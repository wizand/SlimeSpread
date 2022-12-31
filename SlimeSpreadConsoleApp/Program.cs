

using SlimeSpreadConsoleApp;

int rounds = 10;
InitiateMap(5, 5);

void InitiateMap(int ySize, int xSize)
{
    SlimeMap map = new SlimeMap(ySize, xSize, initialWalls: DemoArrays.initial5x5Walls, initialSlime: DemoArrays.initial5x5Slime);

    bool isProgressing = true;
    while (isProgressing)
    {
        map.Print();
        map.ApplyRules();
        isProgressing = checkStatus(map);
    }
}

bool checkStatus(SlimeMap map)
{
    if (rounds > 0)
    {
        rounds--;
    }
    if (rounds > 0)
        return true;


    return false;
}