using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Hardware;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Home_Organizer.Code.Controller.Config;
using Home_Organizer.Code.Controller.Sensor;
using Home_Organizer.Code.View.Helper;
using HO.Apps.Contracts;
using HO.Apps.Droid;
using HO.Apps.Droid.Code.Controller.Config;
using HO.Apps.Models;
using ImageViews.Rounded;
using Square.Picasso;
using static Android.App.Result;
using HO.Apps.Services;
using Xamarin.Forms;
using Application = Android.App.Application;
using Button = Android.Widget.Button;
using DatePicker = Android.Widget.DatePicker;
using View = Android.Views.View;

namespace Home_Organizer.Fragment
{

    /*
     *  This is for collceting the user information to generate the M.I.L.K id 
     */
    public class RegistrationFragment : Android.Support.V4.App.Fragment, Android.Hardware.ISensorEventListener
    {
        private ImageView imageView;

        private ShakeListener mShakeListener;
        private ImilkDigitalIDService _milkDigitalIdService;
        private Context mContext;

        private DatePicker datePicker;
        private DialogManager mDialogManager;
        View view;
        private TextView dateOfBirth;
        private DateTime _date;     
        private DateTime date
        {   
            get { return _date; }
            set
            {
                _date = value;
                this.updateDateHandler(this, this.date);
            }
        }

        private event EventHandler<DateTime> updateDateHandler;
        LinearLayout firstLayout, secondLayout;
        private EditText firstName, bloodType, race, hairColor, eyeColor, height, weight, glasses, distinguishingMark, contact, comments, gender;
        private Button  cencle, save;
        private ImageView next;

        public RegistrationFragment(Context context)
        {
            this.mContext = context;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            view = inflater.Inflate(Resource.Layout.registration_fragment, container, false);
            
            initView();
            
            secondLayout.Visibility = ViewStates.Gone;
            return view;
        }

     /*   private string getDate()
        {
          //datePicker = new DatePickerDialog(mContext);
            StringBuilder strCurrentDate = new StringBuilder();
            int month = datePicker.Month+1;
            strCurrentDate.Append("date: " + month + "/" + datePicker.DayOfMonth + "/" + datePicker.Year);

            return strCurrentDate.ToString();
        }*/

        public void initView()
        {
            mDialogManager = new DialogManager(mContext);
            firstLayout = (LinearLayout)view.FindViewById(Resource.Id.first_layout);
            secondLayout = (LinearLayout)view.FindViewById(Resource.Id.second_layout);
            imageView = (ImageView)view.FindViewById(Resource.Id.childImage1);

            dateOfBirth = (TextView) view.FindViewById(Resource.Id.birth_date);
           // dateOfBirth.SetText("5");
            dateOfBirth.Text = "";

            
            firstName = (EditText)view.FindViewById(Resource.Id.edt_first_name);
            bloodType = (EditText)view.FindViewById(Resource.Id.edt_blood_type);
            race = (EditText)view.FindViewById(Resource.Id.edt_race);
            hairColor = (EditText)view.FindViewById(Resource.Id.edt_hair_color);
            eyeColor = (EditText)view.FindViewById(Resource.Id.edt_eye_color);
            height = (EditText)view.FindViewById(Resource.Id.edt_height);
            weight = (EditText)view.FindViewById(Resource.Id.edt_weight);
            glasses = (EditText)view.FindViewById(Resource.Id.edt_glasses);
            distinguishingMark = (EditText)view.FindViewById(Resource.Id.edt_distinguishing_mark);
            contact = (EditText)view.FindViewById(Resource.Id.edt_contact);
            comments = (EditText)view.FindViewById(Resource.Id.edt_comments);
            gender = (EditText)view.FindViewById(Resource.Id.edt_gender);


            next = view.FindViewById< ImageView> (Resource.Id.iv_next);
            cencle = view.FindViewById<Button>(Resource.Id.btn_cencle);
            save = view.FindViewById<Button>(Resource.Id.btn_save);

            _milkDigitalIdService = DependencyService.Get<ImilkDigitalIDService>();

            Android.Widget.ScrollView sv_lay = (Android.Widget.ScrollView)view.FindViewById(Resource.Id.sv_lay);
            Android.Graphics.Color backgroundColor = new Android.Graphics.Color(ThemeUtill.OnActivityCreateSetTheme((Activity)mContext));

            /**
             * set back ground color dynamicly here 
             */
            sv_lay.SetBackgroundColor(backgroundColor);

        }

         void OnDateSet (object sender, DatePickerDialog.DateSetEventArgs e)
        {
            
            this.date = e.Date;
        }



        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            imageView.Click += delegate
            {
                switch (mDialogManager.ShowGalleryCameraDialog())
                {
                    case Util.REQUEST_FOR_CAMERA:
                        getImageFormCamera();
                        break;

                    case Util.REQUEST_FOR_GALLERY:
                        getImageFormGallery();

                        break;
                }
            };
            /*
                        dateOfBirth.Click += delegate
                        {
                            dateOfBirth.Text = getDate();
                        };*/

            dateOfBirth.Click += delegate {
                // ShowDialog (DATE_DIALOG_ID); 
                DatePickerDialog dialog = new DatePickerDialog( mContext,OnDateSet,date.Year,date.Month-1,date.Day);
                dialog.Show();

            };

