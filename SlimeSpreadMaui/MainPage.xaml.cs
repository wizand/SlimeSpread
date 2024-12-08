using SlimeSpreadDrawer;
using SkiaSharp.Views.Maui;
using SkiaSharp;
using SkiaSharp.Views.Maui.Controls;
using SlimeSpreadConsoleApp;
using SlimeSpreadLib;


namespace SlimeSpreadMaui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        DrawHandler _slimeSpreadDrawer;
        SlimeMap? map = null;
        //InitiateMap(10, 10);
        public MainPage()
        {
            //map = SlimeMap.InitiateMap(initialWalls: DemoArrays.initial10x10Walls, initialSlime:   DemoArrays.initial10x10Slime);

            var wallsMap = DemoArrays.generateBasicWalls(100, 100);
            var slimeMap = DemoArrays.generateBasicSlimes(100, 100, ref wallsMap);


            map = new SlimeMap(100, 100, wallsMap, slimeMap);

            Simulation sim = new(map, ConsoleSim);
            InitializeComponent();
        }

        public void 2dSim()
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
                
                string[] prevState = map.GetMapStateAsStringLines();
                map.ApplyRules();
                string[] currentState = map.GetMapStateAsStringLines();

                //printStates(prevState, currentState);
                //isProgressing = checkStatus(map);
                Console.WriteLine("");
            }
            Console.WriteLine("Slime spread ended to round {0}. ", currentRound);
        }


        // Handle the PaintSurface event
        private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {

            if (_slimeSpreadDrawer == null)
            {
                _slimeSpreadDrawer = new(e.Info.Width, e.Info.Height);
            }
            var canvas = e.Surface.Canvas;
            _slimeSpreadDrawer.Draw(e.Surface, map);
            


        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            //_slimeSpreadDrawer.Draw();
            skCanvasView.InvalidateSurface();

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
