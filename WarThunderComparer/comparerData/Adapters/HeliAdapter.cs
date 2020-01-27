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
    class HeliAdapter : BaseAdapter
    {
        private Context c;
        List<Heli> helis;
        LayoutInflater inflater;

        public HeliAdapter(Context c, List<Heli> helis)
        {
            this.c = c;
            this.helis = helis;
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
            nameTxt.Text = "[" + helis[position].BR.ToString("0.0#") + "] " + helis[position].Name;

            if (helis[position].Type == c.Resources.GetString(Resource.String.AttackHelicopter))
            {
                nameTxt.SetBackgroundResource(Resource.Drawable._LightTankSpinnerGradient);
            }
            if (helis[position].Type == c.Resources.GetString(Resource.String.UtilityHelicopter))
            {
                nameTxt.SetBackgroundResource(Resource.Drawable._AttackerSpinnerGradient);
            }

            return convertView;
        }
    }
}