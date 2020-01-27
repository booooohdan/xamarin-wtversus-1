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

namespace WarThunderComparer.comparerData.Collections
{
    class FirstActivity
    {
        public int Image { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class FirstActivityCollection
    {
        public static List<FirstActivity> GetFirstActivitys()
        {
            Context context = Application.Context;

            List<FirstActivity> firstActivitys = new List<FirstActivity>();
            FirstActivity firstActivity = null;

            firstActivity = new FirstActivity();
            firstActivity.Id = 1;
            firstActivity.Name = context.Resources.GetString(Resource.String.FAInfoStat);
            firstActivity.Image = Resource.Drawable._menuInfoStat;
            firstActivitys.Add(firstActivity);

            firstActivity = new FirstActivity();
            firstActivity.Id = 2;
            firstActivity.Name = context.Resources.GetString(Resource.String.FACompareStat);
            firstActivity.Image = Resource.Drawable._menuInfoCompare;
            firstActivitys.Add(firstActivity);
            /*
            firstActivity = new FirstActivity();
            firstActivity.Id = 3;
            firstActivity.Name = "Top in squadron";
            firstActivity.Image = Resource.Drawable._menuTheBest;
            firstActivitys.Add(firstActivity);
            */
            firstActivity = new FirstActivity();
            firstActivity.Id = 4;
            firstActivity.Name = context.Resources.GetString(Resource.String.FAInfoPlane);
            firstActivity.Image = Resource.Drawable._menuInfo;
            firstActivitys.Add(firstActivity);

            firstActivity = new FirstActivity();
            firstActivity.Id = 5;
            firstActivity.Name = context.Resources.GetString(Resource.String.FAComparePlane);
            firstActivity.Image = Resource.Drawable._menuCompare;
            firstActivitys.Add(firstActivity);
            
            firstActivity = new FirstActivity();
            firstActivity.Id = 6;
            firstActivity.Name = context.Resources.GetString(Resource.String.FATheBestPlane);
            firstActivity.Image = Resource.Drawable._menuTheBest;
            firstActivitys.Add(firstActivity);

            firstActivity = new FirstActivity();
            firstActivity.Id = 7;
            firstActivity.Name = context.Resources.GetString(Resource.String.FAInfoTank);
            firstActivity.Image = Resource.Drawable._menuInfo;
            firstActivitys.Add(firstActivity);

            firstActivity = new FirstActivity();
            firstActivity.Id = 8;
            firstActivity.Name = context.Resources.GetString(Resource.String.FACompareTank);
            firstActivity.Image = Resource.Drawable._menuCompare;
            firstActivitys.Add(firstActivity);

            firstActivity = new FirstActivity();
            firstActivity.Id = 9;
            firstActivity.Name = context.Resources.GetString(Resource.String.FATheBestTank);
            firstActivity.Image = Resource.Drawable._menuTheBest;
            firstActivitys.Add(firstActivity);

            firstActivity = new FirstActivity();
            firstActivity.Id = 10;
            firstActivity.Name = context.Resources.GetString(Resource.String.FAInfoHeli);
            firstActivity.Image = Resource.Drawable._menuInfo;
            firstActivitys.Add(firstActivity);

            firstActivity = new FirstActivity();
            firstActivity.Id = 11;
            firstActivity.Name = context.Resources.GetString(Resource.String.FAInfoHeli);
            firstActivity.Image = Resource.Drawable._menuCompare;
            firstActivitys.Add(firstActivity);

            firstActivity = new FirstActivity();
            firstActivity.Id = 12;
            firstActivity.Name = context.Resources.GetString(Resource.String.FAInfoHeli);
            firstActivity.Image = Resource.Drawable._menuTheBest;
            firstActivitys.Add(firstActivity);

            firstActivity = new FirstActivity();
            firstActivity.Id = 13;
            firstActivity.Name = context.Resources.GetString(Resource.String.FAInfoShip);
            firstActivity.Image = Resource.Drawable._menuInfo;
            firstActivitys.Add(firstActivity);

            firstActivity = new FirstActivity();
            firstActivity.Id = 14;
            firstActivity.Name = context.Resources.GetString(Resource.String.FACompareShip);
            firstActivity.Image = Resource.Drawable._menuCompare;
            firstActivitys.Add(firstActivity);

            firstActivity = new FirstActivity();
            firstActivity.Id = 15;
            firstActivity.Name = context.Resources.GetString(Resource.String.FATheBestShip);
            firstActivity.Image = Resource.Drawable._menuTheBest;
            firstActivitys.Add(firstActivity);

            return firstActivitys;
        }
    }
}