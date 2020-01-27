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
using Android.Gms.Ads;
using Android.Preferences;

namespace WarThunderComparer
{
    [Activity(ScreenOrientation=ScreenOrientation.Portrait)]
    class CompareHeli:AppCompatActivity
    {
        Spinner _CompareSpinnerNationLeft;
        Spinner _CompareSpinnerHeliLeft;
        Spinner _CompareSpinnerRankLeft;
        Spinner _CompareSpinnerNationRight;
        Spinner _CompareSpinnerHeliRight;
        Spinner _CompareSpinnerRankRight;
        //Объявление  спиннеров и скролов с XAML

        #region 
        Context context;
        ImageView _CompareImageLeft;
        ImageView _CompareLeftFlag;
        ImageView _CompareLeftHandingAGM;
        ImageView _CompareLeftHandlingCannon;
        ImageView _CompareLeftHandlingBomb;
        ImageView _CompareLeftHandingASM;
        ImageView _CompareLeftHandlingAirToAir;
        ImageView _CompareLeftIRCM;
        ImageView _CompareLeftFlares; 
        ImageView _CompareLeftHIRSS;


        TextView _CompareHeliLeftTextMaxSpeed;
        TextView _CompareHeliLeftTextClimbTo1000;
        TextView _CompareHeliLeftTextTurn360;
        TextView _CompareHeliLeftTextEnginePower;
        TextView _CompareHeliLeftTextWeight;
        TextView _CompareHeliLeftTextThrustToWeightRatio;
        TextView _CompareHeliLeftTextAGMCount;
        TextView _CompareHeliLeftTextAGMArmorPenetration;
        TextView _CompareHeliLeftTextAGMSpeed;
        TextView _CompareHeliLeftTextAGMRange;
        TextView _CompareHeliLeftTextASMCount;
        TextView _CompareHeliLeftTextASMArmorPenetration;
        TextView _CompareHeliLeftTextASMSpeed;
        TextView _CompareHeliLeftTextBombLoad;
        TextView _CompareHeliLeftOffensiveWeapon;
        TextView _CompareHeliLeftSuspensionWeapon;

        ImageView _CompareImageRight;
        ImageView _CompareRightFlag;
        ImageView _CompareRightHandingAGM;
        ImageView _CompareRightHandlingCannon;
        ImageView _CompareRightHandlingBomb;
        ImageView _CompareRightHandingASM;
        ImageView _CompareRightHandlingAirToAir;
        ImageView _CompareRightIRCM;
        ImageView _CompareRightFlares;
        ImageView _CompareRightHIRSS;

        TextView _CompareHeliRightTextMaxSpeed;
        TextView _CompareHeliRightTextClimbTo1000;
        TextView _CompareHeliRightTextTurn360;
        TextView _CompareHeliRightTextEnginePower;
        TextView _CompareHeliRightTextWeight;
        TextView _CompareHeliRightTextThrustToWeightRatio;
        TextView _CompareHeliRightTextAGMCount;
        TextView _CompareHeliRightTextAGMArmorPenetration;
        TextView _CompareHeliRightTextAGMSpeed;
        TextView _CompareHeliRightTextAGMRange;
        TextView _CompareHeliRightTextASMCount;
        TextView _CompareHeliRightTextASMArmorPenetration;
        TextView _CompareHeliRightTextASMSpeed;
        TextView _CompareHeliRightTextBombLoad;
        TextView _CompareHeliRightOffensiveWeapon;
        TextView _CompareHeliRightSuspensionWeapon;



        TextView _CompareHeliLabelTextMaxSpeed;
        TextView _CompareHeliLabelTextClimbTo1000;
        TextView _CompareHeliLabelTextTurn360;
        TextView _CompareHeliLabelTextEnginePower;
        TextView _CompareHeliLabelTextWeight;
        TextView _CompareHeliLabelTextThrustToWeightRatio;
        TextView _CompareHeliLabelTextAGMCount;
        TextView _CompareHeliLabelTextAGMArmorPenetration;
        TextView _CompareHeliLabelTextAGMSpeed;
        TextView _CompareHeliLabelTextAGMRange;
        TextView _CompareHeliLabelTextASMCount;
        TextView _CompareHeliLabelTextASMArmorPenetration;
        TextView _CompareHeliLabelTextASMSpeed;
        TextView _CompareHeliLabelTextBombLoad;
        TextView _CompareHeliLabelDefence;
        TextView _CompareHeliLabelHandingWeapon;


        //Объявление текстовых полей       
        #endregion

        List<Heli> helisleft;
        List<Heli> helisright;
        HeliAdapter AdapterHeliLeft;
        HeliAdapter AdapterHeliRight;
        List<Nation> nations;
        NationAdapter AdapterNationsLeft;
        NationAdapter AdapterNationsRight;
        List<Rank> ranks;
        RankAdapter AdapterRankLeft;
        RankAdapter AdapterRankRight;
        // Объявление адаптеров, коллекций и переменных        

        private int selectedNationLeft;
        private int selectedNationRight;
        private int selectedRankLeft;
        private int selectedRankRight;

        private bool leftAGMExiste;
        private bool leftASMExiste;
        private bool leftCannonExiste;
        private bool leftBombExiste;
        private bool leftAirToAir;
        private bool leftIRCM;
        private bool leftFlares;
        private bool leftHIRSS;

        private bool rightBombExiste;
        private bool rightAGMExiste;
        private bool rightCannonExiste;
        private bool rightASMExiste;
        private bool rightAirToAir;
        private bool rightIRCM;
        private bool rightFlares;
        private bool rightHIRSS;

        private int leftMaxSpeed;
        private int leftClimbTo1000;
        private int leftTurn360;
        private int leftEnginePower;
        private int leftWeight;
        private double leftThrustToWeightRatio;
        private int leftAGMCount;
        private int leftAGMArmorPenetration;
        private int leftAGMSpeed;
        private int leftAGMRange;
        private int leftASMCount;
        private int leftASMArmorPenetration;
        private int leftASMSpeed;
        private int leftBombLoad;

        private int rightMaxSpeed;
        private int rightClimbTo1000;
        private int rightTurn360;
        private int rightEnginePower;
        private int rightWeight;
        private double rightThrustToWeightRatio;
        private int rightAGMCount;
        private int rightAGMArmorPenetration;
        private int rightAGMSpeed;
        private int rightAGMRange;
        private int rightASMCount;
        private int rightASMArmorPenetration;
        private int rightASMSpeed;
        private int rightBombLoad;


        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\
        DrawerLayout drawerLayout;
        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\

        public CompareHeli()
        {
        }

        protected CompareHeli(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CompareHeli);
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
            var adView = FindViewById<AdView>(Resource.Id.adViewCompareHeli);
                 var adRequest = new AdRequest.Builder().Build();
                adView.LoadAd(adRequest);
            //var requestbuilder = new AdRequest.Builder().AddTestDevice("D0BE22F1A4BE27C7470F95A699568FE2");
            //adView.LoadAd(requestbuilder.Build());
            //шрифт
            var font = Typeface.CreateFromAsset(Assets, "dinfont.ttf");