            this.updateDateHandler += delegate (object sender, DateTime e) {
                dateOfBirth.Text = e.ToString("d");
            };

            // get the current date
            date = DateTime.Today;



            next.Click += delegate
            {
                firstLayout.Visibility = ViewStates.Gone;
                secondLayout.Visibility = ViewStates.Visible;
                next.Visibility = ViewStates.Gone;
            };

            cencle.Click += delegate
            {
                //Intent intent = getIntent();
                //this.finish();
                //startActivity(intent);


            };

            save.Click += delegate
            {
                String strAge,
                    strBloodType,
                    strCmments,
                    strContact,
                    strDateOfBirth,
                    strDistinguishingMarks,
                    strEyeColor,
                    strFirstName,
                    strGender,
                    strGlasses,
                    strHairColor,
                    strHeight,
                    strImagePortraitView,
                    strImageSideView,
                    strLastName,
                    strMiddleName,
                    strNickName,
                    strPhotoDate,
                    strProtraitView,
                    strRace,
                    strSideView,
                    strWeight;

               /* strDateOfBirth = 
                strAge = getCurrentAge(strDateOfBirth)*/
                strBloodType = bloodType.Text;
                strCmments = comments.Text;
                strContact = contact.Text;
                strDistinguishingMarks = distinguishingMark.Text;
                strEyeColor = eyeColor.Text;
                strFirstName = firstName.Text;
                strGender = gender.Text;
                strGlasses = glasses.Text;
                strHairColor = hairColor.Text;
                strHeight = height.Text;
                strRace = race.Text;
                strWeight = weight.Text;

                milkDigitalID digitalID = new milkDigitalID()
                {
                    Age = 32,
                    BloodType = strBloodType,
                    Comments = strCmments,
                    Contact = strContact,
                    DateOfBirth = new DateTime(2016, 11, 20),
                    DistinguishingMarks = strDistinguishingMarks,
                    EyeColor = strEyeColor,
                    FirstName = strFirstName,
                    Gender = strGender,
                    Glasses = strGlasses,
                    HairColor = strHairColor,
                    Height = strHeight,
                    ImagePortraitView = "",
                    ImageSideView = "",
                    LastName = "last name",
                    MiddleName = "Middle Name",
                    NickName = "Shuvo",
                    PhotoDate = DateTime.UtcNow,
                    PortraitView = null,
                    Race = strRace,
                    SideView = null,
                    Weight = strWeight
                };
                //_milkDigitalIdService.CreateDigitalID(digitalID);
                var sData = _milkDigitalIdService.GetDigitalIDs();
                var getId = _milkDigitalIdService.GetDigitalID(1);

               // Log.Error("shuvo", sData);
                Toast.MakeText(mContext,""+sData,ToastLength.Long).Show();
                Toast.MakeText(mContext,"saved",ToastLength.Long).Show();
            };
            SetUpSensor();
        }

        public static string getCurrentAge( DateTime birthday)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - birthday.Year;
            if (now < birthday.AddYears(age)) age--;

            return age.ToString();
        }

      

        public override void OnActivityResult(int requestCode, int resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == 11)
            {
               
                switch (resultCode)
                {
                    case (int)Result.Ok:
                        try
                        {
                            Bitmap bitmap = (Bitmap)data.Extras.Get("data");
                            // if (bitmap != null)
                            // {
                            imageView.SetImageBitmap(bitmap);
                            // }
                            // else
                            // {
                            //    Toast.MakeText(context, "Thanks", ToastLength.Long).Show();
                            // }
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        break;

                    case (int)Result.Canceled:
                        Toast.MakeText(mContext, "Thanks", ToastLength.Long).Show();
                        break;
                }
                
            } else if (requestCode == 12)
            {
                switch (resultCode)
                {
                    case (int)Result.Ok:
                        imageView.SetImageURI(data.Data);
                        break;
                    case (int)Result.Canceled:
                        Toast.MakeText(mContext, "Thanks", ToastLength.Long).Show();
                        break;
                }
               
            }
        }

     
     

        private void SetUpSensor()
        {
            mShakeListener = new ShakeListener(Application.Context);
            var sensorManager = mContext.GetSystemService(Context.SensorService) as Android.Hardware.SensorManager;
            var sensor = sensorManager.GetDefaultSensor(Android.Hardware.SensorType.Accelerometer);
            sensorManager.RegisterListener(this, sensor, Android.Hardware.SensorDelay.Game);
        }

        public void OnAccuracyChanged(Sensor sensor, SensorStatus accuracy)
        {
            throw new NotImplementedException();
        }

        public void OnSensorChanged(SensorEvent e)
        {
            if (AppController.GetHandShakingSetting())
            {
                if (mShakeListener.Shakedetect(e))
                {
                    // ------DO WHAT YOU WANT TO DO WITH VIEW 

                }
            }
        }


        private void getImageFormCamera()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            // mContext.StartActivityForResult(intent, 11);

            StartActivityForResult(intent, 11);
        }

        private void getImageFormGallery()
        {
            var imageIntent = new Intent();
            imageIntent.SetType("image/*");
            imageIntent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(
            Intent.CreateChooser(imageIntent, "Select photo"), 12);
        }

        
    }
}