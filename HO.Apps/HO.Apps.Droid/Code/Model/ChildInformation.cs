using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Home_Organizer.Code.Model
{

    /*
    *  This class is for determining  the list item model. 
    */
    class ChildInformation
    {
        public string childName { get; set; }
        public Bitmap url { get; set; }

    /*    public Bitmap url { get; set; }
        public string childName { get; set; }*/
/*
        public ChildInformation(string name, Stream image)
        {
            this.url = image;
            this.childName = name;
        }*/

        public ChildInformation(string firstName, Bitmap bitmap)
        {
            this.childName = firstName;
            this.url = bitmap;
        }
    }
}