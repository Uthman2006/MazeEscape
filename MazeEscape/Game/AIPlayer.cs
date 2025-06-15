using System.Collections.Generic;
using MazeEscape.Entities;

namespace MazeEscape.Game
{
    public static class AIPlayer
    {
        public static Position CalculateNextMove(GameState gameState)
        {

        }
        private static List<Position> findShortestPath(char[,] maze, Position start, Position end)
        {
            int width = maze.GetLength(1);
            int height = maze.GetLength(0);
            Queue<List<Position>> q = new();
            HashSet<Position> visited = new();
            q.Enqueue(new List<Position> { start });
            
        }
    }
}