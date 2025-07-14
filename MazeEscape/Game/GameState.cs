using MazeEscape.Entities;
using MazeEscape.Utilities;
namespace MazeEscape.Game
{
    public class GameState
    {
        public char[,] maze;
        public Position playerPosition;
        public Position aiPosition;
        public Position exitPosition;
        public bool gameOver;
        public string? winner;
        public GameState(char[,] maze, Position playerStart, Position aiStart, Position exit)
        {
            this.maze = maze;
            this.playerPosition = playerStart;
            this.aiPosition = aiStart;
            this.exitPosition = exit;
        }
        public bool tryMovePlayer(int dx, int dy) // tries to move player if the given position is not valid returns false
        {
            if (gameOver)
                return false;
            int newX = playerPosition.x + dx;
            int newY = playerPosition.y + dy;
            if (isValidMove(newX, newY))
            {
                playerPosition = new Position(newX, newY);
                checkWin("player");
                return true;
            }
            return false;
        }
        public bool isValidMove(int x, int y)// checks if the given position is in the maze and not on the wall
        {
            if (x < 0 || y < 0 || x >= getWidth() || y >= getHeight())
                return false;
            if (maze[y, x] == Constants.Wall)
                return false;
            return true;
        }
        public void checkWin(string entity) // determines the winner of the game
        {
            Position currentPosition = (entity == "player") ? playerPosition : aiPosition;
            if (currentPosition.Equals(exitPosition))
            {
                gameOver = true;
                winner = entity;
            }
        }
        public void moveAI(Position newPosition) // moves AI and checks if the winner is AI
        {
            if (gameOver)
                return;
            aiPosition = newPosition;
            checkWin("ai");
        }
        public int getHeight() => maze.GetLength(0);
        public int getWidth() => maze.GetLength(1);
    }
}