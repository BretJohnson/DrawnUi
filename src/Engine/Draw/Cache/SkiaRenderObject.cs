﻿namespace DrawnUi.Maui.Draw;

public class CachedObject : IDisposable
{
    public SKPoint TranslateInputCoords(SKRect drawingRect)
    {
        //return new(0, 0);

        var offsetCacheX = drawingRect.Left - Bounds.Left;
        var offsetCacheY = drawingRect.Top - Bounds.Top;

        return new SKPoint(-offsetCacheX, -offsetCacheY);
    }

    public SKPoint CalculatePositionOffset(SKPoint drawingRect)
    {
        //return new(0, 0);

        var offsetCacheX = drawingRect.X - Bounds.Left;
        var offsetCacheY = drawingRect.Y - Bounds.Top;

        //var offsetCacheX = (float)Math.Round(drawingRect.X - Bounds.Left);
        //var offsetCacheY = (float)Math.Round(drawingRect.Y - Bounds.Top);


        return new SKPoint(offsetCacheX, offsetCacheY);
    }

    public SKPoint Test(SKRect drawingRect)
    {

        var offsetCacheX = Math.Abs(drawingRect.Left - Bounds.Left);
        var offsetCacheY = Math.Abs(drawingRect.Top - Bounds.Top);

        return new SKPoint(offsetCacheX, offsetCacheY);
    }

    public void Draw(SKCanvas canvas, SKRect destination, SKPaint paint)
    {
        try
        {
            if (Picture != null)
            {
                var moveY = Bounds.Top - RecordingArea.Top;
                var moveX = Bounds.Left - RecordingArea.Left;

                var x = (float)Math.Round(destination.Left - Bounds.Left + moveX);
                var y = (float)Math.Round(destination.Top - Bounds.Top + moveY);

                canvas.DrawPicture(Picture, x, y, paint);
            }
            else
            if (Image != null)
            {
                var moveY = Bounds.Top - RecordingArea.Top;
                var moveX = Bounds.Left - RecordingArea.Left;

                var x = (float)Math.Round(destination.Left + moveX);
                var y = (float)Math.Round(destination.Top + moveY);

                canvas.DrawImage(Image, x, y, paint);
            }
        }
        catch (Exception e)
        {
            Super.Log(e);
        }
    }

    public CachedObject(SkiaCacheType type, SKPicture picture, SKRect bounds, SKRect recordingArea)
    {
        Type = type;
        Bounds = bounds;
        RecordingArea = recordingArea;
        Picture = picture;
    }

    public CachedObject(SkiaCacheType type, SKSurface surface, SKRect bounds, SKRect recordingArea)
    {
        Type = type;
        Surface = surface;
        Bounds = bounds;
        RecordingArea = recordingArea;
        Image = surface.Snapshot();


    }

    /// <summary>
    /// An existing surface was reused for creating this object
    /// </summary>
    public bool SurfaceIsRecycled { get; set; }

    public SKPicture Picture { get; set; }

    public SKImage Image { get; set; }

    public SKRect Bounds { get; set; }

    public SKRect RecordingArea { get; set; }

    public SkiaCacheType Type { get; protected set; }

    public void Dispose()
    {
        if (!IsDisposed)
        {
            IsDisposed = true;

            Surface?.Dispose();
            Surface = null;
            Picture?.Dispose();
            Picture = null;
            Image?.Dispose();
            Image = null;
        }
    }

    public bool IsDisposed { get; protected set; }

    public string Tag { get; set; }

    public bool NeedDispose { get; set; }

    public SKBitmap GetBitmap()
    {
        return SKBitmap.FromImage(Image);
    }

    public SKSurface Surface { get; set; }
}