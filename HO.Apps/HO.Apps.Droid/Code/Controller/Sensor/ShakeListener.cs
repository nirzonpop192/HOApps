using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Hardware;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Home_Organizer.Code.Controller.Sensor
{

    /**
         *  This Class is to sence the shacking mode .... even it also can understand is the unintentional shacking 
         *  
         */
    class ShakeListener
    {


        private Context mContext;

        //        private Android.Hardware.Sensor mSensor;

        //        private List<Android.Hardware.Sensor> sensorsList;

        //        private Android.Hardware.SensorManager mSensorManager;

        private bool hasUpdated = false;
        private DateTime lastUpdate;
        /**
         * Last coordinates of X,Y,Z
         * */
        private float mCord_X = 0.0f;
        private float mCord_Y = 0.0f;
        private float mCord_Z = 0.0f;

        /**
         * CONSTANT
         */
        private const int SHAKE_DETECTION_TIME_LAPSE = 250;
        private const double SHAKE_THRESHOLD = 800;

        public ShakeListener(Context parent)
        {

            this.mContext = parent;

//              mSensorManager =
//                   (SensorManager)mContext.GetSystemService(Context.SensorService);
//
//               sensorsList = mSensorManager.GetSensorList(SensorType.All) as List<Android.Hardware.Sensor>;
//               if (sensorsList != null)
//               {
//                   if (sensorsList.Count > 0)
//                   {
//                       mSensor = sensorsList[0];
//                   }
//               }

        }

        /**
         * get Exception 
         */

        //        public void start()
        //        {
        //
        //
        //            var sensorManager = mContext.GetSystemService(Context.SensorService) as Android.Hardware.SensorManager;
        //            var sensor = sensorManager.GetDefaultSensor(Android.Hardware.SensorType.Accelerometer);
        //            sensorManager.RegisterListener(this, sensor, Android.Hardware.SensorDelay.Game);
        //
        //        }
        //
        //        public void stop()
        //        {
        //            //mSensorManager.UnregisterListener(this);
        //        }


        //        public void OnAccuracyChanged(Android.Hardware.Sensor sensor, SensorStatus accuracy)
        //        {
        //            throw new NotImplementedException();
        //        }

        private void updateCoordinate(float coor_X, float coor_Y, float coor_Z)
        {
            mCord_X = coor_X;
            mCord_Y = coor_Y;
            mCord_Z = coor_Z;
        }

        //        public void OnSensorChanged(SensorEvent e)
        //        {
        //            /**
        //             * if user hand sheak the device (Accelerometer)  Sensor will invoke 
        //             */
        //            if (e.Sensor.Type == Android.Hardware.SensorType.Accelerometer)
        //            {
        //                Shakedetect(e);
        //            }                   // end of if 
        //        }




        public bool Shakedetect(SensorEvent e)
        {

            bool shaked = false;
                /**
                *  get the current current coordinate  from sensor event 
                */
            float current_Coord_x = e.Values[0];
            float current_Coord_y = e.Values[1];
            float current_Coord_z = e.Values[2];

            DateTime curTime = System.DateTime.Now;
            /**
             *  this block detect the unintentional shake
             */
            if (hasUpdated == false)
            {
                hasUpdated = true;
                lastUpdate = curTime;

                updateCoordinate(current_Coord_x, current_Coord_y, current_Coord_z);

            }   
                                /**
                                 * the intentional shake block 
                                 */
            else
            {
                if ((curTime - lastUpdate).TotalMilliseconds > SHAKE_DETECTION_TIME_LAPSE)
                {

                    /**
                     * time ,t
                     */
                    float diffTime = (float)(curTime - lastUpdate).TotalMilliseconds;
                    /**
                     * update last shaking time 
                     */
                    lastUpdate = curTime;
                    /**
                     * total distance ,s
                     */
                    float total = current_Coord_x + current_Coord_y + current_Coord_z - mCord_X - mCord_Y - mCord_Z;
                    /**
                     *  v=(s/t)
                     */
                    float speed = Math.Abs(total) / diffTime * 10000;

                    if (speed > SHAKE_THRESHOLD)
                    {
                        Toast.MakeText(mContext, "Shaking", ToastLength.Short).Show();

                     

                        shaked = true;
                    } 
                    updateCoordinate(current_Coord_x, current_Coord_y, current_Coord_z);

                }          
            }              

            return shaked;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IntPtr Handle { get; }
    }
}