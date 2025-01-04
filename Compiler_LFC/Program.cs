
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

            TokenExtractor.ExtractTokens(CodeSorce, outputCode);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Eroare la citirea fisierului: {ex.Message}");
        }
    }
}
