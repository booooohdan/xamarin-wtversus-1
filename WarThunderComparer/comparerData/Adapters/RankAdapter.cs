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

namespace WarThunderComparer.comparerData.Adapters
{
    class RankAdapter : BaseAdapter
    {
        private Context c;
        List<Rank> ranks;
        LayoutInflater inflater;

        public override int Count => ranks.Count();

        public RankAdapter(Context c, List<Rank> ranks)
        {
            this.c = c;
            this.ranks = ranks;
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
            if (inflater == null)
            {
                inflater=(LayoutInflater)c.GetSystemService(Context.LayoutInflaterService);
            }
            if (convertView == null)
            {
                convertView = inflater.Inflate(Resource.Layout._modelAllSpinner, parent, false);
            }
            TextView nameTxt = convertView.FindViewById<TextView>(Resource.Id.nameTxt);
            nameTxt.Text = ranks[position].Name.ToString();
            return convertView;
        }

      /*  public override int GetCount()
        {
            return ranks.Count();
        }*/
    }
    }