using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace Compiler_LFC
{
    internal class TokenExtractor
    {
        public static void ExtractTokens(string sourceCode, string outputFilePath)
        {
            var inputStream = new AntlrInputStream(sourceCode);
            var lexer = new GrammarLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(lexer);
            var parser = new GrammarParser(commonTokenStream);

            // Adăugăm un ErrorListener pentru a captura erorile
            lexer.RemoveErrorListeners();
            //lexer.AddErrorListener(new DiagnosticErrorListener());

            //var tokens = lexer.GetAllTokens(); // Obținem toate tokenurile

            var tree = parser.program();

            //Console.WriteLine(tree.ToStringTree(parser));

            //Scriem rezultatele într-un fișier

            commonTokenStream.GetText();

            //var writer = new StreamWriter(outputFilePath);
            //writer.WriteLine(tree.ToStringTree(parser));

            using (var writer = new StreamWriter(outputFilePath))
            {
                foreach (var token in commonTokenStream.GetTokens())
                {
                    if (token.Type != GrammarLexer.WS && token.Type != GrammarLexer.LINE_COMMENT && token.Type != GrammarLexer.BLOCK_COMMENT)
                    {
                        writer.WriteLine($"<token: {token.Text}, lexema: {token.Text}, linie: {token.Line}>");
                    }
                }
            }

            Console.WriteLine("Unitatile lexicale au fost salvate in fiierul: " + outputFilePath);
        }

        class CustomVisitor : GrammarBaseVisitor<object>
        {

        }
    }
}
