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
using Felipecsl.GifImageViewLibrary;
using System.IO;
using System.Timers;
using Android.Content.PM;
using Android.Content.Res;
using Android.Util;
using Java.Util;
using Android.Preferences;

namespace WarThunderComparer
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait, Label = "WT Versus", MainLauncher = true, Icon = "@drawable/_Icon", NoHistory = true)]
    class SplashScreenNew : AppCompatActivity
    {
        GifImageView gifImageView;
        static string LanguageCodevalue;
        int languagesId;
        int firstActivityId;
        Context context;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            context = Application.Context;
            #region Мова
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            ISharedPreferencesEditor editor = prefs.Edit();
            languagesId = prefs.GetInt("key_languageId", 1);

            if (languagesId == 1)
            {
                LanguageCodevalue = "en";
            }
            else
            if (languagesId == 2)
            {
                LanguageCodevalue = "fr";
            }
            else
            if (languagesId == 3)
            {
                LanguageCodevalue = "de";
            }
            else
            if (languagesId == 4)
            {
                LanguageCodevalue = "it";
            }
            else
            if (languagesId == 5)
            {
                LanguageCodevalue = "es";
            }
            else
            if (languagesId == 6)
            {
                LanguageCodevalue = "pt";
            }
            else
            if (languagesId == 7)
            {
                LanguageCodevalue = "cs";
            }
            else
            if (languagesId == 8)
            {
                LanguageCodevalue = "pl";
            }
            else
            if (languagesId == 9)
            {
                LanguageCodevalue = "ru";
            }
            else
            if (languagesId == 10)
            {
                LanguageCodevalue = "uk";
            }
            else
            if (languagesId == 11)
            {
                LanguageCodevalue = "ja";
            }
            else
            if (languagesId == 12)
            {
                LanguageCodevalue = "ko";
            }
            
            Android.Content.Res.Resources res = this.Resources;
            DisplayMetrics Dm = res.DisplayMetrics;
            Android.Content.Res.Configuration conf = res.Configuration;
            if (LanguageCodevalue != null)
            {
                conf.SetLocale(new Locale(LanguageCodevalue));
            }
            else
            {
                conf.SetLocale(new Locale("en"));
            }
            res.UpdateConfiguration(conf, Dm);
            #endregion

            Window.AddFlags(WindowManagerFlags.Fullscreen);
            SetContentView(Resource.Layout._splashScreenNew);
            gifImageView = FindViewById<GifImageView>(Resource.Id.gifSplashScreen);

            var assets1 = Assets.List(string.Empty);
            if (assets1.Any())

            {
                var videoFilename = assets1.FirstOrDefault(a => a.EndsWith(".gif"));

                if (!string.IsNullOrWhiteSpace(videoFilename))

                {
                    var fileDescriptor = Assets.OpenFd(videoFilename);

                    using (var input = this.Assets.Open(videoFilename, Access.Streaming))
                    {
                        byte[] buffer;
                        using (Stream s = input)
                        {
                            long length = fileDescriptor.Length;
                            buffer = new byte[length];
                            s.Read(buffer, 0, (int)length);

                            gifImageView.SetBytes(buffer);
                            gifImageView.StartAnimation();
                        }
                    }

                }

            }

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1400;
            timer.AutoReset = false;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            gifImageView.StopAnimation();

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            ISharedPreferencesEditor editor = prefs.Edit();
            firstActivityId = prefs.GetInt("key_firstActivityId", 8);
            // key 1

            if (firstActivityId == 1)
            {
                StartActivity(new Intent(this, typeof(InfoStat)));
            }
            else
                            if (firstActivityId == 2)
            {
                StartActivity(new Intent(this, typeof(CompareStat)));
            }
            else
            /*       if (firstActivityId == 3)
                             {
                                 StartActivity(new Intent(this, typeof(InfoStat)));
                             }
            else*/
                                           if (firstActivityId == 4)
            {
                StartActivity(new Intent(this, typeof(InfoPlane)));
            }
            else
                                          if (firstActivityId == 5)
            {
                StartActivity(new Intent(this, typeof(ComparePlane)));
            }
            else
                                          if (firstActivityId == 6)
            {
                StartActivity(new Intent(this, typeof(TheBestPlane)));
            }
            else
                                                           if (firstActivityId == 7)
            {
                StartActivity(new Intent(this, typeof(InfoTank)));
            }
            else
                                          if (firstActivityId == 8)
            {
                StartActivity(new Intent(this, typeof(CompareTank)));
            }
            else
                                          if (firstActivityId == 9)
            {
                StartActivity(new Intent(this, typeof(TheBestTank)));
            }
            else
                                                           if (firstActivityId == 10)
            {
                StartActivity(new Intent(this, typeof(InfoHeli)));
            }
            else
                                          if (firstActivityId == 11)
            {
                StartActivity(new Intent(this, typeof(CompareHeli)));
            }
            else
                                          if (firstActivityId == 12)
            {
                StartActivity(new Intent(this, typeof(TheBestHeli)));
            }
            else
                                                           if (firstActivityId == 13)
            {
                StartActivity(new Intent(this, typeof(InfoShip)));
            }
            else
                                          if (firstActivityId == 14)
            {
                StartActivity(new Intent(this, typeof(CompareShip)));
            }
            else
                                          if (firstActivityId == 15)
            {
                StartActivity(new Intent(this, typeof(TheBestShip)));
            }
        }
    }
}