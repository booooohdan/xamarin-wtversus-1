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
    public class ComparePlane : AppCompatActivity
    {
        Spinner _CompareSpinnerNationLeft;
        Spinner _CompareSpinnerPlaneLeft;
        Spinner _CompareSpinnerRankLeft;
        Spinner _CompareSpinnerNationRight;
        Spinner _CompareSpinnerPlaneRight;
        Spinner _CompareSpinnerRankRight;
        //Объявление  спиннеров и скролов с XAML


        #region Объявление всех Textview
        Context context;
        ImageView _CompareImageLeft;
        ImageView _CompareLeftFlag;
        ImageView _CompareLeftHandlingRocket;
        ImageView _CompareLeftHandlingAirToAir;
        ImageView _CompareLeftHandlingAirToGround;
        ImageView _CompareLeftHandlingCannon;
        ImageView _CompareLeftHandlingBomb;
        ImageView _CompareLeftHandlingTorpedo;

        TextView _ComparePlaneLeftTextMaxSpeedAt0;
        TextView _ComparePlaneLeftTextMaxSpeedAt5000;
        TextView _ComparePlaneLeftTextBombLoad;
        TextView _ComparePlaneLeftTextTurnAt0;
        TextView _ComparePlaneLeftTextClimb;
        TextView _ComparePlaneLeftTextEnginePower;
        TextView _ComparePlaneLeftTextWeight;
        TextView _ComparePlaneLeftTextThrustToWeightRatio;
        TextView _ComparePlaneLeftTextWeaponVolleyPerSecond;
        TextView _ComparePlaneLeftTextWeaponAndTurrels;
        TextView _ComparePlaneLeftTextFlutter;

        ImageView _CompareImageRight;
        ImageView _CompareRightFlag;
        ImageView _CompareRightHandlingRocket;
        ImageView _CompareRightHandlingAirToAir;
        ImageView _CompareRightHandlingAirToGround;
        ImageView _CompareRightHandlingCannon;
        ImageView _CompareRightHandlingBomb;
        ImageView _CompareRightHandlingTorpedo;

        TextView _ComparePlaneRightTextMaxSpeedAt0;
        TextView _ComparePlaneRightTextMaxSpeedAt5000;
        TextView _ComparePlaneRightTextBombLoad;
        TextView _ComparePlaneRightTextTurnAt0;
        TextView _ComparePlaneRightTextClimb;
        TextView _ComparePlaneRightTextEnginePower;
        TextView _ComparePlaneRightTextWeight;
        TextView _ComparePlaneRightTextThrustToWeightRatio;
        TextView _ComparePlaneRightTextWeaponVolleyPerSecond;
        TextView _ComparePlaneRightTextWeaponAndTurrels;
        TextView _ComparePlaneRightTextFlutter;


        TextView _ComparePlaneLabelTextMaxSpeedAt0;
        TextView _ComparePlaneLabelTextMaxSpeedAt5000;
        TextView _ComparePlaneLabelTextBombLoad;
        TextView _ComparePlaneLabelTextTurnAt0;
        TextView _ComparePlaneLabelTextClimb;
        TextView _ComparePlaneLabelTextEnginePower;
        TextView _ComparePlaneLabelTextWeight;
        TextView _ComparePlaneLabelTextThrustToWeightRatio;
        TextView _ComparePlaneLabelTextWeaponVolleyPerSecond;
        TextView _ComparePlaneLabelHandingWeapon;
        TextView _ComparePlaneLabelTextFlutter;

        //Объявление текстовых полей
        #endregion

        List<Plane> planesleft;
        List<Plane> planesright;
        PlaneAdapter AdapterPlaneLeft;
        PlaneAdapter AdapterPlaneRight;
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

        private bool leftBombExiste;
        private bool leftRocketExiste;
        private bool leftCannonExiste;
        private bool leftTorpedoExiste;
        private bool leftAirToAirExiste;
        private bool rightBombExiste;
        private bool rightRocketExiste;
        private bool rightCannonExiste;
        private bool rightTorpedoExiste;
        private bool rightAirToAirExiste;
        private bool rightAirToGroundExiste;
        private int leftSpeed0;
        private int leftSpeed5000;
        private int leftBombLoad;
        private double leftTurnTime;
        private int leftClimb;
        private int leftEnginePower;
        private int leftWeight;
        private double leftThrustToWeiht;
        private double leftVolleyPerSecond;
        private bool leftAirToGroundExiste;
        private int selectedRankIDLeft;
        private int leftFlutter;

        private int rightSpeed0;
        private int rightSpeed5000;
        private int rightBombLoad;
        private double rightTurnTime;
        private int rightClimb;
        private int rightEnginePower;
        private int rightWeight;
        private double rightThrustToWeiht;
        private double rightVolleyPerSecond;
        private int selectedRankIDRight;
        private int rightFlutter;


        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\
        DrawerLayout drawerLayout;
        ////////////////////////МЕНЮ\\\\\\\\\\\\\\\\\\\\\\


        public ComparePlane()
        {
        }
        protected ComparePlane(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ComparePlane);
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
            var adView = FindViewById<AdView>(Resource.Id.adViewComparePlane);
                 var adRequest = new AdRequest.Builder().Build();
                adView.LoadAd(adRequest);
            //var requestbuilder = new AdRequest.Builder().AddTestDevice("D0BE22F1A4BE27C7470F95A699568FE2");
            //adView.LoadAd(requestbuilder.Build());
            //шрифт
            var font = Typeface.CreateFromAsset(Assets, "dinfont.ttf");

            _CompareSpinnerNationLeft = FindViewById<Spinner>(Resource.Id.CompareSpinnerNationLeft);
            _CompareSpinnerPlaneLeft = FindViewById<Spinner>(Resource.Id.CompareSpinnerPlaneLeft);
            _CompareSpinnerNationRight = FindViewById<Spinner>(Resource.Id.CompareSpinnerNationRight);
            _CompareSpinnerPlaneRight = FindViewById<Spinner>(Resource.Id.CompareSpinnerPlaneRight);
            _CompareSpinnerRankLeft = FindViewById<Spinner>(Resource.Id.CompareSpinnerRankLeft);
            _CompareSpinnerRankRight = FindViewById<Spinner>(Resource.Id.CompareSpinnerRankRight);
            //Привязка спиннеров к шарп коду 

            #region Привязка TextView к коду
            _CompareImageLeft = FindViewById<ImageView>(Resource.Id.CompareImage1);
            _CompareLeftFlag = FindViewById<ImageView>(Resource.Id.CompareFlag1);
            _CompareLeftHandlingBomb = FindViewById<ImageView>(Resource.Id.CompareLeftHandlingBomb);
            _CompareLeftHandlingCannon = FindViewById<ImageView>(Resource.Id.CompareLeftHandlingCannon);
            _CompareLeftHandlingAirToAir = FindViewById<ImageView>(Resource.Id.CompareLeftHandlingAirToAir);
            _CompareLeftHandlingAirToGround = FindViewById<ImageView>(Resource.Id.CompareLeftHandlingAirToGround);
            _CompareLeftHandlingRocket = FindViewById<ImageView>(Resource.Id.CompareLeftHandlingRocket);
            _CompareLeftHandlingTorpedo = FindViewById<ImageView>(Resource.Id.CompareLeftHandlingTorpedo);

             _ComparePlaneLeftTextMaxSpeedAt0 = FindViewById<TextView>(Resource.Id.ComparePlaneLeftTextMaxSpeedAt0);
             _ComparePlaneLeftTextMaxSpeedAt5000 = FindViewById<TextView>(Resource.Id.ComparePlaneLeftTextMaxSpeedAt5000);
            _ComparePlaneLeftTextBombLoad = FindViewById<TextView>(Resource.Id.ComparePlaneLeftTextBombLoad);
             _ComparePlaneLeftTextTurnAt0 = FindViewById<TextView>(Resource.Id.ComparePlaneLeftTextTurnAt0);
             _ComparePlaneLeftTextClimb = FindViewById<TextView>(Resource.Id.ComparePlaneLeftTextClimb);
             _ComparePlaneLeftTextEnginePower = FindViewById<TextView>(Resource.Id.ComparePlaneLeftTextEnginePower);
             _ComparePlaneLeftTextWeight = FindViewById<TextView>(Resource.Id.ComparePlaneLeftTextWeight);
             _ComparePlaneLeftTextThrustToWeightRatio = FindViewById<TextView>(Resource.Id.ComparePlaneLeftTextThrustToWeightRatio);
             _ComparePlaneLeftTextWeaponVolleyPerSecond = FindViewById<TextView>(Resource.Id.ComparePlaneLeftTextWeaponVolleyPerSecond);
             _ComparePlaneLeftTextWeaponAndTurrels = FindViewById<TextView>(Resource.Id.ComparePlaneLeftTextWeaponAndTurrels);
            _ComparePlaneLeftTextFlutter = FindViewById<TextView>(Resource.Id.ComparePlaneLeftTextFlutter);

            _ComparePlaneLabelTextMaxSpeedAt0 = FindViewById<TextView>(Resource.Id.ComparePlaneLabelTextMaxSpeedAt0);
            _ComparePlaneLabelTextMaxSpeedAt5000 = FindViewById<TextView>(Resource.Id.ComparePlaneLabelTextMaxSpeedAt5000);
            _ComparePlaneLabelTextBombLoad = FindViewById<TextView>(Resource.Id.ComparePlaneLabelTextBombLoad);
            _ComparePlaneLabelTextTurnAt0 = FindViewById<TextView>(Resource.Id.ComparePlaneLabelTextTurnAt0);
            _ComparePlaneLabelTextClimb = FindViewById<TextView>(Resource.Id.ComparePlaneLabelTextClimb);
            _ComparePlaneLabelTextEnginePower = FindViewById<TextView>(Resource.Id.ComparePlaneLabelTextEnginePower);
            _ComparePlaneLabelTextWeight = FindViewById<TextView>(Resource.Id.ComparePlaneLabelTextWeight);
            _ComparePlaneLabelTextThrustToWeightRatio = FindViewById<TextView>(Resource.Id.ComparePlaneLabelTextThrustToWeightRatio);
            _ComparePlaneLabelTextWeaponVolleyPerSecond = FindViewById<TextView>(Resource.Id.ComparePlaneLabelTextWeaponVolleyPerSecond);
            _ComparePlaneLabelHandingWeapon = FindViewById<TextView>(Resource.Id.ComparePlaneLabelTextHandingWeapon);
            _ComparePlaneLabelTextFlutter = FindViewById<TextView>(Resource.Id.ComparePlaneLabelTextFlutter);


            _CompareImageRight = FindViewById<ImageView>(Resource.Id.CompareImage2);
            _CompareRightFlag = FindViewById<ImageView>(Resource.Id.CompareFlag2);
            _CompareRightHandlingBomb = FindViewById<ImageView>(Resource.Id.CompareRightHandlingBomb);
            _CompareRightHandlingCannon = FindViewById<ImageView>(Resource.Id.CompareRightHandlingCannon);
            _CompareRightHandlingAirToAir = FindViewById<ImageView>(Resource.Id.CompareRightHandlingAirToAir);
            _CompareRightHandlingAirToGround = FindViewById<ImageView>(Resource.Id.CompareRightHandlingAirToGround);
            _CompareRightHandlingRocket = FindViewById<ImageView>(Resource.Id.CompareRightHandlingRocket);
            _CompareRightHandlingTorpedo = FindViewById<ImageView>(Resource.Id.CompareRightHandlingTorpedo);

            _ComparePlaneRightTextMaxSpeedAt0 = FindViewById<TextView>(Resource.Id.ComparePlaneRightTextMaxSpeedAt0);
            _ComparePlaneRightTextMaxSpeedAt5000 = FindViewById<TextView>(Resource.Id.ComparePlaneRightTextMaxSpeedAt5000);
            _ComparePlaneRightTextBombLoad = FindViewById<TextView>(Resource.Id.ComparePlaneRightTextBombLoad);
            _ComparePlaneRightTextTurnAt0 = FindViewById<TextView>(Resource.Id.ComparePlaneRightTextTurnAt0);
            _ComparePlaneRightTextClimb = FindViewById<TextView>(Resource.Id.ComparePlaneRightTextClimb);
            _ComparePlaneRightTextEnginePower = FindViewById<TextView>(Resource.Id.ComparePlaneRightTextEnginePower);
            _ComparePlaneRightTextWeight = FindViewById<TextView>(Resource.Id.ComparePlaneRightTextWeight);
            _ComparePlaneRightTextThrustToWeightRatio = FindViewById<TextView>(Resource.Id.ComparePlaneRightTextThrustToWeightRatio);
            _ComparePlaneRightTextWeaponVolleyPerSecond = FindViewById<TextView>(Resource.Id.ComparePlaneRightTextWeaponVolleyPerSecond);
            _ComparePlaneRightTextWeaponAndTurrels = FindViewById<TextView>(Resource.Id.ComparePlaneRightTextWeaponAndTurrels);
            _ComparePlaneRightTextFlutter = FindViewById<TextView>(Resource.Id.ComparePlaneRightTextFlutter);

            #endregion


            #region Изменения шрифта            

          _ComparePlaneLabelTextMaxSpeedAt0.Typeface = font;
          _ComparePlaneLabelTextMaxSpeedAt5000.Typeface = font;
          _ComparePlaneLabelTextBombLoad.Typeface = font;
          _ComparePlaneLabelTextTurnAt0.Typeface = font;
          _ComparePlaneLabelTextClimb.Typeface = font;
          _ComparePlaneLabelTextEnginePower.Typeface = font;
          _ComparePlaneLabelTextWeight.Typeface = font;
          _ComparePlaneLabelTextThrustToWeightRatio.Typeface = font;
          _ComparePlaneLabelTextWeaponVolleyPerSecond.Typeface = font;
          _ComparePlaneLabelHandingWeapon.Typeface = font;
            _ComparePlaneLabelTextFlutter.Typeface = font;
            #endregion

            #region Изменения цвета текста всех TextView
         
          _ComparePlaneLeftTextMaxSpeedAt0.SetTextColor(Color.Black);
          _ComparePlaneLeftTextMaxSpeedAt5000.SetTextColor(Color.Black);
          _ComparePlaneLeftTextBombLoad.SetTextColor(Color.Black);
          _ComparePlaneLeftTextTurnAt0.SetTextColor(Color.Black);
          _ComparePlaneLeftTextClimb.SetTextColor(Color.Black);
          _ComparePlaneLeftTextEnginePower.SetTextColor(Color.Black);
          _ComparePlaneLeftTextWeight.SetTextColor(Color.Black);
          _ComparePlaneLeftTextThrustToWeightRatio.SetTextColor(Color.Black);
          _ComparePlaneLeftTextWeaponVolleyPerSecond.SetTextColor(Color.Black);
          _ComparePlaneLeftTextWeaponAndTurrels.SetTextColor(Color.Black);
            _ComparePlaneLeftTextFlutter.SetTextColor(Color.Black);

          _ComparePlaneRightTextMaxSpeedAt0.SetTextColor(Color.Black);
            _ComparePlaneRightTextMaxSpeedAt5000.SetTextColor(Color.Black);
            _ComparePlaneRightTextBombLoad.SetTextColor(Color.Black);
          _ComparePlaneRightTextTurnAt0.SetTextColor(Color.Black);
          _ComparePlaneRightTextClimb.SetTextColor(Color.Black);
          _ComparePlaneRightTextEnginePower.SetTextColor(Color.Black);
          _ComparePlaneRightTextWeight.SetTextColor(Color.Black);
          _ComparePlaneRightTextThrustToWeightRatio.SetTextColor(Color.Black);
          _ComparePlaneRightTextWeaponVolleyPerSecond.SetTextColor(Color.Black);
          _ComparePlaneRightTextWeaponAndTurrels.SetTextColor(Color.Black);
            _ComparePlaneRightTextFlutter.SetTextColor(Color.Black);

            _ComparePlaneLabelTextMaxSpeedAt0.SetTextColor(Color.Black);
            _ComparePlaneLabelTextMaxSpeedAt5000.SetTextColor(Color.Black);
            _ComparePlaneLabelTextBombLoad.SetTextColor(Color.Black);
          _ComparePlaneLabelTextTurnAt0.SetTextColor(Color.Black);
          _ComparePlaneLabelTextClimb.SetTextColor(Color.Black);
          _ComparePlaneLabelTextEnginePower.SetTextColor(Color.Black);
          _ComparePlaneLabelTextWeight.SetTextColor(Color.Black);
          _ComparePlaneLabelTextThrustToWeightRatio.SetTextColor(Color.Black);
          _ComparePlaneLabelTextWeaponVolleyPerSecond.SetTextColor(Color.Black);
            _ComparePlaneLabelHandingWeapon.SetTextColor(Color.Black);
            _ComparePlaneLabelTextFlutter.SetTextColor(Color.Black);

            #endregion

            nations = NationCollection.GetNation();
            AdapterNationsLeft = new NationAdapter(this, nations);
            AdapterNationsRight = new NationAdapter(this, nations);
            _CompareSpinnerNationLeft.Adapter = AdapterNationsLeft;
            _CompareSpinnerNationRight.Adapter = AdapterNationsRight;
            _CompareSpinnerNationLeft.SetSelection(3); //Автовыбор
            _CompareSpinnerNationRight.SetSelection(2); //Автовыбор
            selectedNationLeft = 3;   //Автовыбор
            selectedNationRight = 2;   //Автовыбор


            ranks = RankCollection.GetRank();
            AdapterRankLeft = new RankAdapter(this, ranks);
            AdapterRankRight = new RankAdapter(this, ranks);
            _CompareSpinnerRankLeft.Adapter = AdapterRankLeft;
            _CompareSpinnerRankRight.Adapter = AdapterRankRight;
            _CompareSpinnerRankLeft.SetSelection(6); //Автовыбор
            _CompareSpinnerRankRight.SetSelection(6); //Автовыбор
            selectedRankLeft = 6;   //Автовыбор
            selectedRankRight = 6;   //Автовыбор

            _CompareSpinnerPlaneLeft.SetSelection(7);   //Автовыбор
            _CompareSpinnerPlaneRight.SetSelection(4);   //Автовыбор

            //Объявление коллекции наций, рангов и адаптеров


            _CompareSpinnerNationLeft.ItemSelected += _CompareSpinnerNationLeft_ItemSelected;
            _CompareSpinnerNationRight.ItemSelected += _CompareSpinnerNationRight_ItemSelected;
            _CompareSpinnerRankLeft.ItemSelected += _CompareSpinnerRankLeft_ItemSelected;
            _CompareSpinnerRankRight.ItemSelected += _CompareSpinnerRankRight_ItemSelected;
            _CompareSpinnerPlaneLeft.ItemSelected += _CompareSpinnerPlaneLeft_ItemSelected;
            _CompareSpinnerPlaneRight.ItemSelected += _CompareSpinnerPlaneRight_ItemSelected;
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


        //Обработчики событий  нажатия на нации
        private void _CompareSpinnerNationLeft_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedNationLeft = nations[e.Position].Id;
            PlaneLeftSelector();
        }
        private void _CompareSpinnerNationRight_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            
            selectedNationRight = nations[e.Position].Id;
            PlaneRightSelector();
        }

        //Обработчики событий  нажатия на ранги
        private void _CompareSpinnerRankLeft_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedRankLeft = ranks[e.Position].Id;
            PlaneLeftSelector();

        }
        private void _CompareSpinnerRankRight_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedRankRight = ranks[e.Position].Id;
            PlaneRightSelector();
        }

        //Обработчики событий  нажатия на самолеты
        private void _CompareSpinnerPlaneLeft_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            leftSpeed0 = planesleft[e.Position].MaxSpeedAt0;
            leftSpeed5000 = planesleft[e.Position].MaxSpeedAt5000;
            leftBombLoad = planesleft[e.Position].BombLoad;
            leftTurnTime = planesleft[e.Position].TurnAt0;
            leftClimb = planesleft[e.Position].Climb;
            leftEnginePower = planesleft[e.Position].EnginePower;
            leftWeight = planesleft[e.Position].Weight;
            leftThrustToWeiht = planesleft[e.Position].ThrustToWeightRatio;
            leftVolleyPerSecond = planesleft[e.Position].WeaponVolleyPerSecond;
            leftFlutter = planesleft[e.Position].Flutter;
            //Для подсветки

            leftBombExiste = planesleft[e.Position].HandingBomb;
            leftRocketExiste = planesleft[e.Position].HandingRocket;
            leftCannonExiste = planesleft[e.Position].HandingCannon;
            leftTorpedoExiste = planesleft[e.Position].HandingTorpedo;
            leftAirToAirExiste = planesleft[e.Position].HandingAirToAir;
            leftAirToGroundExiste = planesleft[e.Position].HandingAirToGround;
            selectedRankIDLeft = planesleft[e.Position].RankId;
            _CompareImageLeft.SetImageResource(planesleft[e.Position].Image);
            _CompareLeftFlag.SetImageResource(planesleft[e.Position].FlagImage);
            _ComparePlaneLeftTextTurnAt0.SetText(planesleft[e.Position].TurnAt0.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            //      _ComparePlaneLeftTextClimb.SetText(planesleft[e.Position].Climb.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);          
            int newClimb = planesleft[e.Position].Climb;
            TimeSpan timeSpan = TimeSpan.FromSeconds(newClimb);
            string climbToShow = timeSpan.ToString(@"mm\:ss");
            _ComparePlaneLeftTextClimb.SetText(climbToShow, TextView.BufferType.Normal);
            _ComparePlaneLeftTextWeaponAndTurrels.SetText(planesleft[e.Position].WeaponAndTurrels, TextView.BufferType.Normal);

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            ISharedPreferencesEditor editor = prefs.Edit();
            var switchchecked = prefs.GetBoolean("key_kmhtomph", false);
            if (switchchecked)
            {
                var weight = planesleft[e.Position].Weight * 0.00110231131;
                var mphSpeedAt0 = planesleft[e.Position].MaxSpeedAt0 * 0.621371192;
                var mphSpeedAt5000 = planesleft[e.Position].MaxSpeedAt5000 * 0.621371192;
                var payload = planesleft[e.Position].BombLoad * 2.204622621849;
                var burstmass = planesleft[e.Position].WeaponVolleyPerSecond * 2.204622621849;
                var flutter = planesleft[e.Position].Flutter * 0.621371192;
                weight = Math.Round(weight, 1);
                mphSpeedAt0 = Math.Round(mphSpeedAt0, 0);
                mphSpeedAt5000 = Math.Round(mphSpeedAt5000, 0);
                payload = Math.Round(payload, 0);
                burstmass = Math.Round(burstmass, 2);
                flutter = Math.Round(flutter, 0);

                _ComparePlaneLabelTextClimb.SetText(context.Resources.GetString(Resource.String.PlaneClimbFeet), TextView.BufferType.Normal);


                _ComparePlaneLeftTextMaxSpeedAt0.SetText(mphSpeedAt0 + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _ComparePlaneLeftTextMaxSpeedAt5000.SetText(mphSpeedAt5000 + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _ComparePlaneLeftTextBombLoad.SetText(payload + context.Resources.GetString(Resource.String.AbbrLB), TextView.BufferType.Normal);
                _ComparePlaneLeftTextFlutter.SetText(flutter + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _ComparePlaneLeftTextWeight.SetText(weight + context.Resources.GetString(Resource.String.AbbrST), TextView.BufferType.Normal);
                _ComparePlaneLeftTextWeaponVolleyPerSecond.SetText(burstmass + context.Resources.GetString(Resource.String.AbbrLB_S), TextView.BufferType.Normal);

                if (selectedRankIDLeft == 5)
                {
                    var enginePower = planesleft[e.Position].EnginePower * 2.204622621849;
                    enginePower = Math.Round(enginePower, 0);

                    _ComparePlaneLeftTextEnginePower.SetText(enginePower + context.Resources.GetString(Resource.String.AbbrLBF), TextView.BufferType.Normal);
                    _ComparePlaneLeftTextThrustToWeightRatio.SetText(planesleft[e.Position].ThrustToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrLBF_LB), TextView.BufferType.Normal);
                }
                else
             if (selectedRankIDLeft == 6)
                {
                    var enginePower = planesleft[e.Position].EnginePower * 2.204622621849;
                    enginePower = Math.Round(enginePower, 0);

                    _ComparePlaneLeftTextEnginePower.SetText(enginePower + context.Resources.GetString(Resource.String.AbbrLBF), TextView.BufferType.Normal);
                    _ComparePlaneLeftTextThrustToWeightRatio.SetText(planesleft[e.Position].ThrustToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrLBF_LB), TextView.BufferType.Normal);
                }
                else
                {
                    var thrustToWeight = planesleft[e.Position].ThrustToWeightRatio / 2.204622621849;
                    thrustToWeight = Math.Round(thrustToWeight, 2);
                    _ComparePlaneLeftTextEnginePower.SetText(planesleft[e.Position].EnginePower.ToString() + context.Resources.GetString(Resource.String.AbbrH_P), TextView.BufferType.Normal);
                    _ComparePlaneLeftTextThrustToWeightRatio.SetText(thrustToWeight + context.Resources.GetString(Resource.String.AbbrHP_LB), TextView.BufferType.Normal);
                }
            }
            else
            {
                _ComparePlaneLabelTextClimb.SetText(context.Resources.GetString(Resource.String.PlaneClimb), TextView.BufferType.Normal);

                _ComparePlaneLeftTextMaxSpeedAt0.SetText(planesleft[e.Position].MaxSpeedAt0.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _ComparePlaneLeftTextMaxSpeedAt5000.SetText(planesleft[e.Position].MaxSpeedAt5000.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _ComparePlaneLeftTextBombLoad.SetText(planesleft[e.Position].BombLoad.ToString() + context.Resources.GetString(Resource.String.AbbrKG), TextView.BufferType.Normal);
                _ComparePlaneLeftTextFlutter.SetText(planesleft[e.Position].Flutter.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _ComparePlaneLeftTextWeight.SetText(planesleft[e.Position].Weight.ToString() + context.Resources.GetString(Resource.String.AbbrKG), TextView.BufferType.Normal);
                _ComparePlaneLeftTextWeaponVolleyPerSecond.SetText(planesleft[e.Position].WeaponVolleyPerSecond.ToString() + context.Resources.GetString(Resource.String.AbbrKG_S), TextView.BufferType.Normal);
                if (selectedRankIDLeft == 5)
                {
                    _ComparePlaneLeftTextEnginePower.SetText(planesleft[e.Position].EnginePower.ToString() + context.Resources.GetString(Resource.String.AbbrKGS), TextView.BufferType.Normal);
                    _ComparePlaneLeftTextThrustToWeightRatio.SetText(planesleft[e.Position].ThrustToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrKGS_KG), TextView.BufferType.Normal);
                }
                else
                  if (selectedRankIDLeft == 6)
                {
                    _ComparePlaneLeftTextEnginePower.SetText(planesleft[e.Position].EnginePower.ToString() + context.Resources.GetString(Resource.String.AbbrKGS), TextView.BufferType.Normal);
                    _ComparePlaneLeftTextThrustToWeightRatio.SetText(planesleft[e.Position].ThrustToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrKGS_KG), TextView.BufferType.Normal);
                }
                else
                {
                    _ComparePlaneLeftTextEnginePower.SetText(planesleft[e.Position].EnginePower.ToString() + context.Resources.GetString(Resource.String.AbbrH_P), TextView.BufferType.Normal);
                    _ComparePlaneLeftTextThrustToWeightRatio.SetText(planesleft[e.Position].ThrustToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrH_P_KG), TextView.BufferType.Normal);
                }

            }

          
            PlaneLeftHandingWeaponShower();
            PlaneShowBestViaBackgroundColor();
        }


        private void _CompareSpinnerPlaneRight_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            rightSpeed0 = planesright[e.Position].MaxSpeedAt0;
            rightSpeed5000 = planesright[e.Position].MaxSpeedAt5000;
            rightBombLoad = planesright[e.Position].BombLoad;
            rightTurnTime = planesright[e.Position].TurnAt0;
            rightClimb = planesright[e.Position].Climb;
            rightEnginePower = planesright[e.Position].EnginePower;
            rightWeight = planesright[e.Position].Weight;
            rightThrustToWeiht = planesright[e.Position].ThrustToWeightRatio;
            rightVolleyPerSecond = planesright[e.Position].WeaponVolleyPerSecond;
            rightFlutter = planesright[e.Position].Flutter;
            //Для подсветки

            rightBombExiste = planesright[e.Position].HandingBomb;
            rightRocketExiste = planesright[e.Position].HandingRocket;
            rightCannonExiste = planesright[e.Position].HandingCannon;
            rightTorpedoExiste = planesright[e.Position].HandingTorpedo;
            rightAirToAirExiste = planesright[e.Position].HandingAirToAir;
            rightAirToGroundExiste = planesright[e.Position].HandingAirToGround;
            selectedRankIDRight = planesright[e.Position].RankId;
            _CompareImageRight.SetImageResource(planesright[e.Position].Image);
            _CompareRightFlag.SetImageResource(planesright[e.Position].FlagImage);
            _ComparePlaneRightTextTurnAt0.SetText(planesright[e.Position].TurnAt0.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);
            //      _ComparePlaneRightTextClimb.SetText(planesright[e.Position].Climb.ToString() + context.Resources.GetString(Resource.String.AbbrS), TextView.BufferType.Normal);          
            int newClimb = planesright[e.Position].Climb;
            TimeSpan timeSpan = TimeSpan.FromSeconds(newClimb);
            string climbToShow = timeSpan.ToString(@"mm\:ss");
            _ComparePlaneRightTextClimb.SetText(climbToShow, TextView.BufferType.Normal);
            _ComparePlaneRightTextWeaponAndTurrels.SetText(planesright[e.Position].WeaponAndTurrels, TextView.BufferType.Normal);

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            ISharedPreferencesEditor editor = prefs.Edit();
            var switchchecked = prefs.GetBoolean("key_kmhtomph", false);
            if (switchchecked)
            {
                var weight = planesright[e.Position].Weight * 0.00110231131;
                var mphSpeedAt0 = planesright[e.Position].MaxSpeedAt0 * 0.621371192;
                var mphSpeedAt5000 = planesright[e.Position].MaxSpeedAt5000 * 0.621371192;
                var payload = planesright[e.Position].BombLoad * 2.204622621849;
                var burstmass = planesright[e.Position].WeaponVolleyPerSecond * 2.204622621849;
                var flutter = planesright[e.Position].Flutter * 0.621371192;
                weight = Math.Round(weight, 1);
                mphSpeedAt0 = Math.Round(mphSpeedAt0, 0);
                mphSpeedAt5000 = Math.Round(mphSpeedAt5000, 0);
                payload = Math.Round(payload, 0);
                burstmass = Math.Round(burstmass, 2);
                flutter = Math.Round(flutter, 0);

                _ComparePlaneRightTextMaxSpeedAt0.SetText(mphSpeedAt0 + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _ComparePlaneRightTextMaxSpeedAt5000.SetText(mphSpeedAt5000 + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _ComparePlaneRightTextBombLoad.SetText(payload + context.Resources.GetString(Resource.String.AbbrLB), TextView.BufferType.Normal);
                _ComparePlaneRightTextFlutter.SetText(flutter + context.Resources.GetString(Resource.String.AbbrMPH), TextView.BufferType.Normal);
                _ComparePlaneRightTextWeight.SetText(weight + context.Resources.GetString(Resource.String.AbbrST), TextView.BufferType.Normal);
                _ComparePlaneRightTextWeaponVolleyPerSecond.SetText(burstmass + context.Resources.GetString(Resource.String.AbbrLB_S), TextView.BufferType.Normal);

                if (selectedRankIDRight == 5)
                {
                    var enginePower = planesright[e.Position].EnginePower * 2.204622621849;
                    enginePower = Math.Round(enginePower, 0);

                    _ComparePlaneRightTextEnginePower.SetText(enginePower + context.Resources.GetString(Resource.String.AbbrLBF), TextView.BufferType.Normal);
                    _ComparePlaneRightTextThrustToWeightRatio.SetText(planesright[e.Position].ThrustToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrLBF_LB), TextView.BufferType.Normal);
                }
                else
             if (selectedRankIDRight == 6)
                {
                    var enginePower = planesright[e.Position].EnginePower * 2.204622621849;
                    enginePower = Math.Round(enginePower, 0);

                    _ComparePlaneRightTextEnginePower.SetText(enginePower + context.Resources.GetString(Resource.String.AbbrLBF), TextView.BufferType.Normal);
                    _ComparePlaneRightTextThrustToWeightRatio.SetText(planesright[e.Position].ThrustToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrLBF_LB), TextView.BufferType.Normal);
                }
                else
                {
                    var thrustToWeight = planesright[e.Position].ThrustToWeightRatio / 2.204622621849;
                    thrustToWeight = Math.Round(thrustToWeight, 2);
                    _ComparePlaneRightTextEnginePower.SetText(planesright[e.Position].EnginePower.ToString() + context.Resources.GetString(Resource.String.AbbrH_P), TextView.BufferType.Normal);
                    _ComparePlaneRightTextThrustToWeightRatio.SetText(thrustToWeight + context.Resources.GetString(Resource.String.AbbrHP_LB), TextView.BufferType.Normal);
                }
            }
            else
            {
                _ComparePlaneRightTextMaxSpeedAt0.SetText(planesright[e.Position].MaxSpeedAt0.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _ComparePlaneRightTextMaxSpeedAt5000.SetText(planesright[e.Position].MaxSpeedAt5000.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _ComparePlaneRightTextBombLoad.SetText(planesright[e.Position].BombLoad.ToString() + context.Resources.GetString(Resource.String.AbbrKG), TextView.BufferType.Normal);
                _ComparePlaneRightTextFlutter.SetText(planesright[e.Position].Flutter.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);
                _ComparePlaneRightTextWeight.SetText(planesright[e.Position].Weight.ToString() + context.Resources.GetString(Resource.String.AbbrKG), TextView.BufferType.Normal);
                _ComparePlaneRightTextWeaponVolleyPerSecond.SetText(planesright[e.Position].WeaponVolleyPerSecond.ToString() + context.Resources.GetString(Resource.String.AbbrKG_S), TextView.BufferType.Normal);
                if (selectedRankIDRight == 5)
                {
                    _ComparePlaneRightTextEnginePower.SetText(planesright[e.Position].EnginePower.ToString() + context.Resources.GetString(Resource.String.AbbrKGS), TextView.BufferType.Normal);
                    _ComparePlaneRightTextThrustToWeightRatio.SetText(planesright[e.Position].ThrustToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrKGS_KG), TextView.BufferType.Normal);
                }
                else
                  if (selectedRankIDRight == 6)
                {
                    _ComparePlaneRightTextEnginePower.SetText(planesright[e.Position].EnginePower.ToString() + context.Resources.GetString(Resource.String.AbbrKGS), TextView.BufferType.Normal);
                    _ComparePlaneRightTextThrustToWeightRatio.SetText(planesright[e.Position].ThrustToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrKGS_KG), TextView.BufferType.Normal);
                }
                else
                {
                    _ComparePlaneRightTextEnginePower.SetText(planesright[e.Position].EnginePower.ToString() + context.Resources.GetString(Resource.String.AbbrH_P), TextView.BufferType.Normal);
                    _ComparePlaneRightTextThrustToWeightRatio.SetText(planesright[e.Position].ThrustToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrH_P_KG), TextView.BufferType.Normal);
                }

            }


            PlaneRightHandingWeaponShower();
            PlaneShowBestViaBackgroundColor();
        }

    
 



        public void PlaneLeftSelector()
        {
            if (selectedNationLeft == 100 && selectedRankLeft == 100)
            {
                planesleft = PlaneCollection.GetPlane();
                AdapterPlaneLeft = new PlaneAdapter(this, planesleft);
                _CompareSpinnerPlaneLeft.Adapter = AdapterPlaneLeft;
            }
            else
            if (selectedNationLeft == 100)
            {
                List<Plane> planesAll = PlaneCollection.GetPlane();
                var planevar = from p in planesAll
                               where p.RankId == selectedRankLeft
                               select p;
                planesleft = planevar.ToList<Plane>();
                AdapterPlaneLeft = new PlaneAdapter(this, planesleft);
                _CompareSpinnerPlaneLeft.Adapter = AdapterPlaneLeft;
            }
            else
            if (selectedRankLeft == 100)
            {
                List<Plane> planesAll = PlaneCollection.GetPlane();
                var planevar = from p in planesAll
                               where p.NationId == selectedNationLeft
                               select p;
                planesleft = planevar.ToList<Plane>();
                AdapterPlaneLeft = new PlaneAdapter(this, planesleft);
                _CompareSpinnerPlaneLeft.Adapter = AdapterPlaneLeft;
            }
            else
            {
                planesleft = PlaneSelectorWithout100left(selectedNationLeft, selectedRankLeft);
                AdapterPlaneLeft = new PlaneAdapter(this, planesleft);
                _CompareSpinnerPlaneLeft.Adapter = AdapterPlaneLeft;
            }
        }
        public void PlaneRightSelector()
        {
            if (selectedNationRight == 100 && selectedRankRight == 100)
            {
                planesright = PlaneCollection.GetPlane();
                AdapterPlaneRight = new PlaneAdapter(this, planesright);
                _CompareSpinnerPlaneRight.Adapter = AdapterPlaneRight;
            }
            else
            if (selectedNationRight == 100)
            {
                List<Plane> planesAll = PlaneCollection.GetPlane();
                var planevar = from p in planesAll
                               where p.RankId == selectedRankRight
                               select p;
                planesright = planevar.ToList<Plane>();
                AdapterPlaneRight = new PlaneAdapter(this, planesright);
                _CompareSpinnerPlaneRight.Adapter = AdapterPlaneRight;
            }
            else
if (selectedRankRight == 100)
            {
                List<Plane> planesAll = PlaneCollection.GetPlane();
                var planevar = from p in planesAll
                               where p.NationId == selectedNationRight
                               select p;
                planesright = planevar.ToList<Plane>();
                AdapterPlaneRight = new PlaneAdapter(this, planesright);
                _CompareSpinnerPlaneRight.Adapter = AdapterPlaneRight;
            }
            else
            {
                planesright = PlaneSelectorWtithout100right(selectedNationRight, selectedRankRight);
                AdapterPlaneRight = new PlaneAdapter(this, planesright);
                _CompareSpinnerPlaneRight.Adapter = AdapterPlaneRight;
            }
        }

        public List<Plane> PlaneSelectorWithout100left(int selectedNationLeft, int selectedRankLeft)
        {
            this.selectedNationLeft = selectedNationLeft;
            this.selectedRankLeft = selectedRankLeft;

            List<Plane> planesAll = PlaneCollection.GetPlane();
            var planevar = from p in planesAll
                           where p.NationId == selectedNationLeft
                           where p.RankId == selectedRankLeft
                           select p;
            return planevar.ToList<Plane>();
        }

        public List<Plane> PlaneSelectorWtithout100right(int selectedNationRight, int selectedRankRight)
        {
            this.selectedNationRight = selectedNationRight;
            this.selectedRankRight = selectedRankRight;

            List<Plane> planesAll = PlaneCollection.GetPlane();
            var planevar = from p in planesAll
                           where p.NationId == selectedNationRight
                           where p.RankId == selectedRankRight
                           select p;
            return planevar.ToList<Plane>();
        }




        public void PlaneLeftHandingWeaponShower()
        {
            if(leftBombExiste==true)
            {
                _CompareLeftHandlingBomb.SetImageResource(Resource.Drawable._handingBomb);
            }
            else
            {
                _CompareLeftHandlingBomb.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (leftRocketExiste == true)
            {
                _CompareLeftHandlingRocket.SetImageResource(Resource.Drawable._handingRocket);
            }
            else
            {
                _CompareLeftHandlingRocket.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftAirToAirExiste == true)
            {
                _CompareLeftHandlingAirToAir.SetImageResource(Resource.Drawable._handingAirToAir);
            }
            else
            {
                _CompareLeftHandlingAirToAir.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftAirToGroundExiste == true)
            {
                _CompareLeftHandlingAirToGround.SetImageResource(Resource.Drawable._handingAGM);
            }
            else
            {
                _CompareLeftHandlingAirToGround.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftCannonExiste == true)
            {
                _CompareLeftHandlingCannon.SetImageResource(Resource.Drawable._handingCannon);
            }
            else
            {
                _CompareLeftHandlingCannon.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (leftTorpedoExiste == true)
            {
                _CompareLeftHandlingTorpedo.SetImageResource(Resource.Drawable._handingTorpedo);
            }
            else
            {
                _CompareLeftHandlingTorpedo.SetImageResource(Resource.Drawable._handingTransparent);
            }
        }
        private void PlaneRightHandingWeaponShower()
        {
            if (rightBombExiste == true)
            {
                _CompareRightHandlingBomb.SetImageResource(Resource.Drawable._handingBomb);
            }
            else
            {
                _CompareRightHandlingBomb.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (rightRocketExiste == true)
            {
                _CompareRightHandlingRocket.SetImageResource(Resource.Drawable._handingRocket);
            }
            else
            {
                _CompareRightHandlingRocket.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (rightAirToAirExiste == true)
            {
                _CompareRightHandlingAirToAir.SetImageResource(Resource.Drawable._handingAirToAir);
            }
            else
            {
                _CompareRightHandlingAirToAir.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightAirToGroundExiste == true)
            {
                _CompareRightHandlingAirToGround.SetImageResource(Resource.Drawable._handingAGM);
            }
            else
            {
                _CompareRightHandlingAirToGround.SetImageResource(Resource.Drawable._handingTransparent);
            }

            if (rightCannonExiste == true)
            {
                _CompareRightHandlingCannon.SetImageResource(Resource.Drawable._handingCannon);
            }
            else
            {
                _CompareRightHandlingCannon.SetImageResource(Resource.Drawable._handingTransparent);
            }
            if (rightTorpedoExiste == true)
            {
                _CompareRightHandlingTorpedo.SetImageResource(Resource.Drawable._handingTorpedo);
            }
            else
            {
                _CompareRightHandlingTorpedo.SetImageResource(Resource.Drawable._handingTransparent);
            }
        }

        private void PlaneShowBestViaBackgroundColor()
        {
            if (leftSpeed0>rightSpeed0)
            {
                _ComparePlaneLeftTextMaxSpeedAt0.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _ComparePlaneRightTextMaxSpeedAt0.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
            if(leftSpeed0<rightSpeed0)
            {
                _ComparePlaneLeftTextMaxSpeedAt0.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _ComparePlaneRightTextMaxSpeedAt0.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if(leftSpeed0==rightSpeed0)
            {
                _ComparePlaneLeftTextMaxSpeedAt0.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _ComparePlaneRightTextMaxSpeedAt0.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }




            if (leftSpeed5000 > rightSpeed5000)
            {
                _ComparePlaneLeftTextMaxSpeedAt5000.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _ComparePlaneRightTextMaxSpeedAt5000.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
          if (leftSpeed5000 < rightSpeed5000)
            {
                _ComparePlaneLeftTextMaxSpeedAt5000.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _ComparePlaneRightTextMaxSpeedAt5000.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftSpeed5000 == rightSpeed5000)
            {
                _ComparePlaneLeftTextMaxSpeedAt5000.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _ComparePlaneRightTextMaxSpeedAt5000.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }




            if (leftBombLoad > rightBombLoad)
            {
                _ComparePlaneLeftTextBombLoad.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _ComparePlaneRightTextBombLoad.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
            if (leftBombLoad < rightBombLoad)
            {
                _ComparePlaneLeftTextBombLoad.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _ComparePlaneRightTextBombLoad.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftBombLoad == rightBombLoad)
            {
                _ComparePlaneLeftTextBombLoad.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _ComparePlaneRightTextBombLoad.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }



            if (leftTurnTime < rightTurnTime)
            {
                _ComparePlaneLeftTextTurnAt0.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _ComparePlaneRightTextTurnAt0.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
            if (leftTurnTime > rightTurnTime)
            {
                _ComparePlaneLeftTextTurnAt0.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _ComparePlaneRightTextTurnAt0.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftTurnTime == rightTurnTime)
            {
                _ComparePlaneLeftTextTurnAt0.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _ComparePlaneRightTextTurnAt0.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }



            if (leftClimb < rightClimb)
            {
                _ComparePlaneLeftTextClimb.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _ComparePlaneRightTextClimb.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
            if (leftClimb > rightClimb)
            {
                _ComparePlaneLeftTextClimb.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _ComparePlaneRightTextClimb.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftClimb == rightClimb)
            {
                _ComparePlaneLeftTextClimb.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _ComparePlaneRightTextClimb.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }




            if (leftFlutter > rightFlutter)
            {
                _ComparePlaneLeftTextFlutter.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _ComparePlaneRightTextFlutter.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
       if (leftFlutter < rightFlutter)
            {
                _ComparePlaneLeftTextFlutter.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _ComparePlaneRightTextFlutter.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftFlutter == rightFlutter)
            {
                _ComparePlaneLeftTextFlutter.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _ComparePlaneRightTextFlutter.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }


            if ((selectedRankIDLeft == 5 | selectedRankIDLeft == 6) && (selectedRankIDRight == 1 | selectedRankIDRight == 2 | selectedRankIDRight == 3 | selectedRankIDRight == 4))
            {
                _ComparePlaneLeftTextEnginePower.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _ComparePlaneRightTextEnginePower.SetBackgroundResource(Resource.Drawable._gradientEqual);
            } else
            if ((selectedRankIDLeft == 1 | selectedRankIDLeft == 2 | selectedRankIDLeft == 3 | selectedRankIDLeft == 4) && (selectedRankIDRight == 5 | selectedRankIDRight == 6))
            {
                _ComparePlaneLeftTextEnginePower.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _ComparePlaneRightTextEnginePower.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }else
            //////////////////////////////////////
            if (leftEnginePower > rightEnginePower)
            {
                _ComparePlaneLeftTextEnginePower.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _ComparePlaneRightTextEnginePower.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
            if (leftEnginePower < rightEnginePower)
            {
                _ComparePlaneLeftTextEnginePower.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _ComparePlaneRightTextEnginePower.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftEnginePower == rightEnginePower)
            {
                _ComparePlaneLeftTextEnginePower.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _ComparePlaneRightTextEnginePower.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }
            //////////////////////////////////////////


            if (leftWeight < rightWeight)
            {
                _ComparePlaneLeftTextWeight.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _ComparePlaneRightTextWeight.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
            if (leftWeight > rightWeight)
            {
                _ComparePlaneLeftTextWeight.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _ComparePlaneRightTextWeight.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftWeight == rightWeight)
            {
                _ComparePlaneLeftTextWeight.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _ComparePlaneRightTextWeight.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }


            if ((selectedRankIDLeft == 5 | selectedRankIDLeft == 6) && (selectedRankIDRight == 1 | selectedRankIDRight == 2 | selectedRankIDRight == 3 | selectedRankIDRight == 4))
            {
                _ComparePlaneLeftTextThrustToWeightRatio.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _ComparePlaneRightTextThrustToWeightRatio.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }
            else
            if ((selectedRankIDLeft == 1 | selectedRankIDLeft == 2 | selectedRankIDLeft == 3 | selectedRankIDLeft == 4) && (selectedRankIDRight == 5 | selectedRankIDRight == 6))
            {
                _ComparePlaneLeftTextThrustToWeightRatio.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _ComparePlaneRightTextThrustToWeightRatio.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }
            else
            /////////////////////
            if (leftThrustToWeiht > rightThrustToWeiht)
            {
                _ComparePlaneLeftTextThrustToWeightRatio.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _ComparePlaneRightTextThrustToWeightRatio.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
            if (leftThrustToWeiht < rightThrustToWeiht)
            {
                _ComparePlaneLeftTextThrustToWeightRatio.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _ComparePlaneRightTextThrustToWeightRatio.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftThrustToWeiht == rightThrustToWeiht)
            {
                _ComparePlaneLeftTextThrustToWeightRatio.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _ComparePlaneRightTextThrustToWeightRatio.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }
            ///////////////////////


            if (leftVolleyPerSecond > rightVolleyPerSecond)
            {
                _ComparePlaneLeftTextWeaponVolleyPerSecond.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftBest);
                _ComparePlaneRightTextWeaponVolleyPerSecond.SetBackgroundResource(Resource.Drawable._gradientForCompareRightWorse);
            }
            else
            if (leftVolleyPerSecond < rightVolleyPerSecond)
            {
                _ComparePlaneLeftTextWeaponVolleyPerSecond.SetBackgroundResource(Resource.Drawable._gradientForCompareLeftWorse);
                _ComparePlaneRightTextWeaponVolleyPerSecond.SetBackgroundResource(Resource.Drawable._gradientForCompareRightBest);
            }
            else if (leftVolleyPerSecond == rightVolleyPerSecond)
            {
                _ComparePlaneLeftTextWeaponVolleyPerSecond.SetBackgroundResource(Resource.Drawable._gradientEqual);
                _ComparePlaneRightTextWeaponVolleyPerSecond.SetBackgroundResource(Resource.Drawable._gradientEqual);
            }
        }
    }
}
