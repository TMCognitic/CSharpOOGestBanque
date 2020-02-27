using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Epargne : Compte
    {
        public DateTime DateDernierRetrait { get; private set; }

        public override void Retrait(double montant)
        {
            double oldSolde = Solde;
            base.Retrait(montant);

            if(oldSolde != Solde)
            {
                DateDernierRetrait = DateTime.Now;
            }
        }
    }
}
