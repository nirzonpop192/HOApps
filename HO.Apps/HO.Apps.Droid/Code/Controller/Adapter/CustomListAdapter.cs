using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DE.Hdodenhof.Circleimageview;
using Home_Organizer.Code.Model;
using HO.Apps.Droid;

namespace Home_Organizer.Code.Controller.Adapter
{
    /*
    *  This Class is created for populating the list view...... 
    */
    class CustomListAdapter : BaseAdapter<ChildInformation>
    {
        Context context;
        List<ChildInformation> childList;

        public CustomListAdapter(Context _context, List<ChildInformation> _list)
        {
            this.context = _context;
            this.childList = _list;
        }
        public override ChildInformation this[int position]
        {
            get { return childList[position]; }
        }

        public override int Count
        {
            get { return childList.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        private LayoutInflater lInflater;
        public override Android.Views.View GetView(int position, Android.Views.View convertView, ViewGroup parent)
        {
            Android.Views.View view = convertView;

            // re-use an existing view, if one is available
            // otherwise create a new one

            // this is for the first item ..... the add button 
            if (view == null && position == 0)
            {
                lInflater = (LayoutInflater)context.GetSystemService(Android.Content.Context.LayoutInflaterService);
                view = lInflater.Inflate(Resource.Layout.first_item, parent, false);
            }

            // this is for the rest of items 
            else if (view == null && position != 0)

            {
                lInflater = (LayoutInflater)context.GetSystemService(Android.Content.Context.LayoutInflaterService);
                view = lInflater.Inflate(Resource.Layout.item_child, parent, false);


            }
            ChildInformation item = this[position];
            
            CircleImageView imageButton = view.FindViewById<CircleImageView>(Resource.Id.childImage);
            TextView tv_childNmae = view.FindViewById<TextView>(Resource.Id.childName);

        
            Bitmap imageBitmap = item.url;
            imageButton.SetImageBitmap(imageBitmap);
                      //  imageButton.SetImageResource(item.url);
            tv_childNmae.Text = item.childName;

            imageButton.Focusable = false;
            imageButton.FocusableInTouchMode = false;
            imageButton.Clickable = true;

            imageButton.Click += (sender, args) => Console.WriteLine("ImageButton {0} clicked", position);

            if (position >= 1)
            {
                tv_childNmae.SetTextColor(Color.White);
                if (position % 2 == 0)
                {
                    view.SetBackgroundResource(Resource.Color.list_item_color2);

                }
                else
                {
                    view.SetBackgroundResource(Resource.Color.list_item_color1);

                }
            }



            return view;
        }
    }
}