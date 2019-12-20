using System;
using System.Collections.Generic;
using System.Text;

namespace Boîtes
{
    public enum Formats
    {
        XS,
        S,
        M,
        L,
        XL
    }
    class Etiquette
    {
        public string Texte { get; set;}

        public Couleurs Couleur { get; set;}

        public Formats Format { get; set;}

        public Etiquette(string texte, Couleurs couleur, Formats format)
        {
            Texte = texte;
            Couleur = couleur;
            Format = format;
        }

        
        public Etiquette(){}// Constructeur sans paramètre pour faire fonctionner l'initialiseur. 
        // Normalement soit on créé des constructeurs, soit on utilise un initialiseur.


    }
}
