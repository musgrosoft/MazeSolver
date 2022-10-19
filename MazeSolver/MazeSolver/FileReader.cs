using MazeSolver.Interfaces;

namespace MazeSolver;

public class FileReader : IFileReader
{
    public string?[] GetLines(string filePath)
    {
        return new StreamReader(new FileStream(filePath, FileMode.Open))
            .ReadToEnd()
            .Replace(" ", "")
            .Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    }
}