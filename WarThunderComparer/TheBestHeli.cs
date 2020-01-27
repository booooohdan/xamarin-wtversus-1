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
using Android.Gms.Ads;
using Android.Content;

namespace WarThunderComparer
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait)]
    class TheBestHeli : AppCompatActivity
    {
        Spinner _TheBestSpinnerNation;
        Spinner _TheBestSpinnerRank;
        Spinner _TheBestSpinnerTask;
        ListView _TheBestListView;
        //Объявление  спиннеров и скролов с XAML

        List<Heli> helisForTask;
        List<Heli> helisToListView;
        List<Nation> theBestNations;
        List<Rank> theBestRanks;
        public List<Task> theBestTask;
        NationAdapter TheBestAdapterNation;
        RankAdapter TheBestAdapterRank;
        TaskAdapter TheBestAdapterTask;
        ListViewTheBestHeliAdapter TheBestlistView;

        private int selectedNation;
        private int selectedRank;
        public static int SelectedTask;
        // Объявление адаптеров, текстовых полей ,коллекций и переменных    

        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\
        DrawerLayout drawerLayout;
        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\
        public TheBestHeli()
        {

        }

        protected TheBestHeli(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TheBestHeli);
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
            Context context = Application.Context;
            var id = "ca-app-pub-8211072909515345~1945501010";
            Android.Gms.Ads.MobileAds.Initialize(context, id);
            var adView = FindViewById<AdView>(Resource.Id.adViewTheBestHeli);
                 var adRequest = new AdRequest.Builder().Build();
                adView.LoadAd(adRequest);
            //var requestbuilder = new AdRequest.Builder().AddTestDevice("D0BE22F1A4BE27C7470F95A699568FE2");
            //adView.LoadAd(requestbuilder.Build());


            _TheBestSpinnerNation = FindViewById<Spinner>(Resource.Id.TheBestSpinnerNationH);
            _TheBestSpinnerRank = FindViewById<Spinner>(Resource.Id.TheBestSpinnerRankH);
            _TheBestSpinnerTask = FindViewById<Spinner>(Resource.Id.TheBestSpinnerTaskH);
            _TheBestListView = FindViewById<ListView>(Resource.Id.TheBestlistViewH);
            //Привязка спиннеров к шарп коду
            theBestNations = NationCollection.GetNation();
            TheBestAdapterNation = new NationAdapter(this, theBestNations);
            _TheBestSpinnerNation.Adapter = TheBestAdapterNation;
            _TheBestSpinnerNation.SetSelection(0);  //Автовыбор
            selectedNation = 100;

            theBestRanks = RankCollection.GetRank();
            TheBestAdapterRank = new RankAdapter(this, theBestRanks);
            _TheBestSpinnerRank.Adapter = TheBestAdapterRank;
            _TheBestSpinnerRank.SetSelection(6);   //Автовыбор
            selectedRank = 6;   //Автовыбор

            theBestTask = HeliTaskCollection.GetTask();
            TheBestAdapterTask = new TaskAdapter(this, theBestTask);
            _TheBestSpinnerTask.Adapter = TheBestAdapterTask;
            _TheBestSpinnerTask.SetSelection(0);  //Автовыбор
            SelectedTask = 0; //Автовыбор

            _TheBestSpinnerNation.ItemSelected += _TheBestSpinnerNation_ItemSelected;
            _TheBestSpinnerRank.ItemSelected += _TheBestSpinnerRank_ItemSelected;
            _TheBestSpinnerTask.ItemSelected += _TheBestSpinnerTask_ItemSelected;
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


        private void _TheBestSpinnerNation_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedNation = theBestNations[e.Position].Id;
            ListShower();
            helisForTask = helisToListView;
            TaskSelector();
        }

        private void _TheBestSpinnerRank_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedRank = theBestRanks[e.Position].Id;
            ListShower();
            helisForTask = helisToListView;
            TaskSelector();
        }

        private void _TheBestSpinnerTask_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            SelectedTask = theBestTask[e.Position].Id;
            ListShower();
            helisForTask = helisToListView;
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

        private void ListShower()
        {
            if (selectedNation == 100 && selectedRank == 100)
            {
                helisToListView = HeliCollection.GetHeli();
                TheBestlistView = new ListViewTheBestHeliAdapter(this, helisToListView);
                _TheBestListView.Adapter = TheBestlistView;
            }
            else
                if (selectedNation == 100)
            {
                List<Heli> helisAll = HeliCollection.GetHeli();
                var helivar = from h in helisAll
                              where h.RankId == selectedRank
                              select h;
                helisToListView = helivar.ToList<Heli>();
                TheBestlistView = new ListViewTheBestHeliAdapter(this, helisToListView);
                _TheBestListView.Adapter = TheBestlistView;
            }
            else
                if (selectedRank == 100)
            {
                List<Heli> helisAll = HeliCollection.GetHeli();
                var helivar = from h in helisAll
                              where h.NationId == selectedNation
                              select h;
                helisToListView = helivar.ToList<Heli>();
                TheBestlistView = new ListViewTheBestHeliAdapter(this, helisToListView);
                _TheBestListView.Adapter = TheBestlistView;
            }
            else
            {
                helisToListView = HeliSelector(selectedNation, selectedRank);
                TheBestlistView = new ListViewTheBestHeliAdapter(this, helisToListView);
                _TheBestListView.Adapter = TheBestlistView;
            }
        }

        private void TaskSelector()
        {
            if (SelectedTask == 1)
            {
                var helivar = from h in helisForTask
                              orderby h.MaxSpeed descending
                              select h;
                helisToListView = helivar.ToList<Heli>();
                TheBestlistView = new ListViewTheBestHeliAdapter(this, helisToListView);
                _TheBestListView.Adapter = TheBestlistView;
            }

            if (SelectedTask == 2)
            {
                var helivar = from h in helisForTask
                              orderby h.ClimbTo1000 ascending
                              select h;
                helisToListView = helivar.ToList<Heli>();
                TheBestlistView = new ListViewTheBestHeliAdapter(this, helisToListView);
                _TheBestListView.Adapter = TheBestlistView;
            }

            if (SelectedTask == 3)
            {
                var helivar = from h in helisForTask
                              orderby h.ThrustToWeightRatio descending
                              select h;
                helisToListView = helivar.ToList<Heli>();
                TheBestlistView = new ListViewTheBestHeliAdapter(this, helisToListView);
                _TheBestListView.Adapter = TheBestlistView;
            }

            if (SelectedTask == 4)
            {
                var helivar = from h in helisForTask
                              orderby h.AGMCount descending
                              select h;
                helisToListView = helivar.ToList<Heli>();
                TheBestlistView = new ListViewTheBestHeliAdapter(this, helisToListView);
                _TheBestListView.Adapter = TheBestlistView;
            }

            if (SelectedTask == 5)
            {
                var helivar = from h in helisForTask
                              orderby h.AGMArmorPenetration descending
                              select h;
                helisToListView = helivar.ToList<Heli>();
                TheBestlistView = new ListViewTheBestHeliAdapter(this, helisToListView);
                _TheBestListView.Adapter = TheBestlistView;
            }

            if (SelectedTask == 6)
            {
                var helivar = from h in helisForTask
                              orderby h.AGMRange descending
                              select h;
                helisToListView = helivar.ToList<Heli>();
                TheBestlistView = new ListViewTheBestHeliAdapter(this, helisToListView);
                _TheBestListView.Adapter = TheBestlistView;
            }

            if (SelectedTask == 7)
            {
                var helivar = from h in helisForTask
                              orderby h.ASMCount descending
                              select h;
                helisToListView = helivar.ToList<Heli>();
                TheBestlistView = new ListViewTheBestHeliAdapter(this, helisToListView);
                _TheBestListView.Adapter = TheBestlistView;
            }

        }
    }
}