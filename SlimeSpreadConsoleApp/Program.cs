

using SlimeSpreadConsoleApp;

InitiateMap(5, 5);

void InitiateMap(int v1, int v2)
{
    SlimeMap map = new SlimeMap(v1, v2, initialWalls: DemoArrays.initial5x5Walls, initialSlime: DemoArrays.initial5x5Slime);


    map.Print();
}