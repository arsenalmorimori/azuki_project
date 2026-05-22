using System;
using System.Collections.Generic;

class Maze
{
    public int Width { get; }
    public int Height { get; }
    public char[,] Map { get; private set; }
    public (int X, int Y) StartPosition { get; } = (1, 1);
    public (int X, int Y) FinishPosition { get; private set; }

    public Maze(int width, int height)
    {
        Width = width;
        Height = height;
        Map = new char[Height, Width];
        GenerateMaze();
    }

    private void GenerateMaze()
    {
        // 1. Fill with walls
        for (int y = 0; y < Height; y++)
            for (int x = 0; x < Width; x++)
                Map[y, x] = '█';

        // 2. Use Randomized Depth-First Search (DFS) for carving paths
        Random rand = new Random();
        Stack<(int x, int y)> stack = new Stack<(int, int)>();
        stack.Push(StartPosition);
        Map[StartPosition.Y, StartPosition.X] = ' ';

        int[] dx = { 0, 0, -2, 2 }; // Directions for carving (2 units away)
        int[] dy = { -2, 2, 0, 0 };

        while (stack.Count > 0)
        {
            var (cx, cy) = stack.Peek();
            List<int> dirs = new List<int> { 0, 1, 2, 3 };
            bool moved = false;

            while (dirs.Count > 0)
            {
                int dir = dirs[rand.Next(dirs.Count)];
                dirs.Remove(dir);

                int nx = cx + dx[dir];
                int ny = cy + dy[dir];

                // Check bounds and if the next cell is a wall
                if (nx > 0 && ny > 0 && nx < Width - 1 && ny < Height - 1 && Map[ny, nx] == '█')
                {
                    // Carve path between current cell (c) and next cell (n)
                    Map[cy + dy[dir] / 2, cx + dx[dir] / 2] = ' '; // Open the wall (the cell in between)
                    Map[ny, nx] = ' ';                              // Open the next cell
                    stack.Push((nx, ny));
                    moved = true;
                    break;
                }
            }

            if (!moved) stack.Pop();
        }

        // 3. Mark Start and Finish
        FinishPosition = (Width - 2, Height - 2);
        Map[StartPosition.Y, StartPosition.X] = 'S';
        Map[FinishPosition.Y, FinishPosition.X] = 'F';
    }

    public void Draw()
    {
        Console.Clear();
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
                Console.Write(Map[y, x]);
            Console.WriteLine();
        }
    }
}