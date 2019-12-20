using System;

namespace PGCD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calcul du PGCD de 2 nombres");

            bool correct = false;

            int p = 0, q = 0 ;
            string rep1 = "", rep2 = ""; 

            while (!correct)
            {

                // gestion des exceptions : le bloc permet de compiler le code en cache et
                // renvoie unn message d'erreur si la compilation échoue
                // (ici notamment si l'utilisateur ne rentre pas un nombre).
                try
                {
                    Console.WriteLine("Entrez le premier nombre :");
                    rep1 = Console.ReadLine();
                    p = int.Parse(rep1);
                    correct = true;

                }
                catch (Exception) // possibilité de nommer l'exception pour la consulter si besoin ("Exception e")
                {
                    Console.WriteLine("Vous devez saisir un nombre");
                    //throw;
                }
            }
            correct = false;
            while (!correct)
            {
                try
                {
                    Console.WriteLine("Entrez le deuxième nombre :");
                    rep2 = Console.ReadLine();
                    q = int.Parse(rep2);
                    correct = true;
                }
                catch (FormatException e) // désigne un type plus précis d'exception 
                {
                    Console.WriteLine(e.Message); // affiche le message prédéfini par Visual Studio.
                    //throw;
                }
            }



            Console.WriteLine("Le PGCD de {0} et {1} est {2}", rep1, rep2, CalculerPGCD(p, q));



        }
        static int CalculerPGCD(int p, int q)
        {
            while (p != q)
            {
                if (p > q)
                    p = p - q;
                else
                    q = q - p;
            };
            return p;

        }
    }
}
