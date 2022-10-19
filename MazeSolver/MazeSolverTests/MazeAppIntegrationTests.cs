using MazeSolver;
using MazeSolver.Interfaces;
using Xunit;

namespace MazeSolverTests;

public class MazeAppIntegrationTests
{
    [Fact]
    public void ShouldSolveMaze1WithDumbWalker()
    {
        //Given
        var fileReader = new FileReader();
        var gridLoader = new GridLoader();
        var mazeWalker = new DumbMazeWalker();
        var mazeApp = new MazeApp(fileReader, gridLoader,mazeWalker);

        //When
        var mazeSolution = mazeApp.Run("../../../files/maze1.txt");

        //Then
        Assert.True(mazeSolution.Solved);

    }

    [Fact]
    public void ShouldSolveMaze2WithDumbWalker()
    {
        //Given
        var fileReader = new FileReader();
        var gridLoader = new GridLoader();
        var mazeWalker = new DumbMazeWalker();
        var mazeApp = new MazeApp(fileReader, gridLoader, mazeWalker);

        //When
        var mazeSolution = mazeApp.Run("../../../files/maze2.txt");

        //Then
        Assert.True(mazeSolution.Solved);

    }

    [Fact]
    public void ShouldSolveMaze3WithDumbWalker()
    {
        //Given
        var fileReader = new FileReader();
        var gridLoader = new GridLoader();
        var mazeWalker = new DumbMazeWalker();
        var mazeApp = new MazeApp(fileReader, gridLoader, mazeWalker);

        //When
        var mazeSolution = mazeApp.Run("../../../files/maze3.txt");

        //Then
        Assert.True(mazeSolution.Solved);

    }

    [Fact]
    public void ShouldSolveMaze1WithRecursiveMazeWalker()
    {
        //Given
        var fileReader = new FileReader();
        var gridLoader = new GridLoader();
        var mazeWalker = new RecursiveMazeWalker();
        var mazeApp = new MazeApp(fileReader, gridLoader, mazeWalker);

        //When
        var mazeSolution = mazeApp.Run("../../../files/maze1.txt");

        //Then
        Assert.True(mazeSolution.Solved);

    }

    [Fact]
    public void ShouldSolveMaze2WithRecursiveMazeWalker()
    {
        //Given
        var fileReader = new FileReader();
        var gridLoader = new GridLoader();
        var mazeWalker = new RecursiveMazeWalker();
        var mazeApp = new MazeApp(fileReader, gridLoader, mazeWalker);

        //When
        var mazeSolution = mazeApp.Run("../../../files/maze2.txt");

        //Then
        Assert.True(mazeSolution.Solved);

    }

    [Fact]
    public void ShouldSolveMaze3WithRecursiveMazeWalker()
    {
        //Given
        var fileReader = new FileReader();
        var gridLoader = new GridLoader();
        var mazeWalker = new RecursiveMazeWalker();
        var mazeApp = new MazeApp(fileReader, gridLoader, mazeWalker);

        //When
        var mazeSolution = mazeApp.Run("../../../files/maze3.txt");

        //Then
        Assert.True(mazeSolution.Solved);

    }
}