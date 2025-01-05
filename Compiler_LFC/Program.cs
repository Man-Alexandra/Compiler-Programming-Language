
using Antlr4.Runtime;
using Compiler_LFC;

public class Program
{
    public static void Main()
    {
        try
        {
            string filePath = @"SorceCode.txt";

            string CodeSorce = System.IO.File.ReadAllText(filePath);

            string outputCode = @"OutPutCode.txt";

            string variableCollector = @"VariableCollector.txt";

            string synataxCollector = @"SyntaxCollector.txt";

            string errorFile = @"ErrorReporter.txt";

            TokenExtractor.ExtractTokens(CodeSorce, outputCode);
            VariableCollector.CollectVariables(CodeSorce,variableCollector);
            SyntaxCollector.CollectSyntax(CodeSorce, synataxCollector);

            var inputStream = new AntlrInputStream(CodeSorce);
            var lexer = new GrammarLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(lexer);
            var parser = new GrammarParser(commonTokenStream);

            // Parse the source code to get the ProgramContext
            var programContext = parser.program();

            var errorReporter = new ErrorReporter();
            errorReporter.CheckLexicalErrors(CodeSorce);
            errorReporter.CheckSemanticErrors(programContext);
            errorReporter.SaveErrorsToFile(errorFile);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Eroare la citirea fisierului: {ex.Message}");
        }
    }
}
