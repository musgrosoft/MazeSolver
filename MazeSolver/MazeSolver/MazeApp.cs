using MazeSolver.Data;
using MazeSolver.Interfaces;

namespace MazeSolver;

public class MazeApp
{
    private readonly IFileReader _fileReader;
    private readonly IGridLoader _gridLoader;
    private readonly IMazeWalker _mazeWalker;

    public MazeApp(IFileReader fileReader, IGridLoader gridLoader, IMazeWalker mazeWalker)
    {
        _fileReader = fileReader;
        _gridLoader = gridLoader;
        _mazeWalker = mazeWalker;
    }

    public MazeSolution Run(string mazeFilePath)
    {
        var lines = _fileReader.GetLines(mazeFilePath);
        var maze = _gridLoader.Load(lines);
        return _mazeWalker.Solve(maze);
    }
}