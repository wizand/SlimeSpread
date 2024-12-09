public class Ruleset

{

    public const int DEATH_CHANGE = 20;
    public const int REPRODUCTION_CHANCE = 13;
    internal static void RuleYouDie(ref Tile[][] slimeMap)
    {
        for (int y = 0; y < slimeMap.Length; y++)
        {
            for (int x = 0; x < slimeMap[y].GetLength(0); x++)
            {
                if (slimeMap[y][x].IsWall)
                {
                    continue;
                }

                if (slimeMap[y][x].IsSlime())
                {
                    if (ThrowDice(DEATH_CHANGE))
                    {
                        slimeMap[y][x].KillSlime();
                    }
                }
            }
        }
    }

    /// <summary>
    /// Each slime cell has a chance to reproduce.
    /// </summary>
    /// <param name="slimeMap"></param>
    internal static void RuleYouReproduce(ref Tile[][] slimeMap)
    {
        for (int y = 0; y < slimeMap.Length; y++)
        {
            for (int x = 0; x < slimeMap[y].GetLength(0); x++)
            {
                if (slimeMap[y][x].IsWall)
                {
                    continue;
                }

                if (slimeMap[y][x].IsSlime())
                {
                    if (ThrowDice(REPRODUCTION_CHANCE))
                    {
                        slimeMap[y][x].ReproduceSlime();
                    }
                }
            }
        }
    }

    private static bool ThrowDice(int chance)
    {
        Random rand = new Random();
        return !(chance <= rand.Next(100));
    }


    internal static void RuleYouSpread(ref Tile[][] tiles)
    {
        for (int y = 0; y < tiles.Length; y++)
        {
            for (int x = 0; x < tiles[y].GetLength(0); x++)
            {
                if (tiles[y][x].IsSlime())
                {
                    if (tiles[y][x].SlimeHeight > 1)
                    {
                        //TODO: Make this relative to the current tiles height - lowest neighbour so spread doesnt happen to upper slope
                        Tile lowestNeighbor = tiles[y][x].GetLowestNeighbour();
                        lowestNeighbor.SlimeHeight += 1;
                        tiles[y][x].SlimeHeight -= 1;
                    }
                }
            }
        }
    }


    private static int overcrowdingLimit = 5;
    internal static void RuleYouAreOvercrowded(ref Tile[][] tiles)
    {
        for (int y = 0; y < tiles.Length; y++)
        {
            for (int x = 0; x < tiles[y].GetLength(0); x++)
            {
                if (tiles[y][x].IsSlime())
                {
                    if (tiles[y][x].SlimeHeight > overcrowdingLimit)
                    {
                        tiles[y][x].KillSlime();
                    }
                }
            }
        }
    }

}