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
    }
}