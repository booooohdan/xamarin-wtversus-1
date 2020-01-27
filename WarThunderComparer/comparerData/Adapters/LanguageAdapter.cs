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
    class LanguageAdapter : BaseAdapter
    {

        Context c;
        List<Language> languages;
        LayoutInflater inflater;

        public LanguageAdapter(Context c, List<Language> languages)
        {
            this.c = c;
            this.languages = languages;
        }


        public override int Count => languages.Count;

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
            TextView languageName = convertView.FindViewById<TextView>(Resource.Id.nameTxtLanguage);
            languageName.Text = languages[position].Name.ToString();
            ImageView flagImage = convertView.FindViewById<ImageView>(Resource.Id.imageFlagLanguage);
            flagImage.SetImageResource(languages[position].Image);
            return convertView;

        }
    }
}