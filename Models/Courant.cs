using System;

namespace Models
{
    public class Courant : Compte
    {
        private double _ligneDeCredit;        

        public double LigneDeCredit
        {
            get
            {
                return _ligneDeCredit;
            }

            set
            {
                if (value < 0)
                    throw new InvalidOperationException();

                _ligneDeCredit = value;
            }
        }

        public Courant(string numero, Personne titulaire)
            : base(numero, titulaire)
        {

        }

        public Courant(string numero, Personne titulaire, double solde)
            : base(numero, titulaire, solde)
        {

        }

        public Courant(string numero, double ligneDeCredit, Personne titulaire)
            : base(numero, titulaire)
        {
            LigneDeCredit = ligneDeCredit;
        }

        public override void Retrait(double montant)
        {
            double solde = Solde;
            Retrait(montant, LigneDeCredit);

            if (solde >= 0 && Solde < 0)
            {
                RaisePassageEnNegatifEvent();
            }
        }

        protected override double CalculInteret()
        {
            return Solde * ((Solde < 0) ? .0975 : .03);
        }
    }
}
