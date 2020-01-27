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
    class Heli
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
        public string HeliCharacter { get; set; }
        public double PatchAdded { get; set; }
        public int FirstFlyYear { get; set; }

        public int MaxSpeed { get; set; }
        public int ClimbTo1000 { get; set; }
        public int Turn360 { get; set; }
        public int EnginePower { get; set; }
        public int Weight { get; set; }
        public double ThrustToWeightRatio { get; set; }

        public int AGMCount { get; set; }
        public int AGMArmorPenetration { get; set; }
        public int AGMSpeed { get; set; }
        public int AGMRange { get; set; }
        public int ASMCount { get; set; }
        public int ASMArmorPenetration { get; set; }
        public int ASMSpeed { get; set; }
        public int BombLoad { get; set; }
        public string OffensiveWeapon { get; set; }
        public string SuspensionWeapon { get; set; }

        public bool HandingAGM { get; set; }
        public bool HandingASM { get; set; }
        public bool HandingCannon { get; set; }
        public bool HandingBomb { get; set; }
        public bool AirToAir { get; set; }
        public bool Flares { get; set; }
        public bool HIRSS { get; set; }
        public bool IRCM { get; set; }
    }
}