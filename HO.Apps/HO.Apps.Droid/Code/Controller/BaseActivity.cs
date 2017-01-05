using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Home_Organizer.Code.Controller.Config;
using Xamarin.Forms;
using Application = Android.App.Application;

namespace HO.Apps.Droid.Code.Controller
{
    [Activity(Label = "Activity1", Theme = "@style/Theme.DesignDemo")]
    public class BaseActivity : AppCompatActivity
    {
        private Context mContext;

      /*  public PreferenceUtil mMobileData = null;
        private String TAG = "BaseActivity";
        private String currentCountryCode = "";
        public String themeColor = null;*/
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

         /*   ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutString("red_theme", Color.Red.ToString());
          /*  editor.PutString("blue_theme", Color.Blue.ToString());
            editor.PutString("green_theme", Color.Green.ToString());
            editor.PutString("sky_color_theme", Color.Aqua.ToString());#1#
            editor.Apply();*/

        }

    /*    public void SetTheme()
        {
             themeColor = mMobileData.getString(Constants.PREF_TAG_PROFILE_THEME_COLOR, Constants.PROFILE_THEME_GREEN);

        if (Utils.isValidString(themeColor)) {
            if (themeColor.equalsIgnoreCase(Constants.PROFILE_THEME_GREEN)) {
                setTheme(R.style.AppThemeGreean);
            } else if (themeColor.equalsIgnoreCase(Constants.PROFILE_THEME_BLUE)) {
                setTheme(R.style.AppThemeBlue);
            } else if (themeColor.equalsIgnoreCase(Constants.PROFILE_THEME_RED)) {
                setTheme(R.style.AppThemeRed);
            } else if (themeColor.equalsIgnoreCase(Constants.PROFILE_THEME_YELLOW)) {
                setTheme(R.style.AppThemeYellow);
            } else if (themeColor.equalsIgnoreCase(Constants.PROFILE_THEME_GRAY)) {
                setTheme(R.style.AppThemeGray);
            } else {
                setTheme(R.style.AppThemeGreean);
            }
        }
        }*/

    }
}