using System;
using System.Collections.Generic;

namespace DemoPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Carte c1 = new Carte(1111, 345678);
            c1.CodeSecret = 1234;
            c1.Cryptogramme = 456;
            c1.DateExpiration = new DateTime(2021, 12, 31);
            c1.Renouveler(DateTime.Today);
            c1.NomTitulaire = "Toto";
            
            Console.WriteLine(c1.ToString());

            DateTime dt = new DateTime(2019, 11, 15);
            CompteBancaire cb = new CompteBancaire(58764357233, dt, c1);
            long n = cb.Numéro;

            cb.Créditer(123);
            cb.Créditer(456, "virement salaire"); //appel de la seconde version de la méthode

            Console.WriteLine("Solde du compte {0} : {1}", cb.Numéro, cb.Solde);
            Console.WriteLine("Dernière opération : {0}", cb.Description);

            int cpt = CompteBancaire.Compteur;
            Console.WriteLine("{0} comptes bancaires ont été crées", cpt);


            // application du polymorphisme 
            // Permet de stocker dans une variable du type ancêtre une instance de classe dérivée.
            // Intérêt : traiter de façon identique des objets différents, appeler la méthode de l'ancêtre tout en exécutant le code de la méthode dérivée
            MoyenPaiement c2 = new Carte(11111, 546849) { CodeSecret = 456, Cryptogramme = 678};
            if (c2 is Carte) // pour accéder aux propriétés de carte d'un Moyen de paiement si c'est bien une carte.
            {
                Carte c = (Carte)c2; //transtypage : maintenant c est une  carte est on a accès à ses propriétés de carte.
            }
                
            MoyenPaiement chequier = new Chequier(253489);


            Console.WriteLine("Numéro de la carte associée au compte{0} : {1}", cb.Numéro, cb.CB.Numéro);


            IRenouvelable carte4 = new Carte(11111, 67889); // Possible car Carte implémente l'interface
            IRenouvelable chequier4 = new Chequier(3333);


            //Un tableau de comptes :
            CompteBancaire[] tabComptes = new CompteBancaire[3];
            tabComptes[0] = new CompteBancaire(111111);
            tabComptes[1] = new CompteBancaire(111112);
            tabComptes[2] = new CompteBancaire(111113);

            //Une liste générique de comptes :
            List<CompteBancaire> liste = new List<CompteBancaire>();
            liste.Add(new CompteBancaire(222220));
            liste.Add(new CompteBancaire(222221));
            liste.Add(new CompteBancaire(222222));
            liste.Add(new CompteBancaire(222223));

            // Une méthode de parcours des éléments d'une liste :
            for (int i = 0; i < liste.Count; i++)
            {
                Console.WriteLine(liste[i].Numéro);
            }
            // méthode plus concise :
            foreach (var compteBancaire in liste)
            {
                Console.WriteLine(compteBancaire.Numéro);
            }

            // Dictionnaire
            //Dictionary<long, CompteBancaire> dico = new Dictionary<long, CompteBancaire>
            var dico = new Dictionary<long, CompteBancaire>();
            dico.Add(777, new CompteBancaire(777));
            dico.Add(888, new CompteBancaire(888));

            foreach (var item in dico)
            {
                Console.WriteLine($"{ item.Key} { item.Value.DateCreation}");
            }

            Console.WriteLine(dico[777].Description); 

            Console.ReadKey();
           
        }
    }
}
