using System;
using System.Collections.Generic;
using System.Text;

namespace Soins2020.classesMetier
{
    class Prestation
    {
        private string libelle;
        private DateTime dateSoin;
        private Intervenant l_Intervenant;

        /// <summary>
        /// Constructeur de Prestation
        /// </summary>
        /// <param name="libelle"> le libelle de la prestation</param>
        /// <param name="dateSoin"> la date de soin de la prestation</param>
        /// <param name="l_Intervenant"> l'intervenant sur la prestation</param>
        public Prestation(string libelle, DateTime dateSoin, Intervenant l_Intervenant)
        {
            this.libelle = libelle;
            this.dateSoin = dateSoin;
            this.l_Intervenant = l_Intervenant;
            this.l_Intervenant.ajoutePrestation(this);
        }


        /// <summary>
        /// Fonction permettant de comparer les dates de deux soins et en sortir un entier
        /// </summary>
        /// <param name="unePresta"> la prestation avec laquelle on va comparé la prestation courante</param>
        /// <returns> l'entier correspondant </returns>
        public int compareTo(Prestation unePresta)
        {
            try
            {
                if (this.dateSoin.Date == unePresta.getDateSoin.Date)
                {
                    return 0;
                }
                else if (this.dateSoin.Date < unePresta.getDateSoin.Date)
                {
                    return -1;
                }
                else { return 1; }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        /// <summary>
        /// Accesseur sur la date de soin 
        /// </summary>
        public DateTime getDateSoin { get => dateSoin; }

        /// <summary>
        /// Accesseur sur l'intervenant
        /// </summary>
        public Intervenant getL_Intervenant { get => l_Intervenant; }

        /// <summary>
        /// Accesseur sur le Libelle
        /// </summary>
        public string getLibelle { get => libelle; }


        /// <summary>
        /// Fonction qui retourne les informations sur la prestation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Libelle " + getLibelle + " - " + getDateSoin + getL_Intervenant.ToString();
        }
    }
}
