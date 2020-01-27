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
using Android.Gms.Ads;

namespace WarThunderComparer
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait)]
    class InfoPlane : AppCompatActivity
    {
        Spinner _InfoSpinnerNation;
        Spinner _InfoSpinnerPlane;
        Spinner _InfoSpinnerRank;
        ListView _InfoListView;
        Spinner _InfoSpinnerPotentialEnemyPlane;     
        TaskAdapter PotentialAdapterTaskPlane;          
        //Объявление  спиннеров и скролов с XAML

        #region Объявление всех Textview
        Context context;
        ImageView _InfoImage;
        ImageView _InfoFlag;
        ImageView _InfoHandlingRocket;
        ImageView _InfoHandlingCannon;
        ImageView _InfoHandlingBomb;
        ImageView _InfoHandlingTorpedo;
        ImageView _InfoHandlingAirToAir;
        ImageView _InfoHandlingAirToGround;

        TextView _InfoPlaneTextFirstFlyYear;
        TextView _InfoPlaneTextPatchAdded;
        TextView _InfoPlaneTextBombLoad;
        TextView _InfoPlaneTextBR;
        TextView _InfoPlaneTextType;
        TextView _InfoPlaneTextMaxSpeedAt0;
        TextView _InfoPlaneTextMaxSpeedAt5000;
        TextView _InfoPlaneTextTurnAt0;
        TextView _InfoPlaneTextClimb;
        TextView _InfoPlaneTextEnginePower;
        TextView _InfoPlaneTextWeight;
        TextView _InfoPlaneTextThrustToWeightRatio;
        TextView _InfoPlaneTextWeaponVolleyPerSecond;
        TextView _InfoPlaneTextWeaponAndTurrels;
        TextView _InfoPlaneTextPlaneCharacter;
        TextView _InfoPlaneTextFlutter;


        TextView _InfoPlaneLabelTextFirstFlyYear;
        TextView _InfoPlaneLabelTextPatchAdded;
        TextView _InfoPlaneLabelTextBombLoad;
        TextView _InfoPlaneLabelTextHandingWeapon;
        TextView _InfoPlaneLabelTextBR;
        TextView _InfoPlaneLabelTextType;
        TextView _InfoPlaneLabelTextMaxSpeedAt0;
        TextView _InfoPlaneLabelTextMaxSpeedAt5000;
        TextView _InfoPlaneLabelTextTurnAt0;
        TextView _InfoPlaneLabelTextClimb;
        TextView _InfoPlaneLabelTextEnginePower;
        TextView _InfoPlaneLabelTextWeight;
        TextView _InfoPlaneLabelTextThrustToWeightRatio;
        TextView _InfoPlaneLabelTextWeaponVolleyPerSecond;
        TextView _InfoPlaneLabelTextPlaneCharacter;
        TextView _InfoPlaneLabelTextFlutter;


        //Объявление текстовых полей
        #endregion

        List<Plane> planes;
        List<Plane> planespotential;
        PlaneAdapter AdapterPlane;
        List<Nation> nations;
        NationAdapter AdapterNation;
        List<Rank> ranks;
        public List<Task> potentialTaskPlane;
        RankAdapter AdapterRank;
        ListViewInfoAdapter AdapterListView;


        private bool bombExiste;
        private bool rocketExiste;
        private bool cannonExiste;
        private bool torpedoExiste;
        private bool airToAirExiste;
        private bool airToGroundExiste;


        private int selectedNation;
        private int selectedRank;
        private double selectedPlaneBR;
        private int selectedRankID;
        public static int SelectedPotentialTaskPlane;

        // Объявление адаптеров, коллекций и переменных        


        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\
        DrawerLayout drawerLayout;
        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\

        public InfoPlane()
        {
        }
        protected InfoPlane(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.InfoPlane);
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
            var adView = FindViewById<AdView>(Resource.Id.adViewInfoPlane);
                 var adRequest = new AdRequest.Builder().Build();
                adView.LoadAd(adRequest);
            //var requestbuilder = new AdRequest.Builder().AddTestDevice("D0BE22F1A4BE27C7470F95A699568FE2");
            //adView.LoadAd(requestbuilder.Build());
            //шрифт
            var font = Typeface.CreateFromAsset(Assets, "dinfont.ttf");

            _InfoSpinnerNation = FindViewById<Spinner>(Resource.Id.InfoSpinnerNation);
            _InfoSpinnerPlane = FindViewById<Spinner>(Resource.Id.InfoSpinnerPlane);
            _InfoSpinnerRank = FindViewById<Spinner>(Resource.Id.InfoSpinnerRank);
            _InfoListView = FindViewById<ListView>(Resource.Id.listView);
            _InfoSpinnerPotentialEnemyPlane = FindViewById<Spinner>(Resource.Id.InfoSpinnerPotentialEnemyPlane);   
            //Привязка спиннеров к шарп коду

            #region Привязка TextView к коду
            _InfoImage = FindViewById<ImageView>(Resource.Id.InfoImage);
            _InfoFlag = FindViewById<ImageView>(Resource.Id.InfoCompareFlag);
            _InfoHandlingRocket = FindViewById<ImageView>(Resource.Id.InfoHandlingRocket);
            _InfoHandlingCannon = FindViewById<ImageView>(Resource.Id.InfoHandlingCannon);
            _InfoHandlingBomb = FindViewById<ImageView>(Resource.Id.InfoHandlingBomb);
            _InfoHandlingTorpedo = FindViewById<ImageView>(Resource.Id.InfoHandlingTorpedo);
            _InfoHandlingAirToAir = FindViewById<ImageView>(Resource.Id.InfoHandlingAirToAir);
            _InfoHandlingAirToGround = FindViewById<ImageView>(Resource.Id.InfoHandlingAirToGround);


            _InfoPlaneTextFirstFlyYear = FindViewById<TextView>(Resource.Id.InfoPlaneTextFirstFlyYear);
            _InfoPlaneTextPatchAdded = FindViewById<TextView>(Resource.Id.InfoPlaneTextPatchAdded);
            _InfoPlaneTextBombLoad = FindViewById<TextView>(Resource.Id.InfoPlaneTextBombLoad);
            _InfoPlaneTextBR = FindViewById<TextView>(Resource.Id.InfoPlaneTextBR);
            _InfoPlaneTextType = FindViewById<TextView>(Resource.Id.InfoPlaneTextType);
            _InfoPlaneTextMaxSpeedAt0 = FindViewById<TextView>(Resource.Id.InfoPlaneTextMaxSpeedAt0);
            _InfoPlaneTextMaxSpeedAt5000 = FindViewById<TextView>(Resource.Id.InfoPlaneTextMaxSpeedAt5000);
            _InfoPlaneTextTurnAt0 = FindViewById<TextView>(Resource.Id.InfoPlaneTextTurnAt0);
            _InfoPlaneTextClimb = FindViewById<TextView>(Resource.Id.InfoPlaneTextClimb);
            _InfoPlaneTextEnginePower = FindViewById<TextView>(Resource.Id.InfoPlaneTextEnginePower);
            _InfoPlaneTextWeight = FindViewById<TextView>(Resource.Id.InfoPlaneTextWeight);
            _InfoPlaneTextThrustToWeightRatio = FindViewById<TextView>(Resource.Id.InfoPlaneTextThrustToWeightRatio);
            _InfoPlaneTextWeaponVolleyPerSecond = FindViewById<TextView>(Resource.Id.InfoPlaneTextWeaponVolleyPerSecond);
            _InfoPlaneTextWeaponAndTurrels = FindViewById<TextView>(Resource.Id.InfoPlaneTextWeaponAndTurrels);
            _InfoPlaneTextPlaneCharacter = FindViewById<TextView>(Resource.Id.InfoPlaneTextPlaneCharacter);
            _InfoPlaneTextFlutter = FindViewById<TextView>(Resource.Id.InfoPlaneTextFlutter);

            _InfoPlaneLabelTextHandingWeapon = FindViewById<TextView>(Resource.Id.InfoPlaneLabelTextHandingWeapon);
            _InfoPlaneLabelTextFirstFlyYear = FindViewById<TextView>(Resource.Id.InfoPlaneLabelTextFirstFlyYear);
            _InfoPlaneLabelTextPatchAdded = FindViewById<TextView>(Resource.Id.InfoPlaneLabelTextPlanePatchAdded);
            _InfoPlaneLabelTextBombLoad = FindViewById<TextView>(Resource.Id.InfoPlaneLabelTextBombLoad);
            _InfoPlaneLabelTextBR = FindViewById<TextView>(Resource.Id.InfoPlaneLabelTextBR);
            _InfoPlaneLabelTextType = FindViewById<TextView>(Resource.Id.InfoPlaneLabelTextType);
            _InfoPlaneLabelTextMaxSpeedAt0 = FindViewById<TextView>(Resource.Id.InfoPlaneLabelTextMaxSpeedAt0);
            _InfoPlaneLabelTextMaxSpeedAt5000 = FindViewById<TextView>(Resource.Id.InfoPlaneLabelTextMaxSpeedAt5000);
            _InfoPlaneLabelTextTurnAt0 = FindViewById<TextView>(Resource.Id.InfoPlaneLabelTextTurnAt0);
            _InfoPlaneLabelTextClimb = FindViewById<TextView>(Resource.Id.InfoPlaneLabelTextClimb);
            _InfoPlaneLabelTextEnginePower = FindViewById<TextView>(Resource.Id.InfoPlaneLabelTextEnginePower);
            _InfoPlaneLabelTextWeight = FindViewById<TextView>(Resource.Id.InfoPlaneLabelTextWeight);
            _InfoPlaneLabelTextThrustToWeightRatio = FindViewById<TextView>(Resource.Id.InfoPlaneLabelTextThrustToWeightRatio);
            _InfoPlaneLabelTextWeaponVolleyPerSecond = FindViewById<TextView>(Resource.Id.InfoPlaneLabelTextWeaponVolleyPerSecond);
            _InfoPlaneLabelTextPlaneCharacter = FindViewById<TextView>(Resource.Id.InfoPlaneLabelTextPlaneCharacter);
            _InfoPlaneLabelTextFlutter = FindViewById<TextView>(Resource.Id.InfoPlaneLabelTextFlutter);

            #endregion

            #region Изменения шрифта            

            _InfoPlaneLabelTextPatchAdded.Typeface = font;
            _InfoPlaneLabelTextFirstFlyYear.Typeface = font;
            _InfoPlaneLabelTextBombLoad.Typeface = font;
            _InfoPlaneLabelTextHandingWeapon.Typeface = font;
            _InfoPlaneLabelTextBR.Typeface = font;
            _InfoPlaneLabelTextType.Typeface = font;
            _InfoPlaneLabelTextMaxSpeedAt0.Typeface = font;
            _InfoPlaneLabelTextMaxSpeedAt5000.Typeface = font;
            _InfoPlaneLabelTextTurnAt0.Typeface = font;
            _InfoPlaneLabelTextClimb.Typeface = font;
            _InfoPlaneLabelTextEnginePower.Typeface = font;
            _InfoPlaneLabelTextWeight.Typeface = font;
            _InfoPlaneLabelTextThrustToWeightRatio.Typeface = font;
            _InfoPlaneLabelTextWeaponVolleyPerSecond.Typeface = font;
            _InfoPlaneLabelTextPlaneCharacter.Typeface = font;
            _InfoPlaneTextWeaponAndTurrels.Typeface = font;
            _InfoPlaneLabelTextFlutter.Typeface = font;
            #endregion

            #region Изменения цвета текста всех TextView


            _InfoPlaneTextPatchAdded.SetTextColor(Color.Black);
            _InfoPlaneTextFirstFlyYear.SetTextColor(Color.Black);
            _InfoPlaneTextBombLoad.SetTextColor(Color.Black);
            _InfoPlaneTextBR.SetTextColor(Color.Black);
            _InfoPlaneTextType.SetTextColor(Color.Black);
            _InfoPlaneTextMaxSpeedAt0.SetTextColor(Color.Black);
            _InfoPlaneTextMaxSpeedAt5000.SetTextColor(Color.Black);
            _InfoPlaneTextTurnAt0.SetTextColor(Color.Black);
            _InfoPlaneTextClimb.SetTextColor(Color.Black);
            _InfoPlaneTextEnginePower.SetTextColor(Color.Black);
            _InfoPlaneTextWeight.SetTextColor(Color.Black);
            _InfoPlaneTextThrustToWeightRatio.SetTextColor(Color.Black);
            _InfoPlaneTextWeaponVolleyPerSecond.SetTextColor(Color.Black);
            _InfoPlaneTextFlutter.SetTextColor(Color.Black);







            _InfoPlaneTextWeaponAndTurrels.SetTextColor(Color.Black);
            _InfoPlaneTextPlaneCharacter.SetTextColor(Color.Black);

            _InfoPlaneLabelTextPatchAdded.SetTextColor(Color.Black);
            _InfoPlaneLabelTextFirstFlyYear.SetTextColor(Color.Black);
            _InfoPlaneLabelTextBombLoad.SetTextColor(Color.Black);
            _InfoPlaneLabelTextHandingWeapon.SetTextColor(Color.Black);
            _InfoPlaneLabelTextBR.SetTextColor(Color.Black);
            _InfoPlaneLabelTextType.SetTextColor(Color.Black);
            _InfoPlaneLabelTextMaxSpeedAt0.SetTextColor(Color.Black);
            _InfoPlaneLabelTextMaxSpeedAt5000.SetTextColor(Color.Black);
            _InfoPlaneLabelTextTurnAt0.SetTextColor(Color.Black);
            _InfoPlaneLabelTextClimb.SetTextColor(Color.Black);
            _InfoPlaneLabelTextEnginePower.SetTextColor(Color.Black);
            _InfoPlaneLabelTextWeight.SetTextColor(Color.Black);
            _InfoPlaneLabelTextThrustToWeightRatio.SetTextColor(Color.Black);
            _InfoPlaneLabelTextWeaponVolleyPerSecond.SetTextColor(Color.Black);
            _InfoPlaneLabelTextPlaneCharacter.SetTextColor(Color.Black);
            _InfoPlaneLabelTextFlutter.SetTextColor(Color.Black);

            #endregion

            nations = NationCollection.GetNation();
            AdapterNation = new NationAdapter(this, nations);
            _InfoSpinnerNation.Adapter = AdapterNation;
            _InfoSpinnerNation.SetSelection(1);  //Автовыбор
            selectedNation = 1;   //Автовыбор

            ranks = RankCollection.GetRank();
            AdapterRank = new RankAdapter(this, ranks);
            _InfoSpinnerRank.Adapter = AdapterRank;
            _InfoSpinnerRank.SetSelection(6);   //Автовыбор
            selectedRank = 6;   //Автовыбор

            potentialTaskPlane = TaskCollection.GetTask();
            PotentialAdapterTaskPlane = new TaskAdapter(this, potentialTaskPlane);
            _InfoSpinnerPotentialEnemyPlane.Adapter = PotentialAdapterTaskPlane;
            _InfoSpinnerPotentialEnemyPlane.SetSelection(0);  //Автовыбор
            SelectedPotentialTaskPlane = 0; //Автовыбор

            _InfoSpinnerPlane.SetSelection(7);
            //Объявление коллекции наций, рангов и адаптеров

            _InfoSpinnerNation.ItemSelected += _InfoSpinnerNation_ItemSelected;
            _InfoSpinnerRank.ItemSelected += _InfoSpinnerRank_ItemSelected;
            _InfoSpinnerPlane.ItemSelected += _InfoSpinnerPlane_ItemSelected;
            _InfoSpinnerPotentialEnemyPlane.ItemSelected += _InfoSpinnerPotentialEnemyPlane_ItemSelected;
            //События спиннеров
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


        private void _InfoSpinnerPotentialEnemyPlane_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            SelectedPotentialTaskPlane = potentialTaskPlane[e.Position].Id;
            TaskSelector();
        }

        private void TaskSelector()
        {
            if (SelectedPotentialTaskPlane == 1)
            { 
               List<Plane> planesAll = PlaneCollection.GetPlane();
               double step = 1.0;
               var planevar = from p in planesAll
                           where p.BR <= selectedPlaneBR + step && p.BR >= selectedPlaneBR - step && p.NationId != selectedNation
                           orderby p.MaxSpeedAt0 descending
                           select p;
               planespotential = planevar.ToList<Plane>();
               AdapterListView = new ListViewInfoAdapter(this, planespotential);
               _InfoListView.Adapter = AdapterListView;
            }

            if (SelectedPotentialTaskPlane == 2)
            {
                List<Plane> planesAll = PlaneCollection.GetPlane();
                double step = 1.0;
                var planevar = from p in planesAll
                               where p.BR <= selectedPlaneBR + step && p.BR >= selectedPlaneBR - step && p.NationId != selectedNation
                               orderby p.MaxSpeedAt5000 descending
                               select p;
                planespotential = planevar.ToList<Plane>();
                AdapterListView = new ListViewInfoAdapter(this, planespotential);
                _InfoListView.Adapter = AdapterListView;
            }

            if (SelectedPotentialTaskPlane == 3)
            {
                List<Plane> planesAll = PlaneCollection.GetPlane();
                double step = 1.0;
                var planevar = from p in planesAll
                               where p.BR <= selectedPlaneBR + step && p.BR >= selectedPlaneBR - step && p.NationId != selectedNation
                               orderby p.Climb ascending
                               select p;
                planespotential = planevar.ToList<Plane>();
                AdapterListView = new ListViewInfoAdapter(this, planespotential);
                _InfoListView.Adapter = AdapterListView;
            }

            if (SelectedPotentialTaskPlane == 4)
            {
                List<Plane> planesAll = PlaneCollection.GetPlane();
                double step = 1.0;
                var planevar = from p in planesAll
                               where p.BR <= selectedPlaneBR + step && p.BR >= selectedPlaneBR - step && p.NationId != selectedNation
                               orderby p.TurnAt0 ascending
                               select p;
                planespotential = planevar.ToList<Plane>();
                AdapterListView = new ListViewInfoAdapter(this, planespotential);
                _InfoListView.Adapter = AdapterListView;
            }

            if (SelectedPotentialTaskPlane == 5)
            {
                List<Plane> planesAll = PlaneCollection.GetPlane();
                double step = 1.0;
                var planevar = from p in planesAll
                               where p.BR <= selectedPlaneBR + step && p.BR >= selectedPlaneBR - step && p.NationId != selectedNation
                               orderby p.BombLoad descending
                               select p;
                planespotential = planevar.ToList<Plane>();
                AdapterListView = new ListViewInfoAdapter(this, planespotential);
                _InfoListView.Adapter = AdapterListView;
            }

            if (SelectedPotentialTaskPlane == 6)
            {
                List<Plane> planesAll = PlaneCollection.GetPlane();
                double step = 1.0;
                var planevar = from p in planesAll
                               where p.BR <= selectedPlaneBR + step && p.BR >= selectedPlaneBR - step && p.NationId != selectedNation
                               orderby p.ThrustToWeightRatio descending
                               select p;
                planespotential = planevar.ToList<Plane>();
                AdapterListView = new ListViewInfoAdapter(this, planespotential);
                _InfoListView.Adapter = AdapterListView;
            }

            if (SelectedPotentialTaskPlane == 7)
            {
                List<Plane> planesAll = PlaneCollection.GetPlane();
                double step = 1.0;
                var planevar = from p in planesAll
                               where p.BR <= selectedPlaneBR + step && p.BR >= selectedPlaneBR - step && p.NationId != selectedNation
                               orderby p.WeaponVolleyPerSecond descending
                               select p;
                planespotential = planevar.ToList<Plane>();
                AdapterListView = new ListViewInfoAdapter(this, planespotential);
                _InfoListView.Adapter = AdapterListView;
            }
        }

        private void _InfoSpinnerNation_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedNation = nations[e.Position].Id;


            if (selectedNation == 100 && selectedRank == 100)
            {
                planes = PlaneCollection.GetPlane();
                AdapterPlane = new PlaneAdapter(this, planes);
                _InfoSpinnerPlane.Adapter = AdapterPlane;
            } else
            if (selectedNation == 100)
            {
                List<Plane> planesAll = PlaneCollection.GetPlane();
                var planevar = from p in planesAll
                               where p.RankId == selectedRank
                               select p;
                planes = planevar.ToList<Plane>();
                AdapterPlane = new PlaneAdapter(this, planes);
                _InfoSpinnerPlane.Adapter = AdapterPlane;
            }else
            if (selectedRank == 100)
            {
                List<Plane> planesAll = PlaneCollection.GetPlane();
                var planevar = from p in planesAll
                               where p.NationId == selectedNation
                               select p;
                planes = planevar.ToList<Plane>();
                AdapterPlane = new PlaneAdapter(this, planes);
                _InfoSpinnerPlane.Adapter = AdapterPlane;
            }
            else
            {

                planes = PlaneSelector(selectedNation, selectedRank);
                AdapterPlane = new PlaneAdapter(this, planes);
                _InfoSpinnerPlane.Adapter = AdapterPlane;
            }
        }

        private void _InfoSpinnerRank_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedRank = ranks[e.Position].Id;


            if (selectedNation == 100 && selectedRank == 100)
            {
                planes = PlaneCollection.GetPlane();
                AdapterPlane = new PlaneAdapter(this, planes);
                _InfoSpinnerPlane.Adapter = AdapterPlane;
            }
            else
    if (selectedNation == 100)
            {
                List<Plane> planesAll = PlaneCollection.GetPlane();
                var planevar = from p in planesAll
                               where p.RankId == selectedRank
                               select p;
                planes = planevar.ToList<Plane>();
                AdapterPlane = new PlaneAdapter(this, planes);
                _InfoSpinnerPlane.Adapter = AdapterPlane;
            }
            else
    if (selectedRank == 100)
            {
                List<Plane> planesAll = PlaneCollection.GetPlane();
                var planevar = from p in planesAll
                               where p.NationId == selectedNation
                               select p;
                planes = planevar.ToList<Plane>();
                AdapterPlane = new PlaneAdapter(this, planes);
                _InfoSpinnerPlane.Adapter = AdapterPlane;
            }
            else
            {

                planes = PlaneSelector(selectedNation, selectedRank);
                AdapterPlane = new PlaneAdapter(this, planes);
                _InfoSpinnerPlane.Adapter = AdapterPlane;
            }
        }

        private void _InfoSpinnerPlane_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedPlaneBR = planes[e.Position].BR;
            selectedRankID = planes[e.Position].RankId;
            bombExiste = planes[e.Position].HandingBomb;
            rocketExiste = planes[e.Position].HandingRocket;
            cannonExiste = planes[e.Position].HandingCannon;
            torpedoExiste = planes[e.Position].HandingTorpedo;
            airToAirExiste = planes[e.Position].HandingAirToAir;
            airToGroundExiste = planes[e.Position].HandingAirToGround;
            _InfoImage.SetImageResource(planes[e.Position].Image);
            _InfoFlag.SetImageResource(planes[e.Position].FlagImage);

            _InfoPlaneTextPatchAdded.SetText(planes[e.Position].PatchAdded.ToString(), TextView.BufferType.Normal);
            _InfoPlaneTextFirstFlyYear.SetText(planes[e.Position].FirstFlyYear.ToString()+ context.Resources.GetString(Resource.String.AbbrYear), TextView.BufferType.Normal);
            _InfoPlaneTextBR.SetText(planes[e.Position].BR.ToString("0.0#"), TextView.BufferType.Normal);
            _InfoPlaneTextType.SetText(planes[e.Position].Type, TextView.BufferType.Normal);
            _InfoPlaneTextTurnAt0.SetText(planes[e.Position].TurnAt0.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            //_InfoPlaneTextClimb.SetText(planes[e.Position].Climb.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            int newClimb = planes[e.Position].Climb;
            TimeSpan timeSpan = TimeSpan.FromSeconds(newClimb);
            string climbToShow = timeSpan.ToString(@"mm\:ss");
            _InfoPlaneTextClimb.SetText(climbToShow, TextView.BufferType.Normal);
            //
            _InfoPlaneTextWeaponAndTurrels.SetText(planes[e.Position].WeaponAndTurrels, TextView.BufferType.Normal);
            _InfoPlaneTextPlaneCharacter.SetText(planes[e.Position].PlaneCharacter, TextView.BufferType.Normal);

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            ISharedPreferencesEditor editor = prefs.Edit();
            var switchchecked = prefs.GetBoolean("key_kmhtomph", false);
            if (switchchecked)
            {
                var weight = planes[e.Position].Weight * 0.00110231131;
                var mphSpeedAt0 = planes[e.Position].MaxSpeedAt0 * 0.621371192;
                var mphSpeedAt5000 = planes[e.Position].MaxSpeedAt5000 * 0.621371192;
                var payload = planes[e.Position].BombLoad * 2.204622621849;
                var burstmass = planes[e.Position].WeaponVolleyPerSecond * 2.204622621849;
                var flutter= planes[e.Position].Flutter * 0.621371192;
                weight = Math.Round(weight, 1);
                mphSpeedAt0 = Math.Round(mphSpeedAt0, 0);
                mphSpeedAt5000 = Math.Round(mphSpeedAt5000, 0);
                payload = Math.Round(payload, 0);
                burstmass = Math.Round(burstmass, 2);
                flutter = Math.Round(flutter, 0);

                _InfoPlaneLabelTextClimb.SetText(context.Resources.GetString(Resource.String.PlaneClimbFeet), TextView.BufferType.Normal);

                _InfoPlaneTextWeight.SetText(weight + context.Resources.GetString(Resource.String.AbbrST), TextView.BufferType.Normal);
                _InfoPlaneTextMaxSpeedAt0.SetText(mphSpeedAt0 + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _InfoPlaneTextMaxSpeedAt5000.SetText(mphSpeedAt5000 + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _InfoPlaneTextBombLoad.SetText(payload + context.Resources.GetString(Resource.String.AbbrLB), TextView.BufferType.Normal);
                _InfoPlaneTextWeaponVolleyPerSecond.SetText(burstmass + context.Resources.GetString(Resource.String.AbbrLB_S), TextView.BufferType.Normal);
                _InfoPlaneTextFlutter.SetText( flutter + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                if (selectedRankID == 5)
                {
                    var enginePower = planes[e.Position].EnginePower* 2.204622621849;
                    enginePower= Math.Round(enginePower, 0);

                    _InfoPlaneTextEnginePower.SetText(enginePower + context.Resources.GetString(Resource.String.AbbrLBF), TextView.BufferType.Normal);
                    _InfoPlaneTextThrustToWeightRatio.SetText(planes[e.Position].ThrustToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrLBF_LB), TextView.BufferType.Normal);
                }
                else
                if (selectedRankID == 6)
                {
                    var enginePower = planes[e.Position].EnginePower * 2.204622621849;
                    enginePower = Math.Round(enginePower, 0);

                    _InfoPlaneTextEnginePower.SetText(enginePower + context.Resources.GetString(Resource.String.AbbrLBF), TextView.BufferType.Normal);
                    _InfoPlaneTextThrustToWeightRatio.SetText(planes[e.Position].ThrustToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrLBF_LB), TextView.BufferType.Normal);

                }
                else
                {
                    var thrustToWeight= planes[e.Position].ThrustToWeightRatio/2.204622621849;
                    thrustToWeight = Math.Round(thrustToWeight, 2);
                    _InfoPlaneTextEnginePower.SetText(planes[e.Position].EnginePower.ToString() + context.Resources.GetString(Resource.String.AbbrH_P), TextView.BufferType.Normal);
                    _InfoPlaneTextThrustToWeightRatio.SetText(thrustToWeight + context.Resources.GetString(Resource.String.AbbrHP_LB), TextView.BufferType.Normal);
                }
                //
            }
            else
            {
                _InfoPlaneLabelTextClimb.SetText(context.Resources.GetString(Resource.String.PlaneClimb), TextView.BufferType.Normal);

                _InfoPlaneTextWeight.SetText(planes[e.Position].Weight.ToString() + context.Resources.GetString(Resource.String.AbbrKG), TextView.BufferType.Normal);
                _InfoPlaneTextMaxSpeedAt0.SetText(planes[e.Position].MaxSpeedAt0.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _InfoPlaneTextMaxSpeedAt5000.SetText(planes[e.Position].MaxSpeedAt5000.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _InfoPlaneTextBombLoad.SetText(planes[e.Position].BombLoad.ToString() + context.Resources.GetString(Resource.String.AbbrKG), TextView.BufferType.Normal);
                _InfoPlaneTextWeaponVolleyPerSecond.SetText(planes[e.Position].WeaponVolleyPerSecond.ToString() + context.Resources.GetString(Resource.String.AbbrKG_S), TextView.BufferType.Normal);              
                //
                _InfoPlaneTextFlutter.SetText(planes[e.Position].Flutter.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                if (selectedRankID == 5)
                {
                    _InfoPlaneTextEnginePower.SetText(planes[e.Position].EnginePower.ToString() + context.Resources.GetString(Resource.String.AbbrKGS), TextView.BufferType.Normal);
                    _InfoPlaneTextThrustToWeightRatio.SetText(planes[e.Position].ThrustToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrKGS_KG), TextView.BufferType.Normal);
                }
                else
                if (selectedRankID == 6)
                {
                    _InfoPlaneTextEnginePower.SetText(planes[e.Position].EnginePower.ToString() + context.Resources.GetString(Resource.String.AbbrKGS), TextView.BufferType.Normal);
                    _InfoPlaneTextThrustToWeightRatio.SetText(planes[e.Position].ThrustToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrKGS_KG), TextView.BufferType.Normal);
                }
                else
                {
                    _InfoPlaneTextEnginePower.SetText(planes[e.Position].EnginePower.ToString() + context.Resources.GetString(Resource.String.AbbrH_P), TextView.BufferType.Normal);
                    _InfoPlaneTextThrustToWeightRatio.SetText(planes[e.Position].ThrustToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrH_P_KG), TextView.BufferType.Normal);
                }
                //
            }

            PlaneHandingWeaponShower();
            TaskSelector();
           
        }

        public List<Plane> PlaneSelector(int selectedNation, int selectedRank)
        {
            this.selectedNation = selectedNation;
            this.selectedRank = selectedRank;

            List<Plane> planesAll = PlaneCollection.GetPlane();
            var planevar = from p in planesAll
                           where p.NationId == selectedNation
                           where p.RankId == selectedRank
                           select p;
            return planevar.ToList<Plane>();
        }
                
        public void PlaneHandingWeaponShower()
        {
            if (bombExiste == true)
            {
                _InfoHandlingBomb.SetImageResource(Resource.Drawable._handingBomb);
            }
            else
            {
                _InfoHandlingBomb.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (rocketExiste == true)
            {
                _InfoHandlingRocket.SetImageResource(Resource.Drawable._handingRocket);
            }
            else
            {
                _InfoHandlingRocket.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (airToAirExiste == true)
            {
                _InfoHandlingAirToAir.SetImageResource(Resource.Drawable._handingAirToAir);
            }
            else
            {
                _InfoHandlingAirToAir.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (airToGroundExiste == true)
            {
                _InfoHandlingAirToGround.SetImageResource(Resource.Drawable._handingAGM);
            }
            else
            {
                _InfoHandlingAirToGround.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (cannonExiste == true)
            {
                _InfoHandlingCannon.SetImageResource(Resource.Drawable._handingCannon);
            }
            else
            {
                _InfoHandlingCannon.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (torpedoExiste == true)
            {
                _InfoHandlingTorpedo.SetImageResource(Resource.Drawable._handingTorpedo);
            }
            else
            {
                _InfoHandlingTorpedo.SetImageResource(Resource.Drawable._handingTransparent);
            }
        }
    }
}