using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Com.GrapeCity.Xuni.FlexGrid;

namespace FlexGridSample
{
    [Activity(Label = "FlexGrid Sample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        FlexGrid _flexGrid;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // license
            Com.GrapeCity.Xuni.Core.LicenseManager.Key = License.Key;

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            this._flexGrid = FindViewById<FlexGrid>(Resource.Id.flexgrid);

            this._flexGrid.ItemsSource = Customer.GetCustomerList(50);

            this._flexGrid.CellFactory = new CustomCellFactory(this._flexGrid);

            this._flexGrid.Columns.GetColumn("Money").Format = "c";
            this._flexGrid.Columns.GetColumn("Hired").Format = "MM/dd/yyyy";
        }

    }

}

