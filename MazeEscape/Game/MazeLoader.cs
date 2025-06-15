using System;
using System.IO;
using System.Linq;
using MazeEscape.Entities;
using MazeEscape.Utilities;
namespace MazeEscape.Game
{
    public static class MazeLoader
    {
        public static (char[,] maze, Position? playerStart, Position? aiStart, Position? exit) loadMaze(string path)
        {
            string[] lines = File.ReadAllLines(path);
            if (lines.Length == 0)
                throw new InvalidDataException("Maze fiel is empty");
            int width = lines[0].Length;
            int height = lines.Length;
            if (lines.Any(line => line.Length != width))
                throw new InvalidDataException("Not valid maze field: Rows' length don't match");
            char[,] maze = new char[height, width];
            Position? playerStart = null;
            Position? aiStart = null;
            Position? exit = null;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    char cell = lines[y][x];
                    maze[y, x] = cell;
                    switch (cell)
                    {
                        case Constants.PlayerStart:
                            if (playerStart != null)
                                throw new InvalidDataException("Multiple starting points for player");
                            playerStart = new Position(x, y);
                            maze[y, x] = Constants.Path;
                            break;
                        case Constants.AIStart:
                            if (aiStart != null)
                                throw new InvalidDataException("Multiple strating points for AI");
                            aiStart = new Position(x, y);
                            maze[y, x] = Constants.Path;
                            break;
                        case Constants.Exit:
                            if (exit != null)
                                throw new InvalidDataException("Multiple exit points");
                            exit = new Position(x, y);
                            break;
                        case Constants.Path:
                        case Constants.Wall:
                            break;
                        default:
                            throw new InvalidDataException($"Invalid character {cell} at position ({x},{y})");
                    }
                }
            }
            if (playerStart == null)
                throw new InvalidDataException("Starting point for player NOT FOUND");
            if (aiStart == null)
                throw new InvalidDataException("Starting point for NOT FOUND");
            if (exit == null)
                throw new InvalidDataException("Point for exit NOT FOUND");
            return (maze, playerStart, aiStart, exit);
        }
    }
}