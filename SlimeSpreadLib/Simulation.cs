using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeSpreadLib
{
    public class Simulation
    {

        private Action? func = null;
        private SlimeMap map;

        public Simulation(SlimeMap map, Action? sim = null)
        {
            this.map = map;
            if ( sim != null)
            {
                func = sim;
            }
        }

        public void RunSimulation()
        {

            if (func != null)
            {
                func();
                return;
            }

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

               
                Console.WriteLine("");

            }

            Console.WriteLine("Slime spread ended to round {0}. " + currentRound);
        }


    }
}
