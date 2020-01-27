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
    class InfoShip : AppCompatActivity
    {
        Spinner _InfoSpinnerNation;
        Spinner _InfoSpinnerShip;
        Spinner _InfoSpinnerRank;
        ListView _InfoListView;
        Spinner _InfoSpinnerPotentialEnemyShip;
        TaskAdapter PotentialAdapterTaskShip;
        //Объявление  спиннеров и скролов с XAML

        #region Объявление всех Textview
        Context context;
        ImageView _InfoImage;
        ImageView _InfoFlag;
        ImageView _InfoHandingRocket;
        ImageView _InfoHandlingDepthCharge;
        ImageView _InfoHandlingTorpedo;
        ImageView _InfoHandingMine;

        ImageView _InfoMCShellAP;
        ImageView _InfoMCShellAPHE;
        ImageView _InfoMCShellAPCR;
        ImageView _InfoMCShellHE;
        ImageView _InfoMCShellHEVT;
        ImageView _InfoMCShellHEDF;
        ImageView _InfoMCShellFOG;
        ImageView _InfoMCShellShrapnel;
        ImageView _InfoAUShellShrapnel;
        ImageView _InfoAUShellAP;
        ImageView _InfoAUShellAPHE;
        ImageView _InfoAUShellAPCR;
        ImageView _InfoAUShellHE;
        ImageView _InfoAUShellHEVT;
        ImageView _InfoAUShellHEDF;
        ImageView _InfoAUShellFOG;
        ImageView _InfoAAAShellAP;
        ImageView _InfoAAAShellAPHE;
        ImageView _InfoAAAShellAPCR;
        ImageView _InfoAAAShellHE;
        ImageView _InfoAAAShellHEVT;
        ImageView _InfoAAAShellHEDF;
        ImageView _InfoAAAShellFOG;

        TextView _InfoShipTextFirstLaunch;
        TextView _InfoShipTextPatchAdded;
        TextView _InfoShipTextType;
        TextView _InfoShipTextCharacter;
        TextView _InfoShipTextBR;

        TextView _InfoShipTextMainCaliberName;
        TextView _InfoShipTextMainCaliberReload;
        TextView _InfoShipTextMainCaliberTNT;
        TextView _InfoShipTextAuxiliaryCaliberName;
        TextView _InfoShipTextAuxiliaryCaliberReload;
        TextView _InfoShipTextAAACaliberName;
        TextView _InfoShipTextAAACaliberReload;
        TextView _InfoShipTextTorpedoName;
        TextView _InfoShipTextTorpedoItem;
        TextView _InfoShipTextTorpedoMaxSpeed;
        TextView _InfoShipTextTorpedoTNT;
        TextView _InfoShipTextMaxSpeed;
        TextView _InfoShipTextReverseSpeed;
        TextView _InfoShipTextAcceleration;
        TextView _InfoShipTextBrakingTime;
        TextView _InfoShipTextTurn360;
        TextView _InfoShipTextDisplacement;
        TextView _InfoShipTextCrewCount;

        TextView _InfoShipLabelTextMainCaliberReload;
        TextView _InfoShipLabelTextMainCaliberTNT;
        TextView _InfoShipLabelTextAuxiliaryCaliberReload;
        TextView _InfoShipLabelTextAAACaliberReload;
        TextView _InfoShipLabelTextTorpedoItem;
        TextView _InfoShipLabelTextTorpedoMaxSpeed;
        TextView _InfoShipLabelTextTorpedoTNT;
        TextView _InfoShipLabelTextMaxSpeed;
        TextView _InfoShipLabelTextReverseSpeed;
        TextView _InfoShipLabelTextAcceleration;
        TextView _InfoShipLabelTextBrakingTime;
        TextView _InfoShipLabelTextTurn360;
        TextView _InfoShipLabelTextDisplacement;
        TextView _InfoShipLabelTextCrewCount;
        TextView _InfoShipLabelTextMCShellType;
        TextView _InfoShipLabelTextAUShellType;
        TextView _InfoShipLabelTextAAAShellType;
        TextView _InfoShipLabelTextAdditional;



        TextView _InfoShipLabelTextFirstLaunch ;
        TextView _InfoShipLabelTextPatchAdded ;
        TextView _InfoShipLabelTextType ;
        TextView _InfoShipLabelTextCharacter ;
        TextView _InfoShipLabelTextBR ; 
        #endregion

        List<Ship> ships;
        List<Ship> shipspotential;
        ShipAdapter AdapterShip;
        List<Nation> nations;
        NationAdapter AdapterNation;
        List<Rank> ranks;
        public List<Task> potentialTask;
        RankAdapter AdapterRank;
        ListViewInfoShipAdapter AdapterListView;


        private int selectedNation;
        private int selectedRank;
        private double selectedShipBR;
        public static int SelectedPotentialTaskShip;
        private bool HandingRocket;
        private bool HandlingDepthCharge;
        private bool HandlingTorpedo;
        private bool HandingMine;

        private bool MCShellAP;
        private bool MCShellAPHE;
        private bool MCShellAPCR;
        private bool MCShellHE;
        private bool MCShellHEVT;
        private bool MCShellHEDF;
        private bool MCShellFOG;
        private bool MCShellShrapnel;
        private bool AUShellShrapnel;
        private bool AUShellAP;
        private bool AUShellAPHE;
        private bool AUShellAPCR;
        private bool AUShellHE;
        private bool AUShellHEVT;
        private bool AUShellHEDF;
        private bool AUShellFOG;
        private bool AAAShellAP;
        private bool AAAShellAPHE;
        private bool AAAShellAPCR;
        private bool AAAShellHE;
        private bool AAAShellHEVT;
        private bool AAAShellHEDF;
        private bool AAAShellFOG;

        // Объявление адаптеров, коллекций и переменных      


        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\
        DrawerLayout drawerLayout;

        protected InfoShip(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public InfoShip()
        {
        }

        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\
    



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.InfoShip);
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
            var adView = FindViewById<AdView>(Resource.Id.adViewInfoShip);
                 var adRequest = new AdRequest.Builder().Build();
                adView.LoadAd(adRequest);
            //var requestbuilder = new AdRequest.Builder().AddTestDevice("D0BE22F1A4BE27C7470F95A699568FE2");
            //adView.LoadAd(requestbuilder.Build());
            //шрифт
            var font = Typeface.CreateFromAsset(Assets, "dinfont.ttf");
            _InfoSpinnerNation = FindViewById<Spinner>(Resource.Id.InfoSpinnerNationS);
            _InfoSpinnerRank = FindViewById<Spinner>(Resource.Id.InfoSpinnerRankS);
            _InfoSpinnerShip = FindViewById<Spinner>(Resource.Id.InfoSpinnerShip);
            _InfoListView = FindViewById<ListView>(Resource.Id.listViewS);
            _InfoSpinnerPotentialEnemyShip = FindViewById<Spinner>(Resource.Id.InfoSpinnerPotentialEnemyShip);
            //Привязка спиннеров к шарп коду

            #region Привязка TextView к коду
            _InfoImage = FindViewById<ImageView>(Resource.Id.InfoImageS);
            _InfoFlag = FindViewById<ImageView>(Resource.Id.InfoFlagS);

            _InfoHandingRocket = FindViewById<ImageView>(Resource.Id.InfoShipHandingRocket);
            _InfoHandlingDepthCharge = FindViewById<ImageView>(Resource.Id.InfoShipHandingDepthCharge);
            _InfoHandlingTorpedo = FindViewById<ImageView>(Resource.Id.InfoShipHandingTorpedo);
            _InfoHandingMine = FindViewById<ImageView>(Resource.Id.InfoShipHandingMine);

            _InfoMCShellAP = FindViewById<ImageView>(Resource.Id.InfoShipMCShellAP);
            _InfoMCShellAPHE = FindViewById<ImageView>(Resource.Id.InfoShipMCShellAPHE);
            _InfoMCShellAPCR = FindViewById<ImageView>(Resource.Id.InfoShipMCShellAPCR);
            _InfoMCShellHE = FindViewById<ImageView>(Resource.Id.InfoShipMCShellHE);
            _InfoMCShellHEVT = FindViewById<ImageView>(Resource.Id.InfoShipMCShellHEVT);
            _InfoMCShellHEDF = FindViewById<ImageView>(Resource.Id.InfoShipMCShellHEDF);
            _InfoMCShellFOG = FindViewById<ImageView>(Resource.Id.InfoShipMCShellFOG);
            _InfoMCShellShrapnel = FindViewById<ImageView>(Resource.Id.InfoShipMCShellShrapnel);
            _InfoAUShellShrapnel = FindViewById<ImageView>(Resource.Id.InfoShipAUShellShrapnel);
            _InfoAUShellAP = FindViewById<ImageView>(Resource.Id.InfoShipAUShellAP);
            _InfoAUShellAPHE = FindViewById<ImageView>(Resource.Id.InfoShipAUShellAPHE);
            _InfoAUShellAPCR = FindViewById<ImageView>(Resource.Id.InfoShipAUShellAPCR);
            _InfoAUShellHE = FindViewById<ImageView>(Resource.Id.InfoShipAUShellHE);
            _InfoAUShellHEVT = FindViewById<ImageView>(Resource.Id.InfoShipAUShellHEVT);
            _InfoAUShellHEDF = FindViewById<ImageView>(Resource.Id.InfoShipAUShellHEDF);
            _InfoAUShellFOG = FindViewById<ImageView>(Resource.Id.InfoShipAUShellFOG);
            _InfoAAAShellAP = FindViewById<ImageView>(Resource.Id.InfoShipAAAShellAP);
            _InfoAAAShellAPHE = FindViewById<ImageView>(Resource.Id.InfoShipAAAShellAPHE);
            _InfoAAAShellAPCR = FindViewById<ImageView>(Resource.Id.InfoShipAAAShellAPCR);
            _InfoAAAShellHE = FindViewById<ImageView>(Resource.Id.InfoShipAAAShellHE);
            _InfoAAAShellHEVT = FindViewById<ImageView>(Resource.Id.InfoShipAAAShellHEVT);
            _InfoAAAShellHEDF = FindViewById<ImageView>(Resource.Id.InfoShipAAAShellHEDF);
            _InfoAAAShellFOG = FindViewById<ImageView>(Resource.Id.InfoShipAAAShellFOG);

            _InfoShipLabelTextFirstLaunch = FindViewById<TextView>(Resource.Id.InfoShipLabelTextShipLaunched);
            _InfoShipLabelTextPatchAdded = FindViewById<TextView>(Resource.Id.InfoShipLabelTextPatchAdded);
            _InfoShipLabelTextType = FindViewById<TextView>(Resource.Id.InfoShipLabelTextType);
            _InfoShipLabelTextCharacter = FindViewById<TextView>(Resource.Id.InfoShipLabelTextCharacter);
            _InfoShipLabelTextBR = FindViewById<TextView>(Resource.Id.InfoShipLabelTextBR);

            _InfoShipTextFirstLaunch = FindViewById<TextView>(Resource.Id.InfoShipTextShipLaunched);
            _InfoShipTextPatchAdded = FindViewById<TextView>(Resource.Id.InfoShipTextPatchAdded);
            _InfoShipTextType = FindViewById<TextView>(Resource.Id.InfoShipTextType);
            _InfoShipTextCharacter = FindViewById<TextView>(Resource.Id.InfoShipTextCharacter);
            _InfoShipTextBR = FindViewById<TextView>(Resource.Id.InfoShipTextBR);


            _InfoShipTextMainCaliberName = FindViewById<TextView>(Resource.Id.InfoShipTextMainCaliber);
            _InfoShipTextMainCaliberReload = FindViewById<TextView>(Resource.Id.InfoShipTextMainCaliberReload);
            _InfoShipTextMainCaliberTNT = FindViewById<TextView>(Resource.Id.InfoShipTextMainCaliberTNT);
            _InfoShipTextAuxiliaryCaliberName = FindViewById<TextView>(Resource.Id.InfoShipTextAuxiliaryCaliber);
            _InfoShipTextAuxiliaryCaliberReload = FindViewById<TextView>(Resource.Id.InfoShipTextAuxiliaryCaliberReload);
            _InfoShipTextAAACaliberName = FindViewById<TextView>(Resource.Id.InfoShipTextAAACaliber);
            _InfoShipTextAAACaliberReload = FindViewById<TextView>(Resource.Id.InfoShipTextAAACaliberReload);
            _InfoShipTextTorpedoName = FindViewById<TextView>(Resource.Id.InfoShipTextTorpedo);
            _InfoShipTextTorpedoItem = FindViewById<TextView>(Resource.Id.InfoShipTextTorpedoItem);
            _InfoShipTextTorpedoMaxSpeed = FindViewById<TextView>(Resource.Id.InfoShipTextTorpedoMaxSpeed);
            _InfoShipTextTorpedoTNT = FindViewById<TextView>(Resource.Id.InfoShipTextTorpedoTNT);
            _InfoShipTextMaxSpeed = FindViewById<TextView>(Resource.Id.InfoShipTextMaxSpeed);
            _InfoShipTextReverseSpeed = FindViewById<TextView>(Resource.Id.InfoShipTextReverseSpeed);
            _InfoShipTextAcceleration = FindViewById<TextView>(Resource.Id.InfoShipTextAcceleration);
            _InfoShipTextBrakingTime = FindViewById<TextView>(Resource.Id.InfoShipTextBrakingTime);
            _InfoShipTextTurn360 = FindViewById<TextView>(Resource.Id.InfoShipTextTurn360);
            _InfoShipTextDisplacement = FindViewById<TextView>(Resource.Id.InfoShipTextDisplacement);
            _InfoShipTextCrewCount = FindViewById<TextView>(Resource.Id.InfoShipTextCrewCount);

            _InfoShipLabelTextMainCaliberReload = FindViewById<TextView>(Resource.Id.InfoShipLabelMainCaliberReload);
            _InfoShipLabelTextMainCaliberTNT = FindViewById<TextView>(Resource.Id.InfoShipLabelMainCaliberTNT);
            _InfoShipLabelTextAuxiliaryCaliberReload = FindViewById<TextView>(Resource.Id.InfoShipLabelAuxiliaryCaliberReload);
            _InfoShipLabelTextAAACaliberReload = FindViewById<TextView>(Resource.Id.InfoShipLabelAAACaliberReload);
            _InfoShipLabelTextTorpedoItem = FindViewById<TextView>(Resource.Id.InfoShipLabelTorpedoItem);
            _InfoShipLabelTextTorpedoMaxSpeed = FindViewById<TextView>(Resource.Id.InfoShipLabelTorpedoMaxSpeed);
            _InfoShipLabelTextTorpedoTNT = FindViewById<TextView>(Resource.Id.InfoShipLabelTorpedoTNT);
            _InfoShipLabelTextMaxSpeed = FindViewById<TextView>(Resource.Id.InfoShipLabelMaxSpeed);
            _InfoShipLabelTextReverseSpeed = FindViewById<TextView>(Resource.Id.InfoShipLabelReverseSpeed);
            _InfoShipLabelTextAcceleration = FindViewById<TextView>(Resource.Id.InfoShipLabelAcceleration);
            _InfoShipLabelTextBrakingTime = FindViewById<TextView>(Resource.Id.InfoShipLabelBrakingTime);
            _InfoShipLabelTextTurn360 = FindViewById<TextView>(Resource.Id.InfoShipLabelTurn360);
            _InfoShipLabelTextDisplacement = FindViewById<TextView>(Resource.Id.InfoShipLabelDisplacement);
            _InfoShipLabelTextCrewCount = FindViewById<TextView>(Resource.Id.InfoShipLabelCrewCount);
            _InfoShipLabelTextMCShellType = FindViewById<TextView>(Resource.Id.InfoShipLabelMCShellType);
            _InfoShipLabelTextAUShellType = FindViewById<TextView>(Resource.Id.InfoShipLabelAUShellType);
            _InfoShipLabelTextAAAShellType = FindViewById<TextView>(Resource.Id.InfoShipLabelAAAShellType);
            _InfoShipLabelTextAdditional = FindViewById<TextView>(Resource.Id.InfoShipLabelAdditionalWeapon);
            #endregion

            #region Изменение шрифта и цвета 

            _InfoShipLabelTextMainCaliberReload.Typeface = font;
            _InfoShipLabelTextMainCaliberTNT.Typeface = font;
            _InfoShipLabelTextAuxiliaryCaliberReload.Typeface = font;
            _InfoShipLabelTextAAACaliberReload.Typeface = font;
            _InfoShipLabelTextTorpedoItem.Typeface = font;
            _InfoShipLabelTextTorpedoMaxSpeed.Typeface = font;
            _InfoShipLabelTextTorpedoTNT.Typeface = font;
            _InfoShipLabelTextMaxSpeed.Typeface = font;
            _InfoShipLabelTextReverseSpeed.Typeface = font;
            _InfoShipLabelTextAcceleration.Typeface = font;
            _InfoShipLabelTextBrakingTime.Typeface = font;
            _InfoShipLabelTextTurn360.Typeface = font;
            _InfoShipLabelTextDisplacement.Typeface = font;
            _InfoShipLabelTextCrewCount.Typeface = font;

            _InfoShipLabelTextFirstLaunch.Typeface = font; 
            _InfoShipLabelTextPatchAdded.Typeface = font; 
            _InfoShipLabelTextType.Typeface = font;
            _InfoShipLabelTextCharacter.Typeface = font; 
            _InfoShipLabelTextBR.Typeface = font;
            _InfoShipLabelTextMCShellType.Typeface = font;
            _InfoShipLabelTextAUShellType.Typeface = font;
            _InfoShipLabelTextAAAShellType.Typeface = font;
            _InfoShipLabelTextAdditional.Typeface = font;


            _InfoShipLabelTextMainCaliberReload.SetTextColor(Color.Black);
            _InfoShipLabelTextMainCaliberTNT.SetTextColor(Color.Black);
            _InfoShipLabelTextAuxiliaryCaliberReload.SetTextColor(Color.Black);
            _InfoShipLabelTextAAACaliberReload.SetTextColor(Color.Black);
            _InfoShipLabelTextTorpedoItem.SetTextColor(Color.Black);
            _InfoShipLabelTextTorpedoMaxSpeed.SetTextColor(Color.Black);
            _InfoShipLabelTextTorpedoTNT.SetTextColor(Color.Black);
            _InfoShipLabelTextMaxSpeed.SetTextColor(Color.Black);
            _InfoShipLabelTextReverseSpeed.SetTextColor(Color.Black);
            _InfoShipLabelTextAcceleration.SetTextColor(Color.Black);
            _InfoShipLabelTextBrakingTime.SetTextColor(Color.Black);
            _InfoShipLabelTextTurn360.SetTextColor(Color.Black);
            _InfoShipLabelTextDisplacement.SetTextColor(Color.Black);
            _InfoShipLabelTextCrewCount.SetTextColor(Color.Black);


            _InfoShipTextMainCaliberName.SetTextColor(Color.Black);
            _InfoShipTextMainCaliberReload.SetTextColor(Color.Black);
            _InfoShipTextMainCaliberTNT.SetTextColor(Color.Black);
            _InfoShipTextAuxiliaryCaliberName.SetTextColor(Color.Black);
            _InfoShipTextAuxiliaryCaliberReload.SetTextColor(Color.Black);
            _InfoShipTextAAACaliberName.SetTextColor(Color.Black);
            _InfoShipTextAAACaliberReload.SetTextColor(Color.Black);
            _InfoShipTextTorpedoName.SetTextColor(Color.Black);
            _InfoShipTextTorpedoItem.SetTextColor(Color.Black);
            _InfoShipTextTorpedoMaxSpeed.SetTextColor(Color.Black);
            _InfoShipTextTorpedoTNT.SetTextColor(Color.Black);
            _InfoShipTextMaxSpeed.SetTextColor(Color.Black);
            _InfoShipTextReverseSpeed.SetTextColor(Color.Black);
            _InfoShipTextAcceleration.SetTextColor(Color.Black);
            _InfoShipTextBrakingTime.SetTextColor(Color.Black);
            _InfoShipTextTurn360.SetTextColor(Color.Black);
            _InfoShipTextDisplacement.SetTextColor(Color.Black);
            _InfoShipTextCrewCount.SetTextColor(Color.Black);

            _InfoShipLabelTextFirstLaunch.SetTextColor(Color.Black);
            _InfoShipLabelTextPatchAdded.SetTextColor(Color.Black);
            _InfoShipLabelTextType.SetTextColor(Color.Black);
            _InfoShipLabelTextCharacter.SetTextColor(Color.Black);
            _InfoShipLabelTextBR.SetTextColor(Color.Black);


            _InfoShipTextFirstLaunch.SetTextColor(Color.Black);
            _InfoShipTextPatchAdded.SetTextColor(Color.Black);
            _InfoShipTextType.SetTextColor(Color.Black);
            _InfoShipTextCharacter.SetTextColor(Color.Black);
            _InfoShipTextBR.SetTextColor(Color.Black);
            #endregion

            nations = NationCollection.GetNation();
            AdapterNation = new NationAdapter(this, nations);
            _InfoSpinnerNation.Adapter = AdapterNation;
            _InfoSpinnerNation.SetSelection(1);  //Автовыбор
            selectedNation = 1;   //Автовыбор

            ranks = RankCollection.GetRank();
            AdapterRank = new RankAdapter(this, ranks);
            _InfoSpinnerRank.Adapter = AdapterRank;
            _InfoSpinnerRank.SetSelection(4);   //Автовыбор
            selectedRank = 4;   //Автовыбор

            potentialTask = ShipTaskCollection.GetTask();
            PotentialAdapterTaskShip = new TaskAdapter(this, potentialTask);
            _InfoSpinnerPotentialEnemyShip.Adapter = PotentialAdapterTaskShip;
            _InfoSpinnerPotentialEnemyShip.SetSelection(0); //Автовыбор
            SelectedPotentialTaskShip = 0; //Автовыбор

            _InfoSpinnerShip.SetSelection(1);
            //Объявление коллекции наций, рангов и адаптеров

            _InfoSpinnerNation.ItemSelected += _InfoSpinnerNation_ItemSelected;
            _InfoSpinnerRank.ItemSelected += _InfoSpinnerRank_ItemSelected;
            _InfoSpinnerShip.ItemSelected += _InfoSpinnerShip_ItemSelected;
            _InfoSpinnerPotentialEnemyShip.ItemSelected += _InfoSpinnerPotentialEnemyShip_ItemSelected;


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

        private void _InfoSpinnerNation_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedNation = nations[e.Position].Id;

            if (selectedNation == 100 && selectedRank == 100)
            {
                ships = ShipCollection.GetShip();
                AdapterShip = new ShipAdapter(this, ships);
                _InfoSpinnerShip.Adapter = AdapterShip;
            }
            else
            if (selectedNation == 100)
            {
                List<Ship> shipsAll = ShipCollection.GetShip();
                var shipvar = from s in shipsAll
                              where s.RankId == selectedRank
                              select s;
                ships = shipvar.ToList<Ship>();
                AdapterShip = new ShipAdapter(this, ships);
                _InfoSpinnerShip.Adapter = AdapterShip;
            }
            else
                if (selectedRank == 100)
            {
                List<Ship> shipsAll = ShipCollection.GetShip();
                var shipvar = from s in shipsAll
                              where s.NationId == selectedNation
                              select s;
                ships = shipvar.ToList<Ship>();
                AdapterShip = new ShipAdapter(this, ships);
                _InfoSpinnerShip.Adapter = AdapterShip;
            }
            else
            {
                ships = ShipSelector(selectedNation, selectedRank);
                AdapterShip = new ShipAdapter(this, ships);
                _InfoSpinnerShip.Adapter = AdapterShip;
            }

        }

        private void _InfoSpinnerRank_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedRank = ranks[e.Position].Id;

            if (selectedNation == 100 && selectedRank == 100)
            {
                ships = ShipCollection.GetShip();
                AdapterShip = new ShipAdapter(this, ships);
                _InfoSpinnerShip.Adapter = AdapterShip;
            }
            else
            if (selectedNation == 100)
            {
                List<Ship> shipsAll = ShipCollection.GetShip();
                var shipvar = from s in shipsAll
                              where s.RankId == selectedRank
                              select s;
                ships = shipvar.ToList<Ship>();
                AdapterShip = new ShipAdapter(this, ships);
                _InfoSpinnerShip.Adapter = AdapterShip;
            }
            else
                if (selectedRank == 100)
            {
                List<Ship> shipsAll = ShipCollection.GetShip();
                var shipvar = from s in shipsAll
                              where s.NationId == selectedNation
                              select s;
                ships = shipvar.ToList<Ship>();
                AdapterShip = new ShipAdapter(this, ships);
                _InfoSpinnerShip.Adapter = AdapterShip;
            }
            else
            {
                ships = ShipSelector(selectedNation, selectedRank);
                AdapterShip = new ShipAdapter(this, ships);
                _InfoSpinnerShip.Adapter = AdapterShip;
            }

        }

        private void _InfoSpinnerPotentialEnemyShip_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            SelectedPotentialTaskShip = potentialTask[e.Position].Id;
            TaskSelector();
        }

        private List<Ship> ShipSelector(int selectedNation, int selectedRank)
        {
            this.selectedNation = selectedNation;
            this.selectedRank = selectedRank;
            List<Ship> shipsAll = ShipCollection.GetShip();
            var shipvar = from s in shipsAll
                          where s.NationId == selectedNation
                          where s.RankId == selectedRank
                          select s;
            return shipvar.ToList<Ship>();
        }

        private void TaskSelector()
        {
            if (SelectedPotentialTaskShip == 1)
            {
                List<Ship> shipsAll = ShipCollection.GetShip();
                double step = 1.0;
                var shipvar = from s in shipsAll
                              where s.BR <= selectedShipBR + step && s.BR >= selectedShipBR - step && s.NationId != selectedNation
                              orderby s.MainCaliberSize descending
                              select s;
                shipspotential = shipvar.ToList<Ship>();
                AdapterListView = new ListViewInfoShipAdapter(this, shipspotential);
                _InfoListView.Adapter = AdapterListView;
            }

            if (SelectedPotentialTaskShip == 2)
            {
                List<Ship> shipsAll = ShipCollection.GetShip();
                double step = 1.0;
                var shipvar = from s in shipsAll
                              where s.BR <= selectedShipBR + step && s.BR >= selectedShipBR - step && s.NationId != selectedNation
                              orderby s.MainCaliberItem descending
                              select s;
                shipspotential = shipvar.ToList<Ship>();
                AdapterListView = new ListViewInfoShipAdapter(this, shipspotential);
                _InfoListView.Adapter = AdapterListView;
            }

            if (SelectedPotentialTaskShip == 3)
            {
                List<Ship> shipsAll = ShipCollection.GetShip();
                double step = 1.0;
                var shipvar = from s in shipsAll
                              where s.BR <= selectedShipBR + step && s.BR >= selectedShipBR - step && s.NationId != selectedNation
                              orderby s.MainCaliberTNT descending
                              select s;
                shipspotential = shipvar.ToList<Ship>();
                AdapterListView = new ListViewInfoShipAdapter(this, shipspotential);
                _InfoListView.Adapter = AdapterListView;
            }

            if (SelectedPotentialTaskShip == 4)
            {
                List<Ship> shipsAll = ShipCollection.GetShip();
                double step = 1.0;
                var shipvar = from s in shipsAll
                              where s.BR <= selectedShipBR + step && s.BR >= selectedShipBR - step && s.NationId != selectedNation
                              orderby s.MaxSpeed descending
                              select s;
                shipspotential = shipvar.ToList<Ship>();
                AdapterListView = new ListViewInfoShipAdapter(this, shipspotential);
                _InfoListView.Adapter = AdapterListView;
            }

            if (SelectedPotentialTaskShip == 5)
            {
                List<Ship> shipsAll = ShipCollection.GetShip();
                double step = 1.0;
                var shipvar = from s in shipsAll
                              where s.BR <= selectedShipBR + step && s.BR >= selectedShipBR - step && s.NationId != selectedNation
                              orderby s.TorpedoItem descending
                              select s;
                shipspotential = shipvar.ToList<Ship>();
                AdapterListView = new ListViewInfoShipAdapter(this, shipspotential);
                _InfoListView.Adapter = AdapterListView;
            }

            if (SelectedPotentialTaskShip == 6)
            {
                List<Ship> shipsAll = ShipCollection.GetShip();
                double step = 1.0;
                var shipvar = from s in shipsAll
                              where s.BR <= selectedShipBR + step && s.BR >= selectedShipBR - step && s.NationId != selectedNation
                              orderby s.TorpedoTNT descending
                              select s;
                shipspotential = shipvar.ToList<Ship>();
                AdapterListView = new ListViewInfoShipAdapter(this, shipspotential);
                _InfoListView.Adapter = AdapterListView;
            }

            if (SelectedPotentialTaskShip == 7)
            {
                List<Ship> shipsAll = ShipCollection.GetShip();
                double step = 1.0;
                var shipvar = from s in shipsAll
                              where s.BR <= selectedShipBR + step && s.BR >= selectedShipBR - step && s.NationId != selectedNation
                              orderby s.Displacement descending
                              select s;
                shipspotential = shipvar.ToList<Ship>();
                AdapterListView = new ListViewInfoShipAdapter(this, shipspotential);
                _InfoListView.Adapter = AdapterListView;
            }
        }

        private void _InfoSpinnerShip_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedShipBR = ships[e.Position].BR;
            HandingRocket = ships[e.Position].HandingRocket;
            HandlingDepthCharge = ships[e.Position].HandingDepthCharge;
            HandlingTorpedo = ships[e.Position].HandingTorpedo;
            HandingMine = ships[e.Position].HandingMine;

            MCShellAP = ships[e.Position].MCShellAP;
            MCShellAPHE = ships[e.Position].MCShellAPHE;
            MCShellAPCR = ships[e.Position].MCShellAPCR;
            MCShellHE = ships[e.Position].MCShellHE;
            MCShellHEVT = ships[e.Position].MCShellHEVT;
            MCShellHEDF = ships[e.Position].MCShellHEDF;
            MCShellFOG = ships[e.Position].MCShellFOG;
            MCShellShrapnel = ships[e.Position].MCShellShrapnel;
            AUShellShrapnel = ships[e.Position].AUShellShrapnel;
            AUShellAP = ships[e.Position].AUShellAP;
            AUShellAPHE = ships[e.Position].AUShellAPHE;
            AUShellAPCR = ships[e.Position].AUShellAPCR;
            AUShellHE = ships[e.Position].AUShellHE;
            AUShellHEVT = ships[e.Position].AUShellHEVT;
            AUShellHEDF = ships[e.Position].AUShellHEDF;
            AUShellFOG = ships[e.Position].AUShellFOG;
            AAAShellAP = ships[e.Position].AAAShellAP;
            AAAShellAPHE = ships[e.Position].AAAShellAPHE;
            AAAShellAPCR = ships[e.Position].AAAShellAPCR;
            AAAShellHE = ships[e.Position].AAAShellHE;
            AAAShellHEVT = ships[e.Position].AAAShellHEVT;
            AAAShellHEDF = ships[e.Position].AAAShellHEDF;
            AAAShellFOG = ships[e.Position].AAAShellFOG;
            //Для картинок снарядов и доп вооружения

            _InfoImage.SetImageResource(ships[e.Position].Image);
            _InfoFlag.SetImageResource(ships[e.Position].FlagImage);
            _InfoShipTextBR.SetText(ships[e.Position].BR.ToString("0.0#"), TextView.BufferType.Normal);
            _InfoShipTextFirstLaunch.SetText(ships[e.Position].FirstLaunchYear.ToString() + context.Resources.GetString(Resource.String.AbbrYear), TextView.BufferType.Normal);
            _InfoShipTextPatchAdded.SetText(ships[e.Position].PatchAdded.ToString(), TextView.BufferType.Normal);
            _InfoShipTextType.SetText(ships[e.Position].Type, TextView.BufferType.Normal);
            _InfoShipTextCharacter.SetText(ships[e.Position].ShipCharacter, TextView.BufferType.Normal);
            _InfoShipTextMainCaliberName.SetText(ships[e.Position].MainCaliberName, TextView.BufferType.Normal);
            _InfoShipTextMainCaliberReload.SetText(ships[e.Position].MainCaliberReload.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            _InfoShipTextAuxiliaryCaliberName.SetText(ships[e.Position].AuxiliaryCaliberName, TextView.BufferType.Normal);
            _InfoShipTextAuxiliaryCaliberReload.SetText(ships[e.Position].AuxiliaryCaliberReload.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            _InfoShipTextAAACaliberName.SetText(ships[e.Position].AAACaliberName, TextView.BufferType.Normal);
            _InfoShipTextAAACaliberReload.SetText(ships[e.Position].AAACaliberReload.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            _InfoShipTextTorpedoName.SetText(ships[e.Position].TorpedoName, TextView.BufferType.Normal);
            _InfoShipTextTorpedoItem.SetText(ships[e.Position].TorpedoItem.ToString() + context.Resources.GetString(Resource.String.AbbrITEMS), TextView.BufferType.Normal);
            _InfoShipTextAcceleration.SetText(ships[e.Position].Acceleration.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            _InfoShipTextBrakingTime.SetText(ships[e.Position].BrakingTime.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            //
            int newTurn360 = ships[e.Position].Turn360;
            TimeSpan timeSpan = TimeSpan.FromSeconds(newTurn360);
            string turnToShow = timeSpan.ToString(@"mm\:ss");
            //
            _InfoShipTextTurn360.SetText(turnToShow, TextView.BufferType.Normal);
            _InfoShipTextCrewCount.SetText(ships[e.Position].CrewCount.ToString() + context.Resources.GetString(Resource.String.AbbrITEMS), TextView.BufferType.Normal);
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            ISharedPreferencesEditor editor = prefs.Edit();
            var switchchecked = prefs.GetBoolean("key_kmhtomph", false);
            if (switchchecked)
            {
                var maxSpeed = ships[e.Position].MaxSpeed * 0.621371192;
                var reverseSpeed = ships[e.Position].ReverseSpeed * 0.621371192;
                var torpedoMaxSpeed = ships[e.Position].TorpedoMaxSpeed * 0.621371192;
                var mainCaliberTNT = ships[e.Position].MainCaliberTNT * 2.204622621849;
                var torpedoTNT = ships[e.Position].TorpedoTNT *2.204622621849;
                var displacement = ships[e.Position].Displacement*1.10231131;
                maxSpeed = Math.Round(maxSpeed, 0);
                reverseSpeed = Math.Round(reverseSpeed, 0);
                torpedoMaxSpeed = Math.Round(torpedoMaxSpeed, 0);
                mainCaliberTNT = Math.Round(mainCaliberTNT, 1);
                torpedoTNT = Math.Round(torpedoTNT, 0);
                displacement = Math.Round(displacement, 0);

                _InfoShipTextMaxSpeed.SetText(maxSpeed + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _InfoShipTextReverseSpeed.SetText(reverseSpeed + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _InfoShipTextTorpedoMaxSpeed.SetText(torpedoMaxSpeed + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _InfoShipTextMainCaliberTNT.SetText(mainCaliberTNT + context.Resources.GetString(Resource.String.AbbrLB), TextView.BufferType.Normal);
                _InfoShipTextTorpedoTNT.SetText(torpedoTNT + context.Resources.GetString(Resource.String.AbbrLB), TextView.BufferType.Normal);
                _InfoShipTextDisplacement.SetText(displacement + context.Resources.GetString(Resource.String.AbbrST), TextView.BufferType.Normal);

            }
            else
            {
                _InfoShipTextMainCaliberTNT.SetText(ships[e.Position].MainCaliberTNT.ToString() + context.Resources.GetString(Resource.String.AbbrKG), TextView.BufferType.Normal);
                _InfoShipTextTorpedoMaxSpeed.SetText(ships[e.Position].TorpedoMaxSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _InfoShipTextTorpedoTNT.SetText(ships[e.Position].TorpedoTNT.ToString() + context.Resources.GetString(Resource.String.AbbrKG), TextView.BufferType.Normal);
                _InfoShipTextMaxSpeed.SetText(ships[e.Position].MaxSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _InfoShipTextReverseSpeed.SetText(ships[e.Position].ReverseSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _InfoShipTextDisplacement.SetText(ships[e.Position].Displacement.ToString() + context.Resources.GetString(Resource.String.AbbrT), TextView.BufferType.Normal);

            }



            ShipHandingWeaponShower();
            TaskSelector();
        }

        public void ShipHandingWeaponShower()
        {

            if (HandingRocket == true)
            {
                _InfoHandingRocket.SetImageResource(Resource.Drawable._handingRocket);
            }
            else
            {
                _InfoHandingRocket.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (HandlingDepthCharge == true)
            {
                _InfoHandlingDepthCharge.SetImageResource(Resource.Drawable._handlingDepthCharge);
            }
            else
            {
                _InfoHandlingDepthCharge.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (HandlingTorpedo == true)
            {
                _InfoHandlingTorpedo.SetImageResource(Resource.Drawable._handingTorpedo);
            }
            else
            {
                _InfoHandlingTorpedo.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (HandingMine == true)
            {
                _InfoHandingMine.SetImageResource(Resource.Drawable._handlingMine);
            }
            else
            {
                _InfoHandingMine.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (MCShellAP == true)
            {
                _InfoMCShellAP.SetImageResource(Resource.Drawable._ShellAP);
            }
            else
            {
                _InfoMCShellAP.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (MCShellAPHE == true)
            {
                _InfoMCShellAPHE.SetImageResource(Resource.Drawable._ShellAPHE);
            }
            else
            {
                _InfoMCShellAPHE.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (MCShellAPCR == true)
            {
                _InfoMCShellAPCR.SetImageResource(Resource.Drawable._ShellAPCR);
            }
            else
            {
                _InfoMCShellAPCR.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (MCShellHE == true)
            {
                _InfoMCShellHE.SetImageResource(Resource.Drawable._ShellHE);
            }
            else
            {
                _InfoMCShellHE.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (MCShellHEVT == true)
            {
                _InfoMCShellHEVT.SetImageResource(Resource.Drawable._ShellHEVT);
            }
            else
            {
                _InfoMCShellHEVT.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (MCShellHEDF == true)
            {
                _InfoMCShellHEDF.SetImageResource(Resource.Drawable._ShellHEDF);
            }
            else
            {
                _InfoMCShellHEDF.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (MCShellFOG == true)
            {
                _InfoMCShellFOG.SetImageResource(Resource.Drawable._ShellFOG);
            }
            else
            {
                _InfoMCShellFOG.SetImageResource(Resource.Drawable._handingTransparent);
            }


            if (AUShellAP == true)
            {
                _InfoAUShellAP.SetImageResource(Resource.Drawable._ShellAP);
            }
            else
            {
                _InfoAUShellAP.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (AUShellAPHE == true)
            {
                _InfoAUShellAPHE.SetImageResource(Resource.Drawable._ShellAPHE);
            }
            else
            {
                _InfoAUShellAPHE.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (AUShellAPCR == true)
            {
                _InfoAUShellAPCR.SetImageResource(Resource.Drawable._ShellAPCR);
            }
            else
            {
                _InfoAUShellAPCR.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (AUShellHE == true)
            {
                _InfoAUShellHE.SetImageResource(Resource.Drawable._ShellHE);
            }
            else
            {
                _InfoAUShellHE.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (AUShellHEVT == true)
            {
                _InfoAUShellHEVT.SetImageResource(Resource.Drawable._ShellHEVT);
            }
            else
            {
                _InfoAUShellHEVT.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (AUShellHEDF == true)
            {
                _InfoAUShellHEDF.SetImageResource(Resource.Drawable._ShellHEDF);
            }
            else
            {
                _InfoAUShellHEDF.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (AUShellFOG == true)
            {
                _InfoAUShellFOG.SetImageResource(Resource.Drawable._ShellFOG);
            }
            else
            {
                _InfoAUShellFOG.SetImageResource(Resource.Drawable._handingTransparent);
            }


            if (AAAShellAP == true)
            {
                _InfoAAAShellAP.SetImageResource(Resource.Drawable._ShellAP);
            }
            else
            {
                _InfoAAAShellAP.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (AAAShellAPHE == true)
            {
                _InfoAAAShellAPHE.SetImageResource(Resource.Drawable._ShellAPHE);
            }
            else
            {
                _InfoAAAShellAPHE.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (AAAShellAPCR == true)
            {
                _InfoAAAShellAPCR.SetImageResource(Resource.Drawable._ShellAPCR);
            }
            else
            {
                _InfoAAAShellAPCR.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (AAAShellHE == true)
            {
                _InfoAAAShellHE.SetImageResource(Resource.Drawable._ShellHE);
            }
            else
            {
                _InfoAAAShellHE.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (AAAShellHEVT == true)
            {
                _InfoAAAShellHEVT.SetImageResource(Resource.Drawable._ShellHEVT);
            }
            else
            {
                _InfoAAAShellHEVT.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (AAAShellHEDF == true)
            {
                _InfoAAAShellHEDF.SetImageResource(Resource.Drawable._ShellHEDF);
            }
            else
            {
                _InfoAAAShellHEDF.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (AAAShellFOG == true)
            {
                _InfoAAAShellFOG.SetImageResource(Resource.Drawable._ShellFOG);
            }
            else
            {
                _InfoAAAShellFOG.SetImageResource(Resource.Drawable._handingTransparent);
            }


            if (MCShellShrapnel == true)
            {
                _InfoMCShellShrapnel.SetImageResource(Resource.Drawable._ShellShrapnel);
            }
            else
            {
                _InfoMCShellShrapnel.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (AUShellShrapnel == true)
            {
                _InfoAUShellShrapnel.SetImageResource(Resource.Drawable._ShellShrapnel);
            }
            else
            {
                _InfoAUShellShrapnel.SetImageResource(Resource.Drawable._handingTransparent);
            }

        }

    }
}