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
using WarThunderComparer.comparerData.Adapters;
using WarThunderComparer.comparerData.Collections;

namespace WarThunderComparer.comparerData.Collections
{
    public class Plane
    {
        public int Id { get; set; }

        public int Image { get; set; }
        public int FlagImage { get; set; }
        public int FlagImageTheBest { get; set; }

        public string Name { get; set; }
        public string Nation { get; set; }
        public int NationId { get; set; }
        public string Rank { get; set; }
        public int RankId { get; set; }
        public double BR { get; set; }

        public string Type { get; set; }
        public string PlaneCharacter { get; set; }
        public double PatchAdded { get; set; }
        public int FirstFlyYear { get; set; }

        public int MaxSpeedAt0 { get; set; }
        public int MaxSpeedAt5000 { get; set; }
        public int BombLoad { get; set; }
        public double TurnAt0 { get; set; }
        public int Climb { get; set; }
        public int Flutter { get; set; }
        public int EnginePower { get; set; }
        public int Weight { get; set; }
        public double ThrustToWeightRatio { get; set; }

        public double WeaponVolleyPerSecond { get; set; }
        public bool HandingRocket { get; set; }
        public bool HandingCannon { get; set; }
        public bool HandingBomb { get; set; }
        public bool HandingTorpedo { get; set; }
        public bool HandingAirToAir { get; set; }
        public bool HandingAirToGround { get; set; }
        public string WeaponAndTurrels { get; set; }
    }
}