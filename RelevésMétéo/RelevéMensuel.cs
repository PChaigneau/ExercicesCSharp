using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace RelevésMétéo
{
    class RelevéMensuel
    {
        #region champs
        #endregion
        #region propriétés

        public DateTime Mois { get; private set; }
        public double TempératureMin { get; private set; }
        public double TempératureMax { get; private set; }
        public double Précip { get; private set; }
        public double Ensol { get; private set; }

        #endregion

        #region Méthodes
        public RelevéMensuel(string[] relevé)
        {
            Mois = DateTime.Parse(relevé[0]);
            TempératureMin = double.Parse(relevé[1]);
            TempératureMax = double.Parse(relevé[2]);
            Précip = double.Parse(relevé[3]);
            Ensol = double.Parse(relevé[4]);
        }

        public override string ToString()
        {
            return string.Format
                (
                "{0:MM/yyyy} | {1,6} | {2,6} | {3,11} | {4,10}",
                Mois,
                TempératureMin,
                TempératureMax,
                Précip,
                Ensol
                );
        }

        #endregion
    }
}
