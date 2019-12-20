using System;

namespace Demo
{
    enum sexes {Femme, Homme} 
    //déclare un nouveau type ne pouvant prendre que les valeurs entre {}
    //C# attribue automatiquement une valeur entière aux arguments entre {} en partant de 0
    class Program
    {
        static void Main(string[] args)
        {
            //appel des fonctions
            //Demo1();
            //Demo2();
            //Demo3();

            string m = Demo4("Pierre Chaigneau", 1987, sexes.Homme);
            Console.WriteLine(m);
            
            Console.ReadKey();
        }

        //définitions des fonctions :
        static void Demo1()
        {
            Console.WriteLine("Saisissez votre nom :");
            string nom = Console.ReadLine();
            Console.WriteLine("Bonjour " + nom + ". Quelle est votre année de naissance ?");
            string rep = Console.ReadLine();

            int annéeNais = int.Parse(rep);

            int age = 2019 - annéeNais;
            Console.WriteLine("Vous allez avoir " + age + " ans");
            // age est converti automatiquement en chaîne par C#

            //Console.WriteLine("Vous allez avoir {0} ans", age);
            // version alternative préférée, plutôt que d'utiliser l'opérateur + qui coupe les chaînes

            //Console.WriteLine("Bonjour {0}, vous allez avoir {1} ans", nom, age);

            //méthode par chaîne interpolée (encore plus lisible, noter le $ avant la chaîne)
            //Console.WriteLine($"Bonjour {nom}, vous allez avoir {age} ans");

            if (annéeNais % 4 == 0)
                // "==" plutôt que "=" car il s'agit d'un test et non d'une affectation
                Console.WriteLine("Vous êtes né(e) durant une année bissextile");
            else
                Console.WriteLine("Vous n'êtes pas né(e) durant une année bissextile");

            // en passant par opérateur ternaire : (test ? valeur si vraie, valeur si faux:
            string message;
            message = (annéeNais % 4 == 0) ? " est une année bissextile" : "n'est pas une année bissextile";

            //test avec plusieurs cas :
            if (age < 25)
                Console.WriteLine("Vous êtes dans la tranche d'âge : moins de 25 ans");
            else if (age >= 25 && age < 35)
                Console.WriteLine("Vous êtes dans la tranche d'âge : 25 - 35 ans");
            else
                Console.WriteLine("Vous êtes dans la tranche d'âge : plus de 35 ans");

            const int annéeMin = 1900;
            const int annéeMax = 2019;
            //if (annéeNais < 1900 || annéeNais > 2019)
            if (annéeNais < annéeMin || annéeMax > 2019)
                Console.WriteLine("Vous devez saisir une année valide");
        }

        static void Demo2()
        {
            string texte;
            string phrase;
            int nbPhrases;

            phrase = "le C# est un langage moderne et puissant";
            texte = phrase;
            texte = texte + ", il est utilisé pour toutes sortes d'applications\n";
            texte += " - application console\n"; // raccourci pour {texte = texte + ...}
            texte += " - application fenêtrée avec Winforms et WPF\n";
            texte += " - application mobile avec Xamarin\n";

            Console.WriteLine(texte);

            char lettre;
            lettre = phrase[3]; // ici on utilise la syntaxe d'un tableau. La phrase est vue comme un tableau à 1 ligne et autant de colonnes que de caractères,indicés à partir de 0

            // initialisation d'un tableau :
            int[] tabPos = new int[3];
            tabPos[0] = 3;
            tabPos[1] = 4;
            tabPos[2] = 40;

            tabPos = new int[3] { 3, 4, 40 }; //syntaxe plus condensée
            Console.WriteLine(tabPos.Length);

            //boucle for. snippet pour conditions = (for + tab + tab)
            for (int i = 0; i < tabPos.Length; i++)
            {
                Console.WriteLine($"Position {i} : {tabPos[i]}");
            }

            Console.WriteLine();// pour afficher ligne vierge

            //boucle while
            int j = 0;
            while (j < tabPos.Length)
            {
                Console.WriteLine($"Position {j} : {tabPos[j]}");
                j++;
            }

            j = 0;

            //boucle do (exécute au moins une fois les instructions avant le test) :            
            do
            {
                Console.WriteLine($"Position {j} : {tabPos[j]}");
                j++;
            } while (j < tabPos.Length);


            //boucle foreach :
            int k = 0;
            foreach (int item in tabPos)
            {
                Console.WriteLine($"Position {k} : {item}");
                k++;
            }

            // inmplémentation d'un compteur de phrases :
            nbPhrases = 0;
            for (int i = 0; i < texte.Length; i++)
            {
                if (texte[i] == '\n')
                    nbPhrases++;
            }
            Console.WriteLine("il y a {0} phrases dans le texte", nbPhrases);

        }

        static void Demo3()
        {
            string phrase = "le C# est un langage moderne et puissant";

            int n = CompterMots(phrase);
            Console.WriteLine("La phrase \"{0}\" comporte {1} mots.", phrase, n);

        }

        static int CompterMots(string p) 
        {
            int nbMots = 0;
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] == ' ' || p[i] =='\'' || p[i] == '\n')
                {
                    nbMots++; //on compte le nb d'espaces 
                }
            }


            return nbMots + 1; //= nb d'espaces + 1 = nb de mots
        }

        static string Demo4(string nom, int année, sexes sexe) 
        {
            string message;
            int age = 2019 - année;

            if (sexe == sexes.Femme)
                message = $"Bonjour Madame {nom}, vous avez {age} ans.";
                // Pour utiliser le format avec les jokers, utiliser string.Format()
            else
                message =$"Bonjour Monsieur {nom}, vous avez {age} ans.";

            return message;
        }
    }


}
