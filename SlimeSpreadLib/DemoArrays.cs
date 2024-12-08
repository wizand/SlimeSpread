using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeSpreadConsoleApp
{
    public static class DemoArrays
    {
        public static int[][] initial5x5Slime =
        {
            new int[5]{ 0, 0, 0, 0, 0 },
            new int[5]{ 0, 0, 0, 0, 0 },
            new int[5]{ 0, 3, 3, 0, 0 },
            new int[5]{ 0, 0, 0, 0, 0 },
            new int[5]{ 0, 0, 0, 0, 0 }
        };
        public static int[][] initial5x5Walls =
        {
            new int[5]{ 1, 1, 1, 1, 1 },
            new int[5]{ 1, 0, 0, 1, 1 },
            new int[5]{ 1, 0, 0, 0, 1 },
            new int[5]{ 1, 0, 1, 0, 1 },
            new int[5]{ 1, 1, 1, 1, 1 }
        };

        public static int[][] initial10x10Slime =
        {
            new int[10]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[10]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[10]{ 0, 0, 0, 0, 0, 0, 0, 5, 0, 0 },
            new int[10]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[10]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[10]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[10]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[10]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[10]{ 0, 0, 0, 0, 5, 0, 0, 0, 0, 0 },
            new int[10]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };
        public static int[][] initial10x10Walls =
            {
            new int[10]{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            new int[10]{ 1, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            new int[10]{ 1, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            new int[10]{ 1, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            new int[10]{ 1, 0, 0, 0, 0, 0, 1, 0, 0, 1 },
            new int[10]{ 1, 0, 1, 0, 0, 1, 1, 1, 0, 1 },
            new int[10]{ 1, 1, 1, 0, 0, 0, 1, 0, 0, 1 },
            new int[10]{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
            new int[10]{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
            new int[10]{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        };

        public static int[][] initial7x7SlimySlime =
                    {
            new int[7]{ 0, 0, 0, 0, 0, 0, 0 },
            new int[7]{ 0, 3, 0, 0, 0, 0, 0 },
            new int[7]{ 0, 0, 0, 0, 0, 0, 0 },
            new int[7]{ 0, 0, 0, 4, 6, 0, 0 },
            new int[7]{ 0, 0, 0, 0, 0, 0, 0 },
            new int[7]{ 0, 1, 1, 0, 0, 3, 0 },
            new int[7]{ 0, 0, 0, 0, 0, 0, 0 }
        };
        public static int[][] initial7x7SlimyWalls =
            {
            new int[7]{ 1, 1, 1, 2, 1, 1, 1 },
            new int[7]{ 1, 0, 0, 0, 0, 0, 1 },
            new int[7]{ 2, 0, 0, 0, 0, 0, 1 },
            new int[7]{ 3, 0, 0, 0, 0, 0, 1 },
            new int[7]{ 1, 0, 0, 0, 0, 0, 1 },
            new int[7]{ 1, 0, 0, 0, 0, 0, 1 },
            new int[7]{ 1, 1, 1, 1, 1, 1, 1 }
        };

        public static int[][] generateBasicWalls(int x, int y)
        {
            int[][] map = new int[y][];
            for (int i = 0; i < y; i++)
            {
                map[i] = new int[x];
            }

            for (int myy = 0; myy < y; myy++)
            {
                for (int myx = 0; myx < x; myx++)
                {
                    if (myy == 0 || myy == y - 1 || myx == 0 || myx == x - 1)
                    {
                        map[myy][myx] = 1;
                    }
                    else
                    {
                        map[myy][myx] = 0;
                    }
                }
            }

            return map;
        }

        public static int[][] generateBasicSlimes(int x, int y, ref int[][] walls)
        {
            Random rand = new Random();
            int[][] map = new int[y][];
            for (int i = 0; i < y; i++)
            {
                map[i] = new int[x];
            }

            //Random wall segments
            for (int myy = 0; myy < y; myy++)
            {
                for (int myx = 0; myx < x; myx++)
                {
                    if (walls[myy][myx] == 1)
                    {
                        continue;
                    }

                    if (rand.NextInt64(0, 100) > 85)
                    {
                        walls[myy][myx] = 1;
                    }
                }
            }

            //Random slime pieces
            for (int myy = 0; myy < y; myy++)
            {
                for (int myx = 0; myx < x; myx++)
                {
                    if (walls[myy][myx] == 1) 
                    {
                        continue;
                    }

                    if (rand.NextInt64(0, 100) > 80)
                    {
                        map[myy][myx] = (int)rand.NextInt64(1, 6);
                    }
                }
            }

            return map;
        }

    }
}