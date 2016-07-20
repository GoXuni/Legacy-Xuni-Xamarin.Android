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

using System.Collections.Generic;

namespace Input101
{
    [Activity(Label = "AutoComplete Sample", Icon = "@drawable/icon")]
    public class AutoCompleteActivity : Activity
    {
        XuniAutoCompleteTextView filterAutoComplete;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_autocomplete);

            // Highlight sample
            XuniAutoCompleteTextView highLightAutoComplete = (XuniAutoCompleteTextView)this.FindViewById(Resource.Id.autocomplete_highlight);
            //highLightAutoComplete.SetItemsSource(DropDownItem.country);
            highLightAutoComplete.DisplayMemberPath = "Name";
            highLightAutoComplete.ItemsSource = DropDownItem.getList();
            highLightAutoComplete.MatchType =MatchType.Contains;
            highLightAutoComplete.Threshold=1;
            
            // Delay sample
            XuniAutoCompleteTextView delayAutoComplete = (XuniAutoCompleteTextView)this.FindViewById(Resource.Id.autocomplete_delay);
            delayAutoComplete.DisplayMemberPath = "Name"; 
            delayAutoComplete.ItemsSource=DropDownItem.getList();
            delayAutoComplete.MatchType = MatchType.Contains;
            delayAutoComplete.Threshold = 1;
            delayAutoComplete.Delay = 1500; // Delay 1500 milliseconds.
            delayAutoComplete.SetWidth(20);

            // Custom sample
            System.Collections.Generic.IDictionary<Integer, string> viewToDataMap = new JavaDictionary<Integer, string>();
            viewToDataMap.Add(Integer.ValueOf(Resource.Id.imageView1), "flag");
            viewToDataMap.Add(Integer.ValueOf(Resource.Id.textView1), "Name");
            XuniAutoCompleteTextView customAutoComplete = (XuniAutoCompleteTextView)this.FindViewById(Resource.Id.autocomplete_custom);
            customAutoComplete.SetDropDownItemLayoutId(Resource.Layout.custom_item); // Custom drop down item.
            customAutoComplete.SetDropDownItemTextViewId(Resource.Id.textView1);
            customAutoComplete.ViewDataBinderMap = viewToDataMap;
            IList<object> list = DropDownItem.getList();
            customAutoComplete.ItemsSource = list;
            customAutoComplete.DisplayMemberPath = "Name";
            customAutoComplete.MatchType = MatchType.Contains;
            customAutoComplete.Threshold = 1;
           
            // custom filter sample
            filterAutoComplete = (XuniAutoCompleteTextView)this.FindViewById(Resource.Id.autocomplete_filter);
            filterAutoComplete.ItemsSource = DropDownItem.getList();
            filterAutoComplete.DisplayMemberPath = "Name";
		    filterAutoComplete.Threshold=1;
            filterAutoComplete.FilteringEvent += filterAutoComplete_FilteringEvent;   
        
        }

        void filterAutoComplete_FilteringEvent(object sender, FilteringEventArgs args)
        {
            ICollectionView collectionView = filterAutoComplete.CollectionView;
            IPredicate predicte = new Predicate();
            collectionView.Filter=predicte;
            FilteringEventArgs filteringEventArgs = (FilteringEventArgs) args;
            filteringEventArgs.Handled=true;
        }
      
    }

    class Predicate : Java.Lang.Object, IPredicate{
        public bool Execute(global::Java.Lang.Object item)
        {
            IXamarinXuniObject dropDownItem = (IXamarinXuniObject)item;
            string str = (string)dropDownItem.GetPropertyValue("Name");
            if (str.StartsWith("B"))
            {
                return true;
            }
            return false;
        }

    }
}

