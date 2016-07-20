using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.GrapeCity.Xuni.Core;
using Com.GrapeCity.Xuni.Calendar;

using Com.GrapeCity.Xuni.Input.Mask;
using Com.GrapeCity.Xuni.Input.Dropdown;
using Com.GrapeCity.Xuni.Input.Combobox;
using Com.GrapeCity.Xuni.Input.Autocomplete;

using Android.Graphics;
using Java.Lang;
using Java.Text;
using Java.Util;


namespace Input101
{
    [Activity(Label = "DropDown Sample", Icon = "@drawable/icon")]
    public class DropDownActivity : Activity
    {
        //AutoCompleteTextView autoCompleteTextView;
        XuniDropDown dropdown;
        XuniMaskedTextView header;
        XuniCalendar calendar;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            dropdown = new XuniDropDown(this);
		    header = new XuniMaskedTextView(this);
		    header.Mask="00/00/0000";

		    calendar = new XuniCalendar(this);
		    dropdown.Header=header;
		    dropdown.Dropdown=calendar;
			dropdown.DropDownHeight = 400;
		    dropdown.Animated=true;
            calendar.SelectionChanged += SelectionChanged;

		    this.SetContentView(dropdown);
           
         }

        private void SelectionChanged(object sender, Com.GrapeCity.Xuni.Calendar.CalendarSelectionChangedEventArgs args)
        {
            dropdown.DropDownOpen=false;
           // SimpleDateFormat format = new SimpleDateFormat("MM-dd-yyyy", Locale.Default);
            DateTime dateTime = calendar.SelectedDates.ToArray()[0];
            string strDate = dateTime.ToString("MMddyyyy");
            header.Value = strDate;
        }
    }
}

