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
    class GameModeAdapter : BaseAdapter
    {
        private Context c;
        List<GameMode> gameModes;
        LayoutInflater inflater;

        public GameModeAdapter(Context c, List<GameMode>gameModes)
        {
            this.c = c;
            this.gameModes = gameModes;
        }

        public override int Count => gameModes.Count;

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
                convertView = inflater.Inflate(Resource.Layout._modelSpinnerGameMode, parent, false);
            }
            TextView nameTxt = convertView.FindViewById<TextView>(Resource.Id.nameTxt);
            nameTxt.Text = gameModes[position].Name.ToString();

            return convertView;

        }
    }
}