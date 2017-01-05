using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Animation;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using Home_Organizer.Code.Controller;
using Home_Organizer.Code.Controller.Config;
using Home_Organizer.Code.Controller.Net;
using Home_Organizer.Code.View.Helper;
using HO.Apps.Droid;
using AlertDialog = Android.App.AlertDialog;

namespace Home_Organizer.Code.View
{

    /**
 *  This is being used for maintaining the splash screen
 * 
 */
    [Activity(Label = "SplashActivity"/*, MainLauncher = true*/, Theme = "@style/Theme.AppCompat.Light.NoActionBar"
        )]
    public class SplashActivity : AppCompatActivity
    {
        /**
     * To trace 
     */
        static readonly string TAG = "X:" + typeof(SplashActivity).Name;

        // view
        private ImageView splashImage;
        private TextView tv_Notification;
        private Bitmap mBitmap;
        private Context mContext;

       private DialogManager mDialog;

      
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.splash_activity);

            mContext = this;
            ViewReference();
            mDialog = new DialogManager(mContext);

            splashImage.Click += delegate (object sender, EventArgs args)
             {
                 /**
                  *  goto the Home Page 
                  * */

                 Finish();
                 StartActivity(new Intent(Application.Context, typeof(MainActivity)));
             };

            HideView();

        }

        private void HideView()
        {
            if (tv_Notification.Visibility==ViewStates.Visible)
            {
                tv_Notification.Visibility = Android.Views.ViewStates.Invisible;
            }
        }

        private void ViewReference()
        {
            splashImage = (ImageView)FindViewById(Resource.Id.imgv_splash_screen);
            tv_Notification = (TextView)FindViewById(Resource.Id.tv_splash_press);
        }

        protected override void OnResume()
        {
            base.OnResume();
            Parser parser = new Parser();
            string imageUrl = "";

            Task getImageFromNetTask = new Task(() =>
            {
                Log.Debug(TAG, "Performing some startup work that takes a bit of time.");

                /**
                 * Working in the background - important stuff.
                 */
               
                    imageUrl = parser.GetImageUrlFromApi(AppConfig.API_URL);

                    mBitmap = parser.GetImageBitmapFromUrl(imageUrl);

            });

            getImageFromNetTask.ContinueWith(t =>
            {

                /**
                 * Work is finished - start Main Activity.
                 */

                if (mBitmap!=null)
                {
                    splashImage.SetImageBitmap(mBitmap);
                }
                

                mDialog.HideLoadingDialog();
                tv_Notification.Visibility = Android.Views.ViewStates.Visible;

                blink();
            }, TaskScheduler.FromCurrentSynchronizationContext());



            // check internet connection  
            if (Connectivity.IsConnected(mContext))
            {
                mDialog.ShowLoadingDialog();
                getImageFromNetTask.Start();
            }
            else
            {
                mDialog.HideLoadingDialog();
                showInternetConnectionError();
            }

        }

        public void showInternetConnectionError()
        {

            AlertDialog.Builder alert = mDialog.CreateErrorDialog("Connection error", "Unable to connect with the server.\nCheck your internet connection.",
                "TRAY AGAIN");
            alert.SetPositiveButton("TRAY AGAIN", (senderAlert, args) => {

               StartActivityForResult(new Intent(Settings.ActionWifiSettings),0);
            });
            Dialog dialog = alert.Create();
            dialog.Show();
        }

        /**
         *  this method  sleep the tead 
         */
         
        public void blink()
        {

            Animation animation1 = AnimationUtils.LoadAnimation(mContext, Resource.Animation.blink);

            tv_Notification.StartAnimation(animation1);
        }

       
    }



}