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
    class GameModeCollection
    {
        public static List<GameMode> GetGameMode()
        {
            Context context = Application.Context;

            List<GameMode> gameModes = new List<GameMode>();
            GameMode gameMode = null;

            gameMode = new GameMode();
            gameMode.Id = 0;
            gameMode.Name = context.Resources.GetString(Resource.String.StatAB);
            gameModes.Add(gameMode);

            gameMode = new GameMode();
            gameMode.Id = 1;
            gameMode.Name = context.Resources.GetString(Resource.String.StatRB);
            gameModes.Add(gameMode);

            gameMode = new GameMode();
            gameMode.Id = 2;
            gameMode.Name = context.Resources.GetString(Resource.String.StatSB);
            gameModes.Add(gameMode);

            return gameModes;
        }
    }
}