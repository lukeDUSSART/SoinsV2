using System;
using System.Collections.Generic;
using System.Text;

namespace Soins2020.classesMetier
{
    class Intervenant
    {
        //Attributs privés

        private string nom;
        private string prenom;
        private List<Prestation> lesPrestations;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nom"> nom de l'intervenant</param>
        /// <param name="prenom"> prenom de l'intervenant</param>
        public Intervenant(string nom, string prenom)
        {

            this.nom = nom;
            this.prenom = prenom;
            this.lesPrestations = new List<Prestation>();
        }

        /// <summary>
        /// Accesseur sur l'attriut Nom
        /// </summary>
        public string getNom { get => nom; }
        /// <summary>
        /// Accesseur sur l'attribut prenom
        /// </summary>
        public string getPrenom { get => prenom; }

        /// <summary>
        /// Procédure permettant d'ajouter une prestation à la liste des prestations de l'intervenant
        /// </summary>
        /// <param name="unePrestation">la prestation à ajouter à la liste</param>
        public void ajoutePrestation(Prestation unePrestation)
        {
            try
            {
                this.lesPrestations.Add(unePrestation);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        /// <summary>
        /// Méthode qui permet de retourner les informaions de l'interveant
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return " Intervenant : " + getNom + " - " + getPrenom;
        }
    }
}
