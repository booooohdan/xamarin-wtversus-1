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
    class ListViewTheBestShipAdapter : BaseAdapter
    {
        private Activity activitys;
        private List<Ship> ships;
        Context context;

        private TextView txtName;
        private TextView txtCaliberSize;
        private TextView txtCaliberItem;
        private TextView txtCaliberTNT;
        private TextView txtMaxSpeed;
        private TextView txtTorpedoTNT;
        private TextView txtTorpedoItem;
        private TextView txtDisplacement;

        private ImageView theBestIco1;
        private ImageView theBestIco2;
        private ImageView theBestIco3;
        private ImageView theBestIco4;
        private ImageView theBestIco5;
        private ImageView theBestIco6;
        private ImageView theBestIco7;

        public override int Count => ships.Count;

        public ListViewTheBestShipAdapter(Activity activitys, List<Ship>ships)
        {
            this.activitys = activitys;
            this.ships = ships;
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
            var view = convertView ?? activitys.LayoutInflater.Inflate(Resource.Layout._modelTheBestShipListViewml, parent, false);


            ImageView img = view.FindViewById<ImageView>(Resource.Id.imglistviewmodelS);
            ImageView flag = view.FindViewById<ImageView>(Resource.Id.theBestFlagS);
            txtName = view.FindViewById<TextView>(Resource.Id.textTheBestShipName);
            txtCaliberSize = view.FindViewById<TextView>(Resource.Id.textTheBestShipCaliber);
            txtCaliberItem = view.FindViewById<TextView>(Resource.Id.textTheBestShipCaliberItem);
            txtCaliberTNT = view.FindViewById<TextView>(Resource.Id.textTheBestShipCaliberTNT);
            txtMaxSpeed = view.FindViewById<TextView>(Resource.Id.textTheBestShipMaxSpeed);
            txtTorpedoItem = view.FindViewById<TextView>(Resource.Id.textTheBestShipTorpedoItem);
            txtTorpedoTNT = view.FindViewById<TextView>(Resource.Id.textTheBestShipTorpedoTNT);
            txtDisplacement = view.FindViewById<TextView>(Resource.Id.textTheBestShipDisplacement);


            theBestIco1 = view.FindViewById<ImageView>(Resource.Id.theBestShipIco1);
            theBestIco2 = view.FindViewById<ImageView>(Resource.Id.theBestShipIco2);
            theBestIco3 = view.FindViewById<ImageView>(Resource.Id.theBestShipIco3);
            theBestIco4 = view.FindViewById<ImageView>(Resource.Id.theBestShipIco4);
            theBestIco5 = view.FindViewById<ImageView>(Resource.Id.theBestShipIco5);
            theBestIco6 = view.FindViewById<ImageView>(Resource.Id.theBestShipIco6);
            theBestIco7 = view.FindViewById<ImageView>(Resource.Id.theBestShipIco7);

            img.SetImageResource(ships[position].Image);
            flag.SetImageResource(ships[position].FlagImageTheBest);
            txtName.Text = ships[position].Name;
            txtCaliberItem.Text = ships[position].MainCaliberItem.ToString() + context.Resources.GetString(Resource.String.AbbrITEMS);
            txtTorpedoItem.Text = ships[position].TorpedoItem.ToString() + context.Resources.GetString(Resource.String.AbbrITEMS);

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            ISharedPreferencesEditor editor = prefs.Edit();
            var switchchecked = prefs.GetBoolean("key_kmhtomph", false);
            if (switchchecked)
            {
                var maxSpeed = ships[position].MaxSpeed * 0.621371192;
                var mainCaliberSize = ships[position].MainCaliberSize * 0.039370;
                var mainCaliberTNT = ships[position].MainCaliberTNT * 2.204622621849;
                var torpedoTNT = ships[position].TorpedoTNT * 2.204622621849;
                var displacement = ships[position].Displacement * 1.10231131;
                maxSpeed = System.Math.Round(maxSpeed, 0);
                mainCaliberSize = System.Math.Round(mainCaliberSize, 1);
                mainCaliberTNT = System.Math.Round(mainCaliberTNT, 1);
                torpedoTNT = System.Math.Round(torpedoTNT, 0);
                displacement = System.Math.Round(displacement, 0);

                txtMaxSpeed.Text = maxSpeed + context.Resources.GetString(Resource.String.AbbrMPH);
                txtCaliberSize.Text = mainCaliberSize + context.Resources.GetString(Resource.String.AbbrINCH);
                txtCaliberTNT.Text = mainCaliberTNT + context.Resources.GetString(Resource.String.AbbrLB);
                txtTorpedoTNT.Text = torpedoTNT + context.Resources.GetString(Resource.String.AbbrLB);
                txtDisplacement.Text = displacement + context.Resources.GetString(Resource.String.AbbrST);
            }
            else
            {
                txtMaxSpeed.Text = ships[position].MaxSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H);
                txtCaliberSize.Text = ships[position].MainCaliberSize.ToString() + context.Resources.GetString(Resource.String.AbbrMM);
                txtCaliberTNT.Text = ships[position].MainCaliberTNT.ToString() + context.Resources.GetString(Resource.String.AbbrKG);
                txtTorpedoTNT.Text = ships[position].TorpedoTNT.ToString() + context.Resources.GetString(Resource.String.AbbrKG);
                txtDisplacement.Text = ships[position].Displacement.ToString() + context.Resources.GetString(Resource.String.AbbrT);
            }


            if (TheBestShip.SelectedTask == 1)
            {
                txtCaliberSize.Alpha = 1;
                theBestIco1.Alpha = 1;
            }
            if (TheBestShip.SelectedTask == 2)
            {
                txtCaliberItem.Alpha = 1;
                theBestIco2.Alpha = 1;
            }
            if (TheBestShip.SelectedTask == 3)
            {
                txtCaliberTNT.Alpha = 1;
                theBestIco3.Alpha = 1;
            }
            if (TheBestShip.SelectedTask == 4)
            {
                txtMaxSpeed.Alpha = 1;
                theBestIco4.Alpha = 1;
            }
            if (TheBestShip.SelectedTask == 5)
            {
                txtTorpedoItem.Alpha = 1;
                theBestIco5.Alpha = 1;
            }
            if (TheBestShip.SelectedTask == 6)
            {
                txtTorpedoTNT.Alpha = 1;
                theBestIco6.Alpha = 1;
            }
            if (TheBestShip.SelectedTask == 7)
            {
                txtDisplacement.Alpha = 1;
                theBestIco7.Alpha = 1;
            }

            return view;
            
        }
    }
}