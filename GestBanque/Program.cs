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

            Courant compte1 = new Courant()
            {
                Numero = "00001",
                LigneDeCredit = 500,
                Titulaire = chuckNorris
            };

            Epargne compte2 = new Epargne()
            {
                Numero = "00002",
                Titulaire = chuckNorris
            };

            banque.Ajouter(compte1);
            banque.Ajouter(compte2);

            banque["00001"].Depot(-500);
            banque["00001"].Depot(500);
            banque["00001"].Retrait(-750);
            banque["00001"].Retrait(750);

            banque["00002"].Depot(500);

            banque["00001"].AppliquerInteret();
            banque["00002"].AppliquerInteret();

            Console.WriteLine($"Solde du compte '{banque["00001"].Numero}' : {banque["00001"].Solde}");
            Console.WriteLine($"Solde du compte '{banque["00002"].Numero}' : {banque["00002"].Solde}");
            Console.WriteLine($"Avoir des comptes de {chuckNorris.Prenom} {chuckNorris.Nom} : {banque.AvoirDesComptes(chuckNorris)}");
        }
    }
}
