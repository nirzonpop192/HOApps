using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Home_Organizer.Code.View;
using Home_Organizer.Fragment;
using HO.Apps.Data;
using HO.Apps.Droid;
using HO.Apps.Droid.Code.Controller.Config;
using HO.Apps.Models;
using SupportFragment = Android.Support.V4.App.Fragment;
namespace Home_Organizer
{
    /**
   *  That is the main class for the whole project. From here all kind of fragment and functionalities will maintain
   *  
   *  The navigation bar also maintain from this class
   */
    [Activity(Label = "Home Organizer", ScreenOrientation = ScreenOrientation.Landscape, Theme = "@style/BlueTheme"
        /*, MainLauncher = true*/, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        NavigationView navigationView;
        private SupportFragment mCurrentFragment;
        private ActionBarDrawerToggle mDrawerToggle;
        private Stack<SupportFragment> mStackFragments;
        private HomeFragment homeFragment;
        private SettingsFragment settingsFragment;
        private RegistrationFragment registrationFragment;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            SetContentView(Resource.Layout.Main);
            //  SQLiteClientBase<GlobalOption> globalOption = new SQLiteClientBase<GlobalOption>();

            ThemeUtill.onActivityCreateSetTheme(this);
            InitView();
            navigationView.NavigationItemSelected += OnNavigationItemSelected;

            homeFragment = new HomeFragment(this);
            settingsFragment = new SettingsFragment(this);
            registrationFragment = new RegistrationFragment(this);
            mStackFragments = new Stack<SupportFragment>();

            var trans = SupportFragmentManager.BeginTransaction();
            trans.Add(Resource.Id.fragmentContainer, homeFragment, "homeFragment");
            trans.Commit();

            mCurrentFragment = homeFragment;

        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;

            }
            return base.OnOptionsItemSelected(item);
        }

        public void InitView()
        {
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
        }


        public void ReplaceFragment(SupportFragment fragment)
        {
            if (fragment.IsVisible)
            {
                return;
            }

            var trans = SupportFragmentManager.BeginTransaction();
            trans.SetCustomAnimations(Resource.Animation.slide_in, Resource.Animation.slide_out, Resource.Animation.slide_in, Resource.Animation.slide_out);
            trans.Replace(Resource.Id.fragmentContainer, fragment);
            trans.AddToBackStack(null);
            trans.Commit();
            mCurrentFragment = fragment;
        }

        private void OnNavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            var menuItem = e.MenuItem;

            menuItem.SetChecked(!menuItem.IsChecked);

            drawerLayout.CloseDrawers();

            if (menuItem.ItemId == Resource.Id.nav_home)
            {
                ReplaceFragment(homeFragment);
            }
            else if (menuItem.ItemId == Resource.Id.nav_settings)
            {
                ReplaceFragment(settingsFragment);
            }
            else if (menuItem.ItemId == Resource.Id.nav_registration)
            {
                ReplaceFragment(registrationFragment);
            }

            else if (menuItem.ItemId == Resource.Id.nav_LogOut)
            {
                Finish();
                StartActivity(typeof(LoginActivity));
            }



        }

    }
}

