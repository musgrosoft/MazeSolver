// See https://aka.ms/new-console-template for more information
using MazeSolver;

var fileReader = new FileReader();
var gridLoader = new GridLoader();
//var mazeWalker = new DumbMazeWalker();
var mazeWalker = new RecursiveMazeWalker();

var mazeApp = new MazeApp(fileReader, gridLoader, mazeWalker);
var mazeSolution = mazeApp.Run(@"..\..\..\..\..\maze3.txt");
Console.WriteLine("");
Console.WriteLine(mazeSolution.Solved ? "Reached end of maze! :)" : "Failed but tried : ");
Console.WriteLine("");
foreach (var mazeWalkerMove in mazeSolution.Moves)
{
    Console.WriteLine(mazeWalkerMove);
}

Console.ReadLine();