            _CompareSpinnerNationLeft = FindViewById<Spinner>(Resource.Id.CompareSpinnerNationLeftH);
            _CompareSpinnerNationRight = FindViewById<Spinner>(Resource.Id.CompareSpinnerNationRightH);
            _CompareSpinnerRankLeft = FindViewById<Spinner>(Resource.Id.CompareSpinnerRankLeftH);
            _CompareSpinnerRankRight = FindViewById<Spinner>(Resource.Id.CompareSpinnerRankRightH);
            _CompareSpinnerHeliLeft = FindViewById<Spinner>(Resource.Id.CompareSpinnerHeliLeft);
            _CompareSpinnerHeliRight = FindViewById<Spinner>(Resource.Id.CompareSpinnerHeliRight);
            //Привязка спиннеров к шарп коду 

            #region Привязка TextView к коду
            _CompareImageLeft = FindViewById<ImageView>(Resource.Id.CompareHeliImage1);
            _CompareLeftFlag = FindViewById<ImageView>(Resource.Id.CompareHeliFlag1);
            _CompareLeftHandingAGM = FindViewById<ImageView>(Resource.Id.CompareHeliLeftHandlingAGMRocket);
            _CompareLeftHandingASM = FindViewById<ImageView>(Resource.Id.CompareHeliLeftHandlingASMRocket);
            _CompareLeftHandlingBomb = FindViewById<ImageView>(Resource.Id.CompareHeliLeftHandlingBomb);
            _CompareLeftHandlingCannon = FindViewById<ImageView>(Resource.Id.CompareHeliLeftHandlingCannon);
            _CompareLeftHandlingAirToAir = FindViewById<ImageView>(Resource.Id.CompareHeliLeftHandlingAirToAir);
            _CompareLeftIRCM= FindViewById<ImageView>(Resource.Id.CompareHeliLeftIRCM);
            _CompareLeftHIRSS = FindViewById<ImageView>(Resource.Id.CompareHeliLeftHIRSS);
            _CompareLeftFlares = FindViewById<ImageView>(Resource.Id.CompareHeliLeftFlares);

            _CompareHeliLeftTextMaxSpeed = FindViewById<TextView>(Resource.Id.CompareHeliLeftMaxSpeed);
            _CompareHeliLeftTextClimbTo1000 = FindViewById<TextView>(Resource.Id.CompareHeliLeftClimbTo1000);
            _CompareHeliLeftTextTurn360 = FindViewById<TextView>(Resource.Id.CompareHeliLeftTurn360);
            _CompareHeliLeftTextEnginePower = FindViewById<TextView>(Resource.Id.CompareHeliLeftEnginePower);
            _CompareHeliLeftTextWeight = FindViewById<TextView>(Resource.Id.CompareHeliLeftWeight);
            _CompareHeliLeftTextThrustToWeightRatio = FindViewById<TextView>(Resource.Id.CompareHeliLeftThrustToWeightRatio);
            _CompareHeliLeftTextAGMCount = FindViewById<TextView>(Resource.Id.CompareHeliLeftAGMCount);
            _CompareHeliLeftTextAGMArmorPenetration = FindViewById<TextView>(Resource.Id.CompareHeliLeftAGMArmorPenetration);
            _CompareHeliLeftTextAGMSpeed = FindViewById<TextView>(Resource.Id.CompareHeliLeftAGMSpeed);
            _CompareHeliLeftTextAGMRange = FindViewById<TextView>(Resource.Id.CompareHeliLeftAGMRange);
            _CompareHeliLeftTextASMCount = FindViewById<TextView>(Resource.Id.CompareHeliLeftASMCount);
            _CompareHeliLeftTextASMArmorPenetration = FindViewById<TextView>(Resource.Id.CompareHeliLeftASMArmorPenetration);
            _CompareHeliLeftTextASMSpeed = FindViewById<TextView>(Resource.Id.CompareHeliLeftASMSpeed);
            _CompareHeliLeftTextBombLoad = FindViewById<TextView>(Resource.Id.CompareHeliLeftBombLoad);
            _CompareHeliLeftOffensiveWeapon = FindViewById<TextView>(Resource.Id.CompareHeliLeftOffensiveWeapon);
            _CompareHeliLeftSuspensionWeapon = FindViewById<TextView>(Resource.Id.CompareHeliLeftSuspensionWeapon);

            _CompareImageRight = FindViewById<ImageView>(Resource.Id.CompareHeliImage2);
            _CompareRightFlag = FindViewById<ImageView>(Resource.Id.CompareHeliFlag2);
            _CompareRightHandingAGM = FindViewById<ImageView>(Resource.Id.CompareHeliRightHandlingAGMRocket);
            _CompareRightHandingASM = FindViewById<ImageView>(Resource.Id.CompareHeliRightHandlingASMRocket);
            _CompareRightHandlingBomb = FindViewById<ImageView>(Resource.Id.CompareHeliRightHandlingBomb);
            _CompareRightHandlingCannon = FindViewById<ImageView>(Resource.Id.CompareHeliRightHandlingCannon);
            _CompareRightHandlingAirToAir = FindViewById<ImageView>(Resource.Id.CompareHeliRightHandlingAirToAir);
            _CompareRightIRCM = FindViewById<ImageView>(Resource.Id.CompareHeliRightIRCM);
            _CompareRightHIRSS = FindViewById<ImageView>(Resource.Id.CompareHeliRightHIRSS);
            _CompareRightFlares = FindViewById<ImageView>(Resource.Id.CompareHeliRightFlares);

            _CompareHeliRightTextMaxSpeed = FindViewById<TextView>(Resource.Id.CompareHeliRightMaxSpeed);
            _CompareHeliRightTextClimbTo1000 = FindViewById<TextView>(Resource.Id.CompareHeliRightClimbTo1000);
            _CompareHeliRightTextTurn360 = FindViewById<TextView>(Resource.Id.CompareHeliRightTurn360);
            _CompareHeliRightTextEnginePower = FindViewById<TextView>(Resource.Id.CompareHeliRightEnginePower);
            _CompareHeliRightTextWeight = FindViewById<TextView>(Resource.Id.CompareHeliRightWeight);
            _CompareHeliRightTextThrustToWeightRatio = FindViewById<TextView>(Resource.Id.CompareHeliRightThrustToWeightRatio);
            _CompareHeliRightTextAGMCount = FindViewById<TextView>(Resource.Id.CompareHeliRightAGMCount);
            _CompareHeliRightTextAGMArmorPenetration = FindViewById<TextView>(Resource.Id.CompareHeliRightAGMArmorPenetration);
            _CompareHeliRightTextAGMSpeed = FindViewById<TextView>(Resource.Id.CompareHeliRightAGMSpeed);
            _CompareHeliRightTextAGMRange = FindViewById<TextView>(Resource.Id.CompareHeliRightAGMRange);
            _CompareHeliRightTextASMCount = FindViewById<TextView>(Resource.Id.CompareHeliRightASMCount);
            _CompareHeliRightTextASMArmorPenetration = FindViewById<TextView>(Resource.Id.CompareHeliRightASMArmorPenetration);
            _CompareHeliRightTextASMSpeed = FindViewById<TextView>(Resource.Id.CompareHeliRightASMSpeed);
            _CompareHeliRightTextBombLoad = FindViewById<TextView>(Resource.Id.CompareHeliRightBombLoad);
            _CompareHeliRightOffensiveWeapon = FindViewById<TextView>(Resource.Id.CompareHeliRightOffensiveWeapon);
            _CompareHeliRightSuspensionWeapon = FindViewById<TextView>(Resource.Id.CompareHeliRightSuspensionWeapon);

