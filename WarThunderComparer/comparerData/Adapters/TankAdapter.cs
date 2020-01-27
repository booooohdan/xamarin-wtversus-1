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
    class TankAdapter : BaseAdapter
    {
        private Context c;
        List<Tank> tanks;
        LayoutInflater inflater;

        public TankAdapter(Context c, List<Tank> tanks)
        {
            this.c = c;
            this.tanks = tanks;
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
            nameTxt.Text = "[" + tanks[position].BR.ToString("0.0#") + "] " + tanks[position].Name;

            if (tanks[position].Type == c.Resources.GetString(Resource.String.TankLight))
            {
                nameTxt.SetBackgroundResource(Resource.Drawable._LightTankSpinnerGradient);
            }
            if (tanks[position].Type == c.Resources.GetString(Resource.String.TankMedium))
            {
                nameTxt.SetBackgroundResource(Resource.Drawable._FighterSpinnerGradient);
            }
            if (tanks[position].Type == c.Resources.GetString(Resource.String.TankHeavy))
            {
                nameTxt.SetBackgroundResource(Resource.Drawable._HeavyTankSpinnerGradient);
            }
            if (tanks[position].Type == c.Resources.GetString(Resource.String.TankDestroyer))
            {
                nameTxt.SetBackgroundResource(Resource.Drawable._AttackerSpinnerGradient);
            }
            if (tanks[position].Type == c.Resources.GetString(Resource.String.TankAntiTankMissileCarrier))
            {
                nameTxt.SetBackgroundResource(Resource.Drawable._AttackerSpinnerGradient);
            }
            if (tanks[position].Type == c.Resources.GetString(Resource.String.TankSPAA))
            {
                nameTxt.SetBackgroundResource(Resource.Drawable._BomberSpinnerGradient);
            }

            return convertView;
        }

    }
}