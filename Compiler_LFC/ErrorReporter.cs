using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
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
        private readonly Dictionary<string, string> _globalVariableTypes = new();
        private readonly Dictionary<string, string> _localVariableTypes = new();
        private readonly Dictionary<string, string> _functionReturnTypes = new();

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
            var type = context.type().GetText();
            _functionReturnTypes[functionName] = type;


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

            // Determine if the declaration is global or local (by checking the parent context)
            bool isGlobal = context.Parent is GrammarParser.ProgramContext;

            // Get the declared type (e.g., int, float, etc.)
            var declaredType = context.type().GetText();

            // Get all the identifiers in the declaration (the variables being declared)
            var identifiers = context.identifier();
            var expressions = context.expression();

            // Loop through each identifier and check for type compatibility
            for (int i = 0; i < identifiers.Length; i++)
            {
                var varName = identifiers[i].GetText();

                // Check for duplicate global variables (if it's a global variable)
                if (isGlobal)
                {
                    if (_globalVariables.Contains(varName))
                    {
                        _errorReporter.ReportError($"Semantic error: Duplicate global variable {varName}");
                    }
                    else
                    {
                        _globalVariables.Add(varName);
                    }
                }
                else
                {
                    // Check for duplicate local variables
                    if (_localVariables.Contains(varName))
                    {
                        _errorReporter.ReportError($"Semantic error: Duplicate local variable {varName}");
                    }
                    else
                    {
                        _localVariables.Add(varName);
                    }
                }
                if (context.expression() != null && context.expression().Length > 0)
                {
                    var value = context.expression()[0]?.GetText();
                    if (!IsTypeCompatible(declaredType, value))
                    {
                        _errorReporter.ReportError($"Semantic error: Type mismatch for variable {context.identifier()[0].GetText()}");
                    }
                }
            }
            return base.VisitDeclaration(context);
        }

        private bool IsTypeCompatible(string type, string? value)
        {
            if (value == null) return true;

            if (value.Contains("(") && value.Contains(")"))
            {
                string functionName = value.Split('(')[0];
                if (_functionReturnTypes.ContainsKey(functionName))
                {
                    return _functionReturnTypes[functionName] == type;
                }
                else
                {
                    Console.WriteLine($" = Error: Function {functionName} is not defined = ");
                    return false;
                }
            }

            switch (type)
            {
                case "int":
                    return int.TryParse(value, out _);
                case "float":
                case "double":
                    return double.TryParse(value, out _);
                case "string":
                    return value.StartsWith("\"") && value.EndsWith("\"");
                default:
                    return false;
            }

        }

    }
}
