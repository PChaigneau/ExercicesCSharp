using System;

namespace TriTableau
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int[] Tableau = new int[6] { 5, 3, 4, 2, 0, 1 };
            AfficherTableau(Tableau);
            Trier(Tableau); //passage par référence : 
            AfficherTableau(Tableau);
        }
        static void Trier(int[] tableau)
        {
            bool permut;                      
            do
            {
                permut = false;
                for (int i = 0; i < tableau.Length - 1; i++)
                {
                   
                    if (tableau[i] > tableau[i + 1])
                    {
                        int temp = tableau[i];
                        tableau[i] = tableau[i + 1];
                        tableau[i + 1] = temp;
                        permut = true;
                    }
                }
            }
            while (permut);           
        }
        static void AfficherTableau(int[] tableau) 
        {
            for (int i = 0; i < tableau.Length; i++)
            {
                Console.Write("{0}, ", tableau[i]);
                
            }
            Console.WriteLine();
        }
    }
}
