using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPOO
{
    class CompteBancaire
    {
        //L'usage est de défini successivement les champs, propriétés, méthodes

        //--------------------------------------------------------------------------------------------------------
        //champs :
        private decimal _solde;

        private static int _compteur; // champ statique : partagé entre toutes les instances de la classe

        //------------------------------------------------------------------------------------------------------
        //propriétés
        public long Numéro { get; } // Implémentation automatique d'une propriété
        //ajouter "set;" dans l'acolade permettrait de modifier le numéro depuis une autre classe.
        // public, private = attributs de la notion d'accessibilité
        // ici Numéro est une propriété de la classe CompteBancaire.
        // la syntaxe équivaut à créer une fonction qui renverrai un numéro instancié précédemment.

        /* alternative (historique) :
         private long _numéro; // déclaration explicite de la variable privée qui est masquée dans la syntaxe précédente.
        
         public long Numéro
         {
         get {return _numéro;}
         set {_numéro =  value;}
         }      
         
        // a l'avantage de permettre d'ajouter du code dans les blocs get et set.
        */
        public DateTime DateCreation { get; }

        public decimal Solde
        {
            get { return _solde; }
        }

        public string Description { get; private set; } //on peut accéder à la valeur de l'extérieur, mais on ne peut la modifier qu'à l'intérieur de la classe.

        public static int Compteur
        {
            get { return _compteur; }
        }

        public Carte CB { get; private set; } 

        //--------------------------------------------------------------------------------------------------
        //méthodes :     
        public void Créditer(decimal montant)
        {
            _solde += montant;
        }

        //surcharge : on crée une 2e méthode du même nom an ajoutant des paramètres, 
        //selon les paramètres entrés par l'utilisateur lors de l'appel de la méthode,
        //le compilateur optera pour la méthode adéquate.
        public void Créditer(decimal montant, string description)
        {
            Créditer(montant);
            Description = description;
        }

        //constructeurs (d'habitude les constructeurs sont placés en premier parmi les méthodes)
        public CompteBancaire(long num)
        {
            Numéro = num;
            _compteur++;
        }

        public CompteBancaire(long num, DateTime dateCréa) : this(num) // syntaxe propre aux constructeurs pour appeler méthode CompteBancaire originale
        {
            DateCreation = dateCréa;
        }

        public CompteBancaire(long num, DateTime dateCréa, Carte cb) : this(num, dateCréa)
        {
            CB = cb;
        }


    }
}
