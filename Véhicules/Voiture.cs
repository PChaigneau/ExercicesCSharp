using System;
using System.Collections.Generic;
using System.Text;

namespace Véhicules
{
    class Voiture : Véhicule
    {
        public override string Description
        {
            get { return $"Je suis une voiture \n" + base.Description; }
        }

        
        public Voiture(string nom, Energies energie) : base(nom, 4, energie)
         {

         }

        public Voiture(string nom, double prix) : base(nom, prix) { }

    }
}
