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
using Android.Views;
using Android.Widget;
using Home_Organizer;

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

          //  activity.Finish();

         //   var cs = activity.LocalClassName;
           // dynamic v2 = activity.GetType().GetProperty("Value").GetValue(activity, null);
        
            //   activity.StartActivity(new Intent(activity, typeof(activi)));
            //            activity.StartActivity(new Intent(activity, typeof(activity.Class.ClassLoader)));
            //   activity.startActivity(new Intent(activity, activity.Class.ClassLoader.getClass()));

//            value = Convert.ChangeType(method.Invoke(null, new[] { value }), paramType);
            Intent refresh = new Intent(activity, typeof(MainActivity));
            refresh.AddFlags(ActivityFlags.NoAnimation);
            activity.Finish();
            activity.StartActivity(refresh);


        }

        public static void onActivityCreateSetTheme(Activity activity)

        {

            switch (cTheme)

            {

                default:

                case BLACK:

                    activity.SetTheme(Resource.Style.BlackTheme);

                    Bitmap bm = BitmapFactory.DecodeResource(Resources, Resource.Drawable.Icon);
                    ActivityManager.TaskDescription taskDesc = new ActivityManager.TaskDescription("Listy", bm, Color.Rgb(24, 80, 130));
                    SetTaskDescription(taskDesc);

                    break;

                case BLUE:

                    activity.SetTheme(Resource.Style.BlueTheme);

                    break;

            }

        }
    }
}