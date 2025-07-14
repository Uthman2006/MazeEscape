using System.Collections.Generic;
using MazeEscape.Entities;
using MazeEscape.Utilities;

namespace MazeEscape.Game
{
    public static class AIPlayer
    {
        public static Position calculateNextMove(GameState gameState) // finds next position and saves it in the list.
        {
            List<Position>? path = findShortestPath(gameState.maze, gameState.aiPosition, gameState.exitPosition);
            return (path?.Count > 1) ? path[1] : gameState.aiPosition;
        }
        private static List<Position>? findShortestPath(char[,] maze, Position start, Position end) // BFS algorithm for shortest path for AI
        {
            int width = maze.GetLength(1);
            int height = maze.GetLength(0);
            Queue<List<Position>> q = new(); // BFS queue needed for processing vertices
            HashSet<Position> visited = new(); // BFS coloring needed for checking if the certain vertex is processed
            q.Enqueue(new List<Position> { start });
            visited.Add(start);
            while (q.Count > 0) // Main loop of BFS
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
        private static bool isValidPosition(char[,] maze, Position pos) { // checks if the given position is in the maze and not on the wall.
            return pos.x >= 0 && pos.y >= 0 && pos.y < maze.GetLength(0) && pos.x < maze.GetLength(1) && maze[pos.y, pos.x] != Constants.Wall;
        }
    }
}