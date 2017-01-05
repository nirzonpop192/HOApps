using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Home_Organizer.Code.Controller.Config
{

    /*
    * This class is 
    *  for measuring the screen size .... as we can change the relative resources ..
    */
    class ScreenSize
    {
        private Context mContext;

        public ScreenSize(Context context)
        {
            this.mContext = context;
        }

        public void getScreenSize()
        {
            var metrics = mContext.Resources.DisplayMetrics;
            var widthInDp = ConvertPixelsToDp(metrics.WidthPixels);
            var heightInDp = ConvertPixelsToDp(metrics.HeightPixels);

        }

        private int ConvertPixelsToDp(float pixelValue)
        {
            var dp = (int)((pixelValue) / mContext.Resources.DisplayMetrics.Density);
            return dp;
        }

    }
}