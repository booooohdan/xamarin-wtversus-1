using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using AngleSharp;
using AngleSharp.Scripting;
using AngleSharp.Js;
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
using TextView = Android.Widget.TextView;
using System.Text.RegularExpressions;
using Android.Views.InputMethods;
using Felipecsl.GifImageViewLibrary;
using static Android.Views.View;
using Android.Views;
using Android.Webkit;
using System.Globalization;
using System.Threading;
using Android.Preferences;
using Android.Gms.Ads;
using CloudFlareUtilities;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;

namespace WarThunderComparer
{
    class PreferAB
    {
        public double ABPercent;
        public string ModeName;
    }
    class PreferRB
    {
        public double RBPercent;
        public string ModeName;
    }
    class PreferSB
    {
        public double SBPercent;
        public string ModeName;
    }
    class BEList
    {
        public double KB { get; set; }

    }
    class BEListAB
    {
        public double KB_AB { get; set; }
    }
    class BEListRB
    {
        public double KB_RB { get; set; }
    }
    class BEListSB
    {
        public double KB_SB { get; set; }
    }

    [Activity(ScreenOrientation = ScreenOrientation.Portrait)]
    class InfoStat : AppCompatActivity
    {
        Context context;
        ImageButton _InfoButtonSearch;
        AutoCompleteTextView _InfoEditTextSearch;
        AngleSharp.Dom.IDocument document;

        //Объявление  кнопок и поиска

        #region Объявление всех текстовых полей
        ContentLoadingProgressBar InfoParserLoadProgressBar;
        ImageView _InfoStatImage;
        TextView _TopHintTextViewInfo;
        TextView _InfoStatSquad;
        TextView _InfoStatLevel;
        TextView _InfoStatSkillAB;
        TextView _InfoStatSkillRB;
        TextView _InfoStatSkillSB;
        TextView _InfoStatPreferenceAB;
        TextView _InfoStatPreferenceRB;
        TextView _InfoStatPreferenceSB;
        TextView _InfoStatWinRateAB;
        TextView _InfoStatWinRateRB;
        TextView _InfoStatWinRateSB;
        TextView _InfoStatKillRespRatioAviaAB;
        TextView _InfoStatKillRespRatioAviaRB;
        TextView _InfoStatKillRespRatioAviaSB;
        TextView _InfoStatBattleNumberAviaAB;
        TextView _InfoStatBattleNumberAviaRB;
        TextView _InfoStatBattleNumberAviaSB;
        TextView _InfoStatKillRespRatioTankAB;
        TextView _InfoStatKillRespRatioTankRB;
        TextView _InfoStatKillRespRatioTankSB;
        TextView _InfoStatBattleNumberTankAB;
        TextView _InfoStatBattleNumberTankRB;
        TextView _InfoStatBattleNumberTankSB;
        TextView _InfoStatKillRespRatioShipAB;
        TextView _InfoStatKillRespRatioShipRB;
        TextView _InfoStatKillRespRatioShipSB;
        TextView _InfoStatBattleNumberShipAB;
        TextView _InfoStatBattleNumberShipRB;
        TextView _InfoStatBattleNumberShipSB;
        TextView _InfoStatUSAVehicle;
        TextView _InfoStatGermanyVehicle;
        TextView _InfoStatUSSRVehicle;
        TextView _InfoStatGBVehicle;
        TextView _InfoStatJapanVehicle;
        TextView _InfoStatItalyVehicle;
        TextView _InfoStatFranceVehicle;
        TextView _InfoStatRegDate;
        TextView _InfoStatTotalTime;
        TextView _InfoStatLionEarned;
        TextView _InfoWinRateLabel;
        TextView _InfoStatLevelLabel;
        TextView _InfoKillRespAviaLabel;
        TextView _InfoBattleNumberAviaLabel;
        TextView _InfoKillRespTankLabel;
        TextView _InfoBattleNumberTankLabel;
        TextView _InfoKillRespShipLabel;
        TextView _InfoBattleNumberShipLabel;
        TextView _InfoRegDateLabel;
        TextView _InfoTotalTimeLabel;
        TextView _InfoLionEarnedLabel;
        TextView _InfoStatPriorityAB;
        TextView _InfoStatPriorityRB;
        TextView _InfoStatPrioritySB;
        TextView _InfoStatSkillName;


        TextView _InfoStatFighter;
        TextView _InfoStatAttacker;
        TextView _InfoStatBomber;
        TextView _InfoStatMiddleTank;
        TextView _InfoStatHeavyTank;
        TextView _InfoStatTankDestroyer;
        TextView _InfoStatSPAA;
        TextView _InfoStatBoat;
        TextView _InfoStatBarge;
        TextView _InfoStatSeaHunter;
        TextView _InfoStatShipDestroyer;
        TextView _InfoStatCruiser;

        #endregion
        private string nickName;
        private string nickName1;
        private string nickName2;
        private string nickName3;
        private string nickName4;
        private string nickName5;
        private string nickName6;
        private string nickName7;
        private string nickName8;
        private string nickName9;
        private string nickName10;
        private string[] names;


        #region Поля для записай данных парсинга
        private string InfoStatSquad;
        private string InfoStatLevel;
        private string InfoStatSkillAB;
        private string InfoStatSkillRB;
        private string InfoStatSkillSB;
        private string InfoStatPreferenceAB;
        private string InfoStatPreferenceRB;
        private string InfoStatPreferenceSB;

        private string InfoStatWinRateAB;
        private string InfoStatWinRateRB;
        private string InfoStatWinRateSB;

        private string InfoStatFragNumberAviaAB;
        private string InfoStatFragNumberAviaRB;
        private string InfoStatFragNumberAviaSB;
        private string InfoStatBattleNumberAviaAB;
        private string InfoStatBattleNumberAviaRB;
        private string InfoStatBattleNumberAviaSB;
        private double InfoStatKillRespRatioAviaAB;
        private double InfoStatKillRespRatioAviaRB;
        private double InfoStatKillRespRatioAviaSB;

        private string InfoStatFragNumberTankAB;
        private string InfoStatFragNumberTankRB;
        private string InfoStatFragNumberTankSB;
        private string InfoStatBattleNumberTankAB;
        private string InfoStatBattleNumberTankRB;
        private string InfoStatBattleNumberTankSB;
        private double InfoStatKillRespRatioTankAB;
        private double InfoStatKillRespRatioTankRB;
        private double InfoStatKillRespRatioTankSB;

        private string InfoStatFragNumberShipAB;
        private string InfoStatFragNumberShipRB;
        private string InfoStatFragNumberShipSB;
        private string InfoStatBattleNumberShipAB;
        private string InfoStatBattleNumberShipRB;
        private string InfoStatBattleNumberShipSB;
        private double InfoStatKillRespRatioShipAB;
        private double InfoStatKillRespRatioShipRB;
        private double InfoStatKillRespRatioShipSB;

        private string InfoStatUSAVehicle;
        private string InfoStatGermanyVehicle;
        private string InfoStatUSSRVehicle;
        private string InfoStatGBVehicle;
        private string InfoStatJapanVehicle;
        private string InfoStatItalyVehicle;
        private string InfoStatFranceVehicle;

        private string InfoStatRegDate;
        private string InfoStatTotalTime;
        private double InfoStatLionEarned;


        private string BE_ABWinRate;
        private string BE_ABAviaBattleNumber;
        private double BE_ABAviaKB;
        private string BE_ABTankBattleNumber;
        private double BE_ABTankKB;
        private string BE_ABShipBattleNumber;
        private double BE_ABShipKB;
        private string BE_RBWinRate;
        private string BE_RBAviaBattleNumber;
        private double BE_RBAviaKB;
        private string BE_RBTankBattleNumber;
        private double BE_RBTankKB;
        private string BE_RBShipBattleNumber;
        private double BE_RBShipKB;
        private string BE_SBWinRate;
        private string BE_SBAviaBattleNumber;
        private double BE_SBAviaKB;
        private string BE_SBTankBattleNumber;
        private double BE_SBTankKB;
        private string BE_SBShipBattleNumber;
        private double BE_SBShipKB;


        private string InfoStatABLionEarned;
        private string InfoStatLionABEarned_;
        private string InfoStatLionRBEarned_;
        private string InfoStatLionSBEarned_;
        private string InfoStatRBLionEarned;
        private string InfoStatSBLionEarned;

        private double InfoStatTotalGameTimeAB_;
        private double InfoStatTotalGameTimeRB_;
        private double InfoStatTotalGameTimeSB_;

        private double finalBE;

        List<PreferAB> preferABs;
        List<PreferRB> preferRBs;
        List<PreferSB> preferSBs;
        #endregion


        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\
        DrawerLayout drawerLayout;
        private double InfoStatTotalGameTimeAll;
        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\

        public InfoStat()
        {
        }

        protected InfoStat(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.InfoStat);
            context = Application.Context;
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
            var id = "ca-app-pub-8211072909515345~1945501010";
            Android.Gms.Ads.MobileAds.Initialize(context, id);
            var adView = FindViewById<AdView>(Resource.Id.adViewInfoStat);
                 var adRequest = new AdRequest.Builder().Build();
                adView.LoadAd(adRequest);
            //var requestbuilder = new AdRequest.Builder().AddTestDevice("D0BE22F1A4BE27C7470F95A699568FE2");
            //adView.LoadAd(requestbuilder.Build());
            var font = Typeface.CreateFromAsset(Assets, "dinfont.ttf");
            _InfoButtonSearch = FindViewById<ImageButton>(Resource.Id.ButtonSearchInfo);
            _InfoEditTextSearch = FindViewById<AutoCompleteTextView>(Resource.Id.EditTextSearchInfo);
            _InfoButtonSearch.Click += _InfoButtonSearch_Click;
            _InfoEditTextSearch.Click += _InfoEditTextSearch_Click;

            Window.SetSoftInputMode(Android.Views.SoftInput.StateAlwaysHidden);

            #region AutoComplexView

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            ISharedPreferencesEditor editor = prefs.Edit();

            nickName1 = prefs.GetString("key_nickName1", "");
            nickName2 = prefs.GetString("key_nickName2", "");
            nickName3 = prefs.GetString("key_nickName3", "");
            nickName4 = prefs.GetString("key_nickName4", "");
            nickName5 = prefs.GetString("key_nickName5", "");
            nickName6 = prefs.GetString("key_nickName6", "");
            nickName7 = prefs.GetString("key_nickName7", "");
            nickName8 = prefs.GetString("key_nickName8", "");
            nickName9 = prefs.GetString("key_nickName9", "");
            nickName10 = prefs.GetString("key_nickName10", "");

            names = new string[] { nickName1, nickName2, nickName3, nickName4, nickName5, nickName6, nickName7, nickName8, nickName9, nickName10 };
            ArrayAdapter adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, names);
            _InfoEditTextSearch.Adapter = adapter;

            #endregion

