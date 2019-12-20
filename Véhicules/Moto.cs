using System;
using System.Collections.Generic;
using System.Text;

namespace Véhicules
{
    class Moto : Véhicule
    {
        public override string Description
        {
            get { return $"Je suis une moto \n"  + base.Description; }
        }
        public Moto(string nom, Energies energie) : base(nom, 2, energie)
        {
            
        }

        public Moto(string nom, double prix) : base(nom, prix) { }
    }
}
