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
    class InfoTank : AppCompatActivity
    {
        Spinner _InfoSpinnerNation;
        Spinner _InfoSpinnerTank;
        Spinner _InfoSpinnerRank;
        ListView _InfoListView;
        Spinner _InfoSpinnerPotentialEnemyTank;
        TaskAdapter PotentialAdapterTask;
        //Объявление  спиннеров и скролов с XAML


        #region Объявление всех Textview
        Context context;
        ImageView _InfoImage;
        ImageView _InfoFlag;
        ImageView _ShellAP;
        ImageView _ShellAPHE;
        ImageView _ShellHE;
        ImageView _ShellAPCR;
        ImageView _ShellAPDS;
        ImageView _ShellAPFSDS;
        ImageView _ShellHEAT;
        ImageView _ShellHEATFS;
        ImageView _ShellShrapnel;
        ImageView _ShellHESH;
        ImageView _ShellATGM;
        ImageView _ShellSSM;
        ImageView _ShellHEATGRENADE;
        ImageView _ShellHEGRENADE;
        ImageView _ShellHEVT;
        ImageView _ShellSAM;

        TextView _InfoTankLabelTextBR;
        TextView _InfoTankLabelTextType;
        TextView _InfoTankLabelTextCharacter;
        TextView _InfoTankLabelTextFirstRideYear;
        TextView _InfoTankLabelTextPatchAdded;
        TextView _InfoTankLabelTextMaxSpeedAtRoad;
        TextView _InfoTankLabelTextMaxSpeedAtTerrain;
        TextView _InfoTankLabelTextMaxReverseSpeed;
        TextView _InfoTankLabelTextAccelerationTo100;
        TextView _InfoTankLabelTextTurnTurretTime;
        TextView _InfoTankLabelTextTurnHullTime;
        TextView _InfoTankLabelTextEnginePower;
        TextView _InfoTankLabelTextWeight;
        TextView _InfoTankLabelTextPowerToWeightRatio;
        TextView _InfoTankLabelTextPenetration;
        TextView _InfoTankLabelTextShellSpeed;
        TextView _InfoTankLabelTextReloadTime;
        TextView _InfoTankLabelTextUpAimAngle;
        TextView _InfoTankLabelTextDownAimAngle;
        TextView _InfoTankLabelTextStabilizer;
        TextView _InfoTankLabelTextAAMachineGunExist;
        TextView _InfoTankLabelTextReducedArmorFrontTurret;
        TextView _InfoTankLabelTextReducedArmorTopSheet;
        TextView _InfoTankLabelTextReducedArmorBottomSheet;

        TextView _InfoTankTextBR;
        TextView _InfoTankTextType;
        TextView _InfoTankTextCharacter;
        TextView _InfoTankTextFirstRideYear;
        TextView _InfoTankTextPatchAdded;
        TextView _InfoTankTextMaxSpeedAtRoad;
        TextView _InfoTankTextMaxSpeedAtTerrain;
        TextView _InfoTankTextMaxReverseSpeed;
        TextView _InfoTankTextAccelerationTo100;
        TextView _InfoTankTextTurnTurretTime;
        TextView _InfoTankTextTurnHullTime;
        TextView _InfoTankTextEnginePower;
        TextView _InfoTankTextWeight;
        TextView _InfoTankTextPowerToWeightRatio;
        TextView _InfoTankTextCannonName;
        TextView _InfoTankTextPenetration;
        TextView _InfoTankTextShellSpeed;
        TextView _InfoTankTextReloadTime;
        TextView _InfoTankTextUpAimAngle;
        TextView _InfoTankTextDownAimAngle;
        TextView _InfoTankTextStabilizer;
        TextView _InfoTankTextAAMachineGunExist;
        TextView _InfoTankTextReducedArmorFrontTurret;
        TextView _InfoTankTextReducedArmorTopSheet;
        TextView _InfoTankTextReducedArmorBottomSheet;
        TextView _InfoTankShellType;

        //Объявление текстовых полей
        #endregion

        List<Tank> tanks;
        List<Tank> tankspotential;
        TankAdapter AdapterTank;
        List<Nation> nations;
        NationAdapter AdapterNation;
        List<Rank> ranks;
        public List<Task> potentialTask;
        RankAdapter AdapterRank;
        ListViewInfoTankAdapter AdapterListView;


        private int selectedNation;
        private int selectedRank;
        private double selectedTankBR;
        private bool textAAMachineGunExist;
        private bool textStabilizer;
        public static int SelectedPotentialTask;

        private bool ShellAP;
        private bool ShellAPHE;
        private bool ShellHE;
        private bool ShellAPCR;
        private bool ShellAPDS;
        private bool ShellAPFSDS;
        private bool ShellHEAT;
        private bool ShellHEATFS;
        private bool ShellShrapnel;
        private bool ShellHESH;
        private bool ShellATGM;
        private bool ShellSSM;
        private bool ShellHEATGRENADE;
        private bool ShellHEGRENADE;
        private bool ShellSAM;
        private bool ShellHEVT;


        // Объявление адаптеров, коллекций и переменных        


        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\
        DrawerLayout drawerLayout;
        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\

        public InfoTank()
        {
        }

        protected InfoTank(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.InfoTank);
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
            var adView = FindViewById<AdView>(Resource.Id.adViewInfoTankkk);
                 var adRequest = new AdRequest.Builder().Build();
                adView.LoadAd(adRequest);
            //var requestbuilder = new AdRequest.Builder().AddTestDevice("D0BE22F1A4BE27C7470F95A699568FE2");
            //adView.LoadAd(requestbuilder.Build());
            //шрифт
            var font = Typeface.CreateFromAsset(Assets, "dinfont.ttf");

            _InfoSpinnerNation = FindViewById<Spinner>(Resource.Id.InfoSpinnerNationT);
            _InfoSpinnerRank = FindViewById<Spinner>(Resource.Id.InfoSpinnerRankT);
            _InfoSpinnerTank = FindViewById<Spinner>(Resource.Id.InfoSpinnerTank);
            _InfoListView = FindViewById<ListView>(Resource.Id.listViewT);
            _InfoSpinnerPotentialEnemyTank = FindViewById<Spinner>(Resource.Id.InfoSpinnerPotentialEnemyTank);
            //Привязка спиннеров к шарп коду

            #region Привязка TextView к коду
            _InfoImage = FindViewById<ImageView>(Resource.Id.InfoImageT);
            _InfoFlag = FindViewById<ImageView>(Resource.Id.InfoFlagT);

            _ShellAP = FindViewById<ImageView>(Resource.Id.InfoShellAP);
            _ShellAPHE = FindViewById<ImageView>(Resource.Id.InfoShellAPHE);
            _ShellHE = FindViewById<ImageView>(Resource.Id.InfoShellHE);
            _ShellAPCR = FindViewById<ImageView>(Resource.Id.InfoShellAPCR);
            _ShellAPDS = FindViewById<ImageView>(Resource.Id.InfoShellAPDS);
            _ShellAPFSDS = FindViewById<ImageView>(Resource.Id.InfoShellAPFSDS);
            _ShellHEAT = FindViewById<ImageView>(Resource.Id.InfoShellHEAT);
            _ShellHEATFS = FindViewById<ImageView>(Resource.Id.InfoShellHEATFS);
            _ShellShrapnel = FindViewById<ImageView>(Resource.Id.InfoShellShrapnel);
            _ShellHESH = FindViewById<ImageView>(Resource.Id.InfoShellHESH);
            _ShellATGM = FindViewById<ImageView>(Resource.Id.InfoShellATGM);
            _ShellSSM = FindViewById<ImageView>(Resource.Id.InfoShellSSM);
            _ShellHEATGRENADE = FindViewById<ImageView>(Resource.Id.InfoShellHEATGRENADE);
            _ShellHEGRENADE = FindViewById<ImageView>(Resource.Id.InfoShellHEGRENADE);
            _ShellHEVT = FindViewById<ImageView>(Resource.Id.InfoShellHEVT);
            _ShellSAM = FindViewById<ImageView>(Resource.Id.InfoShellSAM);



            _InfoTankTextBR = FindViewById<TextView>(Resource.Id.InfoTankTextBR);
            _InfoTankTextType = FindViewById<TextView>(Resource.Id.InfoTankTextType);
            _InfoTankTextCharacter = FindViewById<TextView>(Resource.Id.InfoTankTextPlaneCharacter);
            _InfoTankTextFirstRideYear = FindViewById<TextView>(Resource.Id.InfoTankTextFirstRideYear);
            _InfoTankTextPatchAdded = FindViewById<TextView>(Resource.Id.InfoTankTextPatchAdded);
            _InfoTankTextMaxSpeedAtRoad = FindViewById<TextView>(Resource.Id.InfoTankTextMaxSpeedAtRoad);
            _InfoTankTextMaxSpeedAtTerrain = FindViewById<TextView>(Resource.Id.InfoTankTextMaxSpeedAtTerrain);
            _InfoTankTextMaxReverseSpeed = FindViewById<TextView>(Resource.Id.InfoTankTextMaxReverseSpeed);
            _InfoTankTextAccelerationTo100 = FindViewById<TextView>(Resource.Id.InfoTankTextAccelerationTo100);
            _InfoTankTextTurnTurretTime = FindViewById<TextView>(Resource.Id.InfoTankTextTurnTurretTime);
            _InfoTankTextTurnHullTime = FindViewById<TextView>(Resource.Id.InfoTankTextTurnHullTime);
            _InfoTankTextEnginePower = FindViewById<TextView>(Resource.Id.InfoTankTextEnginePower);
            _InfoTankTextWeight = FindViewById<TextView>(Resource.Id.InfoTankTextWeight);
            _InfoTankTextPowerToWeightRatio = FindViewById<TextView>(Resource.Id.InfoTankTextPowerToWeightRatio);
            _InfoTankTextCannonName = FindViewById<TextView>(Resource.Id.InfoTankTextCannonName);
            _InfoTankTextPenetration = FindViewById<TextView>(Resource.Id.InfoTankTextPenetration);
            _InfoTankTextShellSpeed = FindViewById<TextView>(Resource.Id.InfoTankTextShellSpeed);
            _InfoTankTextReloadTime = FindViewById<TextView>(Resource.Id.InfoTankTextReloadTime);
            _InfoTankTextUpAimAngle = FindViewById<TextView>(Resource.Id.InfoTankTextUpAimAngle);
            _InfoTankTextDownAimAngle = FindViewById<TextView>(Resource.Id.InfoTankTextDownAimAngle);
            _InfoTankTextStabilizer = FindViewById<TextView>(Resource.Id.InfoTankTextStabilizer);
            _InfoTankTextAAMachineGunExist = FindViewById<TextView>(Resource.Id.InfoTankTextAAMachineGunExist);
            _InfoTankTextReducedArmorFrontTurret = FindViewById<TextView>(Resource.Id.InfoTankTextReducedArmorFrontTurret);
            _InfoTankTextReducedArmorTopSheet = FindViewById<TextView>(Resource.Id.InfoTankTextReducedArmorTopSheet);
            _InfoTankTextReducedArmorBottomSheet = FindViewById<TextView>(Resource.Id.InfoTankTextReducedBottomTopSheet);

            _InfoTankLabelTextBR = FindViewById<TextView>(Resource.Id.InfoTankLabelTextBR);
            _InfoTankLabelTextType = FindViewById<TextView>(Resource.Id.InfoTankLabelTextType);
            _InfoTankLabelTextCharacter = FindViewById<TextView>(Resource.Id.InfoTankLabelTextPlaneCharacter);
            _InfoTankLabelTextFirstRideYear = FindViewById<TextView>(Resource.Id.InfoTankLabelTextFirstRideYear);
            _InfoTankLabelTextPatchAdded = FindViewById<TextView>(Resource.Id.InfoTankLabelTextTankPatchAdded);
            _InfoTankLabelTextMaxSpeedAtRoad = FindViewById<TextView>(Resource.Id.InfoTankLabelTextMaxSpeedAtRoad);
            _InfoTankLabelTextMaxSpeedAtTerrain = FindViewById<TextView>(Resource.Id.InfoTankLabelTextMaxSpeedAtTerrain);
            _InfoTankLabelTextMaxReverseSpeed = FindViewById<TextView>(Resource.Id.InfoTankLabelTextMaxReverseSpeed);
            _InfoTankLabelTextAccelerationTo100 = FindViewById<TextView>(Resource.Id.InfoTankLabelTextAccelerationTo100);
            _InfoTankLabelTextTurnTurretTime = FindViewById<TextView>(Resource.Id.InfoTankLabelTextTurnTurretTime);
            _InfoTankLabelTextTurnHullTime = FindViewById<TextView>(Resource.Id.InfoTankLabelTextTurnHullTime);
            _InfoTankLabelTextEnginePower = FindViewById<TextView>(Resource.Id.InfoTankLabelTextEnginePower);
            _InfoTankLabelTextWeight = FindViewById<TextView>(Resource.Id.InfoTankLabelTextWeight);
            _InfoTankLabelTextPowerToWeightRatio = FindViewById<TextView>(Resource.Id.InfoTankLabelTextPowerToWeightRatio);
            _InfoTankLabelTextPenetration = FindViewById<TextView>(Resource.Id.InfoTankLabelTextPenetration);
            _InfoTankLabelTextShellSpeed = FindViewById<TextView>(Resource.Id.InfoTankLabelTextShellSpeed);
            _InfoTankLabelTextReloadTime = FindViewById<TextView>(Resource.Id.InfoTankLabelTextReloadTime);
            _InfoTankLabelTextUpAimAngle = FindViewById<TextView>(Resource.Id.InfoTankLabelTextUpAimAngle);
            _InfoTankLabelTextDownAimAngle = FindViewById<TextView>(Resource.Id.InfoTankLabelTextDownAimAngle);
            _InfoTankLabelTextStabilizer = FindViewById<TextView>(Resource.Id.InfoTankLabelTextStabilizer);
            _InfoTankLabelTextAAMachineGunExist = FindViewById<TextView>(Resource.Id.InfoTankLabelTextAAMachineGunExist);
            _InfoTankLabelTextReducedArmorFrontTurret = FindViewById<TextView>(Resource.Id.InfoTankLabelTextReducedArmorFrontTurret);
            _InfoTankLabelTextReducedArmorTopSheet = FindViewById<TextView>(Resource.Id.InfoTankLabelTextReducedArmorTopSheet);
            _InfoTankLabelTextReducedArmorBottomSheet = FindViewById<TextView>(Resource.Id.InfoTankLabelTextReducedArmorBottomSheet);
            _InfoTankShellType = FindViewById<TextView>(Resource.Id.InfoTankShellType);
            #endregion

            #region Изменения шрифта 

            _InfoTankLabelTextBR.Typeface = font;
            _InfoTankLabelTextType.Typeface = font;
            _InfoTankLabelTextCharacter.Typeface = font;
            _InfoTankLabelTextFirstRideYear.Typeface = font;
            _InfoTankLabelTextPatchAdded.Typeface = font;
            _InfoTankLabelTextMaxSpeedAtRoad.Typeface = font;
            _InfoTankLabelTextMaxSpeedAtTerrain.Typeface = font;
            _InfoTankLabelTextMaxReverseSpeed.Typeface = font;
            _InfoTankLabelTextAccelerationTo100.Typeface = font;
            _InfoTankLabelTextTurnTurretTime.Typeface = font;
            _InfoTankLabelTextTurnHullTime.Typeface = font;
            _InfoTankLabelTextEnginePower.Typeface = font;
            _InfoTankLabelTextWeight.Typeface = font;
            _InfoTankLabelTextPowerToWeightRatio.Typeface = font;
            _InfoTankLabelTextPenetration.Typeface = font;
            _InfoTankLabelTextShellSpeed.Typeface = font;
            _InfoTankLabelTextReloadTime.Typeface = font;
            _InfoTankLabelTextUpAimAngle.Typeface = font;
            _InfoTankLabelTextDownAimAngle.Typeface = font;
            _InfoTankLabelTextStabilizer.Typeface = font;
            _InfoTankLabelTextAAMachineGunExist.Typeface = font;
            _InfoTankLabelTextReducedArmorFrontTurret.Typeface = font;
            _InfoTankLabelTextReducedArmorTopSheet.Typeface = font;
            _InfoTankLabelTextReducedArmorBottomSheet.Typeface = font;
            _InfoTankShellType.Typeface = font;

            #endregion

            #region Изменения цвета текста всех TextView


            _InfoTankLabelTextBR.SetTextColor(Color.Black);
            _InfoTankLabelTextType.SetTextColor(Color.Black);
            _InfoTankLabelTextCharacter.SetTextColor(Color.Black);
            _InfoTankLabelTextFirstRideYear.SetTextColor(Color.Black);
            _InfoTankLabelTextPatchAdded.SetTextColor(Color.Black);
            _InfoTankLabelTextMaxSpeedAtRoad.SetTextColor(Color.Black);
            _InfoTankLabelTextMaxSpeedAtTerrain.SetTextColor(Color.Black);
            _InfoTankLabelTextMaxReverseSpeed.SetTextColor(Color.Black);
            _InfoTankLabelTextAccelerationTo100.SetTextColor(Color.Black);
            _InfoTankLabelTextTurnTurretTime.SetTextColor(Color.Black);
            _InfoTankLabelTextTurnHullTime.SetTextColor(Color.Black);
            _InfoTankLabelTextEnginePower.SetTextColor(Color.Black);
            _InfoTankLabelTextWeight.SetTextColor(Color.Black);
            _InfoTankLabelTextPowerToWeightRatio.SetTextColor(Color.Black);
            _InfoTankLabelTextPenetration.SetTextColor(Color.Black);
            _InfoTankLabelTextShellSpeed.SetTextColor(Color.Black);
            _InfoTankLabelTextReloadTime.SetTextColor(Color.Black);
            _InfoTankLabelTextUpAimAngle.SetTextColor(Color.Black);
            _InfoTankLabelTextDownAimAngle.SetTextColor(Color.Black);
            _InfoTankLabelTextStabilizer.SetTextColor(Color.Black);
            _InfoTankLabelTextAAMachineGunExist.SetTextColor(Color.Black);
            _InfoTankLabelTextReducedArmorFrontTurret.SetTextColor(Color.Black);
            _InfoTankLabelTextReducedArmorTopSheet.SetTextColor(Color.Black);
            _InfoTankLabelTextReducedArmorBottomSheet.SetTextColor(Color.Black);

            _InfoTankTextBR.SetTextColor(Color.Black);
            _InfoTankTextType.SetTextColor(Color.Black);
            _InfoTankTextCharacter.SetTextColor(Color.Black);
            _InfoTankTextFirstRideYear.SetTextColor(Color.Black);
            _InfoTankTextPatchAdded.SetTextColor(Color.Black);
            _InfoTankTextMaxSpeedAtRoad.SetTextColor(Color.Black);
            _InfoTankTextMaxSpeedAtTerrain.SetTextColor(Color.Black);
            _InfoTankTextMaxReverseSpeed.SetTextColor(Color.Black);
            _InfoTankTextAccelerationTo100.SetTextColor(Color.Black);
            _InfoTankTextTurnTurretTime.SetTextColor(Color.Black);
            _InfoTankTextTurnHullTime.SetTextColor(Color.Black);
            _InfoTankTextEnginePower.SetTextColor(Color.Black);
            _InfoTankTextWeight.SetTextColor(Color.Black);
            _InfoTankTextPowerToWeightRatio.SetTextColor(Color.Black);
            _InfoTankTextCannonName.SetTextColor(Color.Black);
            _InfoTankTextPenetration.SetTextColor(Color.Black);
            _InfoTankTextShellSpeed.SetTextColor(Color.Black);
            _InfoTankTextReloadTime.SetTextColor(Color.Black);
            _InfoTankTextUpAimAngle.SetTextColor(Color.Black);
            _InfoTankTextDownAimAngle.SetTextColor(Color.Black);
            _InfoTankTextStabilizer.SetTextColor(Color.Black);
            _InfoTankTextAAMachineGunExist.SetTextColor(Color.Black);
            _InfoTankTextReducedArmorFrontTurret.SetTextColor(Color.Black);
            _InfoTankTextReducedArmorTopSheet.SetTextColor(Color.Black);
            _InfoTankTextReducedArmorBottomSheet.SetTextColor(Color.Black);
            _InfoTankShellType.SetTextColor(Color.Black);

            #endregion

            nations = NationCollection.GetNation();
            AdapterNation = new NationAdapter(this, nations);
            _InfoSpinnerNation.Adapter = AdapterNation;
            _InfoSpinnerNation.SetSelection(5);  //Автовыбор
            selectedNation = 5;   //Автовыбор

            ranks = RankCollection.GetRank();
            AdapterRank = new RankAdapter(this, ranks);
            _InfoSpinnerRank.Adapter = AdapterRank;
            _InfoSpinnerRank.SetSelection(7);   //Автовыбор
            selectedRank = 7;   //Автовыбор

            potentialTask = TankTaskCollection.GetTankTask();
            PotentialAdapterTask = new TaskAdapter(this, potentialTask);
            _InfoSpinnerPotentialEnemyTank.Adapter = PotentialAdapterTask;
            _InfoSpinnerPotentialEnemyTank.SetSelection(0);  //Автовыбор
            SelectedPotentialTask = 0; //Автовыбор

            _InfoSpinnerTank.SetSelection(1);
            //Объявление коллекции наций, рангов и адаптеров

            _InfoSpinnerNation.ItemSelected += _InfoSpinnerNation_ItemSelected;
            _InfoSpinnerRank.ItemSelected += _InfoSpinnerRank_ItemSelected;
            _InfoSpinnerTank.ItemSelected += _InfoSpinnerTank_ItemSelected;
            _InfoSpinnerPotentialEnemyTank.ItemSelected += _InfoSpinnerPotentialEnemyTank_ItemSelected;    //**//


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


        private void _InfoSpinnerPotentialEnemyTank_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            SelectedPotentialTask = potentialTask[e.Position].Id;
            TaskSelector();

        }

        private void TaskSelector()
        {
            if (SelectedPotentialTask == 1)
            {
                List<Tank> tanksAll = TankCollection.GetTank();
                double step = 1.0;
                var tankvar = from p in tanksAll
                              where p.BR <= selectedTankBR + step && p.BR >= selectedTankBR - step && p.NationId != selectedNation
                              orderby p.MaxSpeedAtTerrain descending
                              select p;
                tankspotential = tankvar.ToList<Tank>();
                AdapterListView = new ListViewInfoTankAdapter(this, tankspotential);
                _InfoListView.Adapter = AdapterListView;

            }
            if (SelectedPotentialTask == 2)
            {
                List<Tank> tanksAll = TankCollection.GetTank();
                double step = 1.0;
                var tankvar = from p in tanksAll
                              where p.BR <= selectedTankBR + step && p.BR >= selectedTankBR - step && p.NationId != selectedNation
                              orderby p.AccelerationTo100 ascending
                              select p;
                tankspotential = tankvar.ToList<Tank>();
                AdapterListView = new ListViewInfoTankAdapter(this, tankspotential);
                _InfoListView.Adapter = AdapterListView;

            }

            if (SelectedPotentialTask == 3)
            {
                List<Tank> tanksAll = TankCollection.GetTank();
                double step = 1.0;
                var tankvar = from p in tanksAll
                              where p.BR <= selectedTankBR + step && p.BR >= selectedTankBR - step && p.NationId != selectedNation
                              orderby p.PowerToWeightRatio descending
                              select p;
                tankspotential = tankvar.ToList<Tank>();
                AdapterListView = new ListViewInfoTankAdapter(this, tankspotential);
                _InfoListView.Adapter = AdapterListView;

            }

            if (SelectedPotentialTask == 4)
            {
                List<Tank> tanksAll = TankCollection.GetTank();
                double step = 1.0;
                var tankvar = from p in tanksAll
                              where p.BR <= selectedTankBR + step && p.BR >= selectedTankBR - step && p.NationId != selectedNation
                              orderby p.Penetration descending
                              select p;
                tankspotential = tankvar.ToList<Tank>();
                AdapterListView = new ListViewInfoTankAdapter(this, tankspotential);
                _InfoListView.Adapter = AdapterListView;

            }

            if (SelectedPotentialTask == 5)
            {
                List<Tank> tanksAll = TankCollection.GetTank();
                double step = 1.0;
                var tankvar = from p in tanksAll
                              where p.BR <= selectedTankBR + step && p.BR >= selectedTankBR - step && p.NationId != selectedNation
                              orderby p.ReloadTime ascending
                              select p;
                tankspotential = tankvar.ToList<Tank>();
                AdapterListView = new ListViewInfoTankAdapter(this, tankspotential);
                _InfoListView.Adapter = AdapterListView;

            }

            if (SelectedPotentialTask == 6)
            {
                List<Tank> tanksAll = TankCollection.GetTank();
                double step = 1.0;
                var tankvar = from p in tanksAll
                              where p.BR <= selectedTankBR + step && p.BR >= selectedTankBR - step && p.NationId != selectedNation
                              orderby p.ReducedArmorFrontTurret descending
                              select p;
                tankspotential = tankvar.ToList<Tank>();
                AdapterListView = new ListViewInfoTankAdapter(this, tankspotential);
                _InfoListView.Adapter = AdapterListView;

            }

            if (SelectedPotentialTask == 7)
            {
                List<Tank> tanksAll = TankCollection.GetTank();
                double step = 1.0;
                var tankvar = from p in tanksAll
                              where p.BR <= selectedTankBR + step && p.BR >= selectedTankBR - step && p.NationId != selectedNation
                              orderby p.ReducedArmorTopSheet descending
                              select p;
                tankspotential = tankvar.ToList<Tank>();
                AdapterListView = new ListViewInfoTankAdapter(this, tankspotential);
                _InfoListView.Adapter = AdapterListView;

            }

        }

        private void _InfoSpinnerNation_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedNation = nations[e.Position].Id;

            if (selectedNation == 100 && selectedRank == 100)
            {
                tanks = TankCollection.GetTank();
                AdapterTank = new TankAdapter(this, tanks);
                _InfoSpinnerTank.Adapter = AdapterTank;
            }
            else
            if (selectedNation == 100)
            {
                List<Tank> tanksAll = TankCollection.GetTank();
                var tankvar = from p in tanksAll
                              where p.RankId == selectedRank
                              select p;
                tanks = tankvar.ToList<Tank>();
                AdapterTank = new TankAdapter(this, tanks);
                _InfoSpinnerTank.Adapter = AdapterTank;
            }
            else
            if (selectedRank == 100)
            {
                List<Tank> tanksAll = TankCollection.GetTank();
                var tankvar = from p in tanksAll
                              where p.NationId == selectedNation
                              select p;
                tanks = tankvar.ToList<Tank>();
                AdapterTank = new TankAdapter(this, tanks);
                _InfoSpinnerTank.Adapter = AdapterTank;
            }
            else
            {

                tanks = TankSelector(selectedNation, selectedRank);
                AdapterTank = new TankAdapter(this, tanks);
                _InfoSpinnerTank.Adapter = AdapterTank;
            }
        }


        private void _InfoSpinnerRank_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedRank = ranks[e.Position].Id;
            if (selectedNation == 100 && selectedRank == 100)
            {
                tanks = TankCollection.GetTank();
                AdapterTank = new TankAdapter(this, tanks);
                _InfoSpinnerTank.Adapter = AdapterTank;
            }
            else
    if (selectedNation == 100)
            {
                List<Tank> tanksAll = TankCollection.GetTank();
                var tankvar = from p in tanksAll
                              where p.RankId == selectedRank
                              select p;
                tanks = tankvar.ToList<Tank>();
                AdapterTank = new TankAdapter(this, tanks);
                _InfoSpinnerTank.Adapter = AdapterTank;
            }
            else
    if (selectedRank == 100)
            {
                List<Tank> tanksAll = TankCollection.GetTank();
                var tankvar = from p in tanksAll
                              where p.NationId == selectedNation
                              select p;
                tanks = tankvar.ToList<Tank>();
                AdapterTank = new TankAdapter(this, tanks);
                _InfoSpinnerTank.Adapter = AdapterTank;
            }
            else
            {

                tanks = TankSelector(selectedNation, selectedRank);
                AdapterTank = new TankAdapter(this, tanks);
                _InfoSpinnerTank.Adapter = AdapterTank;
            }
        }

        private void _InfoSpinnerTank_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            selectedTankBR = tanks[e.Position].BR;
            textAAMachineGunExist = tanks[e.Position].AAMachineGunExist;
            textStabilizer = tanks[e.Position].Stabilizer;
            _InfoImage.SetImageResource(tanks[e.Position].Image);
            _InfoFlag.SetImageResource(tanks[e.Position].FlagImage);
            _InfoTankTextBR.SetText(tanks[e.Position].BR.ToString("0.0#"), TextView.BufferType.Normal);
            _InfoTankTextType.SetText(tanks[e.Position].Type, TextView.BufferType.Normal);
            _InfoTankTextCharacter.SetText(tanks[e.Position].Character, TextView.BufferType.Normal);
            _InfoTankTextFirstRideYear.SetText(tanks[e.Position].FirstRideYear.ToString() + context.Resources.GetString(Resource.String.AbbrYear), TextView.BufferType.Normal);
            _InfoTankTextPatchAdded.SetText(tanks[e.Position].PatchAdded.ToString(), TextView.BufferType.Normal);
            _InfoTankTextAccelerationTo100.SetText(tanks[e.Position].AccelerationTo100.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            _InfoTankTextTurnTurretTime.SetText(tanks[e.Position].TurnTurretTime.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            _InfoTankTextTurnHullTime.SetText(tanks[e.Position].TurnHullTime.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            _InfoTankTextEnginePower.SetText(tanks[e.Position].EnginePower.ToString() + context.Resources.GetString(Resource.String.AbbrH_P), TextView.BufferType.Normal);
            _InfoTankTextCannonName.SetText(tanks[e.Position].CannonName, TextView.BufferType.Normal);
            _InfoTankTextReloadTime.SetText(tanks[e.Position].ReloadTime.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            _InfoTankTextUpAimAngle.SetText(tanks[e.Position].UpAimAngle.ToString() + "°", TextView.BufferType.Normal);
            _InfoTankTextDownAimAngle.SetText(tanks[e.Position].DownAimAngle.ToString() + "°", TextView.BufferType.Normal);
            _InfoTankTextPowerToWeightRatio.SetText(tanks[e.Position].PowerToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrH_P_T), TextView.BufferType.Normal);


            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            ISharedPreferencesEditor editor = prefs.Edit();
            var switchchecked = prefs.GetBoolean("key_kmhtomph", false);
            if (switchchecked)
            {
                _InfoTankLabelTextAccelerationTo100.SetText(context.Resources.GetString(Resource.String.TankAccTo100Feet), TextView.BufferType.Normal);

                var maxSpeedAtRoad = tanks[e.Position].MaxSpeedAtRoad * 0.621371192;
                var maxSpeedAtTerrain = tanks[e.Position].MaxSpeedAtTerrain * 0.621371192;
                var maxReverseSpeed = tanks[e.Position].MaxReverseSpeed * 0.621371192;
                var weight = tanks[e.Position].Weight * 1.10231131;
                var penetration = tanks[e.Position].Penetration * 0.039370;
                var shellSpeed = tanks[e.Position].ShellSpeed * 3.28084;
                var reducedArmorFrontTurret = tanks[e.Position].ReducedArmorFrontTurret * 0.039370;
                var reducedArmorTopSheet = tanks[e.Position].ReducedArmorTopSheet * 0.039370;
                var reducedArmorBottomSheet = tanks[e.Position].ReducedArmorBottomSheet * 0.039370;
                maxSpeedAtRoad = Math.Round(maxSpeedAtRoad, 0);
                maxSpeedAtTerrain = Math.Round(maxSpeedAtTerrain, 0);
                maxReverseSpeed = Math.Round(maxReverseSpeed, 0);
                weight = Math.Round(weight, 1);
                penetration = Math.Round(penetration, 2);
                shellSpeed = Math.Round(shellSpeed, 0);
                reducedArmorFrontTurret = Math.Round(reducedArmorFrontTurret, 2);
                reducedArmorTopSheet = Math.Round(reducedArmorTopSheet, 2);
                reducedArmorBottomSheet = Math.Round(reducedArmorBottomSheet, 2);

                _InfoTankTextMaxSpeedAtRoad.SetText(maxSpeedAtRoad + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _InfoTankTextMaxSpeedAtTerrain.SetText(maxSpeedAtTerrain + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _InfoTankTextMaxReverseSpeed.SetText(maxReverseSpeed + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _InfoTankTextWeight.SetText(weight + context.Resources.GetString(Resource.String.AbbrST), TextView.BufferType.Normal);
                _InfoTankTextPenetration.SetText(penetration + context.Resources.GetString(Resource.String.AbbrINCH), TextView.BufferType.Normal);
                _InfoTankTextShellSpeed.SetText(shellSpeed + context.Resources.GetString(Resource.String.AbbrFEET_S), TextView.BufferType.Normal);
                _InfoTankTextReducedArmorFrontTurret.SetText(reducedArmorFrontTurret + context.Resources.GetString(Resource.String.AbbrINCH), TextView.BufferType.Normal);
                _InfoTankTextReducedArmorTopSheet.SetText(reducedArmorTopSheet + context.Resources.GetString(Resource.String.AbbrINCH), TextView.BufferType.Normal);
                _InfoTankTextReducedArmorBottomSheet.SetText(reducedArmorBottomSheet + context.Resources.GetString(Resource.String.AbbrINCH), TextView.BufferType.Normal);
            }
            else
            {
                _InfoTankLabelTextAccelerationTo100.SetText(context.Resources.GetString(Resource.String.TankAccTo100), TextView.BufferType.Normal);

                _InfoTankTextMaxSpeedAtRoad.SetText(tanks[e.Position].MaxSpeedAtRoad.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _InfoTankTextMaxSpeedAtTerrain.SetText(tanks[e.Position].MaxSpeedAtTerrain.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _InfoTankTextMaxReverseSpeed.SetText(tanks[e.Position].MaxReverseSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _InfoTankTextWeight.SetText(tanks[e.Position].Weight.ToString() + context.Resources.GetString(Resource.String.AbbrT), TextView.BufferType.Normal);
                _InfoTankTextPenetration.SetText(tanks[e.Position].Penetration.ToString() + context.Resources.GetString(Resource.String.AbbrMM), TextView.BufferType.Normal);
                _InfoTankTextShellSpeed.SetText(tanks[e.Position].ShellSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrM_S), TextView.BufferType.Normal);
                _InfoTankTextReducedArmorFrontTurret.SetText(tanks[e.Position].ReducedArmorFrontTurret.ToString() + context.Resources.GetString(Resource.String.AbbrMM), TextView.BufferType.Normal);
                _InfoTankTextReducedArmorTopSheet.SetText(tanks[e.Position].ReducedArmorTopSheet.ToString() + context.Resources.GetString(Resource.String.AbbrMM), TextView.BufferType.Normal);
                _InfoTankTextReducedArmorBottomSheet.SetText(tanks[e.Position].ReducedArmorBottomSheet.ToString() + context.Resources.GetString(Resource.String.AbbrMM), TextView.BufferType.Normal);
            }

            ShellAP = tanks[e.Position].ShellAP;
            ShellAPHE = tanks[e.Position].ShellAPHE;
            ShellHE = tanks[e.Position].ShellHE;
            ShellAPCR = tanks[e.Position].ShellAPCR;
            ShellAPDS = tanks[e.Position].ShellAPDS;
            ShellAPFSDS = tanks[e.Position].ShellAPFSDS;
            ShellHEAT = tanks[e.Position].ShellHEAT;
            ShellHEATFS = tanks[e.Position].ShellHEATFS;
            ShellShrapnel = tanks[e.Position].ShellShrapnel;
            ShellHESH = tanks[e.Position].ShellHESH;
            ShellATGM = tanks[e.Position].ShellATGM;
            ShellSSM = tanks[e.Position].ShellSSM;
            ShellHEATGRENADE = tanks[e.Position].ShellHEATGRENADE;
            ShellHEGRENADE = tanks[e.Position].ShellHEGRENADE;
            ShellHEVT = tanks[e.Position].ShellHEVT;
            ShellSAM = tanks[e.Position].ShellSTA;
            TankShellShower();
            TaskSelector();


            if (textAAMachineGunExist == true)
            {
                _InfoTankTextAAMachineGunExist.SetText(context.Resources.GetString(Resource.String.TankYes), TextView.BufferType.Normal);
            }
            else
            if (textAAMachineGunExist == false)
            {
                _InfoTankTextAAMachineGunExist.SetText(context.Resources.GetString(Resource.String.TankNo), TextView.BufferType.Normal);
            }
            if (textStabilizer == true)
            {
                _InfoTankTextStabilizer.SetText(context.Resources.GetString(Resource.String.TankYes), TextView.BufferType.Normal);
            }
            else
            if (textStabilizer == false)
            {
                _InfoTankTextStabilizer.SetText(context.Resources.GetString(Resource.String.TankNo), TextView.BufferType.Normal);
            }

        }

        private void TankShellShower()
        {

            if (ShellAP == true)
            {
                _ShellAP.SetImageResource(Resource.Drawable._ShellAP);
            }
            else
            {
                _ShellAP.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (ShellAPHE == true)
            {
                _ShellAPHE.SetImageResource(Resource.Drawable._ShellAPHE);
            }
            else
            {
                _ShellAPHE.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (ShellHE == true)
            {
                _ShellHE.SetImageResource(Resource.Drawable._ShellHE);
            }
            else
            {
                _ShellHE.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (ShellAPCR == true)
            {
                _ShellAPCR.SetImageResource(Resource.Drawable._ShellAPCR);
            }
            else
            {
                _ShellAPCR.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (ShellAPDS == true)
            {
                _ShellAPDS.SetImageResource(Resource.Drawable._ShellAPDS);
            }
            else
            {
                _ShellAPDS.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (ShellAPFSDS == true)
            {
                _ShellAPFSDS.SetImageResource(Resource.Drawable._ShellAPFSDS);
            }
            else
            {
                _ShellAPFSDS.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (ShellHEAT == true)
            {
                _ShellHEAT.SetImageResource(Resource.Drawable._ShellHEAT);
            }
            else
            {
                _ShellHEAT.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (ShellHEATFS == true)
            {
                _ShellHEATFS.SetImageResource(Resource.Drawable._ShellHEATFS);
            }
            else
            {
                _ShellHEATFS.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (ShellShrapnel == true)
            {
                _ShellShrapnel.SetImageResource(Resource.Drawable._ShellShrapnel);
            }
            else
            {
                _ShellShrapnel.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (ShellHESH == true)
            {
                _ShellHESH.SetImageResource(Resource.Drawable._ShellHESH);
            }
            else
            {
                _ShellHESH.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (ShellATGM == true)
            {
                _ShellATGM.SetImageResource(Resource.Drawable._ShellATGM);
            }
            else
            {
                _ShellATGM.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (ShellSSM == true)
            {
                _ShellSSM.SetImageResource(Resource.Drawable._ShellSSM);
            }
            else
            {
                _ShellSSM.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (ShellHEATGRENADE == true)
            {
                _ShellHEATGRENADE.SetImageResource(Resource.Drawable._ShellHEATGRENADE);
            }
            else
            {
                _ShellHEATGRENADE.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (ShellHEGRENADE == true)
            {
                _ShellHEGRENADE.SetImageResource(Resource.Drawable._ShellHEGRENADE);
            }
            else
            {
                _ShellHEGRENADE.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (ShellHEVT == true)
            {
                _ShellHEVT.SetImageResource(Resource.Drawable._ShellHEVT);
            }
            else
            {
                _ShellHEVT.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (ShellSAM == true)
            {
                _ShellSAM.SetImageResource(Resource.Drawable._ShellSAM);
            }
            else
            {
                _ShellSAM.SetImageResource(Resource.Drawable._handingTransparent);
            }



        }

        private List<Tank> TankSelector(int selectedNation, int selectedRank)
        {

            this.selectedNation = selectedNation;
            this.selectedRank = selectedRank;

            List<Tank> tanksAll = TankCollection.GetTank();
            var tankvar = from p in tanksAll
                          where p.NationId == selectedNation
                          where p.RankId == selectedRank
                          select p;
            return tankvar.ToList<Tank>();
        }


    }
}