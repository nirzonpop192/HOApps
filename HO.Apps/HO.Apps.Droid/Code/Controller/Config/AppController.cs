using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Home_Organizer.Code.Controller.Config
{
    /** <summary>
     This class controll whole apps setting 
 */
    class AppController
    {
        public const string _HAND_SHAKE_ON_OFF_KEY = "hand_shake";
        public const string _THEME_CHOICE_KEY = "theme_choice";
        /**
         * theme constant
         * */

        public const string BLUE_THEME = "Blue Theme";
        public const string RED_THEME = "Red Theme";
        
        public static void SetHandShakingSetting(bool handShakeOnOFF)
        {

            ISharedPreferences prefs = Application.Context.GetSharedPreferences("HOME_ORG", FileCreationMode.Private);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutBoolean(_HAND_SHAKE_ON_OFF_KEY, handShakeOnOFF);

            editor.Apply();
        }


        public static bool GetHandShakingSetting()
        {
            Boolean handshakingOnOf;
            ISharedPreferences prefs = Application.Context.GetSharedPreferences("HOME_ORG", FileCreationMode.Private);

            handshakingOnOf = prefs.GetBoolean(_HAND_SHAKE_ON_OFF_KEY, false);
            Log.Debug("MOR", "hand is " + handshakingOnOf);
            return handshakingOnOf;

        }

        public static void ThemeSetting(String theme)
        {

            ISharedPreferences prefs = Application.Context.GetSharedPreferences("HOME_ORG", FileCreationMode.Private);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutString(_THEME_CHOICE_KEY, theme);

            editor.Apply();
        }
    }
}