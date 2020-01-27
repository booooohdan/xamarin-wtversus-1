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
using Android.Webkit;
using Android.Content;

namespace WarThunderComparer
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait)]
    class Feedback : AppCompatActivity
    {
        Button ButtonReddit, ButtonDiscord;


        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\
        DrawerLayout drawerLayout;
        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\
        public Feedback()
        {
        }

        protected Feedback(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Feedback);
            ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id._app_bar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetTitle(Resource.String.app_name);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);
            var navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected; ;
            var drawerToogle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.open_drawer, Resource.String.close_drawer);
            drawerLayout.AddDrawerListener(drawerToogle);
            drawerToogle.SyncState();
            ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\
            Context context = Application.Context;
        /*    ButtonReddit = FindViewById<Button>(Resource.Id.buttonReddit);
            ButtonDiscord = FindViewById<Button>(Resource.Id.buttonDiscord);

            ButtonReddit.Click += ButtonReddit_Click;
            ButtonDiscord.Click += ButtonDiscord_Click;*/

            /*
            var EditTo = "wtversus@gmail.com";
            var EditSubject = FindViewById<TextView>(Resource.Id.editSubject);
            var EditMessage = FindViewById<TextView>(Resource.Id.editMessage);
            var ButtonSend = FindViewById<Button>(Resource.Id.buttonSend);
            
            ButtonSend.Click += (s, e) => {
                Intent email = new Intent(Intent.ActionSend);
                email.PutExtra(Intent.ExtraEmail, new string[] { EditTo.ToString() });
                email.PutExtra(Intent.ExtraSubject, EditSubject.Text.ToString());
                email.PutExtra(Intent.ExtraText, EditMessage.Text.ToString());
                email.SetType("message/rfc822");
                StartActivity(Intent.CreateChooser(email, context.Resources.GetString(Resource.String.EmailClient)));
            };

          string txtUrl = "";
            webViewFeedback = FindViewById<WebView>(Resource.Id.webViewF);
          webViewFeedback.SetWebViewClient(new ExtendWebViewClient());

            WebSettings webSettings = webViewFeedback.Settings;
            webSettings.JavaScriptEnabled = true;
            webViewFeedback.LoadUrl(txtUrl);
            */
                    StartActivity(typeof(Dedoherzer));
                    Finish();
        }

     /*   private void ButtonDiscord_Click(object sender, EventArgs e)
        {
            var uri = Android.Net.Uri.Parse("https://discord.gg/DHVHkfA");
            var intent = new Intent(Intent.ActionView, uri);
            StartActivity(intent);
        }

        private void ButtonReddit_Click(object sender, EventArgs e)
        {
            var uri = Android.Net.Uri.Parse("https://www.reddit.com/r/wtversus/");
            var intent = new Intent(Intent.ActionView, uri);
            StartActivity(intent);
        }
*/
        /*    public override void OnBackPressed()
            {
                if (webViewFeedback.CanGoBack())
                {
                    webViewFeedback.GoBack();
                }
                else
                {
                    base.OnBackPressed();
                }
            }
            */



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