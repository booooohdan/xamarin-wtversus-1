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

    class ListViewInfoHeliAdapter : BaseAdapter
    {
        private Activity activitys;
        private List<Heli> helis;
        Context context;
        public ListViewInfoHeliAdapter(Activity activitys, List<Heli>helis)
        {
            this.helis = helis;
            this.activitys = activitys;
            context = Application.Context;
        }

        public override int Count => helis.Count;

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


            txtName.Text = helis[position].Name;
            txtBR.Text = helis[position].BR.ToString("0.0#");
            txtNation.Text = helis[position].Nation;
            img.SetImageResource(helis[position].Image);

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            ISharedPreferencesEditor editor = prefs.Edit();
            var switchchecked = prefs.GetBoolean("key_kmhtomph", false);
            if (switchchecked)
            {
                var maxSpeed = helis[position].MaxSpeed * 0.621371192;
                var aGMRange = helis[position].AGMRange * 3.28084;
                var aGMArmorPenetration = helis[position].AGMArmorPenetration * 0.039370;
                maxSpeed = System.Math.Round(maxSpeed, 0);
                aGMRange = System.Math.Round(aGMRange, 0);
                aGMArmorPenetration = System.Math.Round(aGMArmorPenetration, 2);

                if (InfoHeli.SelectedPotentialTaskHeli == 1)
                {
                    txtBR.Text = maxSpeed + context.Resources.GetString(Resource.String.AbbrMPH);
                }

                if (InfoHeli.SelectedPotentialTaskHeli == 2)
                {
                    // txtBR.Text = planes[position].Climb.ToString() + context.Resources.GetString(Resource.String.AbbrS);
                    int newClimb = helis[position].ClimbTo1000;
                    TimeSpan timeSpan = TimeSpan.FromSeconds(newClimb);
                    string climbToShow = timeSpan.ToString(@"mm\:ss");
                    txtBR.Text = climbToShow;
                }
                if (InfoHeli.SelectedPotentialTaskHeli == 3)
                {
                    txtBR.Text = helis[position].ThrustToWeightRatio.ToString();
                }
                if (InfoHeli.SelectedPotentialTaskHeli == 4)
                {
                    txtBR.Text = helis[position].AGMCount.ToString() + context.Resources.GetString(Resource.String.AbbrITEMS);
                }
                if (InfoHeli.SelectedPotentialTaskHeli == 5)
                {
                    txtBR.Text = aGMArmorPenetration + context.Resources.GetString(Resource.String.AbbrINCH);
                }
                if (InfoHeli.SelectedPotentialTaskHeli == 6)
                {
                    txtBR.Text = aGMRange + context.Resources.GetString(Resource.String.AbbrFEET);
                }
                if (InfoHeli.SelectedPotentialTaskHeli == 7)
                {
                    txtBR.Text = helis[position].ASMCount.ToString() + context.Resources.GetString(Resource.String.AbbrITEMS);
                }
            }
            else
            {
                if (InfoHeli.SelectedPotentialTaskHeli == 1)
                {
                    txtBR.Text = helis[position].MaxSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H);
                }

                if (InfoHeli.SelectedPotentialTaskHeli == 2)
                {
                    // txtBR.Text = planes[position].Climb.ToString() + context.Resources.GetString(Resource.String.AbbrS);
                    int newClimb = helis[position].ClimbTo1000;
                    TimeSpan timeSpan = TimeSpan.FromSeconds(newClimb);
                    string climbToShow = timeSpan.ToString(@"mm\:ss");
                    txtBR.Text = climbToShow;

                }
                if (InfoHeli.SelectedPotentialTaskHeli == 3)
                {
                    txtBR.Text = helis[position].ThrustToWeightRatio.ToString();
                }
                if (InfoHeli.SelectedPotentialTaskHeli == 4)
                {
                    txtBR.Text = helis[position].AGMCount.ToString() + context.Resources.GetString(Resource.String.AbbrITEMS);
                }
                if (InfoHeli.SelectedPotentialTaskHeli == 5)
                {
                    txtBR.Text = helis[position].AGMArmorPenetration.ToString() + context.Resources.GetString(Resource.String.AbbrMM);
                }
                if (InfoHeli.SelectedPotentialTaskHeli == 6)
                {
                    txtBR.Text = helis[position].AGMRange.ToString() + context.Resources.GetString(Resource.String.AbbrMETER);
                }
                if (InfoHeli.SelectedPotentialTaskHeli == 7)
                {
                    txtBR.Text = helis[position].ASMCount.ToString() + context.Resources.GetString(Resource.String.AbbrITEMS);
                }
            }

              


            return view;

        }
    }
}