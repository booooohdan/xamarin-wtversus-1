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
   public class Tank
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
        public string Character { get; set; }
        public double PatchAdded { get; set; }
        public int FirstRideYear { get; set; }

        public int MaxSpeedAtRoad { get; set; }
        public int MaxSpeedAtTerrain { get; set; }
        public int MaxReverseSpeed { get; set; }
        public int AccelerationTo100 { get; set; }
        public int TurnTurretTime { get; set; }
        public int TurnHullTime { get; set; }
        public int EnginePower { get; set; }
        public double Weight { get; set; }
        public double PowerToWeightRatio { get; set; }

        public string CannonName { get; set; }
        public int Penetration { get; set; }
        public int ShellSpeed { get; set; }
        public double ReloadTime { get; set; }
        public int UpAimAngle { get; set; }
        public int DownAimAngle { get; set; }
        public bool Stabilizer { get; set; }
        public bool AAMachineGunExist { get; set; }

        public bool ShellAP;
        public bool ShellAPHE;
        public bool ShellHE;
        public bool ShellAPCR;
        public bool ShellAPDS;
        public bool ShellAPFSDS;
        public bool ShellHEAT;
        public bool ShellHEATFS;
        public bool ShellShrapnel;
        public bool ShellHESH;
        public bool ShellATGM;
        public bool ShellSSM;
        public bool ShellHEATGRENADE;
        public bool ShellHEGRENADE;
        public bool ShellHEVT;
        public bool ShellSTA;
    
        public int ReducedArmorFrontTurret { get; set; }
        public int ReducedArmorTopSheet { get; set; }
        public int ReducedArmorBottomSheet { get; set; }
        public string WeakZoneExist { get; set; }
















    }
}