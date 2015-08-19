using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Util;

using Com.GrapeCity.Xuni.Core;
using Com.GrapeCity.Xuni.ChartCore;
using Com.GrapeCity.Xuni.FlexChart;

namespace FlexChartSample
{
    [Activity(Label = "FlexChart Sample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        FlexChart chart;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            LicenseManager.Key = License.Key;

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // get chart from view
            chart = FindViewById<FlexChart>(Resource.Id.flexchart);
            
            // set title/footer
            chart.Header = "FlexChart Sales";
            chart.Footer = "GrapeCity Xuni";
            chart.Legend.BorderWidth = 1;
            chart.Legend.BorderColor = System.Drawing.Color.Gray.ToArgb();

            // set palette
            chart.SetPalette(Palettes.Modern);
            
            // bind X axis to display category names
            chart.BindingX = "Date";

            // create series with binding
            ChartSeries sales = new ChartSeries(chart, "Sales", "Sales"); // new Series(chart, legend name, binding property)
            ChartSeries expenses = new ChartSeries(chart, "Expenses", "Expenses");
            ChartSeries downloads = new ChartSeries(chart, "Downloads", "Downloads");

            downloads.ChartType = ChartType.Line;
            chart.Series.Add(sales);
            chart.Series.Add(expenses);
            chart.Series.Add(downloads);

            // set data source
            chart.ItemsSource = SalesData.GetSalesDataList();

            // configure default axes
            chart.AxisX.LabelAngle = 45;
            chart.AxisX.Format = "d";
            chart.AxisY.Format = "c0";
            chart.AxisY.Title = "Dollars";

            // add second Y axis
            ChartAxis y2 = new ChartAxis(chart, ChartPositionType.Right);
            y2.Name = "y2";
            y2.Format = "n0";
            y2.MajorGridVisible = false;
            y2.MinorGridVisible = false;
            y2.LabelsVisible = true;
            y2.Title = "Downloads";
            chart.Axes.Add(y2);

            downloads.AxisY = "y2";

            // customize tooltip
            chart.Tooltip.Content = new MyTooltip(chart, chart.Context);

            // customize plot element
            chart.PlotElementLoading += chart_PlotElementLoading;

            // configure animation
            chart.LoadAnimation.AnimationMode = AnimationMode.Point;

        }

        void chart_PlotElementLoading(object sender, ChartPlotElementEventArgs e)
        {
            // only customize expenses series
            if (e.DataPoint.SeriesName.Equals("Expenses"))
            {
                // get sales value at point index
                SalesData data = e.DataPoint.DataObject as SalesData;
                // color expenses that are greater than sales as RED
                if (data != null && data.Expenses >= data.Sales)
                {
                    e.RenderEngine.SetFill(Android.Graphics.Color.Red.ToArgb());
                }
            }
            e.DefaultRender.Execute();
        }
    }

    public class MyTooltip : BaseChartTooltipView
    {
        TextView txtLabelX;
        TextView txtLabelY;

        public MyTooltip(FlexChart chart, Context context) : base(chart)
        {
            txtLabelX = new TextView(context);
            txtLabelY = new TextView(context);
            LinearLayout layout = new LinearLayout(context);
            layout.Orientation = Orientation.Vertical;
            layout.SetBackgroundColor(Android.Graphics.Color.Gray);
            layout.SetPadding(5, 5, 5, 5);
            layout.AddView(txtLabelX);
            layout.AddView(txtLabelY);
            AddView(layout);
        }
        public override void Render(SuperChartDataPoint point)
        {
            double y = double.Parse(point.YValue.ToString());
            txtLabelX.SetText(String.Format("Date: {0}", point.XValue), TextView.BufferType.Normal);
            txtLabelY.SetText(String.Format("{0}: {1:N2}", point.SeriesName, y), TextView.BufferType.Normal);
            RequestLayout();
        }
    }
}

