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

namespace Home_Organizer.Code.Controller.Config
{

    /**
     * This class is for storing all kinds of api link.....
     */
    class AppConfig
    {
        public const string API_URL = "http://apitest.home-organizer.com/Api/Software/AgentSplashDefData/32-AMKM5/106-19522-2";

        /**
* check valid promo code
*/
        public const string API_URL_CHECK_PROMO_CODE =
            "http://apitest.home-organizer.com/Api/Software/IsPromoCodeValid/";
    }
}