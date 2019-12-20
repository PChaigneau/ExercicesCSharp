using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace RelevésMétéo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            string[] relevés = File.ReadAllLines("..\\..\\..\\DonnéesMétéoParis.txt");
            RelevéMensuel relevé;
            Console.WriteLine(@" Mois   | T° min | T° max | Précip (mm) | Ensol (H) ");
            Console.WriteLine(@"----------------------------------------------------");
            try
            {
                for (int i = 1; i < relevés.Length; i++)
                {
                    relevé = new RelevéMensuel(relevés[i].Split('\t'));
                    Console.WriteLine(relevé.ToString());
                }

            }
            catch (FormatException e)
            {

                Console.WriteLine(e.Message); ;
            }



            Console.ReadKey();
        }
    }
}
