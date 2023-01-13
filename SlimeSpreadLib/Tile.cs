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
        Console.WriteLine("Slime has died at {0}. Slime left on tile=[{1}].", Coords.ToString(), SlimeHeight);
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append(Coords.ToString());
        sb.Append(" IsWall=[" + IsWall + "] IsSlime=[" + IsSlime() + "] SlimeHeight=[" + SlimeHeight + "]");
        return sb.ToString();
    }

    internal void ReproduceSlime()
    {
        SlimeHeight += 1;
        Console.WriteLine("Slime has spawned at {0}. Slime now on tile=[{1}].", Coords.ToString(), SlimeHeight);
    }

    internal Tile GetLowestNeighbour()
    {
        List<Direction> dirs = new List<Direction>() { Direction.NORTH, Direction.SOUTH, Direction.EAST, Direction.WEST };
        List<Tile> lowestTiles = new();
        int lowestNeighbourhoodSlimeLevel = 9999999;
        
        foreach( Direction dir in dirs)
        {
            Tile? neighbour = GetNeighbor(dir);

            //There is no such neighbout.. propaply at an edge or corner.. Or wall. We dont spread to walls.
            if (neighbour == null || neighbour.IsWall)
            {
                continue;
            }

            //If the slime level of neighbour is as low as the lowest this far, just add the tile to the lowest tiles list
            if (neighbour.SlimeHeight == lowestNeighbourhoodSlimeLevel)
            {
                lowestTiles.Add(neighbour);
                continue;
            }

            if (neighbour.SlimeHeight < lowestNeighbourhoodSlimeLevel)
            {
                lowestNeighbourhoodSlimeLevel = neighbour.SlimeHeight;
                //We have a new lowest in town! Clear the ones that have came before!
                lowestTiles.Clear();
                lowestTiles.Add(neighbour);
            }
        }

        if (lowestTiles.Count == 0)
        {
            throw new Exception("Errm.. cannot be. There must be a neighbour, right?! ");
        }

        if (lowestTiles.Count == 1)
        {
            return lowestTiles[0];
        }

        Random rand = new Random();
        //Just for debugging. Make sure the index is correct.
        int randomIndex = rand.Next(lowestTiles.Count);
        Console.WriteLine("Multiple lowest tiles. Selecting index=[{0}] from the count of tiles=[{1}]", randomIndex, lowestTiles.Count);
        return lowestTiles[randomIndex];
    }


    internal Tile? GetNeighbor(Direction dir)
    {
        Coords neighborCoords;
        switch (dir)
        {
            case Direction.NORTH:
                neighborCoords = Coords.OneNorth;
                break;
            case Direction.EAST:
                neighborCoords = Coords.OneEast;
                break;
            case Direction.SOUTH:
                neighborCoords = Coords.OneSouth;
                break;
            case Direction.WEST:
                neighborCoords = Coords.OneWest;
                break;
            default:
                neighborCoords = new Coords(-1, -1);
                break;
        }

        if (neighborCoords.IsValid())
        {
            return Tiles[neighborCoords.Y][neighborCoords.X];
        }
        return null;
    }

}


enum Direction
{
    NORTH, EAST, SOUTH, WEST
}