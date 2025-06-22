# Developers Documentation
In this code from `System` package  I used `System.Console` (for echoing the output) `System.ConsoleKey` (for input) `System.IO` (for reading file) `System.Diagnostics` (for console command `ls` ) `System.Threading` (for slowing the process for AI) `System.Collections.Generic` (for data and algorithm)<br>
Every code in here is in the package `MazeEscape`
### `MazeEscape.Entities`
#### `class Position { ... }` :
**Descrpition** : This class is used for saving the Position of player or AI.<br>
**Fields** : `public int x,y`<br>
**Methods** :  
`public override bool Equals(object? obj)` - this is `System.Object.Equals(object obj)` methods override for class `Position`<br>
`public override int GetHashCode()` - this is `System.Object.GetHashCode()` methods override for class `Position`
### `MazeEscape.Game`
#### `class AIPlayer { ... }` :
**Description** : This class is used for moving the AI in the maze and finding the shortest route for it.<br>
**Methods** :
`public static Position calculateNextMove(GameState gameState)` - this method is used for calculating next move of the AI. It takes one argumnet which is `GameState gameState` which consists of `char[,] maze`, `Position aiPosition`, `Position exitPosition` which is needed for this method.<br>
`private static List<Position>? findShortestPath(char [,] maze, Position start, Position end)` - this method is used for finding the shortest path for AI. This method uses BFS (Breadth-First-Search) algorithmd to find the shortest route from start to end. It also uses `System.Collections.Generic.Queue<T>` and `System.Collections.Generic.HashSet<T>` classes for this algorithm.<br>
`private static bool isValidPosition(char [,] maze, Position pos)` - this method checks if the given argument is a valid position in the maze. it checks if the position is inside the maze and if the position is not a null
#### `class GameState { ... }`:
**Description**: This class mainly focuses on new position of the player and moving the AI. 
**Fields** : ``