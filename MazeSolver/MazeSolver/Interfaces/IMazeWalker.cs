using MazeSolver.Data;

namespace MazeSolver.Interfaces;

public interface IMazeWalker
{
    public MazeSolution Solve(MazeGrid grid);
}