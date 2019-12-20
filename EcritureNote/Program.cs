using System;
using System.IO;

namespace EcritureNote
{
    class Program
    {
        static void Main(string[] args)
        {
            string texte, path;
            SaisirNote(out texte, out path);
        }

        static void SaisirNote(out string texte, out string path)
        {
            Console.WriteLine("Saisissez votre texte");
            texte = Console.ReadLine();
            Console.WriteLine("Précisez un chemin de sauvegarde");
            path = Console.ReadLine();

            try
            {
                EnregistrerNote(texte, path);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Le repertoire spécifié n'existe pas");
            }

        }
        static void EnregistrerNote(string texte, string path)
        {
            try
            {
                using (StreamWriter outputFile = new StreamWriter(path, true))
                {
                    outputFile.WriteLine(texte);
                }
            }
            catch (Exception e)
            { 
                Console.WriteLine(e.Message);
            }
            
            /*finally
            {
                Console.WriteLine("Libération de la ressource");
                if (outputFile != null) outputFile.Close();

            }*/

        }
    }
}
