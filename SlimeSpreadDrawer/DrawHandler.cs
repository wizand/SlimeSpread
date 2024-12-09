using SkiaSharp;

using SlimeSpreadDrawer.Drawbales;

namespace SlimeSpreadDrawer
{
    public class DrawHandler
    {

  
        private SKColor clearColor = SKColors.Red;

        public DrawHandler(int width, int height)
        {
            CanvasWidth = width;
            CanvasHeight = height;
        }

        //public DrawHandler(int width = 800, int heigth = 800, SKColorType colorType = SKColorType.Rgba8888, SKAlphaType alphaType = SKAlphaType.Premul, string? clearColorHex = null )
        //{
        //    imageInfo = new SKImageInfo(width, heigth, colorType: colorType, alphaType: alphaType);
        //    surface = SKSurface.Create(imageInfo);
        //    canvas = surface.Canvas;
        //    if (clearColorHex != null)
        //    {
        //        clearColor = SKColor.Parse(clearColorHex);
        //    }
        //    else
        //    {
        //        clearColor = SKColors.DarkGray;
        //    }
        //}

        public int CanvasWidth { get; }
        public int CanvasHeight { get; }
        

        public void Draw(SKSurface surface, SlimeMap map)
        {
            List <SlimeDrawable> drawables = new();
           
            foreach(Tile tile in map.TilesInArray)
            {
                drawables.Add(new SlimeDrawable(tile, CanvasWidth, CanvasHeight));
            }
            var canvas = surface.Canvas;
            canvas.Clear(clearColor);
            //var rand = new Random();
            //int lineCount = 1000;
            //for (int i = 0; i < lineCount; i++)
            //{
            //    float lineWidth = rand.Next(1, 10);
            //    var lineColor = new SKColor(
            //            red: (byte)rand.Next(255),
            //            green: (byte)rand.Next(255),
            //            blue: (byte)rand.Next(255),
            //            alpha: (byte)rand.Next(255));

            //    var linePaint = new SKPaint
            //    {
            //        Color = lineColor,
            //        StrokeWidth = lineWidth,
            //        IsAntialias = true,
            //        Style = SKPaintStyle.Stroke
            //    };
               
            //    int x1 = rand.Next(200);
            //    int y1 = rand.Next(200);
            //    int x2 = rand.Next(200);
            //    int y2 = rand.Next(200);
            //    canvas.DrawLine(x1, y1, x2, y2, linePaint);
            foreach (var drawable in drawables)
            {
                canvas.DrawRect(drawable.Rect, drawable.Paint);
            }
        }
    }
}
