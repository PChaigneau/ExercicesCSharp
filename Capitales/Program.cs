using System;

namespace Capitales
{
    class Program
    {
        
        static string[] tabPays = new string[10] {"Albanie", "Allemagne", "Andorre", "Autriche",
                "Belgique", "Biélorussie", "Bosnie-Herzégovine", "Bulgarie",
                "Chypre", "Croatie"};//en fait il est inutile de préciser "10" entre crochets quand on précise ts les éléments du tableau
        static string[] tabCap = new string[10] {"Tirana", "Berlin", "Andorre-La-ville", "Vienne",
                "Bruxelles", "Minsk", "Sarajevo", "Sofia", "Nicosie", "Zagreb"};
        static void Main(string[] args)
        {

            /*
            Console.WriteLine("Quelle est la capitale de l'Espagne ?");
            string rep;
            rep = Console.ReadLine();
            if (rep.ToLower() == "madrid")//Appel de la fonction pour passer la réponse en minuscules
                Console.WriteLine("Bravo !");
            else
                Console.WriteLine("Mauvaise réponse");

            Console.ReadLine();//La console ne se fermera que sur la touche "entrée"
            */






            //étape 7:            
            /*for (int i = tabPays.Length - 1 ; i >= 0 ; i--)
            {
               pays = tabPays[i];
               capitale = tabCap[i];
               Console.WriteLine($"Quelle est la capitale de {pays} ?");
               rep = Console.ReadLine();
               if (rep.ToLower() == capitale.ToLower())
                    Console.WriteLine("Bravo !");
               else
                    Console.WriteLine($"Mauvaise réponse. La réponse était {capitale}");
            }*/

            /* //étape 8 :
             int points = 0;
             for (int i = 0; i < tabPays.Length; i++)
             {
                 pays = tabPays[i];
                 capitale = tabCap[i];
                 Console.WriteLine($"Quelle est la capitale de {pays} ?");
                 rep = Console.ReadLine();
                 if (rep.ToLower() == capitale.ToLower())
                 {
                     Console.WriteLine("Bravo !");
                     points++;
                 }
                 else
                     Console.WriteLine($"Mauvaise réponse. La réponse était {capitale}");
             }
             Console.WriteLine($"Vous avez {points} bonnes réponses.");
             */

            //étape 10 :

            //Jouer();

            //étapes 11 et 12 :
            
            Jouer2();
            
        }

        static void Jouer()
        {
            string pays;
            string capitale;
            string rep;
            string answer = "o";// utiliser un type booléen est possible aussi

            while (answer.ToLower() == "o")
            {
                Console.Clear();
                int points = 0;
                for (int i = 0; i < tabPays.Length; i++)
                {
                    pays = tabPays[i];//inutile, il suffit d'utiliser directement tabPays[i]
                    capitale = tabCap[i];
                    Console.WriteLine($"Quelle est la capitale de {pays} ?");
                    rep = Console.ReadLine();
                    if (rep.ToLower() == capitale.ToLower())
                    {
                        Console.WriteLine("Bravo !");
                        points++;
                    }
                    else
                        Console.WriteLine($"Mauvaise réponse. La réponse était {capitale}");
                }
                Console.WriteLine($"Vous avez {points} bonnes réponses.");
                Console.WriteLine("Voulez-vous rejouer? (o/n)");
                answer = Console.ReadLine();
                Console.WriteLine("Merci d'avoir joué");
            }
        }



        static void Jouer2()
        {
            int pointCounter = 0;
            do
            {
                Console.Clear();
                Random rd = new Random();
                if (PoserQuestion(rd.Next(tabPays.Length - 1)))
                {
                    pointCounter++;
                    Console.WriteLine("Vous avez actuellement {0} points.", pointCounter);
                }               

                Console.WriteLine("Appuyer sur n'importe quelle autre touche pour continuer, ou sur Echap pour arrêter le jeu.");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            Console.Clear();
            Console.WriteLine("Vous avez remporté {0} points. Merci d'avoir joué. Bye !", pointCounter);
        }

        /*autre possibilité pour récupérer la touche Echap : 
        //déclarer :    
        bool continuer = true;

        //puis construire le while en testant la valeur de "continuer" :
        
        ConsoleKeyInfo touche = Console.ReadKey();
        if (touche.Key == ConsoleKey.Escape)
            continuer = false;
        */
        static bool PoserQuestion(int p)
        {
            string answer;
            bool isGood;

            Console.WriteLine($"Quelle est la capitale de {tabPays[p]} ?");
            answer = Console.ReadLine();
            if (answer.ToLower() == tabCap[p].ToLower())
            {
                isGood = true;
                Console.WriteLine("Bravo !");
            }
            else
            {
                Console.WriteLine($"Mauvaise réponse. La réponse était {tabCap[p]}.");
                isGood = false;
            }
            return isGood;
        }

        
    }


}
