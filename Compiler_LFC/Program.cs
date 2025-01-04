
using Compiler_LFC;

public class Program
{
    public static void Main()
    {
        try
        {
            string filePath = @"D:\Anul2\LFC\Compiler_LFC\Compiler_LFC\SorceCode.txt";

            string CodeSorce = System.IO.File.ReadAllText(filePath);

            string outputCode = @"D:\Anul2\LFC\Compiler_LFC\Compiler_LFC\OutPutCode.txt";

            TokenExtractor.ExtractTokens(CodeSorce, outputCode);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Eroare la citirea fisierului: {ex.Message}");
        }
    }
}