            _CompareHeliLabelTextMaxSpeed = FindViewById<TextView>(Resource.Id.CompareHeliLabelMaxSpeed);
            _CompareHeliLabelTextClimbTo1000 = FindViewById<TextView>(Resource.Id.CompareHeliLabelClimbTo1000);
            _CompareHeliLabelTextTurn360 = FindViewById<TextView>(Resource.Id.CompareHeliLabelTurn360);
            _CompareHeliLabelTextEnginePower = FindViewById<TextView>(Resource.Id.CompareHeliLabelEnginePower);
            _CompareHeliLabelTextWeight = FindViewById<TextView>(Resource.Id.CompareHeliLabelWeight);
            _CompareHeliLabelTextThrustToWeightRatio = FindViewById<TextView>(Resource.Id.CompareHeliLabelThrustToWeightRatio);
            _CompareHeliLabelTextAGMCount = FindViewById<TextView>(Resource.Id.CompareHeliLabelAGMCount);
            _CompareHeliLabelTextAGMArmorPenetration = FindViewById<TextView>(Resource.Id.CompareHeliLabelAGMArmorPenetration);
            _CompareHeliLabelTextAGMSpeed = FindViewById<TextView>(Resource.Id.CompareHeliLabelAGMSpeed);
            _CompareHeliLabelTextAGMRange = FindViewById<TextView>(Resource.Id.CompareHeliLabelAGMRange);
            _CompareHeliLabelTextASMCount = FindViewById<TextView>(Resource.Id.CompareHeliLabelASMCount);
            _CompareHeliLabelTextASMArmorPenetration = FindViewById<TextView>(Resource.Id.CompareHeliLabelASMArmorPenetration);
            _CompareHeliLabelTextASMSpeed = FindViewById<TextView>(Resource.Id.CompareHeliLabelASMSpeed);
            _CompareHeliLabelTextBombLoad = FindViewById<TextView>(Resource.Id.CompareHeliLabelBombLoad);
            _CompareHeliLabelDefence = FindViewById<TextView>(Resource.Id.CompareHeliLabelDefence);
            _CompareHeliLabelHandingWeapon = FindViewById<TextView>(Resource.Id.CompareHeliLabelHandingWeapon);

            #endregion

            #region Изменение шрифта

            _CompareHeliLabelTextMaxSpeed.Typeface=font; 
            _CompareHeliLabelTextClimbTo1000.Typeface=font; 
            _CompareHeliLabelTextTurn360.Typeface=font; 
            _CompareHeliLabelTextEnginePower.Typeface=font; 
            _CompareHeliLabelTextWeight.Typeface=font; 
            _CompareHeliLabelTextThrustToWeightRatio.Typeface=font; 
            _CompareHeliLabelTextAGMCount.Typeface=font;
            _CompareHeliLabelTextAGMArmorPenetration.Typeface=font; 
            _CompareHeliLabelTextAGMSpeed.Typeface=font; 
            _CompareHeliLabelTextAGMRange.Typeface=font; 
            _CompareHeliLabelTextASMCount.Typeface=font; 
            _CompareHeliLabelTextASMArmorPenetration.Typeface=font;
            _CompareHeliLabelTextASMSpeed.Typeface=font; 
            _CompareHeliLabelTextBombLoad.Typeface=font;
            _CompareHeliLabelDefence.Typeface = font;
            _CompareHeliLabelHandingWeapon.Typeface = font;
            #endregion

            #region Изменения цвета текста всех TextView
            _CompareHeliLabelTextMaxSpeed.SetTextColor(Color.Black);
            _CompareHeliLabelTextClimbTo1000.SetTextColor(Color.Black);
            _CompareHeliLabelTextTurn360.SetTextColor(Color.Black);
            _CompareHeliLabelTextEnginePower.SetTextColor(Color.Black);
            _CompareHeliLabelTextWeight.SetTextColor(Color.Black);
            _CompareHeliLabelTextThrustToWeightRatio.SetTextColor(Color.Black);
            _CompareHeliLabelTextAGMCount.SetTextColor(Color.Black);
            _CompareHeliLabelTextAGMArmorPenetration.SetTextColor(Color.Black);
            _CompareHeliLabelTextAGMSpeed.SetTextColor(Color.Black);
            _CompareHeliLabelTextAGMRange.SetTextColor(Color.Black);
            _CompareHeliLabelTextASMCount.SetTextColor(Color.Black);
            _CompareHeliLabelTextASMArmorPenetration.SetTextColor(Color.Black);
            _CompareHeliLabelTextASMSpeed.SetTextColor(Color.Black);
            _CompareHeliLabelTextBombLoad.SetTextColor(Color.Black);
 


            _CompareHeliLeftTextMaxSpeed.SetTextColor(Color.Black);
            _CompareHeliLeftTextClimbTo1000.SetTextColor(Color.Black);
            _CompareHeliLeftTextTurn360.SetTextColor(Color.Black);
            _CompareHeliLeftTextEnginePower.SetTextColor(Color.Black);
            _CompareHeliLeftTextWeight.SetTextColor(Color.Black);
            _CompareHeliLeftTextThrustToWeightRatio.SetTextColor(Color.Black);
            _CompareHeliLeftTextAGMCount.SetTextColor(Color.Black);
            _CompareHeliLeftTextAGMArmorPenetration.SetTextColor(Color.Black);
            _CompareHeliLeftTextAGMSpeed.SetTextColor(Color.Black);
            _CompareHeliLeftTextAGMRange.SetTextColor(Color.Black);
            _CompareHeliLeftTextASMCount.SetTextColor(Color.Black);
            _CompareHeliLeftTextASMArmorPenetration.SetTextColor(Color.Black);
            _CompareHeliLeftTextASMSpeed.SetTextColor(Color.Black);
            _CompareHeliLeftTextBombLoad.SetTextColor(Color.Black);
            _CompareHeliLeftOffensiveWeapon.SetTextColor(Color.Black);
            _CompareHeliLeftSuspensionWeapon.SetTextColor(Color.Black);

