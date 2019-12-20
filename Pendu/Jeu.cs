using System;
using System.Text.RegularExpressions;

namespace Pendu
{
    public enum EtatsPartie
    {
        EnCours,
        perdue,
        gagnée
    }

    /// <summary>
    /// Modélise un jeu de pendu en utilisant le moins possible de concepts de POO
    /// (Pas de propriétés, ni constructeur)
    /// </summary>
    public class Jeu
    {
        // Variabes utilisées pour mémoriser les informations
        const int NB_ERREURS_MAX = 10; // Nombre d'erreurs maximum avant que la partie soit perdue
        const char CAR_REMPL = '-'; // Caractère de remplacement pour les lettres pas encore trouvées
        int _nbErreurs = 0; // Compteur d'erreurs
        //string _motADeviner;
        char[] _motEnCours; // Tableau représentant le mot en cours de construction
                            // avec des caractères de remplacement pour les lettres non trouvées
        EtatsPartie _etatPartie; // Etat de la partie (en cours, perdue ou gagnée)

        public EtatsPartie EtatPartie { get { return _etatPartie; } }
        //public string MotADeviner { get { return _motADeviner; } }
        public string MotADeviner { get; private set; }
        public string MotEnCours { get { return new string(_motEnCours); } }


        /// <summary>
        /// Initialisation du jeu
        /// </summary>
        /// <param name="mot">mot à deviner</param>
        public void InitialiserJeu(string mot)
        {
            // Mémorise le mot à deviner après l'avoir mis en minuscules
            MotADeviner = mot.ToLower();
            // Initialise l'état de la partie comme "en cours"
            _etatPartie = EtatsPartie.EnCours;
            // Initialise le tableau représentant le mot en cours de construction
            _motEnCours = new char[mot.Length];
            // Les lettre sont remplacées par des caractères de remplacement
            for (int i = 0; i < _motEnCours.Length ; i++)
            {
                _motEnCours[i] = CAR_REMPL;

            }

        }

        /// <summary>
        /// Renvoie l'état de la partie (en cours, perdue ou gagnée)
        /// </summary>
        /// <returns></returns>
        //public EtatsPartie GetEtatPartie()
        //{
        //    return _etatPartie;
        //}

        /// <summary>
        /// Renvoie le mot à deviner
        /// </summary>
        /// <returns></returns>
        //public string GetMotADeviner()
        //{
        //    return _motADeviner;
        //}

        /// <summary>
        /// Renvoie le mot en cours, où chaque lettre non trouvée
        /// est remplacée par un caractère de remplacement
        /// </summary>
        /// <returns></returns>
        //public string GetMotEnCours()
        //{
        //    return new string(_motEnCours);
        //}

        /// <summary>
        /// Renvoie un dessin du pendu représentantif du nombre d'erreurs déjà faites
        /// </summary>
        /// <returns>Chaîne représentant le dessin du pendu</returns>
        public string GetDessinPendu()
        {

            string res = string.Empty;
            // Définit le dessin à renvoyer en fonction du compteur d'erreur
            switch (_nbErreurs)
            {
                case 1:
                    res = @"

 
    
   
    
____";
                    break;
                case 2:
                    res = @"

|
|   
|  
|   
|____";
                    break;
                case 3:
                    res = @"
____
|
|   
|  
|   
|____";
                    break;
                case 4:
                    res = @"
____
|/  
|   
|  
|   
|____";
                    break;
                case 5:
                    res = @"
____
|/  |
|   
|  
|   
|____";
                    break;
                case 6:
                    res = @"
____
|/  |
|   o
|  
|   
|____";
                    break;
                case 7:
                    res = @"
____
|/  |
|   o
|   |
|   
|____";
                    break;
                case 8:
                    res = @"
____
|/  |
|   o
|  /|
|   
|____";
                    break;
                case 9:
                    res = @"
____
|/  |
|   o
|  /|\
|   
|____";
                    break;
                case 10:
                    res = @"
____
|/  |
|   o
|  /|\
|  / 
|____";
                    break;
                case 11:
                    res = @"
____
|/  |
|  ~o~
|  /|\
|  / \
|____";
                    break;
                default:
                    res = @"

 
    
   
    
";
                    break;
            }
            return res;
        }

        /// <summary>
        /// Vérifie le mot passé en paramètre
        /// Renvoie un message d'erreur le cas échéant
        /// </summary>
        /// <param name="mot"></param>
        public static void VerifierMot(string mot)
        {

            // Vérifie que le mot n'est pas vide ni constitué d'espaces
            if (string.IsNullOrEmpty(mot) || string.IsNullOrWhiteSpace(mot))
            {
                throw new FormatException("Le mot doit contenir entre 3 et 25 lettres");
            }
            // Vérifie que le mot a une longueur comprise entre 3 et 25 caractères
            else if (mot.Length < 3 || mot.Length > 25)
                throw new FormatException("Le mot ne doit contenir que des lettres, sans accent");
            else
            {
                for (int i = 0; i < mot.Length ; i++)
                { 
                    // Vérifie que le mot ne contient que des lettres non accentuées
                    if (mot[i] < 65 || mot[i] > 122 || (mot[i] > 90 && mot[i] < 97))
                        throw new FormatException("Le mot ne doit contenir que des lettres, sans accent");
                }
            }            
        }

        /// <summary>
        /// Teste si la lettre passée en paramètre est dans le mot
        /// et met à jour l'état de la partie
        /// </summary>
        /// <param name="l">Lettre à tester</param>
        public void TesterLettre(char l)
        {
            bool estPrésent = false;
            for (int i = 0; i < MotADeviner.Length; i++)
            {                
                // Si la lettre est présente dans le mot à deviner
                if (l == MotADeviner[i])
                {
                // on place cette lettre dans le tableau du mot en cours aux bons endroits
                    _motEnCours[i] = l;
                    estPrésent = true;
                }              
                
            }
            if (!estPrésent)
                _nbErreurs++;
            // S'il n'y a plus de caractère de remplacement dans le mot en cours,
            // c'est que la partie est gagnée
            // sinon, si le nombre d'erreurs maxi est dépassé, la partie est perdue
            if (MotADeviner == MotEnCours)
                _etatPartie = EtatsPartie.gagnée;
            else if (_nbErreurs > NB_ERREURS_MAX)
            {
                _etatPartie = EtatsPartie.perdue;
            }

                                          
        }
    }
}

