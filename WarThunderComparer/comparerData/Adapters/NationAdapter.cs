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
    class NationAdapter : BaseAdapter
    {


        private Context c;
        List<Nation> nations;
        LayoutInflater inflater;

        public NationAdapter(Context c, List<Nation> nations)
        {
            this.c = c;
            this.nations = nations;
        }

        public override int Count => nations.Count;

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
                convertView = inflater.Inflate(Resource.Layout._modelLanguageSpinner, parent, false);
            }
            TextView nameTxt = convertView.FindViewById<TextView>(Resource.Id.nameTxtLanguage);   
            nameTxt.Text = nations[position].Name.ToString();
            ImageView flagImage = convertView.FindViewById<ImageView>(Resource.Id.imageFlagLanguage);
            flagImage.SetImageResource(nations[position].Image);
            return convertView;
        }
    }
}