            _CompareHeliRightTextMaxSpeed.SetTextColor(Color.Black);
            _CompareHeliRightTextClimbTo1000.SetTextColor(Color.Black);
            _CompareHeliRightTextTurn360.SetTextColor(Color.Black);
            _CompareHeliRightTextEnginePower.SetTextColor(Color.Black);
            _CompareHeliRightTextWeight.SetTextColor(Color.Black);
            _CompareHeliRightTextThrustToWeightRatio.SetTextColor(Color.Black);
            _CompareHeliRightTextAGMCount.SetTextColor(Color.Black);
            _CompareHeliRightTextAGMArmorPenetration.SetTextColor(Color.Black);
            _CompareHeliRightTextAGMSpeed.SetTextColor(Color.Black);
            _CompareHeliRightTextAGMRange.SetTextColor(Color.Black);
            _CompareHeliRightTextASMCount.SetTextColor(Color.Black);
            _CompareHeliRightTextASMArmorPenetration.SetTextColor(Color.Black);
            _CompareHeliRightTextASMSpeed.SetTextColor(Color.Black);
            _CompareHeliRightTextBombLoad.SetTextColor(Color.Black);
            _CompareHeliRightOffensiveWeapon.SetTextColor(Color.Black);
            _CompareHeliRightSuspensionWeapon.SetTextColor(Color.Black);

            #endregion

            nations = NationCollection.GetNation();
            AdapterNationsLeft = new NationAdapter(this, nations);
            AdapterNationsRight = new NationAdapter(this, nations);
            _CompareSpinnerNationLeft.Adapter = AdapterNationsLeft;
            _CompareSpinnerNationRight.Adapter = AdapterNationsRight;
            _CompareSpinnerNationLeft.SetSelection(1); //Автовыбор
            _CompareSpinnerNationRight.SetSelection(3); //Автовыбор
            selectedNationLeft = 1;   //Автовыбор
            selectedNationRight = 3;   //Автовыбор

            ranks = RankCollection.GetRank();
            AdapterRankLeft = new RankAdapter(this, ranks);
            AdapterRankRight = new RankAdapter(this, ranks);
            _CompareSpinnerRankLeft.Adapter = AdapterRankLeft;
            _CompareSpinnerRankRight.Adapter = AdapterRankRight;
            _CompareSpinnerRankLeft.SetSelection(5); //Автовыбор
            _CompareSpinnerRankRight.SetSelection(5); //Автовыбор
            selectedRankLeft = 5;   //Автовыбор
            selectedRankRight = 5;   //Автовыбор

            _CompareSpinnerHeliLeft.SetSelection(1);   //Автовыбор
            _CompareSpinnerHeliRight.SetSelection(1);   //Автовыбор

            //Объявление коллекции наций, рангов и адаптеров

            _CompareSpinnerHeliLeft.ItemSelected += _CompareSpinnerHeliLeft_ItemSelected;
            _CompareSpinnerHeliRight.ItemSelected += _CompareSpinnerHeliRight_ItemSelected;
            _CompareSpinnerRankLeft.ItemSelected += _CompareSpinnerRankLeft_ItemSelected;
            _CompareSpinnerRankRight.ItemSelected += _CompareSpinnerRankRight_ItemSelected;
            _CompareSpinnerNationLeft.ItemSelected += _CompareSpinnerNationLeft_ItemSelected;
            _CompareSpinnerNationRight.ItemSelected += _CompareSpinnerNationRight_ItemSelected;


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


        //Обработчики событий  нажатия на нации
        private void _CompareSpinnerNationLeft_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedNationLeft = nations[e.Position].Id;
            HeliLeftSelector();
        }

