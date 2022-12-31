using System.Text;

internal class SlimeMap
{

    public Tile[][] tiles;

    public SlimeMap(int xSize, int ySize, int[][] initialWalls = null, int[][] initialSlime = null)
    {
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

    internal void ApplyRules()
    {
        
        for (int y = 0; y < tiles.Length; y++)
        {
            for (int x = 0; x < tiles[y].GetLength(0); x++)
            {
                if (tiles[y][x].IsWall)
                {
                    continue;
                }

                if (tiles[y][x].IsSlime())
                {
                    if (ThrowDice(10))
                    {
                        tiles[y][x].KillSlime();
                    }
                }
            }
        }
    }

    private bool ThrowDice(int chance)
    {
        Random rand = new Random();
        return !(chance <= rand.Next(100));
    }

    internal void Print()
    {
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
            System.Console.WriteLine(sb.ToString());
        }
    }
}
