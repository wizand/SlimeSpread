public class SlimeTile : Tile
{
    public SlimeTile(ref Tile[][] tiles, Coords coords, int slimeHeight) : base(ref tiles, coords: coords)
    {
       
        SlimeHeight = slimeHeight;
    }

    public int SlimeHeight { get; }
}