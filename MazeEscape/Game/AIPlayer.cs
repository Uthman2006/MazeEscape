using System.Collections.Generic;
using MazeEscape.Entities;
using MazeEscape.Utilities;

namespace MazeEscape.Game
{
    public static class AIPlayer
    {
        public static Position calculateNextMove(GameState gameState)
        {
            List<Position>? path = findShortestPath(gameState.maze, gameState.aiPosition, gameState.exitPosition);
            return (path?.Count > 1) ? path[1] : gameState.aiPosition;
        }
        private static List<Position>? findShortestPath(char[,] maze, Position start, Position end)
        {
            int width = maze.GetLength(1);
            int height = maze.GetLength(0);
            Queue<List<Position>> q = new();
            HashSet<Position> visited = new();
            q.Enqueue(new List<Position> { start });
            visited.Add(start);
            while (q.Count > 0)
            {
                List<Position> path = q.Dequeue();
                Position current = path[path.Count - 1];
                if (current.Equals(end)) return path;
                Position[] neighbors = new[] {
                    new Position(current.x,current.y-1),
                    new Position(current.x+1,current.y),
                    new Position(current.x, current.y + 1),
                    new Position(current.x-1,current.y)
                };
                foreach (Position ng in neighbors)
                {
                    if (isValidPosition(maze, ng) && !visited.Contains(ng))
                    {
                        visited.Add(ng);
                        List<Position> newPath = new(path) { ng };
                        q.Enqueue(newPath);
                    }
                }
            }
            return null;
        }
        private static bool isValidPosition(char[,] maze, Position pos) {
            return pos.x >= 0 && pos.y >= 0 && pos.y < maze.GetLength(0) && pos.x < maze.GetLength(1) && maze[pos.y, pos.x] != Constants.Wall;
        }
    }
}