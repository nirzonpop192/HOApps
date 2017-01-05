using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HO.Apps.Droid;

namespace Home_Organizer.Code.View.Helper
{
    /**
   *   This class is for generating all kind of dialog. 
   * 
   */
    class DialogManager
    {
        // constant 
        public const int _galleryCamera = 1;
        public const int _normal = 0;
        // instance 
        private Context mContext;

        private int mRequestFlag;

        /**
         * view 
         */
        private Android.App.ProgressDialog mProgressDialog;


        public DialogManager(Context mContext) { this.mContext = mContext; }




        /**
         * overload method to use resource string       
         * titleRes = titleRes integer reference from String resource 
         * messageRes = integer reference from String resource
         * posButtonTitle = button text
        */
        public void ShowErrorDialog(int titleRes, int messageRes, string posButtonTitle)
        {

            ShowErrorDialog(mContext.Resources.GetString(titleRes), mContext.Resources.GetString(messageRes),
                posButtonTitle);

        }

        public void ShowErrorDialog(string title, string message, string posButtonTitle)
        {
            AlertDialog.Builder alert = CreateErrorDialog(title, message, posButtonTitle);
            alert.SetIcon(Resource.Drawable.error);
            Dialog dialog = alert.Create();
            dialog.Show();
        }

        public void ShowErrorDialog()
        {

            LayoutInflater layoutInflater = (LayoutInflater)mContext.GetSystemService(Context.LayoutInflaterService);
            Android.Views.View view = layoutInflater.Inflate(Resource.Layout.custom_toast, null);
            Toast toast = new Toast(mContext);
            toast.SetGravity(GravityFlags.Center, 0, 0);
            toast.Duration = ToastLength.Short;
            toast.View = view;
            toast.Show();

        }

        /**
         * This method Show A dialog 
         * To chose pictue  from Gallery or camera 
         */
        public int ShowGalleryCameraDialog()
        {
            AlertDialog.Builder alert = CreateSimpleDialog("Image Option", "Chose your Image From ", "Gallery", "Camerra", _galleryCamera);

            Dialog dialog = alert.Create();
            dialog.Show();

            return mRequestFlag;
        }

        /**
         * Generic method to show  
         */


        public void ShowSimpleDialog(string title, string message, string posButton, string negButton)
        {
            AlertDialog.Builder alert = CreateSimpleDialog(title, message, posButton, negButton, _normal);
            Dialog dialog = alert.Create();
            dialog.Show();
        }


        public void ShowSimpleDialog(string title, string message, string posButton, string negButton, int iconImage)
        {


            AlertDialog.Builder alert = CreateSimpleDialog(title, message, posButton, negButton, -_normal);

            alert.SetIcon(iconImage);
            Dialog dialog = alert.Create();
            dialog.Show();
        }

        /**
         * Alert  Dialog creator 
         */

        public AlertDialog.Builder CreateSimpleDialog(string title, string message, string posButton, string negButton, int operation)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(mContext);
            alert.SetTitle(title);
            alert.SetMessage(message);
            alert.SetPositiveButton(posButton, (senderAlert, args) =>
            {
                switch (operation)
                {
                    case _galleryCamera:
                        mRequestFlag = Util.REQUEST_FOR_GALLERY;
                        Toast.MakeText(mContext, "Gallery!", ToastLength.Short).Show();
                        break;

                    case _normal:
                        Toast.MakeText(mContext, "Deleted!", ToastLength.Short).Show();
                        break;
                }

            });

            alert.SetNegativeButton(negButton, (senderAlert, args) =>
            {

                switch (operation)
                {
                    case _galleryCamera:
                        mRequestFlag = Util.REQUEST_FOR_CAMERA;
                        Toast.MakeText(mContext, "Camera!", ToastLength.Short).Show();
                        break;

                    case _normal:
                        Toast.MakeText(mContext, "Cancel!", ToastLength.Short).Show();
                        break;
                }

            });



            return alert;
        }

        /**
         * to show user loading  dialog 
         */
        public void ShowLoadingDialog()
        {
            CreateProgressDialog("Loading ...", false, Android.App.ProgressDialogStyle.Spinner);
        }

        public void CreateProgressDialog(string message, Boolean cacelable, ProgressDialogStyle style)
        {


            mProgressDialog = new Android.App.ProgressDialog(mContext);
            mProgressDialog.Indeterminate = true;
            mProgressDialog.SetProgressStyle(style);
            mProgressDialog.SetMessage(message);
            mProgressDialog.SetCancelable(false);
            mProgressDialog.Show();
        }

        public void HideLoadingDialog()
        {
            if (mProgressDialog.IsShowing)
            {
                mProgressDialog.Dismiss();
            }
        }



        /**
        * Show Internet Connection error
        */
        public void showInternetConnectionError()
        {
            AlertDialog.Builder alert = CreateErrorDialog("Connection error", "Unable to connect with the server.\nCheck your internet connection.",
                "TRAY AGAIN");
            alert.SetPositiveButton("TRAY AGAIN", (senderAlert, args) =>
            {

                // mContext.StartActivity(new Intent(Settings.ActionWifiSettings));


            });
            Dialog dialog = alert.Create();
            dialog.Show();
        }

        public AlertDialog.Builder CreateErrorDialog(string title, string message, string posButtonTitle)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(mContext);
            alert.SetTitle(title);
            alert.SetMessage(message);
            alert.SetPositiveButton(posButtonTitle, (senderAlert, args) =>
            {

            });

            return alert;
        }
    }
}