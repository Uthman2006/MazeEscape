namespace MazeEscape.Entities
{
    public class Position
    {
        public int x, y;
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override bool Equals(object? obj)
        {
            return obj is Position position && x == position.x && y == position.y;
        }
        public override int GetHashCode()
        {
            return System.HashCode.Combine(x, y);
        }
    }
}