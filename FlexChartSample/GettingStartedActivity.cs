using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Collections.ObjectModel;
using Com.Grapecity.Xuni.Flexchart.Core;

namespace FlexChartSample
{
    [Activity(Label = "Getting Started")]
    public class GettingStartedActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var chart = FindViewById<Com.Grapecity.Xuni.Flexchart.FlexChart>(Resource.Id.flexchart);
            //chart.CollectionView = new Com.Grapecity.Xuni.Core.Collection.Implementations.CollectionView(new List<int> { 1, 2, 3 });
            chart.ItemsSource = SalesData.GetSalesDataList();
        }
    }
}

