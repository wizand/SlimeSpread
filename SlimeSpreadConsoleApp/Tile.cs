public class Tile
{
    public Tile(ref Tile[][] tiles, Coords coords, bool isWall= false)
    {
        Tiles = tiles;
        IsWall = isWall;
        Coords = coords;
    }

    public Tile[][] Tiles { get; }
    public bool IsWall { get; }
    public Coords Coords { get; }
}