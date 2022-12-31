using System.Text;

public class Tile
{
    public Tile(ref Tile[][] tiles, Coords coords, bool isWall = false, int slimeHeight = 0)
    {
        Tiles = tiles;
        IsWall = isWall;
        Coords = coords;
        SlimeHeight = slimeHeight;
    }

    public int SlimeHeight { get; set; }
    public Tile[][] Tiles { get; }
    public bool IsWall { get; }
    public Coords Coords { get; }

    public bool IsSlime()
    {
        return SlimeHeight > 0;
    }

    internal void KillSlime()
    {
        SlimeHeight -= 1;
        if (SlimeHeight < 0)
        {
            SlimeHeight = 0;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append(Coords.ToString());
        sb.Append(" IsWall=[" + IsWall + "] IsSlime=[" + IsSlime() + "] SlimeHeight=[" + SlimeHeight + "]");
        return sb.ToString();
    }
}