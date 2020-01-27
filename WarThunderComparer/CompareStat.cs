using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using AngleSharp;
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
    class LeftBEList
    {
        public double LeftKB { get; set; }
    }

    class RightBEList
    {
        public double RightKB { get; set; }
    }

    [Activity(ScreenOrientation = ScreenOrientation.Portrait)]

    class CompareStat : AppCompatActivity
    {
        Context context;
        List<GameMode> gameModes;
        GameModeAdapter AdapterGameMode;
        Spinner _CompareStatSpinnerMode;
        ImageButton _ButtonSearch;
        AutoCompleteTextView _EditTextSearchLeft;
        AutoCompleteTextView _EditTextSearchRight;
        AngleSharp.Dom.IDocument documentleft;
        AngleSharp.Dom.IDocument documentright;

        //Объявление  спиннеров, кнопок и поиска
        #region Объявление всех текстовых полей
        ContentLoadingProgressBar parserLoadProgressBar;
        ImageView _LeftStatImage;
        ImageView _RightStatImage;
        LinearLayout _CompareLeftStatBackground;
        LinearLayout _CompareRightStatBackground;
        TextView _TopHintTextViewInfo;
        TextView _CompareSquadLeft;
        TextView _CompareSquadRight;
        TextView _CompareStatLeftLevel;
        TextView _CompareStatLeftMainSkill;
        TextView _CompareStatLeftMainSkillName;
        TextView _CompareStatLeftRegData;
        TextView _CompareStatLeftWinRate;
        TextView _CompareStatLeftAviaKB;
        TextView _CompareStatLeftAviaMatchNumber;
        TextView _CompareStatLeftTankKB;
        TextView _CompareStatLeftTankMatchNumber;
        TextView _CompareStatLeftShipKB;
        TextView _CompareStatLeftShipMatchNumber;
        TextView _CompareStatLeftUSAVehicle;
        TextView _CompareStatLeftGermanyVehicle;
        TextView _CompareStatLeftUSSRVehicle;
        TextView _CompareStatLeftGBVehicle;
        TextView _CompareStatLeftJapanVehicle;
        TextView _CompareStatLeftItalyVehicle;
        TextView _CompareStatLeftFranceVehicle;
        TextView _CompareStatLeftUSASpadedVehicle;
        TextView _CompareStatLeftGermanySpadedVehicle;
        TextView _CompareStatLeftUSSRSpadedVehicle;
        TextView _CompareStatLeftGBSpadedVehicle;
        TextView _CompareStatLeftJapanSpadedVehicle;
        TextView _CompareStatLeftItalySpadedVehicle;
        TextView _CompareStatLeftFranceSpadedVehicle;
        TextView _CompareStatLeftFullGameTime;
        TextView _CompareStatLeftLionEarned;
        TextView _CompareStatRightLevel;
        TextView _CompareStatRightMainSkill;
        TextView _CompareStatRightMainSkillName;
        TextView _CompareStatRightRegData;
        TextView _CompareStatRightWinRate;
        TextView _CompareStatRightAviaKB;
        TextView _CompareStatRightAviaMatchNumber;
        TextView _CompareStatRightTankKB;
        TextView _CompareStatRightTankMatchNumber;
        TextView _CompareStatRightShipKB;
        TextView _CompareStatRightShipMatchNumber;
        TextView _CompareStatRightUSAVehicle;
        TextView _CompareStatRightGermanyVehicle;
        TextView _CompareStatRightUSSRVehicle;
        TextView _CompareStatRightGBVehicle;
        TextView _CompareStatRightJapanVehicle;
        TextView _CompareStatRightItalyVehicle;
        TextView _CompareStatRightFranceVehicle;
        TextView _CompareStatRightUSASpadedVehicle;
        TextView _CompareStatRightGermanySpadedVehicle;
        TextView _CompareStatRightUSSRSpadedVehicle;
        TextView _CompareStatRightGBSpadedVehicle;
        TextView _CompareStatRightJapanSpadedVehicle;
        TextView _CompareStatRightItalySpadedVehicle;
        TextView _CompareStatRightFranceSpadedVehicle;
        TextView _CompareStatRightFullGameTime;
        TextView _CompareStatRightLionEarned;
        TextView _CompareStatLabelLevel;
        TextView _CompareStatLabelRegData;
        TextView _CompareStatLabelWinRate;
        TextView _CompareStatLabelAviaKB;
        TextView _CompareStatLabelAviaMatchNumber;
        TextView _CompareStatLabelTankKB;
        TextView _CompareStatLabelTankMatchNumber;
        TextView _CompareStatLabelShipKB;
        TextView _CompareStatLabelShipMatchNumber;
        TextView _CompareStatLabelUSAVehicle;
        TextView _CompareStatLabelGermanyVehicle;
        TextView _CompareStatLabelUSSRVehicle;
        TextView _CompareStatLabelGBVehicle;
        TextView _CompareStatLabelJapanVehicle;
        TextView _CompareStatLabelItalyVehicle;
        TextView _CompareStatLabelFranceVehicle;
        TextView _CompareStatLabelFullGameTime;
        TextView _CompareStatLabelLionEarned;
        #endregion

        private int selectedGameMode;
        private string leftNickName;
        private string rightNickName;

        private string[] names;
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

        #region Поля для записай данных парсинга

        private string ABCompareStatLeftAviaGameTime_;
        private string ABCompareStatLeftShipGameTime_;
        private string ABCompareStatLeftTankGameTime_;
        private string RBCompareStatLeftAviaGameTime_;
        private string RBCompareStatLeftShipGameTime_;
        private string RBCompareStatLeftTankGameTime_;
        private string SBCompareStatLeftAviaGameTime_;
        private string SBCompareStatLeftShipGameTime_;
        private string SBCompareStatLeftTankGameTime_;

        private string ABCompareStatRightAviaGameTime_;
        private string ABCompareStatRightShipGameTime_;
        private string ABCompareStatRightTankGameTime_;
        private string RBCompareStatRightAviaGameTime_;
        private string RBCompareStatRightShipGameTime_;
        private string RBCompareStatRightTankGameTime_;
        private string SBCompareStatRightAviaGameTime_;
        private string SBCompareStatRightShipGameTime_;
        private string SBCompareStatRightTankGameTime_;

        private string BE_LeftABWinRate;
        private string BE_LeftABAviaBattleNumber;
        private double BE_LeftABAviaKB;
        private string BE_LeftABTankBattleNumber;
        private double BE_LeftABTankKB;
        private string BE_LeftABShipBattleNumber;
        private double BE_LeftABShipKB;
        private string BE_LeftRBWinRate;
        private string BE_LeftRBAviaBattleNumber;
        private double BE_LeftRBAviaKB;
        private string BE_LeftRBTankBattleNumber;
        private double BE_LeftRBTankKB;
        private string BE_LeftRBShipBattleNumber;
        private double BE_LeftRBShipKB;
        private string BE_LeftSBWinRate;
        private string BE_LeftSBAviaBattleNumber;
        private double BE_LeftSBAviaKB;
        private string BE_LeftSBTankBattleNumber;
        private double BE_LeftSBTankKB;
        private string BE_LeftSBShipBattleNumber;
        private double BE_LeftSBShipKB;

        private string BE_RightABWinRate;
        private string BE_RightABAviaBattleNumber;
        private double BE_RightABAviaKB;
        private string BE_RightABTankBattleNumber;
        private double BE_RightABTankKB;
        private string BE_RightABShipBattleNumber;
        private double BE_RightABShipKB;
        private string BE_RightRBWinRate;
        private string BE_RightRBAviaBattleNumber;
        private double BE_RightRBAviaKB;
        private string BE_RightRBTankBattleNumber;
        private double BE_RightRBTankKB;
        private string BE_RightRBShipBattleNumber;
        private double BE_RightRBShipKB;
        private string BE_RightSBWinRate;
        private string BE_RightSBAviaBattleNumber;
        private double BE_RightSBAviaKB;
        private string BE_RightSBTankBattleNumber;
        private double BE_RightSBTankKB;
        private string BE_RightSBShipBattleNumber;
        private double BE_RightSBShipKB;

        private string CompareStatLeftRegData;
        private string CompareStatLeftLevel;
        //AB
        private string ABCompareStatLeftWinRate;
        private double ABCompareStatLeftAviaKB;
        private string ABBattleNumberLeftAvia;
        private double ABCompareStatLeftTankKB;
        private string ABBattleNumberLeftTank;
        private double ABCompareStatLeftShipKB;
        private string ABBattleNumberLeftShip;
        //RB
        private string RBCompareStatLeftWinRate;
        private double RBCompareStatLeftAviaKB;
        private string RBBattleNumberLeftAvia;
        private double RBCompareStatLeftTankKB;
        private string RBBattleNumberLeftTank;
        private double RBCompareStatLeftShipKB;
        private string RBBattleNumberLeftShip;
        //SB
        private string SBCompareStatLeftWinRate;
        private double SBCompareStatLeftAviaKB;
        private string SBBattleNumberLeftAvia;
        private double SBCompareStatLeftTankKB;
        private string SBBattleNumberLeftTank;
        private double SBCompareStatLeftShipKB;
        private string SBBattleNumberLeftShip;
        //else
        private string CompareStatLeftAviaGameTime;
        private string CompareStatLeftTankGameTime;
        private string CompareStatLeftShipGameTime;
        private string CompareStatLeftFranceSpadedVehicle;
        private string CompareStatLeftItalySpadedVehicle;
        private string CompareStatLeftJapanSpadedVehicle;
        private string CompareStatLeftGBSpadedVehicle;
        private string CompareStatLeftUSSRSpadedVehicle;
        private string CompareStatLeftGermanySpadedVehicle;
        private string CompareStatLeftUSASpadedVehicle;
        private string CompareStatLeftUSAVehicle;
        private string CompareStatLeftGermanyVehicle;
        private string CompareStatLeftUSSRVehicle;
        private string CompareStatLeftGBVehicle;
        private string CompareStatLeftJapanVehicle;
        private string CompareStatLeftItalyVehicle;
        private string CompareStatLeftFranceVehicle;
        private double CompareStatLeftLionEarned;
        private string CompareStatLeftABGameTime;
        private string CompareStatLeftRBGameTime;
        private string CompareStatLeftSBGameTime;
        private string CompareStatRightABGameTime;
        private string CompareStatRightRBGameTime;
        private string CompareStatRightSBGameTime;


        private string CompareStatRightRegData;
        private string CompareStatRightLevel;
        //AB
        private string ABCompareStatRightWinRate;
        private double ABCompareStatRightAviaKB;
        private string ABBattleNumberRightAvia;
        private double ABCompareStatRightTankKB;
        private string ABBattleNumberRightTank;
        private double ABCompareStatRightShipKB;
        private string ABBattleNumberRightShip;
        //RB
        private string RBCompareStatRightWinRate;
        private double RBCompareStatRightAviaKB;
        private string RBBattleNumberRightAvia;
        private double RBCompareStatRightTankKB;
        private string RBBattleNumberRightTank;
        private double RBCompareStatRightShipKB;
        private string RBBattleNumberRightShip;
        //SB
        private string SBCompareStatRightWinRate;
        private double SBCompareStatRightAviaKB;
        private string SBBattleNumberRightAvia;
        private double SBCompareStatRightTankKB;
        private string SBBattleNumberRightTank;
        private double SBCompareStatRightShipKB;
        private string SBBattleNumberRightShip;
        //else
        private string CompareStatRightAviaGameTime;
        private string CompareStatRightTankGameTime;
        private string CompareStatRightShipGameTime;
        private string CompareStatRightFranceSpadedVehicle;
        private string CompareStatRightItalySpadedVehicle;
        private string CompareStatRightJapanSpadedVehicle;
        private string CompareStatRightGBSpadedVehicle;
        private string CompareStatRightUSSRSpadedVehicle;
        private string CompareStatRightGermanySpadedVehicle;
        private string CompareStatRightUSASpadedVehicle;
        private string CompareStatRightUSAVehicle;
        private string CompareStatRightGermanyVehicle;
        private string CompareStatRightUSSRVehicle;
        private string CompareStatRightGBVehicle;
        private string CompareStatRightJapanVehicle;
        private string CompareStatRightItalyVehicle;
        private string CompareStatRightFranceVehicle;
        private double CompareStatRightLionEarned;

        private double leftAviaGameTimeColor;
        private double rightAviaGameTimeColor;
        private double leftTankGameTimeColor;
        private double rightTankGameTimeColor;
        private double leftShipGameTimeColor;
        private double rightShipGameTimeColor;
        private double leftFullGameTimeColor;
        private double leftFullABGameTimeColor;
        private double leftFullRBGameTimeColor;
        private double leftFullSBGameTimeColor;
        private double rightFullABGameTimeColor;
        private double rightFullRBGameTimeColor;
        private double rightFullSBGameTimeColor;
        private double rightFullGameTimeColor;

        private string CompareStatLeftLionABEarned;
        private string CompareStatLeftLionABEarned_;
        private string CompareStatLeftLionSBEarned_;
        private string CompareStatLeftLionSBEarned;
        private string CompareStatLeftLionRBEarned_;
        private string CompareStatLeftLionRBEarned;
        private string CompareStatRightLionABEarned_;
        private string CompareStatRightLionABEarned;
        private string CompareStatRightLionRBEarned_;
        private string CompareStatRightLionRBEarned;
        private string CompareStatRightLionSBEarned;
        private string CompareStatRightLionSBEarned_;


        private double finalLeftBE;
        private double finalRightBE;
        #endregion


        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\
        DrawerLayout drawerLayout;



        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\

        protected CompareStat(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public CompareStat()
        {
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //SetContentView(Resource.Layout.CompareStat);
            SetContentView(Resource.Layout.CompareStat);
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
            var adView = FindViewById<AdView>(Resource.Id.adViewCompareStat);
            var adRequest = new AdRequest.Builder().Build();
            adView.LoadAd(adRequest);
            //var requestbuilder = new AdRequest.Builder().AddTestDevice("D0BE22F1A4BE27C7470F95A699568FE2");
           // adView.LoadAd(requestbuilder.Build());

            var font = Typeface.CreateFromAsset(Assets, "dinfont.ttf");

            _CompareStatSpinnerMode = FindViewById<Spinner>(Resource.Id.CompareStatSpinnerMode);
            _ButtonSearch = FindViewById<ImageButton>(Resource.Id.ButtonSearch);
            _EditTextSearchLeft = FindViewById<AutoCompleteTextView>(Resource.Id.EditTextSearchLeft);
            _EditTextSearchRight = FindViewById<AutoCompleteTextView>(Resource.Id.EditTextSearchRight);

            gameModes = GameModeCollection.GetGameMode();
            AdapterGameMode = new GameModeAdapter(this, gameModes);
            _CompareStatSpinnerMode.Adapter = AdapterGameMode;
            _CompareStatSpinnerMode.SetSelection(1); //Автовыбор

            _CompareStatSpinnerMode.ItemSelected += _CompareStatSpinnerMode_ItemSelected;
            _ButtonSearch.Click += _ButtonSearch_Click;
            _EditTextSearchLeft.Click += _EditTextSearchLeft_Click;
            _EditTextSearchRight.Click += _EditTextSearchRight_Click;
            //Привязка спиннера и кнопок в коду
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
            _EditTextSearchLeft.Adapter = adapter;
            _EditTextSearchRight.Adapter = adapter;

            #endregion


            #region Объявление всех текстовых полей
            parserLoadProgressBar = FindViewById<ContentLoadingProgressBar>(Resource.Id.contentLoadingProgressBar1);
            parserLoadProgressBar.Hide();
            _TopHintTextViewInfo = FindViewById<TextView>(Resource.Id.TopHintTextView);
            _LeftStatImage = FindViewById<ImageView>(Resource.Id.LeftStatImage);
            _CompareSquadLeft = FindViewById<TextView>(Resource.Id.TextViewSquadLeft);
            _CompareStatLeftLevel = FindViewById<TextView>(Resource.Id.CompareStatLeftLevel);
            _CompareStatLeftMainSkill = FindViewById<TextView>(Resource.Id.CompareStatLeftMainSkill);
            _CompareStatLeftMainSkillName = FindViewById<TextView>(Resource.Id.CompareStatLeftMainSkillName);
            _CompareStatLeftRegData = FindViewById<TextView>(Resource.Id.CompareStatLeftRegData);
            _CompareStatLeftWinRate = FindViewById<TextView>(Resource.Id.CompareStatLeftWinRate);
            _CompareStatLeftAviaKB = FindViewById<TextView>(Resource.Id.CompareStatLeftAviaKB);
            _CompareStatLeftAviaMatchNumber = FindViewById<TextView>(Resource.Id.CompareStatLeftAviaMatchNumber);
            _CompareStatLeftTankKB = FindViewById<TextView>(Resource.Id.CompareStatLeftTankKB);
            _CompareStatLeftTankMatchNumber = FindViewById<TextView>(Resource.Id.CompareStatLeftTankMatchNumber);
            _CompareStatLeftShipKB = FindViewById<TextView>(Resource.Id.CompareStatLeftShipKB);
            _CompareStatLeftShipMatchNumber = FindViewById<TextView>(Resource.Id.CompareStatLeftShipMatchNumber);
            _CompareStatLeftUSAVehicle = FindViewById<TextView>(Resource.Id.CompareStatLeftUSAVehicle);
            _CompareStatLeftGermanyVehicle = FindViewById<TextView>(Resource.Id.CompareStatLeftGermanyVehicle);
            _CompareStatLeftUSSRVehicle = FindViewById<TextView>(Resource.Id.CompareStatLeftUSSRVehicle);
            _CompareStatLeftGBVehicle = FindViewById<TextView>(Resource.Id.CompareStatLeftGBVehicle);
            _CompareStatLeftJapanVehicle = FindViewById<TextView>(Resource.Id.CompareStatLeftJapanVehicle);
            _CompareStatLeftItalyVehicle = FindViewById<TextView>(Resource.Id.CompareStatLeftItalyVehicle);
            _CompareStatLeftFranceVehicle = FindViewById<TextView>(Resource.Id.CompareStatLeftFranceVehicle);
            _CompareStatLeftUSASpadedVehicle = FindViewById<TextView>(Resource.Id.CompareStatLeftUSASpadedVehicle);
            _CompareStatLeftGermanySpadedVehicle = FindViewById<TextView>(Resource.Id.CompareStatLeftGermanySpadedVehicle);
            _CompareStatLeftUSSRSpadedVehicle = FindViewById<TextView>(Resource.Id.CompareStatLeftUSSRSpadedVehicle);
            _CompareStatLeftGBSpadedVehicle = FindViewById<TextView>(Resource.Id.CompareStatLeftGBSpadedVehicle);
            _CompareStatLeftJapanSpadedVehicle = FindViewById<TextView>(Resource.Id.CompareStatLeftJapanSpadedVehicle);
            _CompareStatLeftItalySpadedVehicle = FindViewById<TextView>(Resource.Id.CompareStatLeftItalySpadedVehicle);
            _CompareStatLeftFranceSpadedVehicle = FindViewById<TextView>(Resource.Id.CompareStatLeftFranceSpadedVehicle);
            _CompareStatLeftFullGameTime = FindViewById<TextView>(Resource.Id.CompareStatLeftFullGameTime);
            _CompareStatLeftLionEarned = FindViewById<TextView>(Resource.Id.CompareStatLeftLionEarned);
            _CompareLeftStatBackground = FindViewById<LinearLayout>(Resource.Id.LeftStatBackground);

            _RightStatImage = FindViewById<ImageView>(Resource.Id.RightStatImage);
            _CompareSquadRight = FindViewById<TextView>(Resource.Id.TextViewSquadRight);
            _CompareStatRightLevel = FindViewById<TextView>(Resource.Id.CompareStatRightLevel);
            _CompareStatRightMainSkill = FindViewById<TextView>(Resource.Id.CompareStatRightMainSkill);
            _CompareStatRightMainSkillName = FindViewById<TextView>(Resource.Id.CompareStatRightMainSkillName);
            _CompareStatRightRegData = FindViewById<TextView>(Resource.Id.CompareStatRightRegData);
            _CompareStatRightWinRate = FindViewById<TextView>(Resource.Id.CompareStatRightWinRate);
            _CompareStatRightAviaKB = FindViewById<TextView>(Resource.Id.CompareStatRightAviaKB);
            _CompareStatRightAviaMatchNumber = FindViewById<TextView>(Resource.Id.CompareStatRightAviaMatchNumber);
            _CompareStatRightTankKB = FindViewById<TextView>(Resource.Id.CompareStatRightTankKB);
            _CompareStatRightTankMatchNumber = FindViewById<TextView>(Resource.Id.CompareStatRightTankMatchNumber);
            _CompareStatRightShipKB = FindViewById<TextView>(Resource.Id.CompareStatRightShipKB);
            _CompareStatRightShipMatchNumber = FindViewById<TextView>(Resource.Id.CompareStatRightShipMatchNumber);
            _CompareStatRightUSAVehicle = FindViewById<TextView>(Resource.Id.CompareStatRightUSAVehicle);
            _CompareStatRightGermanyVehicle = FindViewById<TextView>(Resource.Id.CompareStatRightGermanyVehicle);
            _CompareStatRightUSSRVehicle = FindViewById<TextView>(Resource.Id.CompareStatRightUSSRVehicle);
            _CompareStatRightGBVehicle = FindViewById<TextView>(Resource.Id.CompareStatRightGBVehicle);
            _CompareStatRightJapanVehicle = FindViewById<TextView>(Resource.Id.CompareStatRightJapanVehicle);
            _CompareStatRightItalyVehicle = FindViewById<TextView>(Resource.Id.CompareStatRightItalyVehicle);
            _CompareStatRightFranceVehicle = FindViewById<TextView>(Resource.Id.CompareStatRightFranceVehicle);
            _CompareStatRightUSASpadedVehicle = FindViewById<TextView>(Resource.Id.CompareStatRightUSASpadedVehicle);
            _CompareStatRightGermanySpadedVehicle = FindViewById<TextView>(Resource.Id.CompareStatRightGermanySpadedVehicle);
            _CompareStatRightUSSRSpadedVehicle = FindViewById<TextView>(Resource.Id.CompareStatRightUSSRSpadedVehicle);
            _CompareStatRightGBSpadedVehicle = FindViewById<TextView>(Resource.Id.CompareStatRightGBSpadedVehicle);
            _CompareStatRightJapanSpadedVehicle = FindViewById<TextView>(Resource.Id.CompareStatRightJapanSpadedVehicle);
            _CompareStatRightItalySpadedVehicle = FindViewById<TextView>(Resource.Id.CompareStatRightItalySpadedVehicle);
            _CompareStatRightFranceSpadedVehicle = FindViewById<TextView>(Resource.Id.CompareStatRightFranceSpadedVehicle);
            _CompareStatRightFullGameTime = FindViewById<TextView>(Resource.Id.CompareStatRightFullGameTime);
            _CompareStatRightLionEarned = FindViewById<TextView>(Resource.Id.CompareStatRightLionEarned);
            _CompareRightStatBackground = FindViewById<LinearLayout>(Resource.Id.RightStatBackground);


            _CompareStatLabelLevel = FindViewById<TextView>(Resource.Id.CompareStatLabelLevel);
            _CompareStatLabelRegData = FindViewById<TextView>(Resource.Id.CompareStatLabelRegData);
            _CompareStatLabelWinRate = FindViewById<TextView>(Resource.Id.CompareStatLabelWinRate);
            _CompareStatLabelAviaKB = FindViewById<TextView>(Resource.Id.CompareStatLabelAviaKB);
            _CompareStatLabelAviaMatchNumber = FindViewById<TextView>(Resource.Id.CompareStatLabelAviaMatchNumber);
            _CompareStatLabelTankKB = FindViewById<TextView>(Resource.Id.CompareStatLabelTankKB);
            _CompareStatLabelTankMatchNumber = FindViewById<TextView>(Resource.Id.CompareStatLabelTankMatchNumber);
            _CompareStatLabelShipKB = FindViewById<TextView>(Resource.Id.CompareStatLabelShipKB);
            _CompareStatLabelShipMatchNumber = FindViewById<TextView>(Resource.Id.CompareStatLabelShipMatchNumber);
            _CompareStatLabelUSAVehicle = FindViewById<TextView>(Resource.Id.CompareStatLabelUSAVehicle);
            _CompareStatLabelGermanyVehicle = FindViewById<TextView>(Resource.Id.CompareStatLabelGermanyVehicle);
            _CompareStatLabelUSSRVehicle = FindViewById<TextView>(Resource.Id.CompareStatLabelUSSRVehicle);
            _CompareStatLabelGBVehicle = FindViewById<TextView>(Resource.Id.CompareStatLabelGBVehicle);
            _CompareStatLabelJapanVehicle = FindViewById<TextView>(Resource.Id.CompareStatLabelJapanVehicle);
            _CompareStatLabelItalyVehicle = FindViewById<TextView>(Resource.Id.CompareStatLabelItalyVehicle);
            _CompareStatLabelFranceVehicle = FindViewById<TextView>(Resource.Id.CompareStatLabelFranceVehicle);
            _CompareStatLabelFullGameTime = FindViewById<TextView>(Resource.Id.CompareStatLabelFullGameTime);
            _CompareStatLabelLionEarned = FindViewById<TextView>(Resource.Id.CompareStatLabelLionEarned);


            #endregion

            #region Изменения шрифта

            _CompareStatLabelLevel.Typeface = font;
            _CompareStatLabelRegData.Typeface = font;
            _CompareStatLabelWinRate.Typeface = font;
            _CompareStatLabelAviaKB.Typeface = font;
            _CompareStatLabelAviaMatchNumber.Typeface = font;
            _CompareStatLabelTankKB.Typeface = font;
            _CompareStatLabelTankMatchNumber.Typeface = font;
            _CompareStatLabelShipKB.Typeface = font;
            _CompareStatLabelShipMatchNumber.Typeface = font;
            _CompareStatLabelUSAVehicle.Typeface = font;
            _CompareStatLabelGermanyVehicle.Typeface = font;
            _CompareStatLabelUSSRVehicle.Typeface = font;
            _CompareStatLabelGBVehicle.Typeface = font;
            _CompareStatLabelJapanVehicle.Typeface = font;
            _CompareStatLabelItalyVehicle.Typeface = font;
            _CompareStatLabelFranceVehicle.Typeface = font;
            _CompareStatLabelFullGameTime.Typeface = font;
            _CompareStatLabelLionEarned.Typeface = font;
            _CompareStatLeftMainSkill.Typeface = font;
            _CompareStatRightMainSkill.Typeface = font;

            #endregion

            #region Изменения цвета всех TextView
            _CompareSquadLeft.SetTextColor(Color.Black);
            _CompareStatLeftLevel.SetTextColor(Color.Black);
            _CompareStatLeftMainSkill.SetTextColor(Color.White);
            _CompareStatLeftRegData.SetTextColor(Color.Black);
            _CompareStatLeftWinRate.SetTextColor(Color.Black);
            _CompareStatLeftAviaKB.SetTextColor(Color.Black);
            _CompareStatLeftAviaMatchNumber.SetTextColor(Color.Black);
            _CompareStatLeftTankKB.SetTextColor(Color.Black);
            _CompareStatLeftTankMatchNumber.SetTextColor(Color.Black);
            _CompareStatLeftShipKB.SetTextColor(Color.Black);
            _CompareStatLeftShipMatchNumber.SetTextColor(Color.Black);
            _CompareStatLeftUSAVehicle.SetTextColor(Color.Black);
            _CompareStatLeftGermanyVehicle.SetTextColor(Color.Black);
            _CompareStatLeftUSSRVehicle.SetTextColor(Color.Black);
            _CompareStatLeftGBVehicle.SetTextColor(Color.Black);
            _CompareStatLeftJapanVehicle.SetTextColor(Color.Black);
            _CompareStatLeftItalyVehicle.SetTextColor(Color.Black);
            _CompareStatLeftFranceVehicle.SetTextColor(Color.Black);
            _CompareStatLeftUSASpadedVehicle.SetTextColor(Color.Black);
            _CompareStatLeftGermanySpadedVehicle.SetTextColor(Color.Black);
            _CompareStatLeftUSSRSpadedVehicle.SetTextColor(Color.Black);
            _CompareStatLeftGBSpadedVehicle.SetTextColor(Color.Black);
            _CompareStatLeftJapanSpadedVehicle.SetTextColor(Color.Black);
            _CompareStatLeftItalySpadedVehicle.SetTextColor(Color.Black);
            _CompareStatLeftFranceSpadedVehicle.SetTextColor(Color.Black);
            _CompareStatLeftFullGameTime.SetTextColor(Color.Black);
            _CompareStatLeftLionEarned.SetTextColor(Color.Black);

            _CompareSquadRight.SetTextColor(Color.Black);
            _CompareStatRightLevel.SetTextColor(Color.Black);
            _CompareStatRightMainSkill.SetTextColor(Color.White);
            _CompareStatRightRegData.SetTextColor(Color.Black);
            _CompareStatRightWinRate.SetTextColor(Color.Black);
            _CompareStatRightAviaKB.SetTextColor(Color.Black);
            _CompareStatRightAviaMatchNumber.SetTextColor(Color.Black);
            _CompareStatRightTankKB.SetTextColor(Color.Black);
            _CompareStatRightTankMatchNumber.SetTextColor(Color.Black);
            _CompareStatRightShipKB.SetTextColor(Color.Black);
            _CompareStatRightShipMatchNumber.SetTextColor(Color.Black);
            _CompareStatRightUSAVehicle.SetTextColor(Color.Black);
            _CompareStatRightGermanyVehicle.SetTextColor(Color.Black);
            _CompareStatRightUSSRVehicle.SetTextColor(Color.Black);
            _CompareStatRightGBVehicle.SetTextColor(Color.Black);
            _CompareStatRightJapanVehicle.SetTextColor(Color.Black);
            _CompareStatRightItalyVehicle.SetTextColor(Color.Black);
            _CompareStatRightFranceVehicle.SetTextColor(Color.Black);
            _CompareStatRightUSASpadedVehicle.SetTextColor(Color.Black);
            _CompareStatRightGermanySpadedVehicle.SetTextColor(Color.Black);
            _CompareStatRightUSSRSpadedVehicle.SetTextColor(Color.Black);
            _CompareStatRightGBSpadedVehicle.SetTextColor(Color.Black);
            _CompareStatRightJapanSpadedVehicle.SetTextColor(Color.Black);
            _CompareStatRightItalySpadedVehicle.SetTextColor(Color.Black);
            _CompareStatRightFranceSpadedVehicle.SetTextColor(Color.Black);
            _CompareStatRightFullGameTime.SetTextColor(Color.Black);
            _CompareStatRightLionEarned.SetTextColor(Color.Black);

            _CompareStatLabelLevel.SetTextColor(Color.Black);
            _CompareStatLabelRegData.SetTextColor(Color.Black);
            _CompareStatLabelWinRate.SetTextColor(Color.Black);
            _CompareStatLabelAviaKB.SetTextColor(Color.Black);
            _CompareStatLabelAviaMatchNumber.SetTextColor(Color.Black);
            _CompareStatLabelTankKB.SetTextColor(Color.Black);
            _CompareStatLabelTankMatchNumber.SetTextColor(Color.Black);
            _CompareStatLabelShipKB.SetTextColor(Color.Black);
            _CompareStatLabelShipMatchNumber.SetTextColor(Color.Black);
            _CompareStatLabelUSAVehicle.SetTextColor(Color.Black);
            _CompareStatLabelGermanyVehicle.SetTextColor(Color.Black);
            _CompareStatLabelUSSRVehicle.SetTextColor(Color.Black);
            _CompareStatLabelGBVehicle.SetTextColor(Color.Black);
            _CompareStatLabelJapanVehicle.SetTextColor(Color.Black);
            _CompareStatLabelItalyVehicle.SetTextColor(Color.Black);
            _CompareStatLabelFranceVehicle.SetTextColor(Color.Black);
            _CompareStatLabelFullGameTime.SetTextColor(Color.Black);
            _CompareStatLabelLionEarned.SetTextColor(Color.Black);

            #endregion

   //         StartActivity(typeof(InDevelop));
   //        Finish();
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

        private void _EditTextSearchRight_Click(object sender, EventArgs e)
        {
            _EditTextSearchRight.SetCursorVisible(true);
        }

        private void _EditTextSearchLeft_Click(object sender, EventArgs e)
        {
            _EditTextSearchLeft.SetCursorVisible(true);
        }

        private void _ButtonSearch_Click(object sender, EventArgs e)
        {

            leftNickName = _EditTextSearchLeft.Text;
            _EditTextSearchLeft.SetText(leftNickName, Android.Widget.TextView.BufferType.Normal);
            _EditTextSearchLeft.SetCursorVisible(false);

            rightNickName = _EditTextSearchRight.Text;
            _EditTextSearchRight.SetText(rightNickName, Android.Widget.TextView.BufferType.Normal);
            _EditTextSearchRight.SetCursorVisible(false);

            if (string.IsNullOrEmpty(leftNickName))
            {
                Toast.MakeText(this, context.Resources.GetString(Resource.String.WriteYourNick), ToastLength.Long).Show();
                EraseAllField();
            }
            else
            if (string.IsNullOrEmpty(rightNickName))
            {
                Toast.MakeText(this, context.Resources.GetString(Resource.String.WriteOtherNick), ToastLength.Long).Show();
                EraseAllField();
            }
            else
            {
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
                ISharedPreferencesEditor editor = prefs.Edit();

                string isExistLeft = _EditTextSearchLeft.Text;
                string isExistRight = _EditTextSearchRight.Text;

                if (names.Contains(isExistLeft) | names.Contains(isExistRight))
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
                nickName2 = _EditTextSearchRight.Text;
                nickName1 = _EditTextSearchLeft.Text;


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
                _EditTextSearchLeft.Adapter = adapter;
                _EditTextSearchRight.Adapter = adapter;

                _EditTextSearchLeft.DismissDropDown();
                _EditTextSearchRight.DismissDropDown();
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

        /////////////////////////////////////////////////////////


        private void EraseAllField()
        {
            _LeftStatImage.SetImageResource(Resource.Drawable._transparentPlane);
            _RightStatImage.SetImageResource(Resource.Drawable._transparentPlane);
            _CompareSquadLeft.SetText("", TextView.BufferType.Normal);
            _CompareSquadRight.SetText("", TextView.BufferType.Normal);
            _CompareStatLeftLevel.SetText("", TextView.BufferType.Normal);
            _CompareStatLeftMainSkill.SetText("", TextView.BufferType.Normal);
            _CompareStatLeftMainSkillName.SetText("", TextView.BufferType.Normal);
            _CompareStatLeftRegData.SetText("", TextView.BufferType.Normal);
            _CompareStatLeftWinRate.SetText("", TextView.BufferType.Normal);
            _CompareStatLeftAviaKB.SetText("", TextView.BufferType.Normal);
            _CompareStatLeftAviaMatchNumber.SetText("", TextView.BufferType.Normal);
            _CompareStatLeftTankKB.SetText("", TextView.BufferType.Normal);
            _CompareStatLeftTankMatchNumber.SetText("", TextView.BufferType.Normal);
            _CompareStatLeftShipKB.SetText("", TextView.BufferType.Normal);
            _CompareStatLeftShipMatchNumber.SetText("", TextView.BufferType.Normal);
            _CompareStatLeftUSAVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatLeftGermanyVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatLeftUSSRVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatLeftGBVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatLeftJapanVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatLeftItalyVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatLeftFranceVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatLeftUSASpadedVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatLeftGermanySpadedVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatLeftUSSRSpadedVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatLeftGBSpadedVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatLeftJapanSpadedVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatLeftItalySpadedVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatLeftFranceSpadedVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatLeftFullGameTime.SetText("", TextView.BufferType.Normal);
            _CompareStatLeftLionEarned.SetText("", TextView.BufferType.Normal);

            _CompareStatRightLevel.SetText("", TextView.BufferType.Normal);
            _CompareStatRightMainSkill.SetText("", TextView.BufferType.Normal);
            _CompareStatRightMainSkillName.SetText("", TextView.BufferType.Normal);
            _CompareStatRightRegData.SetText("", TextView.BufferType.Normal);
            _CompareStatRightWinRate.SetText("", TextView.BufferType.Normal);
            _CompareStatRightAviaKB.SetText("", TextView.BufferType.Normal);
            _CompareStatRightAviaMatchNumber.SetText("", TextView.BufferType.Normal);
            _CompareStatRightTankKB.SetText("", TextView.BufferType.Normal);
            _CompareStatRightTankMatchNumber.SetText("", TextView.BufferType.Normal);
            _CompareStatRightShipKB.SetText("", TextView.BufferType.Normal);
            _CompareStatRightShipMatchNumber.SetText("", TextView.BufferType.Normal);
            _CompareStatRightUSAVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatRightGermanyVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatRightUSSRVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatRightGBVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatRightJapanVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatRightItalyVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatRightFranceVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatRightUSASpadedVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatRightGermanySpadedVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatRightUSSRSpadedVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatRightGBSpadedVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatRightJapanSpadedVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatRightItalySpadedVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatRightFranceSpadedVehicle.SetText("", TextView.BufferType.Normal);
            _CompareStatRightFullGameTime.SetText("", TextView.BufferType.Normal);
            _CompareStatRightLionEarned.SetText("", TextView.BufferType.Normal);


            _CompareStatLeftLevel.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatLeftMainSkill.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatLeftMainSkillName.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatLeftRegData.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatLeftWinRate.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatLeftAviaKB.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatLeftAviaMatchNumber.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatLeftTankKB.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatLeftTankMatchNumber.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatLeftShipKB.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatLeftShipMatchNumber.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatLeftUSAVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatLeftGermanyVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatLeftUSSRVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatLeftGBVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatLeftJapanVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatLeftItalyVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatLeftFranceVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatLeftUSASpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatLeftGermanySpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatLeftUSSRSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatLeftGBSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatLeftJapanSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatLeftItalySpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatLeftFranceSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatLeftFullGameTime.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatLeftLionEarned.SetBackgroundResource(Resource.Drawable._gradientEqual);

            _CompareStatRightLevel.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatRightMainSkill.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatRightMainSkillName.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatRightRegData.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatRightWinRate.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatRightAviaKB.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatRightAviaMatchNumber.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatRightTankKB.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatRightTankMatchNumber.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatRightShipKB.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatRightShipMatchNumber.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatRightUSAVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatRightGermanyVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatRightUSSRVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatRightGBVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatRightJapanVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatRightItalyVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatRightFranceVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatRightUSASpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatRightGermanySpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatRightUSSRSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatRightGBSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatRightJapanSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatRightItalySpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatRightFranceSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatRightFullGameTime.SetBackgroundResource(Resource.Drawable._gradientEqual);
            _CompareStatRightLionEarned.SetBackgroundResource(Resource.Drawable._gradientEqual);

            _CompareRightStatBackground.SetBackgroundColor(Color.Transparent);
            _CompareLeftStatBackground.SetBackgroundColor(Color.Transparent);
        }


        private async System.Threading.Tasks.Task NickParser()
        {
            EraseAllField();
            var inputManager = (InputMethodManager)GetSystemService(InputMethodService); //скрытие клавиатуры
            inputManager.HideSoftInputFromWindow(_ButtonSearch.WindowToken, HideSoftInputFlags.None); //скрытие клавиатуры
            Regex regexOnlyNumbers = new Regex(@"[\D]");
            Regex regexOnlyNumbersWithDots = new Regex(@"[А-Яа-я\s]");
            string regexMounth = @"^[0-9]{1,2}.{1,}м$";
            string regexDayAndHour = @"^[0-9]{1,2}д\s[0-9]{1,2}ч$";
            string regexHourAndMin = @"^[0-9]{1,2}ч\s[0-9]{1,2}мин$";
            //Регулярки

            parserLoadProgressBar.Show();

            #region Обхід Cloudflare

            try
            {
                ClearanceHandler handler = new ClearanceHandler
                {
                    MaxRetries = 2
                };
                HttpClient client = new HttpClient(handler);
                string sourceLeft = await client.GetStringAsync("https://warthunder.ru/ru/community/userinfo/?nick=" + leftNickName);
                string sourceRight = await client.GetStringAsync("https://warthunder.ru/ru/community/userinfo/?nick=" + rightNickName);

                var parserLeft = new HtmlParser();
                documentleft = parserLeft.ParseDocument(sourceLeft);
                var parserRight = new HtmlParser();
                documentright = parserRight.ParseDocument(sourceRight);
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

                #region Левый игрок

                #region Полк
                string CompareStatSquadLeft_;
                var CompareStatSquadLeft = documentleft.All.FirstOrDefault(m =>
m.LocalName == "a" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("user-profile__data-link")
);
                if (CompareStatSquadLeft != null)
                {
                     CompareStatSquadLeft_ = documentleft.All.FirstOrDefault(m =>
 m.LocalName == "a" &&
 m.HasAttribute("class") &&
 m.GetAttribute("class").Contains("user-profile__data-link")).TextContent.ToString();
                    _CompareSquadLeft.SetText("   "+CompareStatSquadLeft_.ToString(), TextView.BufferType.Normal);

                }
                else
                {
                    CompareStatSquadLeft_ = "";
                    _CompareSquadLeft.SetText(CompareStatSquadLeft_.ToString(), TextView.BufferType.Normal);

                }

                #endregion

                #region Уровень. Слева      

                var CompareStatLeftLevel_ = documentleft.All.Where(m =>
    m.LocalName == "li" &&
    m.HasAttribute("class") &&
    m.GetAttribute("class").Contains("user-profile__data-item")
    ).Last().TextContent.ToString();
                CompareStatLeftLevel = regexOnlyNumbers.Replace(CompareStatLeftLevel_, "");
                _CompareStatLeftLevel.SetText(CompareStatLeftLevel, TextView.BufferType.Normal);


                #endregion

                #region Дата регистрации. Слева
                var CompareStatLeftRegData_ = documentleft.All.Where(m =>
    m.LocalName == "li" &&
    m.HasAttribute("class") &&
    m.GetAttribute("class").Contains("user-profile__data-regdate")
    ).ElementAt(0).TextContent.ToString();
                CompareStatLeftRegData = regexOnlyNumbersWithDots.Replace(CompareStatLeftRegData_, "");
                _CompareStatLeftRegData.SetText(CompareStatLeftRegData, TextView.BufferType.Normal);


                #endregion

                #region Режимы АБ, РБ, СБ

            
                    #region Процент побед. Слева
                    ABCompareStatLeftWinRate = documentleft.All.Where(m =>
       m.LocalName == "li" &&
       m.HasAttribute("class") &&
       m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(13).TextContent.ToString();
                    if (ABCompareStatLeftWinRate == "N/A")
                    {
                        ABCompareStatLeftWinRate = "0%";
                    }
                    BE_LeftABWinRate = ABCompareStatLeftWinRate;
                    #endregion

                    #region Соотношение фраг/бой,  количество вылетов и время игры. Авиа. Слева.
                    var ABFragNumberLeftAvia = documentleft.All.Where(m =>
        m.LocalName == "li" &&
        m.HasAttribute("class") &&
        m.GetAttribute("class").Contains("profile-stat__list-item")
        ).ElementAt(63).TextContent.ToString();

                    ABBattleNumberLeftAvia = documentleft.All.Where(m =>
        m.LocalName == "li" &&
        m.HasAttribute("class") &&
        m.GetAttribute("class").Contains("profile-stat__list-item")
        ).ElementAt(54).TextContent.ToString();

                    ABCompareStatLeftAviaGameTime_ = documentleft.All.Where(m =>
       m.LocalName == "li" &&
       m.HasAttribute("class") &&
       m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(58).TextContent.ToString();

                    try
                    {
                        var FragNumberLeftAviaInt = Convert.ToDouble(ABFragNumberLeftAvia);
                        var BattleNumberLeftAviaInt = Convert.ToDouble(ABBattleNumberLeftAvia);
                        ABCompareStatLeftAviaKB = FragNumberLeftAviaInt / BattleNumberLeftAviaInt;
                        ABCompareStatLeftAviaKB = Math.Round(ABCompareStatLeftAviaKB, 2);


                    }
                    catch (FormatException)
                    {
                        ABCompareStatLeftAviaKB = 0;
                        ABBattleNumberLeftAvia = "0";
                        ABCompareStatLeftAviaGameTime_ = "0ч 0мин";

                    }
                    BE_LeftABAviaKB = ABCompareStatLeftAviaKB;
                    BE_LeftABAviaBattleNumber = ABBattleNumberLeftAvia;



                    #endregion

                    #region Соотношение фраг/бой, количество выездов и время игры. Танки. Слева.
                    var ABFragNumberLeftTank = documentleft.All.Where(m =>
        m.LocalName == "li" &&
        m.HasAttribute("class") &&
        m.GetAttribute("class").Contains("profile-stat__list-item")
        ).ElementAt(120).TextContent.ToString();


                    ABBattleNumberLeftTank = documentleft.All.Where(m =>
       m.LocalName == "li" &&
       m.HasAttribute("class") &&
       m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(108).TextContent.ToString();

                    ABCompareStatLeftTankGameTime_ = documentleft.All.Where(m =>
       m.LocalName == "li" &&
       m.HasAttribute("class") &&
       m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(113).TextContent.ToString();

                    try
                    {
                        var FragNumberLeftTankInt = Convert.ToDouble(ABFragNumberLeftTank);
                        var BattleNumberLeftTankInt = Convert.ToDouble(ABBattleNumberLeftTank);
                        ABCompareStatLeftTankKB = FragNumberLeftTankInt / BattleNumberLeftTankInt;
                        ABCompareStatLeftTankKB = Math.Round(ABCompareStatLeftTankKB, 2);
                    }
                    catch (FormatException)
                    {
                        ABCompareStatLeftTankKB = 0;
                        ABBattleNumberLeftTank = "0";
                        ABCompareStatLeftTankGameTime_ = "0ч 0мин";
                    }
                    BE_LeftABTankBattleNumber = ABBattleNumberLeftTank;
                    BE_LeftABTankKB = ABCompareStatLeftTankKB;


                    #endregion

                    #region Соотношение фраг/бой, количество выходов и время игры. Флот. Слева.
                    var ABFragNumberLeftShip = documentleft.All.Where(m =>
        m.LocalName == "li" &&
        m.HasAttribute("class") &&
        m.GetAttribute("class").Contains("profile-stat__list-item")
        ).ElementAt(193).TextContent.ToString();

                    ABBattleNumberLeftShip = documentleft.All.Where(m =>
       m.LocalName == "li" &&
       m.HasAttribute("class") &&
       m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(174).TextContent.ToString();

                    ABCompareStatLeftShipGameTime_ = documentleft.All.Where(m =>
       m.LocalName == "li" &&
       m.HasAttribute("class") &&
       m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(182).TextContent.ToString();
                    try
                    {
                        var FragNumberLeftShipInt = Convert.ToDouble(ABFragNumberLeftShip);
                        var BattleNumberLeftShipInt = Convert.ToDouble(ABBattleNumberLeftShip);
                        ABCompareStatLeftShipKB = FragNumberLeftShipInt / BattleNumberLeftShipInt;
                        ABCompareStatLeftShipKB = Math.Round(ABCompareStatLeftShipKB, 2);
                    }
                    catch (FormatException)
                    {
                        ABCompareStatLeftShipKB = 0;
                        ABBattleNumberLeftShip = "0";
                        ABCompareStatLeftShipGameTime_ = "0ч 0мин";
                    }
                    BE_LeftABShipKB = ABCompareStatLeftShipKB;
                    BE_LeftABShipBattleNumber = ABBattleNumberLeftShip;


                    #endregion
                

                    #region Процент побед. Слева
                    RBCompareStatLeftWinRate = documentleft.All.Where(m =>
       m.LocalName == "li" &&
       m.HasAttribute("class") &&
       m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(23).TextContent.ToString();
                    if (RBCompareStatLeftWinRate == "N/A")
                    {
                        RBCompareStatLeftWinRate = "0%";
                    }
                    BE_LeftRBWinRate = RBCompareStatLeftWinRate;

                    #endregion

                    #region Соотношение фраг/бой,  количество вылетов и ремя игры. Авиа. Слева.
                    var RBFragNumberLeftAvia = documentleft.All.Where(m =>
    m.LocalName == "li" &&
    m.HasAttribute("class") &&
    m.GetAttribute("class").Contains("profile-stat__list-item")
    ).ElementAt(76).TextContent.ToString();


                    RBBattleNumberLeftAvia = documentleft.All.Where(m =>
        m.LocalName == "li" &&
        m.HasAttribute("class") &&
        m.GetAttribute("class").Contains("profile-stat__list-item")
        ).ElementAt(67).TextContent.ToString();

                    RBCompareStatLeftAviaGameTime_ = documentleft.All.Where(m =>
       m.LocalName == "li" &&
       m.HasAttribute("class") &&
       m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(71).TextContent.ToString();
                    try
                    {
                        var FragNumberLeftAviaInt = Convert.ToDouble(RBFragNumberLeftAvia);
                        var BattleNumberLeftAviaInt = Convert.ToDouble(RBBattleNumberLeftAvia);
                        RBCompareStatLeftAviaKB = FragNumberLeftAviaInt / BattleNumberLeftAviaInt;
                        RBCompareStatLeftAviaKB = Math.Round(RBCompareStatLeftAviaKB, 2);
                    }
                    catch (FormatException)
                    {
                        RBCompareStatLeftAviaKB = 0;
                        RBBattleNumberLeftAvia = "0";
                        RBCompareStatLeftAviaGameTime_ = "0ч 0мин";
                    }
                    BE_LeftRBAviaKB = RBCompareStatLeftAviaKB;
                    BE_LeftRBAviaBattleNumber = RBBattleNumberLeftAvia;



                    #endregion

                    #region Соотношение фраг/бой, количество выездов и время игры. Танки. Слева.
                    var RBFragNumberLeftTank = documentleft.All.Where(m =>
        m.LocalName == "li" &&
        m.HasAttribute("class") &&
        m.GetAttribute("class").Contains("profile-stat__list-item")
        ).ElementAt(135).TextContent.ToString();


                    RBBattleNumberLeftTank = documentleft.All.Where(m =>
       m.LocalName == "li" &&
       m.HasAttribute("class") &&
       m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(123).TextContent.ToString();

                    RBCompareStatLeftTankGameTime_ = documentleft.All.Where(m =>
       m.LocalName == "li" &&
       m.HasAttribute("class") &&
       m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(128).TextContent.ToString();
                    try
                    {
                        var FragNumberLeftTankInt = Convert.ToDouble(RBFragNumberLeftTank);
                        var BattleNumberLeftTankInt = Convert.ToDouble(RBBattleNumberLeftTank);
                        RBCompareStatLeftTankKB = FragNumberLeftTankInt / BattleNumberLeftTankInt;
                        RBCompareStatLeftTankKB = Math.Round(RBCompareStatLeftTankKB, 2);
                    }
                    catch (FormatException)
                    {
                        RBCompareStatLeftTankKB = 0;
                        RBBattleNumberLeftTank = "0";
                        RBCompareStatLeftTankGameTime_ = "0ч 0мин";
                        CompareStatLeftTankGameTime = ParseTranslator(RBCompareStatLeftTankGameTime_);
                    }
                    BE_LeftRBTankKB = RBCompareStatLeftTankKB;
                    BE_LeftRBTankBattleNumber = RBBattleNumberLeftTank;


                    #endregion

                    #region Соотношение фраг/бой, количество выходов и время игры. Флот. Слева.
                    var RBFragNumberLeftShip = documentleft.All.Where(m =>
        m.LocalName == "li" &&
        m.HasAttribute("class") &&
        m.GetAttribute("class").Contains("profile-stat__list-item")
        ).ElementAt(214).TextContent.ToString();


                    RBBattleNumberLeftShip = documentleft.All.Where(m =>
       m.LocalName == "li" &&
       m.HasAttribute("class") &&
       m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(195).TextContent.ToString();

                    RBCompareStatLeftShipGameTime_ = documentleft.All.Where(m =>
       m.LocalName == "li" &&
       m.HasAttribute("class") &&
       m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(203).TextContent.ToString();
                    try
                    {
                        var FragNumberLeftShipInt = Convert.ToDouble(RBFragNumberLeftShip);
                        var BattleNumberLeftShipInt = Convert.ToDouble(RBBattleNumberLeftShip);
                        RBCompareStatLeftShipKB = FragNumberLeftShipInt / BattleNumberLeftShipInt;
                        RBCompareStatLeftShipKB = Math.Round(RBCompareStatLeftShipKB, 2);
                    }
                    catch (FormatException)
                    {
                        RBCompareStatLeftShipKB = 0;
                        RBBattleNumberLeftShip = "0";
                        RBCompareStatLeftShipGameTime_ = "0ч 0мин";
                    }
                    BE_LeftRBShipKB = RBCompareStatLeftShipKB;
                    BE_LeftRBShipBattleNumber = RBBattleNumberLeftShip;


                    #endregion
                

                    #region Процент побед. Слева
                    SBCompareStatLeftWinRate = documentleft.All.Where(m =>
       m.LocalName == "li" &&
       m.HasAttribute("class") &&
       m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(33).TextContent.ToString();
                    if (SBCompareStatLeftWinRate == "N/A")
                    {
                        SBCompareStatLeftWinRate = "0%";
                    }
                    BE_LeftSBWinRate = SBCompareStatLeftWinRate;
                    #endregion

                    #region Соотношение фраг/бой,  количество вылетов и ремя игры. Авиа. Слева.
                    var SBFragNumberLeftAvia = documentleft.All.Where(m =>
        m.LocalName == "li" &&
        m.HasAttribute("class") &&
        m.GetAttribute("class").Contains("profile-stat__list-item")
        ).ElementAt(89).TextContent.ToString();


                    SBBattleNumberLeftAvia = documentleft.All.Where(m =>
        m.LocalName == "li" &&
        m.HasAttribute("class") &&
        m.GetAttribute("class").Contains("profile-stat__list-item")
        ).ElementAt(80).TextContent.ToString();

                    SBCompareStatLeftAviaGameTime_ = documentleft.All.Where(m =>
       m.LocalName == "li" &&
       m.HasAttribute("class") &&
       m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(84).TextContent.ToString();
                    try
                    {
                        var FragNumberLeftAviaInt = Convert.ToDouble(SBFragNumberLeftAvia);
                        var BattleNumberLeftAviaInt = Convert.ToDouble(SBBattleNumberLeftAvia);
                        SBCompareStatLeftAviaKB = FragNumberLeftAviaInt / BattleNumberLeftAviaInt;
                        SBCompareStatLeftAviaKB = Math.Round(SBCompareStatLeftAviaKB, 2);
                    }
                    catch (FormatException)
                    {
                        SBCompareStatLeftAviaKB = 0;
                        SBBattleNumberLeftAvia = "0";
                        SBCompareStatLeftAviaGameTime_ = "0ч 0мин";
                    }
                    BE_LeftSBAviaKB = SBCompareStatLeftAviaKB;
                    BE_LeftSBAviaBattleNumber = SBFragNumberLeftAvia;



                    #endregion

                    #region Соотношение фраг/бой, количество выездов и время игры. Танки. Слева.
                    var SBFragNumberLeftTank = documentleft.All.Where(m =>
        m.LocalName == "li" &&
        m.HasAttribute("class") &&
        m.GetAttribute("class").Contains("profile-stat__list-item")
        ).ElementAt(150).TextContent.ToString();


                    SBBattleNumberLeftTank = documentleft.All.Where(m =>
       m.LocalName == "li" &&
       m.HasAttribute("class") &&
       m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(138).TextContent.ToString();

                    SBCompareStatLeftTankGameTime_ = documentleft.All.Where(m =>
       m.LocalName == "li" &&
       m.HasAttribute("class") &&
       m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(143).TextContent.ToString();
                    try
                    {
                        var FragNumberLeftTankInt = Convert.ToDouble(SBFragNumberLeftTank);
                        var BattleNumberLeftTankInt = Convert.ToDouble(SBBattleNumberLeftTank);
                        SBCompareStatLeftTankKB = FragNumberLeftTankInt / BattleNumberLeftTankInt;
                        SBCompareStatLeftTankKB = Math.Round(SBCompareStatLeftTankKB, 2);
                    }
                    catch (FormatException)
                    {
                        SBCompareStatLeftTankKB = 0;
                        SBBattleNumberLeftTank = "0";
                        SBCompareStatLeftTankGameTime_ = "0ч 0мин";
                    }
                    BE_LeftSBTankKB = SBCompareStatLeftTankKB;
                    BE_LeftSBTankBattleNumber = SBFragNumberLeftTank;



                    #endregion

                    #region Соотношение фраг/бой, количество выходов и время игры. Флот. Слева.
                    var SBFragNumberLeftShip = documentleft.All.Where(m =>
        m.LocalName == "li" &&
        m.HasAttribute("class") &&
        m.GetAttribute("class").Contains("profile-stat__list-item")
        ).ElementAt(235).TextContent.ToString();


                    SBBattleNumberLeftShip = documentleft.All.Where(m =>
       m.LocalName == "li" &&
       m.HasAttribute("class") &&
       m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(216).TextContent.ToString();

                    SBCompareStatLeftShipGameTime_ = documentleft.All.Where(m =>
       m.LocalName == "li" &&
       m.HasAttribute("class") &&
       m.GetAttribute("class").Contains("profile-stat__list-item")
       ).ElementAt(224).TextContent.ToString();
                    try
                    {
                        var FragNumberLeftShipInt = Convert.ToDouble(SBFragNumberLeftShip);
                        var BattleNumberLeftShipInt = Convert.ToDouble(SBBattleNumberLeftShip);
                        SBCompareStatLeftShipKB = FragNumberLeftShipInt / BattleNumberLeftShipInt;
                        SBCompareStatLeftShipKB = Math.Round(SBCompareStatLeftShipKB, 2);

                    }
                    catch (FormatException)
                    {
                        SBCompareStatLeftShipKB = 0;
                        SBBattleNumberLeftShip = "0";
                        SBCompareStatLeftShipGameTime_ = "0ч 0мин";
                    }
                    BE_LeftSBShipKB = SBCompareStatLeftShipKB;
                    BE_LeftSBShipBattleNumber = SBFragNumberLeftShip;


                #endregion
               
                if (selectedGameMode == 0)
                {
                    _CompareStatLeftWinRate.SetText(ABCompareStatLeftWinRate, TextView.BufferType.Normal);
                    _CompareStatLeftAviaKB.SetText(ABCompareStatLeftAviaKB.ToString(), TextView.BufferType.Normal);
                    _CompareStatLeftAviaMatchNumber.SetText(ABBattleNumberLeftAvia, TextView.BufferType.Normal);
                    _CompareStatLeftTankKB.SetText(ABCompareStatLeftTankKB.ToString(), TextView.BufferType.Normal);
                    _CompareStatLeftTankMatchNumber.SetText(ABBattleNumberLeftTank, TextView.BufferType.Normal);
                    _CompareStatLeftShipKB.SetText(ABCompareStatLeftShipKB.ToString(), TextView.BufferType.Normal);
                    _CompareStatLeftShipMatchNumber.SetText(ABBattleNumberLeftShip, TextView.BufferType.Normal);
                    CompareStatLeftAviaGameTime = ParseTranslator(ABCompareStatLeftAviaGameTime_);
                    CompareStatLeftTankGameTime = ParseTranslator(ABCompareStatLeftTankGameTime_);
                    CompareStatLeftShipGameTime = ParseTranslator(ABCompareStatLeftShipGameTime_);
                }
                else
                if (selectedGameMode == 1)
                {
                    _CompareStatLeftWinRate.SetText(RBCompareStatLeftWinRate, TextView.BufferType.Normal);
                    _CompareStatLeftAviaKB.SetText(RBCompareStatLeftAviaKB.ToString(), TextView.BufferType.Normal);
                    _CompareStatLeftAviaMatchNumber.SetText(RBBattleNumberLeftAvia, TextView.BufferType.Normal);
                    _CompareStatLeftTankKB.SetText(RBCompareStatLeftTankKB.ToString(), TextView.BufferType.Normal);
                    _CompareStatLeftTankMatchNumber.SetText(RBBattleNumberLeftTank, TextView.BufferType.Normal);
                    _CompareStatLeftShipKB.SetText(RBCompareStatLeftShipKB.ToString(), TextView.BufferType.Normal);
                    _CompareStatLeftShipMatchNumber.SetText(RBBattleNumberLeftShip, TextView.BufferType.Normal);
                    CompareStatLeftAviaGameTime = ParseTranslator(RBCompareStatLeftAviaGameTime_);
                    CompareStatLeftTankGameTime = ParseTranslator(RBCompareStatLeftTankGameTime_);
                    CompareStatLeftShipGameTime = ParseTranslator(RBCompareStatLeftShipGameTime_);
                }
                else
                if (selectedGameMode == 2)
                {
                    _CompareStatLeftWinRate.SetText(SBCompareStatLeftWinRate, TextView.BufferType.Normal);
                    _CompareStatLeftAviaKB.SetText(SBCompareStatLeftAviaKB.ToString(), TextView.BufferType.Normal);
                    _CompareStatLeftAviaMatchNumber.SetText(SBBattleNumberLeftAvia, TextView.BufferType.Normal);
                    _CompareStatLeftTankKB.SetText(SBCompareStatLeftTankKB.ToString(), TextView.BufferType.Normal);
                    _CompareStatLeftTankMatchNumber.SetText(SBBattleNumberLeftTank, TextView.BufferType.Normal);
                    _CompareStatLeftShipKB.SetText(SBCompareStatLeftShipKB.ToString(), TextView.BufferType.Normal);
                    _CompareStatLeftShipMatchNumber.SetText(SBBattleNumberLeftShip, TextView.BufferType.Normal);
                    CompareStatLeftAviaGameTime = ParseTranslator(SBCompareStatLeftAviaGameTime_);
                    CompareStatLeftTankGameTime = ParseTranslator(SBCompareStatLeftTankGameTime_);
                    CompareStatLeftShipGameTime = ParseTranslator(SBCompareStatLeftShipGameTime_);
                }

                #endregion

                #region Техника. Вся. Слева

                CompareStatLeftUSAVehicle = documentleft.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-score__list-item")
   ).ElementAt(9).TextContent.ToString();
                _CompareStatLeftUSAVehicle.SetText(CompareStatLeftUSAVehicle, TextView.BufferType.Normal);

                CompareStatLeftGermanyVehicle = documentleft.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-score__list-item")
   ).ElementAt(12).TextContent.ToString();
                _CompareStatLeftGermanyVehicle.SetText(CompareStatLeftGermanyVehicle, TextView.BufferType.Normal);

                CompareStatLeftUSSRVehicle = documentleft.All.Where(m =>
     m.LocalName == "li" &&
     m.HasAttribute("class") &&
     m.GetAttribute("class").Contains("profile-score__list-item")
     ).ElementAt(10).TextContent.ToString();
                _CompareStatLeftUSSRVehicle.SetText(CompareStatLeftUSSRVehicle, TextView.BufferType.Normal);

                CompareStatLeftGBVehicle = documentleft.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-score__list-item")
   ).ElementAt(11).TextContent.ToString();
                _CompareStatLeftGBVehicle.SetText(CompareStatLeftGBVehicle, TextView.BufferType.Normal);

                CompareStatLeftJapanVehicle = documentleft.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-score__list-item")
   ).ElementAt(13).TextContent.ToString();
                _CompareStatLeftJapanVehicle.SetText(CompareStatLeftJapanVehicle, TextView.BufferType.Normal);

                CompareStatLeftItalyVehicle = documentleft.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-score__list-item")
   ).ElementAt(14).TextContent.ToString();
                _CompareStatLeftItalyVehicle.SetText(CompareStatLeftItalyVehicle, TextView.BufferType.Normal);

                CompareStatLeftFranceVehicle = documentleft.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-score__list-item")
   ).ElementAt(15).TextContent.ToString();
                _CompareStatLeftFranceVehicle.SetText(CompareStatLeftFranceVehicle, TextView.BufferType.Normal);

                #endregion

                #region Техника. Топ. Слева

                CompareStatLeftUSASpadedVehicle = documentleft.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-score__list-item")
   ).ElementAt(17).TextContent.ToString();
                _CompareStatLeftUSASpadedVehicle.SetText(" (" + CompareStatLeftUSASpadedVehicle + ")", TextView.BufferType.Normal);

                CompareStatLeftGermanySpadedVehicle = documentleft.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-score__list-item")
   ).ElementAt(20).TextContent.ToString();
                _CompareStatLeftGermanySpadedVehicle.SetText(" (" + CompareStatLeftGermanySpadedVehicle + ")", TextView.BufferType.Normal);

                CompareStatLeftUSSRSpadedVehicle = documentleft.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-score__list-item")
   ).ElementAt(18).TextContent.ToString();
                _CompareStatLeftUSSRSpadedVehicle.SetText(" (" + CompareStatLeftUSSRSpadedVehicle + ")", TextView.BufferType.Normal);

                CompareStatLeftGBSpadedVehicle = documentleft.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-score__list-item")
   ).ElementAt(19).TextContent.ToString();
                _CompareStatLeftGBSpadedVehicle.SetText(" (" + CompareStatLeftGBSpadedVehicle + ")", TextView.BufferType.Normal);

                CompareStatLeftJapanSpadedVehicle = documentleft.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-score__list-item")
   ).ElementAt(21).TextContent.ToString();
                _CompareStatLeftJapanSpadedVehicle.SetText(" (" + CompareStatLeftJapanSpadedVehicle + ")", TextView.BufferType.Normal);

                CompareStatLeftItalySpadedVehicle = documentleft.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-score__list-item")
   ).ElementAt(22).TextContent.ToString();
                _CompareStatLeftItalySpadedVehicle.SetText(" (" + CompareStatLeftItalySpadedVehicle + ")", TextView.BufferType.Normal);

                CompareStatLeftFranceSpadedVehicle = documentleft.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-score__list-item")
   ).ElementAt(23).TextContent.ToString();
                _CompareStatLeftFranceSpadedVehicle.SetText(" (" + CompareStatLeftFranceSpadedVehicle + ")", TextView.BufferType.Normal);

                #endregion

                #region Серебро.Слева

                CompareStatLeftLionABEarned_ = documentleft.All.Where(m =>
    m.LocalName == "li" &&
    m.HasAttribute("class") &&
    m.GetAttribute("class").Contains("profile-stat__list-item")
    ).ElementAt(15).TextContent.ToString();
                if (CompareStatLeftLionABEarned_ == "N/A")
                {
                    CompareStatLeftLionABEarned = "0";
                }
                else
                {
                    CompareStatLeftLionABEarned = regexOnlyNumbers.Replace(CompareStatLeftLionABEarned_, "");
                }
                 CompareStatLeftLionRBEarned_ = documentleft.All.Where(m =>
    m.LocalName == "li" &&
    m.HasAttribute("class") &&
    m.GetAttribute("class").Contains("profile-stat__list-item")
    ).ElementAt(25).TextContent.ToString();
                if (CompareStatLeftLionRBEarned_ == "N/A")
                {
                    CompareStatLeftLionRBEarned = "0";
                }
                else
                {
                     CompareStatLeftLionRBEarned = regexOnlyNumbers.Replace(CompareStatLeftLionRBEarned_, "");
                }

                 CompareStatLeftLionSBEarned_ = documentleft.All.Where(m =>
    m.LocalName == "li" &&
    m.HasAttribute("class") &&
    m.GetAttribute("class").Contains("profile-stat__list-item")
    ).ElementAt(35).TextContent.ToString();
                if (CompareStatLeftLionSBEarned_ == "N/A")
                {
                    CompareStatLeftLionSBEarned = "0";
                }
                else
                {
                    CompareStatLeftLionSBEarned = regexOnlyNumbers.Replace(CompareStatLeftLionSBEarned_, "");
                }

                try
                {
                    var CompareStatLeftLionABEarnedInt = Convert.ToDouble(CompareStatLeftLionABEarned);
                    var CompareStatLeftLionRBEarnedInt = Convert.ToDouble(CompareStatLeftLionRBEarned);
                    var CompareStatLeftLionSBEarnedInt = Convert.ToDouble(CompareStatLeftLionSBEarned);
                    CompareStatLeftLionEarned = CompareStatLeftLionABEarnedInt + CompareStatLeftLionRBEarnedInt + CompareStatLeftLionSBEarnedInt;

                    _CompareStatLeftLionEarned.SetText(CompareStatLeftLionEarned.ToString("N0"), TextView.BufferType.Normal);
                }
                catch (FormatException)
                {
                    _CompareStatLeftLionEarned.SetText("0", TextView.BufferType.Normal);
                }
                #endregion

                #region Общее игровое время. Слева
                CompareStatLeftABGameTime = documentleft.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-stat__list-item")
   ).ElementAt(16).TextContent.ToString();

                CompareStatLeftRBGameTime = documentleft.All.Where(m =>
 m.LocalName == "li" &&
 m.HasAttribute("class") &&
 m.GetAttribute("class").Contains("profile-stat__list-item")
 ).ElementAt(26).TextContent.ToString();

                CompareStatLeftSBGameTime = documentleft.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(36).TextContent.ToString();

                #region Конвертер аркадного игрового времени в часы для подсветки цветом. Слева


                Match matchMounthABLeft = Regex.Match(CompareStatLeftABGameTime, regexMounth, RegexOptions.IgnoreCase);
                Match matchDayAndHoursABLeft = Regex.Match(CompareStatLeftABGameTime, regexDayAndHour, RegexOptions.IgnoreCase);
                Match matchHoursAndMinutesABLeft = Regex.Match(CompareStatLeftABGameTime, regexHourAndMin, RegexOptions.IgnoreCase);

                if (matchMounthABLeft.Success)
                {
                    string totalTime_ = regexOnlyNumbersWithDots.Replace(CompareStatLeftABGameTime, "");
                    CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    var totalTime = Convert.ToDouble(totalTime_);
                    Thread.CurrentThread.CurrentCulture = temp_culture;
                    leftFullABGameTimeColor = totalTime * 720;
                }
                else
                if (matchDayAndHoursABLeft.Success)
                {
                    var time = TimeSpan.ParseExact(CompareStatLeftABGameTime, "d'д 'h'ч'", null);
                    leftFullABGameTimeColor = time.TotalHours;
                }
                else
                if (matchHoursAndMinutesABLeft.Success)
                {
                    var time = TimeSpan.ParseExact(CompareStatLeftABGameTime, "h'ч 'm'мин'", null);
                    leftFullABGameTimeColor = time.TotalHours;
                }


                #endregion

                #region Конвертер реалистичного игрового времени в часы для подсветки цветом. Слева


                Match matchMounthRBLeft = Regex.Match(CompareStatLeftRBGameTime, regexMounth, RegexOptions.IgnoreCase);
                Match matchDayAndHoursRBLeft = Regex.Match(CompareStatLeftRBGameTime, regexDayAndHour, RegexOptions.IgnoreCase);
                Match matchHoursAndMinutesRBLeft = Regex.Match(CompareStatLeftRBGameTime, regexHourAndMin, RegexOptions.IgnoreCase);

                if (matchMounthRBLeft.Success)
                {
                    string totalTime_ = regexOnlyNumbersWithDots.Replace(CompareStatLeftRBGameTime, "");
                    CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    var totalTime = Convert.ToDouble(totalTime_);
                    Thread.CurrentThread.CurrentCulture = temp_culture;
                    leftFullRBGameTimeColor = totalTime * 720;
                }
                else
                if (matchDayAndHoursRBLeft.Success)
                {
                    var time = TimeSpan.ParseExact(CompareStatLeftRBGameTime, "d'д 'h'ч'", null);
                    leftFullRBGameTimeColor = time.TotalHours;
                }
                else
                if (matchHoursAndMinutesRBLeft.Success)
                {
                    var time = TimeSpan.ParseExact(CompareStatLeftRBGameTime, "h'ч 'm'мин'", null);
                    leftFullRBGameTimeColor = time.TotalHours;
                }


                #endregion

                #region Конвертер симуляторного игрового времени в часы для подсветки цветом. Слева


                Match matchMounthSBLeft = Regex.Match(CompareStatLeftSBGameTime, regexMounth, RegexOptions.IgnoreCase);
                Match matchDayAndHoursSBLeft = Regex.Match(CompareStatLeftSBGameTime, regexDayAndHour, RegexOptions.IgnoreCase);
                Match matchHoursAndMinutesSBLeft = Regex.Match(CompareStatLeftSBGameTime, regexHourAndMin, RegexOptions.IgnoreCase);

                if (matchMounthSBLeft.Success)
                {
                    string totalTime_ = regexOnlyNumbersWithDots.Replace(CompareStatLeftSBGameTime, "");
                    CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    var totalTime = Convert.ToDouble(totalTime_);
                    Thread.CurrentThread.CurrentCulture = temp_culture;
                    leftFullSBGameTimeColor = totalTime * 720;
                }
                else
                if (matchDayAndHoursSBLeft.Success)
                {
                    var time = TimeSpan.ParseExact(CompareStatLeftSBGameTime, "d'д 'h'ч'", null);
                    leftFullSBGameTimeColor = time.TotalHours;
                }
                else
                if (matchHoursAndMinutesSBLeft.Success)
                {
                    var time = TimeSpan.ParseExact(CompareStatLeftSBGameTime, "h'ч 'm'мин'", null);
                    leftFullSBGameTimeColor = time.TotalHours;
                }


                #endregion


                leftFullGameTimeColor = leftFullABGameTimeColor + leftFullRBGameTimeColor + leftFullSBGameTimeColor;
                var leftFullGameTimeDays = leftFullGameTimeColor / 24;
                leftFullGameTimeDays= Math.Round(leftFullGameTimeDays, 0);
                _CompareStatLeftFullGameTime.SetText(leftFullGameTimeDays.ToString()+" " + context.Resources.GetString(Resource.String.StatDay), TextView.BufferType.Normal);

                #endregion

                #endregion


                #region Правый игрок

                #region Полк
                string CompareStatSquadRight_;
                var CompareStatSquadRight = documentright.All.FirstOrDefault(m =>
m.LocalName == "a" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("user-profile__data-link")
);
                if (CompareStatSquadRight != null)
                {
                    CompareStatSquadRight_ = documentright.All.FirstOrDefault(m =>
m.LocalName == "a" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("user-profile__data-link")
    ).TextContent.ToString();
                    _CompareSquadRight.SetText("   " + CompareStatSquadRight_.ToString(), TextView.BufferType.Normal);

                }
                else
                {
                    CompareStatSquadRight_ = "";
                    _CompareSquadRight.SetText(CompareStatSquadRight_.ToString(), TextView.BufferType.Normal);

                }

                #endregion

                #region Уровень. Справа      

                var CompareStatRightLevel_ = documentright.All.Where(m =>
    m.LocalName == "li" &&
    m.HasAttribute("class") &&
    m.GetAttribute("class").Contains("user-profile__data-item")
    ).Last().TextContent.ToString();
                CompareStatRightLevel = regexOnlyNumbers.Replace(CompareStatRightLevel_, "");
                _CompareStatRightLevel.SetText(CompareStatRightLevel, TextView.BufferType.Normal);


                #endregion

                #region Дата регистрации. Справа
                var CompareStatRightRegData_ = documentright.All.Where(m =>
    m.LocalName == "li" &&
    m.HasAttribute("class") &&
    m.GetAttribute("class").Contains("user-profile__data-regdate")
    ).ElementAt(0).TextContent.ToString();
                CompareStatRightRegData = regexOnlyNumbersWithDots.Replace(CompareStatRightRegData_, "");
                _CompareStatRightRegData.SetText(CompareStatRightRegData, TextView.BufferType.Normal);


                #endregion

                #region Режимы АБ, РБ, СБ


                #region Процент побед. Справа
                ABCompareStatRightWinRate = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-stat__list-item")
   ).ElementAt(13).TextContent.ToString();
                if (ABCompareStatRightWinRate == "N/A")
                {
                    ABCompareStatRightWinRate = "0%";
                }
                BE_RightABWinRate = ABCompareStatRightWinRate;
                #endregion

                #region Соотношение фраг/бой,  количество вылетов и ремя игры. Авиа. Справа.
                var ABFragNumberRightAvia = documentright.All.Where(m =>
    m.LocalName == "li" &&
    m.HasAttribute("class") &&
    m.GetAttribute("class").Contains("profile-stat__list-item")
    ).ElementAt(63).TextContent.ToString();

                ABBattleNumberRightAvia = documentright.All.Where(m =>
    m.LocalName == "li" &&
    m.HasAttribute("class") &&
    m.GetAttribute("class").Contains("profile-stat__list-item")
    ).ElementAt(54).TextContent.ToString();

                ABCompareStatRightAviaGameTime_ = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-stat__list-item")
   ).ElementAt(58).TextContent.ToString();

                try
                {
                    var FragNumberRightAviaInt = Convert.ToDouble(ABFragNumberRightAvia);
                    var BattleNumberRightAviaInt = Convert.ToDouble(ABBattleNumberRightAvia);
                    ABCompareStatRightAviaKB = FragNumberRightAviaInt / BattleNumberRightAviaInt;
                    ABCompareStatRightAviaKB = Math.Round(ABCompareStatRightAviaKB, 2);


                }
                catch (FormatException)
                {
                    ABCompareStatRightAviaKB = 0;
                    ABBattleNumberRightAvia = "0";
                    ABCompareStatRightAviaGameTime_ = "0ч 0мин";

                }
                BE_RightABAviaKB = ABCompareStatRightAviaKB;
                BE_RightABAviaBattleNumber = ABBattleNumberRightAvia;



                #endregion

                #region Соотношение фраг/бой, количество выездов и время игры. Танки. Справа.
                var ABFragNumberRightTank = documentright.All.Where(m =>
    m.LocalName == "li" &&
    m.HasAttribute("class") &&
    m.GetAttribute("class").Contains("profile-stat__list-item")
    ).ElementAt(120).TextContent.ToString();


                ABBattleNumberRightTank = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-stat__list-item")
   ).ElementAt(108).TextContent.ToString();

                ABCompareStatRightTankGameTime_ = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-stat__list-item")
   ).ElementAt(113).TextContent.ToString();

                try
                {
                    var FragNumberRightTankInt = Convert.ToDouble(ABFragNumberRightTank);
                    var BattleNumberRightTankInt = Convert.ToDouble(ABBattleNumberRightTank);
                    ABCompareStatRightTankKB = FragNumberRightTankInt / BattleNumberRightTankInt;
                    ABCompareStatRightTankKB = Math.Round(ABCompareStatRightTankKB, 2);
                }
                catch (FormatException)
                {
                    ABCompareStatRightTankKB = 0;
                    ABBattleNumberRightTank = "0";
                    ABCompareStatRightTankGameTime_ = "0ч 0мин";
                }
                BE_RightABTankBattleNumber = ABBattleNumberRightTank;
                BE_RightABTankKB = ABCompareStatRightTankKB;


                #endregion

                #region Соотношение фраг/бой, количество выходов и время игры. Флот. Справа.
                var ABFragNumberRightShip = documentright.All.Where(m =>
    m.LocalName == "li" &&
    m.HasAttribute("class") &&
    m.GetAttribute("class").Contains("profile-stat__list-item")
    ).ElementAt(193).TextContent.ToString();

                ABBattleNumberRightShip = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-stat__list-item")
   ).ElementAt(174).TextContent.ToString();

                ABCompareStatRightShipGameTime_ = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-stat__list-item")
   ).ElementAt(182).TextContent.ToString();
                try
                {
                    var FragNumberRightShipInt = Convert.ToDouble(ABFragNumberRightShip);
                    var BattleNumberRightShipInt = Convert.ToDouble(ABBattleNumberRightShip);
                    ABCompareStatRightShipKB = FragNumberRightShipInt / BattleNumberRightShipInt;
                    ABCompareStatRightShipKB = Math.Round(ABCompareStatRightShipKB, 2);
                }
                catch (FormatException)
                {
                    ABCompareStatRightShipKB = 0;
                    ABBattleNumberRightShip = "0";
                    ABCompareStatRightShipGameTime_ = "0ч 0мин";
                }
                BE_RightABShipKB = ABCompareStatRightShipKB;
                BE_RightABShipBattleNumber = ABBattleNumberRightShip;


                #endregion


                #region Процент побед. Справа
                RBCompareStatRightWinRate = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-stat__list-item")
   ).ElementAt(23).TextContent.ToString();
                if (RBCompareStatRightWinRate == "N/A")
                {
                    RBCompareStatRightWinRate = "0%";
                }
                BE_RightRBWinRate = RBCompareStatRightWinRate;

                #endregion

                #region Соотношение фраг/бой,  количество вылетов и ремя игры. Авиа. Справа.
                var RBFragNumberRightAvia = documentright.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(76).TextContent.ToString();


                RBBattleNumberRightAvia = documentright.All.Where(m =>
    m.LocalName == "li" &&
    m.HasAttribute("class") &&
    m.GetAttribute("class").Contains("profile-stat__list-item")
    ).ElementAt(67).TextContent.ToString();

                RBCompareStatRightAviaGameTime_ = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-stat__list-item")
   ).ElementAt(71).TextContent.ToString();
                try
                {
                    var FragNumberRightAviaInt = Convert.ToDouble(RBFragNumberRightAvia);
                    var BattleNumberRightAviaInt = Convert.ToDouble(RBBattleNumberRightAvia);
                    RBCompareStatRightAviaKB = FragNumberRightAviaInt / BattleNumberRightAviaInt;
                    RBCompareStatRightAviaKB = Math.Round(RBCompareStatRightAviaKB, 2);
                }
                catch (FormatException)
                {
                    RBCompareStatRightAviaKB = 0;
                    RBBattleNumberRightAvia = "0";
                    RBCompareStatRightAviaGameTime_ = "0ч 0мин";
                }
                BE_RightRBAviaKB = RBCompareStatRightAviaKB;
                BE_RightRBAviaBattleNumber = RBBattleNumberRightAvia;



                #endregion

                #region Соотношение фраг/бой, количество выездов и время игры. Танки. Справа.
                var RBFragNumberRightTank = documentright.All.Where(m =>
    m.LocalName == "li" &&
    m.HasAttribute("class") &&
    m.GetAttribute("class").Contains("profile-stat__list-item")
    ).ElementAt(135).TextContent.ToString();


                RBBattleNumberRightTank = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-stat__list-item")
   ).ElementAt(123).TextContent.ToString();

                RBCompareStatRightTankGameTime_ = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-stat__list-item")
   ).ElementAt(128).TextContent.ToString();
                try
                {
                    var FragNumberRightTankInt = Convert.ToDouble(RBFragNumberRightTank);
                    var BattleNumberRightTankInt = Convert.ToDouble(RBBattleNumberRightTank);
                    RBCompareStatRightTankKB = FragNumberRightTankInt / BattleNumberRightTankInt;
                    RBCompareStatRightTankKB = Math.Round(RBCompareStatRightTankKB, 2);
                }
                catch (FormatException)
                {
                    RBCompareStatRightTankKB = 0;
                    RBBattleNumberRightTank = "0";
                    RBCompareStatRightTankGameTime_ = "0ч 0мин";
                    CompareStatRightTankGameTime = ParseTranslator(RBCompareStatRightTankGameTime_);
                }
                BE_RightRBTankKB = RBCompareStatRightTankKB;
                BE_RightRBTankBattleNumber = RBBattleNumberRightTank;


                #endregion

                #region Соотношение фраг/бой, количество выходов и время игры. Флот. Справа.
                var RBFragNumberRightShip = documentright.All.Where(m =>
    m.LocalName == "li" &&
    m.HasAttribute("class") &&
    m.GetAttribute("class").Contains("profile-stat__list-item")
    ).ElementAt(214).TextContent.ToString();


                RBBattleNumberRightShip = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-stat__list-item")
   ).ElementAt(195).TextContent.ToString();

                RBCompareStatRightShipGameTime_ = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-stat__list-item")
   ).ElementAt(203).TextContent.ToString();
                try
                {
                    var FragNumberRightShipInt = Convert.ToDouble(RBFragNumberRightShip);
                    var BattleNumberRightShipInt = Convert.ToDouble(RBBattleNumberRightShip);
                    RBCompareStatRightShipKB = FragNumberRightShipInt / BattleNumberRightShipInt;
                    RBCompareStatRightShipKB = Math.Round(RBCompareStatRightShipKB, 2);
                }
                catch (FormatException)
                {
                    RBCompareStatRightShipKB = 0;
                    RBBattleNumberRightShip = "0";
                    RBCompareStatRightShipGameTime_ = "0ч 0мин";
                }
                BE_RightRBShipKB = RBCompareStatRightShipKB;
                BE_RightRBShipBattleNumber = RBBattleNumberRightShip;


                #endregion


                #region Процент побед. Справа
                SBCompareStatRightWinRate = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-stat__list-item")
   ).ElementAt(33).TextContent.ToString();
                if (SBCompareStatRightWinRate == "N/A")
                {
                    SBCompareStatRightWinRate = "0%";
                }
                BE_RightSBWinRate = SBCompareStatRightWinRate;
                #endregion

                #region Соотношение фраг/бой,  количество вылетов и ремя игры. Авиа. Справа.
                var SBFragNumberRightAvia = documentright.All.Where(m =>
    m.LocalName == "li" &&
    m.HasAttribute("class") &&
    m.GetAttribute("class").Contains("profile-stat__list-item")
    ).ElementAt(89).TextContent.ToString();


                SBBattleNumberRightAvia = documentright.All.Where(m =>
    m.LocalName == "li" &&
    m.HasAttribute("class") &&
    m.GetAttribute("class").Contains("profile-stat__list-item")
    ).ElementAt(80).TextContent.ToString();

                SBCompareStatRightAviaGameTime_ = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-stat__list-item")
   ).ElementAt(84).TextContent.ToString();
                try
                {
                    var FragNumberRightAviaInt = Convert.ToDouble(SBFragNumberRightAvia);
                    var BattleNumberRightAviaInt = Convert.ToDouble(SBBattleNumberRightAvia);
                    SBCompareStatRightAviaKB = FragNumberRightAviaInt / BattleNumberRightAviaInt;
                    SBCompareStatRightAviaKB = Math.Round(SBCompareStatRightAviaKB, 2);
                }
                catch (FormatException)
                {
                    SBCompareStatRightAviaKB = 0;
                    SBBattleNumberRightAvia = "0";
                    SBCompareStatRightAviaGameTime_ = "0ч 0мин";
                }
                BE_RightSBAviaKB = SBCompareStatRightAviaKB;
                BE_RightSBAviaBattleNumber = SBFragNumberRightAvia;



                #endregion

                #region Соотношение фраг/бой, количество выездов и время игры. Танки. Справа.
                var SBFragNumberRightTank = documentright.All.Where(m =>
    m.LocalName == "li" &&
    m.HasAttribute("class") &&
    m.GetAttribute("class").Contains("profile-stat__list-item")
    ).ElementAt(150).TextContent.ToString();


                SBBattleNumberRightTank = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-stat__list-item")
   ).ElementAt(138).TextContent.ToString();

                SBCompareStatRightTankGameTime_ = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-stat__list-item")
   ).ElementAt(143).TextContent.ToString();
                try
                {
                    var FragNumberRightTankInt = Convert.ToDouble(SBFragNumberRightTank);
                    var BattleNumberRightTankInt = Convert.ToDouble(SBBattleNumberRightTank);
                    SBCompareStatRightTankKB = FragNumberRightTankInt / BattleNumberRightTankInt;
                    SBCompareStatRightTankKB = Math.Round(SBCompareStatRightTankKB, 2);
                }
                catch (FormatException)
                {
                    SBCompareStatRightTankKB = 0;
                    SBBattleNumberRightTank = "0";
                    SBCompareStatRightTankGameTime_ = "0ч 0мин";
                }
                BE_RightSBTankKB = SBCompareStatRightTankKB;
                BE_RightSBTankBattleNumber = SBFragNumberRightTank;



                #endregion

                #region Соотношение фраг/бой, количество выходов и время игры. Флот. Справа.
                var SBFragNumberRightShip = documentright.All.Where(m =>
    m.LocalName == "li" &&
    m.HasAttribute("class") &&
    m.GetAttribute("class").Contains("profile-stat__list-item")
    ).ElementAt(235).TextContent.ToString();


                SBBattleNumberRightShip = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-stat__list-item")
   ).ElementAt(216).TextContent.ToString();

                SBCompareStatRightShipGameTime_ = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-stat__list-item")
   ).ElementAt(224).TextContent.ToString();
                try
                {
                    var FragNumberRightShipInt = Convert.ToDouble(SBFragNumberRightShip);
                    var BattleNumberRightShipInt = Convert.ToDouble(SBBattleNumberRightShip);
                    SBCompareStatRightShipKB = FragNumberRightShipInt / BattleNumberRightShipInt;
                    SBCompareStatRightShipKB = Math.Round(SBCompareStatRightShipKB, 2);

                }
                catch (FormatException)
                {
                    SBCompareStatRightShipKB = 0;
                    SBBattleNumberRightShip = "0";
                    SBCompareStatRightShipGameTime_ = "0ч 0мин";
                }
                BE_RightSBShipKB = SBCompareStatRightShipKB;
                BE_RightSBShipBattleNumber = SBFragNumberRightShip;


                #endregion

                if (selectedGameMode == 0)
                {
                    _CompareStatRightWinRate.SetText(ABCompareStatRightWinRate, TextView.BufferType.Normal);
                    _CompareStatRightAviaKB.SetText(ABCompareStatRightAviaKB.ToString(), TextView.BufferType.Normal);
                    _CompareStatRightAviaMatchNumber.SetText(ABBattleNumberRightAvia, TextView.BufferType.Normal);
                    _CompareStatRightTankKB.SetText(ABCompareStatRightTankKB.ToString(), TextView.BufferType.Normal);
                    _CompareStatRightTankMatchNumber.SetText(ABBattleNumberRightTank, TextView.BufferType.Normal);
                    _CompareStatRightShipKB.SetText(ABCompareStatRightShipKB.ToString(), TextView.BufferType.Normal);
                    _CompareStatRightShipMatchNumber.SetText(ABBattleNumberRightShip, TextView.BufferType.Normal);
                    CompareStatRightAviaGameTime = ParseTranslator(ABCompareStatRightAviaGameTime_);
                    CompareStatRightTankGameTime = ParseTranslator(ABCompareStatRightTankGameTime_);
                    CompareStatRightShipGameTime = ParseTranslator(ABCompareStatRightShipGameTime_);
                }
                else
                if (selectedGameMode == 1)
                {
                    _CompareStatRightWinRate.SetText(RBCompareStatRightWinRate, TextView.BufferType.Normal);
                    _CompareStatRightAviaKB.SetText(RBCompareStatRightAviaKB.ToString(), TextView.BufferType.Normal);
                    _CompareStatRightAviaMatchNumber.SetText(RBBattleNumberRightAvia, TextView.BufferType.Normal);
                    _CompareStatRightTankKB.SetText(RBCompareStatRightTankKB.ToString(), TextView.BufferType.Normal);
                    _CompareStatRightTankMatchNumber.SetText(RBBattleNumberRightTank, TextView.BufferType.Normal);
                    _CompareStatRightShipKB.SetText(RBCompareStatRightShipKB.ToString(), TextView.BufferType.Normal);
                    _CompareStatRightShipMatchNumber.SetText(RBBattleNumberRightShip, TextView.BufferType.Normal);
                    CompareStatRightAviaGameTime = ParseTranslator(RBCompareStatRightAviaGameTime_);
                    CompareStatRightTankGameTime = ParseTranslator(RBCompareStatRightTankGameTime_);
                    CompareStatRightShipGameTime = ParseTranslator(RBCompareStatRightShipGameTime_);
                }
                else
                if (selectedGameMode == 2)
                {
                    _CompareStatRightWinRate.SetText(SBCompareStatRightWinRate, TextView.BufferType.Normal);
                    _CompareStatRightAviaKB.SetText(SBCompareStatRightAviaKB.ToString(), TextView.BufferType.Normal);
                    _CompareStatRightAviaMatchNumber.SetText(SBBattleNumberRightAvia, TextView.BufferType.Normal);
                    _CompareStatRightTankKB.SetText(SBCompareStatRightTankKB.ToString(), TextView.BufferType.Normal);
                    _CompareStatRightTankMatchNumber.SetText(SBBattleNumberRightTank, TextView.BufferType.Normal);
                    _CompareStatRightShipKB.SetText(SBCompareStatRightShipKB.ToString(), TextView.BufferType.Normal);
                    _CompareStatRightShipMatchNumber.SetText(SBBattleNumberRightShip, TextView.BufferType.Normal);
                    CompareStatRightAviaGameTime = ParseTranslator(SBCompareStatRightAviaGameTime_);
                    CompareStatRightTankGameTime = ParseTranslator(SBCompareStatRightTankGameTime_);
                    CompareStatRightShipGameTime = ParseTranslator(SBCompareStatRightShipGameTime_);
                }

                #endregion

                #region Техника. Вся. Справа

                CompareStatRightUSAVehicle = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-score__list-item")
   ).ElementAt(9).TextContent.ToString();
                _CompareStatRightUSAVehicle.SetText(CompareStatRightUSAVehicle, TextView.BufferType.Normal);

                CompareStatRightGermanyVehicle = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-score__list-item")
   ).ElementAt(12).TextContent.ToString();
                _CompareStatRightGermanyVehicle.SetText(CompareStatRightGermanyVehicle, TextView.BufferType.Normal);

                CompareStatRightUSSRVehicle = documentright.All.Where(m =>
     m.LocalName == "li" &&
     m.HasAttribute("class") &&
     m.GetAttribute("class").Contains("profile-score__list-item")
     ).ElementAt(10).TextContent.ToString();
                _CompareStatRightUSSRVehicle.SetText(CompareStatRightUSSRVehicle, TextView.BufferType.Normal);

                CompareStatRightGBVehicle = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-score__list-item")
   ).ElementAt(11).TextContent.ToString();
                _CompareStatRightGBVehicle.SetText(CompareStatRightGBVehicle, TextView.BufferType.Normal);

                CompareStatRightJapanVehicle = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-score__list-item")
   ).ElementAt(13).TextContent.ToString();
                _CompareStatRightJapanVehicle.SetText(CompareStatRightJapanVehicle, TextView.BufferType.Normal);

                CompareStatRightItalyVehicle = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-score__list-item")
   ).ElementAt(14).TextContent.ToString();
                _CompareStatRightItalyVehicle.SetText(CompareStatRightItalyVehicle, TextView.BufferType.Normal);

                CompareStatRightFranceVehicle = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-score__list-item")
   ).ElementAt(15).TextContent.ToString();
                _CompareStatRightFranceVehicle.SetText(CompareStatRightFranceVehicle, TextView.BufferType.Normal);

                #endregion

                #region Техника. Топ. Справа

                CompareStatRightUSASpadedVehicle = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-score__list-item")
   ).ElementAt(17).TextContent.ToString();
                _CompareStatRightUSASpadedVehicle.SetText(" (" + CompareStatRightUSASpadedVehicle + ")", TextView.BufferType.Normal);

                CompareStatRightGermanySpadedVehicle = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-score__list-item")
   ).ElementAt(20).TextContent.ToString();
                _CompareStatRightGermanySpadedVehicle.SetText(" (" + CompareStatRightGermanySpadedVehicle + ")", TextView.BufferType.Normal);

                CompareStatRightUSSRSpadedVehicle = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-score__list-item")
   ).ElementAt(18).TextContent.ToString();
                _CompareStatRightUSSRSpadedVehicle.SetText(" (" + CompareStatRightUSSRSpadedVehicle + ")", TextView.BufferType.Normal);

                CompareStatRightGBSpadedVehicle = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-score__list-item")
   ).ElementAt(19).TextContent.ToString();
                _CompareStatRightGBSpadedVehicle.SetText(" (" + CompareStatRightGBSpadedVehicle + ")", TextView.BufferType.Normal);

                CompareStatRightJapanSpadedVehicle = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-score__list-item")
   ).ElementAt(21).TextContent.ToString();
                _CompareStatRightJapanSpadedVehicle.SetText(" (" + CompareStatRightJapanSpadedVehicle + ")", TextView.BufferType.Normal);

                CompareStatRightItalySpadedVehicle = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-score__list-item")
   ).ElementAt(22).TextContent.ToString();
                _CompareStatRightItalySpadedVehicle.SetText(" (" + CompareStatRightItalySpadedVehicle + ")", TextView.BufferType.Normal);

                CompareStatRightFranceSpadedVehicle = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-score__list-item")
   ).ElementAt(23).TextContent.ToString();
                _CompareStatRightFranceSpadedVehicle.SetText(" (" + CompareStatRightFranceSpadedVehicle + ")", TextView.BufferType.Normal);

                #endregion

                #region Серебро.Справа

                CompareStatRightLionABEarned_ = documentright.All.Where(m =>
    m.LocalName == "li" &&
    m.HasAttribute("class") &&
    m.GetAttribute("class").Contains("profile-stat__list-item")
    ).ElementAt(15).TextContent.ToString();
                if (CompareStatRightLionABEarned_ == "N/A")
                {
                    CompareStatRightLionABEarned = "0";
                }
                else
                {
                    CompareStatRightLionABEarned = regexOnlyNumbers.Replace(CompareStatRightLionABEarned_, "");
                }
                CompareStatRightLionRBEarned_ = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-stat__list-item")
   ).ElementAt(25).TextContent.ToString();
                if (CompareStatRightLionRBEarned_ == "N/A")
                {
                    CompareStatRightLionRBEarned = "0";
                }
                else
                {
                    CompareStatRightLionRBEarned = regexOnlyNumbers.Replace(CompareStatRightLionRBEarned_, "");
                }

                CompareStatRightLionSBEarned_ = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-stat__list-item")
   ).ElementAt(35).TextContent.ToString();
                if (CompareStatRightLionSBEarned_ == "N/A")
                {
                    CompareStatRightLionSBEarned = "0";
                }
                else
                {
                    CompareStatRightLionSBEarned = regexOnlyNumbers.Replace(CompareStatRightLionSBEarned_, "");
                }

                try
                {
                    var CompareStatRightLionABEarnedInt = Convert.ToDouble(CompareStatRightLionABEarned);
                    var CompareStatRightLionRBEarnedInt = Convert.ToDouble(CompareStatRightLionRBEarned);
                    var CompareStatRightLionSBEarnedInt = Convert.ToDouble(CompareStatRightLionSBEarned);
                    CompareStatRightLionEarned = CompareStatRightLionABEarnedInt + CompareStatRightLionRBEarnedInt + CompareStatRightLionSBEarnedInt;

                    _CompareStatRightLionEarned.SetText(CompareStatRightLionEarned.ToString("N0"), TextView.BufferType.Normal);
                }
                catch (FormatException)
                {
                    _CompareStatRightLionEarned.SetText("0", TextView.BufferType.Normal);
                }
                #endregion

                #region Общее игровое время. Справа
                CompareStatRightABGameTime = documentright.All.Where(m =>
   m.LocalName == "li" &&
   m.HasAttribute("class") &&
   m.GetAttribute("class").Contains("profile-stat__list-item")
   ).ElementAt(16).TextContent.ToString();

                CompareStatRightRBGameTime = documentright.All.Where(m =>
 m.LocalName == "li" &&
 m.HasAttribute("class") &&
 m.GetAttribute("class").Contains("profile-stat__list-item")
 ).ElementAt(26).TextContent.ToString();

                CompareStatRightSBGameTime = documentright.All.Where(m =>
m.LocalName == "li" &&
m.HasAttribute("class") &&
m.GetAttribute("class").Contains("profile-stat__list-item")
).ElementAt(36).TextContent.ToString();

                #region Конвертер аркадного игрового времени в часы для подсветки цветом. Справа


                Match matchMounthABRight = Regex.Match(CompareStatRightABGameTime, regexMounth, RegexOptions.IgnoreCase);
                Match matchDayAndHoursABRight = Regex.Match(CompareStatRightABGameTime, regexDayAndHour, RegexOptions.IgnoreCase);
                Match matchHoursAndMinutesABRight = Regex.Match(CompareStatRightABGameTime, regexHourAndMin, RegexOptions.IgnoreCase);

                if (matchMounthABRight.Success)
                {
                    string totalTime_ = regexOnlyNumbersWithDots.Replace(CompareStatRightABGameTime, "");
                    CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    var totalTime = Convert.ToDouble(totalTime_);
                    Thread.CurrentThread.CurrentCulture = temp_culture;
                    rightFullABGameTimeColor = totalTime * 720;
                }
                else
                if (matchDayAndHoursABRight.Success)
                {
                    var time = TimeSpan.ParseExact(CompareStatRightABGameTime, "d'д 'h'ч'", null);
                    rightFullABGameTimeColor = time.TotalHours;
                }
                else
                if (matchHoursAndMinutesABRight.Success)
                {
                    var time = TimeSpan.ParseExact(CompareStatRightABGameTime, "h'ч 'm'мин'", null);
                    rightFullABGameTimeColor = time.TotalHours;
                }


                #endregion

                #region Конвертер реалистичного игрового времени в часы для подсветки цветом. Справа


                Match matchMounthRBRight = Regex.Match(CompareStatRightRBGameTime, regexMounth, RegexOptions.IgnoreCase);
                Match matchDayAndHoursRBRight = Regex.Match(CompareStatRightRBGameTime, regexDayAndHour, RegexOptions.IgnoreCase);
                Match matchHoursAndMinutesRBRight = Regex.Match(CompareStatRightRBGameTime, regexHourAndMin, RegexOptions.IgnoreCase);

                if (matchMounthRBRight.Success)
                {
                    string totalTime_ = regexOnlyNumbersWithDots.Replace(CompareStatRightRBGameTime, "");
                    CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    var totalTime = Convert.ToDouble(totalTime_);
                    Thread.CurrentThread.CurrentCulture = temp_culture;
                    rightFullRBGameTimeColor = totalTime * 720;
                }
                else
                if (matchDayAndHoursRBRight.Success)
                {
                    var time = TimeSpan.ParseExact(CompareStatRightRBGameTime, "d'д 'h'ч'", null);
                    rightFullRBGameTimeColor = time.TotalHours;
                }
                else
                if (matchHoursAndMinutesRBRight.Success)
                {
                    var time = TimeSpan.ParseExact(CompareStatRightRBGameTime, "h'ч 'm'мин'", null);
                    rightFullRBGameTimeColor = time.TotalHours;
                }


                #endregion

                #region Конвертер симуляторного игрового времени в часы для подсветки цветом. Справа


                Match matchMounthSBRight = Regex.Match(CompareStatRightSBGameTime, regexMounth, RegexOptions.IgnoreCase);
                Match matchDayAndHoursSBRight = Regex.Match(CompareStatRightSBGameTime, regexDayAndHour, RegexOptions.IgnoreCase);
                Match matchHoursAndMinutesSBRight = Regex.Match(CompareStatRightSBGameTime, regexHourAndMin, RegexOptions.IgnoreCase);

                if (matchMounthSBRight.Success)
                {
                    string totalTime_ = regexOnlyNumbersWithDots.Replace(CompareStatRightSBGameTime, "");
                    CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    var totalTime = Convert.ToDouble(totalTime_);
                    Thread.CurrentThread.CurrentCulture = temp_culture;
                    rightFullSBGameTimeColor = totalTime * 720;
                }
                else
                if (matchDayAndHoursSBRight.Success)
                {
                    var time = TimeSpan.ParseExact(CompareStatRightSBGameTime, "d'д 'h'ч'", null);
                    rightFullSBGameTimeColor = time.TotalHours;
                }
                else
                if (matchHoursAndMinutesSBRight.Success)
                {
                    var time = TimeSpan.ParseExact(CompareStatRightSBGameTime, "h'ч 'm'мин'", null);
                    rightFullSBGameTimeColor = time.TotalHours;
                }


                #endregion


                rightFullGameTimeColor = rightFullABGameTimeColor + rightFullRBGameTimeColor + rightFullSBGameTimeColor;
                var rightFullGameTimeDays = rightFullGameTimeColor / 24;
                rightFullGameTimeDays = Math.Round(rightFullGameTimeDays, 0);
                _CompareStatRightFullGameTime.SetText(rightFullGameTimeDays.ToString() + " " + context.Resources.GetString(Resource.String.StatDay), TextView.BufferType.Normal);

                #endregion

                #endregion

                #region Подсветка цветом
                parserLoadProgressBar.Hide();


                #region Уровень

                var CompareStatLeftLevelColor = Convert.ToDouble(CompareStatLeftLevel);
                var CompareStatRightLevelColor = Convert.ToDouble(CompareStatRightLevel);

                if (CompareStatLeftLevelColor > CompareStatRightLevelColor)
                {
                    _CompareStatLeftLevel.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                    _CompareStatRightLevel.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                }
                else
               if (CompareStatLeftLevelColor < CompareStatRightLevelColor)
                {
                    _CompareStatLeftLevel.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                    _CompareStatRightLevel.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                }
                else if (CompareStatLeftLevelColor == CompareStatRightLevelColor)
                {
                    _CompareStatLeftLevel.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    _CompareStatRightLevel.SetBackgroundResource(Resource.Drawable._gradientEqual);
                }

                #endregion

                #region Дата регистрации
                var CompareStatLeftRegDataColor = DateTime.ParseExact(CompareStatLeftRegData, "dd.MM.yyyy", null);
                var CompareStatRightRegDataColor = DateTime.ParseExact(CompareStatRightRegData, "dd.MM.yyyy", null);

                if (CompareStatLeftRegDataColor < CompareStatRightRegDataColor)
                {
                    _CompareStatLeftRegData.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                    _CompareStatRightRegData.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                }
                else
                if (CompareStatLeftRegDataColor > CompareStatRightRegDataColor)
                {
                    _CompareStatLeftRegData.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                    _CompareStatRightRegData.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                }
                else if (CompareStatLeftRegDataColor == CompareStatRightRegDataColor)
                {
                    _CompareStatLeftRegData.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    _CompareStatRightRegData.SetBackgroundResource(Resource.Drawable._gradientEqual);
                }
                #endregion

                if (selectedGameMode == 0)
                {
                    #region Процент побед

                    var CompareStatLeftWinRateColor_ = regexOnlyNumbers.Replace(ABCompareStatLeftWinRate, "");
                    var CompareStatRightWinRateColor_ = regexOnlyNumbers.Replace(ABCompareStatRightWinRate, "");

                    var CompareStatLeftWinRateColor = Convert.ToDouble(CompareStatLeftWinRateColor_);
                    var CompareStatRightWinRateColor = Convert.ToDouble(CompareStatRightWinRateColor_);

                    if (CompareStatLeftWinRateColor > CompareStatRightWinRateColor)
                    {
                        _CompareStatLeftWinRate.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                        _CompareStatRightWinRate.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    }
                    else
                   if (CompareStatLeftWinRateColor < CompareStatRightWinRateColor)
                    {
                        _CompareStatLeftWinRate.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                        _CompareStatRightWinRate.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    }
                    else if (CompareStatLeftWinRateColor == CompareStatRightWinRateColor)
                    {
                        _CompareStatLeftWinRate.SetBackgroundResource(Resource.Drawable._gradientEqual);
                        _CompareStatRightWinRate.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    }

                    #endregion

                    #region Авиация


                    if (ABCompareStatLeftAviaKB > ABCompareStatRightAviaKB)
                    {
                        _CompareStatLeftAviaKB.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                        _CompareStatRightAviaKB.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    }
                    else
                   if (ABCompareStatLeftAviaKB < ABCompareStatRightAviaKB)
                    {
                        _CompareStatLeftAviaKB.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                        _CompareStatRightAviaKB.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    }
                    else if (ABCompareStatLeftAviaKB == ABCompareStatRightAviaKB)
                    {
                        _CompareStatLeftAviaKB.SetBackgroundResource(Resource.Drawable._gradientEqual);
                        _CompareStatRightAviaKB.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    }



                    var BattleNumberLeftAviaColor = Convert.ToDouble(ABBattleNumberLeftAvia);
                    var BattleNumberRightAviaColor = Convert.ToDouble(ABBattleNumberRightAvia);

                    if (BattleNumberLeftAviaColor > BattleNumberRightAviaColor)
                    {
                        _CompareStatLeftAviaMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                        _CompareStatRightAviaMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    }
                    else
               if (BattleNumberLeftAviaColor < BattleNumberRightAviaColor)
                    {
                        _CompareStatLeftAviaMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                        _CompareStatRightAviaMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    }
                    else if (BattleNumberLeftAviaColor == BattleNumberRightAviaColor)
                    {
                        _CompareStatLeftAviaMatchNumber.SetBackgroundResource(Resource.Drawable._gradientEqual);
                        _CompareStatRightAviaMatchNumber.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    }


                    #region Конвертер игрового времени в часы для подсветки цветом. Слева


                    Match matchMounthAviaLeft = Regex.Match(ABCompareStatLeftAviaGameTime_, regexMounth, RegexOptions.IgnoreCase);
                    Match matchDayAndHoursAviaLeft = Regex.Match(ABCompareStatLeftAviaGameTime_, regexDayAndHour, RegexOptions.IgnoreCase);
                    Match matchHoursAndMinutesAviaLeft = Regex.Match(ABCompareStatLeftAviaGameTime_, regexHourAndMin, RegexOptions.IgnoreCase);

                    if (matchMounthAviaLeft.Success)
                    {
                        string totalTime_ = regexOnlyNumbersWithDots.Replace(ABCompareStatLeftAviaGameTime_, "");
                        CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                        var totalTime = Convert.ToDouble(totalTime_);
                        Thread.CurrentThread.CurrentCulture = temp_culture;
                        leftAviaGameTimeColor = totalTime * 720;
                    }
                    else
                    if (matchDayAndHoursAviaLeft.Success)
                    {
                        var time = TimeSpan.ParseExact(ABCompareStatLeftAviaGameTime_, "d'д 'h'ч'", null);
                        leftAviaGameTimeColor = time.TotalHours;
                    }
                    else
                    if (matchHoursAndMinutesAviaLeft.Success)
                    {
                        var time = TimeSpan.ParseExact(ABCompareStatLeftAviaGameTime_, "h'ч 'm'мин'", null);
                        leftAviaGameTimeColor = time.TotalHours;
                    }


                    #endregion
                    #region Конвертер игрового времени в часы для подсветки цветом. Справа


                    Match matchMounthAviaRight = Regex.Match(ABCompareStatRightAviaGameTime_, regexMounth, RegexOptions.IgnoreCase);
                    Match matchDayAndHoursAviaRight = Regex.Match(ABCompareStatRightAviaGameTime_, regexDayAndHour, RegexOptions.IgnoreCase);
                    Match matchHoursAndMinutesAviaRight = Regex.Match(ABCompareStatRightAviaGameTime_, regexHourAndMin, RegexOptions.IgnoreCase);

                    if (matchMounthAviaRight.Success)
                    {
                        string totalTime_ = regexOnlyNumbersWithDots.Replace(ABCompareStatRightAviaGameTime_, "");
                        CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                        var totalTime = Convert.ToDouble(totalTime_);
                        Thread.CurrentThread.CurrentCulture = temp_culture;
                        rightAviaGameTimeColor = totalTime * 720;
                    }
                    else
                    if (matchDayAndHoursAviaRight.Success)
                    {
                        var time = TimeSpan.ParseExact(ABCompareStatRightAviaGameTime_, "d'д 'h'ч'", null);
                        rightAviaGameTimeColor = time.TotalHours;
                    }
                    else
                    if (matchHoursAndMinutesAviaRight.Success)
                    {
                        var time = TimeSpan.ParseExact(ABCompareStatRightAviaGameTime_, "h'ч 'm'мин'", null);
                        rightAviaGameTimeColor = time.TotalHours;
                    }


                    #endregion


                    #endregion

                    #region Танки


                    if (ABCompareStatLeftTankKB > ABCompareStatRightTankKB)
                    {
                        _CompareStatLeftTankKB.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                        _CompareStatRightTankKB.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    }
                    else
                   if (ABCompareStatLeftTankKB < ABCompareStatRightTankKB)
                    {
                        _CompareStatLeftTankKB.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                        _CompareStatRightTankKB.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    }
                    else if (ABCompareStatLeftTankKB == ABCompareStatRightTankKB)
                    {
                        _CompareStatLeftTankKB.SetBackgroundResource(Resource.Drawable._gradientEqual);
                        _CompareStatRightTankKB.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    }



                    var BattleNumberLeftTankColor = Convert.ToDouble(ABBattleNumberLeftTank);
                    var BattleNumberRightTankColor = Convert.ToDouble(ABBattleNumberRightTank);

                    if (BattleNumberLeftTankColor > BattleNumberRightTankColor)
                    {
                        _CompareStatLeftTankMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                        _CompareStatRightTankMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    }
                    else
               if (BattleNumberLeftTankColor < BattleNumberRightTankColor)
                    {
                        _CompareStatLeftTankMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                        _CompareStatRightTankMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    }
                    else if (BattleNumberLeftTankColor == BattleNumberRightTankColor)
                    {
                        _CompareStatLeftTankMatchNumber.SetBackgroundResource(Resource.Drawable._gradientEqual);
                        _CompareStatRightTankMatchNumber.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    }


                    #region Конвертер игрового времени в часы для подсветки цветом. Слева


                    Match matchMounthTankLeft = Regex.Match(ABCompareStatLeftTankGameTime_, regexMounth, RegexOptions.IgnoreCase);
                    Match matchDayAndHoursTankLeft = Regex.Match(ABCompareStatLeftTankGameTime_, regexDayAndHour, RegexOptions.IgnoreCase);
                    Match matchHoursAndMinutesTankLeft = Regex.Match(ABCompareStatLeftTankGameTime_, regexHourAndMin, RegexOptions.IgnoreCase);

                    if (matchMounthTankLeft.Success)
                    {
                        string totalTime_ = regexOnlyNumbersWithDots.Replace(ABCompareStatLeftTankGameTime_, "");
                        CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                        var totalTime = Convert.ToDouble(totalTime_);
                        Thread.CurrentThread.CurrentCulture = temp_culture;
                        leftTankGameTimeColor = totalTime * 720;
                    }
                    else
                    if (matchDayAndHoursTankLeft.Success)
                    {
                        var time = TimeSpan.ParseExact(ABCompareStatLeftTankGameTime_, "d'д 'h'ч'", null);
                        leftTankGameTimeColor = time.TotalHours;
                    }
                    else
                    if (matchHoursAndMinutesTankLeft.Success)
                    {
                        var time = TimeSpan.ParseExact(ABCompareStatLeftTankGameTime_, "h'ч 'm'мин'", null);
                        leftTankGameTimeColor = time.TotalHours;
                    }


                    #endregion
                    #region Конвертер игрового времени в часы для подсветки цветом. Справа


                    Match matchMounthTankRight = Regex.Match(ABCompareStatRightTankGameTime_, regexMounth, RegexOptions.IgnoreCase);
                    Match matchDayAndHoursTankRight = Regex.Match(ABCompareStatRightTankGameTime_, regexDayAndHour, RegexOptions.IgnoreCase);
                    Match matchHoursAndMinutesTankRight = Regex.Match(ABCompareStatRightTankGameTime_, regexHourAndMin, RegexOptions.IgnoreCase);

                    if (matchMounthTankRight.Success)
                    {
                        string totalTime_ = regexOnlyNumbersWithDots.Replace(ABCompareStatRightTankGameTime_, "");
                        CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                        var totalTime = Convert.ToDouble(totalTime_);
                        Thread.CurrentThread.CurrentCulture = temp_culture;
                        rightTankGameTimeColor = totalTime * 720;
                    }
                    else
                    if (matchDayAndHoursTankRight.Success)
                    {
                        var time = TimeSpan.ParseExact(ABCompareStatRightTankGameTime_, "d'д 'h'ч'", null);
                        rightTankGameTimeColor = time.TotalHours;
                    }
                    else
                    if (matchHoursAndMinutesTankRight.Success)
                    {
                        var time = TimeSpan.ParseExact(ABCompareStatRightTankGameTime_, "h'ч 'm'мин'", null);
                        rightTankGameTimeColor = time.TotalHours;
                    }


                    #endregion

                  

                    #endregion

                    #region Флот


                    if (ABCompareStatLeftShipKB > ABCompareStatRightShipKB)
                    {
                        _CompareStatLeftShipKB.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                        _CompareStatRightShipKB.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    }
                    else
                   if (ABCompareStatLeftShipKB < ABCompareStatRightShipKB)
                    {
                        _CompareStatLeftShipKB.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                        _CompareStatRightShipKB.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    }
                    else if (ABCompareStatLeftShipKB == ABCompareStatRightShipKB)
                    {
                        _CompareStatLeftShipKB.SetBackgroundResource(Resource.Drawable._gradientEqual);
                        _CompareStatRightShipKB.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    }



                    var BattleNumberLeftShipColor = Convert.ToDouble(ABBattleNumberLeftShip);
                    var BattleNumberRightShipColor = Convert.ToDouble(ABBattleNumberRightShip);

                    if (BattleNumberLeftShipColor > BattleNumberRightShipColor)
                    {
                        _CompareStatLeftShipMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                        _CompareStatRightShipMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    }
                    else
               if (BattleNumberLeftShipColor < BattleNumberRightShipColor)
                    {
                        _CompareStatLeftShipMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                        _CompareStatRightShipMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    }
                    else if (BattleNumberLeftShipColor == BattleNumberRightShipColor)
                    {
                        _CompareStatLeftShipMatchNumber.SetBackgroundResource(Resource.Drawable._gradientEqual);
                        _CompareStatRightShipMatchNumber.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    }


                    #region Конвертер игрового времени в часы для подсветки цветом. Слева


                    Match matchMounthShipLeft = Regex.Match(ABCompareStatLeftShipGameTime_, regexMounth, RegexOptions.IgnoreCase);
                    Match matchDayAndHoursShipLeft = Regex.Match(ABCompareStatLeftShipGameTime_, regexDayAndHour, RegexOptions.IgnoreCase);
                    Match matchHoursAndMinutesShipLeft = Regex.Match(ABCompareStatLeftShipGameTime_, regexHourAndMin, RegexOptions.IgnoreCase);

                    if (matchMounthShipLeft.Success)
                    {
                        string totalTime_ = regexOnlyNumbersWithDots.Replace(ABCompareStatLeftShipGameTime_, "");
                        CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                        var totalTime = Convert.ToDouble(totalTime_);
                        Thread.CurrentThread.CurrentCulture = temp_culture;
                        leftShipGameTimeColor = totalTime * 720;
                    }
                    else
                    if (matchDayAndHoursShipLeft.Success)
                    {
                        var time = TimeSpan.ParseExact(ABCompareStatLeftShipGameTime_, "d'д 'h'ч'", null);
                        leftShipGameTimeColor = time.TotalHours;
                    }
                    else
                    if (matchHoursAndMinutesShipLeft.Success)
                    {
                        var time = TimeSpan.ParseExact(ABCompareStatLeftShipGameTime_, "h'ч 'm'мин'", null);
                        leftShipGameTimeColor = time.TotalHours;
                    }


                    #endregion
                    #region Конвертер игрового времени в часы для подсветки цветом. Справа


                    Match matchMounthShipRight = Regex.Match(ABCompareStatRightShipGameTime_, regexMounth, RegexOptions.IgnoreCase);
                    Match matchDayAndHoursShipRight = Regex.Match(ABCompareStatRightShipGameTime_, regexDayAndHour, RegexOptions.IgnoreCase);
                    Match matchHoursAndMinutesShipRight = Regex.Match(ABCompareStatRightShipGameTime_, regexHourAndMin, RegexOptions.IgnoreCase);

                    if (matchMounthShipRight.Success)
                    {
                        string totalTime_ = regexOnlyNumbersWithDots.Replace(ABCompareStatRightShipGameTime_, "");
                        CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                        var totalTime = Convert.ToDouble(totalTime_);
                        Thread.CurrentThread.CurrentCulture = temp_culture;
                        rightShipGameTimeColor = totalTime * 720;
                    }
                    else
                    if (matchDayAndHoursShipRight.Success)
                    {
                        var time = TimeSpan.ParseExact(ABCompareStatRightShipGameTime_, "d'д 'h'ч'", null);
                        rightShipGameTimeColor = time.TotalHours;
                    }
                    else
                    if (matchHoursAndMinutesShipRight.Success)
                    {
                        var time = TimeSpan.ParseExact(ABCompareStatRightShipGameTime_, "h'ч 'm'мин'", null);
                        rightShipGameTimeColor = time.TotalHours;
                    }


                    #endregion

         

                    #endregion
                }
                else

                if (selectedGameMode == 1)
                {
                    #region Процент побед

                    var CompareStatLeftWinRateColor_ = regexOnlyNumbers.Replace(RBCompareStatLeftWinRate, "");
                    var CompareStatRightWinRateColor_ = regexOnlyNumbers.Replace(RBCompareStatRightWinRate, "");

                    var CompareStatLeftWinRateColor = Convert.ToDouble(CompareStatLeftWinRateColor_);
                    var CompareStatRightWinRateColor = Convert.ToDouble(CompareStatRightWinRateColor_);

                    if (CompareStatLeftWinRateColor > CompareStatRightWinRateColor)
                    {
                        _CompareStatLeftWinRate.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                        _CompareStatRightWinRate.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    }
                    else
                   if (CompareStatLeftWinRateColor < CompareStatRightWinRateColor)
                    {
                        _CompareStatLeftWinRate.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                        _CompareStatRightWinRate.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    }
                    else if (CompareStatLeftWinRateColor == CompareStatRightWinRateColor)
                    {
                        _CompareStatLeftWinRate.SetBackgroundResource(Resource.Drawable._gradientEqual);
                        _CompareStatRightWinRate.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    }

                    #endregion

                    #region Авиация


                    if (RBCompareStatLeftAviaKB > RBCompareStatRightAviaKB)
                    {
                        _CompareStatLeftAviaKB.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                        _CompareStatRightAviaKB.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    }
                    else
                   if (RBCompareStatLeftAviaKB < RBCompareStatRightAviaKB)
                    {
                        _CompareStatLeftAviaKB.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                        _CompareStatRightAviaKB.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    }
                    else if (RBCompareStatLeftAviaKB == RBCompareStatRightAviaKB)
                    {
                        _CompareStatLeftAviaKB.SetBackgroundResource(Resource.Drawable._gradientEqual);
                        _CompareStatRightAviaKB.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    }



                    var BattleNumberLeftAviaColor = Convert.ToDouble(RBBattleNumberLeftAvia);
                    var BattleNumberRightAviaColor = Convert.ToDouble(RBBattleNumberRightAvia);

                    if (BattleNumberLeftAviaColor > BattleNumberRightAviaColor)
                    {
                        _CompareStatLeftAviaMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                        _CompareStatRightAviaMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    }
                    else
               if (BattleNumberLeftAviaColor < BattleNumberRightAviaColor)
                    {
                        _CompareStatLeftAviaMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                        _CompareStatRightAviaMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    }
                    else if (BattleNumberLeftAviaColor == BattleNumberRightAviaColor)
                    {
                        _CompareStatLeftAviaMatchNumber.SetBackgroundResource(Resource.Drawable._gradientEqual);
                        _CompareStatRightAviaMatchNumber.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    }


                    #region Конвертер игрового времени в часы для подсветки цветом. Слева


                    Match matchMounthAviaLeft = Regex.Match(RBCompareStatLeftAviaGameTime_, regexMounth, RegexOptions.IgnoreCase);
                    Match matchDayAndHoursAviaLeft = Regex.Match(RBCompareStatLeftAviaGameTime_, regexDayAndHour, RegexOptions.IgnoreCase);
                    Match matchHoursAndMinutesAviaLeft = Regex.Match(RBCompareStatLeftAviaGameTime_, regexHourAndMin, RegexOptions.IgnoreCase);

                    if (matchMounthAviaLeft.Success)
                    {
                        string totalTime_ = regexOnlyNumbersWithDots.Replace(RBCompareStatLeftAviaGameTime_, "");
                        CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                        var totalTime = Convert.ToDouble(totalTime_);
                        Thread.CurrentThread.CurrentCulture = temp_culture;
                        leftAviaGameTimeColor = totalTime * 720;
                    }
                    else
                    if (matchDayAndHoursAviaLeft.Success)
                    {
                        var time = TimeSpan.ParseExact(RBCompareStatLeftAviaGameTime_, "d'д 'h'ч'", null);
                        leftAviaGameTimeColor = time.TotalHours;
                    }
                    else
                    if (matchHoursAndMinutesAviaLeft.Success)
                    {
                        var time = TimeSpan.ParseExact(RBCompareStatLeftAviaGameTime_, "h'ч 'm'мин'", null);
                        leftAviaGameTimeColor = time.TotalHours;
                    }


                    #endregion
                    #region Конвертер игрового времени в часы для подсветки цветом. Справа


                    Match matchMounthAviaRight = Regex.Match(RBCompareStatRightAviaGameTime_, regexMounth, RegexOptions.IgnoreCase);
                    Match matchDayAndHoursAviaRight = Regex.Match(RBCompareStatRightAviaGameTime_, regexDayAndHour, RegexOptions.IgnoreCase);
                    Match matchHoursAndMinutesAviaRight = Regex.Match(RBCompareStatRightAviaGameTime_, regexHourAndMin, RegexOptions.IgnoreCase);

                    if (matchMounthAviaRight.Success)
                    {
                        string totalTime_ = regexOnlyNumbersWithDots.Replace(RBCompareStatRightAviaGameTime_, "");
                        CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                        var totalTime = Convert.ToDouble(totalTime_);
                        Thread.CurrentThread.CurrentCulture = temp_culture;
                        rightAviaGameTimeColor = totalTime * 720;
                    }
                    else
                    if (matchDayAndHoursAviaRight.Success)
                    {
                        var time = TimeSpan.ParseExact(RBCompareStatRightAviaGameTime_, "d'д 'h'ч'", null);
                        rightAviaGameTimeColor = time.TotalHours;
                    }
                    else
                    if (matchHoursAndMinutesAviaRight.Success)
                    {
                        var time = TimeSpan.ParseExact(RBCompareStatRightAviaGameTime_, "h'ч 'm'мин'", null);
                        rightAviaGameTimeColor = time.TotalHours;
                    }


                    #endregion

              

                    #endregion

                    #region Танки


                    if (RBCompareStatLeftTankKB > RBCompareStatRightTankKB)
                    {
                        _CompareStatLeftTankKB.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                        _CompareStatRightTankKB.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    }
                    else
                   if (RBCompareStatLeftTankKB < RBCompareStatRightTankKB)
                    {
                        _CompareStatLeftTankKB.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                        _CompareStatRightTankKB.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    }
                    else if (RBCompareStatLeftTankKB == RBCompareStatRightTankKB)
                    {
                        _CompareStatLeftTankKB.SetBackgroundResource(Resource.Drawable._gradientEqual);
                        _CompareStatRightTankKB.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    }



                    var BattleNumberLeftTankColor = Convert.ToDouble(RBBattleNumberLeftTank);
                    var BattleNumberRightTankColor = Convert.ToDouble(RBBattleNumberRightTank);

                    if (BattleNumberLeftTankColor > BattleNumberRightTankColor)
                    {
                        _CompareStatLeftTankMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                        _CompareStatRightTankMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    }
                    else
               if (BattleNumberLeftTankColor < BattleNumberRightTankColor)
                    {
                        _CompareStatLeftTankMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                        _CompareStatRightTankMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    }
                    else if (BattleNumberLeftTankColor == BattleNumberRightTankColor)
                    {
                        _CompareStatLeftTankMatchNumber.SetBackgroundResource(Resource.Drawable._gradientEqual);
                        _CompareStatRightTankMatchNumber.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    }


                    #region Конвертер игрового времени в часы для подсветки цветом. Слева


                    Match matchMounthTankLeft = Regex.Match(RBCompareStatLeftTankGameTime_, regexMounth, RegexOptions.IgnoreCase);
                    Match matchDayAndHoursTankLeft = Regex.Match(RBCompareStatLeftTankGameTime_, regexDayAndHour, RegexOptions.IgnoreCase);
                    Match matchHoursAndMinutesTankLeft = Regex.Match(RBCompareStatLeftTankGameTime_, regexHourAndMin, RegexOptions.IgnoreCase);

                    if (matchMounthTankLeft.Success)
                    {
                        string totalTime_ = regexOnlyNumbersWithDots.Replace(RBCompareStatLeftTankGameTime_, "");
                        CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                        var totalTime = Convert.ToDouble(totalTime_);
                        Thread.CurrentThread.CurrentCulture = temp_culture;
                        leftTankGameTimeColor = totalTime * 720;
                    }
                    else
                    if (matchDayAndHoursTankLeft.Success)
                    {
                        var time = TimeSpan.ParseExact(RBCompareStatLeftTankGameTime_, "d'д 'h'ч'", null);
                        leftTankGameTimeColor = time.TotalHours;
                    }
                    else
                    if (matchHoursAndMinutesTankLeft.Success)
                    {
                        var time = TimeSpan.ParseExact(RBCompareStatLeftTankGameTime_, "h'ч 'm'мин'", null);
                        leftTankGameTimeColor = time.TotalHours;
                    }


                    #endregion
                    #region Конвертер игрового времени в часы для подсветки цветом. Справа


                    Match matchMounthTankRight = Regex.Match(RBCompareStatRightTankGameTime_, regexMounth, RegexOptions.IgnoreCase);
                    Match matchDayAndHoursTankRight = Regex.Match(RBCompareStatRightTankGameTime_, regexDayAndHour, RegexOptions.IgnoreCase);
                    Match matchHoursAndMinutesTankRight = Regex.Match(RBCompareStatRightTankGameTime_, regexHourAndMin, RegexOptions.IgnoreCase);

                    if (matchMounthTankRight.Success)
                    {
                        string totalTime_ = regexOnlyNumbersWithDots.Replace(RBCompareStatRightTankGameTime_, "");
                        CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                        var totalTime = Convert.ToDouble(totalTime_);
                        Thread.CurrentThread.CurrentCulture = temp_culture;
                        rightTankGameTimeColor = totalTime * 720;
                    }
                    else
                    if (matchDayAndHoursTankRight.Success)
                    {
                        var time = TimeSpan.ParseExact(RBCompareStatRightTankGameTime_, "d'д 'h'ч'", null);
                        rightTankGameTimeColor = time.TotalHours;
                    }
                    else
                    if (matchHoursAndMinutesTankRight.Success)
                    {
                        var time = TimeSpan.ParseExact(RBCompareStatRightTankGameTime_, "h'ч 'm'мин'", null);
                        rightTankGameTimeColor = time.TotalHours;
                    }


                    #endregion

                
                    #endregion

                    #region Флот


                    if (RBCompareStatLeftShipKB > RBCompareStatRightShipKB)
                    {
                        _CompareStatLeftShipKB.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                        _CompareStatRightShipKB.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    }
                    else
                   if (RBCompareStatLeftShipKB < RBCompareStatRightShipKB)
                    {
                        _CompareStatLeftShipKB.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                        _CompareStatRightShipKB.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    }
                    else if (RBCompareStatLeftShipKB == RBCompareStatRightShipKB)
                    {
                        _CompareStatLeftShipKB.SetBackgroundResource(Resource.Drawable._gradientEqual);
                        _CompareStatRightShipKB.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    }



                    var BattleNumberLeftShipColor = Convert.ToDouble(RBBattleNumberLeftShip);
                    var BattleNumberRightShipColor = Convert.ToDouble(RBBattleNumberRightShip);

                    if (BattleNumberLeftShipColor > BattleNumberRightShipColor)
                    {
                        _CompareStatLeftShipMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                        _CompareStatRightShipMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    }
                    else
               if (BattleNumberLeftShipColor < BattleNumberRightShipColor)
                    {
                        _CompareStatLeftShipMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                        _CompareStatRightShipMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    }
                    else if (BattleNumberLeftShipColor == BattleNumberRightShipColor)
                    {
                        _CompareStatLeftShipMatchNumber.SetBackgroundResource(Resource.Drawable._gradientEqual);
                        _CompareStatRightShipMatchNumber.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    }


                    #region Конвертер игрового времени в часы для подсветки цветом. Слева


                    Match matchMounthShipLeft = Regex.Match(RBCompareStatLeftShipGameTime_, regexMounth, RegexOptions.IgnoreCase);
                    Match matchDayAndHoursShipLeft = Regex.Match(RBCompareStatLeftShipGameTime_, regexDayAndHour, RegexOptions.IgnoreCase);
                    Match matchHoursAndMinutesShipLeft = Regex.Match(RBCompareStatLeftShipGameTime_, regexHourAndMin, RegexOptions.IgnoreCase);

                    if (matchMounthShipLeft.Success)
                    {
                        string totalTime_ = regexOnlyNumbersWithDots.Replace(RBCompareStatLeftShipGameTime_, "");
                        CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                        var totalTime = Convert.ToDouble(totalTime_);
                        Thread.CurrentThread.CurrentCulture = temp_culture;
                        leftShipGameTimeColor = totalTime * 720;
                    }
                    else
                    if (matchDayAndHoursShipLeft.Success)
                    {
                        var time = TimeSpan.ParseExact(RBCompareStatLeftShipGameTime_, "d'д 'h'ч'", null);
                        leftShipGameTimeColor = time.TotalHours;
                    }
                    else
                    if (matchHoursAndMinutesShipLeft.Success)
                    {
                        var time = TimeSpan.ParseExact(RBCompareStatLeftShipGameTime_, "h'ч 'm'мин'", null);
                        leftShipGameTimeColor = time.TotalHours;
                    }


                    #endregion
                    #region Конвертер игрового времени в часы для подсветки цветом. Справа


                    Match matchMounthShipRight = Regex.Match(RBCompareStatRightShipGameTime_, regexMounth, RegexOptions.IgnoreCase);
                    Match matchDayAndHoursShipRight = Regex.Match(RBCompareStatRightShipGameTime_, regexDayAndHour, RegexOptions.IgnoreCase);
                    Match matchHoursAndMinutesShipRight = Regex.Match(RBCompareStatRightShipGameTime_, regexHourAndMin, RegexOptions.IgnoreCase);

                    if (matchMounthShipRight.Success)
                    {
                        string totalTime_ = regexOnlyNumbersWithDots.Replace(RBCompareStatRightShipGameTime_, "");
                        CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                        var totalTime = Convert.ToDouble(totalTime_);
                        Thread.CurrentThread.CurrentCulture = temp_culture;
                        rightShipGameTimeColor = totalTime * 720;
                    }
                    else
                    if (matchDayAndHoursShipRight.Success)
                    {
                        var time = TimeSpan.ParseExact(RBCompareStatRightShipGameTime_, "d'д 'h'ч'", null);
                        rightShipGameTimeColor = time.TotalHours;
                    }
                    else
                    if (matchHoursAndMinutesShipRight.Success)
                    {
                        var time = TimeSpan.ParseExact(RBCompareStatRightShipGameTime_, "h'ч 'm'мин'", null);
                        rightShipGameTimeColor = time.TotalHours;
                    }


                    #endregion

                 

                    #endregion
                }
                else

                if (selectedGameMode == 2)
                {
                    #region Процент побед

                    var CompareStatLeftWinRateColor_ = regexOnlyNumbers.Replace(SBCompareStatLeftWinRate, "");
                    var CompareStatRightWinRateColor_ = regexOnlyNumbers.Replace(SBCompareStatRightWinRate, "");

                    var CompareStatLeftWinRateColor = Convert.ToDouble(CompareStatLeftWinRateColor_);
                    var CompareStatRightWinRateColor = Convert.ToDouble(CompareStatRightWinRateColor_);

                    if (CompareStatLeftWinRateColor > CompareStatRightWinRateColor)
                    {
                        _CompareStatLeftWinRate.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                        _CompareStatRightWinRate.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    }
                    else
                   if (CompareStatLeftWinRateColor < CompareStatRightWinRateColor)
                    {
                        _CompareStatLeftWinRate.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                        _CompareStatRightWinRate.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    }
                    else if (CompareStatLeftWinRateColor == CompareStatRightWinRateColor)
                    {
                        _CompareStatLeftWinRate.SetBackgroundResource(Resource.Drawable._gradientEqual);
                        _CompareStatRightWinRate.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    }

                    #endregion

                    #region Авиация


                    if (SBCompareStatLeftAviaKB > SBCompareStatRightAviaKB)
                    {
                        _CompareStatLeftAviaKB.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                        _CompareStatRightAviaKB.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    }
                    else
                   if (SBCompareStatLeftAviaKB < SBCompareStatRightAviaKB)
                    {
                        _CompareStatLeftAviaKB.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                        _CompareStatRightAviaKB.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    }
                    else if (SBCompareStatLeftAviaKB == SBCompareStatRightAviaKB)
                    {
                        _CompareStatLeftAviaKB.SetBackgroundResource(Resource.Drawable._gradientEqual);
                        _CompareStatRightAviaKB.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    }



                    var BattleNumberLeftAviaColor = Convert.ToDouble(SBBattleNumberLeftAvia);
                    var BattleNumberRightAviaColor = Convert.ToDouble(SBBattleNumberRightAvia);

                    if (BattleNumberLeftAviaColor > BattleNumberRightAviaColor)
                    {
                        _CompareStatLeftAviaMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                        _CompareStatRightAviaMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    }
                    else
               if (BattleNumberLeftAviaColor < BattleNumberRightAviaColor)
                    {
                        _CompareStatLeftAviaMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                        _CompareStatRightAviaMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    }
                    else if (BattleNumberLeftAviaColor == BattleNumberRightAviaColor)
                    {
                        _CompareStatLeftAviaMatchNumber.SetBackgroundResource(Resource.Drawable._gradientEqual);
                        _CompareStatRightAviaMatchNumber.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    }


                    #region Конвертер игрового времени в часы для подсветки цветом. Слева


                    Match matchMounthAviaLeft = Regex.Match(SBCompareStatLeftAviaGameTime_, regexMounth, RegexOptions.IgnoreCase);
                    Match matchDayAndHoursAviaLeft = Regex.Match(SBCompareStatLeftAviaGameTime_, regexDayAndHour, RegexOptions.IgnoreCase);
                    Match matchHoursAndMinutesAviaLeft = Regex.Match(SBCompareStatLeftAviaGameTime_, regexHourAndMin, RegexOptions.IgnoreCase);

                    if (matchMounthAviaLeft.Success)
                    {
                        string totalTime_ = regexOnlyNumbersWithDots.Replace(SBCompareStatLeftAviaGameTime_, "");
                        CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                        var totalTime = Convert.ToDouble(totalTime_);
                        Thread.CurrentThread.CurrentCulture = temp_culture;
                        leftAviaGameTimeColor = totalTime * 720;
                    }
                    else
                    if (matchDayAndHoursAviaLeft.Success)
                    {
                        var time = TimeSpan.ParseExact(SBCompareStatLeftAviaGameTime_, "d'д 'h'ч'", null);
                        leftAviaGameTimeColor = time.TotalHours;
                    }
                    else
                    if (matchHoursAndMinutesAviaLeft.Success)
                    {
                        var time = TimeSpan.ParseExact(SBCompareStatLeftAviaGameTime_, "h'ч 'm'мин'", null);
                        leftAviaGameTimeColor = time.TotalHours;
                    }


                    #endregion
                    #region Конвертер игрового времени в часы для подсветки цветом. Справа


                    Match matchMounthAviaRight = Regex.Match(SBCompareStatRightAviaGameTime_, regexMounth, RegexOptions.IgnoreCase);
                    Match matchDayAndHoursAviaRight = Regex.Match(SBCompareStatRightAviaGameTime_, regexDayAndHour, RegexOptions.IgnoreCase);
                    Match matchHoursAndMinutesAviaRight = Regex.Match(SBCompareStatRightAviaGameTime_, regexHourAndMin, RegexOptions.IgnoreCase);

                    if (matchMounthAviaRight.Success)
                    {
                        string totalTime_ = regexOnlyNumbersWithDots.Replace(SBCompareStatRightAviaGameTime_, "");
                        CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                        var totalTime = Convert.ToDouble(totalTime_);
                        Thread.CurrentThread.CurrentCulture = temp_culture;
                        rightAviaGameTimeColor = totalTime * 720;
                    }
                    else
                    if (matchDayAndHoursAviaRight.Success)
                    {
                        var time = TimeSpan.ParseExact(SBCompareStatRightAviaGameTime_, "d'д 'h'ч'", null);
                        rightAviaGameTimeColor = time.TotalHours;
                    }
                    else
                    if (matchHoursAndMinutesAviaRight.Success)
                    {
                        var time = TimeSpan.ParseExact(SBCompareStatRightAviaGameTime_, "h'ч 'm'мин'", null);
                        rightAviaGameTimeColor = time.TotalHours;
                    }


                    #endregion

                   

                    #endregion

                    #region Танки


                    if (SBCompareStatLeftTankKB > SBCompareStatRightTankKB)
                    {
                        _CompareStatLeftTankKB.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                        _CompareStatRightTankKB.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    }
                    else
                   if (SBCompareStatLeftTankKB < SBCompareStatRightTankKB)
                    {
                        _CompareStatLeftTankKB.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                        _CompareStatRightTankKB.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    }
                    else if (SBCompareStatLeftTankKB == SBCompareStatRightTankKB)
                    {
                        _CompareStatLeftTankKB.SetBackgroundResource(Resource.Drawable._gradientEqual);
                        _CompareStatRightTankKB.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    }



                    var BattleNumberLeftTankColor = Convert.ToDouble(SBBattleNumberLeftTank);
                    var BattleNumberRightTankColor = Convert.ToDouble(SBBattleNumberRightTank);

                    if (BattleNumberLeftTankColor > BattleNumberRightTankColor)
                    {
                        _CompareStatLeftTankMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                        _CompareStatRightTankMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    }
                    else
               if (BattleNumberLeftTankColor < BattleNumberRightTankColor)
                    {
                        _CompareStatLeftTankMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                        _CompareStatRightTankMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    }
                    else if (BattleNumberLeftTankColor == BattleNumberRightTankColor)
                    {
                        _CompareStatLeftTankMatchNumber.SetBackgroundResource(Resource.Drawable._gradientEqual);
                        _CompareStatRightTankMatchNumber.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    }


                    #region Конвертер игрового времени в часы для подсветки цветом. Слева


                    Match matchMounthTankLeft = Regex.Match(SBCompareStatLeftTankGameTime_, regexMounth, RegexOptions.IgnoreCase);
                    Match matchDayAndHoursTankLeft = Regex.Match(SBCompareStatLeftTankGameTime_, regexDayAndHour, RegexOptions.IgnoreCase);
                    Match matchHoursAndMinutesTankLeft = Regex.Match(SBCompareStatLeftTankGameTime_, regexHourAndMin, RegexOptions.IgnoreCase);

                    if (matchMounthTankLeft.Success)
                    {
                        string totalTime_ = regexOnlyNumbersWithDots.Replace(SBCompareStatLeftTankGameTime_, "");
                        CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                        var totalTime = Convert.ToDouble(totalTime_);
                        Thread.CurrentThread.CurrentCulture = temp_culture;
                        leftTankGameTimeColor = totalTime * 720;
                    }
                    else
                    if (matchDayAndHoursTankLeft.Success)
                    {
                        var time = TimeSpan.ParseExact(SBCompareStatLeftTankGameTime_, "d'д 'h'ч'", null);
                        leftTankGameTimeColor = time.TotalHours;
                    }
                    else
                    if (matchHoursAndMinutesTankLeft.Success)
                    {
                        var time = TimeSpan.ParseExact(SBCompareStatLeftTankGameTime_, "h'ч 'm'мин'", null);
                        leftTankGameTimeColor = time.TotalHours;
                    }


                    #endregion
                    #region Конвертер игрового времени в часы для подсветки цветом. Справа


                    Match matchMounthTankRight = Regex.Match(SBCompareStatRightTankGameTime_, regexMounth, RegexOptions.IgnoreCase);
                    Match matchDayAndHoursTankRight = Regex.Match(SBCompareStatRightTankGameTime_, regexDayAndHour, RegexOptions.IgnoreCase);
                    Match matchHoursAndMinutesTankRight = Regex.Match(SBCompareStatRightTankGameTime_, regexHourAndMin, RegexOptions.IgnoreCase);

                    if (matchMounthTankRight.Success)
                    {
                        string totalTime_ = regexOnlyNumbersWithDots.Replace(SBCompareStatRightTankGameTime_, "");
                        CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                        var totalTime = Convert.ToDouble(totalTime_);
                        Thread.CurrentThread.CurrentCulture = temp_culture;
                        rightTankGameTimeColor = totalTime * 720;
                    }
                    else
                    if (matchDayAndHoursTankRight.Success)
                    {
                        var time = TimeSpan.ParseExact(SBCompareStatRightTankGameTime_, "d'д 'h'ч'", null);
                        rightTankGameTimeColor = time.TotalHours;
                    }
                    else
                    if (matchHoursAndMinutesTankRight.Success)
                    {
                        var time = TimeSpan.ParseExact(SBCompareStatRightTankGameTime_, "h'ч 'm'мин'", null);
                        rightTankGameTimeColor = time.TotalHours;
                    }


                    #endregion

                    #endregion

                    #region Флот


                    if (SBCompareStatLeftShipKB > SBCompareStatRightShipKB)
                    {
                        _CompareStatLeftShipKB.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                        _CompareStatRightShipKB.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    }
                    else
                   if (SBCompareStatLeftShipKB < SBCompareStatRightShipKB)
                    {
                        _CompareStatLeftShipKB.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                        _CompareStatRightShipKB.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    }
                    else if (SBCompareStatLeftShipKB == SBCompareStatRightShipKB)
                    {
                        _CompareStatLeftShipKB.SetBackgroundResource(Resource.Drawable._gradientEqual);
                        _CompareStatRightShipKB.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    }



                    var BattleNumberLeftShipColor = Convert.ToDouble(SBBattleNumberLeftShip);
                    var BattleNumberRightShipColor = Convert.ToDouble(SBBattleNumberRightShip);

                    if (BattleNumberLeftShipColor > BattleNumberRightShipColor)
                    {
                        _CompareStatLeftShipMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                        _CompareStatRightShipMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    }
                    else
               if (BattleNumberLeftShipColor < BattleNumberRightShipColor)
                    {
                        _CompareStatLeftShipMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                        _CompareStatRightShipMatchNumber.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    }
                    else if (BattleNumberLeftShipColor == BattleNumberRightShipColor)
                    {
                        _CompareStatLeftShipMatchNumber.SetBackgroundResource(Resource.Drawable._gradientEqual);
                        _CompareStatRightShipMatchNumber.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    }


                    #region Конвертер игрового времени в часы для подсветки цветом. Слева


                    Match matchMounthShipLeft = Regex.Match(SBCompareStatLeftShipGameTime_, regexMounth, RegexOptions.IgnoreCase);
                    Match matchDayAndHoursShipLeft = Regex.Match(SBCompareStatLeftShipGameTime_, regexDayAndHour, RegexOptions.IgnoreCase);
                    Match matchHoursAndMinutesShipLeft = Regex.Match(SBCompareStatLeftShipGameTime_, regexHourAndMin, RegexOptions.IgnoreCase);

                    if (matchMounthShipLeft.Success)
                    {
                        string totalTime_ = regexOnlyNumbersWithDots.Replace(SBCompareStatLeftShipGameTime_, "");
                        CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                        var totalTime = Convert.ToDouble(totalTime_);
                        Thread.CurrentThread.CurrentCulture = temp_culture;
                        leftShipGameTimeColor = totalTime * 720;
                    }
                    else
                    if (matchDayAndHoursShipLeft.Success)
                    {
                        var time = TimeSpan.ParseExact(SBCompareStatLeftShipGameTime_, "d'д 'h'ч'", null);
                        leftShipGameTimeColor = time.TotalHours;
                    }
                    else
                    if (matchHoursAndMinutesShipLeft.Success)
                    {
                        var time = TimeSpan.ParseExact(SBCompareStatLeftShipGameTime_, "h'ч 'm'мин'", null);
                        leftShipGameTimeColor = time.TotalHours;
                    }


                    #endregion
                    #region Конвертер игрового времени в часы для подсветки цветом. Справа


                    Match matchMounthShipRight = Regex.Match(SBCompareStatRightShipGameTime_, regexMounth, RegexOptions.IgnoreCase);
                    Match matchDayAndHoursShipRight = Regex.Match(SBCompareStatRightShipGameTime_, regexDayAndHour, RegexOptions.IgnoreCase);
                    Match matchHoursAndMinutesShipRight = Regex.Match(SBCompareStatRightShipGameTime_, regexHourAndMin, RegexOptions.IgnoreCase);

                    if (matchMounthShipRight.Success)
                    {
                        string totalTime_ = regexOnlyNumbersWithDots.Replace(SBCompareStatRightShipGameTime_, "");
                        CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                        var totalTime = Convert.ToDouble(totalTime_);
                        Thread.CurrentThread.CurrentCulture = temp_culture;
                        rightShipGameTimeColor = totalTime * 720;
                    }
                    else
                    if (matchDayAndHoursShipRight.Success)
                    {
                        var time = TimeSpan.ParseExact(SBCompareStatRightShipGameTime_, "d'д 'h'ч'", null);
                        rightShipGameTimeColor = time.TotalHours;
                    }
                    else
                    if (matchHoursAndMinutesShipRight.Success)
                    {
                        var time = TimeSpan.ParseExact(SBCompareStatRightShipGameTime_, "h'ч 'm'мин'", null);
                        rightShipGameTimeColor = time.TotalHours;
                    }


                    #endregion

                

                    #endregion
                }
                
                #region Количество техники

                var CompareStatLeftUSAVehicleColor = Convert.ToDouble(CompareStatLeftUSAVehicle);
                var CompareStatRightUSAVehicleColor = Convert.ToDouble(CompareStatRightUSAVehicle);

                if (CompareStatLeftUSAVehicleColor > CompareStatRightUSAVehicleColor)
                {
                    _CompareStatLeftUSAVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareGreen);
                    _CompareStatLeftUSASpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                    _CompareStatRightUSAVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    _CompareStatRightUSASpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRed);
                }
                else
            if (CompareStatLeftUSAVehicleColor < CompareStatRightUSAVehicleColor)
                {
                    _CompareStatLeftUSAVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRed);
                    _CompareStatLeftUSASpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                    _CompareStatRightUSAVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    _CompareStatRightUSASpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareGreen);
                }
                else if (CompareStatLeftUSAVehicleColor == CompareStatRightUSAVehicleColor)
                {
                    _CompareStatLeftUSAVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    _CompareStatRightUSAVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    _CompareStatLeftUSASpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    _CompareStatRightUSASpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);


                }




                var CompareStatLeftGermanyVehicleColor = Convert.ToDouble(CompareStatLeftGermanyVehicle);
                var CompareStatRightGermanyVehicleColor = Convert.ToDouble(CompareStatRightGermanyVehicle);

                if (CompareStatLeftGermanyVehicleColor > CompareStatRightGermanyVehicleColor)
                {
                    _CompareStatLeftGermanyVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareGreen);
                    _CompareStatLeftGermanySpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                    _CompareStatRightGermanyVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    _CompareStatRightGermanySpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRed);
                }
                else
            if (CompareStatLeftGermanyVehicleColor < CompareStatRightGermanyVehicleColor)
                {
                    _CompareStatLeftGermanyVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRed);
                    _CompareStatLeftGermanySpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                    _CompareStatRightGermanyVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    _CompareStatRightGermanySpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareGreen);
                }
                else if (CompareStatLeftGermanyVehicleColor == CompareStatRightGermanyVehicleColor)
                {
                    _CompareStatLeftGermanyVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    _CompareStatRightGermanyVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    _CompareStatLeftGermanySpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    _CompareStatRightGermanySpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                }



                var CompareStatLeftUSSRVehicleColor = Convert.ToDouble(CompareStatLeftUSSRVehicle);
                var CompareStatRightUSSRVehicleColor = Convert.ToDouble(CompareStatRightUSSRVehicle);

                if (CompareStatLeftUSSRVehicleColor > CompareStatRightUSSRVehicleColor)
                {
                    _CompareStatLeftUSSRVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareGreen);
                    _CompareStatLeftUSSRSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                    _CompareStatRightUSSRVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    _CompareStatRightUSSRSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRed);
                }
                else
            if (CompareStatLeftUSSRVehicleColor < CompareStatRightUSSRVehicleColor)
                {
                    _CompareStatLeftUSSRVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRed);
                    _CompareStatLeftUSSRSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                    _CompareStatRightUSSRVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    _CompareStatRightUSSRSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareGreen);
                }
                else if (CompareStatLeftUSSRVehicleColor == CompareStatRightUSSRVehicleColor)
                {
                    _CompareStatLeftUSSRVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    _CompareStatRightUSSRVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    _CompareStatLeftUSSRSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    _CompareStatRightUSSRSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                }



                var CompareStatLeftGBVehicleColor = Convert.ToDouble(CompareStatLeftGBVehicle);
                var CompareStatRightGBVehicleColor = Convert.ToDouble(CompareStatRightGBVehicle);

                if (CompareStatLeftGBVehicleColor > CompareStatRightGBVehicleColor)
                {
                    _CompareStatLeftGBVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareGreen);
                    _CompareStatLeftGBSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                    _CompareStatRightGBVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    _CompareStatRightGBSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRed);
                }
                else
            if (CompareStatLeftGBVehicleColor < CompareStatRightGBVehicleColor)
                {
                    _CompareStatLeftGBVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRed);
                    _CompareStatLeftGBSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                    _CompareStatRightGBVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    _CompareStatRightGBSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareGreen);
                }
                else if (CompareStatLeftGBVehicleColor == CompareStatRightGBVehicleColor)
                {
                    _CompareStatLeftGBVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    _CompareStatRightGBVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    _CompareStatLeftGBSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    _CompareStatRightGBSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                }



                var CompareStatLeftJapanVehicleColor = Convert.ToDouble(CompareStatLeftJapanVehicle);
                var CompareStatRightJapanVehicleColor = Convert.ToDouble(CompareStatRightJapanVehicle);

                if (CompareStatLeftJapanVehicleColor > CompareStatRightJapanVehicleColor)
                {
                    _CompareStatLeftJapanVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareGreen);
                    _CompareStatLeftJapanSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                    _CompareStatRightJapanVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    _CompareStatRightJapanSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRed);
                }
                else
            if (CompareStatLeftJapanVehicleColor < CompareStatRightJapanVehicleColor)
                {
                    _CompareStatLeftJapanVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRed);
                    _CompareStatLeftJapanSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                    _CompareStatRightJapanVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    _CompareStatRightJapanSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareGreen);
                }
                else if (CompareStatLeftJapanVehicleColor == CompareStatRightJapanVehicleColor)
                {
                    _CompareStatLeftJapanVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    _CompareStatRightJapanVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    _CompareStatLeftJapanSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    _CompareStatRightJapanSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                }



                var CompareStatLeftItalyVehicleColor = Convert.ToDouble(CompareStatLeftItalyVehicle);
                var CompareStatRightItalyVehicleColor = Convert.ToDouble(CompareStatRightItalyVehicle);

                if (CompareStatLeftItalyVehicleColor > CompareStatRightItalyVehicleColor)
                {
                    _CompareStatLeftItalyVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareGreen);
                    _CompareStatLeftItalySpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                    _CompareStatRightItalyVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    _CompareStatRightItalySpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRed);
                }
                else
            if (CompareStatLeftItalyVehicleColor < CompareStatRightItalyVehicleColor)
                {
                    _CompareStatLeftItalyVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRed);
                    _CompareStatLeftItalySpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                    _CompareStatRightItalyVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    _CompareStatRightItalySpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareGreen);
                }
                else if (CompareStatLeftItalyVehicleColor == CompareStatRightItalyVehicleColor)
                {
                    _CompareStatLeftItalyVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    _CompareStatRightItalyVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    _CompareStatLeftItalySpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    _CompareStatRightItalySpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                }



                var CompareStatLeftFranceVehicleColor = Convert.ToDouble(CompareStatLeftFranceVehicle);
                var CompareStatRightFranceVehicleColor = Convert.ToDouble(CompareStatRightFranceVehicle);

                if (CompareStatLeftFranceVehicleColor > CompareStatRightFranceVehicleColor)
                {
                    _CompareStatLeftFranceVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareGreen);
                    _CompareStatLeftFranceSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                    _CompareStatRightFranceVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                    _CompareStatRightFranceSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRed);
                }
                else
            if (CompareStatLeftFranceVehicleColor < CompareStatRightFranceVehicleColor)
                {
                    _CompareStatLeftFranceVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRed);
                    _CompareStatLeftFranceSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                    _CompareStatRightFranceVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                    _CompareStatRightFranceSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientForCompareGreen);
                }
                else if (CompareStatLeftFranceVehicleColor == CompareStatRightFranceVehicleColor)
                {
                    _CompareStatLeftFranceVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    _CompareStatRightFranceVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    _CompareStatLeftFranceSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    _CompareStatRightFranceSpadedVehicle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                }

                #endregion
                
                #region Серебро

                if (CompareStatLeftLionEarned > CompareStatRightLionEarned)
                {
                    _CompareStatLeftLionEarned.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                    _CompareStatRightLionEarned.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                }
                else
            if (CompareStatLeftLionEarned < CompareStatRightLionEarned)
                {
                    _CompareStatLeftLionEarned.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                    _CompareStatRightLionEarned.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                }
                else if (CompareStatLeftLionEarned == CompareStatRightLionEarned)
                {
                    _CompareStatLeftLionEarned.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    _CompareStatRightLionEarned.SetBackgroundResource(Resource.Drawable._gradientEqual);
                }

                #endregion

                #region Общее игровое время

                if (leftFullGameTimeColor > rightFullGameTimeColor)
                {
                    _CompareStatLeftFullGameTime.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                    _CompareStatRightFullGameTime.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                }
                else
            if (leftFullGameTimeColor < rightFullGameTimeColor)
                {
                    _CompareStatLeftFullGameTime.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                    _CompareStatRightFullGameTime.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                }
                else if (leftFullGameTimeColor == rightFullGameTimeColor)
                {
                    _CompareStatLeftFullGameTime.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    _CompareStatRightFullGameTime.SetBackgroundResource(Resource.Drawable._gradientEqual);
                }

                #endregion

                #endregion

                _CompareStatLeftMainSkill.SetBackgroundColor(Color.ParseColor("#50000000"));
                _CompareStatLeftMainSkillName.SetBackgroundColor(Color.ParseColor("#50000000"));
                _CompareStatRightMainSkill.SetBackgroundColor(Color.ParseColor("#50000000"));
                _CompareStatRightMainSkillName.SetBackgroundColor(Color.ParseColor("#50000000"));
                //


                #region Левая боевая эффективность
                List <LeftBEList> leftBELists = new List<LeftBEList>();
                var BE_LeftABAviaBattleNumber_ = Convert.ToDouble(ABBattleNumberLeftAvia);
                var BE_LeftABTankBattleNumber_ = Convert.ToDouble(ABBattleNumberLeftTank);
                var BE_LeftABShipBattleNumber_ = Convert.ToDouble(ABBattleNumberLeftShip);
                var BE_LeftRBAviaBattleNumber_ = Convert.ToDouble(RBBattleNumberLeftAvia);
                var BE_LeftRBTankBattleNumber_ = Convert.ToDouble(RBBattleNumberLeftTank);
                var BE_LeftRBShipBattleNumber_ = Convert.ToDouble(RBBattleNumberLeftShip);
                var BE_LeftSBAviaBattleNumber_ = Convert.ToDouble(SBBattleNumberLeftAvia);
                var BE_LeftSBTankBattleNumber_ = Convert.ToDouble(SBBattleNumberLeftTank);
                var BE_LeftSBShipBattleNumber_ = Convert.ToDouble(SBBattleNumberLeftShip);

                if (BE_LeftABAviaBattleNumber_ >= 100)
                {
                    leftBELists.Add(new LeftBEList()
                    {
                        LeftKB = ABCompareStatLeftAviaKB
                    });
                }

                if (BE_LeftABTankBattleNumber_ >= 100)
                {
                    leftBELists.Add(new LeftBEList()
                    {
                        LeftKB = ABCompareStatLeftTankKB
                    });
                }
                
                if (BE_LeftABShipBattleNumber_ >= 100)
                {
                    leftBELists.Add(new LeftBEList()
                    {
                        LeftKB = ABCompareStatLeftShipKB
                    });
                }

                if (BE_LeftRBAviaBattleNumber_ >= 100)
                {
                    leftBELists.Add(new LeftBEList()
                    {
                        LeftKB = RBCompareStatLeftAviaKB
                    });
                }

                if (BE_LeftRBTankBattleNumber_ >= 100)
                {
                    leftBELists.Add(new LeftBEList()
                    {
                        LeftKB = RBCompareStatLeftTankKB
                    });
                }

                if (BE_LeftRBShipBattleNumber_ >= 100)
                {
                    leftBELists.Add(new LeftBEList()
                    {
                        LeftKB = RBCompareStatLeftShipKB
                    });
                }

                if (BE_LeftSBAviaBattleNumber_ >= 100)
                {
                    leftBELists.Add(new LeftBEList()
                    {
                        LeftKB = SBCompareStatLeftAviaKB
                    });
                }

                if (BE_LeftSBTankBattleNumber_ >= 100)
                {
                    leftBELists.Add(new LeftBEList()
                    {
                        LeftKB = SBCompareStatLeftTankKB
                    });
                }

                if (BE_LeftSBShipBattleNumber_ >= 100)
                {
                    leftBELists.Add(new LeftBEList()
                    {
                        LeftKB = SBCompareStatLeftShipKB
                    });
                }

                //////////////
                if (leftBELists.Count == 0)
                {
                    finalLeftBE = 0;
                }
                else
                {
                    double finalLeftBEList = leftBELists.Average(x => x.LeftKB);
                    finalLeftBE = finalLeftBEList * 100; 
                    finalLeftBE = Math.Round(finalLeftBE, 0);
                }
                /////////////////


                #endregion

                #region Правая боевая эффективность
                List<RightBEList> rightBELists = new List<RightBEList>();
                var BE_RightABAviaBattleNumber_ = Convert.ToDouble(ABBattleNumberRightAvia);
                var BE_RightABTankBattleNumber_ = Convert.ToDouble(ABBattleNumberRightTank);
                var BE_RightABShipBattleNumber_ = Convert.ToDouble(ABBattleNumberRightShip);
                var BE_RightRBAviaBattleNumber_ = Convert.ToDouble(RBBattleNumberRightAvia);
                var BE_RightRBTankBattleNumber_ = Convert.ToDouble(RBBattleNumberRightTank);
                var BE_RightRBShipBattleNumber_ = Convert.ToDouble(RBBattleNumberRightShip);
                var BE_RightSBAviaBattleNumber_ = Convert.ToDouble(SBBattleNumberRightAvia);
                var BE_RightSBTankBattleNumber_ = Convert.ToDouble(SBBattleNumberRightTank);
                var BE_RightSBShipBattleNumber_ = Convert.ToDouble(SBBattleNumberRightShip);

                if (BE_RightABAviaBattleNumber_ >= 100)
                {
                    rightBELists.Add(new RightBEList()
                    {
                        RightKB = ABCompareStatRightAviaKB
                    });
                }

                if (BE_RightABTankBattleNumber_ >= 100)
                {
                    rightBELists.Add(new RightBEList()
                    {
                        RightKB = ABCompareStatRightTankKB
                    });
                }

                if (BE_RightABShipBattleNumber_ >= 100)
                {
                    rightBELists.Add(new RightBEList()
                    {
                        RightKB = ABCompareStatRightShipKB
                    });
                }

                if (BE_RightRBAviaBattleNumber_ >= 100)
                {
                    rightBELists.Add(new RightBEList()
                    {
                        RightKB = RBCompareStatRightAviaKB
                    });
                }

                if (BE_RightRBTankBattleNumber_ >= 100)
                {
                    rightBELists.Add(new RightBEList()
                    {
                        RightKB = RBCompareStatRightTankKB
                    });
                }

                if (BE_RightRBShipBattleNumber_ >= 100)
                {
                    rightBELists.Add(new RightBEList()
                    {
                        RightKB = RBCompareStatRightShipKB
                    });
                }

                if (BE_RightSBAviaBattleNumber_ >= 100)
                {
                    rightBELists.Add(new RightBEList()
                    {
                        RightKB = SBCompareStatRightAviaKB
                    });
                }

                if (BE_RightSBTankBattleNumber_ >= 100)
                {
                    rightBELists.Add(new RightBEList()
                    {
                        RightKB = SBCompareStatRightTankKB
                    });
                }

                if (BE_RightSBShipBattleNumber_ >= 100)
                {
                    rightBELists.Add(new RightBEList()
                    {
                        RightKB = SBCompareStatRightShipKB
                    });
                }

                //////////////
                if (rightBELists.Count == 0)
                {
                    finalRightBE = 0;
                }
                else
                {
                    double finalRightBEList = rightBELists.Average(x => x.RightKB);
                    finalRightBE = finalRightBEList * 100;
                    finalRightBE = Math.Round(finalRightBE, 0);
                }
                /////////////////
                #endregion


                _CompareStatLeftMainSkill.SetText(finalLeftBE.ToString()+"%", TextView.BufferType.Normal);
                _CompareStatRightMainSkill.SetText(finalRightBE.ToString()+"%", TextView.BufferType.Normal);

                if (finalLeftBE >= 0 && finalLeftBE <= 30)
                {
                    _LeftStatImage.SetImageResource(Resource.Drawable._stat1left);
                    _CompareStatLeftMainSkillName.SetText(Resource.String.stat1);
                }
                else
                if (finalLeftBE >= 31 && finalLeftBE <= 50)
                {
                    _LeftStatImage.SetImageResource(Resource.Drawable._stat2left);
                    _CompareStatLeftMainSkillName.SetText(Resource.String.stat2);
                }
                else
                if (finalLeftBE >= 51 && finalLeftBE <= 75)
                {
                    _LeftStatImage.SetImageResource(Resource.Drawable._stat3left);
                    _CompareStatLeftMainSkillName.SetText(Resource.String.stat3);
                }
                else
                if (finalLeftBE >= 76 && finalLeftBE <= 100)
                {
                    _LeftStatImage.SetImageResource(Resource.Drawable._stat4left);
                    _CompareStatLeftMainSkillName.SetText(Resource.String.stat4);
                }
                else
                if (finalLeftBE >= 101 && finalLeftBE <= 150)
                {
                    _LeftStatImage.SetImageResource(Resource.Drawable._stat5left);
                    _CompareStatLeftMainSkillName.SetText(Resource.String.stat5);
                }
                else
                if (finalLeftBE >= 151 && finalLeftBE <= 200)
                {
                    _LeftStatImage.SetImageResource(Resource.Drawable._stat6left);
                    _CompareStatLeftMainSkillName.SetText(Resource.String.stat7);
                }
                else
                if (finalLeftBE >= 200)
                {
                    _LeftStatImage.SetImageResource(Resource.Drawable._stat8left);
                    _CompareStatLeftMainSkillName.SetText(Resource.String.stat8);
                }





                if (finalRightBE >= 0 && finalRightBE <= 30)
                {
                    _RightStatImage.SetImageResource(Resource.Drawable._stat1right);
                    _CompareStatRightMainSkillName.SetText(Resource.String.stat1);
                }
                else
