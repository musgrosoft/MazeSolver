using MazeSolver.Data;
using MazeSolver.Interfaces;
using System;
using System.Reflection.Metadata;

namespace MazeSolver;

public class RecursiveMazeWalker : IMazeWalker
{
    // const int width = 123;
    // const int height = 456;

    // bool[][] maze = new bool[width][height]; // The maze
    // bool[][] wasHere = new bool[width][height];
    // bool[][] correctPath = new bool[width][height]; // The solution to the maze
    // int startX, startY; // Starting X and Y values of maze
    // int endX, endY;     // Ending X and Y values of maze

    private bool[][]? wasHere;
    private bool[][]? correctPath;

    private int endX = 0;
    private int endY = 0;

    private int width = 0;
    private int height = 0;

    private MazeGrid _grid;

    public MazeSolution Solve(MazeGrid grid)
    {
        _grid = grid;

        endX = grid.Finish.X;
        endY = grid.Finish.Y;

        height = grid.Grid.Length;
        width = grid.Grid[0].Length;

        wasHere = new bool[grid.Grid.Length][];
        for (int i = 0; i < wasHere.Length; i++)
        {
            wasHere[i] = new bool[grid.Grid[0].Length];
        }
        correctPath = new bool[grid.Grid.Length][];
        for (int i = 0; i < correctPath.Length; i++)
        {
            correctPath[i] = new bool[grid.Grid[0].Length];
        }
        // bool[][] correctPath = new bool[width][height]; // The solution to the maze

        //maze = generateMaze(); // Create Maze (false = path, true = wall)
        //for (int row = 0; row < grid.Grid.Length; row++)
        //{
        //    // Sets boolean Arrays to default values
        //    for (int col = 0; col < grid.Grid[row].Length; col++)
        //    {
        //        wasHere[row][col] = false;
        //        correctPath[row][col] = false;
        //    }
        //}

        bool b = recursiveSolve(grid.StartPosition.X, grid.StartPosition.Y);
        // Will leave you with a boolean array (correctPath) 
        // with the path indicated by true values.
        // If b is false, there is no solution to the maze

        var solution =  new MazeSolution
        {
            Solved = b,
        };


        var lines = new List<string>();

        for (int i = 0; i < height; i++)
        {
            var theLine = "";

            for (int j = 0; j < width; j++)
            {
                theLine += correctPath[i][j] ? "x" : ".";
            }

            solution.Moves.Add(theLine);
        }

        return solution;

    }
    public bool recursiveSolve(int x, int y)
    {
        if (x == endX && y == endY)
        {
            correctPath[y][x] = true;
            return true;
        } // If you reached the end
    

        
        // If you are on a wall or already were here
        if (!_grid.Grid[y][x] || wasHere[y][x]) return false;

        wasHere[y][x] = true;
        if (x != 0) // Checks if not on left edge
            if (recursiveSolve(x - 1, y))
            { // Recalls method one to the left
                correctPath[y][x] = true; // Sets that path value to true;
                return true;
            }
        if (x != width ) // Checks if not on right edge
            if (recursiveSolve(x + 1, y))
            { // Recalls method one to the right
                correctPath[y][x] = true;
                return true;
            }
        if (y != 0)  // Checks if not on top edge
            if (recursiveSolve(x, y - 1))
            { // Recalls method one up
                correctPath[y][x] = true;
                return true;
            }
        if (y != height ) // Checks if not on bottom edge
            if (recursiveSolve(x, y + 1))
            { // Recalls method one down
                correctPath[y][x] = true;
                return true;
            }
        return false;
    }

}