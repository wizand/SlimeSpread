using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SkiaSharp;

namespace SlimeSpreadDrawer.Drawbales
{
    public class SlimeDrawable : IDisposable
    {

        public int X, Y;
        public int Width = 10;
        public int Height = 10;

        public SKPaint Paint;
        public SKRect Rect;

        public SlimeDrawable(Tile tile, int canvasW, int canvasH)
        {
            Width = canvasW / Coords.X_MAX;
            Height= canvasH / Coords.Y_MAX;

            X = tile.Coords.X;
            Y = tile.Coords.Y;
            Rect = new SKRect(
                X * Width,
                Y * Height,
                (X + 1) * Width,
                (Y + 1) * Height);

            if (tile.TILE_TYPE == TileType.SLIME)
            {
                Paint = new SKPaint
                {
                    Style = SKPaintStyle.Fill,
                    Color = SKColors.Green
                };
            }
            else if (tile.TILE_TYPE == TileType.WALL)
            {
                Paint = new SKPaint
                {
                    Style = SKPaintStyle.Fill,
                    Color = SKColors.DarkGray
                };
            }
            else
            {
                Paint = new SKPaint
                {
                    Style = SKPaintStyle.Fill,
                    Color = SKColors.White
                };

            }
        }

        public void Dispose()
        {
            Console.WriteLine("Disposing SlimeDrawable");
            ((IDisposable)Paint).Dispose();
        }
    }
}
