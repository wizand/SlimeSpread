using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeSpreadLib
{
    public class Simulation
    {

        private Action? additionalSimFunction = null;
        private SlimeMap map;
        private SlimeMap originalMap;
        private bool simulationStillRunning = true;
        private int rounds = 100;
        private int currentRound = 0;

        public Simulation(SlimeMap map, Action? additionalSimAction = null, int rounds = 100)
        {
            originalMap = map.GetMapCopy();
            this.map = map;
            this.rounds = rounds;
            this.currentRound = 0;
            if ( additionalSimAction != null)
            {
                additionalSimFunction = additionalSimAction;
            }
        }

        public void Reset()
        {
            map = originalMap.GetMapCopy();
            simulationStillRunning = true;
            currentRound = 0;
        }

        public bool checkStatus()
        {
            if (map.IsSlimeDead())
            {
               // endMessage = "All slimes dead.";
                return false;
            }

            if ( currentRound == rounds)
            {
                //endMessage = "Rounds limit reached.";
                return false;
            }
            return true;
        }

        public void RunSimulation()
        {

            if (additionalSimFunction != null)
            {
                additionalSimFunction();
            }

            if (map == null)
            {
                Console.WriteLine("Slime map not initiated. Cannot run simulation.");
                return;
            }

            if (simulationStillRunning == false)
            {
                Console.WriteLine("Simulation already ended.");
                return;
            }
            currentRound++;
            Console.WriteLine("--------- ROUND #{0} ---------", currentRound);
            string[] prevState = map.GetMapStateAsStringLines();
            map.ApplyRules();
            string[] currentState = map.GetMapStateAsStringLines();

               
            Console.WriteLine("");
            simulationStillRunning = checkStatus();

            Console.WriteLine("Slime spread ended to round {0}. " + currentRound);
        }

        public SlimeMap GetSimulationMap()
        {
            return map;
        }
    }
}
