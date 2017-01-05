using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


namespace Home_Organizer.Code.Controller
{

    /*
        *  This class is for parsing the image for the api result, json in future use  .
        * 
        */
    class Parser
    {



        public bool IsValidPromoCode(string url)
        {
            bool validPromoCode = false;

            string webResponse;

            using (var webClient = new WebClient())
            {
                webResponse = webClient.DownloadString(url);
                if (webResponse.Equals("true"))
                {
                    validPromoCode = true;
                }
            }
            return validPromoCode;
        }

        public string GetImageUrlFromApi(string url)
        {


            string imageUrlLink = "";

            using (var webClient = new WebClient())
            {
                imageUrlLink = webClient.DownloadString(url);
                // replace " double Cote from the link 
                imageUrlLink = imageUrlLink.Replace('"', ' ');
            }

            return imageUrlLink;
        }
        public Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }
    }
}