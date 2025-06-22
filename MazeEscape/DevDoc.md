# Developers Documentation
In this code from `System` package  I used `System.Console` (for echoing the output) `System.ConsoleKey` (for input) `System.IO` (for reading file) `System.Diagnostics` (for console command `ls` ) `System.Threading` (for slowing the process for AI) `System.Collections.Generic` (for data and algorithm)<br>
Every code in here is in the package `MazeEscape`
### `MazeEscape.Entities`
#### `class Position(int x, int y) { ... }` :
**Descrpition** : This class is used for saving the Position of player or AI.<br>
**Fields** : `public int x,y`<br>
**Methods** :<br>
`public override bool Equals(object? obj)` - this is `System.Object.Equals(object obj)` methods override for class `Position`<br>
`public override int GetHashCode()` - this is `System.Object.GetHashCode()` methods override for class `Position`
### `MazeEscape.Game`
#### `class AIPlayer() { ... }` :
**Description** : This class is used for moving the AI in the maze and finding the shortest route for it.<br>
**Methods** :<br>
`public static Position calculateNextMove(GameState gameState)` - this method is used for calculating next move of the AI. It takes one argumnet which is `GameState gameState` which consists of `char[,] maze`, `Position aiPosition`, `Position exitPosition` which is needed for this method.<br>
`private static List<Position>? findShortestPath(char [,] maze, Position start, Position end)` - this method is used for finding the shortest path for AI. This method uses BFS (Breadth-First-Search) algorithmd to find the shortest route from start to end. It also uses `System.Collections.Generic.Queue<T>` and `System.Collections.Generic.HashSet<T>` classes for this algorithm.<br>
`private static bool isValidPosition(char [,] maze, Position pos)` - this method checks if the given argument is a valid position in the maze. it checks if the position is inside the maze and if the position is not a null
#### `class GameState(char[,] maze, Position playerStart, Position aiStart, Position exit) { ... }`:
**Description**: This class mainly focuses on new position of the player and moving the AI.<br>
**Fields** : `public char[,] maze`, `public Position playerPosition`, `public Position aiPosition`, `public Position exitPosition`, `public bool gameOver`,`public string? winner`<br>
**Methods**:<br>
`public bool tryMovePlayer(int dx, int dy)` - this method is used for to check if the next position is a valid for player. This method tries to move the player if the next position is not valid, then it returns false. Otherwise, returns true.<br>
`public bool isValidMove(int x, int y)` - this method is the same as in the `class AIPlayer`<br>
`public void checkWin(string entity)` - this method finds the winner of the game, and assigns it to the `string? winner` variable.<br>
`public void moveAI(Position nextPosition)` - this method moves the AI to the parameter nextPosition.<br>
`public int getHeight()` and `public int getWidth()` - this methods return mazes height and width.
#### `public static class MazeLoader() { ... }`:
**Description**: This class is used for getting the path oof the maze in the file and loading it to the memory and parsing the given data such as Start Player Position, Start AI Position, and Exit Position.<br>
**Methods**:<br>
`public static (char[,] maze, Position? player, Position? aiStart, Position? exit) loadMaze(string path)` - this method reads the given maze and prepares it for the game. It also parses the position of Player, AI, and Exit.
### `MazeEscape.Utilities`
#### `public static class Constants() { ... }`:
**Description**: This class mainly focuses on constants of the game.<br>
**Constants**: `public const int AIMoveDelay`, `public const char PlayerStart = 'P'`, `public const char AIStart = 'A'`,`public const char Exit = 'E'`,`public const char Path ='.'`, `public const char Wall='#'`
### `MazeEscape`
#### `public class ConsoleGame() { ... }`:
**Description**: This class is the main part of this game. Everything function is called in order so that the game run flawlessly.<br>
**Fields**: `private GameState gameState`, `private int turnCount = 0`, `private bool playerTurn = true`, `string maze`<br>
**Methds**:<br>