if (finalRightBE >= 31 && finalRightBE <= 50)
                {
                    _RightStatImage.SetImageResource(Resource.Drawable._stat2right);
                    _CompareStatRightMainSkillName.SetText(Resource.String.stat2);
                }
                else
if (finalRightBE >= 51 && finalRightBE <= 75)
                {
                    _RightStatImage.SetImageResource(Resource.Drawable._stat3right);
                    _CompareStatRightMainSkillName.SetText(Resource.String.stat3);
                }
                else
if (finalRightBE >= 76 && finalRightBE <= 100)
                {
                    _RightStatImage.SetImageResource(Resource.Drawable._stat4right);
                    _CompareStatRightMainSkillName.SetText(Resource.String.stat4);
                }
                else
if (finalRightBE >= 101 && finalRightBE <= 150)
                {
                    _RightStatImage.SetImageResource(Resource.Drawable._stat5right);
                    _CompareStatRightMainSkillName.SetText(Resource.String.stat5);
                }
                else
if (finalRightBE >= 151 && finalRightBE <= 200)
                {
                    _RightStatImage.SetImageResource(Resource.Drawable._stat6right);
                    _CompareStatRightMainSkillName.SetText(Resource.String.stat7);
                }
                else
if (finalRightBE >= 200)
                {
                    _RightStatImage.SetImageResource(Resource.Drawable._stat8right);
                    _CompareStatRightMainSkillName.SetText(Resource.String.stat8);
                }

                _TopHintTextViewInfo.Visibility = Android.Views.ViewStates.Gone;
            }

            catch (InvalidOperationException)
            {
                EraseAllField();
                parserLoadProgressBar.Hide();
                Toast.MakeText(this, context.Resources.GetString(Resource.String.StatNoNetwork), ToastLength.Long).Show();
                //
            }
        }


        private void _CompareStatSpinnerMode_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            
            selectedGameMode = gameModes[e.Position].Id;
            EraseAllField();

            if (!string.IsNullOrEmpty(leftNickName)&&!string.IsNullOrEmpty(rightNickName))
            {
               NickParser();
            }
         }

    }
}