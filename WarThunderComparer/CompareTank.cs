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
using Android.Views;

namespace WarThunderComparer
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait)]
    public class CompareTank : AppCompatActivity
    {
        Spinner _CompareSpinnerNationLeft;
        Spinner _CompareSpinnerTankLeft;
        Spinner _CompareSpinnerRankLeft;
        Spinner _CompareSpinnerNationRight;
        Spinner _CompareSpinnerTankRight;
        Spinner _CompareSpinnerRankRight;
        //Объявление  спиннеров и скролов с XAML

        #region Объявление всех Textview
        Context context;
        ImageView _CompareImageLeft;
        ImageView _CompareLeftFlag;
        ImageView _LeftShellAP;
        ImageView _LeftShellAPHE;
        ImageView _LeftShellHE;
        ImageView _LeftShellAPCR;
        ImageView _LeftShellAPDS;
        ImageView _LeftShellAPFSDS;
        ImageView _LeftShellHEAT;
        ImageView _LeftShellHEVT;
        ImageView _LeftShellSAM;
        ImageView _LeftShellHEATFS;
        ImageView _LeftShellShrapnel;
        ImageView _LeftShellHESH;
        ImageView _LeftShellATGM;
        ImageView _LeftShellSSM;
        ImageView _LeftShellHEATGRENADE;
        ImageView _LeftShellHEGRENADE;
        TextView _CompareTankLeftTextMaxSpeedAtRoad;
        TextView _CompareTankLeftTextMaxSpeedAtTerrain;
        TextView _CompareTankLeftTextMaxReverseSpeed;
        TextView _CompareTankLeftTextAccelerationTo100;
        TextView _CompareTankLeftTextTurnTurretTime;
        TextView _CompareTankLeftTextTurnHullTime;
        TextView _CompareTankLeftTextEnginePower;
        TextView _CompareTankLeftTextWeight;
        TextView _CompareTankLeftTextPowerToWeightRatio;
        TextView _CompareTankLeftTextCannonName;
        TextView _CompareTankLeftTextPenetration;
        TextView _CompareTankLeftTextShellSpeed;
        TextView _CompareTankLeftTextReloadTime;
        TextView _CompareTankLeftTextUpAimAngle;
        TextView _CompareTankLeftTextDownAimAngle;
        TextView _CompareTankLeftTextStabilizer;
        TextView _CompareTankLeftTextAAMachineGunExist;
        TextView _CompareTankLeftTextReducedArmorFrontTurret;
        TextView _CompareTankLeftTextReducedArmorTopSheet;
        TextView _CompareTankLeftTextReducedArmorBottomSheet;

        ImageView _CompareImageRight;
        ImageView _CompareRightFlag;
        ImageView _RightShellAP;
        ImageView _RightShellAPHE;
        ImageView _RightShellHE;
        ImageView _RightShellAPCR;
        ImageView _RightShellAPDS;
        ImageView _RightShellAPFSDS;
        ImageView _RightShellHEAT;
        ImageView _RightShellHEVT;
        ImageView _RightShellSAM;
        ImageView _RightShellHEATFS;
        ImageView _RightShellShrapnel;
        ImageView _RightShellHESH;
        ImageView _RightShellATGM;
        ImageView _RightShellSSM;
        ImageView _RightShellHEATGRENADE;
        ImageView _RightShellHEGRENADE;
        TextView _CompareTankRightTextMaxSpeedAtRoad;
        TextView _CompareTankRightTextMaxSpeedAtTerrain;
        TextView _CompareTankRightTextMaxReverseSpeed;
        TextView _CompareTankRightTextAccelerationTo100;
        TextView _CompareTankRightTextTurnTurretTime;
        TextView _CompareTankRightTextTurnHullTime;
        TextView _CompareTankRightTextEnginePower;
        TextView _CompareTankRightTextWeight;
        TextView _CompareTankRightTextPowerToWeightRatio;
        TextView _CompareTankRightTextCannonName;
        TextView _CompareTankRightTextPenetration;
        TextView _CompareTankRightTextShellSpeed;
        TextView _CompareTankRightTextReloadTime;
        TextView _CompareTankRightTextUpAimAngle;
        TextView _CompareTankRightTextDownAimAngle;
        TextView _CompareTankRightTextStabilizer;
        TextView _CompareTankRightTextAAMachineGunExist;
        TextView _CompareTankRightTextReducedArmorFrontTurret;
        TextView _CompareTankRightTextReducedArmorTopSheet;
        TextView _CompareTankRightTextReducedArmorBottomSheet;

        TextView _CompareTankLabelTextMaxSpeedAtRoad;
        TextView _CompareTankLabelTextMaxSpeedAtTerrain;
        TextView _CompareTankLabelTextMaxReverseSpeed;
        TextView _CompareTankLabelTextAccelerationTo100;
        TextView _CompareTankLabelTextTurnTurretTime;
        TextView _CompareTankLabelTextTurnHullTime;
        TextView _CompareTankLabelTextEnginePower;
        TextView _CompareTankLabelTextWeight;
        TextView _CompareTankLabelTextPowerToWeightRatio;
        TextView _CompareTankLabelTextPenetration;
        TextView _CompareTankLabelTextShellSpeed;
        TextView _CompareTankLabelTextReloadTime;
        TextView _CompareTankLabelTextUpAimAngle;
        TextView _CompareTankLabelTextDownAimAngle;
        TextView _CompareTankLabelTextStabilizer;
        TextView _CompareTankLabelTextAAMachineGunExist;
        TextView _CompareTankLabelTextReducedArmorFrontTurret;
        TextView _CompareTankLabelTextReducedArmorTopSheet;
        TextView _CompareTankLabelTextReducedArmorBottomSheet;
        TextView _CompareTankLabelTextShellType;

        //Объявление текстовых полей
        #endregion

        List<Tank> tanksleft;
        List<Tank> tanksright;
        TankAdapter AdapterTankLeft;
        TankAdapter AdapterTankRight;
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

        private bool leftShellAP;
        private bool leftShellAPHE;
        private bool leftShellHE;
        private bool leftShellAPCR;
        private bool leftShellAPDS;
        private bool leftShellAPFSDS;
        private bool leftShellHEAT;
        private bool leftShellHEVT;
        private bool leftShellSAM;
        private bool leftShellHEATFS;
        private bool leftShellShrapnel;
        private bool leftShellHESH;
        private bool leftShellATGM;
        private bool leftShellSSM;
        private bool leftShellHEATGRENADE;
        private bool leftShellHEGRENADE;

        private bool rightShellAP;
        private bool rightShellAPHE;
        private bool rightShellHE;
        private bool rightShellAPCR;
        private bool rightShellAPDS;
        private bool rightShellAPFSDS;
        private bool rightShellHEAT;
        private bool rightShellHEVT;
        private bool rightShellSAM;
        private bool rightShellHEATFS;
        private bool rightShellShrapnel;
        private bool rightShellHESH;
        private bool rightShellATGM;
        private bool rightShellSSM;
        private bool rightShellHEATGRENADE;
        private bool rightShellHEGRENADE;


        private int leftTextMaxSpeedAtRoad;
        private int leftTextMaxSpeedAtTerrain;
        private int leftTextMaxReverseSpeed;
        private int leftTextAccelerationTo100;
        private int leftTextTurnTurretTime;
        private int leftTextTurnHullTime;
        private int leftTextEnginePower;
        private double leftTextWeight;
        private double leftTextPowerToWeightRatio;
        private int leftTextPenetration;
        private int leftTextShellSpeed;
        private double leftTextReloadTime;
        private int leftTextUpAimAngle;
        private int leftTextDownAimAngle;
        private bool leftTextAAMachineGunExist;
        private bool leftTextStabilizer;
        private int leftTextReducedArmorFrontTurret;
        private int leftTextReducedArmorTopSheet;
        private int leftTextReducedArmorBottomSheet;

        private int rightTextMaxSpeedAtRoad;
        private int rightTextMaxSpeedAtTerrain;
        private int rightTextMaxReverseSpeed;
        private int rightTextAccelerationTo100;
        private int rightTextTurnTurretTime;
        private int rightTextTurnHullTime;
        private int rightTextEnginePower;
        private double rightTextWeight;
        private double rightTextPowerToWeightRatio;
        private int rightTextPenetration;
        private int rightTextShellSpeed;
        private double rightTextReloadTime;
        private int rightTextUpAimAngle;
        private int rightTextDownAimAngle;
        private bool rightTextAAMachineGunExist;
        private bool rightTextStabilizer;
        private int rightTextReducedArmorFrontTurret;
        private int rightTextReducedArmorTopSheet;
        private int rightTextReducedArmorBottomSheet;

        private int showRateAlert;

        LayoutInflater layoutInflater;
        View mview;
        Android.App.AlertDialog.Builder alertDialogBuilder;
        Android.App.AlertDialog alertDialogAndroid;

        Button rateButtonNo, rateButtonYes;

        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\
        DrawerLayout drawerLayout;
        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\

        public CompareTank()
        {
        }

        protected CompareTank(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CompareTank);
            context = Application.Context;
            #region Rate App

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            ISharedPreferencesEditor editor = prefs.Edit();

            showRateAlert = prefs.GetInt("rateAlert", 1);
            showRateAlert++;
            editor.PutInt("rateAlert", showRateAlert);
            editor.Apply();

            #endregion

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
            var adView = FindViewById<AdView>(Resource.Id.adViewCompareTank);
            var adRequest = new AdRequest.Builder().Build();
            adView.LoadAd(adRequest);
            //var requestbuilder = new AdRequest.Builder().AddTestDevice("D0BE22F1A4BE27C7470F95A699568FE2");
            //adView.LoadAd(requestbuilder.Build());
            //шрифт
            var font = Typeface.CreateFromAsset(Assets, "dinfont.ttf");

            _CompareSpinnerNationLeft = FindViewById<Spinner>(Resource.Id.CompareSpinnerNationLeftT);
            _CompareSpinnerNationRight = FindViewById<Spinner>(Resource.Id.CompareSpinnerNationRightT);
            _CompareSpinnerRankLeft = FindViewById<Spinner>(Resource.Id.CompareSpinnerRankLeftT);
            _CompareSpinnerRankRight = FindViewById<Spinner>(Resource.Id.CompareSpinnerRankRightT);
            _CompareSpinnerTankLeft = FindViewById<Spinner>(Resource.Id.CompareSpinnerTankLeft);
            _CompareSpinnerTankRight = FindViewById<Spinner>(Resource.Id.CompareSpinnerTankRight);
            //Привязка спиннеров к шарп коду 


            #region Привязка TextView к коду
            _CompareImageLeft = FindViewById<ImageView>(Resource.Id.CompareTankImage1);
            _CompareLeftFlag = FindViewById<ImageView>(Resource.Id.CompareTankFlag1);
            _CompareTankLeftTextMaxSpeedAtRoad = FindViewById<TextView>(Resource.Id.CompareTankLeftTextMaxSpeedAtRoad);
            _CompareTankLeftTextMaxSpeedAtTerrain = FindViewById<TextView>(Resource.Id.CompareTankLeftTextMaxSpeedAtTerrain);
            _CompareTankLeftTextMaxReverseSpeed = FindViewById<TextView>(Resource.Id.CompareTankLeftTextMaxReverseSpeed);
            _CompareTankLeftTextAccelerationTo100 = FindViewById<TextView>(Resource.Id.CompareTankLeftTextAccelerationTo100);
            _CompareTankLeftTextTurnTurretTime = FindViewById<TextView>(Resource.Id.CompareTankLeftTextTurnTurretTime);
            _CompareTankLeftTextTurnHullTime = FindViewById<TextView>(Resource.Id.CompareTankLeftTextTurnHullTime);
            _CompareTankLeftTextEnginePower = FindViewById<TextView>(Resource.Id.CompareTankLeftTextEnginePower);
            _CompareTankLeftTextWeight = FindViewById<TextView>(Resource.Id.CompareTankLeftTextWeight);
            _CompareTankLeftTextPowerToWeightRatio = FindViewById<TextView>(Resource.Id.CompareTankLeftTextPowerToWeightRatio);
            _CompareTankLeftTextCannonName = FindViewById<TextView>(Resource.Id.CompareTankLeftTextCannonName);
            _CompareTankLeftTextPenetration = FindViewById<TextView>(Resource.Id.CompareTankLeftTextPenetration);
            _CompareTankLeftTextShellSpeed = FindViewById<TextView>(Resource.Id.CompareTankLeftTextShellSpeed);
            _CompareTankLeftTextReloadTime = FindViewById<TextView>(Resource.Id.CompareTankLeftTextReloadTime);
            _CompareTankLeftTextUpAimAngle = FindViewById<TextView>(Resource.Id.CompareTankLeftTextUpAimAngle);
            _CompareTankLeftTextDownAimAngle = FindViewById<TextView>(Resource.Id.CompareTankLeftTextDownAimAngle);
            _CompareTankLeftTextStabilizer = FindViewById<TextView>(Resource.Id.CompareTankLeftTextStabilizer);
            _CompareTankLeftTextAAMachineGunExist = FindViewById<TextView>(Resource.Id.CompareTankLeftTextAAMachineGunExist);
            _CompareTankLeftTextReducedArmorFrontTurret = FindViewById<TextView>(Resource.Id.CompareTankLeftTextReducedArmorFrontTurret);
            _CompareTankLeftTextReducedArmorTopSheet = FindViewById<TextView>(Resource.Id.CompareTankLeftTextReducedArmorTopSheet);
            _CompareTankLeftTextReducedArmorBottomSheet = FindViewById<TextView>(Resource.Id.CompareTankLeftTextReducedArmorBottomSheet);
            _LeftShellAP = FindViewById<ImageView>(Resource.Id.CompareLeftShellAP);
            _LeftShellAPHE = FindViewById<ImageView>(Resource.Id.CompareLeftShellAPHE);
            _LeftShellHE = FindViewById<ImageView>(Resource.Id.CompareLeftShellHE);
            _LeftShellAPCR = FindViewById<ImageView>(Resource.Id.CompareLeftShellAPCR);
            _LeftShellAPDS = FindViewById<ImageView>(Resource.Id.CompareLeftShellAPDS);
            _LeftShellAPFSDS = FindViewById<ImageView>(Resource.Id.CompareLeftShellAPFSDS);
            _LeftShellHEAT = FindViewById<ImageView>(Resource.Id.CompareLeftShellHEAT);
            _LeftShellHEVT = FindViewById<ImageView>(Resource.Id.CompareLeftShellHEVT);
            _LeftShellSAM = FindViewById<ImageView>(Resource.Id.CompareLeftShellSAM);
            _LeftShellHEATFS = FindViewById<ImageView>(Resource.Id.CompareLeftShellHEATFS);
            _LeftShellShrapnel = FindViewById<ImageView>(Resource.Id.CompareLeftShellShrapnel);
            _LeftShellHESH = FindViewById<ImageView>(Resource.Id.CompareLeftShellHESH);
            _LeftShellATGM = FindViewById<ImageView>(Resource.Id.CompareLeftShellATGM);
            _LeftShellSSM = FindViewById<ImageView>(Resource.Id.CompareLeftShellSSM);
            _LeftShellHEATGRENADE = FindViewById<ImageView>(Resource.Id.CompareLeftShellHEATGRENADE);
            _LeftShellHEGRENADE = FindViewById<ImageView>(Resource.Id.CompareLeftShellHEGRENADE);


            _CompareTankLabelTextMaxSpeedAtRoad = FindViewById<TextView>(Resource.Id.CompareTankLabelTextMaxSpeedAtRoad);
            _CompareTankLabelTextMaxSpeedAtTerrain = FindViewById<TextView>(Resource.Id.CompareTankLabelTextMaxSpeedAtTerrain);
            _CompareTankLabelTextMaxReverseSpeed = FindViewById<TextView>(Resource.Id.CompareTankLabelTextMaxReverseSpeed);
            _CompareTankLabelTextAccelerationTo100 = FindViewById<TextView>(Resource.Id.CompareTankLabelTextAccelerationTo100);
            _CompareTankLabelTextTurnTurretTime = FindViewById<TextView>(Resource.Id.CompareTankLabelTextTurnTurretTime);
            _CompareTankLabelTextTurnHullTime = FindViewById<TextView>(Resource.Id.CompareTankLabelTextTurnHullTime);
            _CompareTankLabelTextEnginePower = FindViewById<TextView>(Resource.Id.CompareTankLabelTextEnginePower);
            _CompareTankLabelTextWeight = FindViewById<TextView>(Resource.Id.CompareTankLabelTextWeight);
            _CompareTankLabelTextPowerToWeightRatio = FindViewById<TextView>(Resource.Id.CompareTankLabelTextPowerToWeightRatio);
            _CompareTankLabelTextPenetration = FindViewById<TextView>(Resource.Id.CompareTankLabelTextPenetration);
            _CompareTankLabelTextShellSpeed = FindViewById<TextView>(Resource.Id.CompareTankLabelTextShellSpeed);
            _CompareTankLabelTextReloadTime = FindViewById<TextView>(Resource.Id.CompareTankLabelTextReloadTime);
            _CompareTankLabelTextUpAimAngle = FindViewById<TextView>(Resource.Id.CompareTankLabelTextUpAimAngle);
            _CompareTankLabelTextDownAimAngle = FindViewById<TextView>(Resource.Id.CompareTankLabelTextDownAimAngle);
            _CompareTankLabelTextStabilizer = FindViewById<TextView>(Resource.Id.CompareTankLabelTextStabilizer);
            _CompareTankLabelTextAAMachineGunExist = FindViewById<TextView>(Resource.Id.CompareTankLabelTextAAMachineGunExist);
            _CompareTankLabelTextReducedArmorFrontTurret = FindViewById<TextView>(Resource.Id.CompareTankLabelTextReducedArmorFrontTurret);
            _CompareTankLabelTextReducedArmorTopSheet = FindViewById<TextView>(Resource.Id.CompareTankLabelTextReducedArmorTopSheet);
            _CompareTankLabelTextReducedArmorBottomSheet = FindViewById<TextView>(Resource.Id.CompareTankLabelTextReducedArmorBottomSheet);
            _CompareTankLabelTextShellType = FindViewById<TextView>(Resource.Id.CompareTankLabelTextShellType);


            _CompareImageRight = FindViewById<ImageView>(Resource.Id.CompareTankImage2);
            _CompareRightFlag = FindViewById<ImageView>(Resource.Id.CompareTankFlag2);
            _CompareTankRightTextMaxSpeedAtRoad = FindViewById<TextView>(Resource.Id.CompareTankRightTextMaxSpeedAtRoad);
            _CompareTankRightTextMaxSpeedAtTerrain = FindViewById<TextView>(Resource.Id.CompareTankRightTextMaxSpeedAtTerrain);
            _CompareTankRightTextMaxReverseSpeed = FindViewById<TextView>(Resource.Id.CompareTankRightTextMaxReverseSpeed);
            _CompareTankRightTextAccelerationTo100 = FindViewById<TextView>(Resource.Id.CompareTankRightTextAccelerationTo100);
            _CompareTankRightTextTurnTurretTime = FindViewById<TextView>(Resource.Id.CompareTankRightTextTurnTurretTime);
            _CompareTankRightTextTurnHullTime = FindViewById<TextView>(Resource.Id.CompareTankRightTextTurnHullTime);
            _CompareTankRightTextEnginePower = FindViewById<TextView>(Resource.Id.CompareTankRightTextEnginePower);
            _CompareTankRightTextWeight = FindViewById<TextView>(Resource.Id.CompareTankRightTextWeight);
            _CompareTankRightTextPowerToWeightRatio = FindViewById<TextView>(Resource.Id.CompareTankRightTextPowerToWeightRatio);
            _CompareTankRightTextCannonName = FindViewById<TextView>(Resource.Id.CompareTankRightTextCannonName);
            _CompareTankRightTextPenetration = FindViewById<TextView>(Resource.Id.CompareTankRightTextPenetration);
            _CompareTankRightTextShellSpeed = FindViewById<TextView>(Resource.Id.CompareTankRightTextShellSpeed);
            _CompareTankRightTextReloadTime = FindViewById<TextView>(Resource.Id.CompareTankRightTextReloadTime);
            _CompareTankRightTextUpAimAngle = FindViewById<TextView>(Resource.Id.CompareTankRightTextUpAimAngle);
            _CompareTankRightTextDownAimAngle = FindViewById<TextView>(Resource.Id.CompareTankRightTextDownAimAngle);
            _CompareTankRightTextStabilizer = FindViewById<TextView>(Resource.Id.CompareTankRightTextStabilizer);
            _CompareTankRightTextAAMachineGunExist = FindViewById<TextView>(Resource.Id.CompareTankRightTextAAMachineGunExist);
            _CompareTankRightTextReducedArmorFrontTurret = FindViewById<TextView>(Resource.Id.CompareTankRightTextReducedArmorFrontTurret);
            _CompareTankRightTextReducedArmorTopSheet = FindViewById<TextView>(Resource.Id.CompareTankRightTextReducedArmorTopSheet);
            _CompareTankRightTextReducedArmorBottomSheet = FindViewById<TextView>(Resource.Id.CompareTankRightTextReducedArmorBottomSheet);
            _RightShellAP = FindViewById<ImageView>(Resource.Id.CompareRightShellAP);
            _RightShellAPHE = FindViewById<ImageView>(Resource.Id.CompareRightShellAPHE);
            _RightShellHE = FindViewById<ImageView>(Resource.Id.CompareRightShellHE);
            _RightShellAPCR = FindViewById<ImageView>(Resource.Id.CompareRightShellAPCR);
            _RightShellAPDS = FindViewById<ImageView>(Resource.Id.CompareRightShellAPDS);
            _RightShellAPFSDS = FindViewById<ImageView>(Resource.Id.CompareRightShellAPFSDS);
            _RightShellHEAT = FindViewById<ImageView>(Resource.Id.CompareRightShellHEAT);
            _RightShellHEVT = FindViewById<ImageView>(Resource.Id.CompareRightShellHEVT);
            _RightShellSAM = FindViewById<ImageView>(Resource.Id.CompareRightShellSAM);
            _RightShellHEATFS = FindViewById<ImageView>(Resource.Id.CompareRightShellHEATFS);
            _RightShellShrapnel = FindViewById<ImageView>(Resource.Id.CompareRightShellShrapnel);
            _RightShellHESH = FindViewById<ImageView>(Resource.Id.CompareRightShellHESH);
            _RightShellATGM = FindViewById<ImageView>(Resource.Id.CompareRightShellATGM);
            _RightShellSSM = FindViewById<ImageView>(Resource.Id.CompareRightShellSSM);
            _RightShellHEATGRENADE = FindViewById<ImageView>(Resource.Id.CompareRightShellHEATGRENADE);
            _RightShellHEGRENADE = FindViewById<ImageView>(Resource.Id.CompareRightShellHEGRENADE);
            #endregion

            #region Изменения шрифта            
            _CompareTankLabelTextMaxSpeedAtRoad.Typeface = font;
            _CompareTankLabelTextMaxSpeedAtTerrain.Typeface = font;
            _CompareTankLabelTextMaxReverseSpeed.Typeface = font;
            _CompareTankLabelTextAccelerationTo100.Typeface = font;
            _CompareTankLabelTextTurnTurretTime.Typeface = font;
            _CompareTankLabelTextTurnHullTime.Typeface = font;
            _CompareTankLabelTextEnginePower.Typeface = font;
            _CompareTankLabelTextWeight.Typeface = font;
            _CompareTankLabelTextPowerToWeightRatio.Typeface = font;
            //  _CompareTankLabelTextCannonName.Typeface = font;
            _CompareTankLabelTextPenetration.Typeface = font;
            _CompareTankLabelTextShellSpeed.Typeface = font;
            _CompareTankLabelTextReloadTime.Typeface = font;
            _CompareTankLabelTextUpAimAngle.Typeface = font;
            _CompareTankLabelTextDownAimAngle.Typeface = font;
            _CompareTankLabelTextStabilizer.Typeface = font;
            _CompareTankLabelTextAAMachineGunExist.Typeface = font;
            _CompareTankLabelTextReducedArmorFrontTurret.Typeface = font;
            _CompareTankLabelTextReducedArmorTopSheet.Typeface = font;
            _CompareTankLabelTextReducedArmorBottomSheet.Typeface = font;
            _CompareTankLabelTextShellType.Typeface = font;

            #endregion


            #region Изменения цвета текста всех TextView

            _CompareTankLeftTextMaxSpeedAtRoad.SetTextColor(Color.Black);
            _CompareTankLeftTextMaxSpeedAtTerrain.SetTextColor(Color.Black);
            _CompareTankLeftTextMaxReverseSpeed.SetTextColor(Color.Black);
            _CompareTankLeftTextAccelerationTo100.SetTextColor(Color.Black);
            _CompareTankLeftTextTurnTurretTime.SetTextColor(Color.Black);
            _CompareTankLeftTextTurnHullTime.SetTextColor(Color.Black);
            _CompareTankLeftTextEnginePower.SetTextColor(Color.Black);
            _CompareTankLeftTextWeight.SetTextColor(Color.Black);
            _CompareTankLeftTextPowerToWeightRatio.SetTextColor(Color.Black);
            _CompareTankLeftTextCannonName.SetTextColor(Color.Black);
            _CompareTankLeftTextPenetration.SetTextColor(Color.Black);
            _CompareTankLeftTextShellSpeed.SetTextColor(Color.Black);
            _CompareTankLeftTextReloadTime.SetTextColor(Color.Black);
            _CompareTankLeftTextUpAimAngle.SetTextColor(Color.Black);
            _CompareTankLeftTextDownAimAngle.SetTextColor(Color.Black);
            _CompareTankLeftTextStabilizer.SetTextColor(Color.Black);
            _CompareTankLeftTextAAMachineGunExist.SetTextColor(Color.Black);
            _CompareTankLeftTextReducedArmorFrontTurret.SetTextColor(Color.Black);
            _CompareTankLeftTextReducedArmorTopSheet.SetTextColor(Color.Black);
            _CompareTankLeftTextReducedArmorBottomSheet.SetTextColor(Color.Black);


            _CompareTankRightTextMaxSpeedAtRoad.SetTextColor(Color.Black);
            _CompareTankRightTextMaxSpeedAtTerrain.SetTextColor(Color.Black);
            _CompareTankRightTextMaxReverseSpeed.SetTextColor(Color.Black);
            _CompareTankRightTextAccelerationTo100.SetTextColor(Color.Black);
            _CompareTankRightTextTurnTurretTime.SetTextColor(Color.Black);
            _CompareTankRightTextTurnHullTime.SetTextColor(Color.Black);
            _CompareTankRightTextEnginePower.SetTextColor(Color.Black);
            _CompareTankRightTextWeight.SetTextColor(Color.Black);
            _CompareTankRightTextPowerToWeightRatio.SetTextColor(Color.Black);
            _CompareTankRightTextCannonName.SetTextColor(Color.Black);
            _CompareTankRightTextPenetration.SetTextColor(Color.Black);
            _CompareTankRightTextShellSpeed.SetTextColor(Color.Black);
            _CompareTankRightTextReloadTime.SetTextColor(Color.Black);
            _CompareTankRightTextUpAimAngle.SetTextColor(Color.Black);
            _CompareTankRightTextDownAimAngle.SetTextColor(Color.Black);
            _CompareTankRightTextStabilizer.SetTextColor(Color.Black);
            _CompareTankRightTextAAMachineGunExist.SetTextColor(Color.Black);
            _CompareTankRightTextReducedArmorFrontTurret.SetTextColor(Color.Black);
            _CompareTankRightTextReducedArmorTopSheet.SetTextColor(Color.Black);
            _CompareTankRightTextReducedArmorBottomSheet.SetTextColor(Color.Black);

            _CompareTankLabelTextMaxSpeedAtRoad.SetTextColor(Color.Black);
            _CompareTankLabelTextMaxSpeedAtTerrain.SetTextColor(Color.Black);
            _CompareTankLabelTextMaxReverseSpeed.SetTextColor(Color.Black);
            _CompareTankLabelTextAccelerationTo100.SetTextColor(Color.Black);
            _CompareTankLabelTextTurnTurretTime.SetTextColor(Color.Black);
            _CompareTankLabelTextTurnHullTime.SetTextColor(Color.Black);
            _CompareTankLabelTextEnginePower.SetTextColor(Color.Black);
            _CompareTankLabelTextWeight.SetTextColor(Color.Black);
            _CompareTankLabelTextPowerToWeightRatio.SetTextColor(Color.Black);
            _CompareTankLabelTextPenetration.SetTextColor(Color.Black);
            _CompareTankLabelTextShellSpeed.SetTextColor(Color.Black);
            _CompareTankLabelTextReloadTime.SetTextColor(Color.Black);
            _CompareTankLabelTextUpAimAngle.SetTextColor(Color.Black);
            _CompareTankLabelTextDownAimAngle.SetTextColor(Color.Black);
            _CompareTankLabelTextStabilizer.SetTextColor(Color.Black);
            _CompareTankLabelTextAAMachineGunExist.SetTextColor(Color.Black);
            _CompareTankLabelTextReducedArmorFrontTurret.SetTextColor(Color.Black);
            _CompareTankLabelTextReducedArmorTopSheet.SetTextColor(Color.Black);
            _CompareTankLabelTextReducedArmorBottomSheet.SetTextColor(Color.Black);
            _CompareTankLabelTextShellType.SetTextColor(Color.Black);

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
            _CompareSpinnerRankLeft.SetSelection(7); //Автовыбор
            _CompareSpinnerRankRight.SetSelection(7); //Автовыбор
            selectedRankLeft = 7;   //Автовыбор
            selectedRankRight = 7;   //Автовыбор

            _CompareSpinnerTankLeft.SetSelection(1);   //Автовыбор
            _CompareSpinnerTankRight.SetSelection(1);   //Автовыбор

            //Объявление коллекции наций, рангов и адаптеров

            _CompareSpinnerTankLeft.ItemSelected += _CompareSpinnerTankLeft_ItemSelected;
            _CompareSpinnerTankRight.ItemSelected += _CompareSpinnerTankRight_ItemSelected;
            _CompareSpinnerRankLeft.ItemSelected += _CompareSpinnerRankLeft_ItemSelected;
            _CompareSpinnerRankRight.ItemSelected += _CompareSpinnerRankRight_ItemSelected;
            _CompareSpinnerNationLeft.ItemSelected += _CompareSpinnerNationLeft_ItemSelected;
            _CompareSpinnerNationRight.ItemSelected += _CompareSpinnerNationRight_ItemSelected;
            //События спиннеров

            RateApp();
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
            TankLeftSelector();
        }

        private void _CompareSpinnerNationRight_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedNationRight = nations[e.Position].Id;
            TankRightSelector();
        }

        //Обработчики событий  нажатия на ранги
        private void _CompareSpinnerRankLeft_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedRankLeft = ranks[e.Position].Id;
            TankLeftSelector();
        }

        //Обработчики событий  нажатия на самолеты
        private void _CompareSpinnerRankRight_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedRankRight = ranks[e.Position].Id;
            TankRightSelector();
        }

        private void _CompareSpinnerTankLeft_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            leftTextMaxSpeedAtRoad = tanksleft[e.Position].MaxSpeedAtRoad;
            leftTextMaxSpeedAtTerrain = tanksleft[e.Position].MaxSpeedAtTerrain;
            leftTextMaxReverseSpeed = tanksleft[e.Position].MaxReverseSpeed;
            leftTextAccelerationTo100 = tanksleft[e.Position].AccelerationTo100;
            leftTextTurnTurretTime = tanksleft[e.Position].TurnTurretTime;
            leftTextTurnHullTime = tanksleft[e.Position].TurnHullTime;
            leftTextEnginePower = tanksleft[e.Position].EnginePower;
            leftTextWeight = tanksleft[e.Position].Weight;
            leftTextPowerToWeightRatio = tanksleft[e.Position].PowerToWeightRatio;
            leftTextPenetration = tanksleft[e.Position].Penetration;
            leftTextShellSpeed = tanksleft[e.Position].ShellSpeed;
            leftTextReloadTime = tanksleft[e.Position].ReloadTime;
            leftTextUpAimAngle = tanksleft[e.Position].UpAimAngle;
            leftTextDownAimAngle = tanksleft[e.Position].DownAimAngle;
            leftTextStabilizer = tanksleft[e.Position].Stabilizer;
            leftTextAAMachineGunExist = tanksleft[e.Position].AAMachineGunExist;
            leftTextReducedArmorFrontTurret = tanksleft[e.Position].ReducedArmorFrontTurret;
            leftTextReducedArmorTopSheet = tanksleft[e.Position].ReducedArmorTopSheet;
            leftTextReducedArmorBottomSheet = tanksleft[e.Position].ReducedArmorBottomSheet;
            //для подсветки

            leftShellAP = tanksleft[e.Position].ShellAP;
            leftShellAPHE = tanksleft[e.Position].ShellAPHE;
            leftShellHE = tanksleft[e.Position].ShellHE;
            leftShellAPCR = tanksleft[e.Position].ShellAPCR;
            leftShellAPDS = tanksleft[e.Position].ShellAPDS;
            leftShellAPFSDS = tanksleft[e.Position].ShellAPFSDS;
            leftShellHEAT = tanksleft[e.Position].ShellHEAT;
            leftShellHEVT = tanksleft[e.Position].ShellHEVT;
            leftShellSAM = tanksleft[e.Position].ShellSTA;
            leftShellHEATFS = tanksleft[e.Position].ShellHEATFS;
            leftShellShrapnel = tanksleft[e.Position].ShellShrapnel;
            leftShellHESH = tanksleft[e.Position].ShellHESH;
            leftShellATGM = tanksleft[e.Position].ShellATGM;
            leftShellSSM = tanksleft[e.Position].ShellSSM;
            leftShellHEATGRENADE = tanksleft[e.Position].ShellHEATGRENADE;
            leftShellHEGRENADE = tanksleft[e.Position].ShellHEGRENADE;

            _CompareImageLeft.SetImageResource(tanksleft[e.Position].Image);
            _CompareLeftFlag.SetImageResource(tanksleft[e.Position].FlagImage);
            _CompareTankLeftTextAccelerationTo100.SetText(tanksleft[e.Position].AccelerationTo100.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            _CompareTankLeftTextTurnTurretTime.SetText(tanksleft[e.Position].TurnTurretTime.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            _CompareTankLeftTextTurnHullTime.SetText(tanksleft[e.Position].TurnHullTime.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            _CompareTankLeftTextEnginePower.SetText(tanksleft[e.Position].EnginePower.ToString() + context.Resources.GetString(Resource.String.AbbrH_P), TextView.BufferType.Normal);
            _CompareTankLeftTextPowerToWeightRatio.SetText(tanksleft[e.Position].PowerToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrH_P_T), TextView.BufferType.Normal);
            _CompareTankLeftTextCannonName.SetText(tanksleft[e.Position].CannonName, TextView.BufferType.Normal);
            _CompareTankLeftTextReloadTime.SetText(tanksleft[e.Position].ReloadTime.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            _CompareTankLeftTextUpAimAngle.SetText(tanksleft[e.Position].UpAimAngle.ToString() + "°", TextView.BufferType.Normal);
            _CompareTankLeftTextDownAimAngle.SetText(tanksleft[e.Position].DownAimAngle.ToString() + "°", TextView.BufferType.Normal);


            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            ISharedPreferencesEditor editor = prefs.Edit();
            var switchchecked = prefs.GetBoolean("key_kmhtomph", false);
            if (switchchecked)
            {
                var maxSpeedAtRoad = tanksleft[e.Position].MaxSpeedAtRoad * 0.621371192;
                var maxSpeedAtTerrain = tanksleft[e.Position].MaxSpeedAtTerrain * 0.621371192;
                var maxReverseSpeed = tanksleft[e.Position].MaxReverseSpeed * 0.621371192;
                var weight = tanksleft[e.Position].Weight * 1.10231131; ;
                var penetration = tanksleft[e.Position].Penetration * 0.039370;
                var shellSpeed = tanksleft[e.Position].ShellSpeed * 3.28084;
                var reducedArmorFrontTurret = tanksleft[e.Position].ReducedArmorFrontTurret * 0.039370;
                var reducedArmorTopSheet = tanksleft[e.Position].ReducedArmorTopSheet * 0.039370;
                var reducedArmorBottomSheet = tanksleft[e.Position].ReducedArmorBottomSheet * 0.039370;
                maxSpeedAtRoad = Math.Round(maxSpeedAtRoad, 0);
                maxSpeedAtTerrain = Math.Round(maxSpeedAtTerrain, 0);
                maxReverseSpeed = Math.Round(maxReverseSpeed, 0);
                weight = Math.Round(weight, 1);
                penetration = Math.Round(penetration, 2);
                shellSpeed = Math.Round(shellSpeed, 0);
                reducedArmorFrontTurret = Math.Round(reducedArmorFrontTurret, 2);
                reducedArmorTopSheet = Math.Round(reducedArmorTopSheet, 2);
                reducedArmorBottomSheet = Math.Round(reducedArmorBottomSheet, 2);

                _CompareTankLabelTextAccelerationTo100.SetText(context.Resources.GetString(Resource.String.TankAccTo100Feet), TextView.BufferType.Normal);

                _CompareTankLeftTextMaxSpeedAtRoad.SetText(maxSpeedAtRoad + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _CompareTankLeftTextMaxSpeedAtTerrain.SetText(maxSpeedAtTerrain + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _CompareTankLeftTextMaxReverseSpeed.SetText(maxReverseSpeed + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _CompareTankLeftTextWeight.SetText(weight + context.Resources.GetString(Resource.String.AbbrST), TextView.BufferType.Normal);
                _CompareTankLeftTextPenetration.SetText(penetration + context.Resources.GetString(Resource.String.AbbrINCH), TextView.BufferType.Normal);
                _CompareTankLeftTextShellSpeed.SetText(shellSpeed + context.Resources.GetString(Resource.String.AbbrFEET_S), TextView.BufferType.Normal);
                _CompareTankLeftTextReducedArmorFrontTurret.SetText(reducedArmorFrontTurret + context.Resources.GetString(Resource.String.AbbrINCH), TextView.BufferType.Normal);
                _CompareTankLeftTextReducedArmorTopSheet.SetText(reducedArmorTopSheet + context.Resources.GetString(Resource.String.AbbrINCH), TextView.BufferType.Normal);
                _CompareTankLeftTextReducedArmorBottomSheet.SetText(reducedArmorBottomSheet + context.Resources.GetString(Resource.String.AbbrINCH), TextView.BufferType.Normal);

            }
            else
            {
                _CompareTankLabelTextAccelerationTo100.SetText(context.Resources.GetString(Resource.String.TankAccTo100), TextView.BufferType.Normal);

                _CompareTankLeftTextMaxSpeedAtRoad.SetText(tanksleft[e.Position].MaxSpeedAtRoad.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _CompareTankLeftTextMaxSpeedAtTerrain.SetText(tanksleft[e.Position].MaxSpeedAtTerrain.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _CompareTankLeftTextMaxReverseSpeed.SetText(tanksleft[e.Position].MaxReverseSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _CompareTankLeftTextWeight.SetText(tanksleft[e.Position].Weight.ToString() + context.Resources.GetString(Resource.String.AbbrT), TextView.BufferType.Normal);
                _CompareTankLeftTextPenetration.SetText(tanksleft[e.Position].Penetration.ToString() + context.Resources.GetString(Resource.String.AbbrMM), TextView.BufferType.Normal);
                _CompareTankLeftTextShellSpeed.SetText(tanksleft[e.Position].ShellSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrM_S), TextView.BufferType.Normal);
                _CompareTankLeftTextReducedArmorFrontTurret.SetText(tanksleft[e.Position].ReducedArmorFrontTurret.ToString() + context.Resources.GetString(Resource.String.AbbrMM), TextView.BufferType.Normal);
                _CompareTankLeftTextReducedArmorTopSheet.SetText(tanksleft[e.Position].ReducedArmorTopSheet.ToString() + context.Resources.GetString(Resource.String.AbbrMM), TextView.BufferType.Normal);
                _CompareTankLeftTextReducedArmorBottomSheet.SetText(tanksleft[e.Position].ReducedArmorBottomSheet.ToString() + context.Resources.GetString(Resource.String.AbbrMM), TextView.BufferType.Normal);

            }


            TankShowBestViaBackgroundColor();
            TankLeftShellShower();

        }



        private void _CompareSpinnerTankRight_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            rightTextMaxSpeedAtRoad = tanksright[e.Position].MaxSpeedAtRoad;
            rightTextMaxSpeedAtTerrain = tanksright[e.Position].MaxSpeedAtTerrain;
            rightTextMaxReverseSpeed = tanksright[e.Position].MaxReverseSpeed;
            rightTextAccelerationTo100 = tanksright[e.Position].AccelerationTo100;
            rightTextTurnTurretTime = tanksright[e.Position].TurnTurretTime;
            rightTextTurnHullTime = tanksright[e.Position].TurnHullTime;
            rightTextEnginePower = tanksright[e.Position].EnginePower;
            rightTextWeight = tanksright[e.Position].Weight;
            rightTextPowerToWeightRatio = tanksright[e.Position].PowerToWeightRatio;
            rightTextPenetration = tanksright[e.Position].Penetration;
            rightTextShellSpeed = tanksright[e.Position].ShellSpeed;
            rightTextReloadTime = tanksright[e.Position].ReloadTime;
            rightTextUpAimAngle = tanksright[e.Position].UpAimAngle;
            rightTextDownAimAngle = tanksright[e.Position].DownAimAngle;
            rightTextStabilizer = tanksright[e.Position].Stabilizer;
            rightTextAAMachineGunExist = tanksright[e.Position].AAMachineGunExist;
            rightTextReducedArmorFrontTurret = tanksright[e.Position].ReducedArmorFrontTurret;
            rightTextReducedArmorTopSheet = tanksright[e.Position].ReducedArmorTopSheet;
            rightTextReducedArmorBottomSheet = tanksright[e.Position].ReducedArmorBottomSheet;
            //для подсветки

            rightShellAP = tanksright[e.Position].ShellAP;
            rightShellAPHE = tanksright[e.Position].ShellAPHE;
            rightShellHE = tanksright[e.Position].ShellHE;
            rightShellAPCR = tanksright[e.Position].ShellAPCR;
            rightShellAPDS = tanksright[e.Position].ShellAPDS;
            rightShellAPFSDS = tanksright[e.Position].ShellAPFSDS;
            rightShellHEAT = tanksright[e.Position].ShellHEAT;
            rightShellHEVT = tanksright[e.Position].ShellHEVT;
            rightShellSAM = tanksright[e.Position].ShellSTA;
            rightShellHEATFS = tanksright[e.Position].ShellHEATFS;
            rightShellShrapnel = tanksright[e.Position].ShellShrapnel;
            rightShellHESH = tanksright[e.Position].ShellHESH;
            rightShellATGM = tanksright[e.Position].ShellATGM;
            rightShellSSM = tanksright[e.Position].ShellSSM;
            rightShellHEATGRENADE = tanksright[e.Position].ShellHEATGRENADE;
            rightShellHEGRENADE = tanksright[e.Position].ShellHEGRENADE;

            _CompareImageRight.SetImageResource(tanksright[e.Position].Image);
            _CompareRightFlag.SetImageResource(tanksright[e.Position].FlagImage);
            _CompareTankRightTextAccelerationTo100.SetText(tanksright[e.Position].AccelerationTo100.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            _CompareTankRightTextTurnTurretTime.SetText(tanksright[e.Position].TurnTurretTime.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            _CompareTankRightTextTurnHullTime.SetText(tanksright[e.Position].TurnHullTime.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            _CompareTankRightTextEnginePower.SetText(tanksright[e.Position].EnginePower.ToString() + context.Resources.GetString(Resource.String.AbbrH_P), TextView.BufferType.Normal);
            _CompareTankRightTextPowerToWeightRatio.SetText(tanksright[e.Position].PowerToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrH_P_T), TextView.BufferType.Normal);
            _CompareTankRightTextCannonName.SetText(tanksright[e.Position].CannonName, TextView.BufferType.Normal);
            _CompareTankRightTextReloadTime.SetText(tanksright[e.Position].ReloadTime.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            _CompareTankRightTextUpAimAngle.SetText(tanksright[e.Position].UpAimAngle.ToString() + "°", TextView.BufferType.Normal);
            _CompareTankRightTextDownAimAngle.SetText(tanksright[e.Position].DownAimAngle.ToString() + "°", TextView.BufferType.Normal);


            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            ISharedPreferencesEditor editor = prefs.Edit();
            var switchchecked = prefs.GetBoolean("key_kmhtomph", false);
            if (switchchecked)
            {
                var maxSpeedAtRoad = tanksright[e.Position].MaxSpeedAtRoad * 0.621371192;
                var maxSpeedAtTerrain = tanksright[e.Position].MaxSpeedAtTerrain * 0.621371192;
                var maxReverseSpeed = tanksright[e.Position].MaxReverseSpeed * 0.621371192;
                var weight = tanksright[e.Position].Weight * 1.10231131; ;
                var penetration = tanksright[e.Position].Penetration * 0.039370;
                var shellSpeed = tanksright[e.Position].ShellSpeed * 3.28084;
                var reducedArmorFrontTurret = tanksright[e.Position].ReducedArmorFrontTurret * 0.039370;
                var reducedArmorTopSheet = tanksright[e.Position].ReducedArmorTopSheet * 0.039370;
                var reducedArmorBottomSheet = tanksright[e.Position].ReducedArmorBottomSheet * 0.039370;
                maxSpeedAtRoad = Math.Round(maxSpeedAtRoad, 0);
                maxSpeedAtTerrain = Math.Round(maxSpeedAtTerrain, 0);
                maxReverseSpeed = Math.Round(maxReverseSpeed, 0);
                weight = Math.Round(weight, 1);
                penetration = Math.Round(penetration, 2);
                shellSpeed = Math.Round(shellSpeed, 0);
                reducedArmorFrontTurret = Math.Round(reducedArmorFrontTurret, 2);
                reducedArmorTopSheet = Math.Round(reducedArmorTopSheet, 2);
                reducedArmorBottomSheet = Math.Round(reducedArmorBottomSheet, 2);

                _CompareTankRightTextMaxSpeedAtRoad.SetText(maxSpeedAtRoad + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _CompareTankRightTextMaxSpeedAtTerrain.SetText(maxSpeedAtTerrain + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _CompareTankRightTextMaxReverseSpeed.SetText(maxReverseSpeed + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _CompareTankRightTextWeight.SetText(weight + context.Resources.GetString(Resource.String.AbbrST), TextView.BufferType.Normal);
                _CompareTankRightTextPenetration.SetText(penetration + context.Resources.GetString(Resource.String.AbbrINCH), TextView.BufferType.Normal);
                _CompareTankRightTextShellSpeed.SetText(shellSpeed + context.Resources.GetString(Resource.String.AbbrFEET_S), TextView.BufferType.Normal);
                _CompareTankRightTextReducedArmorFrontTurret.SetText(reducedArmorFrontTurret + context.Resources.GetString(Resource.String.AbbrINCH), TextView.BufferType.Normal);
                _CompareTankRightTextReducedArmorTopSheet.SetText(reducedArmorTopSheet + context.Resources.GetString(Resource.String.AbbrINCH), TextView.BufferType.Normal);
                _CompareTankRightTextReducedArmorBottomSheet.SetText(reducedArmorBottomSheet + context.Resources.GetString(Resource.String.AbbrINCH), TextView.BufferType.Normal);

            }
            else
            {
                _CompareTankRightTextMaxSpeedAtRoad.SetText(tanksright[e.Position].MaxSpeedAtRoad.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _CompareTankRightTextMaxSpeedAtTerrain.SetText(tanksright[e.Position].MaxSpeedAtTerrain.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _CompareTankRightTextMaxReverseSpeed.SetText(tanksright[e.Position].MaxReverseSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _CompareTankRightTextWeight.SetText(tanksright[e.Position].Weight.ToString() + context.Resources.GetString(Resource.String.AbbrT), TextView.BufferType.Normal);
                _CompareTankRightTextPenetration.SetText(tanksright[e.Position].Penetration.ToString() + context.Resources.GetString(Resource.String.AbbrMM), TextView.BufferType.Normal);
                _CompareTankRightTextShellSpeed.SetText(tanksright[e.Position].ShellSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrM_S), TextView.BufferType.Normal);
                _CompareTankRightTextReducedArmorFrontTurret.SetText(tanksright[e.Position].ReducedArmorFrontTurret.ToString() + context.Resources.GetString(Resource.String.AbbrMM), TextView.BufferType.Normal);
                _CompareTankRightTextReducedArmorTopSheet.SetText(tanksright[e.Position].ReducedArmorTopSheet.ToString() + context.Resources.GetString(Resource.String.AbbrMM), TextView.BufferType.Normal);
                _CompareTankRightTextReducedArmorBottomSheet.SetText(tanksright[e.Position].ReducedArmorBottomSheet.ToString() + context.Resources.GetString(Resource.String.AbbrMM), TextView.BufferType.Normal);

            }


            TankShowBestViaBackgroundColor();
            TankRightShellShower();


        }



        public void TankLeftSelector()
        {
            if (selectedNationLeft == 100 && selectedRankLeft == 100)
            {
                tanksleft = TankCollection.GetTank();
                AdapterTankLeft = new TankAdapter(this, tanksleft);
                _CompareSpinnerTankLeft.Adapter = AdapterTankLeft;
            }
            else
          if (selectedNationLeft == 100)
            {
                List<Tank> tanksAll = TankCollection.GetTank();
                var tankvar = from p in tanksAll
                              where p.RankId == selectedRankLeft
                              select p;
                tanksleft = tankvar.ToList<Tank>();
                AdapterTankLeft = new TankAdapter(this, tanksleft);
                _CompareSpinnerTankLeft.Adapter = AdapterTankLeft;
            }
            else
          if (selectedRankLeft == 100)
            {
                List<Tank> tanksAll = TankCollection.GetTank();
                var tankvar = from p in tanksAll
                              where p.NationId == selectedNationLeft
                              select p;
                tanksleft = tankvar.ToList<Tank>();
                AdapterTankLeft = new TankAdapter(this, tanksleft);
                _CompareSpinnerTankLeft.Adapter = AdapterTankLeft;
            }
            else
            {
                tanksleft = TankSelectorWithout100left(selectedNationLeft, selectedRankLeft);
                AdapterTankLeft = new TankAdapter(this, tanksleft);
                _CompareSpinnerTankLeft.Adapter = AdapterTankLeft;
            }
        }

        public List<Tank> TankSelectorWithout100left(int selectedNationLeft, int selectedRankLeft)
        {
            this.selectedNationLeft = selectedNationLeft;
            this.selectedRankLeft = selectedRankLeft;

            List<Tank> tanksAll = TankCollection.GetTank();
            var tankvar = from p in tanksAll
                          where p.NationId == selectedNationLeft
                          where p.RankId == selectedRankLeft
                          select p;
            return tankvar.ToList<Tank>();
        }



        private void TankRightSelector()
        {
            if (selectedNationRight == 100 && selectedRankRight == 100)
            {
                tanksright = TankCollection.GetTank();
                AdapterTankRight = new TankAdapter(this, tanksright);
                _CompareSpinnerTankRight.Adapter = AdapterTankRight;
            }
            else
          if (selectedNationRight == 100)
            {
                List<Tank> tanksAll = TankCollection.GetTank();
                var tankvar = from p in tanksAll
                              where p.RankId == selectedRankRight
                              select p;
                tanksright = tankvar.ToList<Tank>();
                AdapterTankRight = new TankAdapter(this, tanksright);
                _CompareSpinnerTankRight.Adapter = AdapterTankRight;
            }
            else
          if (selectedRankRight == 100)
            {
                List<Tank> tanksAll = TankCollection.GetTank();
                var tankvar = from p in tanksAll
                              where p.NationId == selectedNationRight
                              select p;
                tanksright = tankvar.ToList<Tank>();
                AdapterTankRight = new TankAdapter(this, tanksright);
                _CompareSpinnerTankRight.Adapter = AdapterTankRight;
            }
            else
            {
                tanksright = TankSelectorWithout100right(selectedNationRight, selectedRankRight);
                AdapterTankRight = new TankAdapter(this, tanksright);
                _CompareSpinnerTankRight.Adapter = AdapterTankRight;
            }
        }
        public List<Tank> TankSelectorWithout100right(int selectedNationRight, int selectedRankRight)
        {
            this.selectedNationRight = selectedNationRight;
            this.selectedRankRight = selectedRankRight;

            List<Tank> tanksAll = TankCollection.GetTank();
            var tankvar = from p in tanksAll
                          where p.NationId == selectedNationRight
                          where p.RankId == selectedRankRight
                          select p;
            return tankvar.ToList<Tank>();
        }


        private void TankLeftShellShower()
        {
            if (leftShellAP == true)
            {
                _LeftShellAP.SetImageResource(Resource.Drawable._ShellAP);
            }
            else
            {
                _LeftShellAP.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (leftShellAPHE == true)
            {
                _LeftShellAPHE.SetImageResource(Resource.Drawable._ShellAPHE);
            }
            else
            {
                _LeftShellAPHE.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (leftShellHE == true)
            {
                _LeftShellHE.SetImageResource(Resource.Drawable._ShellHE);
            }
            else
            {
                _LeftShellHE.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (leftShellAPCR == true)
            {
                _LeftShellAPCR.SetImageResource(Resource.Drawable._ShellAPCR);
            }
            else
            {
                _LeftShellAPCR.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (leftShellAPDS == true)
            {
                _LeftShellAPDS.SetImageResource(Resource.Drawable._ShellAPDS);
            }
            else
            {
                _LeftShellAPDS.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (leftShellAPFSDS == true)
            {
                _LeftShellAPFSDS.SetImageResource(Resource.Drawable._ShellAPFSDS);
            }
            else
            {
                _LeftShellAPFSDS.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (leftShellHEAT == true)
            {
                _LeftShellHEAT.SetImageResource(Resource.Drawable._ShellHEAT);
            }
            else
            {
                _LeftShellHEAT.SetImageResource(Resource.Drawable._handingTransparent);
            }


            if (leftShellHEVT == true)
            {
                _LeftShellHEVT.SetImageResource(Resource.Drawable._ShellHEVT);
            }
            else
            {
                _LeftShellHEVT.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (leftShellSAM == true)
            {
                _LeftShellSAM.SetImageResource(Resource.Drawable._ShellSAM);
            }
            else
            {
                _LeftShellSAM.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (leftShellHEATFS == true)
            {
                _LeftShellHEATFS.SetImageResource(Resource.Drawable._ShellHEATFS);
            }
            else
            {
                _LeftShellHEATFS.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (leftShellShrapnel == true)
            {
                _LeftShellShrapnel.SetImageResource(Resource.Drawable._ShellShrapnel);
            }
            else
            {
                _LeftShellShrapnel.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (leftShellHESH == true)
            {
                _LeftShellHESH.SetImageResource(Resource.Drawable._ShellHESH);
            }
            else
            {
                _LeftShellHESH.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (leftShellATGM == true)
            {
                _LeftShellATGM.SetImageResource(Resource.Drawable._ShellATGM);
            }
            else
            {
                _LeftShellATGM.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (leftShellSSM == true)
            {
                _LeftShellSSM.SetImageResource(Resource.Drawable._ShellSSM);
            }
            else
            {
                _LeftShellSSM.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (leftShellHEATGRENADE == true)
            {
                _LeftShellHEATGRENADE.SetImageResource(Resource.Drawable._ShellHEATGRENADE);
            }
            else
            {
                _LeftShellHEATGRENADE.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (leftShellHEGRENADE == true)
            {
                _LeftShellHEGRENADE.SetImageResource(Resource.Drawable._ShellHEGRENADE);
            }
            else
            {
                _LeftShellHEGRENADE.SetImageResource(Resource.Drawable._handingTransparent);
            }

        }

        private void TankRightShellShower()
        {
            if (rightShellAP == true)
            {
                _RightShellAP.SetImageResource(Resource.Drawable._ShellAP);
            }
            else
            {
                _RightShellAP.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (rightShellAPHE == true)
            {
                _RightShellAPHE.SetImageResource(Resource.Drawable._ShellAPHE);
            }
            else
            {
                _RightShellAPHE.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (rightShellHE == true)
            {
                _RightShellHE.SetImageResource(Resource.Drawable._ShellHE);
            }
            else
            {
                _RightShellHE.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (rightShellAPCR == true)
            {
                _RightShellAPCR.SetImageResource(Resource.Drawable._ShellAPCR);
            }
            else
            {
                _RightShellAPCR.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (rightShellAPDS == true)
            {
                _RightShellAPDS.SetImageResource(Resource.Drawable._ShellAPDS);
            }
            else
            {
                _RightShellAPDS.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (rightShellAPFSDS == true)
            {
                _RightShellAPFSDS.SetImageResource(Resource.Drawable._ShellAPFSDS);
            }
            else
            {
                _RightShellAPFSDS.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (rightShellHEAT == true)
            {
                _RightShellHEAT.SetImageResource(Resource.Drawable._ShellHEAT);
            }
            else
            {
                _RightShellHEAT.SetImageResource(Resource.Drawable._handingTransparent);
            }


            if (rightShellHEVT == true)
            {
                _RightShellHEVT.SetImageResource(Resource.Drawable._ShellHEVT);
            }
            else
            {
                _RightShellHEVT.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (rightShellSAM == true)
            {
                _RightShellSAM.SetImageResource(Resource.Drawable._ShellSAM);
            }
            else
            {
                _RightShellSAM.SetImageResource(Resource.Drawable._handingTransparent);
            }


            if (rightShellHEATFS == true)
            {
                _RightShellHEATFS.SetImageResource(Resource.Drawable._ShellHEATFS);
            }
            else
            {
                _RightShellHEATFS.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (rightShellShrapnel == true)
            {
                _RightShellShrapnel.SetImageResource(Resource.Drawable._ShellShrapnel);
            }
            else
            {
                _RightShellShrapnel.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (rightShellHESH == true)
            {
                _RightShellHESH.SetImageResource(Resource.Drawable._ShellHESH);
            }
            else
            {
                _RightShellHESH.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (rightShellATGM == true)
            {
                _RightShellATGM.SetImageResource(Resource.Drawable._ShellATGM);
            }
            else
            {
                _RightShellATGM.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (rightShellSSM == true)
            {
                _RightShellSSM.SetImageResource(Resource.Drawable._ShellSSM);
            }
            else
            {
                _RightShellSSM.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (rightShellHEATGRENADE == true)
            {
                _RightShellHEATGRENADE.SetImageResource(Resource.Drawable._ShellHEATGRENADE);
            }
            else
            {
                _RightShellHEATGRENADE.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (rightShellHEGRENADE == true)
            {
                _RightShellHEGRENADE.SetImageResource(Resource.Drawable._ShellHEGRENADE);
            }
            else
            {
                _RightShellHEGRENADE.SetImageResource(Resource.Drawable._handingTransparent);
            }

        }


        private void TankShowBestViaBackgroundColor()
        {

            if (leftTextMaxSpeedAtRoad > rightTextMaxSpeedAtRoad)
            {
                _CompareTankLeftTextMaxSpeedAtRoad.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareTankRightTextMaxSpeedAtRoad.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
            if (leftTextMaxSpeedAtRoad < rightTextMaxSpeedAtRoad)
            {
                _CompareTankLeftTextMaxSpeedAtRoad.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareTankRightTextMaxSpeedAtRoad.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else
            if (leftTextMaxSpeedAtRoad == rightTextMaxSpeedAtRoad)
            {
                _CompareTankLeftTextMaxSpeedAtRoad.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareTankRightTextMaxSpeedAtRoad.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }


            if (leftTextMaxSpeedAtTerrain > rightTextMaxSpeedAtTerrain)
            {
                _CompareTankLeftTextMaxSpeedAtTerrain.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareTankRightTextMaxSpeedAtTerrain.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
            if (leftTextMaxSpeedAtTerrain < rightTextMaxSpeedAtTerrain)
            {
                _CompareTankLeftTextMaxSpeedAtTerrain.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareTankRightTextMaxSpeedAtTerrain.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else
            if (leftTextMaxSpeedAtTerrain == rightTextMaxSpeedAtTerrain)
            {
                _CompareTankLeftTextMaxSpeedAtTerrain.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareTankRightTextMaxSpeedAtTerrain.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }


            if (leftTextMaxReverseSpeed > rightTextMaxReverseSpeed)
            {
                _CompareTankLeftTextMaxReverseSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareTankRightTextMaxReverseSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
 if (leftTextMaxReverseSpeed < rightTextMaxReverseSpeed)
            {
                _CompareTankLeftTextMaxReverseSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareTankRightTextMaxReverseSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else
 if (leftTextMaxReverseSpeed == rightTextMaxReverseSpeed)
            {
                _CompareTankLeftTextMaxReverseSpeed.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareTankRightTextMaxReverseSpeed.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }



            if (leftTextAccelerationTo100 < rightTextAccelerationTo100)
            {
                _CompareTankLeftTextAccelerationTo100.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareTankRightTextAccelerationTo100.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftTextAccelerationTo100 > rightTextAccelerationTo100)
            {
                _CompareTankLeftTextAccelerationTo100.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareTankRightTextAccelerationTo100.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else
if (leftTextAccelerationTo100 == rightTextAccelerationTo100)
            {
                _CompareTankLeftTextAccelerationTo100.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareTankRightTextAccelerationTo100.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }



            ///////////////////////////////

            if (rightTextTurnTurretTime == 0 && leftTextTurnTurretTime != 0)
            {
                _CompareTankLeftTextTurnTurretTime.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareTankRightTextTurnTurretTime.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
            if (leftTextTurnTurretTime == 0 && rightTextTurnTurretTime != 0)
            {
                _CompareTankLeftTextTurnTurretTime.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareTankRightTextTurnTurretTime.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else
            if (leftTextTurnTurretTime == 0 && rightTextTurnTurretTime == 0)
            {
                _CompareTankLeftTextTurnTurretTime.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareTankRightTextTurnTurretTime.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }
            else
            {  ///////////////////
                if (leftTextTurnTurretTime < rightTextTurnTurretTime)
                {
                    _CompareTankLeftTextTurnTurretTime.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                    _CompareTankRightTextTurnTurretTime.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                }
                else
                if (leftTextTurnTurretTime > rightTextTurnTurretTime)
                {
                    _CompareTankLeftTextTurnTurretTime.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                    _CompareTankRightTextTurnTurretTime.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                }
                else
                if (leftTextTurnTurretTime == rightTextTurnTurretTime)
                {
                    _CompareTankLeftTextTurnTurretTime.SetBackgroundResource(Resource.Drawable._gradientEqual);
                    _CompareTankRightTextTurnTurretTime.SetBackgroundResource(Resource.Drawable._gradientEqual);
                }
            }

            ////////////////////////


            if (leftTextTurnHullTime < rightTextTurnHullTime)
            {
                _CompareTankLeftTextTurnHullTime.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareTankRightTextTurnHullTime.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftTextTurnHullTime > rightTextTurnHullTime)
            {
                _CompareTankLeftTextTurnHullTime.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareTankRightTextTurnHullTime.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else
if (leftTextTurnHullTime == rightTextTurnHullTime)
            {
                _CompareTankLeftTextTurnHullTime.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareTankRightTextTurnHullTime.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }


            if (leftTextEnginePower > rightTextEnginePower)
            {
                _CompareTankLeftTextEnginePower.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareTankRightTextEnginePower.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftTextEnginePower < rightTextEnginePower)
            {
                _CompareTankLeftTextEnginePower.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareTankRightTextEnginePower.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else
if (leftTextEnginePower == rightTextEnginePower)
            {
                _CompareTankLeftTextEnginePower.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareTankRightTextEnginePower.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }


            if (leftTextWeight < rightTextWeight)
            {
                _CompareTankLeftTextWeight.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareTankRightTextWeight.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftTextWeight > rightTextWeight)
            {
                _CompareTankLeftTextWeight.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareTankRightTextWeight.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else
if (leftTextWeight == rightTextWeight)
            {
                _CompareTankLeftTextWeight.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareTankRightTextWeight.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }


            if (leftTextPowerToWeightRatio > rightTextPowerToWeightRatio)
            {
                _CompareTankLeftTextPowerToWeightRatio.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareTankRightTextPowerToWeightRatio.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftTextPowerToWeightRatio < rightTextPowerToWeightRatio)
            {
                _CompareTankLeftTextPowerToWeightRatio.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareTankRightTextPowerToWeightRatio.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else
if (leftTextPowerToWeightRatio == rightTextPowerToWeightRatio)
            {
                _CompareTankLeftTextPowerToWeightRatio.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareTankRightTextPowerToWeightRatio.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }



            if (leftTextPenetration > rightTextPenetration)
            {
                _CompareTankLeftTextPenetration.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareTankRightTextPenetration.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftTextPenetration < rightTextPenetration)
            {
                _CompareTankLeftTextPenetration.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareTankRightTextPenetration.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else
if (leftTextPenetration == rightTextPenetration)
            {
                _CompareTankLeftTextPenetration.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareTankRightTextPenetration.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }


            if (leftTextShellSpeed > rightTextShellSpeed)
            {
                _CompareTankLeftTextShellSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareTankRightTextShellSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftTextShellSpeed < rightTextShellSpeed)
            {
                _CompareTankLeftTextShellSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareTankRightTextShellSpeed.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else
if (leftTextShellSpeed == rightTextShellSpeed)
            {
                _CompareTankLeftTextShellSpeed.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareTankRightTextShellSpeed.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }


            if (leftTextReloadTime < rightTextReloadTime)
            {
                _CompareTankLeftTextReloadTime.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareTankRightTextReloadTime.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftTextReloadTime > rightTextReloadTime)
            {
                _CompareTankLeftTextReloadTime.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareTankRightTextReloadTime.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else
if (leftTextReloadTime == rightTextReloadTime)
            {
                _CompareTankLeftTextReloadTime.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareTankRightTextReloadTime.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }

            if (leftTextUpAimAngle > rightTextUpAimAngle)
            {
                _CompareTankLeftTextUpAimAngle.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareTankRightTextUpAimAngle.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftTextUpAimAngle < rightTextUpAimAngle)
            {
                _CompareTankLeftTextUpAimAngle.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareTankRightTextUpAimAngle.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else
if (leftTextUpAimAngle == rightTextUpAimAngle)
            {
                _CompareTankLeftTextUpAimAngle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareTankRightTextUpAimAngle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }


            if (leftTextDownAimAngle < rightTextDownAimAngle)
            {
                _CompareTankLeftTextDownAimAngle.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareTankRightTextDownAimAngle.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftTextDownAimAngle > rightTextDownAimAngle)
            {
                _CompareTankLeftTextDownAimAngle.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareTankRightTextDownAimAngle.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else
if (leftTextDownAimAngle == rightTextDownAimAngle)
            {
                _CompareTankLeftTextDownAimAngle.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareTankRightTextDownAimAngle.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }


            if (leftTextReducedArmorFrontTurret > rightTextReducedArmorFrontTurret)
            {
                _CompareTankLeftTextReducedArmorFrontTurret.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareTankRightTextReducedArmorFrontTurret.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftTextReducedArmorFrontTurret < rightTextReducedArmorFrontTurret)
            {
                _CompareTankLeftTextReducedArmorFrontTurret.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareTankRightTextReducedArmorFrontTurret.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else
if (leftTextReducedArmorFrontTurret == rightTextReducedArmorFrontTurret)
            {
                _CompareTankLeftTextReducedArmorFrontTurret.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareTankRightTextReducedArmorFrontTurret.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }

            if (leftTextReducedArmorTopSheet > rightTextReducedArmorTopSheet)
            {
                _CompareTankLeftTextReducedArmorTopSheet.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareTankRightTextReducedArmorTopSheet.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftTextReducedArmorTopSheet < rightTextReducedArmorTopSheet)
            {
                _CompareTankLeftTextReducedArmorTopSheet.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareTankRightTextReducedArmorTopSheet.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else
if (leftTextReducedArmorTopSheet == rightTextReducedArmorTopSheet)
            {
                _CompareTankLeftTextReducedArmorTopSheet.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareTankRightTextReducedArmorTopSheet.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }


            if (leftTextReducedArmorBottomSheet > rightTextReducedArmorBottomSheet)
            {
                _CompareTankLeftTextReducedArmorBottomSheet.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareTankRightTextReducedArmorBottomSheet.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
if (leftTextReducedArmorBottomSheet < rightTextReducedArmorBottomSheet)
            {
                _CompareTankLeftTextReducedArmorBottomSheet.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareTankRightTextReducedArmorBottomSheet.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else
if (leftTextReducedArmorBottomSheet == rightTextReducedArmorBottomSheet)
            {
                _CompareTankLeftTextReducedArmorBottomSheet.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareTankRightTextReducedArmorBottomSheet.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }



            if (leftTextAAMachineGunExist == true && rightTextAAMachineGunExist == false)
            {
                _CompareTankLeftTextAAMachineGunExist.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareTankRightTextAAMachineGunExist.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                _CompareTankLeftTextAAMachineGunExist.SetText(context.Resources.GetString(Resource.String.TankYes), TextView.BufferType.Normal);
                _CompareTankRightTextAAMachineGunExist.SetText(context.Resources.GetString(Resource.String.TankNo), TextView.BufferType.Normal);

            }
            else
                if (leftTextAAMachineGunExist == false && rightTextAAMachineGunExist == true)
            {
                _CompareTankLeftTextAAMachineGunExist.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareTankRightTextAAMachineGunExist.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                _CompareTankLeftTextAAMachineGunExist.SetText(context.Resources.GetString(Resource.String.TankNo), TextView.BufferType.Normal);
                _CompareTankRightTextAAMachineGunExist.SetText(context.Resources.GetString(Resource.String.TankYes), TextView.BufferType.Normal);

            }
            else
            if (leftTextAAMachineGunExist == true && rightTextAAMachineGunExist == true)
            {
                _CompareTankLeftTextAAMachineGunExist.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareTankRightTextAAMachineGunExist.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareTankLeftTextAAMachineGunExist.SetText(context.Resources.GetString(Resource.String.TankYes), TextView.BufferType.Normal);
                _CompareTankRightTextAAMachineGunExist.SetText(context.Resources.GetString(Resource.String.TankYes), TextView.BufferType.Normal);
            }
            else
            if (leftTextAAMachineGunExist == false && rightTextAAMachineGunExist == false)
            {
                _CompareTankLeftTextAAMachineGunExist.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareTankRightTextAAMachineGunExist.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareTankLeftTextAAMachineGunExist.SetText(context.Resources.GetString(Resource.String.TankNo), TextView.BufferType.Normal);
                _CompareTankRightTextAAMachineGunExist.SetText(context.Resources.GetString(Resource.String.TankNo), TextView.BufferType.Normal);
            }



            if (leftTextStabilizer == true && rightTextStabilizer == false)
            {
                _CompareTankLeftTextStabilizer.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _CompareTankRightTextStabilizer.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
                _CompareTankLeftTextStabilizer.SetText(context.Resources.GetString(Resource.String.TankYes), TextView.BufferType.Normal);
                _CompareTankRightTextStabilizer.SetText(context.Resources.GetString(Resource.String.TankNo), TextView.BufferType.Normal);

            }
            else
           if (leftTextStabilizer == false && rightTextStabilizer == true)
            {
                _CompareTankLeftTextStabilizer.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _CompareTankRightTextStabilizer.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
                _CompareTankLeftTextStabilizer.SetText(context.Resources.GetString(Resource.String.TankNo), TextView.BufferType.Normal);
                _CompareTankRightTextStabilizer.SetText(context.Resources.GetString(Resource.String.TankYes), TextView.BufferType.Normal);

            }
            else
          if (leftTextStabilizer == true && rightTextStabilizer == true)
            {
                _CompareTankLeftTextStabilizer.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareTankRightTextStabilizer.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareTankLeftTextStabilizer.SetText(context.Resources.GetString(Resource.String.TankYes), TextView.BufferType.Normal);
                _CompareTankRightTextStabilizer.SetText(context.Resources.GetString(Resource.String.TankYes), TextView.BufferType.Normal);
            }
            else
          if (leftTextStabilizer == false && rightTextStabilizer == false)
            {
                _CompareTankLeftTextStabilizer.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareTankRightTextStabilizer.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _CompareTankLeftTextStabilizer.SetText(context.Resources.GetString(Resource.String.TankNo), TextView.BufferType.Normal);
                _CompareTankRightTextStabilizer.SetText(context.Resources.GetString(Resource.String.TankNo), TextView.BufferType.Normal);
            }

        }

        private void RateApp()
        {
            if (showRateAlert == 10)
            {
                layoutInflater = LayoutInflater.From(this);
                mview = layoutInflater.Inflate(Resource.Layout._alertDialogRateApp, null);
                alertDialogBuilder = new Android.App.AlertDialog.Builder(this);
                alertDialogBuilder.SetView(mview);
                alertDialogAndroid = alertDialogBuilder.Create();
                alertDialogAndroid.Show();
                alertDialogAndroid.SetCanceledOnTouchOutside(false);
                alertDialogAndroid.SetCancelable(false);
                rateButtonYes = mview.FindViewById<Button>(Resource.Id.buttonYes);
                rateButtonNo = mview.FindViewById<Button>(Resource.Id.buttonNo);
                rateButtonNo.Click += RateButtonNo_Click;
                rateButtonYes.Click += RateButtonYes_Click;
            }
        }

        private void RateButtonNo_Click(object sender, EventArgs e)
        {
            alertDialogAndroid.Dismiss();
        }

        private void RateButtonYes_Click(object sender, EventArgs e)
        {
            alertDialogAndroid.Dismiss();
            StartActivity(new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://play.google.com/store/apps/details?id=com.wave.wtversus")));
        }

    }
}