using System;
using System.Collections.Generic;
using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace Compiler_LFC
{
    internal class VariableCollector
    {
        // Metoda care colectează variabilele globale și le scrie într-un fișier
        public static void CollectVariables(string sourceCode, string outputFilePath)
        {
            var inputStream = new AntlrInputStream(sourceCode);
            var lexer = new GrammarLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(lexer);
            var parser = new GrammarParser(commonTokenStream);

            // Adăugăm un ErrorListener pentru a captura erorile
            lexer.RemoveErrorListeners();

            var tree = parser.program();
            Console.WriteLine(tree.ToStringTree(parser));

            // Creăm o listă pentru a stoca variabilele globale
            var variables = new List<string>();
            var visitor = new VariableCollectorVisitor(variables);
            visitor.Visit(tree);

            // Scriem variabilele globale într-un fișier
            using (var writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine("Variabile globale:");
                foreach (var variable in variables)
                {
                    writer.WriteLine(variable);
                }
            }

            Console.WriteLine("Variabilele globale au fost salvate în fișierul: " + outputFilePath);
        }
    }

    // Vizitator pentru colectarea variabilelor globale
    class VariableCollectorVisitor : GrammarBaseVisitor<object>
    {
        private List<string> _variables;

        public VariableCollectorVisitor(List<string> variables)
        {
            _variables = variables;
        }

        // Modificăm vizitarea declarațiilor pentru a adăuga doar variabilele globale
        public override object VisitDeclaration(GrammarParser.DeclarationContext context)
        {
            // Verificăm dacă declarația este într-o funcție sau bloc (adică nu este globală)
            var parent = context.Parent;

            // Adăugăm doar variabilele globale (dacă părintele nu este funcție sau bloc)
            if (!(parent is GrammarParser.FunctionDefinitionContext || parent is GrammarParser.BlockContext))
            {
                // Extragem tipul și numele variabilelor (pentru variabilele globale)
                var type = context.type().GetText();
                var identifiers = context.identifier();

                foreach (var identifier in identifiers)
                {
                    var variableInfo = $"{type} {identifier.GetText()}";

                    // Verificăm dacă există o valoare inițializată
                    if (context.ASSIGN() != null)
                    {
                        var expression = context.expression();

                        // Dacă expression este un array, procesăm fiecare element
                        if (expression.Length > 0)
                        {
                            var value = string.Join(" ", Array.ConvertAll(expression, expr => expr.GetText())); // Concatenăm toate expresiile
                            variableInfo += " = " + value;
                        }
                    }

                    // Adăugăm variabila globală în lista de variabile
                    _variables.Add(variableInfo);
                }
            }

            return base.VisitDeclaration(context);
        }
    }
}
