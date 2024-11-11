using AnywhereUI;

namespace DrawnUi.Infrastructure;

public struct MeasuringConstraints
{
    public Thickness Margins { get; set; }

    /// <summary>
    /// Include padding
    /// </summary>
    public Thickness TotalMargins { get; set; }

    public SizeF Request { get; set; }
    public RectF Content { get; set; }
}