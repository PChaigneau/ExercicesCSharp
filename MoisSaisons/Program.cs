using System;

namespace MoisSaisons
{
    [Flags]
    public enum Mois
    {
        aucun = 0,
        janvier = 1,
        février = 2,
        mars = 4,
        avril = 8,
        mai = 16,
        juin = 32,
        juillet = 64,
        août = 128,
        septembre = 256,
        octobre = 512,
        novembre = 1024,
        decembre = 2048
    }

    [Flags]
    public enum Saisons
    {
        aucun = 0,
        automne = 1,
        printemps = 2,
        été = 4,
        hiver = 8
    }
    class Program
    {
        static void Main(string[] args)
        {
            Mois mars = Mois.mars;
            Saisons sais = SaisonsDuMois(mars);
            Console.WriteLine($"Saison(s) du mois {mars} : {sais}");            
        }
        static Saisons SaisonsDuMois(Mois mois)
        {
            //définition des masques :
            Mois moisAutomne = Mois.septembre | Mois.octobre | Mois.novembre | Mois.decembre;
            Mois moisPrintemps = Mois.mars | Mois.avril | Mois.mai | Mois.juin;
            Mois moisEté = Mois.juin | Mois.juillet | Mois.août | Mois.septembre;
            Mois moisHiver = Mois.decembre | Mois.janvier | Mois.février | Mois.mars;

            Saisons sais = Saisons.aucun;

            if ((mois & moisHiver) == mois) sais |= Saisons.hiver;
            if ((mois & moisPrintemps) == mois) sais |= Saisons.printemps;
            if ((mois & moisEté) == mois) sais |= Saisons.été;
            if ((mois & moisAutomne) == mois) sais |= Saisons.automne;
            return sais;
        }
    }
}
