namespace MazeSolver.Interfaces;

public interface IFileReader
{
    string?[] GetLines(string filePath);
}