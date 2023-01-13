public class Coords 
{
    public static int X_MAX = 0;
    public static int Y_MAX = 0;

    public Coords(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }


    public Coords OneNorth => new Coords(X, Y-1);
    public Coords OneEast => new Coords(X+1, Y);
    public Coords OneSouth => new Coords(X, Y + 1);
    public Coords OneWest => new Coords(X-1, Y);


    public bool IsValid()
    {
        if ( X < 0 || X > X_MAX )
            return false;
        if (Y < 0 || Y > Y_MAX)
            return false;
        return true;
    }

    public override string ToString()
    {
        return $"[{X},{Y}]";
    }
}