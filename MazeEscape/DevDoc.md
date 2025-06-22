# Developers Documentation
In this code from `System` package  I used `System.Console` (for echoing the output) `System.ConsoleKey` (for input) `System.IO` (for reading file) `System.Diagnostics` (for console command `ls` ) `System.Threading` (for slowing the process for AI). <br>
Every code in here is in the package `MazeEscape`
### `MazeEscape.Entities`
#### `class Position { ... }`: <br>
**Descrpition** : This class is used for saving the Position of player or AI.<br>
**Fields** : `public int x,y`<br>
**Methods** :  
`public override bool Equals(object? obj)` - this is `System.Object.Equals(object obj)` methods override for class `Position`<br>
`public override int GetHashCode()` - this is `System.Object.GetHashCode()` methods override for class `Position`
### `MazeEscape.Game`