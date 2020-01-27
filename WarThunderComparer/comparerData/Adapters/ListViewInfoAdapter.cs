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

    public class ListViewInfoAdapter : BaseAdapter
    {
        private Activity activitys;
        private List<Plane> planes;
        Context context;
        Context aContext;
        public ListViewInfoAdapter(Activity activitys, List<Plane> planes)
        {
            this.activitys = activitys;
            this.planes = planes;
            context = Application.Context;
            aContext = activitys.ApplicationContext;
        }

        public override int Count => planes.Count;

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

            txtName.Text = planes[position].Name;
            txtBR.Text = planes[position].BR.ToString("0.0#");
            txtNation.Text = planes[position].Nation;
            img.SetImageResource(planes[position].Image);

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

                if (InfoPlane.SelectedPotentialTaskPlane == 1)
                {
                    txtBR.Text = mphSpeedAt0 + context.Resources.GetString(Resource.String.AbbrMPH);
                }
                if (InfoPlane.SelectedPotentialTaskPlane == 2)
                {
                    txtBR.Text = mphSpeedAt5000 + context.Resources.GetString(Resource.String.AbbrMPH);
                }
                if (InfoPlane.SelectedPotentialTaskPlane == 3)
                {
                    // txtBR.Text = planes[position].Climb.ToString() + context.Resources.GetString(Resource.String.AbbrS);
                    int newClimb = planes[position].Climb;
                    TimeSpan timeSpan = TimeSpan.FromSeconds(newClimb);
                    string climbToShow = timeSpan.ToString(@"mm\:ss");
                    txtBR.Text = climbToShow;
                }
                if (InfoPlane.SelectedPotentialTaskPlane == 4)
                {
                    txtBR.Text = planes[position].TurnAt0.ToString() + context.Resources.GetString(Resource.String.AbbrS);
                }
                if (InfoPlane.SelectedPotentialTaskPlane == 5)
                {
                    txtBR.Text = payload + context.Resources.GetString(Resource.String.AbbrLB);
                }
                if (InfoPlane.SelectedPotentialTaskPlane == 6)
                {
                    txtBR.Text = planes[position].ThrustToWeightRatio.ToString();
                }
                if (InfoPlane.SelectedPotentialTaskPlane == 7)
                {
                    txtBR.Text = burstmass + context.Resources.GetString(Resource.String.AbbrLB_S);
                }
            }
            else
            {
                if (InfoPlane.SelectedPotentialTaskPlane == 1)
                {
                    txtBR.Text = planes[position].MaxSpeedAt0.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H);
                }
                if (InfoPlane.SelectedPotentialTaskPlane == 2)
                {
                    txtBR.Text = planes[position].MaxSpeedAt5000.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H);
                }
                if (InfoPlane.SelectedPotentialTaskPlane == 3)
                {
                   // txtBR.Text = planes[position].Climb.ToString() + context.Resources.GetString(Resource.String.AbbrS);
                    int newClimb = planes[position].Climb;
                    TimeSpan timeSpan = TimeSpan.FromSeconds(newClimb);
                    string climbToShow = timeSpan.ToString(@"mm\:ss");
                    txtBR.Text = climbToShow;
                }
                if (InfoPlane.SelectedPotentialTaskPlane == 4)
                {
                    txtBR.Text = planes[position].TurnAt0.ToString() + context.Resources.GetString(Resource.String.AbbrS);
                }
                if (InfoPlane.SelectedPotentialTaskPlane == 5)
                {
                    txtBR.Text = planes[position].BombLoad.ToString() + context.Resources.GetString(Resource.String.AbbrKG);
                }
                if (InfoPlane.SelectedPotentialTaskPlane == 6)
                {
                    txtBR.Text = planes[position].ThrustToWeightRatio.ToString();
                }
                if (InfoPlane.SelectedPotentialTaskPlane == 7)
                {
                    txtBR.Text = planes[position].WeaponVolleyPerSecond.ToString() + context.Resources.GetString(Resource.String.AbbrKG_S);
                }
            }

            return view;

        }
    }
}