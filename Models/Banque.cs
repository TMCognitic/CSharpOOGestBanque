using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Banque
    {
        private Dictionary<string, Compte> _comptes = new Dictionary<string, Compte>();        

        public string Nom { get; private set; }

        public Compte this[string numero]
        {
            get
            {
                _comptes.TryGetValue(numero, out Compte compte);
                return compte;
            }
        }

        public Banque(string nom)
        {
            Nom = nom;
        }

        public void Ajouter(Compte compte)
        {
            compte.PassageEnNegatifEvent += Compte_PassageEnNegatif;
            _comptes[compte.Numero] = compte;
        }        

        public void Supprimer(string numero)
        {
            Compte compte = this[numero];
            compte.PassageEnNegatifEvent -= Compte_PassageEnNegatif;
            _comptes.Remove(numero);
        }

        private void Compte_PassageEnNegatif(Compte compte)
        {
            Console.WriteLine($"Le compte '{compte.Numero}' vient de passer en négatif!");
        }

        public double AvoirDesComptes(Personne titulaire)
        {
            double total = 0;

            foreach (Compte compte in _comptes.Values)
                if (compte.Titulaire == titulaire)
                    total += compte;

            return total;
        }
    }
}
