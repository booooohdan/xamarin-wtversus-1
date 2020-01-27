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
    class Ship
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
        public string ShipCharacter { get; set; }
        public double PatchAdded { get; set; }
        public int FirstLaunchYear { get; set; }

        public int MaxSpeed { get; set; }
        public int ReverseSpeed { get; set; }
        public int Acceleration { get; set; }
        public int BrakingTime { get; set; }
        public int Turn360 { get; set; }
        public int Displacement { get; set; }
        public int CrewCount { get; set; }

        public string MainCaliberName { get; set; }
        public double MainCaliberSize { get; set; }
        public int MainCaliberItem { get; set; }
        public double MainCaliberForCompare{ get; set; }
        public double MainCaliberReload { get; set; }
        public double MainCaliberTNT { get; set; }

        public string AuxiliaryCaliberName { get; set; }
        public double AuxiliaryCaliberForCompare { get; set; }
        public double AuxiliaryCaliberReload { get; set; }

        public string AAACaliberName { get; set; }
        public double AAACaliberForCompare { get; set; }
        public double AAACaliberReload { get; set; }

        public string TorpedoName { get; set; }
        public int TorpedoItem { get; set; }
        public int TorpedoMaxSpeed { get; set; }
        public double TorpedoTNT { get; set; }

        public bool HandingRocket{ get; set; }
        public bool HandingDepthCharge { get; set; }
        public bool HandingTorpedo { get; set; }
        public bool HandingMine { get; set; }

        public bool MCShellAP;
        public bool MCShellAPHE;
        public bool MCShellAPCR;
        public bool MCShellHE;
        public bool MCShellShrapnel;
        public bool MCShellHEVT; //радиовзрыв
        public bool MCShellHEDF; //дист взрыв
        public bool MCShellFOG; //гранатомет

        public bool AUShellAP;
        public bool AUShellAPHE;
        public bool AUShellAPCR;
        public bool AUShellHE;
        public bool AUShellShrapnel;
        public bool AUShellHEVT; //радиовзрыв
        public bool AUShellHEDF; //дист взрыв
        public bool AUShellFOG; //гранатомет

        public bool AAAShellAP;
        public bool AAAShellAPHE;
        public bool AAAShellAPCR;
        public bool AAAShellHE;
        public bool AAAShellHEVT; //радиовзрыв
        public bool AAAShellHEDF; //дист взрыв
        public bool AAAShellFOG; //гранатомет
    }

}

