using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.GrapeCity.Xuni.Core;
using Com.GrapeCity.Xuni.Calendar;

namespace CalendarSample
{
    [Activity(Label = "CalendarSample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        XuniCalendar calendar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // license app with Xuni
            LicenseManager.Key = License.Key;

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // get chart from view
            calendar = FindViewById<XuniCalendar>(Resource.Id.calendar);

            // for vertical scrolling set Orientation
            calendar.Orientation = CalendarOrientation.Vertical;

            // set maximum selected days
            calendar.MaxSelectionCount = 14;

            // change appearance
            calendar.DayOfWeekBackgroundColor = System.Drawing.Color.Transparent.ToArgb();
            calendar.DayOfWeekTextColor = System.Drawing.Color.LightGray.ToArgb();

            calendar.DaySlotLoading += Calendar_DaySlotLoading;

            // Get our button from the layout resource,
            // and attach an event to it
            //Button button = FindViewById<Button>(Resource.Id.MyButton);

            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
        }

        private void Calendar_DaySlotLoading(object sender, CalendarDaySlotLoadingEventArgs e)
        {
            // get day
            Java.Util.Date date = e.Date;
            Java.Util.Calendar cal = Java.Util.Calendar.GetInstance(Java.Util.Locale.English);
            cal.Time = date;
            int day = cal.Get(Java.Util.CalendarField.DayOfMonth);

            // create day slot layout container
            CalendarDaySlotBase layout = new CalendarDaySlotBase(ApplicationContext);
            layout.SetGravity(GravityFlags.Top);
            layout.SetVerticalGravity(GravityFlags.Top);
            layout.Orientation = Orientation.Vertical;
            layout.SetPadding(5, 5, 5, 5);
            LinearLayout.LayoutParams linearLayoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.FillParent, LinearLayout.LayoutParams.FillParent);
            layout.LayoutParameters = linearLayoutParams;

            // create text element
            TextView tv = new TextView(ApplicationContext);
            //LinearLayout.LayoutParams linearLayoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
            //vv.LayoutParameters = linearLayoutParams;
            tv.Gravity = GravityFlags.Top;
            tv.Text = day.ToString();

            if (e.AdjacentDay)
            {
                // format adjacent day text
                tv.SetTextColor(Android.Graphics.Color.DarkGray);
            }

            // add text element to layout
            layout.AddView(tv);


            // add weather image for certain days
            if (day >= 14 && day <= 23)
            {
                ImageView iv = new ImageView(ApplicationContext);
                switch (day % 5)
                {
                    case 0: iv.SetImageResource(Resource.Drawable.Cloudy);
                        break;
                    case 1: iv.SetImageResource(Resource.Drawable.PartlyCloudy);
                        break;
                    case 2: iv.SetImageResource(Resource.Drawable.Rain);
                        break;
                    case 3: iv.SetImageResource(Resource.Drawable.Storm);
                        break;
                    case 4: iv.SetImageResource(Resource.Drawable.Sun);
                        break;

                }
                layout.AddView(iv);
               
            }

            // finally, set layout to day slot
            e.DaySlot = layout;
        }
    }
}

