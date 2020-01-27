using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.OS;
using Android.Widget;
using Android.Content.PM;
using WarThunderComparer.comparerData.Adapters;
using WarThunderComparer.comparerData.Collections;
using Android.Graphics;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Content;

using Android.Views;
using System.Resources;
using System.Xml.Linq;

namespace WarThunderComparer.comparerData.Collections
{
    class NationCollection
    {
        

        public static List<Nation> GetNation()
        {
            Context context = Application.Context;

            List<Nation> nations = new List<Nation>();
            Nation nation = null;
            

            nation = new Nation();
            nation.Id = 100;
            nation.Name = context.Resources.GetString(Resource.String.NationAll);
            nations.Add(nation);
            
            nation = new Nation();
            nation.Id= 1;
            nation.Name = context.Resources.GetString(Resource.String.NationUSA);
            nation.Image = Resource.Drawable._flagTheBestUS;

            nations.Add(nation);

            nation = new Nation();
            nation.Id = 2;
            nation.Name = context.Resources.GetString(Resource.String.NationGermany);
            nation.Image = Resource.Drawable._flagTheBestGermany;
            nations.Add(nation);

            nation = new Nation();
            nation.Id = 3;
            nation.Name = context.Resources.GetString(Resource.String.NationUSSR);
            nation.Image = Resource.Drawable._flagTheBestUSSR;
            nations.Add(nation);

            nation = new Nation();
            nation.Id = 4;
            nation.Name = context.Resources.GetString(Resource.String.NationGB);
            nation.Image = Resource.Drawable._flagTheBestBritain;
            nations.Add(nation);

            nation = new Nation();
            nation.Id = 5;
            nation.Name = context.Resources.GetString(Resource.String.NationJapan);
            nation.Image = Resource.Drawable._flagTheBestJapan;
            nations.Add(nation);

            nation = new Nation();
            nation.Id = 8;
            nation.Name = context.Resources.GetString(Resource.String.NationChina);
            nation.Image = Resource.Drawable._flagTheBestChina;
            nations.Add(nation);

            nation = new Nation();
            nation.Id = 6;
            nation.Name = context.Resources.GetString(Resource.String.NationItaly);
            nation.Image = Resource.Drawable._flagTheBestItaly;
            nations.Add(nation);

            nation = new Nation();
            nation.Id = 7;
            nation.Name = context.Resources.GetString(Resource.String.NationFrance);
            nation.Image = Resource.Drawable._flagTheBestFrance;
            nations.Add(nation);

            nation = new Nation();
            nation.Id = 9;
            nation.Name = context.Resources.GetString(Resource.String.NationSweden);
            nation.Image = Resource.Drawable._flagTheBestSweden;
            nations.Add(nation);


            return nations;

        }
    }
}