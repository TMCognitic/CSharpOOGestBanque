using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Banque
    {
        private Dictionary<string, Courant> _comptes = new Dictionary<string, Courant>();
        public string Nom { get; set; }

        public Courant this[string numero]
        {
            get
            {
                _comptes.TryGetValue(numero, out Courant compte);
                return compte;
            }
        }

        public void Ajouter(Courant compte)
        {
            _comptes[compte.Numero] = compte;
        }

        public void Supprimer(string numero)
        {
            _comptes.Remove(numero);
        }

        public double AvoirDesComptes(Personne titulaire)
        {
            double total = 0;

            foreach (Courant compte in _comptes.Values)
                if (compte.Titulaire == titulaire)
                    total += compte;

            return total;
        }
    }
}
