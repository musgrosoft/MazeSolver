using MazeSolver.Data;
using MazeSolver.Interfaces;

namespace MazeSolver;

public class DumbMazeWalker : IMazeWalker
{
    private MazeGrid m_MazeGrid;
    private Orientation m_direc;
        

    public bool CanSeeLeftTurning()
    {
        var pointToOurLeft = new Point(CurrentPosition.X, CurrentPosition.Y);

        switch (m_direc)
        {
            case Orientation.North:
                pointToOurLeft.X -= 1;
                break;
            case Orientation.South:
                pointToOurLeft.X += 1;
                break;
            case Orientation.East:
                pointToOurLeft.Y -= 1;
                break;
            case Orientation.West:
                pointToOurLeft.Y += 1;
                break;
            default:
                throw new Exception();
        }

        return m_MazeGrid.Grid[pointToOurLeft.Y][pointToOurLeft.X];
    }

    public Point CurrentPosition { get; set; }

    public void TurnRight()
    {
        switch (m_direc)
        {
            case Orientation.North:
                m_direc = Orientation.East;
                break;
            case Orientation.East:
                m_direc = Orientation.South;
                break;
            case Orientation.South:
                m_direc = Orientation.West;
                break;
            case Orientation.West:
                m_direc = Orientation.North;
                break;
            default:
                throw new Exception();
        }
    }

    public void TurnLeft()
    {
        switch (m_direc)
        {
            case Orientation.North:
                m_direc = Orientation.West;
                break;
            case Orientation.West:
                m_direc = Orientation.South;
                break;
            case Orientation.South:
                m_direc = Orientation.East;
                break;
            case Orientation.East:
                m_direc = Orientation.North;
                break;
            default:
                throw new Exception();
        }
    }

    public bool MoveForward()
    {
        var desiredPoint = new Point(CurrentPosition.X, CurrentPosition.Y);

        switch (m_direc)
        {
            case Orientation.North:
                desiredPoint.Y -= 1;
                break;
            case Orientation.South:
                desiredPoint.Y += 1;
                break;
            case Orientation.East:
                desiredPoint.X += 1;
                break;
            case Orientation.West:
                desiredPoint.X -= 1;
                break;
            default:
                throw new Exception();
        }

        var canMoveForward = m_MazeGrid.Grid[desiredPoint.Y][desiredPoint.X];
        if (canMoveForward) CurrentPosition = desiredPoint;
        return canMoveForward;
    }

    public bool AtFinish()
    {
        return m_MazeGrid.Finish.X == CurrentPosition.X && m_MazeGrid.Finish.Y == CurrentPosition.Y;
    }

    public MazeSolution Solve(MazeGrid grid)
    {
        m_MazeGrid = grid;
        CurrentPosition = m_MazeGrid.StartPosition;
        m_direc = Orientation.South;

        var mazeSolution = new MazeSolution
        {
            Solved = false
        };

        int counter = 0;

        while (!mazeSolution.Solved)
        {
            mazeSolution.Moves.Add($"Current Position {CurrentPosition} , facing {m_direc}" );

            var couldMoveForward = MoveForward();

            if (!couldMoveForward)
            {
                TurnRight();
            }
            else
            {
                if (CanSeeLeftTurning())
                {
                    TurnLeft();
                }
            }

            mazeSolution.Solved = AtFinish();
            
            counter++;
            if (counter > 1000000)
            {
                break;
            }
        }

        return mazeSolution;

    }
        
}