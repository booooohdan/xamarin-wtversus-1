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
using System.Globalization;

namespace WarThunderComparer.comparerData.Adapters
{
    class PlaneAdapter : BaseAdapter
    {

        private Context c;
        List<Plane> planes;
        LayoutInflater inflater;

        public PlaneAdapter(Context c, List<Plane> planes)
        {
            this.c = c;
            this.planes = planes;
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
            if (inflater == null)
            {
                inflater = (LayoutInflater)c.GetSystemService(Context.LayoutInflaterService);
            }
            if (convertView == null)
            {
                convertView = inflater.Inflate(Resource.Layout._modelAllSpinner, parent, false);
            }
            TextView nameTxt = convertView.FindViewById<TextView>(Resource.Id.nameTxt);
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            nameTxt.Text = "[" + planes[position].BR.ToString("0.0#") + "] " + planes[position].Name;

            if (planes[position].Type == c.Resources.GetString(Resource.String.PlaneFighter))
            {
                nameTxt.SetBackgroundResource(Resource.Drawable._FighterSpinnerGradient);
            }
            if (planes[position].Type == c.Resources.GetString(Resource.String.PlaneAttacker))
            {
                nameTxt.SetBackgroundResource(Resource.Drawable._AttackerSpinnerGradient);
            }
            if (planes[position].Type == c.Resources.GetString(Resource.String.PlaneBomber))
            {
                nameTxt.SetBackgroundResource(Resource.Drawable._BomberSpinnerGradient);
            }

            // _InfoPlaneTextMaxSpeedAt0.SetText(planes[e.Position].MaxSpeedAt0.ToString() + context.Resources.GetString(Resource.String.AbbrKM_H), TextView.BufferType.Normal);


            return convertView;
        }
    }
}