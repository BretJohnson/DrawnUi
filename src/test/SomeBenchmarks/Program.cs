﻿using BenchmarkDotNet.Running;
using DrawnUi.Maui.Draw;
using SomeBenchmarks;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var summary = BenchmarkRunner
            .Run<MauiLayout>();


        //var layout = new SkiaLayout();
        ////{
        ////    Type = LayoutType.Stack
        ////};

        ////var layout = new ContentLayout();

        //layout.AddSubView(new SkiaShape());

        ////layout.AddSubView(new SkiaShape());

        ////layout.AddSubView(new SkiaShape());

        //var stop = 1;
    }
}
