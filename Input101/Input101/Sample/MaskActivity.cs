using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.GrapeCity.Xuni.Core;

using Com.GrapeCity.Xuni.Input.Mask;
using Com.GrapeCity.Xuni.Input.Dropdown;
using Com.GrapeCity.Xuni.Input.Combobox;
using Com.GrapeCity.Xuni.Input.Autocomplete;
using Android.Graphics;
using Java.Lang;


namespace Input101
{
    [Activity(Label = "Mask Sample", Icon = "@drawable/icon")]
    public class MaskActivity : Activity
    {
        //AutoCompleteTextView autoCompleteTextView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_basic_mask);
           
           
        }
      
    }
}

