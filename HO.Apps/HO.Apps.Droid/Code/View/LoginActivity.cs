using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Support.V7.App;
using Android.Widget;
using Home_Organizer.Code.Controller;
using Home_Organizer.Code.Controller.Config;
using Home_Organizer.Code.Controller.Net;
using Home_Organizer.Code.View.Helper;
using HO.Apps.Droid;
using AlertDialog = Android.App.AlertDialog;
using HO.Apps.Contracts;
using Xamarin.Forms;
using HO.Apps.Models;

namespace Home_Organizer.Code.View
{

    /**
     * Start point of app 
     * whole log in procedure ..  
     * */
    [Activity(Label = "LoginActivity", MainLauncher = true, Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class LoginActivity : AppCompatActivity
    {
        private EditText edtPromoCode;
        private ImageView btnLogIn;
        private Context mContext;
       

       private DialogManager mDialog ;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.log_in);

            Inti();

            btnLogIn.Click += BtnLogIn_Click;
        }

        private void BtnLogIn_Click(object sender, EventArgs e)
        {

            bool validPromoCode = false;
            Parser parser = new Parser();

            /*
             * Put value into database and others functionalities ..... 
             */

      
            

            Task startupWork = new Task(() =>
            {
                //  Log.Debug(TAG, "Performing some startup work that takes a bit of time.");

                /**
                 * Working in the background - important stuff.
                 */
                string url = AppConfig.API_URL_CHECK_PROMO_CODE + edtPromoCode.Text.Trim();
                validPromoCode = parser.IsValidPromoCode(url);
            });

            startupWork.ContinueWith(t =>
            {
                /**
                 * if promo code is valid
                 */

                if (validPromoCode)
                {

                    /**
                     * Work is finished - start Main Activity.
                     */
                    mDialog.HideLoadingDialog();

                    StartActivity(new Intent(mContext, typeof(SplashActivity)));
                }
                else
                {               
                    /**
                    * Work is finished - start Main Activity.
                    */
                    mDialog.HideLoadingDialog();
                    mDialog.ShowErrorDialog(Resource.String.Invalid_title, Resource.String.Invalid_msg_PomoCode, "Ok");
                }

            }, TaskScheduler.FromCurrentSynchronizationContext());


            // todo : check  internet 

            // check inter net connection  
            if (Connectivity.IsConnected(mContext))
            {
                // check is input is empty 
                if (edtPromoCode.Text.Length > 0)
                {
                    mDialog.ShowLoadingDialog();
                    startupWork.Start();
                }
                else
                {
                    mDialog.ShowErrorDialog(Resource.String.Error_title, Resource.String.Error_msg_PromoCode, "Ok");
                }
            }
            else
            {               

              //  mDialog.ShowErrorDialog();
                showInternetConnectionError();
            }            

        }
        /**
         * Intial thie intance 
         */
        private void Inti()
        {
            ViewReference();
            mContext = this;
            mDialog = new DialogManager(mContext);
        }

        private void ViewReference()
        {
            btnLogIn = (ImageView)FindViewById(Resource.Id.btnNext);
            edtPromoCode = (EditText)FindViewById(Resource.Id.promo_code);
          
        }

        private void showInternetConnectionError()
        {

            AlertDialog.Builder alert = mDialog.CreateErrorDialog("Connection error", "Unable to connect with the server.\nCheck your internet connection.",
                "TRAY AGAIN");
            alert.SetPositiveButton("TRAY AGAIN", (senderAlert, args) => {

                StartActivityForResult(new Intent(Settings.ActionWifiSettings), 0);
            });
            Dialog dialog = alert.Create();
            dialog.Show();
        }
    }
}