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
                }
                else
                {
                    writer.WriteLine("No errors found.");
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
            var type = context.type().GetText();
            var identifiers = context.identifier();

            // Verificăm dacă variabila este globală
            foreach (var identifier in identifiers)
            {
                var varName = identifier.GetText();

                // Verificăm unicitatea variabilelor globale
                if (_globalVariables.Contains(varName))
                {
                    _errorReporter.ReportError($"Semantic error: Duplicate global variable {varName}");
                }
                else
                {
                    _globalVariables.Add(varName);
                }

                // Verificăm compatibilitatea tipurilor
                if (context.ASSIGN() != null)
                {
                    var expression = $"{type} {context.GetText()}";

                    // Verificăm tipul valorii și al variabilei
                    if (type == "int" && !IsIntegerExpression(expression))
                    {
                        _errorReporter.ReportError($"Semantic error: Incompatible type assignment for variable {varName}. Expected int but got {expression}");
                    }
                    else if (type == "double" && !IsDoubleExpression(expression))
                    {
                        _errorReporter.ReportError($"Semantic error: Incompatible type assignment for variable {varName}. Expected double but got {expression}");
                    }
                }
            }

            return base.VisitDeclaration(context);
        }

        private bool IsIntegerExpression(string expression)
        {
            return int.TryParse(expression, out _);
        }

        private bool IsDoubleExpression(string expression)
        {
            return double.TryParse(expression, out _);
        }
    }
}
