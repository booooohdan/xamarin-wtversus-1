using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Content.PM;
using Android.Graphics;
using WarThunderComparer.comparerData.Adapters;
using WarThunderComparer.comparerData.Collections;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;

namespace WarThunderComparer
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait)]
    class SplashScreen:AppCompatActivity
    {
        public SplashScreen()
        {
        }

        protected SplashScreen(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
        Context context;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
                    context = Application.Context;
            

        }
    }
}