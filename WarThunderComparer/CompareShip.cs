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
    [Activity(ScreenOrientation = ScreenOrientation.Portrait)]
    class CompareShip : AppCompatActivity
    {
        Spinner _CompareSpinnerNationLeft;
        Spinner _CompareSpinnerShipLeft;
        Spinner _CompareSpinnerRankLeft;
        Spinner _CompareSpinnerNationRight;
        Spinner _CompareSpinnerShipRight;
        Spinner _CompareSpinnerRankRight;
        //Объявление  спиннеров и скролов с XAML


        #region Текстовые поля и картинки
        Context context;
        ImageView _CompareImageLeft;
        ImageView _CompareLeftFlag;
        ImageView _CompareLeftHandingRocket;
        ImageView _CompareLeftHandlingDepthCharge;
        ImageView _CompareLeftHandlingTorpedo;
        ImageView _CompareLeftHandingMine;

        ImageView _CompareLeftMCShellAP;
        ImageView _CompareLeftMCShellAPHE;
        ImageView _CompareLeftMCShellAPCR;
        ImageView _CompareLeftMCShellHE;
        ImageView _CompareLeftMCShellShrapnel;
        ImageView _CompareLeftAUShellShrapnel;
        ImageView _CompareLeftMCShellHEVT;
        ImageView _CompareLeftMCShellHEDF;
        ImageView _CompareLeftMCShellFOG;
        ImageView _CompareLeftAUShellAP;
        ImageView _CompareLeftAUShellAPHE;
        ImageView _CompareLeftAUShellAPCR;
        ImageView _CompareLeftAUShellHE;
        ImageView _CompareLeftAUShellHEVT;
        ImageView _CompareLeftAUShellHEDF;
        ImageView _CompareLeftAUShellFOG;
        ImageView _CompareLeftAAAShellAP;
        ImageView _CompareLeftAAAShellAPHE;
        ImageView _CompareLeftAAAShellAPCR;
        ImageView _CompareLeftAAAShellHE;
        ImageView _CompareLeftAAAShellHEVT;
        ImageView _CompareLeftAAAShellHEDF;
        ImageView _CompareLeftAAAShellFOG;

        TextView _CompareShipLeftTextMainCaliberName;
        TextView _CompareShipLeftTextMainCaliberReload;
        TextView _CompareShipLeftTextMainCaliberTNT;
        TextView _CompareShipLeftTextAuxiliaryCaliberName;
        TextView _CompareShipLeftTextAuxiliaryCaliberReload;
        TextView _CompareShipLeftTextAAACaliberName;
        TextView _CompareShipLeftTextAAACaliberReload;
        TextView _CompareShipLeftTextTorpedoName;
        TextView _CompareShipLeftTextTorpedoItem;
        TextView _CompareShipLeftTextTorpedoMaxSpeed;
        TextView _CompareShipLeftTextTorpedoTNT;
        TextView _CompareShipLeftTextMaxSpeed;
        TextView _CompareShipLeftTextReverseSpeed;
        TextView _CompareShipLeftTextAcceleration;
        TextView _CompareShipLeftTextBrakingTime;
        TextView _CompareShipLeftTextTurn360;
        TextView _CompareShipLeftTextDisplacement;
        TextView _CompareShipLeftTextCrewCount;
        TextView _CompareShipLabelTextMCShellType;
        TextView _CompareShipLabelTextAUShellType;
        TextView _CompareShipLabelTextAAAShellType;
        TextView _CompareShipLabelTextAdditional;



        ImageView _CompareImageRight;
        ImageView _CompareRightFlag;
        ImageView _CompareRightHandingRocket;
        ImageView _CompareRightHandlingDepthCharge;
        ImageView _CompareRightHandlingTorpedo;
        ImageView _CompareRightHandingMine;

        ImageView _CompareRightMCShellAP;
        ImageView _CompareRightMCShellAPHE;
        ImageView _CompareRightMCShellAPCR;
        ImageView _CompareRightMCShellHE;
        ImageView _CompareRightMCShellShrapnel;
        ImageView _CompareRightAUShellShrapnel;
        ImageView _CompareRightMCShellHEVT;
        ImageView _CompareRightMCShellHEDF;
        ImageView _CompareRightMCShellFOG;
        ImageView _CompareRightAUShellAP;
        ImageView _CompareRightAUShellAPHE;
        ImageView _CompareRightAUShellAPCR;
        ImageView _CompareRightAUShellHE;
        ImageView _CompareRightAUShellHEVT;
        ImageView _CompareRightAUShellHEDF;
        ImageView _CompareRightAUShellFOG;
        ImageView _CompareRightAAAShellAP;
        ImageView _CompareRightAAAShellAPHE;
        ImageView _CompareRightAAAShellAPCR;
        ImageView _CompareRightAAAShellHE;
        ImageView _CompareRightAAAShellHEVT;
        ImageView _CompareRightAAAShellHEDF;
        ImageView _CompareRightAAAShellFOG;

        TextView _CompareShipRightTextMainCaliberName;
        TextView _CompareShipRightTextMainCaliberReload;
        TextView _CompareShipRightTextMainCaliberTNT;
        TextView _CompareShipRightTextAuxiliaryCaliberName;
        TextView _CompareShipRightTextAuxiliaryCaliberReload;
        TextView _CompareShipRightTextAAACaliberName;
        TextView _CompareShipRightTextAAACaliberReload;
        TextView _CompareShipRightTextTorpedoName;
        TextView _CompareShipRightTextTorpedoItem;
        TextView _CompareShipRightTextTorpedoMaxSpeed;
        TextView _CompareShipRightTextTorpedoTNT;
        TextView _CompareShipRightTextMaxSpeed;
        TextView _CompareShipRightTextReverseSpeed;
        TextView _CompareShipRightTextAcceleration;
        TextView _CompareShipRightTextBrakingTime;
        TextView _CompareShipRightTextTurn360;
        TextView _CompareShipRightTextDisplacement;
        TextView _CompareShipRightTextCrewCount;


        TextView _CompareShipLabelTextMainCaliberReload;
        TextView _CompareShipLabelTextMainCaliberTNT;
        TextView _CompareShipLabelTextAuxiliaryCaliberReload;
        TextView _CompareShipLabelTextAAACaliberReload;
        TextView _CompareShipLabelTextTorpedoItem;
        TextView _CompareShipLabelTextTorpedoMaxSpeed;
        TextView _CompareShipLabelTextTorpedoTNT;
        TextView _CompareShipLabelTextMaxSpeed;
        TextView _CompareShipLabelTextReverseSpeed;
        TextView _CompareShipLabelTextAcceleration;
        TextView _CompareShipLabelTextBrakingTime;
        TextView _CompareShipLabelTextTurn360;
        TextView _CompareShipLabelTextDisplacement;
        TextView _CompareShipLabelTextCrewCount;



        #endregion

        List<Ship> shipsleft;
        List<Ship> shipsright;
        ShipAdapter AdapterShipLeft;
        ShipAdapter AdapterShipRight;
        List<Nation> nations;
        NationAdapter AdapterNationsLeft;
        NationAdapter AdapterNationsRight;
        List<Rank> ranks;
        RankAdapter AdapterRankLeft;
        RankAdapter AdapterRankRight;
        // Объявление адаптеров, коллекций и переменных       


        #region Булевые переменные для картинок
        private int selectedNationLeft;
        private int selectedNationRight;
        private int selectedRankLeft;
        private int selectedRankRight;


        private bool leftHandingRocket;
        private bool leftHandlingDepthCharge;
        private bool leftHandlingTorpedo;
        private bool leftHandingMine;

        private bool leftMCShellAP;
        private bool leftMCShellAPHE;
        private bool leftMCShellAPCR;
        private bool leftMCShellHE;
        private bool leftMCShellHEVT;
        private bool leftMCShellHEDF;
        private bool leftMCShellFOG;
        private bool leftMCShellShrapnel;
        private bool leftAUShellShrapnel;
        private bool leftAUShellAP;
        private bool leftAUShellAPHE;
        private bool leftAUShellAPCR;
        private bool leftAUShellHE;
        private bool leftAUShellHEVT;
        private bool leftAUShellHEDF;
        private bool leftAUShellFOG;
        private bool leftAAAShellAP;
        private bool leftAAAShellAPHE;
        private bool leftAAAShellAPCR;
        private bool leftAAAShellHE;
        private bool leftAAAShellHEVT;
        private bool leftAAAShellHEDF;
        private bool leftAAAShellFOG;

        private double leftMainCaliber;
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


        private bool rightHandingRocket;
        private bool rightHandlingDepthCharge;
        private bool rightHandlingTorpedo;
        private bool rightHandingMine;

        private bool rightMCShellAP;
        private bool rightMCShellAPHE;
        private bool rightMCShellAPCR;
        private bool rightMCShellHE;
        private bool rightMCShellHEVT;
        private bool rightMCShellHEDF;
        private bool rightMCShellFOG;
        private bool rightMCShellShrapnel;
        private bool rightAUShellShrapnel;
        private bool rightAUShellAP;
        private bool rightAUShellAPHE;
        private bool rightAUShellAPCR;
        private bool rightAUShellHE;
        private bool rightAUShellHEVT;
        private bool rightAUShellHEDF;
        private bool rightAUShellFOG;
        private bool rightAAAShellAP;
        private bool rightAAAShellAPHE;
        private bool rightAAAShellAPCR;
        private bool rightAAAShellHE;
        private bool rightAAAShellHEVT;
        private bool rightAAAShellHEDF;
        private bool rightAAAShellFOG;

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
        #endregion


        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\
        DrawerLayout drawerLayout;

        public CompareShip()
        {
        }

        protected CompareShip(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CompareShip);
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
            var adView = FindViewById<AdView>(Resource.Id.adViewCompareShip);
                 var adRequest = new AdRequest.Builder().Build();
                adView.LoadAd(adRequest);
            //var requestbuilder = new AdRequest.Builder().AddTestDevice("D0BE22F1A4BE27C7470F95A699568FE2");
            //adView.LoadAd(requestbuilder.Build());
            //шрифт
            var font = Typeface.CreateFromAsset(Assets, "dinfont.ttf");

            _CompareSpinnerNationLeft = FindViewById<Spinner>(Resource.Id.CompareSpinnerNationLeftS);
            _CompareSpinnerNationRight = FindViewById<Spinner>(Resource.Id.CompareSpinnerNationRightS);
            _CompareSpinnerRankLeft = FindViewById<Spinner>(Resource.Id.CompareSpinnerRankLeftS);
            _CompareSpinnerRankRight = FindViewById<Spinner>(Resource.Id.CompareSpinnerRankRightS);
            _CompareSpinnerShipLeft = FindViewById<Spinner>(Resource.Id.CompareSpinnerShipLeft);
            _CompareSpinnerShipRight = FindViewById<Spinner>(Resource.Id.CompareSpinnerShipRight);
            //Привязка спиннеров к шарп коду 

            #region Привязка TextView к коду

            _CompareImageLeft = FindViewById<ImageView>(Resource.Id.CompareShipImage1);
            _CompareLeftFlag = FindViewById<ImageView>(Resource.Id.CompareShipFlag1);
            _CompareLeftHandingRocket = FindViewById<ImageView>(Resource.Id.CompareShipLeftHandingRocket);
            _CompareLeftHandlingDepthCharge = FindViewById<ImageView>(Resource.Id.CompareShipLeftHandingDepthCharge);
            _CompareLeftHandlingTorpedo = FindViewById<ImageView>(Resource.Id.CompareShipLeftHandingTorpedo);
            _CompareLeftHandingMine = FindViewById<ImageView>(Resource.Id.CompareShipLeftHandingMine);

            _CompareLeftMCShellAP = FindViewById<ImageView>(Resource.Id.CompareShipLeftMCShellAP);
            _CompareLeftMCShellAPHE = FindViewById<ImageView>(Resource.Id.CompareShipLeftMCShellAPHE);
            _CompareLeftMCShellAPCR = FindViewById<ImageView>(Resource.Id.CompareShipLeftMCShellAPCR);
            _CompareLeftMCShellHE = FindViewById<ImageView>(Resource.Id.CompareShipLeftMCShellHE);
            _CompareLeftMCShellHEVT = FindViewById<ImageView>(Resource.Id.CompareShipLeftMCShellHEVT);
            _CompareLeftMCShellHEDF = FindViewById<ImageView>(Resource.Id.CompareShipLeftMCShellHEDF);
            _CompareLeftMCShellFOG = FindViewById<ImageView>(Resource.Id.CompareShipLeftMCShellFOG);
            _CompareLeftMCShellShrapnel = FindViewById<ImageView>(Resource.Id.CompareShipLeftMCShellShrapnel);
            _CompareLeftAUShellShrapnel = FindViewById<ImageView>(Resource.Id.CompareShipLeftAUShellShrapnel);
            _CompareLeftAUShellAP = FindViewById<ImageView>(Resource.Id.CompareShipLeftAUShellAP);
            _CompareLeftAUShellAPHE = FindViewById<ImageView>(Resource.Id.CompareShipLeftAUShellAPHE);
            _CompareLeftAUShellAPCR = FindViewById<ImageView>(Resource.Id.CompareShipLeftAUShellAPCR);
            _CompareLeftAUShellHE = FindViewById<ImageView>(Resource.Id.CompareShipLeftAUShellHE);
            _CompareLeftAUShellHEVT = FindViewById<ImageView>(Resource.Id.CompareShipLeftAUShellHEVT);
            _CompareLeftAUShellHEDF = FindViewById<ImageView>(Resource.Id.CompareShipLeftAUShellHEDF);
            _CompareLeftAUShellFOG = FindViewById<ImageView>(Resource.Id.CompareShipLeftAUShellFOG);
            _CompareLeftAAAShellAP = FindViewById<ImageView>(Resource.Id.CompareShipLeftAAAShellAP);
            _CompareLeftAAAShellAPHE = FindViewById<ImageView>(Resource.Id.CompareShipLeftAAAShellAPHE);
            _CompareLeftAAAShellAPCR = FindViewById<ImageView>(Resource.Id.CompareShipLeftAAAShellAPCR);
            _CompareLeftAAAShellHE = FindViewById<ImageView>(Resource.Id.CompareShipLeftAAAShellHE);
            _CompareLeftAAAShellHEVT = FindViewById<ImageView>(Resource.Id.CompareShipLeftAAAShellHEVT);
            _CompareLeftAAAShellHEDF = FindViewById<ImageView>(Resource.Id.CompareShipLeftAAAShellHEDF);
            _CompareLeftAAAShellFOG = FindViewById<ImageView>(Resource.Id.CompareShipLeftAAAShellFOG);

            _CompareShipLeftTextMainCaliberName = FindViewById<TextView>(Resource.Id.CompareShipLeftMainCaliber);
            _CompareShipLeftTextMainCaliberReload = FindViewById<TextView>(Resource.Id.CompareShipLeftMainCaliberReload);
            _CompareShipLeftTextMainCaliberTNT = FindViewById<TextView>(Resource.Id.CompareShipLeftMainCaliberTNT);
            _CompareShipLeftTextAuxiliaryCaliberName = FindViewById<TextView>(Resource.Id.CompareShipLeftAuxiliaryCaliber);
            _CompareShipLeftTextAuxiliaryCaliberReload = FindViewById<TextView>(Resource.Id.CompareShipLeftAuxiliaryCaliberReload);
            _CompareShipLeftTextAAACaliberName = FindViewById<TextView>(Resource.Id.CompareShipLeftAAACaliber);
            _CompareShipLeftTextAAACaliberReload = FindViewById<TextView>(Resource.Id.CompareShipLeftAAACaliberReload);
            _CompareShipLeftTextTorpedoName = FindViewById<TextView>(Resource.Id.CompareShipLeftTorpedo);
            _CompareShipLeftTextTorpedoItem = FindViewById<TextView>(Resource.Id.CompareShipLeftTorpedoItem);
            _CompareShipLeftTextTorpedoMaxSpeed = FindViewById<TextView>(Resource.Id.CompareShipLeftTorpedoMaxSpeed);
            _CompareShipLeftTextTorpedoTNT = FindViewById<TextView>(Resource.Id.CompareShipLeftTorpedoTNT);
            _CompareShipLeftTextMaxSpeed = FindViewById<TextView>(Resource.Id.CompareShipLeftMaxSpeed);
            _CompareShipLeftTextReverseSpeed = FindViewById<TextView>(Resource.Id.CompareShipLeftReverseSpeed);
            _CompareShipLeftTextAcceleration = FindViewById<TextView>(Resource.Id.CompareShipLeftAcceleration);
            _CompareShipLeftTextBrakingTime = FindViewById<TextView>(Resource.Id.CompareShipLeftBrakingTime);
            _CompareShipLeftTextTurn360 = FindViewById<TextView>(Resource.Id.CompareShipLeftTurn360);
            _CompareShipLeftTextDisplacement = FindViewById<TextView>(Resource.Id.CompareShipLeftDisplacement);
            _CompareShipLeftTextCrewCount = FindViewById<TextView>(Resource.Id.CompareShipLeftCrewCount);




            _CompareImageRight = FindViewById<ImageView>(Resource.Id.CompareShipImage2);
            _CompareRightFlag = FindViewById<ImageView>(Resource.Id.CompareShipFlag2);
            _CompareRightHandingRocket = FindViewById<ImageView>(Resource.Id.CompareShipRightHandingRocket);
            _CompareRightHandlingDepthCharge = FindViewById<ImageView>(Resource.Id.CompareShipRightHandingDepthCharge);
            _CompareRightHandlingTorpedo = FindViewById<ImageView>(Resource.Id.CompareShipRightHandingTorpedo);
            _CompareRightHandingMine = FindViewById<ImageView>(Resource.Id.CompareShipRightHandingMine);

            _CompareRightMCShellAP = FindViewById<ImageView>(Resource.Id.CompareShipRightMCShellAP);
            _CompareRightMCShellAPHE = FindViewById<ImageView>(Resource.Id.CompareShipRightMCShellAPHE);
            _CompareRightMCShellAPCR = FindViewById<ImageView>(Resource.Id.CompareShipRightMCShellAPCR);
            _CompareRightMCShellHE = FindViewById<ImageView>(Resource.Id.CompareShipRightMCShellHE);
            _CompareRightMCShellHEVT = FindViewById<ImageView>(Resource.Id.CompareShipRightMCShellHEVT);
            _CompareRightMCShellHEDF = FindViewById<ImageView>(Resource.Id.CompareShipRightMCShellHEDF);
            _CompareRightMCShellFOG = FindViewById<ImageView>(Resource.Id.CompareShipRightMCShellFOG);
            _CompareRightMCShellShrapnel = FindViewById<ImageView>(Resource.Id.CompareShipRightMCShellShrapnel);
            _CompareRightAUShellShrapnel = FindViewById<ImageView>(Resource.Id.CompareShipRightAUShellShrapnel);
            _CompareRightAUShellAP = FindViewById<ImageView>(Resource.Id.CompareShipRightAUShellAP);
            _CompareRightAUShellAPHE = FindViewById<ImageView>(Resource.Id.CompareShipRightAUShellAPHE);
            _CompareRightAUShellAPCR = FindViewById<ImageView>(Resource.Id.CompareShipRightAUShellAPCR);
            _CompareRightAUShellHE = FindViewById<ImageView>(Resource.Id.CompareShipRightAUShellHE);
            _CompareRightAUShellHEVT = FindViewById<ImageView>(Resource.Id.CompareShipRightAUShellHEVT);
            _CompareRightAUShellHEDF = FindViewById<ImageView>(Resource.Id.CompareShipRightAUShellHEDF);
            _CompareRightAUShellFOG = FindViewById<ImageView>(Resource.Id.CompareShipRightAUShellFOG);
            _CompareRightAAAShellAP = FindViewById<ImageView>(Resource.Id.CompareShipRightAAAShellAP);
            _CompareRightAAAShellAPHE = FindViewById<ImageView>(Resource.Id.CompareShipRightAAAShellAPHE);
            _CompareRightAAAShellAPCR = FindViewById<ImageView>(Resource.Id.CompareShipRightAAAShellAPCR);
            _CompareRightAAAShellHE = FindViewById<ImageView>(Resource.Id.CompareShipRightAAAShellHE);
            _CompareRightAAAShellHEVT = FindViewById<ImageView>(Resource.Id.CompareShipRightAAAShellHEVT);
            _CompareRightAAAShellHEDF = FindViewById<ImageView>(Resource.Id.CompareShipRightAAAShellHEDF);
            _CompareRightAAAShellFOG = FindViewById<ImageView>(Resource.Id.CompareShipRightAAAShellFOG);

            _CompareShipRightTextMainCaliberName = FindViewById<TextView>(Resource.Id.CompareShipRightMainCaliber);
            _CompareShipRightTextMainCaliberReload = FindViewById<TextView>(Resource.Id.CompareShipRightMainCaliberReload);
            _CompareShipRightTextMainCaliberTNT = FindViewById<TextView>(Resource.Id.CompareShipRightMainCaliberTNT);
            _CompareShipRightTextAuxiliaryCaliberName = FindViewById<TextView>(Resource.Id.CompareShipRightAuxiliaryCaliber);
            _CompareShipRightTextAuxiliaryCaliberReload = FindViewById<TextView>(Resource.Id.CompareShipRightAuxiliaryCaliberReload);
            _CompareShipRightTextAAACaliberName = FindViewById<TextView>(Resource.Id.CompareShipRightAAACaliber);
            _CompareShipRightTextAAACaliberReload = FindViewById<TextView>(Resource.Id.CompareShipRightAAACaliberReload);
            _CompareShipRightTextTorpedoName = FindViewById<TextView>(Resource.Id.CompareShipRightTorpedo);
            _CompareShipRightTextTorpedoItem = FindViewById<TextView>(Resource.Id.CompareShipRightTorpedoItem);
            _CompareShipRightTextTorpedoMaxSpeed = FindViewById<TextView>(Resource.Id.CompareShipRightTorpedoMaxSpeed);
            _CompareShipRightTextTorpedoTNT = FindViewById<TextView>(Resource.Id.CompareShipRightTorpedoTNT);
            _CompareShipRightTextMaxSpeed = FindViewById<TextView>(Resource.Id.CompareShipRightMaxSpeed);
            _CompareShipRightTextReverseSpeed = FindViewById<TextView>(Resource.Id.CompareShipRightReverseSpeed);
            _CompareShipRightTextAcceleration = FindViewById<TextView>(Resource.Id.CompareShipRightAcceleration);
            _CompareShipRightTextBrakingTime = FindViewById<TextView>(Resource.Id.CompareShipRightBrakingTime);
            _CompareShipRightTextTurn360 = FindViewById<TextView>(Resource.Id.CompareShipRightTurn360);
            _CompareShipRightTextDisplacement = FindViewById<TextView>(Resource.Id.CompareShipRightDisplacement);
            _CompareShipRightTextCrewCount = FindViewById<TextView>(Resource.Id.CompareShipRightCrewCount);




            _CompareShipLabelTextMainCaliberReload = FindViewById<TextView>(Resource.Id.CompareShipLabelMainCaliberReload);
            _CompareShipLabelTextMainCaliberTNT = FindViewById<TextView>(Resource.Id.CompareShipLabelMainCaliberTNT);
            _CompareShipLabelTextAuxiliaryCaliberReload = FindViewById<TextView>(Resource.Id.CompareShipLabelAuxiliaryCaliberReload);
            _CompareShipLabelTextAAACaliberReload = FindViewById<TextView>(Resource.Id.CompareShipLabelAAACaliberReload);
            _CompareShipLabelTextTorpedoItem = FindViewById<TextView>(Resource.Id.CompareShipLabelTorpedoItem);
            _CompareShipLabelTextTorpedoMaxSpeed = FindViewById<TextView>(Resource.Id.CompareShipLabelTorpedoMaxSpeed);
            _CompareShipLabelTextTorpedoTNT = FindViewById<TextView>(Resource.Id.CompareShipLabelTorpedoTNT);
            _CompareShipLabelTextMaxSpeed = FindViewById<TextView>(Resource.Id.CompareShipLabelMaxSpeed);
            _CompareShipLabelTextReverseSpeed = FindViewById<TextView>(Resource.Id.CompareShipLabelReverseSpeed);
            _CompareShipLabelTextAcceleration = FindViewById<TextView>(Resource.Id.CompareShipLabelAcceleration);
            _CompareShipLabelTextBrakingTime = FindViewById<TextView>(Resource.Id.CompareShipLabelBrakingTime);
            _CompareShipLabelTextTurn360 = FindViewById<TextView>(Resource.Id.CompareShipLabelTurn360);
            _CompareShipLabelTextDisplacement = FindViewById<TextView>(Resource.Id.CompareShipLabelDisplacement);
            _CompareShipLabelTextCrewCount = FindViewById<TextView>(Resource.Id.CompareShipLabelCrewCount);
            _CompareShipLabelTextMCShellType = FindViewById<TextView>(Resource.Id.CompareShipLabelMCShellType);
            _CompareShipLabelTextAUShellType = FindViewById<TextView>(Resource.Id.CompareShipLabelAUShellType);
            _CompareShipLabelTextAAAShellType = FindViewById<TextView>(Resource.Id.CompareShipLabelAAAShellType);
            _CompareShipLabelTextAdditional = FindViewById<TextView>(Resource.Id.CompareShipLabelAdditionalWeapon);
            #endregion

            #region Изменение шрифта и цвета 
            _CompareShipLabelTextMainCaliberReload.Typeface = font;
            _CompareShipLabelTextMainCaliberTNT.Typeface = font;
            _CompareShipLabelTextAuxiliaryCaliberReload.Typeface = font;
            _CompareShipLabelTextAAACaliberReload.Typeface = font;
            _CompareShipLabelTextTorpedoItem.Typeface = font;
            _CompareShipLabelTextTorpedoMaxSpeed.Typeface = font;
            _CompareShipLabelTextTorpedoTNT.Typeface = font;
            _CompareShipLabelTextMaxSpeed.Typeface = font;
            _CompareShipLabelTextReverseSpeed.Typeface = font;
            _CompareShipLabelTextAcceleration.Typeface = font;
            _CompareShipLabelTextBrakingTime.Typeface = font;
            _CompareShipLabelTextTurn360.Typeface = font;
            _CompareShipLabelTextDisplacement.Typeface = font;
            _CompareShipLabelTextCrewCount.Typeface = font;

            _CompareShipLabelTextMainCaliberReload.SetTextColor(Color.Black);
            _CompareShipLabelTextMainCaliberTNT.SetTextColor(Color.Black);
            _CompareShipLabelTextAuxiliaryCaliberReload.SetTextColor(Color.Black);
            _CompareShipLabelTextAAACaliberReload.SetTextColor(Color.Black);
            _CompareShipLabelTextTorpedoItem.SetTextColor(Color.Black);
            _CompareShipLabelTextTorpedoMaxSpeed.SetTextColor(Color.Black);
            _CompareShipLabelTextTorpedoTNT.SetTextColor(Color.Black);
            _CompareShipLabelTextMaxSpeed.SetTextColor(Color.Black);
            _CompareShipLabelTextReverseSpeed.SetTextColor(Color.Black);
            _CompareShipLabelTextAcceleration.SetTextColor(Color.Black);
            _CompareShipLabelTextBrakingTime.SetTextColor(Color.Black);
            _CompareShipLabelTextTurn360.SetTextColor(Color.Black);
            _CompareShipLabelTextDisplacement.SetTextColor(Color.Black);
            _CompareShipLabelTextCrewCount.SetTextColor(Color.Black);
            _CompareShipLabelTextMCShellType.Typeface = font;
            _CompareShipLabelTextAUShellType.Typeface = font;
            _CompareShipLabelTextAAAShellType.Typeface = font;
            _CompareShipLabelTextAdditional.Typeface = font;

            _CompareShipLeftTextMainCaliberName.SetTextColor(Color.Black);
            _CompareShipLeftTextMainCaliberReload.SetTextColor(Color.Black);
            _CompareShipLeftTextMainCaliberTNT.SetTextColor(Color.Black);
            _CompareShipLeftTextAuxiliaryCaliberName.SetTextColor(Color.Black);
            _CompareShipLeftTextAuxiliaryCaliberReload.SetTextColor(Color.Black);
            _CompareShipLeftTextAAACaliberName.SetTextColor(Color.Black);
            _CompareShipLeftTextAAACaliberReload.SetTextColor(Color.Black);
            _CompareShipLeftTextTorpedoName.SetTextColor(Color.Black);
            _CompareShipLeftTextTorpedoItem.SetTextColor(Color.Black);
            _CompareShipLeftTextTorpedoMaxSpeed.SetTextColor(Color.Black);
            _CompareShipLeftTextTorpedoTNT.SetTextColor(Color.Black);
            _CompareShipLeftTextMaxSpeed.SetTextColor(Color.Black);
            _CompareShipLeftTextReverseSpeed.SetTextColor(Color.Black);
            _CompareShipLeftTextAcceleration.SetTextColor(Color.Black);
            _CompareShipLeftTextBrakingTime.SetTextColor(Color.Black);
            _CompareShipLeftTextTurn360.SetTextColor(Color.Black);
            _CompareShipLeftTextDisplacement.SetTextColor(Color.Black);
            _CompareShipLeftTextCrewCount.SetTextColor(Color.Black);


            _CompareShipRightTextMainCaliberName.SetTextColor(Color.Black);
            _CompareShipRightTextMainCaliberReload.SetTextColor(Color.Black);
            _CompareShipRightTextMainCaliberTNT.SetTextColor(Color.Black);
            _CompareShipRightTextAuxiliaryCaliberName.SetTextColor(Color.Black);
            _CompareShipRightTextAuxiliaryCaliberReload.SetTextColor(Color.Black);
            _CompareShipRightTextAAACaliberName.SetTextColor(Color.Black);
            _CompareShipRightTextAAACaliberReload.SetTextColor(Color.Black);
            _CompareShipRightTextTorpedoName.SetTextColor(Color.Black);
            _CompareShipRightTextTorpedoItem.SetTextColor(Color.Black);
            _CompareShipRightTextTorpedoMaxSpeed.SetTextColor(Color.Black);
            _CompareShipRightTextTorpedoTNT.SetTextColor(Color.Black);
            _CompareShipRightTextMaxSpeed.SetTextColor(Color.Black);
            _CompareShipRightTextReverseSpeed.SetTextColor(Color.Black);
            _CompareShipRightTextAcceleration.SetTextColor(Color.Black);
            _CompareShipRightTextBrakingTime.SetTextColor(Color.Black);
            _CompareShipRightTextTurn360.SetTextColor(Color.Black);
            _CompareShipRightTextDisplacement.SetTextColor(Color.Black);
            _CompareShipRightTextCrewCount.SetTextColor(Color.Black);

            #endregion

            nations = NationCollection.GetNation();
            AdapterNationsLeft = new NationAdapter(this, nations);
            AdapterNationsRight = new NationAdapter(this, nations);
            _CompareSpinnerNationLeft.Adapter = AdapterNationsLeft;
            _CompareSpinnerNationRight.Adapter = AdapterNationsRight;
            _CompareSpinnerNationLeft.SetSelection(4); //Автовыбор
            _CompareSpinnerNationRight.SetSelection(2); //Автовыбор
            selectedNationLeft = 4;   //Автовыбор
            selectedNationRight = 2;   //Автовыбор

            ranks = RankCollection.GetRank();
            AdapterRankLeft = new RankAdapter(this, ranks);
            AdapterRankRight = new RankAdapter(this, ranks);
            _CompareSpinnerRankLeft.Adapter = AdapterRankLeft;
            _CompareSpinnerRankRight.Adapter = AdapterRankRight;
            _CompareSpinnerRankLeft.SetSelection(4); //Автовыбор
            _CompareSpinnerRankRight.SetSelection(4); //Автовыбор
            selectedRankLeft = 4;   //Автовыбор
            selectedRankRight = 4;   //Автовыбор

            _CompareSpinnerShipLeft.SetSelection(1);   //Автовыбор
            _CompareSpinnerShipRight.SetSelection(1);   //Автовыбор

            //Объявление коллекции наций, рангов и адаптеров

            _CompareSpinnerShipLeft.ItemSelected += _CompareSpinnerShipLeft_ItemSelected;
            _CompareSpinnerShipRight.ItemSelected += _CompareSpinnerShipRight_ItemSelected;
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
            ShipLeftSelector();
        }


        private void _CompareSpinnerNationRight_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedNationRight = nations[e.Position].Id;
            ShipRightSelector();
        }

        //Обработчики событий  нажатия на ранги

        private void _CompareSpinnerRankLeft_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedRankLeft = ranks[e.Position].Id;
            ShipLeftSelector();
        }

        private void _CompareSpinnerRankRight_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedRankRight = ranks[e.Position].Id;
            ShipRightSelector();
        }


        //Обработчики событий  нажатия на корабли


        private void _CompareSpinnerShipLeft_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            leftMainCaliber = shipsleft[e.Position].MainCaliberForCompare;
            leftMainCaliberReload = shipsleft[e.Position].MainCaliberReload;
            leftMainCaliberTNT = shipsleft[e.Position].MainCaliberTNT;
            leftAuxiliaryCaliber = shipsleft[e.Position].AuxiliaryCaliberForCompare;
            leftAuxiliaryCaliberReload = shipsleft[e.Position].AuxiliaryCaliberReload;
            leftAAACaliber = shipsleft[e.Position].AAACaliberForCompare;
            leftAAACaliberReload = shipsleft[e.Position].AAACaliberReload;
            leftTorpedo = shipsleft[e.Position].TorpedoTNT;
            leftTorpedoItem = shipsleft[e.Position].TorpedoItem;
            leftTorpedoMaxSpeed = shipsleft[e.Position].TorpedoMaxSpeed;
            leftTorpedoTNT = shipsleft[e.Position].TorpedoTNT;
            leftMaxSpeed = shipsleft[e.Position].MaxSpeed;
            leftReverseSpeed = shipsleft[e.Position].ReverseSpeed;
            leftAcceleration = shipsleft[e.Position].Acceleration;
            leftBrakingTime = shipsleft[e.Position].BrakingTime;
            leftTurn360 = shipsleft[e.Position].Turn360;
            leftDisplacement = shipsleft[e.Position].Displacement;
            leftCrewCount = shipsleft[e.Position].CrewCount;
            //Для подсветки

            leftHandingRocket = shipsleft[e.Position].HandingRocket;
            leftHandlingDepthCharge = shipsleft[e.Position].HandingDepthCharge;
            leftHandlingTorpedo = shipsleft[e.Position].HandingTorpedo;
            leftHandingMine = shipsleft[e.Position].HandingMine;

            leftMCShellAP = shipsleft[e.Position].MCShellAP;
            leftMCShellAPHE = shipsleft[e.Position].MCShellAPHE;
            leftMCShellAPCR = shipsleft[e.Position].MCShellAPCR;
            leftMCShellHE = shipsleft[e.Position].MCShellHE;
            leftMCShellHEVT = shipsleft[e.Position].MCShellHEVT;
            leftMCShellHEDF = shipsleft[e.Position].MCShellHEDF;
            leftMCShellFOG = shipsleft[e.Position].MCShellFOG;
            leftMCShellShrapnel = shipsleft[e.Position].MCShellShrapnel;
            leftAUShellShrapnel = shipsleft[e.Position].AUShellShrapnel;
            leftAUShellAP = shipsleft[e.Position].AUShellAP;
            leftAUShellAPHE = shipsleft[e.Position].AUShellAPHE;
            leftAUShellAPCR = shipsleft[e.Position].AUShellAPCR;
            leftAUShellHE = shipsleft[e.Position].AUShellHE;
            leftAUShellHEVT = shipsleft[e.Position].AUShellHEVT;
            leftAUShellHEDF = shipsleft[e.Position].AUShellHEDF;
            leftAUShellFOG = shipsleft[e.Position].AUShellFOG;
            leftAAAShellAP = shipsleft[e.Position].AAAShellAP;
            leftAAAShellAPHE = shipsleft[e.Position].AAAShellAPHE;
            leftAAAShellAPCR = shipsleft[e.Position].AAAShellAPCR;
            leftAAAShellHE = shipsleft[e.Position].AAAShellHE;
            leftAAAShellHEVT = shipsleft[e.Position].AAAShellHEVT;
            leftAAAShellHEDF = shipsleft[e.Position].AAAShellHEDF;
            leftAAAShellFOG = shipsleft[e.Position].AAAShellFOG;
            //Для картинок снарядов и доп вооружения
            _CompareImageLeft.SetImageResource(shipsleft[e.Position].Image);
            _CompareLeftFlag.SetImageResource(shipsleft[e.Position].FlagImage);
            _CompareShipLeftTextMainCaliberName.SetText(shipsleft[e.Position].MainCaliberName, TextView.BufferType.Normal);
            _CompareShipLeftTextMainCaliberReload.SetText(shipsleft[e.Position].MainCaliberReload.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            _CompareShipLeftTextAuxiliaryCaliberName.SetText(shipsleft[e.Position].AuxiliaryCaliberName, TextView.BufferType.Normal);
            _CompareShipLeftTextAuxiliaryCaliberReload.SetText(shipsleft[e.Position].AuxiliaryCaliberReload.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            _CompareShipLeftTextAAACaliberName.SetText(shipsleft[e.Position].AAACaliberName, TextView.BufferType.Normal);
            _CompareShipLeftTextAAACaliberReload.SetText(shipsleft[e.Position].AAACaliberReload.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            _CompareShipLeftTextTorpedoName.SetText(shipsleft[e.Position].TorpedoName, TextView.BufferType.Normal);
            _CompareShipLeftTextTorpedoItem.SetText(shipsleft[e.Position].TorpedoItem.ToString() + context.Resources.GetString(Resource.String.AbbrITEMS), TextView.BufferType.Normal);
          _CompareShipLeftTextAcceleration.SetText(shipsleft[e.Position].Acceleration.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            _CompareShipLeftTextBrakingTime.SetText(shipsleft[e.Position].BrakingTime.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            //
            int newTurn360 = shipsleft[e.Position].Turn360;
            TimeSpan timeSpan = TimeSpan.FromSeconds(newTurn360);
            string turnToShow = timeSpan.ToString(@"mm\:ss");
            //
            _CompareShipLeftTextTurn360.SetText(turnToShow, TextView.BufferType.Normal);
            _CompareShipLeftTextCrewCount.SetText(shipsleft[e.Position].CrewCount.ToString() + context.Resources.GetString(Resource.String.AbbrITEMS), TextView.BufferType.Normal);

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            ISharedPreferencesEditor editor = prefs.Edit();
            var switchchecked = prefs.GetBoolean("key_kmhtomph", false);
            if (switchchecked)
            {
                var maxSpeed = shipsleft[e.Position].MaxSpeed * 0.621371192;
                var reverseSpeed = shipsleft[e.Position].ReverseSpeed * 0.621371192;
                var torpedoMaxSpeed = shipsleft[e.Position].TorpedoMaxSpeed * 0.621371192;
                var mainCaliberTNT = shipsleft[e.Position].MainCaliberTNT * 2.204622621849;
                var torpedoTNT = shipsleft[e.Position].TorpedoTNT * 2.204622621849;
                var displacement = shipsleft[e.Position].Displacement * 1.10231131;
                maxSpeed = Math.Round(maxSpeed, 0);
                reverseSpeed = Math.Round(reverseSpeed, 0);
                torpedoMaxSpeed = Math.Round(torpedoMaxSpeed, 0);
                mainCaliberTNT = Math.Round(mainCaliberTNT, 1);
                torpedoTNT = Math.Round(torpedoTNT, 0);
                displacement = Math.Round(displacement, 0);

                _CompareShipLeftTextMaxSpeed.SetText(maxSpeed + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _CompareShipLeftTextReverseSpeed.SetText(reverseSpeed + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _CompareShipLeftTextTorpedoMaxSpeed.SetText(torpedoMaxSpeed + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _CompareShipLeftTextMainCaliberTNT.SetText(mainCaliberTNT + context.Resources.GetString(Resource.String.AbbrLB), TextView.BufferType.Normal);
                _CompareShipLeftTextTorpedoTNT.SetText(torpedoTNT + context.Resources.GetString(Resource.String.AbbrLB), TextView.BufferType.Normal);
                _CompareShipLeftTextDisplacement.SetText(displacement  + context.Resources.GetString(Resource.String.AbbrST), TextView.BufferType.Normal);
            }
            else
            {
                _CompareShipLeftTextMaxSpeed.SetText(shipsleft[e.Position].MaxSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _CompareShipLeftTextReverseSpeed.SetText(shipsleft[e.Position].ReverseSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _CompareShipLeftTextTorpedoMaxSpeed.SetText(shipsleft[e.Position].TorpedoMaxSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _CompareShipLeftTextMainCaliberTNT.SetText(shipsleft[e.Position].MainCaliberTNT.ToString() + context.Resources.GetString(Resource.String.AbbrKG), TextView.BufferType.Normal);
                _CompareShipLeftTextTorpedoTNT.SetText(shipsleft[e.Position].TorpedoTNT.ToString() + context.Resources.GetString(Resource.String.AbbrKG), TextView.BufferType.Normal);
                _CompareShipLeftTextDisplacement.SetText(shipsleft[e.Position].Displacement.ToString() + context.Resources.GetString(Resource.String.AbbrT), TextView.BufferType.Normal);

            }



            ShipShowBestViaBackgroundColor();
            ShipLeftHandingWeaponShower();

        }

        private void _CompareSpinnerShipRight_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            rightMainCaliber = shipsright[e.Position].MainCaliberForCompare;
            rightMainCaliberReload = shipsright[e.Position].MainCaliberReload;
            rightMainCaliberTNT = shipsright[e.Position].MainCaliberTNT;
            rightAuxiliaryCaliber = shipsright[e.Position].AuxiliaryCaliberForCompare;
            rightAuxiliaryCaliberReload = shipsright[e.Position].AuxiliaryCaliberReload;
            rightAAACaliber = shipsright[e.Position].AAACaliberForCompare;
            rightAAACaliberReload = shipsright[e.Position].AAACaliberReload;
            rightTorpedo = shipsright[e.Position].TorpedoTNT;
            rightTorpedoItem = shipsright[e.Position].TorpedoItem;
            rightTorpedoMaxSpeed = shipsright[e.Position].TorpedoMaxSpeed;
            rightTorpedoTNT = shipsright[e.Position].TorpedoTNT;
            rightMaxSpeed = shipsright[e.Position].MaxSpeed;
            rightReverseSpeed = shipsright[e.Position].ReverseSpeed;
            rightAcceleration = shipsright[e.Position].Acceleration;
            rightBrakingTime = shipsright[e.Position].BrakingTime;
            rightTurn360 = shipsright[e.Position].Turn360;
            rightDisplacement = shipsright[e.Position].Displacement;
            rightCrewCount = shipsright[e.Position].CrewCount;
            //Для подсветки

            rightHandingRocket = shipsright[e.Position].HandingRocket;
            rightHandlingDepthCharge = shipsright[e.Position].HandingDepthCharge;
            rightHandlingTorpedo = shipsright[e.Position].HandingTorpedo;
            rightHandingMine = shipsright[e.Position].HandingMine;

            rightMCShellAP = shipsright[e.Position].MCShellAP;
            rightMCShellAPHE = shipsright[e.Position].MCShellAPHE;
            rightMCShellAPCR = shipsright[e.Position].MCShellAPCR;
            rightMCShellHE = shipsright[e.Position].MCShellHE;
            rightMCShellHEVT = shipsright[e.Position].MCShellHEVT;
            rightMCShellHEDF = shipsright[e.Position].MCShellHEDF;
            rightMCShellFOG = shipsright[e.Position].MCShellFOG;
            rightMCShellShrapnel = shipsright[e.Position].MCShellShrapnel;
            rightAUShellShrapnel = shipsright[e.Position].AUShellShrapnel;
            rightAUShellAP = shipsright[e.Position].AUShellAP;
            rightAUShellAPHE = shipsright[e.Position].AUShellAPHE;
            rightAUShellAPCR = shipsright[e.Position].AUShellAPCR;
            rightAUShellHE = shipsright[e.Position].AUShellHE;
            rightAUShellHEVT = shipsright[e.Position].AUShellHEVT;
            rightAUShellHEDF = shipsright[e.Position].AUShellHEDF;
            rightAUShellFOG = shipsright[e.Position].AUShellFOG;
            rightAAAShellAP = shipsright[e.Position].AAAShellAP;
            rightAAAShellAPHE = shipsright[e.Position].AAAShellAPHE;
            rightAAAShellAPCR = shipsright[e.Position].AAAShellAPCR;
            rightAAAShellHE = shipsright[e.Position].AAAShellHE;
            rightAAAShellHEVT = shipsright[e.Position].AAAShellHEVT;
            rightAAAShellHEDF = shipsright[e.Position].AAAShellHEDF;
            rightAAAShellFOG = shipsright[e.Position].AAAShellFOG;
            //Для картинок снарядов и доп вооружения
            _CompareImageRight.SetImageResource(shipsright[e.Position].Image);
            _CompareRightFlag.SetImageResource(shipsright[e.Position].FlagImage);
            _CompareShipRightTextMainCaliberName.SetText(shipsright[e.Position].MainCaliberName, TextView.BufferType.Normal);
            _CompareShipRightTextMainCaliberReload.SetText(shipsright[e.Position].MainCaliberReload.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            _CompareShipRightTextAuxiliaryCaliberName.SetText(shipsright[e.Position].AuxiliaryCaliberName, TextView.BufferType.Normal);
            _CompareShipRightTextAuxiliaryCaliberReload.SetText(shipsright[e.Position].AuxiliaryCaliberReload.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            _CompareShipRightTextAAACaliberName.SetText(shipsright[e.Position].AAACaliberName, TextView.BufferType.Normal);
            _CompareShipRightTextAAACaliberReload.SetText(shipsright[e.Position].AAACaliberReload.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            _CompareShipRightTextTorpedoName.SetText(shipsright[e.Position].TorpedoName, TextView.BufferType.Normal);
            _CompareShipRightTextTorpedoItem.SetText(shipsright[e.Position].TorpedoItem.ToString() + context.Resources.GetString(Resource.String.AbbrITEMS), TextView.BufferType.Normal);
            _CompareShipRightTextAcceleration.SetText(shipsright[e.Position].Acceleration.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            _CompareShipRightTextBrakingTime.SetText(shipsright[e.Position].BrakingTime.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            //
            int newTurn360 = shipsright[e.Position].Turn360;
            TimeSpan timeSpan = TimeSpan.FromSeconds(newTurn360);
            string turnToShow = timeSpan.ToString(@"mm\:ss");
            //
            _CompareShipRightTextTurn360.SetText(turnToShow, TextView.BufferType.Normal);
            _CompareShipRightTextCrewCount.SetText(shipsright[e.Position].CrewCount.ToString() + context.Resources.GetString(Resource.String.AbbrITEMS), TextView.BufferType.Normal);

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            ISharedPreferencesEditor editor = prefs.Edit();
            var switchchecked = prefs.GetBoolean("key_kmhtomph", false);
            if (switchchecked)
            {
                var maxSpeed = shipsright[e.Position].MaxSpeed * 0.621371192;
                var reverseSpeed = shipsright[e.Position].ReverseSpeed * 0.621371192;
                var torpedoMaxSpeed = shipsright[e.Position].TorpedoMaxSpeed * 0.621371192;
                var mainCaliberTNT = shipsright[e.Position].MainCaliberTNT * 2.204622621849;
                var torpedoTNT = shipsright[e.Position].TorpedoTNT * 2.204622621849;
                var displacement = shipsright[e.Position].Displacement * 1.10231131;
                maxSpeed = Math.Round(maxSpeed, 0);
                reverseSpeed = Math.Round(reverseSpeed, 0);
                torpedoMaxSpeed = Math.Round(torpedoMaxSpeed, 0);
                mainCaliberTNT = Math.Round(mainCaliberTNT, 1);
                torpedoTNT = Math.Round(torpedoTNT, 0);
                displacement = Math.Round(displacement, 0);

                _CompareShipRightTextMaxSpeed.SetText(maxSpeed + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _CompareShipRightTextReverseSpeed.SetText(reverseSpeed + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _CompareShipRightTextTorpedoMaxSpeed.SetText(torpedoMaxSpeed + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _CompareShipRightTextMainCaliberTNT.SetText(mainCaliberTNT + context.Resources.GetString(Resource.String.AbbrLB), TextView.BufferType.Normal);
                _CompareShipRightTextTorpedoTNT.SetText(torpedoTNT + context.Resources.GetString(Resource.String.AbbrLB), TextView.BufferType.Normal);
                _CompareShipRightTextDisplacement.SetText(displacement + context.Resources.GetString(Resource.String.AbbrST), TextView.BufferType.Normal);
            }
            else
            {
                _CompareShipRightTextMaxSpeed.SetText(shipsright[e.Position].MaxSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _CompareShipRightTextReverseSpeed.SetText(shipsright[e.Position].ReverseSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _CompareShipRightTextTorpedoMaxSpeed.SetText(shipsright[e.Position].TorpedoMaxSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _CompareShipRightTextMainCaliberTNT.SetText(shipsright[e.Position].MainCaliberTNT.ToString() + context.Resources.GetString(Resource.String.AbbrKG), TextView.BufferType.Normal);
                _CompareShipRightTextTorpedoTNT.SetText(shipsright[e.Position].TorpedoTNT.ToString() + context.Resources.GetString(Resource.String.AbbrKG), TextView.BufferType.Normal);
                _CompareShipRightTextDisplacement.SetText(shipsright[e.Position].Displacement.ToString() + context.Resources.GetString(Resource.String.AbbrT), TextView.BufferType.Normal);

            }



            ShipShowBestViaBackgroundColor();
            ShipRightHandingWeaponShower();

        }

        private void ShipLeftSelector()
        {
            if (selectedNationLeft == 100 && selectedRankLeft == 100)
            { 
                shipsleft = ShipCollection.GetShip();
            AdapterShipLeft = new ShipAdapter(this, shipsleft);
            _CompareSpinnerShipLeft.Adapter = AdapterShipLeft;
            }
            else
            if (selectedNationLeft == 100)
            {
                List<Ship> shipsAll = ShipCollection.GetShip();
                var shipvar = from h in shipsAll
                              where h.RankId == selectedRankLeft
                              select h;
                shipsleft = shipvar.ToList<Ship>();
                AdapterShipLeft = new ShipAdapter(this, shipsleft);
                _CompareSpinnerShipLeft.Adapter = AdapterShipLeft;
            }
            else
           if (selectedRankLeft == 100)
            {
                List<Ship> shipsAll = ShipCollection.GetShip();
                var shipvar = from h in shipsAll
                              where h.NationId == selectedNationLeft
                              select h;
                shipsleft = shipvar.ToList<Ship>();
                AdapterShipLeft = new ShipAdapter(this, shipsleft);
                _CompareSpinnerShipLeft.Adapter = AdapterShipLeft;
            }
            else
            {
                shipsleft = ShipSelectorWithout100left(selectedNationLeft, selectedRankLeft);
                AdapterShipLeft = new ShipAdapter(this, shipsleft);
                _CompareSpinnerShipLeft.Adapter = AdapterShipLeft;
            }
        }

        private void ShipRightSelector()
        {
            if (selectedNationRight == 100 && selectedRankRight == 100)
            {
                shipsright = ShipCollection.GetShip();
                AdapterShipRight = new ShipAdapter(this, shipsright);
                _CompareSpinnerShipRight.Adapter = AdapterShipRight;
            }
            else
            if (selectedNationRight == 100)
            {
                List<Ship> shipsAll = ShipCollection.GetShip();
                var shipvar = from h in shipsAll
                              where h.RankId == selectedRankRight
                              select h;
                shipsright = shipvar.ToList<Ship>();
                AdapterShipRight = new ShipAdapter(this, shipsright);
                _CompareSpinnerShipRight.Adapter = AdapterShipRight;
            }
            else
           if (selectedRankRight == 100)
            {
                List<Ship> shipsAll = ShipCollection.GetShip();
                var shipvar = from h in shipsAll
                              where h.NationId == selectedNationRight
                              select h;
                shipsright = shipvar.ToList<Ship>();
                AdapterShipRight = new ShipAdapter(this, shipsright);
                _CompareSpinnerShipRight.Adapter = AdapterShipRight;
            }
            else
            {
                shipsright = ShipSelectorWithout100right(selectedNationRight, selectedRankRight);
                AdapterShipRight = new ShipAdapter(this, shipsright);
                _CompareSpinnerShipRight.Adapter = AdapterShipRight;
            }
        }

        private List<Ship> ShipSelectorWithout100left(int selectedNationLeft, int selectedRankLeft)
        {
            this.selectedNationLeft = selectedNationLeft;
            this.selectedRankLeft = selectedRankLeft;

            List<Ship> shipsAll = ShipCollection.GetShip();
            var shipvar = from h in shipsAll
                          where h.NationId == selectedNationLeft
                          where h.RankId == selectedRankLeft
                          select h;
            return shipvar.ToList<Ship>();
        }

        private List<Ship> ShipSelectorWithout100right(int selectedNationRight, int selectedRankRight)
        {
            this.selectedNationRight = selectedNationRight;
            this.selectedRankRight = selectedRankRight;

            List<Ship> shipsAll = ShipCollection.GetShip();
            var shipvar = from h in shipsAll
                          where h.NationId == selectedNationRight
                          where h.RankId == selectedRankRight
                          select h;
            return shipvar.ToList<Ship>();
        }

        private void ShipLeftHandingWeaponShower()
        {
                if (leftHandingRocket == true)
            {
                _CompareLeftHandingRocket.SetImageResource(Resource.Drawable._handingRocket);
            }
            else
            {
                _CompareLeftHandingRocket.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftHandlingDepthCharge == true)
            {
                _CompareLeftHandlingDepthCharge.SetImageResource(Resource.Drawable._handlingDepthCharge);
            }
            else
            {
                _CompareLeftHandlingDepthCharge.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftHandlingTorpedo == true)
            {
                _CompareLeftHandlingTorpedo.SetImageResource(Resource.Drawable._handingTorpedo);
            }
            else
            {
                _CompareLeftHandlingTorpedo.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftHandingMine == true)
            {
                _CompareLeftHandingMine.SetImageResource(Resource.Drawable._handlingMine);
            }
            else
            {
                _CompareLeftHandingMine.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftMCShellAP == true)
            {
                _CompareLeftMCShellAP.SetImageResource(Resource.Drawable._ShellAP);
            }
            else
            {
                _CompareLeftMCShellAP.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftMCShellAPHE == true)
            {
                _CompareLeftMCShellAPHE.SetImageResource(Resource.Drawable._ShellAPHE);
            }
            else
            {
                _CompareLeftMCShellAPHE.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftMCShellAPCR == true)
            {
                _CompareLeftMCShellAPCR.SetImageResource(Resource.Drawable._ShellAPCR);
            }
            else
            {
                _CompareLeftMCShellAPCR.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftMCShellHE == true)
            {
                _CompareLeftMCShellHE.SetImageResource(Resource.Drawable._ShellHE);
            }
            else
            {
                _CompareLeftMCShellHE.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftMCShellHEVT == true)
            {
                _CompareLeftMCShellHEVT.SetImageResource(Resource.Drawable._ShellHEVT);
            }
            else
            {
                _CompareLeftMCShellHEVT.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftMCShellHEDF == true)
            {
                _CompareLeftMCShellHEDF.SetImageResource(Resource.Drawable._ShellHEDF);
            }
            else
            {
                _CompareLeftMCShellHEDF.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftMCShellFOG == true)
            {
                _CompareLeftMCShellFOG.SetImageResource(Resource.Drawable._ShellFOG);
            }
            else
            {
                _CompareLeftMCShellFOG.SetImageResource(Resource.Drawable._handingTransparent);
            }


            if (leftAUShellAP == true)
            {
                _CompareLeftAUShellAP.SetImageResource(Resource.Drawable._ShellAP);
            }
            else
            {
                _CompareLeftAUShellAP.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftAUShellAPHE == true)
            {
                _CompareLeftAUShellAPHE.SetImageResource(Resource.Drawable._ShellAPHE);
            }
            else
            {
                _CompareLeftAUShellAPHE.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftAUShellAPCR == true)
            {
                _CompareLeftAUShellAPCR.SetImageResource(Resource.Drawable._ShellAPCR);
            }
            else
            {
                _CompareLeftAUShellAPCR.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftAUShellHE == true)
            {
                _CompareLeftAUShellHE.SetImageResource(Resource.Drawable._ShellHE);
            }
            else
            {
                _CompareLeftAUShellHE.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftAUShellHEVT == true)
            {
                _CompareLeftAUShellHEVT.SetImageResource(Resource.Drawable._ShellHEVT);
            }
            else
            {
                _CompareLeftAUShellHEVT.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftAUShellHEDF == true)
            {
                _CompareLeftAUShellHEDF.SetImageResource(Resource.Drawable._ShellHEDF);
            }
            else
            {
                _CompareLeftAUShellHEDF.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftAUShellFOG == true)
            {
                _CompareLeftAUShellFOG.SetImageResource(Resource.Drawable._ShellFOG);
            }
            else
            {
                _CompareLeftAUShellFOG.SetImageResource(Resource.Drawable._handingTransparent);
            }
            

            if (leftMCShellShrapnel == true)
            {
                _CompareLeftMCShellShrapnel.SetImageResource(Resource.Drawable._ShellShrapnel);
            }
            else
            {
                _CompareLeftMCShellShrapnel.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (leftAUShellShrapnel == true)
            {
                _CompareLeftAUShellShrapnel.SetImageResource(Resource.Drawable._ShellShrapnel);
            }
            else
            {
                _CompareLeftAUShellShrapnel.SetImageResource(Resource.Drawable._handingTransparent);
            }


            if (leftAAAShellAP == true)
            {
                _CompareLeftAAAShellAP.SetImageResource(Resource.Drawable._ShellAP);
            }
            else
            {
                _CompareLeftAAAShellAP.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftAAAShellAPHE == true)
            {
                _CompareLeftAAAShellAPHE.SetImageResource(Resource.Drawable._ShellAPHE);
            }
            else
            {
                _CompareLeftAAAShellAPHE.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftAAAShellAPCR == true)
            {
                _CompareLeftAAAShellAPCR.SetImageResource(Resource.Drawable._ShellAPCR);
            }
            else
            {
                _CompareLeftAAAShellAPCR.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftAAAShellHE == true)
            {
                _CompareLeftAAAShellHE.SetImageResource(Resource.Drawable._ShellHE);
            }
            else
            {
                _CompareLeftAAAShellHE.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftAAAShellHEVT == true)
            {
                _CompareLeftAAAShellHEVT.SetImageResource(Resource.Drawable._ShellHEVT);
            }
            else
            {
                _CompareLeftAAAShellHEVT.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftAAAShellHEDF == true)
            {
                _CompareLeftAAAShellHEDF.SetImageResource(Resource.Drawable._ShellHEDF);
            }
            else
            {
                _CompareLeftAAAShellHEDF.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftAAAShellFOG == true)
            {
                _CompareLeftAAAShellFOG.SetImageResource(Resource.Drawable._ShellFOG);
            }
            else
            {
                _CompareLeftAAAShellFOG.SetImageResource(Resource.Drawable._handingTransparent);
            }
    }

        private void ShipRightHandingWeaponShower()
        {
            if (rightHandingRocket == true)
            {
                _CompareRightHandingRocket.SetImageResource(Resource.Drawable._handingRocket);
            }
            else
            {
                _CompareRightHandingRocket.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightHandlingDepthCharge == true)
            {
                _CompareRightHandlingDepthCharge.SetImageResource(Resource.Drawable._handlingDepthCharge);
            }
            else
            {
                _CompareRightHandlingDepthCharge.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightHandlingTorpedo == true)
            {
                _CompareRightHandlingTorpedo.SetImageResource(Resource.Drawable._handingTorpedo);
            }
            else
            {
                _CompareRightHandlingTorpedo.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightHandingMine == true)
            {
                _CompareRightHandingMine.SetImageResource(Resource.Drawable._handlingMine);
            }
            else
            {
                _CompareRightHandingMine.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightMCShellAP == true)
            {
                _CompareRightMCShellAP.SetImageResource(Resource.Drawable._ShellAP);
            }
            else
            {
                _CompareRightMCShellAP.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightMCShellAPHE == true)
            {
                _CompareRightMCShellAPHE.SetImageResource(Resource.Drawable._ShellAPHE);
            }
            else
            {
                _CompareRightMCShellAPHE.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightMCShellAPCR == true)
            {
                _CompareRightMCShellAPCR.SetImageResource(Resource.Drawable._ShellAPCR);
            }
            else
            {
                _CompareRightMCShellAPCR.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightMCShellHE == true)
            {
                _CompareRightMCShellHE.SetImageResource(Resource.Drawable._ShellHE);
            }
            else
            {
                _CompareRightMCShellHE.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightMCShellHEVT == true)
            {
                _CompareRightMCShellHEVT.SetImageResource(Resource.Drawable._ShellHEVT);
            }
            else
            {
                _CompareRightMCShellHEVT.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightMCShellHEDF == true)
            {
                _CompareRightMCShellHEDF.SetImageResource(Resource.Drawable._ShellHEDF);
            }
            else
            {
                _CompareRightMCShellHEDF.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightMCShellFOG == true)
            {
                _CompareRightMCShellFOG.SetImageResource(Resource.Drawable._ShellFOG);
            }
            else
            {
                _CompareRightMCShellFOG.SetImageResource(Resource.Drawable._handingTransparent);
            }


            if (rightAUShellAP == true)
            {
                _CompareRightAUShellAP.SetImageResource(Resource.Drawable._ShellAP);
            }
            else
            {
                _CompareRightAUShellAP.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightAUShellAPHE == true)
            {
                _CompareRightAUShellAPHE.SetImageResource(Resource.Drawable._ShellAPHE);
            }
            else
            {
                _CompareRightAUShellAPHE.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightAUShellAPCR == true)
            {
                _CompareRightAUShellAPCR.SetImageResource(Resource.Drawable._ShellAPCR);
            }
            else
            {
                _CompareRightAUShellAPCR.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightAUShellHE == true)
            {
                _CompareRightAUShellHE.SetImageResource(Resource.Drawable._ShellHE);
            }
            else
            {
                _CompareRightAUShellHE.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightAUShellHEVT == true)
            {
                _CompareRightAUShellHEVT.SetImageResource(Resource.Drawable._ShellHEVT);
            }
            else
            {
                _CompareRightAUShellHEVT.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightAUShellHEDF == true)
            {
                _CompareRightAUShellHEDF.SetImageResource(Resource.Drawable._ShellHEDF);
            }
            else
            {
                _CompareRightAUShellHEDF.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightAUShellFOG == true)
            {
                _CompareRightAUShellFOG.SetImageResource(Resource.Drawable._ShellFOG);
            }
            else
            {
                _CompareRightAUShellFOG.SetImageResource(Resource.Drawable._handingTransparent);
            }


            if (rightAAAShellAP == true)
            {
                _CompareRightAAAShellAP.SetImageResource(Resource.Drawable._ShellAP);
            }
            else
            {
                _CompareRightAAAShellAP.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightAAAShellAPHE == true)
            {
                _CompareRightAAAShellAPHE.SetImageResource(Resource.Drawable._ShellAPHE);
            }
            else
            {
                _CompareRightAAAShellAPHE.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightAAAShellAPCR == true)
            {
                _CompareRightAAAShellAPCR.SetImageResource(Resource.Drawable._ShellAPCR);
            }
            else
            {
                _CompareRightAAAShellAPCR.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightAAAShellHE == true)
            {
                _CompareRightAAAShellHE.SetImageResource(Resource.Drawable._ShellHE);
            }
            else
            {
                _CompareRightAAAShellHE.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightAAAShellHEVT == true)
            {
                _CompareRightAAAShellHEVT.SetImageResource(Resource.Drawable._ShellHEVT);
            }
            else
            {
                _CompareRightAAAShellHEVT.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightAAAShellHEDF == true)
            {
                _CompareRightAAAShellHEDF.SetImageResource(Resource.Drawable._ShellHEDF);
            }
            else
            {
                _CompareRightAAAShellHEDF.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightAAAShellFOG == true)
            {
                _CompareRightAAAShellFOG.SetImageResource(Resource.Drawable._ShellFOG);
            }
            else
            {
                _CompareRightAAAShellFOG.SetImageResource(Resource.Drawable._handingTransparent);
            }





            if (rightMCShellShrapnel == true)
            {
                _CompareRightMCShellShrapnel.SetImageResource(Resource.Drawable._ShellShrapnel);
            }
            else
            {
                _CompareRightMCShellShrapnel.SetImageResource(Resource.Drawable._handingTransparent);
            }






            if (rightAUShellShrapnel == true)
            {
                _CompareRightAUShellShrapnel.SetImageResource(Resource.Drawable._ShellShrapnel);
            }
            else
            {
                _CompareRightAUShellShrapnel.SetImageResource(Resource.Drawable._handingTransparent);
            }


        }


        private void ShipShowBestViaBackgroundColor()
        {
            if (leftMainCaliber > rightMainCaliber)
            {
                _CompareShipLeftTextMainCaliberName.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareShipRightTextMainCaliberName.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
       if (leftMainCaliber < rightMainCaliber)
            {
                _CompareShipLeftTextMainCaliberName.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareShipRightTextMainCaliberName.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftMainCaliber == rightMainCaliber)
            {
                _CompareShipLeftTextMainCaliberName.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareShipRightTextMainCaliberName.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }


            if (leftMainCaliberReload < rightMainCaliberReload)
            {
                _CompareShipLeftTextMainCaliberReload.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareShipRightTextMainCaliberReload.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
     if (leftMainCaliberReload > rightMainCaliberReload)
            {
                _CompareShipLeftTextMainCaliberReload.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareShipRightTextMainCaliberReload.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftMainCaliberReload == rightMainCaliberReload)
            {
                _CompareShipLeftTextMainCaliberReload.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareShipRightTextMainCaliberReload.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }




            if (leftMainCaliberTNT > rightMainCaliberTNT)
            {
                _CompareShipLeftTextMainCaliberTNT.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareShipRightTextMainCaliberTNT.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftMainCaliberTNT < rightMainCaliberTNT)
            {
                _CompareShipLeftTextMainCaliberTNT.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareShipRightTextMainCaliberTNT.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftMainCaliberTNT == rightMainCaliberTNT)
            {
                _CompareShipLeftTextMainCaliberTNT.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareShipRightTextMainCaliberTNT.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }


            if (leftAuxiliaryCaliber > rightAuxiliaryCaliber)
            {
                _CompareShipLeftTextAuxiliaryCaliberName.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareShipRightTextAuxiliaryCaliberName.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftAuxiliaryCaliber < rightAuxiliaryCaliber)
            {
                _CompareShipLeftTextAuxiliaryCaliberName.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareShipRightTextAuxiliaryCaliberName.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftAuxiliaryCaliber == rightAuxiliaryCaliber)
            {
                _CompareShipLeftTextAuxiliaryCaliberName.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareShipRightTextAuxiliaryCaliberName.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }


            if (leftAuxiliaryCaliberReload < rightAuxiliaryCaliberReload)
            {
                _CompareShipLeftTextAuxiliaryCaliberReload.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareShipRightTextAuxiliaryCaliberReload.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
     if (leftAuxiliaryCaliberReload > rightAuxiliaryCaliberReload)
            {
                _CompareShipLeftTextAuxiliaryCaliberReload.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareShipRightTextAuxiliaryCaliberReload.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftAuxiliaryCaliberReload == rightAuxiliaryCaliberReload)
            {
                _CompareShipLeftTextAuxiliaryCaliberReload.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareShipRightTextAuxiliaryCaliberReload.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }



            if (leftAAACaliber > rightAAACaliber)
            {
                _CompareShipLeftTextAAACaliberName.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareShipRightTextAAACaliberName.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftAAACaliber < rightAAACaliber)
            {
                _CompareShipLeftTextAAACaliberName.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareShipRightTextAAACaliberName.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftAAACaliber == rightAAACaliber)
            {
                _CompareShipLeftTextAAACaliberName.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareShipRightTextAAACaliberName.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }


            if (leftAAACaliberReload < rightAAACaliberReload)
            {
                _CompareShipLeftTextAAACaliberReload.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareShipRightTextAAACaliberReload.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
     if (leftAAACaliberReload > rightAAACaliberReload)
            {
                _CompareShipLeftTextAAACaliberReload.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareShipRightTextAAACaliberReload.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftAAACaliberReload == rightAAACaliberReload)
            {
                _CompareShipLeftTextAAACaliberReload.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareShipRightTextAAACaliberReload.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }


            if (leftTorpedo > rightTorpedo)
            {
                _CompareShipLeftTextTorpedoName.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareShipRightTextTorpedoName.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftTorpedo < rightTorpedo)
            {
                _CompareShipLeftTextTorpedoName.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareShipRightTextTorpedoName.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftTorpedo == rightTorpedo)
            {
                _CompareShipLeftTextTorpedoName.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareShipRightTextTorpedoName.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }


            if (leftTorpedoItem > rightTorpedoItem)
            {
                _CompareShipLeftTextTorpedoItem.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareShipRightTextTorpedoItem.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftTorpedoItem < rightTorpedoItem)
            {
                _CompareShipLeftTextTorpedoItem.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareShipRightTextTorpedoItem.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftTorpedoItem == rightTorpedoItem)
            {
                _CompareShipLeftTextTorpedoItem.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareShipRightTextTorpedoItem.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }


            if (leftTorpedoMaxSpeed > rightTorpedoMaxSpeed)
            {
                _CompareShipLeftTextTorpedoMaxSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareShipRightTextTorpedoMaxSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftTorpedoMaxSpeed < rightTorpedoMaxSpeed)
            {
                _CompareShipLeftTextTorpedoMaxSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareShipRightTextTorpedoMaxSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftTorpedoMaxSpeed == rightTorpedoMaxSpeed)
            {
                _CompareShipLeftTextTorpedoMaxSpeed.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareShipRightTextTorpedoMaxSpeed.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }
            

            if (leftTorpedoTNT > rightTorpedoTNT)
            {
                _CompareShipLeftTextTorpedoTNT.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareShipRightTextTorpedoTNT.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftTorpedoTNT < rightTorpedoTNT)
            {
                _CompareShipLeftTextTorpedoTNT.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareShipRightTextTorpedoTNT.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftTorpedoTNT == rightTorpedoTNT)
            {
                _CompareShipLeftTextTorpedoTNT.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareShipRightTextTorpedoTNT.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }


            if (leftMaxSpeed > rightMaxSpeed)
            {
                _CompareShipLeftTextMaxSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareShipRightTextMaxSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftMaxSpeed < rightMaxSpeed)
            {
                _CompareShipLeftTextMaxSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareShipRightTextMaxSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftMaxSpeed == rightMaxSpeed)
            {
                _CompareShipLeftTextMaxSpeed.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareShipRightTextMaxSpeed.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }


            if (leftReverseSpeed > rightReverseSpeed)
            {
                _CompareShipLeftTextReverseSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareShipRightTextReverseSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftReverseSpeed < rightReverseSpeed)
            {
                _CompareShipLeftTextReverseSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareShipRightTextReverseSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftReverseSpeed == rightReverseSpeed)
            {
                _CompareShipLeftTextReverseSpeed.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareShipRightTextReverseSpeed.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }


            if (leftAcceleration < rightAcceleration)
            {
                _CompareShipLeftTextAcceleration.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareShipRightTextAcceleration.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftAcceleration > rightAcceleration)
            {
                _CompareShipLeftTextAcceleration.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareShipRightTextAcceleration.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftAcceleration == rightAcceleration)
            {
                _CompareShipLeftTextAcceleration.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareShipRightTextAcceleration.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }


            if (leftBrakingTime < rightBrakingTime)
            {
                _CompareShipLeftTextBrakingTime.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareShipRightTextBrakingTime.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftBrakingTime > rightBrakingTime)
            {
                _CompareShipLeftTextBrakingTime.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareShipRightTextBrakingTime.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftBrakingTime == rightBrakingTime)
            {
                _CompareShipLeftTextBrakingTime.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareShipRightTextBrakingTime.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }



            if (leftTurn360 < rightTurn360)
            {
                _CompareShipLeftTextTurn360.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareShipRightTextTurn360.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftTurn360 > rightTurn360)
            {
                _CompareShipLeftTextTurn360.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareShipRightTextTurn360.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftTurn360 == rightTurn360)
            {
                _CompareShipLeftTextTurn360.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareShipRightTextTurn360.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }



            if (leftDisplacement > rightDisplacement)
            {
                _CompareShipLeftTextDisplacement.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareShipRightTextDisplacement.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftDisplacement < rightDisplacement)
            {
                _CompareShipLeftTextDisplacement.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareShipRightTextDisplacement.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftDisplacement == rightDisplacement)
            {
                _CompareShipLeftTextDisplacement.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareShipRightTextDisplacement.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }

            if (leftCrewCount > rightCrewCount)
            {
                _CompareShipLeftTextCrewCount.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareShipRightTextCrewCount.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftCrewCount < rightCrewCount)
            {
                _CompareShipLeftTextCrewCount.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareShipRightTextCrewCount.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftCrewCount == rightCrewCount)
            {
                _CompareShipLeftTextCrewCount.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareShipRightTextCrewCount.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }

        }

        
    }
}