using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPOO
{

    public interface IRenouvelable // En pratique on ne créé pas souvent d'interface, on utilise celles prédéfinies sur le framework.
    {
        DateTime DateDernierRenouvellement { get; }
        void Renouveler(DateTime date);
    }
    abstract class MoyenPaiement : IRenouvelable
    {
        public long NuméroCompte { get; }
        public string NomTitulaire { get; set; }
        public string PrénomTitulaire { get; set; }

        public DateTime DateDernierRenouvellement { get; set; }

        //public DateTime DateDernierRenouvellement { get; set; }

        public MoyenPaiement(long numéroCompte)
        {
            NuméroCompte = numéroCompte;
        }
        //public virtual void Renouveler(DateTime date) // virtual : la méthode peut être redéfinie ds les classes dérivées
        //{
        //    DateDernierRenouvellement = date;
        //}

        public override string ToString()
        {
            // appelle la méthode ToString de la classe de base et concatène le résultat avec le numéro de carte
            return base.ToString() + $"Carte N° {NuméroCompte}";
        }

        public void Renouveler(DateTime date)
        {
            DateDernierRenouvellement = date;
        }
    }
    class Carte:MoyenPaiement //héritage
    {
        public int Numéro {get;}
        public DateTime DateExpiration { get; set; }
        public int CodeSecret { get; set; }
        public int Cryptogramme { get; set; }


        public Carte(long numCompte, int numCarte) : base(numCompte) //envoie le paramètre à la méthode ancêtre
        {
            Numéro = numCarte;
        }

        public void Renouveler(DateTime date) //permet de modifier la méthode de l'ancêtre
        {
            base.Renouveler(date);
            DateExpiration = DateExpiration.AddYears(2); // méthode fournie par DateTime
        }

        public override string ToString()
        {
            return $"La carte {Numéro} appartient à {NomTitulaire}";
        }
    }
    class Chequier:MoyenPaiement
    {
        public string Adresse { get; set; }
        public long NuméroPremierCheque { get; set; }
        public int NbCheques { get; set; }

        public Chequier(long numCompte) : base (numCompte)
        {
           
        }

        public void Renouveler(DateTime date)
        {
            base.Renouveler(date);
            NuméroPremierCheque += NbCheques;
        }

    }
}