            #region Присваивание всех текстовых полей
            _TopHintTextViewInfo = FindViewById<TextView>(Resource.Id.TopHintTextViewInfo);
            InfoParserLoadProgressBar = FindViewById<ContentLoadingProgressBar>(Resource.Id.contentLoadingProgressBarInfo);
            InfoParserLoadProgressBar.Hide();
            _InfoStatImage = FindViewById<ImageView>(Resource.Id.InfoStatImage);
            _InfoStatSquad = FindViewById<TextView>(Resource.Id.TextViewSquadInfo);
            _InfoStatLevel = FindViewById<TextView>(Resource.Id.InfoStatLevel);
            _InfoStatLevelLabel = FindViewById<TextView>(Resource.Id.InfoStatLevelLabel);
            _InfoStatSkillAB = FindViewById<TextView>(Resource.Id.InfoStatSkillAB);
            _InfoStatSkillRB = FindViewById<TextView>(Resource.Id.InfoStatSkillRB);
            _InfoStatSkillSB = FindViewById<TextView>(Resource.Id.InfoStatSkillSB);
            _InfoStatPreferenceAB = FindViewById<TextView>(Resource.Id.InfoStatPriorityAB);
            _InfoStatPreferenceRB = FindViewById<TextView>(Resource.Id.InfoStatPriorityRB);
            _InfoStatPreferenceSB = FindViewById<TextView>(Resource.Id.InfoStatPrioritySB);
            _InfoStatWinRateAB = FindViewById<TextView>(Resource.Id.InfoStatWinRateAB);
            _InfoStatWinRateRB = FindViewById<TextView>(Resource.Id.InfoStatWinRateRB);
            _InfoStatWinRateSB = FindViewById<TextView>(Resource.Id.InfoStatWinRateSB);
            _InfoStatKillRespRatioAviaAB = FindViewById<TextView>(Resource.Id.InfoStatFraqRespRatioAviaAB);
            _InfoStatKillRespRatioAviaRB = FindViewById<TextView>(Resource.Id.InfoStatFraqRespRatioAviaRB);
            _InfoStatKillRespRatioAviaSB = FindViewById<TextView>(Resource.Id.InfoStatFraqRespRatioAviaSB);
            _InfoStatBattleNumberAviaAB = FindViewById<TextView>(Resource.Id.InfoStatBattleNumberAviaAB);
            _InfoStatBattleNumberAviaRB = FindViewById<TextView>(Resource.Id.InfoStatBattleNumberAviaRB);
            _InfoStatBattleNumberAviaSB = FindViewById<TextView>(Resource.Id.InfoStatBattleNumberAviaSB);
            _InfoStatKillRespRatioTankAB = FindViewById<TextView>(Resource.Id.InfoStatFraqRespRatioTankAB);
            _InfoStatKillRespRatioTankRB = FindViewById<TextView>(Resource.Id.InfoStatFraqRespRatioTankRB);
            _InfoStatKillRespRatioTankSB = FindViewById<TextView>(Resource.Id.InfoStatFraqRespRatioTankSB);
            _InfoStatBattleNumberTankAB = FindViewById<TextView>(Resource.Id.InfoStatBattleNumberTankAB);
            _InfoStatBattleNumberTankRB = FindViewById<TextView>(Resource.Id.InfoStatBattleNumberTankRB);
            _InfoStatBattleNumberTankSB = FindViewById<TextView>(Resource.Id.InfoStatBattleNumberTankSB);
            _InfoStatKillRespRatioShipAB = FindViewById<TextView>(Resource.Id.InfoStatFraqRespRatioShipAB);
            _InfoStatKillRespRatioShipRB = FindViewById<TextView>(Resource.Id.InfoStatFraqRespRatioShipRB);
            _InfoStatKillRespRatioShipSB = FindViewById<TextView>(Resource.Id.InfoStatFraqRespRatioShipSB);
            _InfoStatBattleNumberShipAB = FindViewById<TextView>(Resource.Id.InfoStatBattleNumberShipAB);
            _InfoStatBattleNumberShipRB = FindViewById<TextView>(Resource.Id.InfoStatBattleNumberShipRB);
            _InfoStatBattleNumberShipSB = FindViewById<TextView>(Resource.Id.InfoStatBattleNumberShipSB);
            _InfoStatSkillName = FindViewById<TextView>(Resource.Id.InfoStatSkillName);
            _InfoStatUSAVehicle = FindViewById<TextView>(Resource.Id.InfoStatVehicleUSA);
            _InfoStatGermanyVehicle = FindViewById<TextView>(Resource.Id.InfoStatVehicleGermany);
            _InfoStatUSSRVehicle = FindViewById<TextView>(Resource.Id.InfoStatVehicleUSSR);
            _InfoStatGBVehicle = FindViewById<TextView>(Resource.Id.InfoStatVehicleGB);
            _InfoStatJapanVehicle = FindViewById<TextView>(Resource.Id.InfoStatVehicleJapan);
            _InfoStatItalyVehicle = FindViewById<TextView>(Resource.Id.InfoStatVehicleItaly);
            _InfoStatFranceVehicle = FindViewById<TextView>(Resource.Id.InfoStatVehicleFrance);
            _InfoStatRegDate = FindViewById<TextView>(Resource.Id.InfoStatRegData);
            _InfoStatTotalTime = FindViewById<TextView>(Resource.Id.InfoStatTotalTime);
            _InfoStatLionEarned = FindViewById<TextView>(Resource.Id.InfoStatSilverLionEarned);

            _InfoWinRateLabel = FindViewById<TextView>(Resource.Id.InfoStatWinRateLabel);
            _InfoKillRespAviaLabel = FindViewById<TextView>(Resource.Id.InfoStatFraqRespRatioLabelAviaAB);
            _InfoBattleNumberAviaLabel = FindViewById<TextView>(Resource.Id.InfoStatBattleNumberLabelAviaAB);
            _InfoKillRespTankLabel = FindViewById<TextView>(Resource.Id.InfoStatFraqRespRatioLabelTankAB);
            _InfoBattleNumberTankLabel = FindViewById<TextView>(Resource.Id.InfoStatBattleNumberLabelTankAB);
            _InfoKillRespShipLabel = FindViewById<TextView>(Resource.Id.InfoStatFraqRespRatioLabelShipAB);
            _InfoBattleNumberShipLabel = FindViewById<TextView>(Resource.Id.InfoStatBattleNumberLabelShipAB);
            _InfoRegDateLabel = FindViewById<TextView>(Resource.Id.InfoStatRegDataLabel);
            _InfoTotalTimeLabel = FindViewById<TextView>(Resource.Id.InfoStatTotalTimeLabel);
            _InfoLionEarnedLabel = FindViewById<TextView>(Resource.Id.InfoStatSilverLionEarnedLabel);
            _InfoStatPriorityAB = FindViewById<TextView>(Resource.Id.InfoStatPriorityAB);
            _InfoStatPriorityRB = FindViewById<TextView>(Resource.Id.InfoStatPriorityRB);
            _InfoStatPrioritySB = FindViewById<TextView>(Resource.Id.InfoStatPrioritySB);

            _InfoStatFighter = FindViewById<TextView>(Resource.Id.InfoStatFighter);
            _InfoStatAttacker= FindViewById<TextView>(Resource.Id.InfoStatAttacker);
            _InfoStatBomber = FindViewById<TextView>(Resource.Id.InfoStatBomber);
            _InfoStatMiddleTank = FindViewById<TextView>(Resource.Id.InfoStatMiddleTank);
            _InfoStatHeavyTank = FindViewById<TextView>(Resource.Id.InfoStatHeavyTank);
            _InfoStatTankDestroyer = FindViewById<TextView>(Resource.Id.InfoStatTankDestroyer);
            _InfoStatSPAA = FindViewById<TextView>(Resource.Id.InfoStatSPAA);
            _InfoStatBoat = FindViewById<TextView>(Resource.Id.InfoStatBoat);
            _InfoStatBarge = FindViewById<TextView>(Resource.Id.InfoStatBarge);
            _InfoStatSeaHunter = FindViewById<TextView>(Resource.Id.InfoStatSeaHunter);
            _InfoStatShipDestroyer = FindViewById<TextView>(Resource.Id.InfoStatShipDestroyer);
            _InfoStatCruiser = FindViewById<TextView>(Resource.Id.InfoStatCruiser);


            _InfoWinRateLabel.Typeface = font;
            _InfoStatLevelLabel.Typeface = font;
            _InfoKillRespAviaLabel.Typeface = font;
            _InfoBattleNumberAviaLabel.Typeface = font; 
            _InfoKillRespTankLabel.Typeface = font; 
            _InfoBattleNumberTankLabel.Typeface = font; 
            _InfoKillRespShipLabel.Typeface = font; 
            _InfoBattleNumberShipLabel.Typeface = font; 
            _InfoRegDateLabel.Typeface = font; 
            _InfoTotalTimeLabel.Typeface = font; 
            _InfoLionEarnedLabel.Typeface = font;
            _InfoStatPriorityAB.Typeface = font;
            _InfoStatPriorityRB.Typeface = font;
            _InfoStatPrioritySB.Typeface = font;

            _InfoWinRateLabel.SetTextColor(Color.Black);
            _InfoKillRespAviaLabel.SetTextColor(Color.Black);
            _InfoBattleNumberAviaLabel.SetTextColor(Color.Black);
            _InfoKillRespTankLabel.SetTextColor(Color.Black);
            _InfoBattleNumberTankLabel.SetTextColor(Color.Black);
            _InfoKillRespShipLabel.SetTextColor(Color.Black);
            _InfoBattleNumberShipLabel.SetTextColor(Color.Black);
            _InfoRegDateLabel.SetTextColor(Color.Black);
            _InfoTotalTimeLabel.SetTextColor(Color.Black);
            _InfoLionEarnedLabel.SetTextColor(Color.Black);

            #endregion


            //webViewInfoStat

            //   StartActivity(typeof(InDevelop));
            //   Finish();

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

        private void _InfoEditTextSearch_Click(object sender, EventArgs e)
        {
            _InfoEditTextSearch.SetCursorVisible(true);
        }

