using System;

namespace Boîtes
{
    class Program
    {
        static void Main(string[] args)
        {
            Boite box1 = new Boite(30, 40, 40);
            Console.WriteLine(box1.Volume); 
            
            Boite box2 = new Boite(30, 40, 40, Matières.Métal);
            
            Boite box3 = new Boite(30, 40, 40, Matières.Carton);

            Boite box4 = new Boite(30, 40, 40, Matières.Carton);

            if (Boite.ComparerStatic(box2, box3)) //ComparerStatic est une méthode qui est un attribut de la classe Boite.
                Console.WriteLine("Boîtes identiques");
            else
                Console.WriteLine("Boîtes distinctes");

            bool res = box3.Comparer(box4); // Comparer est une méthode qui est un attribut des objets de la classe Boite.
            Console.WriteLine(res);            

            Console.WriteLine("Il y a {0} boîtes.", Boite.Compteur); 
            
        }

        
    }
}
