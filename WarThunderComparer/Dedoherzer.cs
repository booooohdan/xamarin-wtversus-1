using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.OS;
using Android.Widget;
using Android.Content.PM;
using WarThunderComparer.comparerData.Adapters;
using WarThunderComparer.comparerData.Collections;
using Android.Graphics;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Content;
using Android.Preferences;
using Android.Util;
using Java.Util;

namespace WarThunderComparer
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait)]
    class Dedoherzer : AppCompatActivity
    {
        Context context;
        Switch switchKMHToMPH;
        Button buttonApply;
        Spinner languageSpiner;
        Spinner firstActivitySpinner;
        LanguageAdapter AdapterLanguage;
        FirstActivityAdapter AdapterFirstActivity;
        List<Language> languages;
        List<FirstActivity> firstActivities;

        static string LanguageCodevalue;
        int languagesId;
        int firstActivityId;

        Button ButtonReddit, ButtonDiscord, ButtonEmail, ButtonAboutTheApp;
        RatingBar RatingBar;

        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\
        DrawerLayout drawerLayout;
        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            context = Application.Context;
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

            SetContentView(Resource.Layout.Dedoherzer);
            
            ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id._app_bar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetTitle(Resource.String.app_name);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);
            var navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;
            var drawerToogle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.open_drawer, Resource.String.close_drawer);
            drawerLayout.AddDrawerListener(drawerToogle);
            drawerToogle.SyncState();
            ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\  

            #region Прив'язка 

            switchKMHToMPH = FindViewById<Switch>(Resource.Id.settingsSwitchKMHToMPH);
            buttonApply = FindViewById<Button>(Resource.Id.settingsButtonApply);
            languageSpiner = FindViewById<Spinner>(Resource.Id.languageSpiner);
            firstActivitySpinner = FindViewById<Spinner>(Resource.Id.firstActivitySpiner);

            ButtonReddit = FindViewById<Button>(Resource.Id.buttonReddit);
            ButtonDiscord = FindViewById<Button>(Resource.Id.buttonDiscord);
            ButtonEmail = FindViewById<Button>(Resource.Id.buttonEMail);
            RatingBar = FindViewById<RatingBar>(Resource.Id.ratingBar);
            ButtonAboutTheApp = FindViewById<Button>(Resource.Id.settingsAboutTheAppButton);
            
            #endregion

            #region Запам'ятовування перемикача км/г в миль/г

            switchKMHToMPH.Checked = prefs.GetBoolean("key_kmhtomph", false);
            #endregion

            #region Вибір мови

            languages = LanguageCollection.GetLanguages();
            AdapterLanguage = new LanguageAdapter(this, languages);
            languageSpiner.Adapter = AdapterLanguage;
            languagesId = prefs.GetInt("key_languageId", 1);
            languageSpiner.SetSelection(languagesId-1);  //Автовыбор

            languageSpiner.ItemSelected += LanguageSpiner_ItemSelected;

            #endregion

            #region Вибір актівіті

            firstActivities = FirstActivityCollection.GetFirstActivitys();
            AdapterFirstActivity = new FirstActivityAdapter(this, firstActivities);
            firstActivitySpinner.Adapter = AdapterFirstActivity;
            firstActivityId = prefs.GetInt("key_firstActivityId", 1);

            firstActivitySpinner.ItemSelected += FirstActivitySpinner_ItemSelected;
            #endregion

            #region Кнопка застосувати

            buttonApply.Click += (sender, e) =>
            {
                if (switchKMHToMPH.Checked == true)
                {
                    editor.PutBoolean("key_kmhtomph", true);
                    editor.Apply();
                }
                else
                {
                    editor.PutBoolean("key_kmhtomph", false);
                    editor.Apply();
                }

                if (languagesId == 1)
                {
                    LanguageCodevalue = "en";
                } else 
                if (languagesId == 2)
                {
                    LanguageCodevalue = "ru";
                }
                if (languagesId == 3)
                {
                    LanguageCodevalue = "uk";
                }
                this.Recreate();
                Toast.MakeText(context, context.Resources.GetString(Resource.String.SettingsApplied), ToastLength.Short).Show();
            };
            #endregion


            ButtonReddit.Click += ButtonReddit_Click;
            ButtonDiscord.Click += ButtonDiscord_Click;
            ButtonEmail.Click += ButtonEmail_Click;
            ButtonAboutTheApp.Click += ButtonAboutTheApp_Click;
            RatingBar.RatingBarChange += RatingBar_RatingBarChange;

        }

        private void ButtonAboutTheApp_Click(object sender, EventArgs e)
        {
            Android.App.AlertDialog.Builder alertDialog = new Android.App.AlertDialog.Builder(this);
            alertDialog.SetTitle(context.Resources.GetString(Resource.String.AboutTheAppButton));
            alertDialog.SetMessage(context.Resources.GetString(Resource.String.AboutTheApp));
            alertDialog.SetNeutralButton("Ok", delegate
            {
                alertDialog.Dispose();
            });
            alertDialog.Show();
        } 

        private void RatingBar_RatingBarChange(object sender, RatingBar.RatingBarChangeEventArgs e)
        {
            StartActivity(new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://play.google.com/store/apps/details?id=com.wave.wtversus")));
        }

        private void ButtonReddit_Click(object sender, EventArgs e)
        {
            var uri = Android.Net.Uri.Parse("https://www.reddit.com/r/wtversus/");
            var intent = new Intent(Intent.ActionView, uri);
            StartActivity(intent);
        }

        private void ButtonDiscord_Click(object sender, EventArgs e)
        {
            var uri = Android.Net.Uri.Parse("https://discord.gg/DHVHkfA");
            var intent = new Intent(Intent.ActionView, uri);
            StartActivity(intent);
        }

        private void ButtonEmail_Click(object sender, EventArgs e)
        {
            var EditTo = "waveappfeedback@gmail.com";
            var EditSubject = "WT Versus Feedback";
            var EditMessage = "";

            Intent email = new Intent(Intent.ActionSend);
            email.PutExtra(Intent.ExtraEmail, new string[] { EditTo.ToString() });
            email.PutExtra(Intent.ExtraSubject, new string[] { EditSubject.ToString() });
            email.PutExtra(Intent.ExtraText, new string[] { EditMessage.ToString() });
            email.SetType("message/rfc822");
            StartActivity(Intent.CreateChooser(email, context.Resources.GetString(Resource.String.EmailClient)));
        }

        private void FirstActivitySpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            firstActivityId = firstActivities[e.Position].Id;
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutInt("key_firstActivityId", firstActivityId);
            editor.Apply();
        }

        private void LanguageSpiner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            languagesId = languages[e.Position].Id;
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutInt("key_languageId", languagesId);
            editor.Apply();
        }

        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\
        private void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            switch (e.MenuItem.ItemId)
            {
                case (Resource.Id.nav_stat_compare):
                    StartActivity(typeof(CompareStat));
                    Finish();
                    break;
                case (Resource.Id.nav_stat_info):
                    StartActivity(typeof(InfoStat));
                    Finish();
                    break;
                case (Resource.Id.nav_avia_info):
                    StartActivity(typeof(InfoPlane));
                    Finish();
                    break;
                case (Resource.Id.nav_avia_compare):
                    StartActivity(typeof(ComparePlane));
                    Finish();
                    break;
                case (Resource.Id.nav_avia_thebest):
                    StartActivity(typeof(TheBestPlane));
                    Finish();
                    break;
                case (Resource.Id.nav_army_info):
                    StartActivity(typeof(InfoTank));
                    Finish();
                    break;
                case (Resource.Id.nav_army_compare):
                    StartActivity(typeof(CompareTank));
                    Finish();
                    break;
                case (Resource.Id.nav_army_thebest):
                    StartActivity(typeof(TheBestTank));
                    Finish();
                    break;
                case (Resource.Id.nav_heli_info):
                    StartActivity(typeof(InfoHeli));
                    Finish();
                    break;
                case (Resource.Id.nav_heli_compare):
                    StartActivity(typeof(CompareHeli));
                    Finish();
                    break;
                case (Resource.Id.nav_heli_thebest):
                    StartActivity(typeof(TheBestHeli));
                    Finish();
                    break;
                case (Resource.Id.nav_navy_info):
                    StartActivity(typeof(InfoShip));
                    Finish();
                    break;
                case (Resource.Id.nav_navy_compare):
                    StartActivity(typeof(CompareShip));
                    Finish();
                    break;
                case (Resource.Id.nav_navy_thebest):
                    StartActivity(typeof(TheBestShip));
                    Finish();
                    break;
                case (Resource.Id.nav_dedoHerzer):
                    StartActivity(typeof(Dedoherzer));
                    Finish();
                    break;
                case (Resource.Id.nav_memes):
                    StartActivity(typeof(Memes));
                    Finish();
                    break;
                case (Resource.Id.nav_feedback):
                    StartActivity(typeof(Feedback));
                    Finish();
                    break;
            }
            drawerLayout.CloseDrawers();
        }
        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\

    }
}