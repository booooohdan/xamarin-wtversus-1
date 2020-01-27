using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using WarThunderComparer.comparerData.Adapters;
using WarThunderComparer.comparerData.Collections;

namespace WarThunderComparer.comparerData.Adapters
{

    class ListViewInfoShipAdapter:BaseAdapter
    {
        private Activity activitys;
        private List<Ship> ships;
        Context context;
        public ListViewInfoShipAdapter(Activity activitys, List<Ship>ships)
        {
            this.ships = ships;
            this.activitys = activitys;
            context = Application.Context;
        }

        public override int Count => ships.Count;

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
            var view = convertView ?? activitys.LayoutInflater.Inflate(Resource.Layout._modelInfoListView, parent, false);
            var txtName = view.FindViewById<TextView>(Resource.Id.infoPotentialEnemyName);
            var txtBR = view.FindViewById<TextView>(Resource.Id.infoPotentialEnemyBR);
            var txtNation = view.FindViewById<TextView>(Resource.Id.infoPotentialEnemyNation);
            var img = view.FindViewById<ImageView>(Resource.Id.imglistviewmodel);


            txtName.Text = ships[position].Name;
            txtBR.Text = ships[position].BR.ToString("0.0#");
            txtNation.Text = ships[position].Nation;
            img.SetImageResource(ships[position].Image);


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


                if (InfoShip.SelectedPotentialTaskShip == 1)
                {
                    txtBR.Text = mainCaliberSize + context.Resources.GetString(Resource.String.AbbrINCH);
                }
                if (InfoShip.SelectedPotentialTaskShip == 2)
                {
                    txtBR.Text = ships[position].MainCaliberItem.ToString() + context.Resources.GetString(Resource.String.AbbrITEMS);
                }
                if (InfoShip.SelectedPotentialTaskShip == 3)
                {
                    txtBR.Text = mainCaliberTNT + context.Resources.GetString(Resource.String.AbbrLB);
                }
                if (InfoShip.SelectedPotentialTaskShip == 4)
                {
                    txtBR.Text = maxSpeed + context.Resources.GetString(Resource.String.AbbrMPH);
                }
                if (InfoShip.SelectedPotentialTaskShip == 5)
                {
                    txtBR.Text = ships[position].TorpedoItem.ToString() + context.Resources.GetString(Resource.String.AbbrITEMS);
                }
                if (InfoShip.SelectedPotentialTaskShip == 6)
                {
                    txtBR.Text = torpedoTNT + context.Resources.GetString(Resource.String.AbbrLB);
                }
                if (InfoShip.SelectedPotentialTaskShip == 7)
                {
                    txtBR.Text = displacement + context.Resources.GetString(Resource.String.AbbrST);
                }
            }
            else
            {
                if (InfoShip.SelectedPotentialTaskShip == 1)
                {
                    txtBR.Text = ships[position].MainCaliberSize.ToString() + context.Resources.GetString(Resource.String.AbbrMM);
                }
                if (InfoShip.SelectedPotentialTaskShip == 2)
                {
                    txtBR.Text = ships[position].MainCaliberItem.ToString() + context.Resources.GetString(Resource.String.AbbrITEMS);
                }
                if (InfoShip.SelectedPotentialTaskShip == 3)
                {
                    txtBR.Text = ships[position].MainCaliberTNT.ToString() + context.Resources.GetString(Resource.String.AbbrKG);
                }
                if (InfoShip.SelectedPotentialTaskShip == 4)
                {
                    txtBR.Text = ships[position].MaxSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H);
                }
                if (InfoShip.SelectedPotentialTaskShip == 5)
                {
                    txtBR.Text = ships[position].TorpedoItem.ToString() + context.Resources.GetString(Resource.String.AbbrITEMS);
                }
                if (InfoShip.SelectedPotentialTaskShip == 6)
                {
                    txtBR.Text = ships[position].TorpedoTNT.ToString() + context.Resources.GetString(Resource.String.AbbrKG);
                }
                if (InfoShip.SelectedPotentialTaskShip == 7)
                {
                    txtBR.Text = ships[position].Displacement.ToString() + context.Resources.GetString(Resource.String.AbbrT);
                }
            }
               

            return view;
        }
    }
}