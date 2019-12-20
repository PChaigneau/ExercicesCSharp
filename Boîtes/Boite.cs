using System;
using System.Collections.Generic;
using System.Text;

namespace Boîtes
{
    public enum Couleurs
    {
        Blanc,
        Bleu,
        Vert,
        Jaune,
        Orange,
        Rouge,
        Marron
    }

    public enum Matières
    {
        Carton,
        Plastique,
        Bois,
        Métal
    }
    class Boite
    {
        #region Propriétés

        public double Hauteur { get; }
        public double Largeur { get; }
        public double Longueur { get; }

        public static int Compteur {get; private set;}

        public Couleurs Couleur { get; set; }

        public Matières Matière { get; } = Matières.Carton;

        public double Volume
        {
            get { return Hauteur * Largeur * Longueur; }

        }
        #endregion

        #region Méthodes

        #region Constructeurs

        public Boite(double hauteur, double largeur, double longueur)
        {
            Hauteur = hauteur;
            Largeur = largeur;
            Longueur = longueur;
            Compteur++;
        }

        public Boite(double hauteur, double largeur, double longueur, Matières matière) : this(hauteur, largeur, longueur)
        {
            Matière = matière;
        }
        #endregion
        /// <summary>
        /// Ajoute une étiquette
        /// </summary>
        /// <param name="destinataire"> adresse du destinataire</param>
        public void Etiqueter(string destinataire) { }
        public void Etiqueter(string destinataire, bool fragile)
        {
            Etiqueter(destinataire);
        }

        public bool Comparer(Boite Boite0)
        {
            if (
                Hauteur == Boite0.Hauteur
                && Largeur == Boite0.Largeur
                && Longueur == Boite0.Longueur
                && Matière == Boite0.Matière
                )
                return true;
            else
                return false;
        }

        //Alternative reposant sur une méthode statique (ne dépendant pas d'une instance de la classe)
        
        public static bool ComparerStatic(Boite Boite1, Boite Boite2)
        {
            return (
                Boite1.Hauteur == Boite2.Hauteur
                && Boite1.Largeur == Boite2.Largeur
                && Boite1.Longueur == Boite2.Longueur
                && Boite1.Matière == Boite2.Matière
                ); // manière plus propre de définir le return lié à un test
               

        }
        #endregion
    }
}
