using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Véhicules
{
    class Véhicule : IComparable<Véhicule>
    {
        public string Nom { get;}
        public int NbRoues { get;}
        public Energies Energie { get;}
        public double Prix { get; private set; }

        public virtual string Description 
        {
            get { return $"Véhicule {Nom}, roule sur {NbRoues} roues et à l'énergie {Energie}"; } 
        }

        public Véhicule(string nom, int nbRoues, Energies energie)
        {
            Nom = nom;
            NbRoues = nbRoues;
            Energie = energie;
        }

        public Véhicule(string nom, double prix)
        {
            Nom = nom;
            Prix = prix;
        }        

        public int CompareTo([AllowNull] Véhicule other)
        {
            //if (Prix < other.Prix)
            //    return -1;
            //else if (Prix == other.Prix)
            //    return 0;
            //else
            //    return 1;  
            return Prix.CompareTo(other.Prix);
        }
    }
}
