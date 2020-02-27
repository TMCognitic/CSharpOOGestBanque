using System;

namespace Models
{
    public class Courant
    {
        public static double operator+(double d, Courant compte)
        {
            return ((d < 0) ? 0 : d) + ((compte.Solde < 0) ? 0 : compte.Solde);
        }

        private string _numero;
        private double _solde;
        private double _ligneDeCredit;
        private Personne _titulaire;

        public string Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                _numero = value;
            }
        }

        public double Solde
        {
            get
            {
                return _solde;
            }

            private set
            {
                _solde = value;
            }
        }

        public double LigneDeCredit
        {
            get
            {
                return _ligneDeCredit;
            }

            set
            {
                if (value < 0)
                    return;

                _ligneDeCredit = value;
            }
        }

        public Personne Titulaire
        {
            get
            {
                return _titulaire;
            }

            set
            {
                _titulaire = value;
            }
        }

        public void Depot(double montant)
        {
            if (montant <= 0)
                return;

            Solde += montant;
        }

        public void Retrait(double montant)
        {
            if (montant <= 0)
                return;

            if (Solde - montant < -LigneDeCredit)
                return;

            Solde -= montant;
        }
    }
}
