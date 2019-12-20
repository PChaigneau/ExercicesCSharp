using System;

namespace AnalyseMot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entrez un mot");
            string m = Console.ReadLine();
            int nbL, nbV, nbC;
            CompterLettres(m, out nbL, out nbV, out nbC);
            

            Console.WriteLine($"\"{m} comporte {nbL} lettres, dont {nbC} consonnes et {nbV} voyelles.");

            Console.ReadKey();
        }
        static void CompterLettres(string mot, out int nbLettre, out int nbVoyelle, out int nbConsonne)
        {
            mot = mot.ToLower();
            nbConsonne = 0;
            nbVoyelle = 0;
            nbLettre = mot.Length;
            for (int i = 0; i < nbLettre; i++)
            { 
                if (mot[i] == 'a' || mot[i] == 'e' || mot[i] == 'i' || mot[i] == 'o' || mot[i] == 'u' || mot[i] == 'y')
                    nbVoyelle++;
                else
                    nbConsonne++;
            }
        }
    }
}
