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
    class ListViewTheBestHeliAdapter:BaseAdapter
    {
        private Activity activitys;
        private List<Heli> helis;
        Context context;

        private TextView txtName;
        private TextView txtMaxSpeed;
        private TextView txtClimbTo1000;
        private TextView txtThrustToWeightRatio;
        private TextView txtAGMCount;
        private TextView txtAGMArmorPenetration;
        private TextView txtAGMRange;
        private TextView txtASMCount;

        private ImageView theBestIco1;
        private ImageView theBestIco2;
        private ImageView theBestIco3;
        private ImageView theBestIco4;
        private ImageView theBestIco5;
        private ImageView theBestIco6;
        private ImageView theBestIco7;

        public override int Count => helis.Count;

        public ListViewTheBestHeliAdapter(Activity activitys, List<Heli>helis)
        {
            this.activitys = activitys;
            this.helis = helis;
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
            var view = convertView ?? activitys.LayoutInflater.Inflate(Resource.Layout._modelTheBestHeliListViewml, parent, false);


            ImageView img = view.FindViewById<ImageView>(Resource.Id.imglistviewmodelH);
            txtName = view.FindViewById<TextView>(Resource.Id.textTheBestHeliName);
            txtMaxSpeed = view.FindViewById<TextView>(Resource.Id.textTheBestHeliMaxSpeed);
            txtClimbTo1000 = view.FindViewById<TextView>(Resource.Id.textTheBestHeliClimbTo1000);
            ImageView flag = view.FindViewById<ImageView>(Resource.Id.theBestFlagH);
            txtThrustToWeightRatio = view.FindViewById<TextView>(Resource.Id.textTheBestHeliThrustToWeightRatio);
            txtAGMCount = view.FindViewById<TextView>(Resource.Id.textTheBestHeliAGMCount);
            txtAGMArmorPenetration = view.FindViewById<TextView>(Resource.Id.textTheBestHeliAGMArmorPenetration);
            txtAGMRange = view.FindViewById<TextView>(Resource.Id.textTheBestHeliAGMRange);
            txtASMCount = view.FindViewById<TextView>(Resource.Id.textTheBestHeliASMCount);


            theBestIco1 = view.FindViewById<ImageView>(Resource.Id.theBestHeliIco1);
            theBestIco2 = view.FindViewById<ImageView>(Resource.Id.theBestHeliIco2);
            theBestIco3 = view.FindViewById<ImageView>(Resource.Id.theBestHeliIco3);
            theBestIco4 = view.FindViewById<ImageView>(Resource.Id.theBestHeliIco4);
            theBestIco5 = view.FindViewById<ImageView>(Resource.Id.theBestHeliIco5);
            theBestIco6 = view.FindViewById<ImageView>(Resource.Id.theBestHeliIco6);
            theBestIco7 = view.FindViewById<ImageView>(Resource.Id.theBestHeliIco7);

            img.SetImageResource(helis[position].Image);
            flag.SetImageResource(helis[position].FlagImageTheBest);
            txtName.Text = helis[position].Name;
            //
            int newClimb = helis[position].ClimbTo1000;
            TimeSpan timeSpan = TimeSpan.FromSeconds(newClimb);
            string climbToShow = timeSpan.ToString(@"mm\:ss");
            txtClimbTo1000.Text = climbToShow;
            //
            txtThrustToWeightRatio.Text=helis[position].ThrustToWeightRatio.ToString();
            txtAGMCount.Text = helis[position].AGMCount.ToString() + context.Resources.GetString(Resource.String.AbbrITEMS);
            txtASMCount.Text = helis[position].ASMCount.ToString() + context.Resources.GetString(Resource.String.AbbrITEMS);


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

                txtMaxSpeed.Text = maxSpeed + context.Resources.GetString(Resource.String.AbbrMPH);
                txtAGMArmorPenetration.Text = aGMArmorPenetration + context.Resources.GetString(Resource.String.AbbrINCH);
                txtAGMRange.Text = aGMRange + context.Resources.GetString(Resource.String.AbbrFEET);
            }
            else
            {
                txtMaxSpeed.Text = helis[position].MaxSpeed.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H);
                txtAGMArmorPenetration.Text = helis[position].AGMArmorPenetration.ToString() + context.Resources.GetString(Resource.String.AbbrMM);
                txtAGMRange.Text = helis[position].AGMRange.ToString() + context.Resources.GetString(Resource.String.AbbrMETER);

            }

                if (TheBestHeli.SelectedTask == 1)
            {
                txtMaxSpeed.Alpha = 1;
                theBestIco1.Alpha = 1;
            }
            if (TheBestHeli.SelectedTask == 2)
            {
                txtClimbTo1000.Alpha = 1;
                theBestIco2.Alpha = 1;
            }
            if (TheBestHeli.SelectedTask == 3)
            {
                txtThrustToWeightRatio.Alpha = 1;
                theBestIco3.Alpha = 1;
            }
            if (TheBestHeli.SelectedTask == 4)
            {
                txtAGMCount.Alpha = 1;
                theBestIco4.Alpha = 1;
            }
            if (TheBestHeli.SelectedTask == 5)
            {
                txtAGMArmorPenetration.Alpha = 1;
                theBestIco5.Alpha = 1;
            }
            if (TheBestHeli.SelectedTask == 6)
            {
                txtAGMRange.Alpha = 1;
                theBestIco6.Alpha = 1;
            }
            if (TheBestHeli.SelectedTask == 7)
            {
                txtASMCount.Alpha = 1;
                theBestIco7.Alpha = 1;
            }

            return view;
        }
    }
}
 