using System;
using System.Collections.Generic;
using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace Compiler_LFC
{
    internal class ErrorReporter
    {
        private List<string> _errorMessages = new List<string>();

        public void ReportError(string message)
        {
            _errorMessages.Add(message);
        }

        public void PrintErrorsToConsole()
        {
            if (_errorMessages.Count > 0)
            {
                foreach (var error in _errorMessages)
                {
                    Console.WriteLine("Error: " + error);
                }
            }
            else
            {
                Console.WriteLine("No errors found.");
            }
        }

        public void SaveErrorsToFile(string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                if (_errorMessages.Count > 0)
                {
                    foreach (var error in _errorMessages)
                    {
                        writer.WriteLine("Error: " + error);
                    }
                    Console.WriteLine("Informatiile de sintaxa au fost salvate în fisierul: " + filePath);
                }
                else
                {
                    writer.WriteLine("No errors found.");
                    Console.WriteLine("Informatiile de sintaxa nu au fost salvate în fisierul: " + filePath);
                }
            }
        }

        public void CheckLexicalErrors(string sourceCode)
        {
            var inputStream = new AntlrInputStream(sourceCode);
            var lexer = new GrammarLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(lexer);

            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new LexicalErrorListener(this));
            commonTokenStream.Fill();


            // Leaver this empty for now, as lexical errors are handled during the token stream.
        }

        public void CheckSemanticErrors(GrammarParser.ProgramContext program)
        {
            var globalVariables = new HashSet<string>();
            var functionSignatures = new HashSet<string>();
            var visitor = new SemanticErrorVisitor(this, globalVariables, functionSignatures);
            visitor.Visit(program);
        }
    }


    // Error listener for lexical errors
    // Error listener for lexical errors
    class LexicalErrorListener : IAntlrErrorListener<int>
    {
        private readonly ErrorReporter _errorReporter;

        public LexicalErrorListener(ErrorReporter errorReporter)
        {
            _errorReporter = errorReporter;
        }

        public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            // Raportăm eroarea de sintaxă (lexicală)
            _errorReporter.ReportError($"Lexical error at line {line}:{charPositionInLine} - {msg}");
        }
    }

    // Visitor for checking semantic errors
    class SemanticErrorVisitor : GrammarBaseVisitor<object>
    {
        private readonly ErrorReporter _errorReporter;
        private readonly HashSet<string> _globalVariables;
        private readonly HashSet<string> _functionSignatures;
        private readonly HashSet<string> _localVariables = new HashSet<string>();

        public SemanticErrorVisitor(ErrorReporter errorReporter, HashSet<string> globalVariables, HashSet<string> functionSignatures)
        {
            _errorReporter = errorReporter;
            _globalVariables = globalVariables;
            _functionSignatures = functionSignatures;
        }

        public override object VisitFunctionDefinition(GrammarParser.FunctionDefinitionContext context)
        {
            // Verificăm unicitatea funcțiilor
            var functionName = context.identifier().GetText();
            var parameterList = context.parameterList() != null
                ? string.Join(", ", context.parameterList().parameter().Select(p => p.GetText()))
                : "N/A";

            var functionSignature = $"{functionName}({parameterList})";

            if (_functionSignatures.Contains(functionSignature))
            {
                _errorReporter.ReportError($"Semantic error: Duplicate function {functionSignature}");
            }
            else
            {
                _functionSignatures.Add(functionSignature);
            }

            // Verificăm variabilele locale
            var localVariables = new HashSet<string>();

            foreach (var statement in context.block().statement())
            {
                if (statement.declaration() != null)
                {
                    foreach (var identifier in statement.declaration().identifier())
                    {
                        var varName = identifier.GetText();

                        if (localVariables.Contains(varName))
                        {
                            _errorReporter.ReportError($"Semantic error: Duplicate local variable {varName} in function {functionName}");
                        }
                        else
                        {
                            localVariables.Add(varName);
                        }
                    }
                }
            }

            return base.VisitFunctionDefinition(context);
        }

        public override object VisitDeclaration(GrammarParser.DeclarationContext context)
        {
            // Check if the declaration is at the global level
            // A global declaration is outside of a function's scope.
            bool isGlobal = context.Parent is GrammarParser.ProgramContext;

            // Get all the identifiers from the declaration
            var identifiers = context.identifier();

            // Check if the declaration is at the global level
            if (isGlobal)
            {
                foreach (var identifier in identifiers)
                {
                    var varName = identifier.GetText();

                    // Check if the variable already exists in the global variables set
                    if (_globalVariables.Contains(varName))
                    {
                        _errorReporter.ReportError($"Semantic error: Duplicate global variable {varName}");
                    }
                    else
                    {
                        _globalVariables.Add(varName);
                    }
                }
            }

            return base.VisitDeclaration(context);
        }
    }
}
