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
using Android.Content.Res;

namespace WarThunderComparer.comparerData.Adapters
{
    class FirstActivityAdapter : BaseAdapter
    {
        Context c;
        List<FirstActivity> firstActivities;
        LayoutInflater inflater;

        public FirstActivityAdapter(Context c, List<FirstActivity> firstActivities)
        {
            this.c = c;
            this.firstActivities = firstActivities;
        }

        public override int Count => firstActivities.Count;

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
            if (inflater == null)
            {
                inflater = (LayoutInflater)c.GetSystemService(Context.LayoutInflaterService);
            }
            if (convertView == null)
            {
                convertView = inflater.Inflate(Resource.Layout._modelFirstActivitySpinner, parent, false);
            }
            TextView firstActivityName = convertView.FindViewById<TextView>(Resource.Id.nameTxtFirstActivity);
            firstActivityName.Text = firstActivities[position].Name.ToString();
            ImageView firstActivityImage = convertView.FindViewById<ImageView>(Resource.Id.imageFirstActivity);
            firstActivityImage.SetImageResource(firstActivities[position].Image);
            return convertView;
        }
    }
}