using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrodalomProject.Models
{
    internal class Kerdes
    {
        public Kerdes(string kerdesSzovege, string valaszA, string valaszB, string valaszC, string helyesvalasz)
        {
            KerdesSzovege = kerdesSzovege;
            ValaszA = valaszA;
            ValaszB = valaszB;
            ValaszC = valaszC;
            Helyesvalasz = helyesvalasz;
        }

        public string KerdesSzovege { get; set; }
        public string ValaszA { get; set; }
        public string ValaszB { get; set; }
        public string ValaszC { get; set; }
        public string Helyesvalasz { get; set; }
        public string? FelhasznaloValasza { get; set; }



    }
}
