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


namespace Input101
{
    [Activity(Label = "Input101", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        ListView mSampleList;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // license app with Xuni
            LicenseManager.Key = License.Key;

            mSampleList = new ListView(this);
            SampleListAdapter adapter = new SampleListAdapter(this);
            mSampleList.SetAdapter(adapter);
            mSampleList.ItemClick += ItemClick;

            this.SetContentView(mSampleList);
        }

       

        public void ItemClick(object sender, AdapterView.ItemClickEventArgs e)
	   {
		    Intent intent = new Intent();
		    // initialize the intent based on user click
		    switch (e.Position)
		    {
                case 0:
                    AutoCompleteActivity autoActivity = new AutoCompleteActivity();
                    intent = new Intent(ApplicationContext, autoActivity.Class);
                    break;
                case 1:
                    ComboBoxActivity comActivity = new ComboBoxActivity();
                    intent = new Intent(ApplicationContext, comActivity.Class);
                    break;
                case 2:
                    DropDownActivity dropDownActivity = new DropDownActivity();
                    intent = new Intent(ApplicationContext, dropDownActivity.Class);
                    break;
                case 3:
                    MaskActivity maskActivity = new MaskActivity();
                    intent = new Intent(ApplicationContext, maskActivity.Class);
                    break;
		    }
		    // start the new activity
		    StartActivity(intent);
        }  
    }
}

