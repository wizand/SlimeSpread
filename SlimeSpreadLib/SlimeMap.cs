using System.Text;

public class SlimeMap
{

    public static SlimeMap InitiateMap(int[][] initialWalls, int[][] initialSlime)
    {
        return new SlimeMap(initialWalls.Length, initialWalls[0].Length, initialWalls, initialSlime);
    }


    public Tile[][] tiles;
    private Tile[]? _tiles = null;
    public int XSize { get; }
    public int YSize { get; }
    public Tile[] tilesInArray 
    { 
        get
        { 
            if (_tiles == null)
            {
                _tiles = new Tile[tiles.Length * tiles[0].Length];
                for (int y = 0; y < tiles.Length; y++)
                {
                    for ( int x = 0; x < tiles[y].Length; x++)
                    {
                        _tiles[y * tiles[0].Length + x] = tiles[y][x];
                    }
                }
            }
            return _tiles;

        } 
    }

    public SlimeMap(int xSize, int ySize, int[][] initialWalls = null, int[][] initialSlime = null)
    {
        Coords.Y_MAX = ySize;
        Coords.X_MAX = xSize;  

        tiles = new Tile[xSize][];
        for (int y = 0; y < ySize; y++)
        {
            tiles[y] = new Tile[ySize];
        }

        for (int y = 0; y < initialSlime.Length; y++)
        {
            for (int x = 0; x < initialSlime[y].GetLength(0); x++)
            {
                if (initialSlime[y][x] == 0)
                {
                    if (initialWalls[y][x] == 0)
                    {
                        tiles[y][x] = new Tile(ref tiles, coords: new Coords(x,y));
                    } else
                    {
                        tiles[y][x] = new Tile(ref tiles, coords: new Coords(x, y), isWall: true);
                    }
                } else
                {
                    tiles[y][x] = new Tile(ref tiles, coords: new Coords(x, y), slimeHeight: initialSlime[y][x]);
                }
            }
        }

    }

    public bool IsSlimeDead()
    {
        for (int y = 0; y < tiles.Length; y++)
        {
            for (int x = 0; x < tiles[y].GetLength(0); x++)
            {
                if (tiles[y][x].IsSlime())
                {
                    return false;
                }
            }
        }

        return true;
    }

    public void ApplyRules()
    {
        Ruleset.RuleYouDie(ref tiles);
        Ruleset.RuleYouReproduce(ref tiles);
        Ruleset.RuleYouSpread(ref tiles);
        Ruleset.RuleYouAreOvercrowded(ref tiles);
    }



    public string[] GetMapStateAsStringLines()
    {

        string[] lines = new string[tiles.Length];
        for (int y = 0; y < tiles.GetLength(0); y++)
        {
            StringBuilder sb = new();
            sb.Append("[");
            for (int x = 0; x < tiles[y].GetLength(0); x++)
            {
                if (tiles[y][x].IsWall)
                {
                    sb.Append('#');
                }
                else if (tiles[y][x].IsSlime())
                {
                    sb.Append(tiles[y][x].SlimeHeight + "");
                }
                else
                {
                    sb.Append(' ');
                }
            }
            sb.Append("]");
            lines[y] = sb.ToString();
        }
        return lines;
    }
}
