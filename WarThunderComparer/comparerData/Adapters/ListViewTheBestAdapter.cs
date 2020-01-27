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

    public class ListViewTheBestAdapter : BaseAdapter
    {
        private Activity activitys;
        private List<Plane> planes;
        Context context;

        private TextView txtName;
        private TextView txtSpeedAt0;
        private TextView txtSpeedAt5000;
        private TextView txtClimb;
        private TextView txtTurnTime;
        private TextView txtWeight;
        private TextView txtPowerToWeight;
        private TextView txtVolleyPerSecond;

        private ImageView theBestIco1;
        private ImageView theBestIco2;
        private ImageView theBestIco3;
        private ImageView theBestIco4;
        private ImageView theBestIco5;
        private ImageView theBestIco6;
        private ImageView theBestIco7;

        public override int Count => planes.Count;

        public ListViewTheBestAdapter(Activity activitys, List<Plane> planes)
        {
            this.activitys = activitys;
            this.planes = planes;
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
            var view = convertView ?? activitys.LayoutInflater.Inflate(Resource.Layout._modelTheBestListView, parent, false);

             ImageView img = view.FindViewById<ImageView>(Resource.Id.imglistviewmodel);
             txtName = view.FindViewById<TextView>(Resource.Id.textTheBestName);
             txtSpeedAt0 = view.FindViewById<TextView>(Resource.Id.textTheBestSpeedAt0);
             txtSpeedAt5000 = view.FindViewById<TextView>(Resource.Id.textTheBestSpeedAt5000);
             ImageView flag = view.FindViewById<ImageView>(Resource.Id.theBestFlag);
             txtClimb = view.FindViewById<TextView>(Resource.Id.textTheBestClimb);
             txtTurnTime = view.FindViewById<TextView>(Resource.Id.textTheBestTurnTime);
             txtWeight = view.FindViewById<TextView>(Resource.Id.textTheBestWeight);
             txtPowerToWeight = view.FindViewById<TextView>(Resource.Id.textTheBestPowerToWeight);
             txtVolleyPerSecond = view.FindViewById<TextView>(Resource.Id.textTheBestVolleyPerSecond);


            theBestIco1 = view.FindViewById<ImageView>(Resource.Id.theBestIco1);
            theBestIco2 = view.FindViewById<ImageView>(Resource.Id.theBestIco2);
            theBestIco3 = view.FindViewById<ImageView>(Resource.Id.theBestIco3);
            theBestIco4 = view.FindViewById<ImageView>(Resource.Id.theBestIco4);
            theBestIco5 = view.FindViewById<ImageView>(Resource.Id.theBestIco5);
            theBestIco6 = view.FindViewById<ImageView>(Resource.Id.theBestIco6);
            theBestIco7 = view.FindViewById<ImageView>(Resource.Id.theBestIco7);



            img.SetImageResource(planes[position].Image);
            flag.SetImageResource(planes[position].FlagImageTheBest);
            txtName.Text = planes[position].Name;

            int newClimb = planes[position].Climb;
            TimeSpan timeSpan = TimeSpan.FromSeconds(newClimb);
            string climbToShow = timeSpan.ToString(@"mm\:ss");
            txtClimb.Text = climbToShow;
            //
            txtTurnTime.Text = planes[position].TurnAt0.ToString() + context.Resources.GetString(Resource.String.AbbrS);

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            ISharedPreferencesEditor editor = prefs.Edit();
            var switchchecked = prefs.GetBoolean("key_kmhtomph", false);
            if (switchchecked)
            {
                var mphSpeedAt0 = planes[position].MaxSpeedAt0 * 0.621371192;
                var mphSpeedAt5000 = planes[position].MaxSpeedAt5000 * 0.621371192;
                var payload = planes[position].BombLoad * 2.204622621849;
                var burstmass = planes[position].WeaponVolleyPerSecond * 2.204622621849;
                mphSpeedAt0 = System.Math.Round(mphSpeedAt0, 0);
                mphSpeedAt5000 = System.Math.Round(mphSpeedAt5000, 0);
                payload = System.Math.Round(payload, 0);
                burstmass = System.Math.Round(burstmass, 2);

                txtSpeedAt0.Text = mphSpeedAt0 + context.Resources.GetString(Resource.String.AbbrMPH);
                txtSpeedAt5000.Text = mphSpeedAt5000 + context.Resources.GetString(Resource.String.AbbrMPH);
                txtWeight.Text = payload + context.Resources.GetString(Resource.String.AbbrLB);
                txtVolleyPerSecond.Text = burstmass + context.Resources.GetString(Resource.String.AbbrLB_S);
                if (planes[position].RankId == 5)
                {
                    txtPowerToWeight.Text = planes[position].ThrustToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrLBF_LB);
                }
                if (planes[position].RankId == 6)
                {
                    txtPowerToWeight.Text = planes[position].ThrustToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrLBF_LB);
                }
                else
                {
                    var thrustToWeight = planes[position].ThrustToWeightRatio / 2.204622621849;
                    thrustToWeight = System.Math.Round(thrustToWeight, 2);
                    txtPowerToWeight.Text = thrustToWeight + context.Resources.GetString(Resource.String.AbbrHP_LB);
                }
            }
            else
            {            
                txtSpeedAt0.Text = planes[position].MaxSpeedAt0.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H);
                txtSpeedAt5000.Text = planes[position].MaxSpeedAt5000.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H);    
                txtWeight.Text = planes[position].BombLoad.ToString() + context.Resources.GetString(Resource.String.AbbrKG);
                txtVolleyPerSecond.Text = planes[position].WeaponVolleyPerSecond.ToString() + context.Resources.GetString(Resource.String.AbbrKG_S);
                if (planes[position].RankId == 5)
                {
                    txtPowerToWeight.Text = planes[position].ThrustToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrKGS_KG);
                }
                if (planes[position].RankId == 6)
                {
                    txtPowerToWeight.Text = planes[position].ThrustToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrKGS_KG);
                }
                else
                {
                    txtPowerToWeight.Text = planes[position].ThrustToWeightRatio.ToString() + context.Resources.GetString(Resource.String.AbbrH_P_KG);
                }
            }

            if (TheBestPlane.SelectedTask == 1)
            {
                txtSpeedAt0.Alpha = 1;
                theBestIco1.Alpha = 1;

            }
            if (TheBestPlane.SelectedTask == 2)
            {
                txtSpeedAt5000.Alpha = 1;
                theBestIco2.Alpha = 1;
            }
            if (TheBestPlane.SelectedTask == 3)
            {
                txtClimb.Alpha = 1;
                theBestIco3.Alpha = 1;

            }
            if (TheBestPlane.SelectedTask == 4)
            {
                txtTurnTime.Alpha = 1;
                theBestIco4.Alpha = 1;

            }
            if (TheBestPlane.SelectedTask == 5)
            {
                txtWeight.Alpha = 1;
                theBestIco5.Alpha = 1;
            }
            if (TheBestPlane.SelectedTask == 6)
            {
                txtPowerToWeight.Alpha = 1;
                theBestIco6.Alpha = 1;

            }
            if (TheBestPlane.SelectedTask == 7)
            {
                txtVolleyPerSecond.Alpha = 1;
                theBestIco7.Alpha = 1;

            }

            return view;
            
        }
    }
}