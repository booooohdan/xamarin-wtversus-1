using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using WarThunderComparer.comparerData.Adapters;
using WarThunderComparer.comparerData.Collections;
using Android.Views;
using Android.Widget;

namespace WarThunderComparer.comparerData.Collections
{
    class RankCollection
    {
        public static List<Rank> GetRank()
        {
            Context context = Application.Context;

            List<Rank> ranks = new List<Rank>();
            Rank rank = null;

            rank = new Rank();
            rank.Id = 100;
            rank.Name = context.Resources.GetString(Resource.String.RanksAll);
            ranks.Add(rank);

            rank = new Rank();
            rank.Id = 1;
            rank.Name = "I";
            ranks.Add(rank);

            rank = new Rank();
            rank.Id = 2;
            rank.Name = "II";
            ranks.Add(rank);

            rank = new Rank();
            rank.Id = 3;
            rank.Name = "III";
            ranks.Add(rank);

            rank = new Rank();
            rank.Id = 4;
            rank.Name = "IV";
            ranks.Add(rank);

            rank = new Rank();
            rank.Id = 5;
            rank.Name = "V";
            ranks.Add(rank);

            rank = new Rank();
            rank.Id = 6;
            rank.Name = "VI";
            ranks.Add(rank);

            rank = new Rank();
            rank.Id = 7;
            rank.Name = "VII";
            ranks.Add(rank);

            return ranks;

        }
    }
}