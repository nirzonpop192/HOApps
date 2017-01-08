using System;
using System.Collections.Generic;
using System.IO;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Home_Organizer.Code.Controller.Adapter;
using Home_Organizer.Code.Model;
using Home_Organizer.Code.View.Helper;
using Home_Organizer.Fragment;
using HO.Apps.Contracts;
using HO.Apps.Droid;
using Xamarin.Forms;
using Application = Android.App.Application;
using ListView = Android.Widget.ListView;
using SupportFragment = Android.Support.V4.App.Fragment;
using View = Android.Views.View;

using System.Linq;
using Android.Graphics.Drawables;
using Android.Util;
using HO.Apps.Droid.Code.Controller.Config;
using HO.Apps.Helpers;

namespace Home_Organizer.Fragment
{
    public class HomeFragment : Android.Support.V4.App.Fragment, ListView.IOnItemClickListener
    {
        private Context mContext;
        private ListView listView;
        private ImilkDigitalIDService _milkDigitalIdService;
        private CustomListAdapter adapter;
        private string[] childName = /* {"Creat New ID", "Shuvo", "Faisal", "Mustafiz","Sohan","Rasel","Mehedi"};*/
        {

    };

        /**
         */
        private int[] childImage = { Resource.Drawable.button_create, Resource.Drawable.icon, Resource.Drawable.icon, Resource.Drawable.icon, Resource.Drawable.icon, Resource.Drawable.icon, Resource.Drawable.icon };
        private List<ChildInformation> childInformation = new List<ChildInformation>();

        private RegistrationFragment registrationFragment;

        /**
         * use layout to  change back ground 
         */
        // public LinearLayout homeLayout;

    /*    public HomeFragment()
        {
            this.mContext = Application.Context;
            _milkDigitalIdService = DependencyService.Get<ImilkDigitalIDService>();
        }*/
        public HomeFragment(Context mContext)
        {
            this.mContext = mContext;
            _milkDigitalIdService = DependencyService.Get<ImilkDigitalIDService>();
        }


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // to return adapter view for this Fragment

            View view = inflater.Inflate(Resource.Layout.home_fragment, container, false);
            /**
              * refer the parent tag
              */
            //  homeLayout = view.FindViewById<LinearLayout>(Resource.Id.home_layout);

            LinearLayout ll_iv_1 = view.FindViewById<LinearLayout>(Resource.Id.ll_iv_1);
            LinearLayout ll_iv_2 = view.FindViewById<LinearLayout>(Resource.Id.ll_iv_2);
            LinearLayout ll_iv_3 = view.FindViewById<LinearLayout>(Resource.Id.ll_iv_3);
            LinearLayout ll_iv_4 = view.FindViewById<LinearLayout>(Resource.Id.ll_iv_4);

            listView = (ListView)view.FindViewById(Resource.Id.childList);

            Android.Graphics.Color backgroundColor = new Android.Graphics.Color(ThemeUtill.OnActivityCreateSetTheme((Activity)mContext));

            /**
             * set back ground color dynamicly here 
             */
            ll_iv_1.SetBackgroundColor(backgroundColor);
            ll_iv_2.SetBackgroundColor(backgroundColor);
            ll_iv_3.SetBackgroundColor(backgroundColor);
            ll_iv_4.SetBackgroundColor(backgroundColor);
            listView.SetBackgroundColor(backgroundColor);

            return view;

        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            registrationFragment = new RegistrationFragment(mContext);
            childInformation.Clear();
            adapter = new CustomListAdapter((Activity)mContext, childInformation);
            listView.Adapter = adapter;

            setChildInformation();

            adapter = new CustomListAdapter((Activity)mContext, childInformation);
            listView.Adapter = adapter;
            listView.OnItemClickListener = this;

        }

        /*  public Bitmap Base64ToBitmap(String base64String)
          {
              byte[] imageAsBytes = Base64.Decode(base64String, Base64Flags.Default);
              return BitmapFactory.DecodeByteArray(imageAsBytes, 0, imageAsBytes.Length);
          }*/


        public Bitmap ByteArrayToBitmap(byte[] bitmapData)
        {

            Bitmap bitmap = BitmapFactory.DecodeByteArray(bitmapData, 0, bitmapData.Length);
            return bitmap;
        }

        private void setChildInformation()
        {
            /* for (int i = 0; i < childName.Length; i++)
             {
                 childInformation.Add(new ChildInformation(childName[i], childImage[i]));
             }*/

            var sData = _milkDigitalIdService.GetDigitalIDs();
            foreach (var item in sData)
            {
                if (item.PortraitView != null)
                {
                    childInformation.Add(new ChildInformation(item.FirstName,
                        /*ImageHelpers.ConvertByteToStream(item.PortraitView)*/ByteArrayToBitmap(item.PortraitView)));
                }
                else
                {
                    Bitmap bitmap = BitmapFactory.DecodeResource(mContext.Resources, Resource.Drawable.xamarin);

                    childInformation.Add(new ChildInformation(item.FirstName,
                      bitmap));
                }

            }
        }

        public void OnItemClick(AdapterView parent, View view, int position, long id)
        {
            if (position == 0)
            {
                /* Intent intent = new Intent(Application.Context, typeof(RegistrationFragment));
                 StartActivity(intent);*/
                FragmentHelper.ReplaceFragment(this, registrationFragment);

            }
            var sData = _milkDigitalIdService.GetDigitalIDs()[position];
            if (sData != null)
            {

                Toast.MakeText(Application.Context, "position" + sData.NickName, ToastLength.Long).Show();
            }

        }



    }
}