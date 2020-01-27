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
    class InfoHeli:AppCompatActivity
    {
        Spinner _InfoSpinnerNation;
        Spinner _InfoSpinnerHeli;
        Spinner _InfoSpinnerRank;
        ListView _InfoListView;
        Spinner _InfoSpinnerPotentialEnemyHeli;
        TaskAdapter PotentialAdapterTaskHeli;
        //Объявление  спиннеров и скролов с XAML

        #region Объявление всех Textview
        Context context;
        ImageView _InfoImage;
        ImageView _InfoFlag;
        ImageView _InfoHandlingAGM;
        ImageView _InfoHandlingCannon;
        ImageView _InfoHandlingBomb;
        ImageView _InfoHandlingASM;
        ImageView _InfoHandlingAirToAir;
        ImageView _InfoIRCM;
        ImageView _InfoFlares;
        ImageView _InfoHIRSS;


        TextView _InfoHeliTextFirstFlyYear;
        TextView _InfoHeliTextPatchAdded;
        TextView _InfoHeliTextType;
        TextView _InfoHeliTextCharacter;
        TextView _InfoHeliTextBR;
        TextView _InfoHeliTextMaxSpeed;
        TextView _InfoHeliTextClimbTo1000;
        TextView _InfoHeliTextTurn360;
        TextView _InfoHeliTextEnginePower;
        TextView _InfoHeliTextWeight;
        TextView _InfoHeliTextThrustToWeightRatio;
        TextView _InfoHeliTextAGMCount;
        TextView _InfoHeliTextAGMArmorPenetration;
        TextView _InfoHeliTextAGMSpeed;
        TextView _InfoHeliTextAGMRange;
        TextView _InfoHeliTextASMCount;
        TextView _InfoHeliTextASMArmorPenetration;
        TextView _InfoHeliTextASMSpeed;
        TextView _InfoHeliTextBombLoad;
        TextView _InfoHeliOffensiveWeapon;
        TextView _InfoHeliSuspensionWeapon;

        TextView _InfoHeliLabelTextFirstFlyYear;
        TextView _InfoHeliLabelTextPatchAdded;
        TextView _InfoHeliLabelTextType;
        TextView _InfoHeliLabelTextCharacter;
        TextView _InfoHeliLabelTextBR;
        TextView _InfoHeliLabelTextMaxSpeed;
        TextView _InfoHeliLabelTextClimbTo1000;
        TextView _InfoHeliLabelTextTurn360;
        TextView _InfoHeliLabelTextEnginePower;
        TextView _InfoHeliLabelTextWeight;
        TextView _InfoHeliLabelTextThrustToWeightRatio;
        TextView _InfoHeliLabelTextAGMCount;
        TextView _InfoHeliLabelTextAGMArmorPenetration;
        TextView _InfoHeliLabelTextAGMSpeed;
        TextView _InfoHeliLabelTextAGMRange;
        TextView _InfoHeliLabelTextASMCount;
        TextView _InfoHeliLabelTextASMArmorPenetration;
        TextView _InfoHeliLabelTextASMSpeed;
        TextView _InfoHeliLabelTextBombLoad;
        TextView _InfoHeliLabelOffensiveWeapon;
        TextView _InfoHeliLabelSuspensionWeapon;
        TextView _InfoHeliLabelTextHandingWeapon;
        TextView _InfoHeliLabelDefence;
        #endregion

        List<Heli> helis;
        List<Heli> helispotential;
        HeliAdapter AdapterHeli;
        List<Nation> nations;
        NationAdapter AdapterNation;
        List<Rank> ranks;
        public List<Task> potentialTask;
        RankAdapter AdapterRank;
        ListViewInfoHeliAdapter AdapterListView;

        private bool AGMExiste;
        private bool ASMExiste;
        private bool CannonExiste;
        private bool BombExiste;
        private  bool HandlingAirToAir;
        private  bool IRCM;
        private  bool Flares;
        private  bool HIRSS;


        private int selectedNation;
        private int selectedRank;
        private double selectedHeliBR;
        public static int SelectedPotentialTaskHeli;
        // Объявление адаптеров, коллекций и переменных      
        
        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\
        DrawerLayout drawerLayout;
        

        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\
        public InfoHeli()
        {

        }

        protected InfoHeli(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.InfoHeli);
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
            var adView = FindViewById<AdView>(Resource.Id.adViewInfoHeli);
                var adRequest = new AdRequest.Builder().Build();
               adView.LoadAd(adRequest);
           // var requestbuilder = new AdRequest.Builder().AddTestDevice("D0BE22F1A4BE27C7470F95A699568FE2"); 
            //adView.LoadAd(requestbuilder.Build());
            //шрифт
            var font = Typeface.CreateFromAsset(Assets, "dinfont.ttf");

            _InfoSpinnerNation = FindViewById<Spinner>(Resource.Id.InfoSpinnerNationH);
            _InfoSpinnerRank = FindViewById<Spinner>(Resource.Id.InfoSpinnerRankH);
            _InfoSpinnerHeli = FindViewById<Spinner>(Resource.Id.InfoSpinnerHeli);
            _InfoListView = FindViewById<ListView>(Resource.Id.listViewH);
            _InfoSpinnerPotentialEnemyHeli = FindViewById<Spinner>(Resource.Id.InfoSpinnerPotentialEnemyHeli);
            //Привязка спиннеров к шарп коду

            #region Привязка TextView к коду
            _InfoImage = FindViewById<ImageView>(Resource.Id.InfoImageH);
            _InfoFlag = FindViewById<ImageView>(Resource.Id.InfoFlagH);
            _InfoHandlingAGM = FindViewById<ImageView>(Resource.Id.InfoHeliHandlingAGMRocket);
            _InfoHandlingASM = FindViewById<ImageView>(Resource.Id.InfoHeliHandlingASMRocket);
            _InfoHandlingCannon = FindViewById<ImageView>(Resource.Id.InfoHeliHandlingCannon);
            _InfoHandlingBomb= FindViewById<ImageView>(Resource.Id.InfoHeliHandlingBomb);
             _InfoHandlingAirToAir= FindViewById<ImageView>(Resource.Id.InfoHeliHandlingAirToAir);
             _InfoIRCM= FindViewById<ImageView>(Resource.Id.InfoHeliIRCM);
             _InfoFlares= FindViewById<ImageView>(Resource.Id.InfoHeliFlares);
             _InfoHIRSS= FindViewById<ImageView>(Resource.Id.InfoHeliHIRSS);

            _InfoHeliLabelTextFirstFlyYear = FindViewById<TextView>(Resource.Id.InfoHeliLabelTextFirstFlyYear);
            _InfoHeliLabelTextPatchAdded = FindViewById<TextView>(Resource.Id.InfoHeliLabelTextPatchAdded);
            _InfoHeliLabelTextType = FindViewById<TextView>(Resource.Id.InfoHeliLabelTextType);
            _InfoHeliLabelTextCharacter = FindViewById<TextView>(Resource.Id.InfoHeliLabelTextCharacter);
            _InfoHeliLabelTextBR = FindViewById<TextView>(Resource.Id.InfoHeliLabelTextBR);
            _InfoHeliLabelTextMaxSpeed = FindViewById<TextView>(Resource.Id.InfoHeliLabelMaxSpeed);
            _InfoHeliLabelTextClimbTo1000 = FindViewById<TextView>(Resource.Id.InfoHeliLabelTextClimbTo1000);
            _InfoHeliLabelTextTurn360 = FindViewById<TextView>(Resource.Id.InfoHeliLabelTextTurn360);
            _InfoHeliLabelTextEnginePower = FindViewById<TextView>(Resource.Id.InfoHeliLabelTextEnginePower);
            _InfoHeliLabelTextWeight = FindViewById<TextView>(Resource.Id.InfoHeliLabelWeight);
            _InfoHeliLabelTextThrustToWeightRatio = FindViewById<TextView>(Resource.Id.InfoHeliLabelTextThrustToWeightRatio);
            _InfoHeliLabelTextAGMCount = FindViewById<TextView>(Resource.Id.InfoHeliLabelTextAGMCount);
            _InfoHeliLabelTextAGMArmorPenetration = FindViewById<TextView>(Resource.Id.InfoHeliLabelAGMArmorPenetration);
            _InfoHeliLabelTextAGMSpeed = FindViewById<TextView>(Resource.Id.InfoHeliLabelTextAGMSpeed);
            _InfoHeliLabelTextAGMRange = FindViewById<TextView>(Resource.Id.InfoHeliLabelTextAGMRange);
            _InfoHeliLabelTextASMCount = FindViewById<TextView>(Resource.Id.InfoHeliLabelTextASMCount);
            _InfoHeliLabelTextASMArmorPenetration = FindViewById<TextView>(Resource.Id.InfoHeliLabelTextASMArmorPenetration);
            _InfoHeliLabelTextASMSpeed = FindViewById<TextView>(Resource.Id.InfoHeliLabelTextASMSpeed);
            _InfoHeliLabelTextBombLoad = FindViewById<TextView>(Resource.Id.InfoHeliLabelTextBombLoad);
            _InfoHeliLabelOffensiveWeapon = FindViewById<TextView>(Resource.Id.InfoHeliLabelTextOffensiveWeapon);
            _InfoHeliLabelSuspensionWeapon = FindViewById<TextView>(Resource.Id.InfoHeliLabelTextHeliSuspensionWeapon);
             _InfoHeliLabelTextHandingWeapon = FindViewById<TextView>(Resource.Id.InfoHeliLabelTextHandingWeapon);
            _InfoHeliLabelDefence = FindViewById<TextView>(Resource.Id.InfoHeliLabelDefence);

            _InfoHeliTextFirstFlyYear = FindViewById<TextView>(Resource.Id.InfoHeliFirstFlyYear);
            _InfoHeliTextPatchAdded = FindViewById<TextView>(Resource.Id.InfoHeliTextPatchAdded);
            _InfoHeliTextType = FindViewById<TextView>(Resource.Id.InfoHeliTextType);
            _InfoHeliTextCharacter = FindViewById<TextView>(Resource.Id.InfoHeliTextCharacter);
            _InfoHeliTextBR = FindViewById<TextView>(Resource.Id.InfoHeliTextBR);
            _InfoHeliTextMaxSpeed = FindViewById<TextView>(Resource.Id.InfoHeliTextMaxSpeed);
            _InfoHeliTextClimbTo1000 = FindViewById<TextView>(Resource.Id.InfoHeliTextClimbTo1000);
            _InfoHeliTextTurn360 = FindViewById<TextView>(Resource.Id.InfoHeliTextTurn360);
            _InfoHeliTextEnginePower = FindViewById<TextView>(Resource.Id.InfoHeliTextEnginePower);
            _InfoHeliTextWeight = FindViewById<TextView>(Resource.Id.InfoHeliTextWeight);
            _InfoHeliTextThrustToWeightRatio = FindViewById<TextView>(Resource.Id.InfoHeliTextThrustToWeightRatio);
            _InfoHeliTextAGMCount = FindViewById<TextView>(Resource.Id.InfoHeliTextAGMCount);
            _InfoHeliTextAGMArmorPenetration = FindViewById<TextView>(Resource.Id.InfoHeliTextAGMArmorPenetration);
            _InfoHeliTextAGMSpeed = FindViewById<TextView>(Resource.Id.InfoHeliTextAGMSpeed);
            _InfoHeliTextAGMRange = FindViewById<TextView>(Resource.Id.InfoHeliTextAGMRange);
            _InfoHeliTextASMCount = FindViewById<TextView>(Resource.Id.InfoHeliTextASMCount);
            _InfoHeliTextASMArmorPenetration = FindViewById<TextView>(Resource.Id.InfoHeliTextASMArmorPenetration);
            _InfoHeliTextASMSpeed = FindViewById<TextView>(Resource.Id.InfoHeliTextASMSpeed);
            _InfoHeliTextBombLoad = FindViewById<TextView>(Resource.Id.InfoHeliTextBombLoad);
            _InfoHeliOffensiveWeapon = FindViewById<TextView>(Resource.Id.InfoHeliTextOffensiveWeapon);
            _InfoHeliSuspensionWeapon = FindViewById<TextView>(Resource.Id.InfoHeliTextHeliSuspensionWeapon);
            #endregion

            #region Изменения шрифта 

            _InfoHeliLabelTextFirstFlyYear.Typeface=font;
            _InfoHeliLabelTextPatchAdded.Typeface=font;
            _InfoHeliLabelTextType.Typeface=font;
            _InfoHeliLabelTextCharacter.Typeface=font;
            _InfoHeliLabelTextBR.Typeface=font;
            _InfoHeliLabelTextMaxSpeed.Typeface=font;
            _InfoHeliLabelTextClimbTo1000.Typeface=font;
            _InfoHeliLabelTextTurn360.Typeface=font;
            _InfoHeliLabelTextEnginePower.Typeface=font;
            _InfoHeliLabelTextWeight.Typeface=font;
            _InfoHeliLabelTextThrustToWeightRatio.Typeface=font;
            _InfoHeliLabelTextAGMCount.Typeface=font;
            _InfoHeliLabelTextAGMArmorPenetration.Typeface=font;
            _InfoHeliLabelTextAGMSpeed.Typeface=font;
            _InfoHeliLabelTextAGMRange.Typeface=font;
            _InfoHeliLabelTextASMCount.Typeface=font;
            _InfoHeliLabelTextASMArmorPenetration.Typeface=font;
            _InfoHeliLabelTextASMSpeed.Typeface=font;
            _InfoHeliLabelTextBombLoad.Typeface=font;
            _InfoHeliLabelOffensiveWeapon.Typeface=font;
            _InfoHeliLabelSuspensionWeapon.Typeface=font;
            _InfoHeliLabelTextHandingWeapon.Typeface = font;
            _InfoHeliLabelDefence.Typeface = font;
            #endregion

            #region Изменения цвета текста всех TextView

            _InfoHeliTextFirstFlyYear.SetTextColor(Color.Black);
            _InfoHeliTextPatchAdded.SetTextColor(Color.Black);
            _InfoHeliTextType.SetTextColor(Color.Black);
            _InfoHeliTextCharacter.SetTextColor(Color.Black);
            _InfoHeliTextBR.SetTextColor(Color.Black);
            _InfoHeliTextMaxSpeed.SetTextColor(Color.Black);
            _InfoHeliTextClimbTo1000.SetTextColor(Color.Black);
            _InfoHeliTextTurn360.SetTextColor(Color.Black);
            _InfoHeliTextEnginePower.SetTextColor(Color.Black);
            _InfoHeliTextWeight.SetTextColor(Color.Black);
            _InfoHeliTextThrustToWeightRatio.SetTextColor(Color.Black);
            _InfoHeliTextAGMCount.SetTextColor(Color.Black);
            _InfoHeliTextAGMArmorPenetration.SetTextColor(Color.Black);
            _InfoHeliTextAGMSpeed.SetTextColor(Color.Black);
            _InfoHeliTextAGMRange.SetTextColor(Color.Black);
            _InfoHeliTextASMCount.SetTextColor(Color.Black);
            _InfoHeliTextASMArmorPenetration.SetTextColor(Color.Black);
            _InfoHeliTextASMSpeed.SetTextColor(Color.Black);
            _InfoHeliTextBombLoad.SetTextColor(Color.Black);
            _InfoHeliOffensiveWeapon.SetTextColor(Color.Black);
            _InfoHeliSuspensionWeapon.SetTextColor(Color.Black);


            _InfoHeliLabelTextFirstFlyYear.SetTextColor(Color.Black);
            _InfoHeliLabelTextPatchAdded.SetTextColor(Color.Black);
            _InfoHeliLabelTextType.SetTextColor(Color.Black);
            _InfoHeliLabelTextCharacter.SetTextColor(Color.Black);
            _InfoHeliLabelTextBR.SetTextColor(Color.Black);
            _InfoHeliLabelTextMaxSpeed.SetTextColor(Color.Black);
            _InfoHeliLabelTextClimbTo1000.SetTextColor(Color.Black);
            _InfoHeliLabelTextTurn360.SetTextColor(Color.Black);
            _InfoHeliLabelTextEnginePower.SetTextColor(Color.Black);
            _InfoHeliLabelTextWeight.SetTextColor(Color.Black);
            _InfoHeliLabelTextThrustToWeightRatio.SetTextColor(Color.Black);
            _InfoHeliLabelTextAGMCount.SetTextColor(Color.Black);
            _InfoHeliLabelTextAGMArmorPenetration.SetTextColor(Color.Black);
            _InfoHeliLabelTextAGMSpeed.SetTextColor(Color.Black);
            _InfoHeliLabelTextAGMRange.SetTextColor(Color.Black);
            _InfoHeliLabelTextASMCount.SetTextColor(Color.Black);
            _InfoHeliLabelTextASMArmorPenetration.SetTextColor(Color.Black);
            _InfoHeliLabelTextASMSpeed.SetTextColor(Color.Black);
            _InfoHeliLabelTextBombLoad.SetTextColor(Color.Black);


            #endregion

            nations = NationCollection.GetNation();
            AdapterNation = new NationAdapter(this, nations);
            _InfoSpinnerNation.Adapter = AdapterNation;
            _InfoSpinnerNation.SetSelection(7);  //Автовыбор
            selectedNation = 7;   //Автовыбор

            ranks = RankCollection.GetRank();
            AdapterRank = new RankAdapter(this, ranks);
            _InfoSpinnerRank.Adapter = AdapterRank;
            _InfoSpinnerRank.SetSelection(6);   //Автовыбор
            selectedRank = 6;   //Автовыбор

            potentialTask = HeliTaskCollection.GetTask();
            PotentialAdapterTaskHeli = new TaskAdapter(this, potentialTask);
            _InfoSpinnerPotentialEnemyHeli.Adapter = PotentialAdapterTaskHeli;
            _InfoSpinnerPotentialEnemyHeli.SetSelection(0); //Автовыбор
            SelectedPotentialTaskHeli = 0; //Автовыбор

            _InfoSpinnerHeli.SetSelection(1);
            //Объявление коллекции наций, рангов и адаптеров

            _InfoSpinnerNation.ItemSelected += _InfoSpinnerNation_ItemSelected;
            _InfoSpinnerRank.ItemSelected += _InfoSpinnerRank_ItemSelected;
            _InfoSpinnerHeli.ItemSelected += _InfoSpinnerHeli_ItemSelected;
            _InfoSpinnerPotentialEnemyHeli.ItemSelected += _InfoSpinnerPotentialEnemyHeli_ItemSelected;

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


        private void _InfoSpinnerPotentialEnemyHeli_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            SelectedPotentialTaskHeli = potentialTask[e.Position].Id;
            TaskSelector();
        }

        private void TaskSelector()
        {
            if (SelectedPotentialTaskHeli == 1)
            {
                List<Heli> helisAll = HeliCollection.GetHeli();
                double step = 1.0;
                var helivar = from h in helisAll
                              where h.BR <= selectedHeliBR + step && h.BR >= selectedHeliBR - step && h.NationId != selectedNation
                              orderby h.MaxSpeed descending
                              select h;
                helispotential = helivar.ToList<Heli>();
                AdapterListView = new ListViewInfoHeliAdapter(this, helispotential);
                _InfoListView.Adapter = AdapterListView;
            }

            if (SelectedPotentialTaskHeli == 2)
            {
                List<Heli> helisAll = HeliCollection.GetHeli();
                double step = 1.0;
                var helivar = from h in helisAll
                              where h.BR <= selectedHeliBR + step && h.BR >= selectedHeliBR - step && h.NationId != selectedNation
                              orderby h.ClimbTo1000 ascending
                              select h;
                helispotential = helivar.ToList<Heli>();
                AdapterListView = new ListViewInfoHeliAdapter(this, helispotential);
                _InfoListView.Adapter = AdapterListView;
            }

            if (SelectedPotentialTaskHeli == 3)
            {
                List<Heli> helisAll = HeliCollection.GetHeli();
                double step = 1.0;
                var helivar = from h in helisAll
                              where h.BR <= selectedHeliBR + step && h.BR >= selectedHeliBR - step && h.NationId != selectedNation
                              orderby h.ThrustToWeightRatio descending
                              select h;
                helispotential = helivar.ToList<Heli>();
                AdapterListView = new ListViewInfoHeliAdapter(this, helispotential);
                _InfoListView.Adapter = AdapterListView;
            }

            if (SelectedPotentialTaskHeli == 4)
            {
                List<Heli> helisAll = HeliCollection.GetHeli();
                double step = 1.0;
                var helivar = from h in helisAll
                              where h.BR <= selectedHeliBR + step && h.BR >= selectedHeliBR - step && h.NationId != selectedNation
                              orderby h.AGMCount descending
                              select h;
                helispotential = helivar.ToList<Heli>();
                AdapterListView = new ListViewInfoHeliAdapter(this, helispotential);
                _InfoListView.Adapter = AdapterListView;
            }

            if (SelectedPotentialTaskHeli == 5)
            {
                List<Heli> helisAll = HeliCollection.GetHeli();
                double step = 1.0;
                var helivar = from h in helisAll
                              where h.BR <= selectedHeliBR + step && h.BR >= selectedHeliBR - step && h.NationId != selectedNation
                              orderby h.AGMArmorPenetration descending
                              select h;
                helispotential = helivar.ToList<Heli>();
                AdapterListView = new ListViewInfoHeliAdapter(this, helispotential);
                _InfoListView.Adapter = AdapterListView;
            }

            if (SelectedPotentialTaskHeli == 6)
            {
                List<Heli> helisAll = HeliCollection.GetHeli();
                double step = 1.0;
                var helivar = from h in helisAll
                              where h.BR <= selectedHeliBR + step && h.BR >= selectedHeliBR - step && h.NationId != selectedNation
                              orderby h.AGMRange descending
                              select h;
                helispotential = helivar.ToList<Heli>();
                AdapterListView = new ListViewInfoHeliAdapter(this, helispotential);
                _InfoListView.Adapter = AdapterListView;
            }

            if (SelectedPotentialTaskHeli == 7)
            {
                List<Heli> helisAll = HeliCollection.GetHeli();
                double step = 1.0;
                var helivar = from h in helisAll
                              where h.BR <= selectedHeliBR + step && h.BR >= selectedHeliBR - step && h.NationId != selectedNation
                              orderby h.ASMCount descending
                              select h;
                helispotential = helivar.ToList<Heli>();
                AdapterListView = new ListViewInfoHeliAdapter(this, helispotential);
                _InfoListView.Adapter = AdapterListView;
            }



        }

        private void _InfoSpinnerNation_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedNation = nations[e.Position].Id;

            if (selectedNation == 100 && selectedRank == 100)
            {
                helis = HeliCollection.GetHeli();
                AdapterHeli = new HeliAdapter(this, helis);
                _InfoSpinnerHeli.Adapter = AdapterHeli;
            }
            else
            if (selectedNation == 100)
            {
                List<Heli> helisAll = HeliCollection.GetHeli();
                var helivar = from h in helisAll
                              where h.RankId == selectedRank
                              select h;
                helis = helivar.ToList<Heli>();
                AdapterHeli = new HeliAdapter(this, helis);
                _InfoSpinnerHeli.Adapter = AdapterHeli;
            }
            else
                if (selectedRank == 100)
            {
                List<Heli> helisAll = HeliCollection.GetHeli();
                var helivar = from h in helisAll
                              where h.NationId == selectedNation
                              select h;
                helis = helivar.ToList<Heli>();
                AdapterHeli = new HeliAdapter(this, helis);
                _InfoSpinnerHeli.Adapter = AdapterHeli;
            }
            else
            {
                helis = HeliSelector(selectedNation, selectedRank);
                AdapterHeli = new HeliAdapter(this, helis);
                _InfoSpinnerHeli.Adapter = AdapterHeli;
            }

        }
                
        private void _InfoSpinnerRank_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedRank = ranks[e.Position].Id;

            if (selectedNation == 100 && selectedRank == 100)
            {
                helis = HeliCollection.GetHeli();
                AdapterHeli = new HeliAdapter(this, helis);
                _InfoSpinnerHeli.Adapter = AdapterHeli;
            }
            else
            if (selectedNation == 100)
            {
                List<Heli> helisAll = HeliCollection.GetHeli();
                var helivar = from h in helisAll
                              where h.RankId == selectedRank
                              select h;
                helis = helivar.ToList<Heli>();
                AdapterHeli = new HeliAdapter(this, helis);
                _InfoSpinnerHeli.Adapter = AdapterHeli;
            }
            else
                if (selectedRank == 100)
            {
                List<Heli> helisAll = HeliCollection.GetHeli();
                var helivar = from h in helisAll
                              where h.NationId == selectedNation
                              select h;
                helis = helivar.ToList<Heli>();
                AdapterHeli = new HeliAdapter(this, helis);
                _InfoSpinnerHeli.Adapter = AdapterHeli;
            }
            else
            {
                helis = HeliSelector(selectedNation, selectedRank);
                AdapterHeli = new HeliAdapter(this, helis);
                _InfoSpinnerHeli.Adapter = AdapterHeli;
            }

        }

        private void _InfoSpinnerHeli_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedHeliBR = helis[e.Position].BR;
            BombExiste = helis[e.Position].HandingBomb;
            AGMExiste = helis[e.Position].HandingAGM;
            ASMExiste = helis[e.Position].HandingASM;
            CannonExiste = helis[e.Position].HandingCannon;
            HandlingAirToAir = helis[e.Position].AirToAir;
            IRCM = helis[e.Position].IRCM;
            Flares = helis[e.Position].Flares;
            HIRSS = helis[e.Position].HIRSS;



        _InfoImage.SetImageResource(helis[e.Position].Image);
         _InfoFlag.SetImageResource(helis[e.Position].FlagImage);
            _InfoHeliTextBR.SetText(helis[e.Position].BR.ToString("0.0#"), TextView.BufferType.Normal);
            // _InfoHeliTextClimbTo1000.SetText(helis[e.Position].ClimbTo1000.ToString() TextView.BufferType.Normal);
            int newClimb = helis[e.Position].ClimbTo1000;
            TimeSpan timeSpan = TimeSpan.FromSeconds(newClimb);
            string climbToShow = timeSpan.ToString(@"mm\:ss");
            _InfoHeliTextClimbTo1000.SetText(climbToShow, TextView.BufferType.Normal);
            _InfoHeliTextFirstFlyYear.SetText(helis[e.Position].FirstFlyYear.ToString() + context.Resources.GetString(Resource.String.AbbrYear), TextView.BufferType.Normal);
            _InfoHeliTextPatchAdded.SetText(helis[e.Position].PatchAdded.ToString(), TextView.BufferType.Normal);
            _InfoHeliTextType.SetText(helis[e.Position].Type, TextView.BufferType.Normal);
            _InfoHeliTextCharacter.SetText(helis[e.Position].HeliCharacter, TextView.BufferType.Normal);
            _InfoHeliTextTurn360.SetText(helis[e.Position].Turn360.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            _InfoHeliTextEnginePower.SetText(helis[e.Position].EnginePower.ToString() + context.Resources.GetString(Resource.String.AbbrH_P), TextView.BufferType.Normal);
            _InfoHeliTextAGMCount.SetText(helis[e.Position].AGMCount.ToString() + context.Resources.GetString(Resource.String.AbbrITEMS), TextView.BufferType.Normal);
            _InfoHeliTextASMCount.SetText(helis[e.Position].ASMCount.ToString() + context.Resources.GetString(Resource.String.AbbrITEMS), TextView.BufferType.Normal);
            _InfoHeliOffensiveWeapon.SetText(helis[e.Position].OffensiveWeapon, TextView.BufferType.Normal);
            _InfoHeliSuspensionWeapon.SetText(helis[e.Position].SuspensionWeapon, TextView.BufferType.Normal);

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            ISharedPreferencesEditor editor = prefs.Edit();
            var switchchecked = prefs.GetBoolean("key_kmhtomph", false);
            if (switchchecked)
            {
                _InfoHeliLabelTextClimbTo1000.SetText(context.Resources.GetString(Resource.String.HeliClimbTo1000Feet), TextView.BufferType.Normal);

                var maxSpeed = helis[e.Position].MaxSpeed* 0.621371192;
                var thrustToWeightRatio = helis[e.Position].ThrustToWeightRatio/2.204622621849;
                var weight = helis[e.Position].Weight* 0.00110231131;
                var bombLoad = helis[e.Position].BombLoad* 2.204622621849;
                var aGMSpeed = helis[e.Position].AGMSpeed* 3.28084;
                var aSMSpeed = helis[e.Position].ASMSpeed* 3.28084;
                var aGMRange = helis[e.Position].AGMRange* 3.28084;
                var aSMArmorPenetration = helis[e.Position].ASMArmorPenetration* 0.039370;
                var aGMArmorPenetration = helis[e.Position].AGMArmorPenetration* 0.039370;
                maxSpeed = Math.Round(maxSpeed, 0);
                thrustToWeightRatio = Math.Round(thrustToWeightRatio, 2);
                weight = Math.Round(weight, 1);
                bombLoad = Math.Round(bombLoad, 0);
                aGMSpeed = Math.Round(aGMSpeed, 0);
                aSMSpeed = Math.Round(aSMSpeed, 0);
                aGMRange = Math.Round(aGMRange, 0);
                aSMArmorPenetration = Math.Round(aSMArmorPenetration, 2);
                aGMArmorPenetration = Math.Round(aGMArmorPenetration, 2);

                _InfoHeliTextMaxSpeed.SetText(maxSpeed + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _InfoHeliTextThrustToWeightRatio.SetText(thrustToWeightRatio + context.Resources.GetString(Resource.String.AbbrHP_LB), TextView.BufferType.Normal);
                _InfoHeliTextWeight.SetText(weight + context.Resources.GetString(Resource.String.AbbrST), TextView.BufferType.Normal);
                _InfoHeliTextBombLoad.SetText(bombLoad + context.Resources.GetString(Resource.String.AbbrLB), TextView.BufferType.Normal);
                _InfoHeliTextAGMSpeed.SetText(aGMSpeed + context.Resources.GetString(Resource.String.AbbrFEET_S), TextView.BufferType.Normal);
                _InfoHeliTextASMSpeed.SetText(aSMSpeed + context.Resources.GetString(Resource.String.AbbrFEET_S), TextView.BufferType.Normal);
                _InfoHeliTextAGMRange.SetText(aGMRange + context.Resources.GetString(Resource.String.AbbrFEET), TextView.BufferType.Normal);
                _InfoHeliTextASMArmorPenetration.SetText(aSMArmorPenetration + context.Resources.GetString(Resource.String.AbbrINCH), TextView.BufferType.Normal);
                _InfoHeliTextAGMArmorPenetration.SetText(aGMArmorPenetration + context.Resources.GetString(Resource.String.AbbrINCH), TextView.BufferType.Normal);

            }
            else
            {
                _InfoHeliLabelTextClimbTo1000.SetText(context.Resources.GetString(Resource.String.HeliClimbTo1000), TextView.BufferType.Normal);

                _InfoHeliTextThrustToWeightRatio.SetText(helis[e.Position].ThrustToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrH_P_KG), TextView.BufferType.Normal);
                _InfoHeliTextMaxSpeed.SetText(helis[e.Position].MaxSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _InfoHeliTextWeight.SetText(helis[e.Position].Weight.ToString() + context.Resources.GetString(Resource.String.AbbrKG), TextView.BufferType.Normal);
                _InfoHeliTextAGMArmorPenetration.SetText(helis[e.Position].AGMArmorPenetration.ToString() + context.Resources.GetString(Resource.String.AbbrMM), TextView.BufferType.Normal);
                _InfoHeliTextAGMSpeed.SetText(helis[e.Position].AGMSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrM_S), TextView.BufferType.Normal);
                _InfoHeliTextAGMRange.SetText(helis[e.Position].AGMRange.ToString() + context.Resources.GetString(Resource.String.AbbrMETER), TextView.BufferType.Normal);
                _InfoHeliTextASMArmorPenetration.SetText(helis[e.Position].ASMArmorPenetration.ToString() + context.Resources.GetString(Resource.String.AbbrMM), TextView.BufferType.Normal);
                _InfoHeliTextASMSpeed.SetText(helis[e.Position].ASMSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrM_S), TextView.BufferType.Normal);
                _InfoHeliTextBombLoad.SetText(helis[e.Position].BombLoad.ToString() + context.Resources.GetString(Resource.String.AbbrKG), TextView.BufferType.Normal);

            }


            HeliHandingWeaponShower();
            TaskSelector();

        }

        private List<Heli> HeliSelector(int selectedNation, int selectedRank)
        {
            this.selectedNation = selectedNation;
            this.selectedRank = selectedRank;
            List<Heli> helisAll = HeliCollection.GetHeli();
            var helivar = from h in helisAll
                          where h.NationId == selectedNation
                          where h.RankId == selectedRank
                          select h;
            return helivar.ToList<Heli>();
        }

        public void HeliHandingWeaponShower()
        {
            if (IRCM == true)
            {
                _InfoIRCM.SetImageResource(Resource.Drawable._defenceIRCM);
            }
            else
            {
                _InfoIRCM.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (Flares == true)
            {
                _InfoFlares.SetImageResource(Resource.Drawable._defenceFlares);
            }
            else
            {
                _InfoFlares.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (HIRSS == true)
            {
                _InfoHIRSS.SetImageResource(Resource.Drawable._defenceHIRSS);
            }
            else
            {
                _InfoHIRSS.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (HandlingAirToAir == true)
            {
                _InfoHandlingAirToAir.SetImageResource(Resource.Drawable._handingAirToAir);
            }
            else
            {
                _InfoHandlingAirToAir.SetImageResource(Resource.Drawable._handingTransparent);
            }



            if ( BombExiste== true)
            {
                _InfoHandlingBomb.SetImageResource(Resource.Drawable._handingBomb);
            }
            else
            {
                _InfoHandlingBomb.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (AGMExiste == true)
            {
                _InfoHandlingAGM.SetImageResource(Resource.Drawable._handingRocket);
            }
            else
            {
                _InfoHandlingAGM.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (CannonExiste == true)
            {
                _InfoHandlingCannon.SetImageResource(Resource.Drawable._handingCannon);
            }
            else
            {
                _InfoHandlingCannon.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (ASMExiste == true)
            {
                _InfoHandlingASM.SetImageResource(Resource.Drawable._handingTorpedo);
            }
            else
            {
                _InfoHandlingASM.SetImageResource(Resource.Drawable._handingTransparent);
            }
        }


    }
}