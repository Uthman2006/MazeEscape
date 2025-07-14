namespace MazeEscape.Entities
{
    public class Position 
    {
        public int x, y;
        public Position(int x, int y) // saves position of the players as coordinates x and y
        {
            this.x = x;
            this.y = y;
        }
        public override bool Equals(object? obj) // checks if the gven positions are equal. This is override method
        {
            return obj is Position position && x == position.x && y == position.y;
        }
        public override int GetHashCode() // this override method needed for above method.
        {
            return System.HashCode.Combine(x, y);
        }
    }
}