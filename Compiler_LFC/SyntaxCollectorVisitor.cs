using System;
using System.Collections.Generic;
using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace Compiler_LFC
{
    internal class SyntaxCollector
    {
        // Metoda care colectează informațiile despre sintaxa programului și le scrie într-un fișier
        public static void CollectSyntax(string sourceCode, string outputFilePath)
        {
            var inputStream = new AntlrInputStream(sourceCode);
            var lexer = new GrammarLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(lexer);
            var parser = new GrammarParser(commonTokenStream);

            // Adăugăm un ErrorListener pentru a captura erorile
            lexer.RemoveErrorListeners();

            var tree = parser.program();
            //Console.WriteLine(tree.ToStringTree(parser));

            // Creăm liste pentru a stoca funcțiile și structurile de control
            var functions = new List<string>();
            var controlStructures = new List<string>();
            var localVariables = new List<string>();

            var visitor = new SyntaxCollectorVisitor(functions, controlStructures, localVariables);
            visitor.Visit(tree);

            // Scriem informațiile într-un fișier
            using (var writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine("Funcții:");
                foreach (var function in functions)
                {
                    writer.WriteLine(function);
                }

                writer.WriteLine("\nStructuri de control:");
                foreach (var controlStructure in controlStructures)
                {
                    writer.WriteLine(controlStructure);
                }

                writer.WriteLine("\nVariabile locale:");
                foreach (var variable in localVariables)
                {
                    writer.WriteLine(variable);
                }
            }

            Console.WriteLine("Informațiile de sintaxă au fost salvate în fișierul: " + outputFilePath);
        }
    }

    // Vizitator pentru colectarea sintaxei
    class SyntaxCollectorVisitor : GrammarBaseVisitor<object>
    {
        private List<string> _functions;
        private List<string> _controlStructures;
        private List<string> _localVariables;
        private GrammarParser.FunctionDefinitionContext _currentFunctionContext;
        public SyntaxCollectorVisitor(List<string> functions, List<string> controlStructures, List<string> localVariables)
        {
            _functions = functions;
            _controlStructures = controlStructures;
            _localVariables = localVariables;
        }

        // Vizitator pentru funcții
        public override object VisitFunctionDefinition(GrammarParser.FunctionDefinitionContext context)
        {
            _currentFunctionContext = context;
            var functionType = context.type().GetText();
            var functionName = context.identifier().GetText();
            var parameters = context.parameterList() != null
                ? string.Join(", ", context.parameterList().parameter().Select(p => p.GetText()))
                : "N/A";
            var returnType = context.type().GetText();

            // Determinăm dacă funcția este recursivă sau nu
            var isRecursive = IsRecursiveFunction(functionName);

            // Adăugăm funcția în lista de funcții
            var functionInfo = $"{functionType} {functionName}({parameters}) -> {returnType} (Recursivă: {isRecursive})";
            _functions.Add(functionInfo);

            // Colectăm variabilele locale în funcție
            var localVariables = CollectLocalVariables(context);
            foreach (var variable in localVariables)
            {
                _localVariables.Add(variable);
            }

            return base.VisitFunctionDefinition(context);
        }

        // Verificăm dacă o funcție este recursivă
        private bool IsRecursiveFunction(string functionName)
        {
            // Obține corpul funcției curente
            var blockContext = _currentFunctionContext.block();

            // Dacă nu există un corp de funcție, nu poate fi recursivă
            if (blockContext == null)
                return false;

            // Verificăm fiecare declarație din corpul funcției
            foreach (var statement in blockContext.statement())
            {
                // Dacă găsim un apel de funcție cu același nume
                if (ContainsRecursiveCall(statement, functionName))
                    return true;
            }

            // Nu s-a găsit nicio apelare recursivă
            return false;
        }

        private bool ContainsRecursiveCall(GrammarParser.StatementContext statement, string functionName)
        {
            // Caută apeluri de funcție în arborele contextului
            var functionCalls = FindAllFunctionCalls(statement);

            // Verifică dacă vreun apel de funcție are același nume cu funcția curentă
            return functionCalls.Any(call => call.identifier().GetText() == functionName);
        }

        private IEnumerable<GrammarParser.FunctionCallContext> FindAllFunctionCalls(ParserRuleContext context)
        {
            var functionCalls = new List<GrammarParser.FunctionCallContext>();

            // Parcurge toate nodurile copil ale contextului
            foreach (var child in context.children)
            {
                if (child is GrammarParser.FunctionCallContext functionCall)
                {
                    functionCalls.Add(functionCall);
                }
                else if (child is ParserRuleContext childContext)
                {
                    // Caută recursiv în nodurile copil
                    functionCalls.AddRange(FindAllFunctionCalls(childContext));
                }
            }

            return functionCalls;
        }


        // Colectăm variabilele locale dintr-o funcție
        private List<string> CollectLocalVariables(GrammarParser.FunctionDefinitionContext context)
        {
            var localVariables = new List<string>();
            var statements = context.block().statement();

            foreach (var statement in statements)
            {
                if (statement.declaration() != null)
                {
                    // Extragem tipul și numele variabilelor
                    var type = statement.declaration().type().GetText();
                    var identifiers = statement.declaration().identifier();

                    foreach (var identifier in identifiers)
                    {
                        var variableInfo = $"{type} {identifier.GetText()}";

                        // Verificăm dacă există o valoare inițializată
                        if (statement.declaration().ASSIGN() != null)
                        {
                            var expressions = statement.declaration().expression(); // Acum este un tablou de expresii

                            // Iterăm prin toate expresiile pentru a le prelucra
                            foreach (var expression in expressions)
                            {
                                var value = expression.GetText(); // Preluăm textul expresiei
                                variableInfo += " = " + value;
                            }
                        }

                        localVariables.Add(variableInfo);
                    }
                }
            }

            return localVariables;
        }


        // Vizitator pentru structurile de control
        public override object VisitIfStatement(GrammarParser.IfStatementContext context)
        {
            var lineNumber = context.Start.Line;
            _controlStructures.Add($"IF (Linia {lineNumber})");
            if (context.ELSE() != null)
            {
                _controlStructures.Add($"IF...ELSE (Linia {lineNumber})");
            }
            return base.VisitIfStatement(context);
        }

        public override object VisitWhileStatement(GrammarParser.WhileStatementContext context)
        {
            var lineNumber = context.Start.Line;
            _controlStructures.Add($"WHILE (Linia {lineNumber})");
            return base.VisitWhileStatement(context);
        }

        public override object VisitForStatement(GrammarParser.ForStatementContext context)
        {
            var lineNumber = context.Start.Line;
            _controlStructures.Add($"FOR (Linia {lineNumber})");
            return base.VisitForStatement(context);
        }
    }
}