        private void _InfoButtonSearch_Click(object sender, EventArgs e)
        {
            nickName = _InfoEditTextSearch.Text;
            _InfoEditTextSearch.SetText(nickName, TextView.BufferType.Normal);
            _InfoEditTextSearch.SetCursorVisible(false);

            if (string.IsNullOrEmpty(nickName))
            {
                Toast.MakeText(this, context.Resources.GetString(Resource.String.WriteYourNick), ToastLength.Long).Show();
                EraseAllField();
            }
            else
            if (string.IsNullOrEmpty(nickName))
            {
                Toast.MakeText(this, context.Resources.GetString(Resource.String.WriteOtherNick), ToastLength.Long).Show();
                EraseAllField();
            }
            else
            {
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
                ISharedPreferencesEditor editor = prefs.Edit();


                string isExist = _InfoEditTextSearch.Text;
                if (names.Contains(isExist))
                    {
                      
                    }
                else
                {
                    nickName10 = nickName9;
                    nickName9 = nickName8;
                    nickName8 = nickName7;
                    nickName7 = nickName6;
                    nickName6 = nickName5;
                    nickName5 = nickName4;
                    nickName4 = nickName3;
                    nickName3 = nickName2;
                    nickName2 = nickName1;
                    nickName1 = _InfoEditTextSearch.Text;

                    editor.PutString("key_nickName1", nickName1);
                    editor.PutString("key_nickName2", nickName2);
                    editor.PutString("key_nickName3", nickName3);
                    editor.PutString("key_nickName4", nickName4);
                    editor.PutString("key_nickName5", nickName5);
                    editor.PutString("key_nickName6", nickName6);
                    editor.PutString("key_nickName7", nickName7);
                    editor.PutString("key_nickName8", nickName8);
                    editor.PutString("key_nickName9", nickName9);
                    editor.PutString("key_nickName10", nickName10);
                    editor.Apply();
                }
                
                names = new string[] { nickName1, nickName2, nickName3, nickName4, nickName5, nickName6, nickName7, nickName8, nickName9, nickName10 };

                ArrayAdapter adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, names);
                _InfoEditTextSearch.Adapter = adapter;

                _InfoEditTextSearch.DismissDropDown();
                NickParser();
            }
        }

  
        #region Переводчик при парсиге
        static string ParseTranslator(string s)
        {
            var sb = new StringBuilder(s);
            foreach (var kvp in Replacements)
                sb.Replace(kvp.Key, kvp.Value);
            return sb.ToString();
        }



        static readonly Dictionary<string, string> Replacements = new Dictionary<string, string>()
        {

            ["мин"] = "min",
            ["м"] = "m",
            ["ч"] = "h",
            ["д"] = "d",
        };
        #endregion
        ///////////////////////////////////////
        

        private void EraseAllField()
        {
             _InfoStatImage.SetImageResource(Resource.Drawable._transparentPlane);
            _InfoStatSquad.SetText("", TextView.BufferType.Normal);
            _InfoStatLevel.SetText("", TextView.BufferType.Normal);
            _InfoStatSkillAB.SetText("", TextView.BufferType.Normal);
            _InfoStatSkillRB.SetText("", TextView.BufferType.Normal);
            _InfoStatSkillSB.SetText("", TextView.BufferType.Normal);
            _InfoStatPreferenceAB.SetText("", TextView.BufferType.Normal);
            _InfoStatPreferenceRB.SetText("", TextView.BufferType.Normal);
            _InfoStatPreferenceSB.SetText("", TextView.BufferType.Normal);
            _InfoStatWinRateAB.SetText("", TextView.BufferType.Normal);
            _InfoStatWinRateRB.SetText("", TextView.BufferType.Normal);
            _InfoStatWinRateSB.SetText("", TextView.BufferType.Normal);
            _InfoStatKillRespRatioAviaAB.SetText("", TextView.BufferType.Normal);
            _InfoStatKillRespRatioAviaRB.SetText("", TextView.BufferType.Normal);
            _InfoStatKillRespRatioAviaSB.SetText("", TextView.BufferType.Normal);
            _InfoStatBattleNumberAviaAB.SetText("", TextView.BufferType.Normal);
            _InfoStatBattleNumberAviaRB.SetText("", TextView.BufferType.Normal);
            _InfoStatBattleNumberAviaSB.SetText("", TextView.BufferType.Normal);
            _InfoStatKillRespRatioTankAB.SetText("", TextView.BufferType.Normal);
            _InfoStatKillRespRatioTankRB.SetText("", TextView.BufferType.Normal);
            _InfoStatKillRespRatioTankSB.SetText("", TextView.BufferType.Normal);
            _InfoStatBattleNumberTankAB.SetText("", TextView.BufferType.Normal);
            _InfoStatBattleNumberTankRB.SetText("", TextView.BufferType.Normal);
            _InfoStatBattleNumberTankSB.SetText("", TextView.BufferType.Normal);
            _InfoStatKillRespRatioShipAB.SetText("", TextView.BufferType.Normal);
            _InfoStatKillRespRatioShipRB.SetText("", TextView.BufferType.Normal);
            _InfoStatKillRespRatioShipSB.SetText("", TextView.BufferType.Normal);
            _InfoStatBattleNumberShipAB.SetText("", TextView.BufferType.Normal);
            _InfoStatBattleNumberShipRB.SetText("", TextView.BufferType.Normal);
            _InfoStatBattleNumberShipSB.SetText("", TextView.BufferType.Normal);
            _InfoStatUSAVehicle.SetText("", TextView.BufferType.Normal);
            _InfoStatGermanyVehicle.SetText("", TextView.BufferType.Normal);
            _InfoStatUSSRVehicle.SetText("", TextView.BufferType.Normal);
            _InfoStatGBVehicle.SetText("", TextView.BufferType.Normal);
            _InfoStatJapanVehicle.SetText("", TextView.BufferType.Normal);
            _InfoStatItalyVehicle.SetText("", TextView.BufferType.Normal);
            _InfoStatFranceVehicle.SetText("", TextView.BufferType.Normal);
            _InfoStatRegDate.SetText("", TextView.BufferType.Normal);
            _InfoStatTotalTime.SetText("", TextView.BufferType.Normal);
            _InfoStatLionEarned.SetText("", TextView.BufferType.Normal);
            _InfoStatFighter.SetText("", TextView.BufferType.Normal);
            _InfoStatAttacker.SetText("", TextView.BufferType.Normal);
            _InfoStatBomber.SetText("", TextView.BufferType.Normal);
            _InfoStatMiddleTank.SetText("", TextView.BufferType.Normal);
            _InfoStatHeavyTank.SetText("", TextView.BufferType.Normal);
            _InfoStatTankDestroyer.SetText("", TextView.BufferType.Normal);
            _InfoStatSPAA.SetText("", TextView.BufferType.Normal);
            _InfoStatBoat.SetText("", TextView.BufferType.Normal);
            _InfoStatBarge.SetText("", TextView.BufferType.Normal);
            _InfoStatSeaHunter.SetText("", TextView.BufferType.Normal);
            _InfoStatShipDestroyer.SetText("", TextView.BufferType.Normal);
            _InfoStatCruiser.SetText("", TextView.BufferType.Normal);
            _InfoStatSkillName.SetText("", TextView.BufferType.Normal);
            _InfoStatSkillName.SetBackgroundColor(Color.Transparent);

        }

        private async System.Threading.Tasks.Task NickParser()
        {
            EraseAllField();
            var inputManager = (InputMethodManager)GetSystemService(InputMethodService); //скрытие клавиатуры
            inputManager.HideSoftInputFromWindow(_InfoButtonSearch.WindowToken, HideSoftInputFlags.None); //скрытие клавиатуры
            Regex regexOnlyNumbers = new Regex(@"[\D]");
            Regex regexOnlyNumbersWithDots = new Regex(@"[А-Яа-я\s]");
            string regexMounth = @"^[0-9]{1,2}.{1,}м$";
            string regexDayAndHour = @"^[0-9]{1,2}д\s[0-9]{1,2}ч$";
            string regexHourAndMin = @"^[0-9]{1,2}ч\s[0-9]{1,2}мин$";
            //Регулярки
            InfoParserLoadProgressBar.Show();

            #region Обхід Cloudflare

            try
            {
                ClearanceHandler handler = new ClearanceHandler
                {
                    MaxRetries = 2 
                };
                HttpClient client = new HttpClient(handler);
                string source = await client.GetStringAsync("https://warthunder.ru/ru/community/userinfo/?nick=" + nickName);
                var parser = new HtmlParser();
                document = parser.ParseDocument(source);
            }
            catch (AggregateException ex) when (ex.InnerException is CloudFlareClearanceException)
            {
            }
            catch (AggregateException ex) when (ex.InnerException is TaskCanceledException)
            {
            }
            #endregion


            try
            {
                #region Основная инфа
                #region Полк
                string InfoStatSquad_;
                var InfoStatSquad = document.All.FirstOrDefault(m =>
  m.LocalName == "a" &&
  m.HasAttribute("class") &&
  m.GetAttribute("class").Contains("user-profile__data-link")
  );

                if (InfoStatSquad != null)
                {
                    InfoStatSquad_ = document.All.FirstOrDefault(m =>
m.LocalName == "a" &&
m.HasAttribute("class") &&
 m.GetAttribute("class").Contains("user-profile__data-link")).TextContent.ToString();
                    _InfoStatSquad.SetText(InfoStatSquad_.ToString(), TextView.BufferType.Normal);

                }
                else
                {
                    InfoStatSquad_ = "";
                }
                #endregion

                #region Уровень
                var InfoStatLevel_ = document.All.Where(m =>
    m.LocalName == "li" &&
    m.HasAttribute("class") &&
    m.GetAttribute("class").Contains("user-profile__data-item")
    ).Last().TextContent.ToString();
                InfoStatLevel = regexOnlyNumbers.Replace(InfoStatLevel_, "");
                _InfoStatLevel.SetText(InfoStatLevel, TextView.BufferType.Normal);

                #endregion

                #region Дата регистрации
                var InfoStatRegDate_ = document.All.Where(m =>
                       m.LocalName == "li" &&
                       m.HasAttribute("class") &&
                       m.GetAttribute("class").Contains("user-profile__data-regdate")
                        ).ElementAt(0).TextContent.ToString();
                InfoStatRegDate = regexOnlyNumbersWithDots.Replace(InfoStatRegDate_, "");
                _InfoStatRegDate.SetText(InfoStatRegDate, TextView.BufferType.Normal);
                #endregion

                #region Процент побед АБ
                InfoStatWinRateAB = document.All.Where(m =>
        m.LocalName == "li" &&
        m.HasAttribute("class") &&
        m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(13).TextContent.ToString();
                if (InfoStatWinRateAB == "N/A")
                {
                    InfoStatWinRateAB = "0%";
                }
                BE_ABWinRate = InfoStatWinRateAB;
                _InfoStatWinRateAB.SetText(InfoStatWinRateAB, TextView.BufferType.Normal);
                #endregion

                #region Соотношение фраг/бой, количество вылетов и время игры. Авиа. АБ
                InfoStatFragNumberAviaAB = document.All.Where(m =>
       m.LocalName == "li" &&
       m.HasAttribute("class") &&
       m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(63).TextContent.ToString();

                InfoStatBattleNumberAviaAB = document.All.Where(m =>
      m.LocalName == "li" &&
      m.HasAttribute("class") &&
      m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(54).TextContent.ToString();
                try
                {
                    var InfoStatFragNumberAviaABInt = Convert.ToDouble(InfoStatFragNumberAviaAB);
                    var InfoStatBattleNumberAviaABInt = Convert.ToDouble(InfoStatBattleNumberAviaAB);
                    InfoStatKillRespRatioAviaAB = InfoStatFragNumberAviaABInt / InfoStatBattleNumberAviaABInt;
                    InfoStatKillRespRatioAviaAB = Math.Round(InfoStatKillRespRatioAviaAB, 2);
                }
                catch (FormatException)
                {
                    InfoStatKillRespRatioAviaAB = 0;
                    InfoStatBattleNumberAviaAB = "0";
                }
                _InfoStatKillRespRatioAviaAB.SetText(InfoStatKillRespRatioAviaAB.ToString(), TextView.BufferType.Normal);
                _InfoStatBattleNumberAviaAB.SetText(InfoStatBattleNumberAviaAB, TextView.BufferType.Normal);

                #endregion

                #region Соотношение фраг/бой, количество вылетов и время игры. Танки. АБ
                InfoStatFragNumberTankAB = document.All.Where(m =>
       m.LocalName == "li" &&
       m.HasAttribute("class") &&
       m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(120).TextContent.ToString();

                InfoStatBattleNumberTankAB = document.All.Where(m =>
      m.LocalName == "li" &&
      m.HasAttribute("class") &&
      m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(108).TextContent.ToString();
                try
                {
                    var InfoStatFragNumberTankABInt = Convert.ToDouble(InfoStatFragNumberTankAB);
                    var InfoStatBattleNumberTankABInt = Convert.ToDouble(InfoStatBattleNumberTankAB);
                    InfoStatKillRespRatioTankAB = InfoStatFragNumberTankABInt / InfoStatBattleNumberTankABInt;
                    InfoStatKillRespRatioTankAB = Math.Round(InfoStatKillRespRatioTankAB, 2);
                }
                catch (FormatException)
                {
                    InfoStatKillRespRatioTankAB = 0;
                    InfoStatBattleNumberTankAB = "0";
                }
                _InfoStatKillRespRatioTankAB.SetText(InfoStatKillRespRatioTankAB.ToString(), TextView.BufferType.Normal);
                _InfoStatBattleNumberTankAB.SetText(InfoStatBattleNumberTankAB, TextView.BufferType.Normal);

                #endregion

                #region Соотношение фраг/бой, количество вылетов и время игры. Флот. АБ
                InfoStatFragNumberShipAB = document.All.Where(m =>
       m.LocalName == "li" &&
       m.HasAttribute("class") &&
       m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(193).TextContent.ToString();

                InfoStatBattleNumberShipAB = document.All.Where(m =>
      m.LocalName == "li" &&
      m.HasAttribute("class") &&
      m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(174).TextContent.ToString();
                try
                {
                    var InfoStatFragNumberShipABInt = Convert.ToDouble(InfoStatFragNumberShipAB);
                    var InfoStatBattleNumberShipABInt = Convert.ToDouble(InfoStatBattleNumberShipAB);
                    InfoStatKillRespRatioShipAB = InfoStatFragNumberShipABInt / InfoStatBattleNumberShipABInt;
                    InfoStatKillRespRatioShipAB = Math.Round(InfoStatKillRespRatioShipAB, 2);
                }
                catch (FormatException)
                {
                    InfoStatKillRespRatioShipAB = 0;
                    InfoStatBattleNumberShipAB = "0";
                }
                _InfoStatKillRespRatioShipAB.SetText(InfoStatKillRespRatioShipAB.ToString(), TextView.BufferType.Normal);
                _InfoStatBattleNumberShipAB.SetText(InfoStatBattleNumberShipAB, TextView.BufferType.Normal);

                #endregion

                #region Процент побед РБ
                InfoStatWinRateRB = document.All.Where(m =>
        m.LocalName == "li" &&
        m.HasAttribute("class") &&
        m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(23).TextContent.ToString();
                if (InfoStatWinRateRB == "N/A")
                {
                    InfoStatWinRateRB = "0%";
                }
                BE_RBWinRate = InfoStatWinRateRB;
                _InfoStatWinRateRB.SetText(InfoStatWinRateRB, TextView.BufferType.Normal);
                #endregion

                #region Соотношение фраг/бой, количество вылетов и время игры. Авиа. РБ
                InfoStatFragNumberAviaRB = document.All.Where(m =>
       m.LocalName == "li" &&
       m.HasAttribute("class") &&
       m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(76).TextContent.ToString();

                InfoStatBattleNumberAviaRB = document.All.Where(m =>
      m.LocalName == "li" &&
      m.HasAttribute("class") &&
      m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(67).TextContent.ToString();
                try
                {
                    var InfoStatFragNumberAviaRBInt = Convert.ToDouble(InfoStatFragNumberAviaRB);
                    var InfoStatBattleNumberAviaRBInt = Convert.ToDouble(InfoStatBattleNumberAviaRB);
                    InfoStatKillRespRatioAviaRB = InfoStatFragNumberAviaRBInt / InfoStatBattleNumberAviaRBInt;
                    InfoStatKillRespRatioAviaRB = Math.Round(InfoStatKillRespRatioAviaRB, 2);
                }
                catch (FormatException)
                {
                    InfoStatKillRespRatioAviaRB = 0;
                    InfoStatBattleNumberAviaRB = "0";
                }
                _InfoStatKillRespRatioAviaRB.SetText(InfoStatKillRespRatioAviaRB.ToString(), TextView.BufferType.Normal);
                _InfoStatBattleNumberAviaRB.SetText(InfoStatBattleNumberAviaRB, TextView.BufferType.Normal);

                #endregion

                #region Соотношение фраг/бой, количество вылетов и время игры. Танки. РБ
                InfoStatFragNumberTankRB = document.All.Where(m =>
       m.LocalName == "li" &&
       m.HasAttribute("class") &&
       m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(135).TextContent.ToString();

                InfoStatBattleNumberTankRB = document.All.Where(m =>
      m.LocalName == "li" &&
      m.HasAttribute("class") &&
      m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(123).TextContent.ToString();
                try
                {
                    var InfoStatFragNumberTankRBInt = Convert.ToDouble(InfoStatFragNumberTankRB);
                    var InfoStatBattleNumberTankRBInt = Convert.ToDouble(InfoStatBattleNumberTankRB);
                    InfoStatKillRespRatioTankRB = InfoStatFragNumberTankRBInt / InfoStatBattleNumberTankRBInt;
                    InfoStatKillRespRatioTankRB = Math.Round(InfoStatKillRespRatioTankRB, 2);
                }
                catch (FormatException)
                {
                    InfoStatKillRespRatioTankRB = 0;
                    InfoStatBattleNumberTankRB = "0";
                }
                _InfoStatKillRespRatioTankRB.SetText(InfoStatKillRespRatioTankRB.ToString(), TextView.BufferType.Normal);
                _InfoStatBattleNumberTankRB.SetText(InfoStatBattleNumberTankRB, TextView.BufferType.Normal);

                #endregion

                #region Соотношение фраг/бой, количество вылетов и время игры. Флот. РБ
                InfoStatFragNumberShipRB = document.All.Where(m =>
       m.LocalName == "li" &&
       m.HasAttribute("class") &&
       m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(214).TextContent.ToString();

                InfoStatBattleNumberShipRB = document.All.Where(m =>
      m.LocalName == "li" &&
      m.HasAttribute("class") &&
      m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(195).TextContent.ToString();
                try
                {
                    var InfoStatFragNumberShipRBInt = Convert.ToDouble(InfoStatFragNumberShipRB);
                    var InfoStatBattleNumberShipRBInt = Convert.ToDouble(InfoStatBattleNumberShipRB);
                    InfoStatKillRespRatioShipRB = InfoStatFragNumberShipRBInt / InfoStatBattleNumberShipRBInt;
                    InfoStatKillRespRatioShipRB = Math.Round(InfoStatKillRespRatioShipRB, 2);
                }
                catch (FormatException)
                {
                    InfoStatKillRespRatioShipRB = 0;
                    InfoStatBattleNumberShipRB = "0";
                }
                _InfoStatKillRespRatioShipRB.SetText(InfoStatKillRespRatioShipRB.ToString(), TextView.BufferType.Normal);
                _InfoStatBattleNumberShipRB.SetText(InfoStatBattleNumberShipRB, TextView.BufferType.Normal);

                #endregion

                #region Процент побед СБ
                InfoStatWinRateSB = document.All.Where(m =>
        m.LocalName == "li" &&
        m.HasAttribute("class") &&
        m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(33).TextContent.ToString();
                if (InfoStatWinRateSB == "N/A")
                {
                    InfoStatWinRateSB = "0%";
                }
                BE_SBWinRate = InfoStatWinRateSB;
                _InfoStatWinRateSB.SetText(InfoStatWinRateSB, TextView.BufferType.Normal);
                #endregion

                #region Соотношение фраг/бой, количество вылетов и время игры. Авиа. СБ
                InfoStatFragNumberAviaSB = document.All.Where(m =>
       m.LocalName == "li" &&
       m.HasAttribute("class") &&
       m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(89).TextContent.ToString();

                InfoStatBattleNumberAviaSB = document.All.Where(m =>
      m.LocalName == "li" &&
      m.HasAttribute("class") &&
      m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(80).TextContent.ToString();
                try
                {
                    var InfoStatFragNumberAviaSBInt = Convert.ToDouble(InfoStatFragNumberAviaSB);
                    var InfoStatBattleNumberAviaSBInt = Convert.ToDouble(InfoStatBattleNumberAviaSB);
                    InfoStatKillRespRatioAviaSB = InfoStatFragNumberAviaSBInt / InfoStatBattleNumberAviaSBInt;
                    InfoStatKillRespRatioAviaSB = Math.Round(InfoStatKillRespRatioAviaSB, 2);
                }
                catch (FormatException)
                {
                    InfoStatKillRespRatioAviaSB = 0;
                    InfoStatBattleNumberAviaSB = "0";
                }
                _InfoStatKillRespRatioAviaSB.SetText(InfoStatKillRespRatioAviaSB.ToString(), TextView.BufferType.Normal);
                _InfoStatBattleNumberAviaSB.SetText(InfoStatBattleNumberAviaSB, TextView.BufferType.Normal);

                #endregion

                #region Соотношение фраг/бой, количество вылетов и время игры. Танки. СБ
                InfoStatFragNumberTankSB = document.All.Where(m =>
       m.LocalName == "li" &&
       m.HasAttribute("class") &&
       m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(150).TextContent.ToString();

                InfoStatBattleNumberTankSB = document.All.Where(m =>
      m.LocalName == "li" &&
      m.HasAttribute("class") &&
      m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(138).TextContent.ToString();
                try
                {
                    var InfoStatFragNumberTankSBInt = Convert.ToDouble(InfoStatFragNumberTankSB);
                    var InfoStatBattleNumberTankSBInt = Convert.ToDouble(InfoStatBattleNumberTankSB);
                    InfoStatKillRespRatioTankSB = InfoStatFragNumberTankSBInt / InfoStatBattleNumberTankSBInt;
                    InfoStatKillRespRatioTankSB = Math.Round(InfoStatKillRespRatioTankSB, 2);
                }
                catch (FormatException)
                {
                    InfoStatKillRespRatioTankSB = 0;
                    InfoStatBattleNumberTankSB = "0";
                }
                _InfoStatKillRespRatioTankSB.SetText(InfoStatKillRespRatioTankSB.ToString(), TextView.BufferType.Normal);
                _InfoStatBattleNumberTankSB.SetText(InfoStatBattleNumberTankSB, TextView.BufferType.Normal);

                #endregion

                #region Соотношение фраг/бой, количество вылетов и время игры. Флот. СБ
                InfoStatFragNumberShipSB = document.All.Where(m =>
       m.LocalName == "li" &&
       m.HasAttribute("class") &&
       m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(235).TextContent.ToString();

                InfoStatBattleNumberShipSB = document.All.Where(m =>
      m.LocalName == "li" &&
      m.HasAttribute("class") &&
      m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(216).TextContent.ToString();
                try
                {
                    var InfoStatFragNumberShipSBInt = Convert.ToDouble(InfoStatFragNumberShipSB);
                    var InfoStatBattleNumberShipSBInt = Convert.ToDouble(InfoStatBattleNumberShipSB);
                    InfoStatKillRespRatioShipSB = InfoStatFragNumberShipSBInt / InfoStatBattleNumberShipSBInt;
                    InfoStatKillRespRatioShipSB = Math.Round(InfoStatKillRespRatioShipSB, 2);
                }
                catch (FormatException)
                {
                    InfoStatKillRespRatioShipSB = 0;
                    InfoStatBattleNumberShipSB = "0";
                }
                _InfoStatKillRespRatioShipSB.SetText(InfoStatKillRespRatioShipSB.ToString(), TextView.BufferType.Normal);
                _InfoStatBattleNumberShipSB.SetText(InfoStatBattleNumberShipSB, TextView.BufferType.Normal);

                #endregion

                #region Техника 
                InfoStatUSAVehicle = document.All.Where(m =>
    m.LocalName == "li" &&
    m.HasAttribute("class") &&
    m.GetAttribute("class").Contains("profile-score__list-item")
   ).ElementAt(9).TextContent.ToString();
                _InfoStatUSAVehicle.SetText(InfoStatUSAVehicle, TextView.BufferType.Normal);

                InfoStatGermanyVehicle = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-score__list-item")
).ElementAt(12).TextContent.ToString();
                _InfoStatGermanyVehicle.SetText(InfoStatGermanyVehicle, TextView.BufferType.Normal);

                InfoStatUSSRVehicle = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-score__list-item")
).ElementAt(10).TextContent.ToString();
                _InfoStatUSSRVehicle.SetText(InfoStatUSSRVehicle, TextView.BufferType.Normal);

                InfoStatGBVehicle = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-score__list-item")
).ElementAt(11).TextContent.ToString();
                _InfoStatGBVehicle.SetText(InfoStatGBVehicle, TextView.BufferType.Normal);

                InfoStatJapanVehicle = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-score__list-item")
).ElementAt(13).TextContent.ToString();
                _InfoStatJapanVehicle.SetText(InfoStatJapanVehicle, TextView.BufferType.Normal);

                InfoStatItalyVehicle = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-score__list-item")
).ElementAt(14).TextContent.ToString();
                _InfoStatItalyVehicle.SetText(InfoStatItalyVehicle, TextView.BufferType.Normal);

                InfoStatFranceVehicle = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-score__list-item")
).ElementAt(15).TextContent.ToString();
                _InfoStatFranceVehicle.SetText(InfoStatFranceVehicle, TextView.BufferType.Normal);

                #endregion

                #region Серебро
                InfoStatLionABEarned_ = document.All.Where(m =>
    m.LocalName == "li" &&
    m.HasAttribute("class") &&
    m.GetAttribute("class").Contains("profile-stat__list-item")
    ).ElementAt(15).TextContent.ToString();
                if (InfoStatLionABEarned_ == "N/A")
                {
                    InfoStatABLionEarned = "0";
                }
                else
                {
                    InfoStatABLionEarned = regexOnlyNumbers.Replace(InfoStatLionABEarned_, "");
                }
                InfoStatLionRBEarned_ = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(25).TextContent.ToString();
                if (InfoStatLionRBEarned_ == "N/A")
                {
                    InfoStatRBLionEarned = "0";
                }
                else
                {
                    InfoStatRBLionEarned = regexOnlyNumbers.Replace(InfoStatLionRBEarned_, "");
                }
                InfoStatLionSBEarned_ = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(35).TextContent.ToString();
                if (InfoStatLionSBEarned_ == "N/A")
                {
                    InfoStatSBLionEarned = "0";
                }
                else
                {
                    InfoStatSBLionEarned = regexOnlyNumbers.Replace(InfoStatLionSBEarned_, "");
                }

                try
                {
                    var InfoStatABLionEarnedInt = Convert.ToDouble(InfoStatABLionEarned);
                    var InfoStatRBLionEarnedInt = Convert.ToDouble(InfoStatRBLionEarned);
                    var InfoStatSBLionEarnedInt = Convert.ToDouble(InfoStatSBLionEarned);
                    InfoStatLionEarned = InfoStatABLionEarnedInt + InfoStatRBLionEarnedInt + InfoStatSBLionEarnedInt;

                    _InfoStatLionEarned.SetText(InfoStatLionEarned.ToString("N0"), TextView.BufferType.Normal);
                }
                catch (FormatException)
                {
                    _InfoStatLionEarned.SetText("0", TextView.BufferType.Normal);
                }

                #endregion

                #region Общее время

                var InfoStatTotalGameTimeAB = document.All.Where(m =>
    m.LocalName == "li" &&
    m.HasAttribute("class") &&
    m.GetAttribute("class").Contains("profile-stat__list-item")
   ).ElementAt(16).TextContent.ToString();

                var InfoStatTotalGameTimeRB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(26).TextContent.ToString();

                var InfoStatTotalGameTimeSB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(36).TextContent.ToString();

                #region Конвертер времени со статистики в часы. АБ
                Match matchMounthABLeft = Regex.Match(InfoStatTotalGameTimeAB, regexMounth, RegexOptions.IgnoreCase);
                Match matchDayAndHoursABLeft = Regex.Match(InfoStatTotalGameTimeAB, regexDayAndHour, RegexOptions.IgnoreCase);
                Match matchHoursAndMinutesABLeft = Regex.Match(InfoStatTotalGameTimeAB, regexHourAndMin, RegexOptions.IgnoreCase);

                if (matchMounthABLeft.Success)
                {
                    string totalTime_ = regexOnlyNumbersWithDots.Replace(InfoStatTotalGameTimeAB, "");
                    CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    var totalTime = Convert.ToDouble(totalTime_);
                    Thread.CurrentThread.CurrentCulture = temp_culture;
                    InfoStatTotalGameTimeAB_ = totalTime * 720;
                }
                else
              if (matchDayAndHoursABLeft.Success)
                {
                    var time = TimeSpan.ParseExact(InfoStatTotalGameTimeAB, "d'д 'h'ч'", null);
                    InfoStatTotalGameTimeAB_ = time.TotalHours;
                }
                else
              if (matchHoursAndMinutesABLeft.Success)
                {
                    var time = TimeSpan.ParseExact(InfoStatTotalGameTimeAB, "h'ч 'm'мин'", null);
                    InfoStatTotalGameTimeAB_ = time.TotalHours;
                }
                #endregion


                #region Конвертер времени со статистики в часы. РБ
                Match matchMounthRBLeft = Regex.Match(InfoStatTotalGameTimeRB, regexMounth, RegexOptions.IgnoreCase);
                Match matchDayAndHoursRBLeft = Regex.Match(InfoStatTotalGameTimeRB, regexDayAndHour, RegexOptions.IgnoreCase);
                Match matchHoursAndMinutesRBLeft = Regex.Match(InfoStatTotalGameTimeRB, regexHourAndMin, RegexOptions.IgnoreCase);

                if (matchMounthRBLeft.Success)
                {
                    string totalTime_ = regexOnlyNumbersWithDots.Replace(InfoStatTotalGameTimeRB, "");
                    CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    var totalTime = Convert.ToDouble(totalTime_);
                    Thread.CurrentThread.CurrentCulture = temp_culture;
                    InfoStatTotalGameTimeRB_ = totalTime * 720;
                }
                else
              if (matchDayAndHoursRBLeft.Success)
                {
                    var time = TimeSpan.ParseExact(InfoStatTotalGameTimeRB, "d'д 'h'ч'", null);
                    InfoStatTotalGameTimeRB_ = time.TotalHours;
                }
                else
              if (matchHoursAndMinutesRBLeft.Success)
                {
                    var time = TimeSpan.ParseExact(InfoStatTotalGameTimeRB, "h'ч 'm'мин'", null);
                    InfoStatTotalGameTimeRB_ = time.TotalHours;
                }
                #endregion


                #region Конвертер времени со статистики в часы. СБ
                Match matchMounthSBLeft = Regex.Match(InfoStatTotalGameTimeSB, regexMounth, RegexOptions.IgnoreCase);
                Match matchDayAndHoursSBLeft = Regex.Match(InfoStatTotalGameTimeSB, regexDayAndHour, RegexOptions.IgnoreCase);
                Match matchHoursAndMinutesSBLeft = Regex.Match(InfoStatTotalGameTimeSB, regexHourAndMin, RegexOptions.IgnoreCase);

                if (matchMounthSBLeft.Success)
                {
                    string totalTime_ = regexOnlyNumbersWithDots.Replace(InfoStatTotalGameTimeSB, "");
                    CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    var totalTime = Convert.ToDouble(totalTime_);
                    Thread.CurrentThread.CurrentCulture = temp_culture;
                    InfoStatTotalGameTimeSB_ = totalTime * 720;
                }
                else
              if (matchDayAndHoursSBLeft.Success)
                {
                    var time = TimeSpan.ParseExact(InfoStatTotalGameTimeSB, "d'д 'h'ч'", null);
                    InfoStatTotalGameTimeSB_ = time.TotalHours;
                }
                else
              if (matchHoursAndMinutesSBLeft.Success)
                {
                    var time = TimeSpan.ParseExact(InfoStatTotalGameTimeSB, "h'ч 'm'мин'", null);
                    InfoStatTotalGameTimeSB_ = time.TotalHours;
                }
                #endregion

                InfoStatTotalGameTimeAll = InfoStatTotalGameTimeAB_ + InfoStatTotalGameTimeRB_ + InfoStatTotalGameTimeSB_;
                var FullGameTimeDays = InfoStatTotalGameTimeAll / 24;
                FullGameTimeDays = Math.Round(FullGameTimeDays, 0);
                _InfoStatTotalTime.SetText(FullGameTimeDays.ToString() + " " + context.Resources.GetString(Resource.String.StatDay), TextView.BufferType.Normal);


                #endregion

                #endregion

                InfoParserLoadProgressBar.Hide();

                _InfoStatSkillName.SetBackgroundColor(Color.ParseColor("#50000000"));


                #region Боевая эффективность
                var BE_ABAviaBattleNumber_ = Convert.ToDouble(InfoStatBattleNumberAviaAB);
                var BE_ABTankBattleNumber_ = Convert.ToDouble(InfoStatBattleNumberTankAB);
                var BE_ABShipBattleNumber_ = Convert.ToDouble(InfoStatBattleNumberShipAB);
                var BE_RBAviaBattleNumber_ = Convert.ToDouble(InfoStatBattleNumberAviaRB);
                var BE_RBTankBattleNumber_ = Convert.ToDouble(InfoStatBattleNumberTankRB);
                var BE_RBShipBattleNumber_ = Convert.ToDouble(InfoStatBattleNumberShipRB);
                var BE_SBAviaBattleNumber_ = Convert.ToDouble(InfoStatBattleNumberAviaSB);
                var BE_SBTankBattleNumber_ = Convert.ToDouble(InfoStatBattleNumberTankSB);
                var BE_SBShipBattleNumber_ = Convert.ToDouble(InfoStatBattleNumberShipSB);


                #region Общая
                List<BEList> BELists = new List<BEList>();
                if (BE_ABAviaBattleNumber_ >= 100)
                {
                    BELists.Add(new BEList()
                    {
                        KB = InfoStatKillRespRatioAviaAB
                    });
                }
                if (BE_ABTankBattleNumber_ >= 100)
                {
                    BELists.Add(new BEList()
                    {
                        KB = InfoStatKillRespRatioTankAB
                    });
                }
                if (BE_ABShipBattleNumber_ >= 100)
                {
                    BELists.Add(new BEList()
                    {
                        KB = InfoStatKillRespRatioShipAB
                    });
                }
                if (BE_RBAviaBattleNumber_ >= 100)
                {
                    BELists.Add(new BEList()
                    {
                        KB = InfoStatKillRespRatioAviaRB
                    });
                }
                if (BE_RBTankBattleNumber_ >= 100)
                {
                    BELists.Add(new BEList()
                    {
                        KB = InfoStatKillRespRatioTankRB
                    });
                }
                if (BE_RBShipBattleNumber_ >= 100)
                {
                    BELists.Add(new BEList()
                    {
                        KB = InfoStatKillRespRatioShipRB
                    });
                }
                if (BE_SBAviaBattleNumber_ >= 100)
                {
                    BELists.Add(new BEList()
                    {
                        KB = InfoStatKillRespRatioAviaSB
                    });
                }
                if (BE_SBTankBattleNumber_ >= 100)
                {
                    BELists.Add(new BEList()
                    {
                        KB = InfoStatKillRespRatioTankSB
                    });
                }
                if (BE_SBShipBattleNumber_ >= 100)
                {
                    BELists.Add(new BEList()
                    {
                        KB = InfoStatKillRespRatioShipSB
                    });
                }
                if (BELists.Count == 0)
                {
                    finalBE = 0;
                }
                else
                {
                    double finalBEList = BELists.Average(x => x.KB);
                    finalBE = finalBEList * 100;
                    finalBE = Math.Round(finalBE, 0);

                }
                #endregion

                #region АБ 
                List<BEListAB> BE_ABLists = new List<BEListAB>();
                if (BE_ABAviaBattleNumber_ >= 100)
                {
                    BE_ABLists.Add(new BEListAB()
                    {
                        KB_AB = InfoStatKillRespRatioAviaAB
                    });
                }
                if (BE_ABTankBattleNumber_ >= 100)
                {
                    BE_ABLists.Add(new BEListAB()
                    {
                        KB_AB = InfoStatKillRespRatioTankAB
                    });
                }
                if (BE_ABShipBattleNumber_ >= 100)
                {
                    BE_ABLists.Add(new BEListAB()
                    {
                        KB_AB = InfoStatKillRespRatioShipAB
                    });
                }
                //////////////
                if (BE_ABLists.Count == 0)
                {

                    _InfoStatSkillAB.SetText("0".ToString() + "%", TextView.BufferType.Normal);
                }
                else
                {
                    double AB_BEList = BE_ABLists.Average(x => x.KB_AB);
                    double AB_BE100 = AB_BEList * 100;
                    AB_BE100 = Math.Round(AB_BE100, 0);
                    _InfoStatSkillAB.SetText(AB_BE100.ToString() + "%", TextView.BufferType.Normal);
                }
                /////////////////
                #endregion

                #region РБ
                List<BEListRB> BE_RBLists = new List<BEListRB>();
                if (BE_RBAviaBattleNumber_ >= 100)
                {
                    BE_RBLists.Add(new BEListRB()
                    {
                        KB_RB = InfoStatKillRespRatioAviaRB
                    });
                }
                if (BE_RBTankBattleNumber_ >= 100)
                {
                    BE_RBLists.Add(new BEListRB()
                    {
                        KB_RB = InfoStatKillRespRatioTankRB
                    });
                }
                if (BE_RBShipBattleNumber_ >= 100)
                {
                    BE_RBLists.Add(new BEListRB()
                    {
                        KB_RB = InfoStatKillRespRatioShipRB
                    });
                }
                //////////////
                if (BE_RBLists.Count == 0)
                {

                    _InfoStatSkillRB.SetText("0".ToString() + "%", TextView.BufferType.Normal);
                }
                else
                {
                    double RB_BEList = BE_RBLists.Average(x => x.KB_RB);
                    double RB_BE100 = RB_BEList * 100;
                    RB_BE100 = Math.Round(RB_BE100, 0);
                    _InfoStatSkillRB.SetText(RB_BE100.ToString() + "%", TextView.BufferType.Normal);
                }
                /////////////////
                #endregion

                #region СБ
                List<BEListSB> BE_SBLists = new List<BEListSB>();
                if (BE_SBAviaBattleNumber_ >= 100)
                {
                    BE_SBLists.Add(new BEListSB()
                    {
                        KB_SB = InfoStatKillRespRatioAviaSB
                    });
                }
                if (BE_SBTankBattleNumber_ >= 100)
                {
                    BE_SBLists.Add(new BEListSB()
                    {
                        KB_SB = InfoStatKillRespRatioTankSB
                    });
                }
                if (BE_SBShipBattleNumber_ >= 100)
                {
                    BE_SBLists.Add(new BEListSB()
                    {
                        KB_SB = InfoStatKillRespRatioShipSB
                    });
                }
                //////////////
                if (BE_SBLists.Count == 0)
                {

                    _InfoStatSkillSB.SetText("0".ToString() + "%", TextView.BufferType.Normal);
                }
                else
                {
                    double SB_BEList = BE_SBLists.Average(x => x.KB_SB);
                    double SB_BE100 = SB_BEList * 100;
                    SB_BE100 = Math.Round(SB_BE100, 0);
                    _InfoStatSkillSB.SetText(SB_BE100.ToString() + "%", TextView.BufferType.Normal);
                }
                /////////////////
                #endregion

                #region Картинка

                if (finalBE >= 0 && finalBE <= 30)
                {
                    _InfoStatImage.SetImageResource(Resource.Drawable._stat1info);
                    _InfoStatSkillName.SetText(Resource.String.stat1);

                }
                else
                if (finalBE >= 31 && finalBE <= 50)
                {
                    _InfoStatImage.SetImageResource(Resource.Drawable._stat2info);
                    _InfoStatSkillName.SetText(Resource.String.stat2);

                }
                else
                if (finalBE >= 51 && finalBE <= 75)
                {
                    _InfoStatImage.SetImageResource(Resource.Drawable._stat3info);
                    _InfoStatSkillName.SetText(Resource.String.stat3);
                }
                else
                if (finalBE >= 76 && finalBE <= 100)
                {
                    _InfoStatImage.SetImageResource(Resource.Drawable._stat4info);
                    _InfoStatSkillName.SetText(Resource.String.stat4);
                }
                else
                if (finalBE >= 101 && finalBE <= 150)
                {
                    _InfoStatImage.SetImageResource(Resource.Drawable._stat5info);
                    _InfoStatSkillName.SetText(Resource.String.stat5);
                }
                else
                if (finalBE >= 151 && finalBE <= 200)
                {
                    _InfoStatImage.SetImageResource(Resource.Drawable._stat6info);
                    _InfoStatSkillName.SetText(Resource.String.stat7);
                }
                else
                if (finalBE >= 200)
                {
                    _InfoStatImage.SetImageResource(Resource.Drawable._stat8info);
                    _InfoStatSkillName.SetText(Resource.String.stat8);
                }

                #endregion

                #endregion




                var PreferABBattleCount = BE_ABAviaBattleNumber_ + BE_ABTankBattleNumber_ + BE_ABShipBattleNumber_;
                var PreferRBBattleCount = BE_RBAviaBattleNumber_ + BE_RBTankBattleNumber_ + BE_RBShipBattleNumber_;
                var PreferSBBattleCount = BE_SBAviaBattleNumber_ + BE_SBTankBattleNumber_ + BE_SBShipBattleNumber_;

                #region Предпочтительная техника АБ

                if (PreferABBattleCount >=100)
                {
                    var PreferABAviaBattlePercent = BE_ABAviaBattleNumber_ / PreferABBattleCount * 100;
                    var PreferABTankBattlePercent = BE_ABTankBattleNumber_ / PreferABBattleCount * 100;
                    var PreferABShipBattlePercent = BE_ABShipBattleNumber_ / PreferABBattleCount * 100;

                    preferABs = new List<PreferAB>();
                    preferABs.Add(new PreferAB() { ABPercent = PreferABAviaBattlePercent, ModeName = context.Resources.GetString(Resource.String.StatInfoPreferAvia) });
                    preferABs.Add(new PreferAB() { ABPercent = PreferABTankBattlePercent, ModeName = context.Resources.GetString(Resource.String.StatInfoPreferTank) });
                    preferABs.Add(new PreferAB() { ABPercent = PreferABShipBattlePercent, ModeName = context.Resources.GetString(Resource.String.StatInfoPreferShip) });

                    var sortedAB = from a in preferABs
                                   orderby a.ABPercent descending
                                   select a;
                    preferABs = sortedAB.ToList<PreferAB>();


                    if (preferABs[0].ABPercent >=67)
                    {
                        _InfoStatPreferenceAB.SetText(context.Resources.GetString(Resource.String.StatInfoPrefer) + " " + preferABs[0].ModeName + " " + context.Resources.GetString(Resource.String.StatInfoPreferBattles), TextView.BufferType.Normal);
                    } else
                    if (preferABs[0].ABPercent >=40)
                    {
                        _InfoStatPreferenceAB.SetText(context.Resources.GetString(Resource.String.StatInfoPrefer) + " " + preferABs[0].ModeName + " " + context.Resources.GetString(Resource.String.StatInfoPreferAnd) + " " + preferABs[1].ModeName + " " + context.Resources.GetString(Resource.String.StatInfoPreferBattles), TextView.BufferType.Normal);
                    } else
                    {
                        _InfoStatPreferenceAB.SetText(context.Resources.GetString(Resource.String.StatInfoPreferAll), TextView.BufferType.Normal);
                    }
                }
                else
                {
                    _InfoStatPreferenceAB.SetText(context.Resources.GetString(Resource.String.StatInfoPreferNo), TextView.BufferType.Normal);
                }


                #endregion

                #region Предпочтительная техника РБ

                if (PreferRBBattleCount >= 100)
                {
                    var PreferRBAviaBattlePercent = BE_RBAviaBattleNumber_ / PreferRBBattleCount * 100;
                    var PreferRBTankBattlePercent = BE_RBTankBattleNumber_ / PreferRBBattleCount * 100;
                    var PreferRBShipBattlePercent = BE_RBShipBattleNumber_ / PreferRBBattleCount * 100;

                    preferRBs = new List<PreferRB>();
                    preferRBs.Add(new PreferRB() { RBPercent = PreferRBAviaBattlePercent, ModeName = context.Resources.GetString(Resource.String.StatInfoPreferAvia) });
                    preferRBs.Add(new PreferRB() { RBPercent = PreferRBTankBattlePercent, ModeName = context.Resources.GetString(Resource.String.StatInfoPreferTank) });
                    preferRBs.Add(new PreferRB() { RBPercent = PreferRBShipBattlePercent, ModeName = context.Resources.GetString(Resource.String.StatInfoPreferShip) });

                    var sortedRB = from a in preferRBs
                                   orderby a.RBPercent descending
                                   select a;
                    preferRBs = sortedRB.ToList<PreferRB>();


                    if (preferRBs[0].RBPercent >= 67)
                    {
                        _InfoStatPreferenceRB.SetText(context.Resources.GetString(Resource.String.StatInfoPrefer) +" "+ preferRBs[0].ModeName + " " + context.Resources.GetString(Resource.String.StatInfoPreferBattles), TextView.BufferType.Normal);
                    }
                    else
                    if (preferRBs[0].RBPercent >= 40)
                    {
                        _InfoStatPreferenceRB.SetText(context.Resources.GetString(Resource.String.StatInfoPrefer) + " " + preferRBs[0].ModeName + " " + context.Resources.GetString(Resource.String.StatInfoPreferAnd) + " " + preferRBs[1].ModeName + " " + context.Resources.GetString(Resource.String.StatInfoPreferBattles), TextView.BufferType.Normal);
                    }
                    else
                    {
                        _InfoStatPreferenceRB.SetText(context.Resources.GetString(Resource.String.StatInfoPreferAll), TextView.BufferType.Normal);
                    }
                }
                else
                {
                    _InfoStatPreferenceRB.SetText(context.Resources.GetString(Resource.String.StatInfoPreferNo), TextView.BufferType.Normal);
                }


                #endregion

                #region Предпочтительная техника СБ

                if (PreferSBBattleCount >= 100)
                {
                    var PreferSBAviaBattlePercent = BE_SBAviaBattleNumber_ / PreferSBBattleCount * 100;
                    var PreferSBTankBattlePercent = BE_SBTankBattleNumber_ / PreferSBBattleCount * 100;
                    var PreferSBShipBattlePercent = BE_SBShipBattleNumber_ / PreferSBBattleCount * 100;

                    preferSBs = new List<PreferSB>();
                    preferSBs.Add(new PreferSB() { SBPercent = PreferSBAviaBattlePercent, ModeName = context.Resources.GetString(Resource.String.StatInfoPreferAvia) });
                    preferSBs.Add(new PreferSB() { SBPercent = PreferSBTankBattlePercent, ModeName = context.Resources.GetString(Resource.String.StatInfoPreferTank) });
                    preferSBs.Add(new PreferSB() { SBPercent = PreferSBShipBattlePercent, ModeName = context.Resources.GetString(Resource.String.StatInfoPreferShip) });

                    var sortedSB = from a in preferSBs
                                   orderby a.SBPercent descending
                                   select a;
                    preferSBs = sortedSB.ToList<PreferSB>();



                    if (preferSBs[0].SBPercent >= 67)
                    {
                        _InfoStatPreferenceSB.SetText(context.Resources.GetString(Resource.String.StatInfoPrefer) + " " + preferSBs[0].ModeName + " " + context.Resources.GetString(Resource.String.StatInfoPreferBattles), TextView.BufferType.Normal);
                    }
                    else
                    if (preferSBs[0].SBPercent >= 40)
                    {
                        _InfoStatPreferenceSB.SetText(context.Resources.GetString(Resource.String.StatInfoPrefer) + " " + preferSBs[0].ModeName + " " + context.Resources.GetString(Resource.String.StatInfoPreferAnd) + " " + preferSBs[1].ModeName + " " + context.Resources.GetString(Resource.String.StatInfoPreferBattles), TextView.BufferType.Normal);
                    }
                    else
                    {
                        _InfoStatPreferenceSB.SetText(context.Resources.GetString(Resource.String.StatInfoPreferAll), TextView.BufferType.Normal);
                    }
                }
                else
                {
                    _InfoStatPreferenceSB.SetText(context.Resources.GetString(Resource.String.StatInfoPreferNo), TextView.BufferType.Normal);
                }


                #endregion

                #region Іконки відсотків літаків
                /////////////////////////////////////
                 var InfoStatFighterAB = document.All.Where(m =>
    m.LocalName == "li" &&
    m.HasAttribute("class") &&
    m.GetAttribute("class").Contains("profile-stat__list-item")
   ).ElementAt(55).TextContent.ToString();
                if (InfoStatFighterAB == "N/A")
                {
                    InfoStatFighterAB = "0";
                }

                var InfoStatFighterRB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(68).TextContent.ToString();
                if (InfoStatFighterRB == "N/A")
                {
                    InfoStatFighterRB = "0";
                }

                var InfoStatFighterSB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(81).TextContent.ToString();
                if (InfoStatFighterSB == "N/A")
                {
                    InfoStatFighterSB = "0";
                }

                var InfoStatFighterABInt = Convert.ToDouble(InfoStatFighterAB);
                var InfoStatFighterRBInt = Convert.ToDouble(InfoStatFighterRB);
                var InfoStatFighterSBInt = Convert.ToDouble(InfoStatFighterSB);
                double InfoStatFighterAll = InfoStatFighterABInt + InfoStatFighterRBInt + InfoStatFighterSBInt;
                ////////////////////////////////////////
                var InfoStatBomberAB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(56).TextContent.ToString();
                if (InfoStatBomberAB == "N/A")
                {
                    InfoStatBomberAB = "0";
                }

                var InfoStatBomberRB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(69).TextContent.ToString();
                if (InfoStatBomberRB == "N/A")
                {
                    InfoStatBomberRB = "0";
                }

                var InfoStatBomberSB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(82).TextContent.ToString();
                if (InfoStatBomberSB == "N/A")
                {
                    InfoStatBomberSB = "0";
                }

                var InfoStatBomberABInt = Convert.ToDouble(InfoStatBomberAB);
                var InfoStatBomberRBInt = Convert.ToDouble(InfoStatBomberRB);
                var InfoStatBomberSBInt = Convert.ToDouble(InfoStatBomberSB);
                double InfoStatBomberAll = InfoStatBomberABInt + InfoStatBomberRBInt + InfoStatBomberSBInt;
                ////////////////////////////////////////////////////////
                var InfoStatAttackerAB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(57).TextContent.ToString();
                if (InfoStatAttackerAB == "N/A")
                {
                    InfoStatAttackerAB = "0";
                }

                var InfoStatAttackerRB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(70).TextContent.ToString();
                if (InfoStatAttackerRB == "N/A")
                {
                    InfoStatAttackerRB = "0";
                }

                var InfoStatAttackerSB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(83).TextContent.ToString();
                if (InfoStatAttackerSB == "N/A")
                {
                    InfoStatAttackerSB = "0";
                }

                var InfoStatAttackerABInt = Convert.ToDouble(InfoStatAttackerAB);
                var InfoStatAttackerRBInt = Convert.ToDouble(InfoStatAttackerRB);
                var InfoStatAttackerSBInt = Convert.ToDouble(InfoStatAttackerSB);
                double InfoStatAttackerAll = InfoStatAttackerABInt + InfoStatAttackerRBInt + InfoStatAttackerSBInt;
                //////////////////////////////////////

                double InfoStatPlaneTotal = InfoStatFighterAll + InfoStatBomberAll + InfoStatAttackerAll;
                if (InfoStatPlaneTotal == 0)
                {
                    InfoStatPlaneTotal = 1;
                }
                double InfoStatFighterPercent = InfoStatFighterAll/ InfoStatPlaneTotal;
                InfoStatFighterPercent = InfoStatFighterPercent * 100;
                InfoStatFighterPercent = Math.Round(InfoStatFighterPercent, 0);
                double InfoStatBomberPercent = InfoStatBomberAll/ InfoStatPlaneTotal;
                InfoStatBomberPercent = InfoStatBomberPercent * 100;
                InfoStatBomberPercent = Math.Round(InfoStatBomberPercent, 0);
                double InfoStatAttackerPercent = InfoStatAttackerAll/ InfoStatPlaneTotal;
                InfoStatAttackerPercent = InfoStatAttackerPercent * 100;
                InfoStatAttackerPercent = Math.Round(InfoStatAttackerPercent, 0);

                _InfoStatFighter.SetText(InfoStatFighterPercent+"%", TextView.BufferType.Normal);
                _InfoStatBomber.SetText(InfoStatBomberPercent + "%", TextView.BufferType.Normal);
                _InfoStatAttacker.SetText(InfoStatAttackerPercent + "%", TextView.BufferType.Normal);


                #endregion

                #region Іконки відсотків танків
                /////////////////////////////////////
                var InfoStatMediumTankAB = document.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-stat__list-item")
  ).ElementAt(109).TextContent.ToString();
                if (InfoStatMediumTankAB == "N/A")
                {
                    InfoStatMediumTankAB = "0";
                }

                var InfoStatMediumTankRB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(124).TextContent.ToString();
                if (InfoStatMediumTankRB == "N/A")
                {
                    InfoStatMediumTankRB = "0";
                }

                var InfoStatMediumTankSB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(139).TextContent.ToString();
                if (InfoStatMediumTankSB == "N/A")
                {
                    InfoStatMediumTankSB = "0";
                }

                var InfoStatMediumTankABInt = Convert.ToDouble(InfoStatMediumTankAB);
                var InfoStatMediumTankRBInt = Convert.ToDouble(InfoStatMediumTankRB);
                var InfoStatMediumTankSBInt = Convert.ToDouble(InfoStatMediumTankSB);
                double InfoStatMediumTankAll = InfoStatMediumTankABInt + InfoStatMediumTankRBInt + InfoStatMediumTankSBInt;
                ////////////////////////////////////////////////////////
                var InfoStatTankDestroyerAB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(110).TextContent.ToString();
                if (InfoStatTankDestroyerAB == "N/A")
                {
                    InfoStatTankDestroyerAB = "0";
                }

                var InfoStatTankDestroyerRB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(125).TextContent.ToString();
                if (InfoStatTankDestroyerRB == "N/A")
                {
                    InfoStatTankDestroyerRB = "0";
                }

                var InfoStatTankDestroyerSB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(140).TextContent.ToString();
                if (InfoStatTankDestroyerSB == "N/A")
                {
                    InfoStatTankDestroyerSB = "0";
                }

                var InfoStatTankDestroyerABInt = Convert.ToDouble(InfoStatTankDestroyerAB);
                var InfoStatTankDestroyerRBInt = Convert.ToDouble(InfoStatTankDestroyerRB);
                var InfoStatTankDestroyerSBInt = Convert.ToDouble(InfoStatTankDestroyerSB);
                double InfoStatTankDestroyerAll = InfoStatTankDestroyerABInt + InfoStatTankDestroyerRBInt + InfoStatTankDestroyerSBInt;
                ////////////////////////////////////////

                var InfoStatHeavyTankAB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(111).TextContent.ToString();
                if (InfoStatHeavyTankAB == "N/A")
                {
                    InfoStatHeavyTankAB = "0";
                }

                var InfoStatHeavyTankRB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(126).TextContent.ToString();
                if (InfoStatHeavyTankRB == "N/A")
                {
                    InfoStatHeavyTankRB = "0";
                }

                var InfoStatHeavyTankSB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(141).TextContent.ToString();
                if (InfoStatHeavyTankSB == "N/A")
                {
                    InfoStatHeavyTankSB = "0";
                }

                var InfoStatHeavyTankABInt = Convert.ToDouble(InfoStatHeavyTankAB);
                var InfoStatHeavyTankRBInt = Convert.ToDouble(InfoStatHeavyTankRB);
                var InfoStatHeavyTankSBInt = Convert.ToDouble(InfoStatHeavyTankSB);
                double InfoStatHeavyTankAll = InfoStatHeavyTankABInt + InfoStatHeavyTankRBInt + InfoStatHeavyTankSBInt;
                ////////////////////////////////////////////////////////

                var InfoStatSPAAAB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(112).TextContent.ToString();
                if (InfoStatSPAAAB == "N/A")
                {
                    InfoStatSPAAAB = "0";
                }

                var InfoStatSPAARB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(127).TextContent.ToString();
                if (InfoStatSPAARB == "N/A")
                {
                    InfoStatSPAARB = "0";
                }

                var InfoStatSPAASB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(142).TextContent.ToString();
                if (InfoStatSPAASB == "N/A")
                {
                    InfoStatSPAASB = "0";
                }

                var InfoStatSPAAABInt = Convert.ToDouble(InfoStatSPAAAB);
                var InfoStatSPAARBInt = Convert.ToDouble(InfoStatSPAARB);
                var InfoStatSPAASBInt = Convert.ToDouble(InfoStatSPAASB);
                double InfoStatSPAAAll = InfoStatSPAAABInt + InfoStatSPAARBInt + InfoStatSPAASBInt;

                //////////////////////////////////////

                double InfoStatTankTotal = InfoStatMediumTankAll + InfoStatHeavyTankAll + InfoStatTankDestroyerAll+InfoStatSPAAAll;
                if (InfoStatTankTotal == 0)
                {
                    InfoStatTankTotal = 1;
                }
                double InfoStatMediumTankPercent = InfoStatMediumTankAll / InfoStatTankTotal;
                InfoStatMediumTankPercent = InfoStatMediumTankPercent * 100;
                InfoStatMediumTankPercent = Math.Round(InfoStatMediumTankPercent, 0);
                double InfoStatHeavyTankPercent = InfoStatHeavyTankAll / InfoStatTankTotal;
                InfoStatHeavyTankPercent = InfoStatHeavyTankPercent * 100;
                InfoStatHeavyTankPercent = Math.Round(InfoStatHeavyTankPercent, 0);
                double InfoStatTankDestroyerPercent = InfoStatTankDestroyerAll / InfoStatTankTotal;
                InfoStatTankDestroyerPercent = InfoStatTankDestroyerPercent * 100;
                InfoStatTankDestroyerPercent = Math.Round(InfoStatTankDestroyerPercent, 0);
                double InfoStatSPAAPercent = InfoStatSPAAAll / InfoStatTankTotal;
                InfoStatSPAAPercent = InfoStatSPAAPercent * 100;
                InfoStatSPAAPercent = Math.Round(InfoStatSPAAPercent, 0);

                _InfoStatMiddleTank.SetText(InfoStatMediumTankPercent + "%", TextView.BufferType.Normal);
                _InfoStatHeavyTank.SetText(InfoStatHeavyTankPercent + "%", TextView.BufferType.Normal);
                _InfoStatTankDestroyer.SetText(InfoStatTankDestroyerPercent + "%", TextView.BufferType.Normal);
                _InfoStatSPAA.SetText(InfoStatSPAAPercent + "%", TextView.BufferType.Normal);


                #endregion

                #region Іконки відсотків кораблів
                /////////////////////////////////////
                var InfoStatCruiserAB = document.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-stat__list-item")
  ).ElementAt(175).TextContent.ToString();
                if (InfoStatCruiserAB == "N/A")
                {
                    InfoStatCruiserAB = "0";
                }

                var InfoStatCruiserRB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(196).TextContent.ToString();
                if (InfoStatCruiserRB == "N/A")
                {
                    InfoStatCruiserRB = "0";
                }

                var InfoStatCruiserSB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(217).TextContent.ToString();
                if (InfoStatCruiserSB == "N/A")
                {
                    InfoStatCruiserSB = "0";
                }

                var InfoStatCruiserABInt = Convert.ToDouble(InfoStatCruiserAB);
                var InfoStatCruiserRBInt = Convert.ToDouble(InfoStatCruiserRB);
                var InfoStatCruiserSBInt = Convert.ToDouble(InfoStatCruiserSB);
                double InfoStatCruiserAll = InfoStatCruiserABInt + InfoStatCruiserRBInt + InfoStatCruiserSBInt;
                ////////////////////////////////////////////////////////
                var InfoStatBoatAB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(176).TextContent.ToString();
                if (InfoStatBoatAB == "N/A")
                {
                    InfoStatBoatAB = "0";
                }

                var InfoStatBoatRB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(197).TextContent.ToString();
                if (InfoStatBoatRB == "N/A")
                {
                    InfoStatBoatRB = "0";
                }

                var InfoStatBoatSB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(218).TextContent.ToString();
                if (InfoStatBoatSB == "N/A")
                {
                    InfoStatBoatSB = "0";
                }

                ///

                var InfoStatArtileryBoatAB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(177).TextContent.ToString();
                if (InfoStatArtileryBoatAB == "N/A")
                {
                    InfoStatArtileryBoatAB = "0";
                }

                var InfoStatArtileryBoatRB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(198).TextContent.ToString();
                if (InfoStatArtileryBoatRB == "N/A")
                {
                    InfoStatArtileryBoatRB = "0";
                }

                var InfoStatArtileryBoatSB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(219).TextContent.ToString();
                if (InfoStatArtileryBoatSB == "N/A")
                {
                    InfoStatArtileryBoatSB = "0";
                }

                ///

                var InfoStatTorpedoArtileryBoatAB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(178).TextContent.ToString();
                if (InfoStatTorpedoArtileryBoatAB == "N/A")
                {
                    InfoStatTorpedoArtileryBoatAB = "0";
                }

                var InfoStatTorpedoArtileryBoatRB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(199).TextContent.ToString();
                if (InfoStatTorpedoArtileryBoatRB == "N/A")
                {
                    InfoStatTorpedoArtileryBoatRB = "0";
                }

                var InfoStatTorpedoArtileryBoatSB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(220).TextContent.ToString();
                if (InfoStatTorpedoArtileryBoatSB == "N/A")
                {
                    InfoStatTorpedoArtileryBoatSB = "0";
                }

                ///

                var InfoStatBoatABInt = Convert.ToDouble(InfoStatBoatAB);
                var InfoStatBoatRBInt = Convert.ToDouble(InfoStatBoatRB);
                var InfoStatBoatSBInt = Convert.ToDouble(InfoStatBoatSB);
                var InfoStatArtileryBoatABInt = Convert.ToDouble(InfoStatArtileryBoatAB);
                var InfoStatArtileryBoatRBInt = Convert.ToDouble(InfoStatArtileryBoatRB);
                var InfoStatArtileryBoatSBInt = Convert.ToDouble(InfoStatArtileryBoatSB);
                var InfoStatTorpedoArtileryBoatABInt = Convert.ToDouble(InfoStatTorpedoArtileryBoatAB);
                var InfoStatTorpedoArtileryBoatRBInt = Convert.ToDouble(InfoStatTorpedoArtileryBoatRB);
                var InfoStatTorpedoArtileryBoatSBInt = Convert.ToDouble(InfoStatTorpedoArtileryBoatSB);

                double InfoStatBoatAll = InfoStatBoatABInt + InfoStatBoatRBInt + InfoStatBoatSBInt+InfoStatTorpedoArtileryBoatABInt+ InfoStatTorpedoArtileryBoatRBInt + InfoStatTorpedoArtileryBoatSBInt + InfoStatArtileryBoatABInt + InfoStatArtileryBoatRBInt + InfoStatArtileryBoatSBInt;
                ////////////////////////////////////////

                var InfoStatSeaHunterAB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(179).TextContent.ToString();
                if (InfoStatSeaHunterAB == "N/A")
                {
                    InfoStatSeaHunterAB = "0";
                }

                var InfoStatSeaHunterRB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(200).TextContent.ToString();
                if (InfoStatSeaHunterRB == "N/A")
                {
                    InfoStatSeaHunterRB = "0";
                }

                var InfoStatSeaHunterSB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(221).TextContent.ToString();
                if (InfoStatSeaHunterSB == "N/A")
                {
                    InfoStatSeaHunterSB = "0";
                }

                var InfoStatSeaHunterABInt = Convert.ToDouble(InfoStatSeaHunterAB);
                var InfoStatSeaHunterRBInt = Convert.ToDouble(InfoStatSeaHunterRB);
                var InfoStatSeaHunterSBInt = Convert.ToDouble(InfoStatSeaHunterSB);
                double InfoStatSeaHunterAll = InfoStatSeaHunterABInt + InfoStatSeaHunterRBInt + InfoStatSeaHunterSBInt;
                ////////////////////////////////////////////////////////

                var InfoStatShipDestroyerAB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(180).TextContent.ToString();
                if (InfoStatShipDestroyerAB == "N/A")
                {
                    InfoStatShipDestroyerAB = "0";
                }

                var InfoStatShipDestroyerRB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(201).TextContent.ToString();
                if (InfoStatShipDestroyerRB == "N/A")
                {
                    InfoStatShipDestroyerRB = "0";
                }

                var InfoStatShipDestroyerSB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(222).TextContent.ToString();
                if (InfoStatShipDestroyerSB == "N/A")
                {
                    InfoStatShipDestroyerSB = "0";
                }

                var InfoStatShipDestroyerABInt = Convert.ToDouble(InfoStatShipDestroyerAB);
                var InfoStatShipDestroyerRBInt = Convert.ToDouble(InfoStatShipDestroyerRB);
                var InfoStatShipDestroyerSBInt = Convert.ToDouble(InfoStatShipDestroyerSB);
                double InfoStatShipDestroyerAll = InfoStatShipDestroyerABInt + InfoStatShipDestroyerRBInt + InfoStatShipDestroyerSBInt;

                //////////////////////////////////////

                var InfoStatBargeAB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(181).TextContent.ToString();
                if (InfoStatBargeAB == "N/A")
                {
                    InfoStatBargeAB = "0";
                }

                var InfoStatBargeRB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(202).TextContent.ToString();
                if (InfoStatBargeRB == "N/A")
                {
                    InfoStatBargeRB = "0";
                }

                var InfoStatBargeSB = document.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(223).TextContent.ToString();
                if (InfoStatBargeSB == "N/A")
                {
                    InfoStatBargeSB = "0";
                }

                var InfoStatBargeABInt = Convert.ToDouble(InfoStatBargeAB);
                var InfoStatBargeRBInt = Convert.ToDouble(InfoStatBargeRB);
                var InfoStatBargeSBInt = Convert.ToDouble(InfoStatBargeSB);
                double InfoStatBargeAll = InfoStatBargeABInt + InfoStatBargeRBInt + InfoStatBargeSBInt;

                //////////////////////////////////////

                double InfoStatShipTotal = InfoStatCruiserAll + InfoStatSeaHunterAll + InfoStatBoatAll + InfoStatShipDestroyerAll+InfoStatBargeAll;
                if (InfoStatShipTotal == 0)
                {
                    InfoStatShipTotal = 1;
                }
                double InfoStatCruiserPercent = InfoStatCruiserAll / InfoStatShipTotal;
                InfoStatCruiserPercent = InfoStatCruiserPercent * 100;
                InfoStatCruiserPercent = Math.Round(InfoStatCruiserPercent, 0);
                double InfoStatSeaHunterPercent = InfoStatSeaHunterAll / InfoStatShipTotal;
                InfoStatSeaHunterPercent = InfoStatSeaHunterPercent * 100;
                InfoStatSeaHunterPercent = Math.Round(InfoStatSeaHunterPercent, 0);
                double InfoStatBoatPercent = InfoStatBoatAll / InfoStatShipTotal;
                InfoStatBoatPercent = InfoStatBoatPercent * 100;
                InfoStatBoatPercent = Math.Round(InfoStatBoatPercent, 0);
                double InfoStatShipDestroyerPercent = InfoStatShipDestroyerAll / InfoStatShipTotal;
                InfoStatShipDestroyerPercent = InfoStatShipDestroyerPercent * 100;
                InfoStatShipDestroyerPercent = Math.Round(InfoStatShipDestroyerPercent, 0);
                double InfoStatBargePercent = InfoStatBargeAll / InfoStatShipTotal;
                InfoStatBargePercent = InfoStatBargePercent * 100;
                InfoStatBargePercent = Math.Round(InfoStatBargePercent, 0);

                _InfoStatCruiser.SetText(InfoStatBargePercent + "%", TextView.BufferType.Normal);
                _InfoStatBarge.SetText(InfoStatCruiserPercent + "%", TextView.BufferType.Normal);
                _InfoStatSeaHunter.SetText(InfoStatSeaHunterPercent + "%", TextView.BufferType.Normal);
                _InfoStatBoat.SetText(InfoStatBoatPercent + "%", TextView.BufferType.Normal);
                _InfoStatShipDestroyer.SetText(InfoStatShipDestroyerPercent + "%", TextView.BufferType.Normal);


                #endregion

                _TopHintTextViewInfo.Visibility = Android.Views.ViewStates.Gone;
            }
            catch (InvalidOperationException)
                  {
                      EraseAllField();
                      InfoParserLoadProgressBar.Hide();
                      Toast.MakeText(this, context.Resources.GetString(Resource.String.StatNoNetwork), ToastLength.Long).Show();
                  }
        }


    }


}