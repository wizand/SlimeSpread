using SlimeSpreadDrawer;
using SkiaSharp.Views.Maui;
using SkiaSharp;
using SkiaSharp.Views.Maui.Controls;
using SlimeSpreadConsoleApp;


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
            map = SlimeMap.InitiateMap(initialWalls: DemoArrays.initial10x10Walls, initialSlime:   DemoArrays.initial10x10Slime);


            InitializeComponent();
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
