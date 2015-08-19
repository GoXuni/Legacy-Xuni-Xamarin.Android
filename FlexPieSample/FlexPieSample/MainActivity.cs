using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Com.GrapeCity.Xuni.Core;
using Com.GrapeCity.Xuni.ChartCore;
using Com.GrapeCity.Xuni.FlexPie;

namespace FlexPieSample
{
    [Activity(Label = "FlexPie Sample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // set Xuni license for this sample
            LicenseManager.Key = License.Key;

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our FlexPie from the layout resource
            FlexPie flexPie = FindViewById<FlexPie>(Resource.Id.flexpie);
            
            // bind FlexPie
            flexPie.ItemsSource = GetBrowserDataList();
            flexPie.Binding = "Sessions";
            flexPie.BindingName = "Browser";

            // set palette
            flexPie.SetPalette(Palettes.Slate);

            // configure flexpie settings
            flexPie.Header = "Browser Usage Stats";
            flexPie.Footer = "GrapeCity Xuni";
            flexPie.InnerRadius = 0.2f;
            flexPie.StartAngle = 90f;
            flexPie.SelectedItemOffset = 0.2f;
            flexPie.SelectionMode = ChartSelectionModeType.Point;

            // customize tooltip
            flexPie.Tooltip.Content = new MyTooltip(flexPie, flexPie.Context);

            // set data label
            flexPie.DataLabel = new PieDataLabel(flexPie);
            flexPie.DataLabel.Position = Com.GrapeCity.Xuni.FlexPie.PieLabelPosition.Center;

            // configure animation
            flexPie.LoadAnimation.AnimationMode = AnimationMode.Point;
        }

        public IList<object> GetBrowserDataList()
        {
            IList<object> list = new List<object>();
            string[] browser_names = new string[] { "Chrome", "Safari", "IE", "FireFox", "Opera" };
            Random rnd = new Random();
            for (int i = 0; i < browser_names.Length; i++)
            {
                list.Add(new BrowserUsageData { Browser = browser_names[i], Sessions = rnd.Next(100 * (i + 1)) });
            }
            
            return list;
        }
    }

    
    public class MyTooltip : BasePieTooltipView
    {
        TextView txtLabel;

        public MyTooltip(FlexPie pie, Context context)
            : base(pie)
        {
            txtLabel = new TextView(context);
            LinearLayout layout = new LinearLayout(context);
            layout.Orientation = Orientation.Vertical;
            layout.SetBackgroundColor(Android.Graphics.Color.Gray);
            layout.SetPadding(5, 5, 5, 5);
            layout.AddView(txtLabel);
            AddView(layout);
        }
        public override void Render(PieDataPoint point)
        {
            double percent = double.Parse(point.Percent.ToString());
            txtLabel.SetText(String.Format("{0}: {1:N0}", point.Name, percent), TextView.BufferType.Normal);
            RequestLayout();
        }
    }

    public class BrowserUsageData : Java.Lang.Object
    {
        public string Browser { get; set; }
        public double Sessions { get; set; }
    }
}

