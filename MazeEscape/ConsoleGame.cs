using System;
using System.Diagnostics;
using System.Threading;
using MazeEscape.Entities;
using MazeEscape.Game;
using MazeEscape.Utilities;

namespace MazeEscape
{
    public class ConsoleGame
    {
        private GameState gameState;
        private int turnCount = 0;
        private bool playerTurn = true;
        string maze;
        public void run()
        {
            Console.Title = "Maze Escape - PLayer vs AI";
            chooseMaze();
            resetGame();
            while (true)
            {
                render();
                if (gameState.gameOver)
                {
                    renderGameOver();
                    if (restartHandler())
                    {
                        resetGame();
                        continue;
                    }
                    else break;
                }
                if (playerTurn)
                {
                    playerTurnHandler();
                }
                else
                {
                    aiTurnHandler();
                    Thread.Sleep(Constants.AIMoveDelay);
                }
                playerTurn = !playerTurn;
                turnCount++;
            }
        }
        private void chooseMaze()
        {
            Console.CursorVisible = true;
            Process process = new();
            process.StartInfo.FileName = "bash";
            process.StartInfo.Arguments = "-c \"ls Mazes/\"";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            string files = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            string[] mazes = files.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("Which maze do you wanna choose:");
            for (int i = 0; i < mazes.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {mazes[i]}");
            }
            int mazeNum;
            while (true)
            {
                Console.Write("Select: ");
                if (int.TryParse(Console.ReadLine()!, out mazeNum) && mazeNum >= 1 && mazeNum <= mazes.Length)
                {
                    break;
                }
                Console.WriteLine("Invalid selectio . Try again!!!");
            }
            maze = mazes[mazeNum - 1];
            Console.CursorVisible = false;
        }
        private void loadGame(string mazeFile)
        {
            try
            {
                string mazePath = $"Mazes/{mazeFile}";
                (char[,] maze, Position? playerStart, Position? aiStart, Position? exit) = MazeLoader.loadMaze(mazePath);
                if (playerStart == null || aiStart == null || exit == null) throw new Exception("No sufficient data");
                gameState = new(maze, playerStart, aiStart, exit);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading maze file: {ex.Message}");
                Environment.Exit(1);
            }
        }
        private void resetGame()
        {
            loadGame($"{maze}");
            playerTurn = true;
            turnCount = 0;
        }
        private void render()
        {
            Console.Clear();
            Console.WriteLine($"Turn No {turnCount} - {((playerTurn) ? "Player\'s Turn" : "AI\'s Turn")}");
            Console.WriteLine();
            for (int y = 0; y < gameState.getHeight(); y++)
            {
                for (int x = 0; x < gameState.getWidth(); x++)
                {
                    Position current = new(x, y);
                    if (current.Equals(gameState.playerPosition))
                    {
                        Console.Write(" P");
                    }
                    else if (current.Equals(gameState.aiPosition))
                    {
                        Console.Write(" A");
                    }
                    else if (current.Equals(gameState.exitPosition))
                    {
                        Console.Write(" E");
                    }
                    else
                    {
                        Console.Write(gameState.maze[y, x] == Constants.Wall ? " #" : " .");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Player\'s Position: ({gameState.playerPosition.x}, {gameState.playerPosition.y})");
            Console.WriteLine($"AI\'s Position: ({gameState.aiPosition.x},{gameState.aiPosition.y})");
            Console.WriteLine("Controls: Arrow keys to Move, R to Restart, Q to Quit");
            Console.WriteLine();
        }
        private void renderGameOver()
        {
            Console.WriteLine();
            Console.WriteLine($"==== {((gameState.winner == null) ? "TIE" : $"{gameState.winner.ToUpper()} WINS!")} ====");
            Console.WriteLine($"Game over in {turnCount} turns");
            Console.WriteLine("Press R to restart or Q to quit");
        }
        private void playerTurnHandler()
        {
            Console.WriteLine($"Turn {turnCount + 1}: Your move (use arrow keys)");
            bool validMove = false;
            while (!validMove)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        validMove = gameState.tryMovePlayer(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        validMove = gameState.tryMovePlayer(0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        validMove = gameState.tryMovePlayer(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        validMove = gameState.tryMovePlayer(1, 0);
                        break;
                    case ConsoleKey.R:
                        loadGame($"{maze}");
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
                if (!validMove)
                {
                    Console.WriteLine("Can't move there! Try another direction.");
                }
            }
        }
        private void aiTurnHandler()
        {
            Console.WriteLine($"Turn {turnCount + 1} : AI is moving...");
            Position nextPosition = AIPlayer.calculateNextMove(gameState);
            gameState.moveAI(nextPosition);
        }
        private bool restartHandler()
        {
            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.R)
                {
                    Console.Clear();
                    return true;
                }
                if (key == ConsoleKey.Q) return false;
            }
        }
    }
}