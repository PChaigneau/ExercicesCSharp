using System;

namespace Pendu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Jouez au pendu!");
            char c = 

            //--------------------------------------------------------------------------
            // 1. Les étapes ci-desous consistent à faire saisir un mot valide au 1er joueur

            string mot = string.Empty;
            bool motValide = false;
            // Tant que le mot saisi n'est pas valide
            while (!motValide)
            {
                // On fait saisir le mot
                Console.WriteLine("Saisissez un mot de 3 à 25 lettres sans accent :");
                // On vérifie son format (appeler la méthode statique VerifierMot)
                mot = Console.ReadLine();
                try
                {
                    Jeu.VerifierMot(mot);
                    motValide = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            //--------------------------------------------------------------------------
            // 2. les étapes suivantes consistent à faire deviner le mot au 2d joueur

            // On vide l'écran
            Console.Clear();

            // On crée un jeu et on l'initialise avec le mot saisi
            Jeu jeu = new Jeu();
            jeu.InitialiserJeu(mot);

            // Tant que le jeu n'est pas fini
            while (jeu.EtatPartie == EtatsPartie.EnCours)
            {
                // On affiche le dessin et l'état du mot en cours
                Console.WriteLine("\nMot en cours de déchifrage : " + jeu.MotEnCours);
                Console.WriteLine(jeu.GetDessinPendu());
                // On demande une lettre et on la teste
                Console.WriteLine("Proposez une lettre : ");
                jeu.TesterLettre(Console.ReadKey().KeyChar);               
            }
            // Si la partie est gagnée, on affiche un message en vert
            if (jeu.EtatPartie == EtatsPartie.gagnée)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nBravo, vous avez gagné : {jeu.MotADeviner}");
                Console.ResetColor();
            }
            // Si elle est perdue on affiche un message en rouge avec la solution
            else if (jeu.EtatPartie == EtatsPartie.perdue)
            {
                Console.WriteLine(jeu.GetDessinPendu());
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nPerdu ! Le mot à deviner était : { jeu.MotADeviner}");
                Console.ResetColor();
            }
            Console.ReadKey();
        }

    }
}
