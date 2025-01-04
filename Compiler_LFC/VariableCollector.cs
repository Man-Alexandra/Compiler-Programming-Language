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

            var tree = parser.program();

            // Creăm o listă pentru a stoca variabilele globale
            var variables = new List<string>();
            var visitor = new VariableCollectorVisitor(variables);

            // Vizitează arborele de sintaxă
            visitor.Visit(tree);

            // Scrie variabilele în fișier
            File.WriteAllLines(outputFilePath, variables);
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

        public override object VisitProgram(GrammarParser.ProgramContext context)
        {
            // Parcurge fiecare copil al contextului programului
            foreach (var child in context.children)
            {
                // Dacă copilul este o declarație
                if (child is GrammarParser.DeclarationContext declaration)
                {
                    // Obține tipul variabilei
                    string varType = declaration.type().GetText();

                    // Parcurge fiecare identificator și expresie asociată
                    for (int i = 0; i < declaration.identifier().Length; i++)
                    {
                        string varName = declaration.identifier(i).GetText();
                        string varValue = "null"; // Valoare implicită

                        // Verifică dacă există o expresie de asignare
                        if (declaration.expression(i) != null)
                        {
                            varValue = declaration.expression(i).GetText();
                        }

                        // Adaugă variabila la lista globală
                        _variables.Add($"{varType} {varName} = {varValue}");
                    }
                }
            }

            return null; // Returnează null pentru a semnala că vizitarea este finalizată
        }
    }
}
