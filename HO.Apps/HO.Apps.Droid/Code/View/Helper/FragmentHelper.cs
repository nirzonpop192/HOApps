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
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using HO.Apps.Droid;
using SupportFragment = Android.Support.V4.App.Fragment;

namespace Home_Organizer.Code.View.Helper
{

    /*
    *   This class is to interact with all the destinationFragment transection and all these... 
    */
    class FragmentHelper : Android.Support.V4.App.Fragment
    {
        

        public static void ReplaceFragment(Android.Support.V4.App.Fragment sourceFragment,Android.Support.V4.App.Fragment destinationFragment)
        {
            if (destinationFragment.IsVisible)
            {
                return;
            }
        
            var trans = sourceFragment.FragmentManager.BeginTransaction();
            trans.Replace(Resource.Id.fragmentContainer, destinationFragment);
            trans.AddToBackStack(null);
            trans.Commit();
        }
    }
}