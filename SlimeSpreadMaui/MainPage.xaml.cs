using SlimeSpreadDrawer;
using SkiaSharp.Views.Maui;
using SkiaSharp;
using SkiaSharp.Views.Maui.Controls;
using SlimeSpreadConsoleApp;
using SlimeSpreadLib;
using Windows.Networking.NetworkOperators;


namespace SlimeSpreadMaui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        DrawHandler _slimeSpreadDrawer;
        SlimeMap? map = null;
        Simulation sim;
        //InitiateMap(10, 10);
        public MainPage()
        {
            //map = SlimeMap.InitiateMap(initialWalls: DemoArrays.initial10x10Walls, initialSlime:   DemoArrays.initial10x10Slime);

            var wallsMap = DemoArrays.generateBasicWalls(100, 100);
            var slimeMap = DemoArrays.generateBasicSlimes(100, 100, ref wallsMap);


            map = new SlimeMap(100, 100, wallsMap, slimeMap);

            sim = new(map, SkiaSim, rounds: 100);
            InitializeComponent();
        }

        public void SkiaSim()
        {
            Console.WriteLine("Running simulation");
        }


        // Handle the PaintSurface event
        private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {

            if (_slimeSpreadDrawer == null)
            {
                _slimeSpreadDrawer = new(e.Info.Width, e.Info.Height);
            }
            var canvas = e.Surface.Canvas;
            _slimeSpreadDrawer.Draw(e.Surface, sim.GetSimulationMap());
            


        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            sim.RunSimulation();
            skCanvasView.InvalidateSurface();

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
