using System;
using System.Collections.Generic;
using System.Text;

namespace Soins2020.classesMetier
{
    class IntervenantExterne : Intervenant
    {
        private string specialite;
        private string adresse;
        private string tel;

        /// <summary>
        /// Constructeur IntervenantExterne
        /// </summary>
        /// <param name="nom"> nom de l'intervenant</param>
        /// <param name="prenom"> prenom de l'intervenant</param>
        /// <param name="specialite"> specialite de l'intervenant</param>
        /// <param name="adresse"> adresse de l'interveant</param>
        /// <param name="tel"> tel de l'intervenant</param>
        public IntervenantExterne(string nom, string prenom, string specialite, string adresse, string tel) : base(nom, prenom)
        {
            this.specialite = specialite;
            this.adresse = adresse;
            this.tel = tel;
        }
        /// <summary>
        /// Accesseur sur spécialité
        /// </summary>
        public string getSpecialite { get => specialite; }

        /// <summary>
        /// Accesseur sur Adresse
        /// </summary>
        public string getAdresse { get => adresse; }

        /// <summary>
        /// Accesseur sur Tel
        /// </summary>
        public string getTel { get => tel; }

        /// <summary>
        /// Méthode qui permet de retourner les informations d'un intervenant externe
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + " Spécialité : " + getSpecialite + " " + getAdresse + " - " + getTel;
        }
    }

}
