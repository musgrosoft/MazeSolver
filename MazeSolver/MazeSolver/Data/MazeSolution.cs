namespace MazeSolver.Data;

public class MazeSolution
{
    public MazeSolution()
    {
        Moves = new List<string>();
    }

    public bool Solved { get; set; }
    public List<string> Moves { get; }
}