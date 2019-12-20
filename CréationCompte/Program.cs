using System;


namespace CréationCompte
{
    class Program
    {
        static void Main(string[] args)
        {
            string log, mdp;
            try
            {
                CréerCompte(out log, out mdp);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void CréerCompte(out string login, out string motDePasse)
        {
            Console.WriteLine("Saisissez votre login :");
            login = Console.ReadLine();
            LoginCheck(login);

            Console.WriteLine("Saisissez votre mot de passe :");
            motDePasse = Console.ReadLine();
            MdpCheck(motDePasse);

            Console.WriteLine("Votre compte a bien été crée, un message vient de vous être envoyé.");
        }
        static void LoginCheck(string login)
        {
            if (login.Length < 5)
                throw new FormatException("le login doit faire au moins 5 caractères");

        }
        static void MdpCheck(string motDePasse)
        {
            if (motDePasse.Length < 6)
            {
                throw new FormatException("Le mot de passe doit comporter au moins 6 caractères");
            }
            else
            {
                bool lettre = false;
                bool chiffre = false;
                int i = 0;
                while ((lettre == false || chiffre == false) && i < motDePasse.Length - 1)
                {
                    if ((motDePasse[i] <= 90 && motDePasse[i] >= 65) // test si lettre majuscule
                        || (motDePasse[i] <= 122 && motDePasse[i] >= 97))// test si lettre minuscule
                        lettre = true;
                    if (motDePasse[i] <= 57 && motDePasse[i] >= 48)// test si chiffre
                        chiffre = true;
                    i++;
                }
                if (lettre == false || chiffre == false)                
                    throw new FormatException("Le mot de passe doit comporter au moins une lettre et un chiffre.");
                
            }
        }






    }
}

