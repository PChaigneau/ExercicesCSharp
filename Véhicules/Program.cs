using System;
using System.Collections.Generic;
using System.Text;

namespace Véhicules
{
    public enum Energies
    {
        Aucune,
        Essence,
        Gazole,
        GPL,
        Electrique
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Voiture v1 = new Voiture("Twingo", Energies.Electrique);

            Console.WriteLine(v1.Description);

            Véhicule car1 = new Voiture("Camionnette", Energies.Essence);
            Véhicule moto1 = new Moto("125", Energies.Essence);

            Console.WriteLine(car1.Description);
            Console.WriteLine(moto1.Description);
            // C'est bien les Description de Voiture et Moto qui sont appelés alors que les variables ont été déclarés sous le type véhicule


            var voitM = new Voiture("Mégane", 19000);
            var voitE = new Voiture("Enzo", 380000);
            var motoI = new Moto("Intruder", 13000);
            var motoY = new Moto("Yamaha", 11000);

            var liste1 = new SortedList<string, Véhicule>();
            liste1.Add(voitM.Nom, voitM);
            liste1.Add(voitE.Nom, voitE);
            liste1.Add(motoI.Nom, motoI);
            liste1.Add(motoY.Nom, motoY);

            foreach (var item in liste1)
            {
                Console.WriteLine($"{item.Key} : {item.Value.Prix.ToString("C0")}");
            }
            // La liste est triée par clés

            var liste2 = new SortedList<Véhicule, string>();
            liste2.Add(voitM, voitM.Nom);
            liste2.Add(voitE, voitE.Nom);
            liste2.Add(motoI, motoI.Nom);
            liste2.Add(motoY, motoY.Nom);

            Console.WriteLine();

            foreach (var item in liste2)
            {
                Console.WriteLine($"{item.Value} : {item.Key.Prix.ToString("C0")}");
            }
            // La liste est triée selon la clé grâce à la méthode CompareTo

            Console.WriteLine();

            var tabNoms = new string[] { "Clio", "Mégane", "Golf", "Enzo", "Polo" };


            //foreach (var item1 in tabNoms)
            //{                
            //    bool estPrésent = false;
            //    foreach (var item2 in liste1)
            //    {        
            //        if (item1 == item2.Key)
            //        {
            //            Console.WriteLine($"{item2.Key} :  {item2.Value.Prix.ToString("C0")}");
            //            estPrésent = true;
            //            break;
            //        }
            //        else
            //            estPrésent = false;
            //    }
            //    if (!estPrésent)
            //        Console.WriteLine($"{item1} : données manquantes");

            //}

            foreach (var item in tabNoms)
            {

                if(liste1.TryGetValue(item, out Véhicule V))
                    Console.WriteLine($"{V.Nom} : {V.Prix.ToString("C0")}");           


            }
            




            Console.ReadKey();
        }

    }
}
