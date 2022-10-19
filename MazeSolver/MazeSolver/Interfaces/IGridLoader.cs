using MazeSolver.Data;

namespace MazeSolver.Interfaces;

public interface IGridLoader
{
    MazeGrid Load(string?[] lines);
}