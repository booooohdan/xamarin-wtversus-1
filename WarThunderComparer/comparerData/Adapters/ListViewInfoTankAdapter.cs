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
    class ListViewInfoTankAdapter : BaseAdapter
    {
        private Activity activitys;
        private List<Tank> tanks;
        Context context;
        public ListViewInfoTankAdapter(Activity activitys, List<Tank> tanks)
        {
            this.activitys = activitys;
            this.tanks = tanks;
            context = Application.Context;
        }


        public override int Count => tanks.Count;

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

            txtName.Text = tanks[position].Name;
            txtBR.Text =tanks[position].BR.ToString("0.0#");
            txtNation.Text = tanks[position].Nation;
            img.SetImageResource(tanks[position].Image);

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


                if (InfoTank.SelectedPotentialTask == 1)
                {
                    txtBR.Text = maxSpeedAtTerrain + context.Resources.GetString(Resource.String.AbbrMPH);
                }
                if (InfoTank.SelectedPotentialTask == 2)
                {
                    txtBR.Text = tanks[position].AccelerationTo100.ToString() + context.Resources.GetString(Resource.String.AbbrS);
                }
                if (InfoTank.SelectedPotentialTask == 3)
                {
                    txtBR.Text = tanks[position].PowerToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrH_P_T);
                }
                if (InfoTank.SelectedPotentialTask == 4)
                {
                    txtBR.Text = penetration + context.Resources.GetString(Resource.String.AbbrINCH);
                }
                if (InfoTank.SelectedPotentialTask == 5)
                {
                    txtBR.Text = tanks[position].ReloadTime.ToString() + context.Resources.GetString(Resource.String.AbbrS);
                }
                if (InfoTank.SelectedPotentialTask == 6)
                {
                    txtBR.Text = reducedArmorFrontTurret + context.Resources.GetString(Resource.String.AbbrINCH);
                }
                if (InfoTank.SelectedPotentialTask == 7)
                {
                    txtBR.Text = reducedArmorTopSheet + context.Resources.GetString(Resource.String.AbbrINCH);
                }
            }
            else
            {
                if (InfoTank.SelectedPotentialTask == 1)
                {
                    txtBR.Text = tanks[position].MaxSpeedAtTerrain.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H);
                }
                if (InfoTank.SelectedPotentialTask == 2)
                {
                    txtBR.Text = tanks[position].AccelerationTo100.ToString() + context.Resources.GetString(Resource.String.AbbrS);
                }
                if (InfoTank.SelectedPotentialTask == 3)
                {
                    txtBR.Text = tanks[position].PowerToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrH_P_T);
                }
                if (InfoTank.SelectedPotentialTask == 4)
                {
                    txtBR.Text = tanks[position].Penetration.ToString() + context.Resources.GetString(Resource.String.AbbrMM);
                }
                if (InfoTank.SelectedPotentialTask == 5)
                {
                    txtBR.Text = tanks[position].ReloadTime.ToString() + context.Resources.GetString(Resource.String.AbbrS);
                }
                if (InfoTank.SelectedPotentialTask == 6)
                {
                    txtBR.Text = tanks[position].ReducedArmorFrontTurret.ToString() + context.Resources.GetString(Resource.String.AbbrMM);
                }
                if (InfoTank.SelectedPotentialTask == 7)
                {
                    txtBR.Text = tanks[position].ReducedArmorTopSheet.ToString() + context.Resources.GetString(Resource.String.AbbrMM);
                }
            }
  


            return view;

        }
    }
}