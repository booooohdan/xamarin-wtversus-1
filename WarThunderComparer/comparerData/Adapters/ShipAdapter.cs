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
    class ShipAdapter : BaseAdapter
    {
        private Context c;
        List<Ship> ships;
        LayoutInflater inflater;

        public ShipAdapter(Context c, List<Ship> ships)
        {
            this.c = c;
            this.ships = ships;
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
            nameTxt.Text = "[" + ships[position].BR.ToString("0.0#") + "] " + ships[position].Name;

            if (ships[position].Type == c.Resources.GetString(Resource.String.ShipBoat))
            {
                nameTxt.SetBackgroundResource(Resource.Drawable._BoatSpinnerGradient);
            }
            if (ships[position].Type == c.Resources.GetString(Resource.String.ShipBarge))
            {
                nameTxt.SetBackgroundResource(Resource.Drawable._BargeSpinnerGradient);
            }
            if (ships[position].Type == c.Resources.GetString(Resource.String.ShipSubChaser))
            {
                nameTxt.SetBackgroundResource(Resource.Drawable._BomberSpinnerGradient);
            }
            if (ships[position].Type == c.Resources.GetString(Resource.String.ShipDestroyer))
            {
                nameTxt.SetBackgroundResource(Resource.Drawable._FighterSpinnerGradient);
            }
            if (ships[position].Type == c.Resources.GetString(Resource.String.ShipCruiser))
            {
                nameTxt.SetBackgroundResource(Resource.Drawable._HeavyTankSpinnerGradient);
            }

            return convertView;
        }
    }
}