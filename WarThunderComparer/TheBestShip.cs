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
    class TheBestShip:AppCompatActivity
    {
        Spinner _TheBestSpinnerNation;
        Spinner _TheBestSpinnerRank;
        Spinner _TheBestSpinnerTask;
        ListView _TheBestListView;
        //Объявление  спиннеров и скролов с XAML

        List<Ship> shipsForTask;
        List<Ship> shipsToListView;
        List<Nation> theBestNations;
        List<Rank> theBestRanks;
        public List<Task> theBestTask;
        NationAdapter TheBestAdapterNation;
        RankAdapter TheBestAdapterRank;
        TaskAdapter TheBestAdapterTask;
        ListViewTheBestShipAdapter TheBestlistView;

        private int selectedNation;
        private int selectedRank;
        public static int SelectedTask;
        // Объявление адаптеров, текстовых полей ,коллекций и переменных  

        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\
        DrawerLayout drawerLayout;
        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\
        protected TheBestShip(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public TheBestShip()
        {
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TheBestShip);
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
            var adView = FindViewById<AdView>(Resource.Id.adViewTheBestShip);
                 var adRequest = new AdRequest.Builder().Build();
                adView.LoadAd(adRequest);
            //var requestbuilder = new AdRequest.Builder().AddTestDevice("D0BE22F1A4BE27C7470F95A699568FE2");
            //adView.LoadAd(requestbuilder.Build());

            _TheBestSpinnerNation = FindViewById<Spinner>(Resource.Id.TheBestSpinnerNationS);
            _TheBestSpinnerRank = FindViewById<Spinner>(Resource.Id.TheBestSpinnerRankS);
            _TheBestSpinnerTask = FindViewById<Spinner>(Resource.Id.TheBestSpinnerTaskS);
            _TheBestListView = FindViewById<ListView>(Resource.Id.TheBestlistViewS);

            //Привязка спиннеров к шарп коду
            theBestNations = NationCollection.GetNation();
            TheBestAdapterNation = new NationAdapter(this, theBestNations);
            _TheBestSpinnerNation.Adapter = TheBestAdapterNation;
            _TheBestSpinnerNation.SetSelection(0);  //Автовыбор
            selectedNation = 100;

            theBestRanks = RankCollection.GetRank();
            TheBestAdapterRank = new RankAdapter(this, theBestRanks);
            _TheBestSpinnerRank.Adapter = TheBestAdapterRank;
            _TheBestSpinnerRank.SetSelection(4);   //Автовыбор
            selectedRank = 4;   //Автовыбор

            theBestTask = ShipTaskCollection.GetTask();
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
            shipsForTask = shipsToListView;
            TaskSelector();
        }

        private void _TheBestSpinnerRank_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedRank = theBestRanks[e.Position].Id;
            ListShower();
            shipsForTask = shipsToListView;
            TaskSelector();
        }

        private void _TheBestSpinnerTask_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            SelectedTask = theBestTask[e.Position].Id;
            ListShower();
            shipsForTask = shipsToListView;
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

        private void ListShower()
        {
            if (selectedNation == 100 && selectedRank == 100)
            {
                shipsToListView = ShipCollection.GetShip();
                TheBestlistView = new ListViewTheBestShipAdapter(this, shipsToListView);
                _TheBestListView.Adapter = TheBestlistView;
            }
            else
     if (selectedNation == 100)
            {
                List<Ship> shipsAll = ShipCollection.GetShip();
                var shipvar = from s in shipsAll
                              where s.RankId == selectedRank
                              select s;
                shipsToListView = shipvar.ToList<Ship>();
                TheBestlistView = new ListViewTheBestShipAdapter(this, shipsToListView);
                _TheBestListView.Adapter = TheBestlistView;
            }
            else
     if (selectedRank == 100)
            {
                List<Ship> shipsAll = ShipCollection.GetShip();
                var shipvar = from s in shipsAll
                              where s.NationId == selectedNation
                              select s;
                shipsToListView = shipvar.ToList<Ship>();
                TheBestlistView = new ListViewTheBestShipAdapter(this, shipsToListView);
                _TheBestListView.Adapter = TheBestlistView;
            }
            else
            {
                shipsToListView = ShipSelector(selectedNation, selectedRank);
                TheBestlistView = new ListViewTheBestShipAdapter(this, shipsToListView);
                _TheBestListView.Adapter = TheBestlistView;
            }
        }

        private void TaskSelector()
        {
            if (SelectedTask == 1)
            {
                var shipvar = from s in shipsForTask
                              orderby s.MainCaliberSize descending
                              select s;
                shipsToListView = shipvar.ToList<Ship>();
                TheBestlistView = new ListViewTheBestShipAdapter(this, shipsToListView);
                _TheBestListView.Adapter = TheBestlistView;
            }

            if (SelectedTask == 2)
            {
                var shipvar = from s in shipsForTask
                              orderby s.MainCaliberItem descending
                              select s;
                shipsToListView = shipvar.ToList<Ship>();
                TheBestlistView = new ListViewTheBestShipAdapter(this, shipsToListView);
                _TheBestListView.Adapter = TheBestlistView;
            }

            if (SelectedTask == 3)
            {
                var shipvar = from s in shipsForTask
                              orderby s.MainCaliberTNT descending
                              select s;
                shipsToListView = shipvar.ToList<Ship>();
                TheBestlistView = new ListViewTheBestShipAdapter(this, shipsToListView);
                _TheBestListView.Adapter = TheBestlistView;
            }

            if (SelectedTask == 4)
            {
                var shipvar = from s in shipsForTask
                              orderby s.MaxSpeed descending
                              select s;
                shipsToListView = shipvar.ToList<Ship>();
                TheBestlistView = new ListViewTheBestShipAdapter(this, shipsToListView);
                _TheBestListView.Adapter = TheBestlistView;
            }

            if (SelectedTask == 5)
            {
                var shipvar = from s in shipsForTask
                              orderby s.TorpedoItem descending
                              select s;
                shipsToListView = shipvar.ToList<Ship>();
                TheBestlistView = new ListViewTheBestShipAdapter(this, shipsToListView);
                _TheBestListView.Adapter = TheBestlistView;
            }

            if (SelectedTask == 6)
            {
                var shipvar = from s in shipsForTask
                              orderby s.TorpedoTNT descending
                              select s;
                shipsToListView = shipvar.ToList<Ship>();
                TheBestlistView = new ListViewTheBestShipAdapter(this, shipsToListView);
                _TheBestListView.Adapter = TheBestlistView;
            }

            if (SelectedTask == 7)
            {
                var shipvar = from s in shipsForTask
                              orderby s.Displacement descending
                              select s;
                shipsToListView = shipvar.ToList<Ship>();
                TheBestlistView = new ListViewTheBestShipAdapter(this, shipsToListView);
                _TheBestListView.Adapter = TheBestlistView;
            }



        }




    }
}