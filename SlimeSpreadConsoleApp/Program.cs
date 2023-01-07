

using SlimeSpreadConsoleApp;

using System.Text;

int rounds = 150;
string endMessage = "";
SlimeMap? map = null;
//InitiateMap(10, 10);
InitiateMap(initialWalls: DemoArrays.initial10x10Walls, initialSlime: DemoArrays.initial10x10Slime);
RunSimulation();

void InitiateMap(int[][] initialWalls, int[][] initialSlime)
{
    map = new SlimeMap(initialWalls.Length, initialWalls[0].Length, initialWalls, initialSlime);
}


void RunSimulation()
{
    if (map == null)
    {
        Console.WriteLine("Slime map not initiated. Cannot run simulation.");
        return;
    }

    bool isProgressing = true;
    int currentRound = 0;
    while (isProgressing)
    {
        currentRound++;
        Console.WriteLine("--------- ROUND #{0} ---------", currentRound);
        string[] prevState = map.GetMapStateAsStringLines();
        map.ApplyRules();
        string[] currentState = map.GetMapStateAsStringLines();

        printStates(prevState, currentState);

        isProgressing = checkStatus(map);
        Console.WriteLine("");

    }

    Console.WriteLine("Slime spread ended to round {0}. " + endMessage, currentRound);
}

void printStates(string[] prevState, string[] currentState)
{
    for (int lineIndex = 0; lineIndex < prevState.Length; lineIndex++)
    {
        StringBuilder sb = new();
        
        sb.Append(prevState[lineIndex]);
        if (lineIndex == prevState.Length / 2)
        {
            sb.Append("----->");
        } else
        {
            sb.Append("      ");
        }
        sb.Append(currentState[lineIndex]);
        
        Console.WriteLine(sb.ToString());
    }
}

bool checkStatus(SlimeMap map)
{
    if (map.IsSlimeDead())
    {
        endMessage = "All slimes dead.";
        return false;
    }

    if (rounds > 0)
    {
        rounds--;
    }
    if (rounds > 0)
    {
        return true;
    }

    endMessage = "Rounds ended.";
    return false;
}