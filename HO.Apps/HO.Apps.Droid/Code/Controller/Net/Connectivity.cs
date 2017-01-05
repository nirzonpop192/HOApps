using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Telephony;
using Android.Views;
using Android.Widget;
using Java.Net;

using System.Threading;
using Android.Content;
using Android.Net;
using Android.Telephony;
using Java.IO;
using Java.Net;

namespace Home_Organizer.Code.Controller.Net
{


    /*
     *   This class is for checking the internet connection and all the network related fuctionalities ....
     */
    class Connectivity
    {

        /**
	     * Get the network information ....  
	     */
        public static NetworkInfo GetNetworkInfo(Context context)
        {
            ConnectivityManager cm = (ConnectivityManager)context.GetSystemService(Context.ConnectivityService);
            return cm.ActiveNetworkInfo;
        }

        /**
	     * Check if there is any connectivity	    
	     */
        public static bool IsConnected(Context context)
        {
            NetworkInfo info = Connectivity.GetNetworkInfo(context);
            return (info != null && info.IsConnected);
        }

        /**
	     * Check if there is any connectivity to a Wifi network	     
	     */
        public static bool IsConnectedWifi(Context context)
        {
            NetworkInfo info = Connectivity.GetNetworkInfo(context);
            return (info != null && info.IsConnected && info.Type == ConnectivityType.Wifi);
        }

        /**
	     * Check if there is any connectivity to a mobile network	     
	     */
        public static bool IsConnectedMobile(Context context)
        {
            NetworkInfo info = Connectivity.GetNetworkInfo(context);
            return (info != null && info.IsConnected && info.Type == ConnectivityType.Mobile);
        }

        /**
	     * Check if there is fast connectivity then others 
	     */
        public static bool IsConnectedFast(Context context)
        {
            NetworkInfo info = Connectivity.GetNetworkInfo(context);
            TelephonyManager tm = TelephonyManager.FromContext(context);
            return (info != null && info.IsConnected && Connectivity.IsConnectionFast(info.Type, tm.NetworkType));
        }

        /**
	     * Check if the connection is fast	    
	     */
        public static bool IsConnectionFast(ConnectivityType type, NetworkType subType)
        {
            if (type == ConnectivityType.Wifi)
            {
                return true;
            }
            else if (type == ConnectivityType.Mobile)
            {
                switch (subType)
                {
                   /*
                    * Check for all kind of network that the oparetor provide 
                    */
                    case NetworkType.OneXrtt:
                        return false;

                    case NetworkType.Cdma:
                        return false; 

                    case NetworkType.Edge:
                        return false;

                    case NetworkType.Evdo0:
                        return true;

                    case NetworkType.EvdoA:
                        return true;

                    case NetworkType.Gprs:
                        return false; 

                    case NetworkType.Hsdpa:
                        return true; 

                    case NetworkType.Hspa:
                        return true; 

                    case NetworkType.Hsupa:
                        return true;

                    case NetworkType.Umts:
                        return true; 
                                     /*
                                      * Above API level 7, make sure to set android:targetSdkVersion
                                      * to appropriate level to use these
                                      */
                                   
                    case NetworkType.Ehrpd:
                        return true; 

                    case NetworkType.EvdoB:
                        return true; 

                    case NetworkType.Hspap:
                        return true;

                    case NetworkType.Iden:
                        return false; 

                    case NetworkType.Lte:
                        return true;

                    case NetworkType.Unknown:
                        return false;
                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool IsHostReachable(string host)
        {
            if (string.IsNullOrEmpty(host))
                return false;

            bool isReachable = true;

            Thread thread = new Thread(() =>
            {
                try
                {
                    //isReachable = InetAddress.GetByName(host).IsReachable(2000);

                    /* 
                     * It's important to note that isReachable tries ICMP ping and then TCP echo (port 7).
                     * These are often closed down on HTTP servers.
                     * So a perfectly good working API with a web server on port 80 will be reported as unreachable
                     * if ICMP and TCP port 7 are filtered out!
                     * 
                     * Though we are not check it out
                     */

                    //if (!isReachable){
                    URL url = new URL("http://" + host);

                    URLConnection connection = url.OpenConnection();

                    //if(connection.ContentLength != -1){
                    //isReachable = true;
                    if (connection.ContentLength == -1)
                    {
                        isReachable = false;
                    }
                    //}

                }
                catch (UnknownHostException e)
                {
                    isReachable = false;
                }
                catch (IOException e)
                {
                    isReachable = false;
                }

            });
            thread.Start();

            return isReachable;
        }
    }
}