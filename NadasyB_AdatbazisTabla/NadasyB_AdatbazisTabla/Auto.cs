using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadasyB_AdatbazisTabla
{
    class Auto
    {
        public string Nev { get; set; }
        public string Gyarto { get; set; }
        public string Szin { get; set; }

        public Auto(string nev, string gyarto, string szin)
        {
            Nev = nev;
            Gyarto = gyarto;
            Szin = szin;
        }

    }
}
