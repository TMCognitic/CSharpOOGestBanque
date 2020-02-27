using Models;
using System;

namespace GestBanque
{
    class Program
    {
        static void Main(string[] args)
        {
            Personne chuckNorris = new Personne()
            {
                Nom = "Norris",
                Prenom = "Chuck",
                DateNaiss = new DateTime(1940, 3, 10)
            };

            Courant courant1 = new Courant()
            {
                Numero = "00001",
                LigneDeCredit = 500,
                Titulaire = chuckNorris
            };

            Courant courant2 = new Courant()
            {
                Numero = "00002",
                Titulaire = chuckNorris
            };

            courant1.Depot(-500);
            courant1.Depot(500);
            courant1.Retrait(-750);
            courant1.Retrait(750);

            courant2.Depot(500);

            Console.WriteLine($"Solde du compte '{courant1.Numero}' : {courant1.Solde}");
            Console.WriteLine($"Solde du compte '{courant2.Numero}' : {courant2.Solde}");
        }
    }
}
