using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using WarThunderComparer.comparerData.Adapters;
using WarThunderComparer.comparerData.Collections;
using Android.Graphics;
using Android.Preferences;

namespace WarThunderComparer.comparerData.Adapters
{
    class ListViewTheBestTankAdapter:BaseAdapter
    {
        private Activity activitys;
        private List<Tank> tanks;
        Context context;
        private TextView txtName;
        private TextView txtMaxSpeedAtTerrain;
        private TextView txtAccelerationTo100;
        private TextView txtPowerToWeightRatio;
        private TextView txtPenetration;
        private TextView txtReloadTime;
        private TextView txtReducedArmorFrontTurret;
        private TextView txtReducedArmorTopSheet;

       
        private ImageView theBestIco1;
        private ImageView theBestIco2;
        private ImageView theBestIco3;
        private ImageView theBestIco4;
        private ImageView theBestIco5;
        private ImageView theBestIco6;
        private ImageView theBestIco7;

        public override int Count => tanks.Count;


        public ListViewTheBestTankAdapter(Activity activitys, List<Tank> tanks)
        {
            this.activitys = activitys;
            this.tanks = tanks;
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            context = Application.Context;
            var view = convertView ?? activitys.LayoutInflater.Inflate(Resource.Layout._modelTheBestTankListViewml, parent, false);


        ImageView img = view.FindViewById<ImageView>(Resource.Id.imglistviewmodelT);
        txtName= view.FindViewById<TextView>(Resource.Id.textTheBestTankName);
        txtMaxSpeedAtTerrain= view.FindViewById<TextView>(Resource.Id.textMaxSpeedAtTerrain);
        txtAccelerationTo100= view.FindViewById<TextView>(Resource.Id.textAccelerationTo100);
        txtPowerToWeightRatio= view.FindViewById<TextView>(Resource.Id.textPowerToWeightRatio);
        ImageView flag = view.FindViewById<ImageView>(Resource.Id.theBestFlagT);
        txtPenetration = view.FindViewById<TextView>(Resource.Id.textPenetration);
        txtReloadTime= view.FindViewById<TextView>(Resource.Id.textReloadTime);
        txtReducedArmorFrontTurret= view.FindViewById<TextView>(Resource.Id.textReducedArmorFrontTurret);
        txtReducedArmorTopSheet= view.FindViewById<TextView>(Resource.Id.textReducedArmorTopSheet);


            theBestIco1 = view.FindViewById<ImageView>(Resource.Id.theBestTankIco1);
            theBestIco2 = view.FindViewById<ImageView>(Resource.Id.theBestTankIco2);
            theBestIco3 = view.FindViewById<ImageView>(Resource.Id.theBestTankIco3);
            theBestIco4 = view.FindViewById<ImageView>(Resource.Id.theBestTankIco4);
            theBestIco5 = view.FindViewById<ImageView>(Resource.Id.theBestTankIco5);
            theBestIco6 = view.FindViewById<ImageView>(Resource.Id.theBestTankIco6);
            theBestIco7 = view.FindViewById<ImageView>(Resource.Id.theBestTankIco7);

            img.SetImageResource(tanks[position].Image);
            flag.SetImageResource(tanks[position].FlagImageTheBest);
            txtName.Text = tanks[position].Name;
            txtAccelerationTo100.Text = tanks[position].AccelerationTo100.ToString() + context.Resources.GetString(Resource.String.AbbrS);
            txtPowerToWeightRatio.Text = tanks[position].PowerToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrH_P_T);
            txtReloadTime.Text = tanks[position].ReloadTime.ToString() + context.Resources.GetString(Resource.String.AbbrS);

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            ISharedPreferencesEditor editor = prefs.Edit();
            var switchchecked = prefs.GetBoolean("key_kmhtomph", false);
            if (switchchecked)
            {
                var maxSpeedAtTerrain = tanks[position].MaxSpeedAtTerrain * 0.621371192;
                var penetration = tanks[position].Penetration * 0.039370;
                var reducedArmorFrontTurret = tanks[position].ReducedArmorFrontTurret * 0.039370;
                var reducedArmorTopSheet = tanks[position].ReducedArmorTopSheet * 0.039370;
                maxSpeedAtTerrain = System.Math.Round(maxSpeedAtTerrain, 0);
                penetration = System.Math.Round(penetration, 2);
                reducedArmorFrontTurret = System.Math.Round(reducedArmorFrontTurret, 2);
                reducedArmorTopSheet = System.Math.Round(reducedArmorTopSheet, 2);
                txtMaxSpeedAtTerrain.Text = maxSpeedAtTerrain + context.Resources.GetString(Resource.String.AbbrMPH);
                txtPenetration.Text = penetration + context.Resources.GetString(Resource.String.AbbrINCH);
                txtReducedArmorFrontTurret.Text = reducedArmorFrontTurret + context.Resources.GetString(Resource.String.AbbrINCH);
                txtReducedArmorTopSheet.Text = reducedArmorTopSheet + context.Resources.GetString(Resource.String.AbbrINCH);

            }
            else
            {
                txtMaxSpeedAtTerrain.Text = tanks[position].MaxSpeedAtTerrain.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H);
                txtPenetration.Text = tanks[position].Penetration.ToString() + context.Resources.GetString(Resource.String.AbbrMM);
                txtReducedArmorFrontTurret.Text = tanks[position].ReducedArmorFrontTurret.ToString() + context.Resources.GetString(Resource.String.AbbrMM);
                txtReducedArmorTopSheet.Text = tanks[position].ReducedArmorTopSheet.ToString() + context.Resources.GetString(Resource.String.AbbrMM);

            }


            if (TheBestTank.SelectedTask == 1)
            {
                txtMaxSpeedAtTerrain.Alpha = 1;
                theBestIco1.Alpha = 1;

            }
            if (TheBestTank.SelectedTask == 2)
            {
                txtAccelerationTo100.Alpha = 1;
                theBestIco2.Alpha = 1;
            }
            if (TheBestTank.SelectedTask == 3)
            {
                txtPowerToWeightRatio.Alpha = 1;
                theBestIco3.Alpha = 1;

            }
            if (TheBestTank.SelectedTask == 4)
            {
                txtPenetration.Alpha = 1;
                theBestIco4.Alpha = 1;

            }
            if (TheBestTank.SelectedTask == 5)
            {
                txtReloadTime.Alpha = 1;
                theBestIco5.Alpha = 1;
            }
            if (TheBestTank.SelectedTask == 6)
            {
                txtReducedArmorFrontTurret.Alpha = 1;
                theBestIco6.Alpha = 1;

            }
            if (TheBestTank.SelectedTask == 7)
            {
                txtReducedArmorTopSheet.Alpha = 1;
                theBestIco7.Alpha = 1;

            }

            return view;

        }
    }
}