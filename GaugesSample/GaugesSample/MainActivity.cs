using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;

using Com.GrapeCity.Xuni.Core;
using Com.GrapeCity.Xuni.Gauge;

namespace GaugesSample
{
    [Activity(Label = "Gauges Sample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            LicenseManager.Key = License.Key;

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our linear gauge from the layout resource,
            XuniLinearGauge linearGauge = FindViewById<XuniLinearGauge>(Resource.Id.lineargauge);
            linearGauge.Direction = Com.GrapeCity.Xuni.Gauge.LinearGaugeDirection.Right;
            linearGauge.Min = 0;
            linearGauge.Max = 100;
            linearGauge.Value = 50;
            //linearGauge.Format = "C0";
            linearGauge.ShowTextType = GaugeShowText.All;

            // add ranges to the linear gauge
            GaugeRange range1 = new GaugeRange();
            range1.Min = 0;
            range1.Max = 30;
            range1.Color = Color.Maroon.ToArgb();
            linearGauge.Ranges.Add(range1);
            GaugeRange range2 = new GaugeRange();
            range2.Min = 30;
            range2.Max = 70;
            range2.Color = Color.OrangeRed.ToArgb();
            linearGauge.Ranges.Add(range2);
            GaugeRange range3 = new GaugeRange();
            range3.Min = 70;
            range3.Max = 100;
            range3.Color = Color.ForestGreen.ToArgb();
            linearGauge.Ranges.Add(range3);
            linearGauge.ShowRanges = false;

            // bullet graph
            XuniBulletGraph bulletGraph = FindViewById<XuniBulletGraph>(Resource.Id.bulletgraph);
            bulletGraph.Pointer.Width = 0.5f;
            bulletGraph.Min = 0;
            bulletGraph.Max = 100;
            bulletGraph.Value = 50;
            bulletGraph.Target = 80;
            bulletGraph.Good = 75;
            bulletGraph.Bad = 40;
            bulletGraph.Format = "C0";
            bulletGraph.ShowTextType = Com.GrapeCity.Xuni.Gauge.GaugeShowText.Value;
            bulletGraph.ValueChanged += bulletGraph_ValueChanged;

            // radial gauge
            XuniRadialGauge radialGauge = FindViewById<XuniRadialGauge>(Resource.Id.radialgauge);
            radialGauge.Min = 0;
            radialGauge.Max = 1;
            radialGauge.Value = .75;
            radialGauge.Format = "P0";
            radialGauge.Pointer.Width = 0.5f;
            radialGauge.StartAngle = -15;
            radialGauge.SweepAngle = 210;
            radialGauge.ShowTextType = Com.GrapeCity.Xuni.Gauge.GaugeShowText.All;
            radialGauge.Face.Width = 0.8f;

            GaugeRange radialRange1 = new GaugeRange();
            radialRange1.Min = 0;
            radialRange1.Max = .35;
            radialRange1.Color = Color.OrangeRed.ToArgb();
            radialGauge.Ranges.Add(radialRange1);
        }

        void bulletGraph_ValueChanged(object sender, double e)
        {

        }
    }
}