        private void _CompareSpinnerNationRight_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedNationRight = nations[e.Position].Id;
            HeliRightSelector();

        }
        //Обработчики событий  нажатия на ранги

        private void _CompareSpinnerRankLeft_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedRankLeft = ranks[e.Position].Id;
            HeliLeftSelector();

        }
        private void _CompareSpinnerRankRight_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedRankRight = ranks[e.Position].Id;
            HeliRightSelector();
            
        }
        //Обработчики событий  нажатия на вертолеты
        private void _CompareSpinnerHeliLeft_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            leftMaxSpeed = helisleft[e.Position].MaxSpeed;
            leftClimbTo1000 = helisleft[e.Position].ClimbTo1000;
            leftTurn360 = helisleft[e.Position].Turn360;
            leftEnginePower = helisleft[e.Position].EnginePower;
            leftWeight = helisleft[e.Position].Weight;
            leftThrustToWeightRatio = helisleft[e.Position].ThrustToWeightRatio;
            leftAGMCount = helisleft[e.Position].AGMCount;
            leftAGMArmorPenetration = helisleft[e.Position].AGMArmorPenetration;
            leftAGMSpeed = helisleft[e.Position].AGMSpeed;
            leftAGMRange = helisleft[e.Position].AGMRange;
            leftASMCount = helisleft[e.Position].ASMCount;
            leftASMArmorPenetration = helisleft[e.Position].ASMArmorPenetration;
            leftASMSpeed = helisleft[e.Position].ASMSpeed;
            leftBombLoad = helisleft[e.Position].BombLoad;
            //Для подсветки

            leftAGMExiste = helisleft[e.Position].HandingAGM;
            leftASMExiste = helisleft[e.Position].HandingASM;
            leftCannonExiste = helisleft[e.Position].HandingCannon;
            leftBombExiste = helisleft[e.Position].HandingBomb;
            leftAirToAir = helisleft[e.Position].AirToAir;
        leftIRCM = helisleft[e.Position].IRCM;
        leftFlares = helisleft[e.Position].Flares;
        leftHIRSS = helisleft[e.Position].HIRSS;
        //Для картинок подвесов
        _CompareImageLeft.SetImageResource(helisleft[e.Position].Image);
            _CompareLeftFlag.SetImageResource(helisleft[e.Position].FlagImage);
            // _CompareHeliLeftTextClimbTo1000.SetText(helisleft[e.Position].ClimbTo1000.ToString() TextView.BufferType.Normal);
            int newClimb = helisleft[e.Position].ClimbTo1000;
            TimeSpan timeSpan = TimeSpan.FromSeconds(newClimb);
            string climbToShow = timeSpan.ToString(@"mm\:ss");
            _CompareHeliLeftTextClimbTo1000.SetText(climbToShow, TextView.BufferType.Normal);
            _CompareHeliLeftTextTurn360.SetText(helisleft[e.Position].Turn360.ToString()+ context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            _CompareHeliLeftTextEnginePower.SetText(helisleft[e.Position].EnginePower.ToString() + context.Resources.GetString(Resource.String.AbbrH_P), TextView.BufferType.Normal);
            _CompareHeliLeftTextAGMCount.SetText(helisleft[e.Position].AGMCount.ToString() + context.Resources.GetString(Resource.String.AbbrITEMS), TextView.BufferType.Normal);
            _CompareHeliLeftOffensiveWeapon.SetText(helisleft[e.Position].OffensiveWeapon, TextView.BufferType.Normal);
            _CompareHeliLeftSuspensionWeapon.SetText(helisleft[e.Position].SuspensionWeapon, TextView.BufferType.Normal);
            _CompareHeliLeftTextASMCount.SetText(helisleft[e.Position].ASMCount.ToString() + context.Resources.GetString(Resource.String.AbbrITEMS), TextView.BufferType.Normal);

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            ISharedPreferencesEditor editor = prefs.Edit();
            var switchchecked = prefs.GetBoolean("key_kmhtomph", false);
            if (switchchecked)
            {
                _CompareHeliLabelTextClimbTo1000.SetText(context.Resources.GetString(Resource.String.HeliClimbTo1000Feet), TextView.BufferType.Normal);

                var maxSpeed = helisleft[e.Position].MaxSpeed * 0.621371192;
                var thrustToWeightRatio = helisleft[e.Position].ThrustToWeightRatio / 2.204622621849;
                var weight = helisleft[e.Position].Weight * 0.00110231131;
                var bombLoad = helisleft[e.Position].BombLoad * 2.204622621849;
                var aGMSpeed = helisleft[e.Position].AGMSpeed * 3.28084;
                var aSMSpeed = helisleft[e.Position].ASMSpeed * 3.28084;
                var aGMRange = helisleft[e.Position].AGMRange * 3.28084;
                var aGMArmorPenetration = helisleft[e.Position].AGMArmorPenetration * 0.039370;
                var aSMArmorPenetration = helisleft[e.Position].ASMArmorPenetration * 0.039370;
                maxSpeed = Math.Round(maxSpeed, 0);
                thrustToWeightRatio = Math.Round(thrustToWeightRatio, 2);
                weight = Math.Round(weight, 1);
                bombLoad = Math.Round(bombLoad, 0);
                aGMSpeed = Math.Round(aGMSpeed, 0);
                aSMSpeed = Math.Round(aSMSpeed, 0);
                aGMRange = Math.Round(aGMRange, 0);
                aGMArmorPenetration = Math.Round(aGMArmorPenetration, 2);
                aSMArmorPenetration = Math.Round(aSMArmorPenetration, 2);

                _CompareHeliLeftTextMaxSpeed.SetText(maxSpeed + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _CompareHeliLeftTextThrustToWeightRatio.SetText(thrustToWeightRatio + context.Resources.GetString(Resource.String.AbbrHP_LB), TextView.BufferType.Normal);
                _CompareHeliLeftTextWeight.SetText(weight + context.Resources.GetString(Resource.String.AbbrST), TextView.BufferType.Normal);
                _CompareHeliLeftTextBombLoad.SetText(bombLoad + context.Resources.GetString(Resource.String.AbbrLB), TextView.BufferType.Normal);
                _CompareHeliLeftTextAGMSpeed.SetText(aGMSpeed + context.Resources.GetString(Resource.String.AbbrFEET_S), TextView.BufferType.Normal);
                _CompareHeliLeftTextASMSpeed.SetText(aSMSpeed + context.Resources.GetString(Resource.String.AbbrFEET_S), TextView.BufferType.Normal);
                _CompareHeliLeftTextAGMRange.SetText(aGMRange + context.Resources.GetString(Resource.String.AbbrFEET), TextView.BufferType.Normal);
                _CompareHeliLeftTextAGMArmorPenetration.SetText(aGMArmorPenetration + context.Resources.GetString(Resource.String.AbbrINCH), TextView.BufferType.Normal);
                _CompareHeliLeftTextASMArmorPenetration.SetText(aSMArmorPenetration + context.Resources.GetString(Resource.String.AbbrINCH), TextView.BufferType.Normal);

            }
            else
            {
                _CompareHeliLabelTextClimbTo1000.SetText(context.Resources.GetString(Resource.String.HeliClimbTo1000), TextView.BufferType.Normal);

                _CompareHeliLeftTextMaxSpeed.SetText(helisleft[e.Position].MaxSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _CompareHeliLeftTextThrustToWeightRatio.SetText(helisleft[e.Position].ThrustToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrH_P_KG), TextView.BufferType.Normal);
                _CompareHeliLeftTextWeight.SetText(helisleft[e.Position].Weight.ToString() + context.Resources.GetString(Resource.String.AbbrKG), TextView.BufferType.Normal);
                _CompareHeliLeftTextBombLoad.SetText(helisleft[e.Position].BombLoad.ToString() + context.Resources.GetString(Resource.String.AbbrKG), TextView.BufferType.Normal);
                _CompareHeliLeftTextAGMSpeed.SetText(helisleft[e.Position].AGMSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrM_S), TextView.BufferType.Normal);
                _CompareHeliLeftTextASMSpeed.SetText(helisleft[e.Position].ASMSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrM_S), TextView.BufferType.Normal);
                _CompareHeliLeftTextAGMRange.SetText(helisleft[e.Position].AGMRange.ToString() + context.Resources.GetString(Resource.String.AbbrMETER), TextView.BufferType.Normal);
                _CompareHeliLeftTextAGMArmorPenetration.SetText(helisleft[e.Position].AGMArmorPenetration.ToString() + context.Resources.GetString(Resource.String.AbbrMM), TextView.BufferType.Normal);
                _CompareHeliLeftTextASMArmorPenetration.SetText(helisleft[e.Position].ASMArmorPenetration.ToString() + context.Resources.GetString(Resource.String.AbbrMM), TextView.BufferType.Normal);

            }


            HeliShowBestViaBackgroundColor();
            HeliLeftHandingWeaponShower();


        }

  

       
        private void _CompareSpinnerHeliRight_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            rightMaxSpeed = helisright[e.Position].MaxSpeed;
            rightClimbTo1000 = helisright[e.Position].ClimbTo1000;
            rightTurn360 = helisright[e.Position].Turn360;
            rightEnginePower = helisright[e.Position].EnginePower;
            rightWeight = helisright[e.Position].Weight;
            rightThrustToWeightRatio = helisright[e.Position].ThrustToWeightRatio;
            rightAGMCount = helisright[e.Position].AGMCount;
            rightAGMArmorPenetration = helisright[e.Position].AGMArmorPenetration;
            rightAGMSpeed = helisright[e.Position].AGMSpeed;
            rightAGMRange = helisright[e.Position].AGMRange;
            rightASMCount = helisright[e.Position].ASMCount;
            rightASMArmorPenetration = helisright[e.Position].ASMArmorPenetration;
            rightASMSpeed = helisright[e.Position].ASMSpeed;
            rightBombLoad = helisright[e.Position].BombLoad;
            //Для подсветки

            rightAGMExiste = helisright[e.Position].HandingAGM;
            rightASMExiste = helisright[e.Position].HandingASM;
            rightCannonExiste = helisright[e.Position].HandingCannon;
            rightBombExiste = helisright[e.Position].HandingBomb;
            rightAirToAir = helisright[e.Position].AirToAir;
            rightIRCM = helisright[e.Position].IRCM;
            rightFlares = helisright[e.Position].Flares;
            rightHIRSS = helisright[e.Position].HIRSS;
            //Для картинок подвесов
            _CompareImageRight.SetImageResource(helisright[e.Position].Image);
            _CompareRightFlag.SetImageResource(helisright[e.Position].FlagImage);
            // _CompareHeliRightTextClimbTo1000.SetText(helisright[e.Position].ClimbTo1000.ToString() TextView.BufferType.Normal);
            int newClimb = helisright[e.Position].ClimbTo1000;
            TimeSpan timeSpan = TimeSpan.FromSeconds(newClimb);
            string climbToShow = timeSpan.ToString(@"mm\:ss");
            _CompareHeliRightTextClimbTo1000.SetText(climbToShow, TextView.BufferType.Normal);
            _CompareHeliRightTextTurn360.SetText(helisright[e.Position].Turn360.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            _CompareHeliRightTextEnginePower.SetText(helisright[e.Position].EnginePower.ToString() + context.Resources.GetString(Resource.String.AbbrH_P), TextView.BufferType.Normal);
            _CompareHeliRightTextAGMCount.SetText(helisright[e.Position].AGMCount.ToString() + context.Resources.GetString(Resource.String.AbbrITEMS), TextView.BufferType.Normal);
            _CompareHeliRightOffensiveWeapon.SetText(helisright[e.Position].OffensiveWeapon, TextView.BufferType.Normal);
            _CompareHeliRightSuspensionWeapon.SetText(helisright[e.Position].SuspensionWeapon, TextView.BufferType.Normal);
            _CompareHeliRightTextASMCount.SetText(helisright[e.Position].ASMCount.ToString() + context.Resources.GetString(Resource.String.AbbrITEMS), TextView.BufferType.Normal);

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            ISharedPreferencesEditor editor = prefs.Edit();
            var switchchecked = prefs.GetBoolean("key_kmhtomph", false);
            if (switchchecked)
            {
                var maxSpeed = helisright[e.Position].MaxSpeed * 0.621371192;
                var thrustToWeightRatio = helisright[e.Position].ThrustToWeightRatio / 2.204622621849;
                var weight = helisright[e.Position].Weight * 0.00110231131;
                var bombLoad = helisright[e.Position].BombLoad * 2.204622621849;
                var aGMSpeed = helisright[e.Position].AGMSpeed * 3.28084;
                var aSMSpeed = helisright[e.Position].ASMSpeed * 3.28084;
                var aGMRange = helisright[e.Position].AGMRange * 3.28084;
                var aSMArmorPenetration = helisright[e.Position].ASMArmorPenetration * 0.039370;
                var aGMArmorPenetration = helisright[e.Position].AGMArmorPenetration * 0.039370;
                maxSpeed = Math.Round(maxSpeed, 0);
                thrustToWeightRatio = Math.Round(thrustToWeightRatio, 2);
                weight = Math.Round(weight, 1);
                bombLoad = Math.Round(bombLoad, 0);
                aGMSpeed = Math.Round(aGMSpeed, 0);
                aSMSpeed = Math.Round(aSMSpeed, 0);
                aGMRange = Math.Round(aGMRange, 0);
                aSMArmorPenetration = Math.Round(aSMArmorPenetration, 2);
                aGMArmorPenetration = Math.Round(aGMArmorPenetration, 2);

                _CompareHeliRightTextMaxSpeed.SetText(maxSpeed + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _CompareHeliRightTextThrustToWeightRatio.SetText(thrustToWeightRatio + context.Resources.GetString(Resource.String.AbbrHP_LB), TextView.BufferType.Normal);
                _CompareHeliRightTextWeight.SetText(weight + context.Resources.GetString(Resource.String.AbbrST), TextView.BufferType.Normal);
                _CompareHeliRightTextBombLoad.SetText(bombLoad + context.Resources.GetString(Resource.String.AbbrLB), TextView.BufferType.Normal);
                _CompareHeliRightTextAGMSpeed.SetText(aGMSpeed + context.Resources.GetString(Resource.String.AbbrFEET_S), TextView.BufferType.Normal);
                _CompareHeliRightTextASMSpeed.SetText(aSMSpeed + context.Resources.GetString(Resource.String.AbbrFEET_S), TextView.BufferType.Normal);
                _CompareHeliRightTextAGMRange.SetText(aGMRange + context.Resources.GetString(Resource.String.AbbrFEET), TextView.BufferType.Normal);
                _CompareHeliRightTextAGMArmorPenetration.SetText(aGMArmorPenetration + context.Resources.GetString(Resource.String.AbbrINCH), TextView.BufferType.Normal);
                _CompareHeliRightTextASMArmorPenetration.SetText(aSMArmorPenetration + context.Resources.GetString(Resource.String.AbbrINCH), TextView.BufferType.Normal);

            }
            else
            {
                _CompareHeliRightTextMaxSpeed.SetText(helisright[e.Position].MaxSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _CompareHeliRightTextThrustToWeightRatio.SetText(helisright[e.Position].ThrustToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrH_P_KG), TextView.BufferType.Normal);
                _CompareHeliRightTextWeight.SetText(helisright[e.Position].Weight.ToString() + context.Resources.GetString(Resource.String.AbbrKG), TextView.BufferType.Normal);
                _CompareHeliRightTextBombLoad.SetText(helisright[e.Position].BombLoad.ToString() + context.Resources.GetString(Resource.String.AbbrKG), TextView.BufferType.Normal);
                _CompareHeliRightTextAGMSpeed.SetText(helisright[e.Position].AGMSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrM_S), TextView.BufferType.Normal);
                _CompareHeliRightTextASMSpeed.SetText(helisright[e.Position].ASMSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrM_S), TextView.BufferType.Normal);
                _CompareHeliRightTextAGMRange.SetText(helisright[e.Position].AGMRange.ToString() + context.Resources.GetString(Resource.String.AbbrMETER), TextView.BufferType.Normal);
                _CompareHeliRightTextAGMArmorPenetration.SetText(helisright[e.Position].AGMArmorPenetration.ToString() + context.Resources.GetString(Resource.String.AbbrMM), TextView.BufferType.Normal);
                _CompareHeliRightTextASMArmorPenetration.SetText(helisright[e.Position].ASMArmorPenetration.ToString() + context.Resources.GetString(Resource.String.AbbrMM), TextView.BufferType.Normal);

            }


            HeliShowBestViaBackgroundColor();
            HeliRightHandingWeaponShower();


        }



        private void HeliLeftSelector()
        {
            if (selectedNationLeft == 100 && selectedRankLeft == 100)
            {
                helisleft = HeliCollection.GetHeli();
                AdapterHeliLeft = new HeliAdapter(this, helisleft);
                _CompareSpinnerHeliLeft.Adapter = AdapterHeliLeft;
            }
            else
            if(selectedNationLeft==100)
            {
                List<Heli> helisAll = HeliCollection.GetHeli();
                var helivar = from h in helisAll
                              where h.RankId == selectedRankLeft
                              select h;
                helisleft = helivar.ToList<Heli>();
                AdapterHeliLeft = new HeliAdapter(this, helisleft);
                _CompareSpinnerHeliLeft.Adapter = AdapterHeliLeft;
            }
            else
           if (selectedRankLeft == 100)
            {
                List<Heli> helisAll = HeliCollection.GetHeli();
                var helivar = from h in helisAll
                              where h.NationId == selectedNationLeft
                              select h;
                helisleft = helivar.ToList<Heli>();
                AdapterHeliLeft = new HeliAdapter(this, helisleft);
                _CompareSpinnerHeliLeft.Adapter = AdapterHeliLeft;
            }
            else
            {
                helisleft = HeliSelectorWithout100left(selectedNationLeft, selectedRankLeft);
                AdapterHeliLeft = new HeliAdapter(this, helisleft);
                _CompareSpinnerHeliLeft.Adapter = AdapterHeliLeft;
            }
        }

     

        private void HeliRightSelector()
        {
            if (selectedNationRight == 100 && selectedRankRight == 100)
            {
                helisright = HeliCollection.GetHeli();
                AdapterHeliRight = new HeliAdapter(this, helisright);
                _CompareSpinnerHeliRight.Adapter = AdapterHeliRight;
            }
            else
      if (selectedNationRight == 100)
            {
                List<Heli> helisAll = HeliCollection.GetHeli();
                var helivar = from h in helisAll
                              where h.RankId == selectedRankRight
                              select h;
                helisright = helivar.ToList<Heli>();
                AdapterHeliRight = new HeliAdapter(this, helisright);
                _CompareSpinnerHeliRight.Adapter = AdapterHeliRight;
            }
            else
     if (selectedRankRight == 100)
            {
                List<Heli> helisAll = HeliCollection.GetHeli();
                var helivar = from h in helisAll
                              where h.NationId == selectedNationRight
                              select h;
                helisright = helivar.ToList<Heli>();
                AdapterHeliRight = new HeliAdapter(this, helisright);
                _CompareSpinnerHeliRight.Adapter = AdapterHeliRight;
            }
            else
            {
                helisright = HeliSelectorWithout100right(selectedNationRight, selectedRankRight);
                AdapterHeliRight = new HeliAdapter(this, helisright);
                _CompareSpinnerHeliRight.Adapter = AdapterHeliRight;
            }
        }

        private List<Heli> HeliSelectorWithout100left(int selectedNationLeft, int selectedRankLeft)
        {
            this.selectedNationLeft = selectedNationLeft;
            this.selectedRankLeft = selectedRankLeft;

            List<Heli> helisAll = HeliCollection.GetHeli();
            var helivar = from h in helisAll
                          where h.NationId == selectedNationLeft
                          where h.RankId == selectedRankLeft
                          select h;
            return helivar.ToList<Heli>();
        }

        private List<Heli> HeliSelectorWithout100right(int selectedNationRight, int selectedRankRight)
        {
            this.selectedNationRight = selectedNationRight;
            this.selectedRankRight = selectedRankRight;

            List<Heli> helisAll = HeliCollection.GetHeli();
            var helivar = from h in helisAll
                          where h.NationId == selectedNationRight
                          where h.RankId == selectedRankRight
                          select h;
            return helivar.ToList<Heli>();
        }

        private void HeliLeftHandingWeaponShower()
        {
            if (leftIRCM == true)
            {
                _CompareLeftIRCM.SetImageResource(Resource.Drawable._defenceIRCM);
            }
            else
            {
                _CompareLeftIRCM.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftFlares == true)
            {
                _CompareLeftFlares.SetImageResource(Resource.Drawable._defenceFlares);
            }
            else
            {
                _CompareLeftFlares.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftHIRSS == true)
            {
                _CompareLeftHIRSS.SetImageResource(Resource.Drawable._defenceHIRSS);
            }
            else
            {
                _CompareLeftHIRSS.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (leftAirToAir == true)
            {
                _CompareLeftHandlingAirToAir.SetImageResource(Resource.Drawable._handingAirToAir);
            }
            else
            {
                _CompareLeftHandlingAirToAir.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftAGMExiste == true)
            {
                _CompareLeftHandingAGM.SetImageResource(Resource.Drawable._handingAGM);
            }
            else
            {
                _CompareLeftHandingAGM.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftASMExiste == true)
            {
                _CompareLeftHandingASM.SetImageResource(Resource.Drawable._handingRocket);
            }
            else
            {
                _CompareLeftHandingASM.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftCannonExiste == true)
            {
                _CompareLeftHandlingCannon.SetImageResource(Resource.Drawable._handingCannon);
            }
            else
            {
                _CompareLeftHandlingCannon.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftBombExiste == true)
            {
                _CompareLeftHandlingBomb.SetImageResource(Resource.Drawable._handingBomb);
            }
            else
            {
                _CompareLeftHandlingBomb.SetImageResource(Resource.Drawable._handingTransparent);
            }
            
        }

        private void HeliRightHandingWeaponShower()
        {
            if (rightIRCM == true)
            {
                _CompareRightIRCM.SetImageResource(Resource.Drawable._defenceIRCM);
            }
            else
            {
                _CompareRightIRCM.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightFlares == true)
            {
                _CompareRightFlares.SetImageResource(Resource.Drawable._defenceFlares);
            }
            else
            {
                _CompareRightFlares.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightHIRSS == true)
            {
                _CompareRightHIRSS.SetImageResource(Resource.Drawable._defenceHIRSS);
            }
            else
            {
                _CompareRightHIRSS.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (rightAirToAir == true)
            {
                _CompareRightHandlingAirToAir.SetImageResource(Resource.Drawable._handingAirToAir);
            }
            else
            {
                _CompareRightHandlingAirToAir.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightAGMExiste == true)
            {
                _CompareRightHandingAGM.SetImageResource(Resource.Drawable._handingAGM);
            }
            else
            {
                _CompareRightHandingAGM.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightASMExiste == true)
            {
                _CompareRightHandingASM.SetImageResource(Resource.Drawable._handingRocket);
            }
            else
            {
                _CompareRightHandingASM.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightCannonExiste == true)
            {
                _CompareRightHandlingCannon.SetImageResource(Resource.Drawable._handingCannon);
            }
            else
            {
                _CompareRightHandlingCannon.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightBombExiste == true)
            {
                _CompareRightHandlingBomb.SetImageResource(Resource.Drawable._handingBomb);
            }
            else
            {
                _CompareRightHandlingBomb.SetImageResource(Resource.Drawable._handingTransparent);
            }

        }


        private void HeliShowBestViaBackgroundColor()
        {
          
            if (leftMaxSpeed > rightMaxSpeed)
            {
                _CompareHeliLeftTextMaxSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareHeliRightTextMaxSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
            if (leftMaxSpeed < rightMaxSpeed)
            {
                _CompareHeliLeftTextMaxSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareHeliRightTextMaxSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftMaxSpeed == rightMaxSpeed)
            {
                _CompareHeliLeftTextMaxSpeed.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareHeliRightTextMaxSpeed.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }

            if (leftClimbTo1000 < rightClimbTo1000)
            {
                _CompareHeliLeftTextClimbTo1000.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareHeliRightTextClimbTo1000.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
   if (leftClimbTo1000 > rightClimbTo1000)
            {
                _CompareHeliLeftTextClimbTo1000.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareHeliRightTextClimbTo1000.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftClimbTo1000 == rightClimbTo1000)
            {
                _CompareHeliLeftTextClimbTo1000.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareHeliRightTextClimbTo1000.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }

            if (leftTurn360 < rightTurn360)
            {
                _CompareHeliLeftTextTurn360.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareHeliRightTextTurn360.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftTurn360 > rightTurn360)
            {
                _CompareHeliLeftTextTurn360.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareHeliRightTextTurn360.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftTurn360 == rightTurn360)
            {
                _CompareHeliLeftTextTurn360.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareHeliRightTextTurn360.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }

            if (leftEnginePower > rightEnginePower)
            {
                _CompareHeliLeftTextEnginePower.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareHeliRightTextEnginePower.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftEnginePower < rightEnginePower)
            {
                _CompareHeliLeftTextEnginePower.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareHeliRightTextEnginePower.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftEnginePower == rightEnginePower)
            {
                _CompareHeliLeftTextEnginePower.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareHeliRightTextEnginePower.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }

            if (leftWeight < rightWeight)
            {
                _CompareHeliLeftTextWeight.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareHeliRightTextWeight.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftWeight > rightWeight)
            {
                _CompareHeliLeftTextWeight.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareHeliRightTextWeight.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftWeight == rightWeight)
            {
                _CompareHeliLeftTextWeight.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareHeliRightTextWeight.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }

            if (leftThrustToWeightRatio > rightThrustToWeightRatio)
            {
                _CompareHeliLeftTextThrustToWeightRatio.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareHeliRightTextThrustToWeightRatio.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftThrustToWeightRatio < rightThrustToWeightRatio)
            {
                _CompareHeliLeftTextThrustToWeightRatio.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareHeliRightTextThrustToWeightRatio.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftThrustToWeightRatio == rightThrustToWeightRatio)
            {
                _CompareHeliLeftTextThrustToWeightRatio.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareHeliRightTextThrustToWeightRatio.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }

            if (leftAGMCount > rightAGMCount)
            {
                _CompareHeliLeftTextAGMCount.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareHeliRightTextAGMCount.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftAGMCount < rightAGMCount)
            {
                _CompareHeliLeftTextAGMCount.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareHeliRightTextAGMCount.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftAGMCount == rightAGMCount)
            {
                _CompareHeliLeftTextAGMCount.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareHeliRightTextAGMCount.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }
            if (leftAGMSpeed > rightAGMSpeed)
            {
                _CompareHeliLeftTextAGMSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareHeliRightTextAGMSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftAGMSpeed < rightAGMSpeed)
            {
                _CompareHeliLeftTextAGMSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareHeliRightTextAGMSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftAGMSpeed == rightAGMSpeed)
            {
                _CompareHeliLeftTextAGMSpeed.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareHeliRightTextAGMSpeed.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }

            if (leftAGMArmorPenetration > rightAGMArmorPenetration)
            {
                _CompareHeliLeftTextAGMArmorPenetration.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareHeliRightTextAGMArmorPenetration.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftAGMArmorPenetration < rightAGMArmorPenetration)
            {
                _CompareHeliLeftTextAGMArmorPenetration.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareHeliRightTextAGMArmorPenetration.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftAGMArmorPenetration == rightAGMArmorPenetration)
            {
                _CompareHeliLeftTextAGMArmorPenetration.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareHeliRightTextAGMArmorPenetration.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }

            if (leftASMCount > rightASMCount)
            {
                _CompareHeliLeftTextASMCount.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareHeliRightTextASMCount.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftASMCount < rightASMCount)
            {
                _CompareHeliLeftTextASMCount.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareHeliRightTextASMCount.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftASMCount == rightASMCount)
            {
                _CompareHeliLeftTextASMCount.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareHeliRightTextASMCount.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }
            if (leftASMSpeed > rightASMSpeed)
            {
                _CompareHeliLeftTextASMSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareHeliRightTextASMSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftASMSpeed < rightASMSpeed)
            {
                _CompareHeliLeftTextASMSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareHeliRightTextASMSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftASMSpeed == rightASMSpeed)
            {
                _CompareHeliLeftTextASMSpeed.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareHeliRightTextASMSpeed.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }

            if (leftASMArmorPenetration > rightASMArmorPenetration)
            {
                _CompareHeliLeftTextASMArmorPenetration.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareHeliRightTextASMArmorPenetration.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftASMArmorPenetration < rightASMArmorPenetration)
            {
                _CompareHeliLeftTextASMArmorPenetration.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareHeliRightTextASMArmorPenetration.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftASMArmorPenetration == rightASMArmorPenetration)
            {
                _CompareHeliLeftTextASMArmorPenetration.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareHeliRightTextASMArmorPenetration.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }

            if (leftAGMRange > rightAGMRange)
            {
                _CompareHeliLeftTextAGMRange.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareHeliRightTextAGMRange.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftAGMRange < rightAGMRange)
            {
                _CompareHeliLeftTextAGMRange.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareHeliRightTextAGMRange.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftAGMRange == rightAGMRange)
            {
                _CompareHeliLeftTextAGMRange.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareHeliRightTextAGMRange.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }

            if (leftBombLoad > rightBombLoad)
            {
                _CompareHeliLeftTextBombLoad.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareHeliRightTextBombLoad.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftBombLoad < rightBombLoad)
            {
                _CompareHeliLeftTextBombLoad.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareHeliRightTextBombLoad.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftBombLoad == rightBombLoad)
            {
                _CompareHeliLeftTextBombLoad.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareHeliRightTextBombLoad.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }




        }


    }
}

/*                private double leftMainCaliber;
    private double leftMainCaliberReload;
    private double leftMainCaliberTNT;
    private double leftAuxiliaryCaliber;
    private double leftAuxiliaryCaliberReload;
    private double leftAAACaliber;
    private double leftAAACaliberReload;
    private double leftTorpedo;
    private int leftTorpedoItem;
    private int leftTorpedoMaxSpeed;
    private double leftTorpedoTNT;
    private int leftMaxSpeed;
    private int leftReverseSpeed;
    private int leftAcceleration;
    private int leftBrakingTime;
    private int leftTurn360;
    private int leftDisplacement;
    private int leftCrewCount; 

   private double rightMainCaliber;
private double rightMainCaliberReload;
private double rightMainCaliberTNT;
private double rightAuxiliaryCaliber;
private double rightAuxiliaryCaliberReload;
private double rightAAACaliber;
private double rightAAACaliberReload;
private double rightTorpedo;
private int rightTorpedoItem;
private int rightTorpedoMaxSpeed;
private double rightTorpedoTNT;
private int rightMaxSpeed;
private int rightReverseSpeed;
private int rightAcceleration;
private int rightBrakingTime;
private int rightTurn360;
private int rightDisplacement;
private int rightCrewCount;

 */
