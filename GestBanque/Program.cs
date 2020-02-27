using Models;
using System;

namespace GestBanque
{
    class Program
    {
        static void Main(string[] args)
        {
            Banque banque = new Banque() 
            {
                Nom = "Technofutur Bank"
            };

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

            banque.Ajouter(courant1);
            banque.Ajouter(courant2);

            banque["00001"].Depot(-500);
            banque["00001"].Depot(500);
            banque["00001"].Retrait(-750);
            banque["00001"].Retrait(750);

            banque["00002"].Depot(500);

            Console.WriteLine($"Solde du compte '{banque["00001"].Numero}' : {banque["00001"].Solde}");
            Console.WriteLine($"Solde du compte '{banque["00002"].Numero}' : {banque["00002"].Solde}");
            Console.WriteLine($"Avoir des comptes de {chuckNorris.Prenom} {chuckNorris.Nom} : {banque.AvoirDesComptes(chuckNorris)}");
        }
    }
}
