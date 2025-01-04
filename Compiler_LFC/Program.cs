
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

            var errorReporter = new ErrorReporter();
            errorReporter.CheckLexicalErrors(CodeSorce);
            errorReporter.SaveErrorsToFile(errorFile);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Eroare la citirea fisierului: {ex.Message}");
        }
    }
}
