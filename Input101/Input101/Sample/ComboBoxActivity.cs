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
using Android.Util;


namespace Input101
{
    [Activity(Label = "ComboBox Sample", Icon = "@drawable/icon")]
    public class ComboBoxActivity : Activity
    {
        //AutoCompleteTextView autoCompleteTextView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            LinearLayout layout = new LinearLayout(this);
            layout.Orientation = Orientation.Vertical;

		    TextView editableLabel = new TextView(this);
		    editableLabel.SetText(Resource.String.editable);
		    editableLabel.SetTextSize(ComplexUnitType.Sp,18);
		    layout.AddView(editableLabel);

            XuniComboBox comboBox = new XuniComboBox(this);
            comboBox.DisplayMemberPath = "Name";
            comboBox.ItemsSource = DropDownItem.getList();
            comboBox.SelectedBackgroundColor = Color.Green.ToArgb();
            layout.AddView(comboBox);

            Space emptySpace = new Space(this);
            layout.AddView(emptySpace);

            TextView nonEditableLabel = new TextView(this);
            nonEditableLabel.SetText(Resource.String.noneditable);
            nonEditableLabel.SetTextSize(ComplexUnitType.Sp, 18);
            layout.AddView(nonEditableLabel);

            XuniComboBox nonEditableComboBox = new XuniComboBox(this);
            nonEditableComboBox.ItemsSource = DropDownItem.getList(); ;
            nonEditableComboBox.DisplayMemberPath = "Name";
            nonEditableComboBox.SelectedBackgroundColor = Color.Green.ToArgb();
            nonEditableComboBox.Editable = false;
            layout.AddView(nonEditableComboBox);

		    this.SetContentView(layout);
           
        }
      
    }
}

