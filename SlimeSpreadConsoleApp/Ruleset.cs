internal class Ruleset
{
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
                    if (ThrowDice(10))
                    {
                        slimeMap[y][x].KillSlime();
                    }
                }
            }
        }
    }

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
                    if (ThrowDice(10))
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
                        //Check neighbors 
                    }
                }
            }
        }
    }
}