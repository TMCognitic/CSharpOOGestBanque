﻿using System;

namespace Models
{
    public class Compte
    {
        public static double operator+(double d, Compte compte)
        {
            return ((d < 0) ? 0 : d) + ((compte.Solde < 0) ? 0 : compte.Solde);
        }

        private string _numero;
        private double _solde;
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

        public virtual void Retrait(double montant)
        {
            Retrait(montant, 0);
        }

        protected void Retrait(double montant, double ligneDeCredit)
        {
            if (montant <= 0)
                return;

            if (Solde - montant < -ligneDeCredit)
                return;

            Solde -= montant;
        }
    }
}