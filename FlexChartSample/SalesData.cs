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

namespace FlexChartSample
{
    public class SalesData : Java.Lang.Object
    {
        #region ** fields

        static Random _rnd = new Random();
        static string[] _countries = new string[] { "US", "Germany", "UK", "Japan", "Italy", "Greece" };

        #endregion

        #region ** initialization

        public SalesData()
        {
            this.Name = string.Empty;
            this.Sales = 0;
            this.Expenses = 0;
            this.Downloads = 0;
            this.Date = DateTime.Now;
        }
        public SalesData(string name, double sales, double expenses, double downloads, DateTime date)
        {
            this.Name = name;
            this.Sales = sales;
            this.Expenses = expenses;
            this.Downloads = downloads;
            this.Date = date;
        }

        #endregion

        #region ** object model

        public string Name { get; set; }
        public double Sales { get; set; }
        public double Expenses { get; set; }
        public double Downloads { get; set; }
        public DateTime Date { get; set; }

        #endregion

        #region ** implementation

        // ** static list provider
        public static IList<object> GetSalesDataList()
        {
            var list = new List<object>();
            for (int i = 0; i < GetCountries().Length; i++)
            {
                list.Add(new SalesData
                {
                    Sales = _rnd.NextDouble() * 10000,
                    Expenses = _rnd.NextDouble() * 5000,
                    Downloads = _rnd.Next(20000),
                    Date = DateTime.Now.AddDays(i)
                });
            }
            return list;
        }

        // ** static value providers
        public static string[] GetCountries() { return _countries; }

        #endregion
    }
}