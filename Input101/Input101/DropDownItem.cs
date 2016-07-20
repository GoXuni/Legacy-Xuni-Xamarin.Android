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
using Com.GrapeCity.Xuni.Core;

using JavaString=Java.Lang.String;

namespace Input101
{
    class DropDownItem :Java.Lang.Object
    {
        public string Name { get; set; }
        public JavaString value { get; set; }
        public int flag { get; set; }
    
		public static string[] country = { "Australia", "Bangladesh", "Brazil", "Canada", "China", "France", "Germany", "India", "Japan", "Nepal", "Pakistan", "Srilanka" };

        DropDownItem(string name, JavaString value)
        {
            this.Name = name;
            this.value = value;
        }

        DropDownItem(string name, JavaString value, int flag)
        {
            this.Name = name;
            this.value = value;
            this.flag = flag;
        }

        /**
         * a method to create a list of objects of type DropDownItem;
         * 
         * @param size
         *            - size of element.
         * */
        public static IList<object> getList()
        {
            var list = new List<object>();

            int[] flagId =
			{ Resource.Drawable.australia, Resource.Drawable.bangladesh, Resource.Drawable.brazil, Resource.Drawable.canada, Resource.Drawable.china, Resource.Drawable.france, Resource.Drawable.germany, Resource.Drawable.india,
				Resource.Drawable.japan, Resource.Drawable.nepal, Resource.Drawable.pakistan, Resource.Drawable.srilanka };

            for (int i = 0; i < country.Length; i++)
            {
                list.Add(new DropDownItem(country[i], new JavaString(i+""), flagId[i]));
            }

            return list;
        }


    }
}