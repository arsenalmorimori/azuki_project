class Player
{
    public int X { get; private set; }
    public int Y { get; private set; }
    private readonly Maze _maze;

    public Player(Maze maze)
    {
        _maze = maze;
        X = maze.StartPosition.X;
        Y = maze.StartPosition.Y;
    }

    public bool TryMove(ConsoleKey key)
    {
        int newX = X, newY = Y;

        if (key == ConsoleKey.UpArrow) newY--;
        else if (key == ConsoleKey.DownArrow) newY++;
        else if (key == ConsoleKey.LeftArrow) newX--;
        else if (key == ConsoleKey.RightArrow) newX++;
        else return false; // Not a movement key

        // Check if the new position is a valid, open space
        if (env.maze_dev == 0) {
             if (_maze.Map[newY, newX] == ' '  || _maze.Map[newY, newX] == 'F'){
                // Erase old position on the console
                Console.SetCursorPosition(X, Y);
                Console.Write(' ');

                // Update player state
                X = newX;
                Y = newY;

                // Draw new position on the console
                Console.SetCursorPosition(X, Y);
                Console.Write('P');

                return true;
            }
        }
        else {
            if (_maze.Map[newY, newX] == ' '|| _maze.Map[newY, newX] == '█'|| _maze.Map[newY, newX] == 'F'){
                // Erase old position on the console
                Console.SetCursorPosition(X, Y);
                Console.Write(' ');

                // Update player state
                X = newX;
                Y = newY;

                // Draw new position on the console
                Console.SetCursorPosition(X, Y);
                Console.Write('P');

                return true;
            }
        }
       

        return false; // Collision with a wall
    }

    public bool HasFinished()
    {
        return X == _maze.FinishPosition.X && Y == _maze.FinishPosition.Y;
    }
}