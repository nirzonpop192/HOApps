using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Home_Organizer.Code.Controller.Config;
using HO.Apps.Droid;
using HO.Apps.Droid.Code.Controller.Config;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Home_Organizer.Fragment
{

    /*
     * For managing the Setting option 
     */
    public class SettingsFragment : Android.Support.V4.App.Fragment
    {

        // view 
        private Switch shakeSwitch;

        private V7Toolbar toolbar;

        private RadioGroup rdgTheme;

        private View viewFragmentLayout;

        private Activity mActivity;

        public SettingsFragment(Activity mActivity)
        {
            this.mActivity = mActivity;
        }

        public override void OnAttach(Activity activity)
        {
            base.OnAttach(activity);

            toolbar = activity.FindViewById<V7Toolbar>(Resource.Id.toolbar);
            AppCompatActivity nactivity = (AppCompatActivity)activity;
            nactivity.SetSupportActionBar(toolbar);

        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment


            viewFragmentLayout = inflater.Inflate(Resource.Layout.setting_fragment, container, false);

            /***
             * view refernce here
             */
            shakeSwitch = (Switch)viewFragmentLayout.FindViewById(Resource.Id.swch_setting_shaking);

            rdgTheme = (RadioGroup)viewFragmentLayout.FindViewById(Resource.Id.radioGroupTheme);

            return viewFragmentLayout;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            shakeSwitch.CheckedChange += delegate (object sender, CompoundButton.CheckedChangeEventArgs e)
            {
                AppController.SetHandShakingSetting(e.IsChecked);
                Toast.MakeText(Application.Context, "Hand Shaking option is " +
                    (e.IsChecked ? " Trun ON" : " Trun OFF"), ToastLength.Short).Show();
            };

            rdgTheme.CheckedChange += delegate
            {
                /**
                 * get radio button's value 
                 */
                String radioButton = viewFragmentLayout.FindViewById<RadioButton>(rdgTheme.CheckedRadioButtonId).Text;

                switch (radioButton)
                {
                    case AppController.BLUE_THEME:
                        //                        AppController.ThemeSetting(AppController.BLUE_THEME);
                        //                        toolbar.SetBackgroundColor(Color.Blue);
                        ThemeUtill.changeToTheme(mActivity, ThemeUtill.BLUE);
                        break;
                    case AppController.RED_THEME:
                        AppController.ThemeSetting(AppController.RED_THEME);
                        toolbar.SetBackgroundColor(Color.Red);
                        break;
                    case "Default Theme":
                        AppController.ThemeSetting("Blue");
                        toolbar.SetBackgroundColor(new Color(21, 96, 243));
                        break;
                }

            };

           

        }
    }
}