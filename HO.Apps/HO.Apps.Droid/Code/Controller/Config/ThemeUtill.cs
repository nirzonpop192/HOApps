using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using Home_Organizer;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;

namespace HO.Apps.Droid.Code.Controller.Config
{
    class ThemeUtill
    {
        private static int cTheme;



        public const int BLACK = 0;

        public const int BLUE = 1;

        public static void changeToTheme( Activity activity, int theme)

        {

            cTheme = theme;


            Intent refresh = new Intent(activity, typeof(MainActivity));
            refresh.AddFlags(ActivityFlags.NoAnimation);
            activity.Finish();
            activity.StartActivity(refresh);


        }

        public static Color  OnActivityCreateSetTheme(Activity activity)

        {
                 V7Toolbar toolbar;
        toolbar = activity.FindViewById<V7Toolbar>(Resource.Id.toolbar);
            switch (cTheme)

            {

                default:

                case BLACK:
                   // Resource re=activity.Resource.Color.drak_blue_1
//                    activity.SetTheme(Resource.Style.BlackTheme);
                    toolbar.SetBackgroundColor(Color.Red);
//                    llLinearLayout.SetBackgroundColor(Color.Black);
//                    llLinearLayout.SetBackgroundColor(new Color(ContextCompat.GetColor(activity, Resource.Color.drak_blue_1)));
//                    navigationView.SetBackgroundColor(new Color(ContextCompat.GetColor(activity, Resource.Color.irisBlue)));
//  Color myColor = res.GetColor(Resource.Color.myColor);
// navigationView.SetBackgroundColor(res.GetColor(Resource.Color.gray_53));


                    break;

                case BLUE:

                    activity.SetTheme(Resource.Style.BlueTheme);

                    break;

            }

            toolbar.SetBackgroundColor(Color.Red);

            return GetBackgroundColor(activity, cTheme);
        }

        public static Color GetBackgroundColor(Activity activity, int them)
        {

            Color c;

            switch (cTheme)

            {

                default:

                case BLACK:

                    c = new Color(ContextCompat.GetColor(activity, Resource.Color.drak_blue_1));

                    break;

                case BLUE:

                    c = new Color(ContextCompat.GetColor(activity, Resource.Color.drak_blue_1));

                    break;

            }
            return c;
        }
    }
}