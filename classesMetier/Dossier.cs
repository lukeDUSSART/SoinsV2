using System;
using System.Collections.Generic;
using System.Text;

namespace Soins2020.classesMetier

{
    class Dossier
    {
        /// <summary>
        /// Attributs privés
        /// </summary>

        private string nomPatient;
        private string prenomPatient;
        private DateTime dateNaissancePatient;
        private List<Prestation> mesPrestations;

        /// <summary>
        /// Accesseur sur le nom du patient
        /// </summary>
        public string getNomPatient { get => nomPatient; }

        /// <summary>
        /// Accesseur sur le prenom du patient
        /// </summary>
        public string getPrenomPatient { get => prenomPatient; }

        /// <summary>
        /// Accesseur sur la date de naissance du patient
        /// </summary>
        public DateTime getDateNaissancePatient { get => dateNaissancePatient; }

        /// <summary>
        /// Constructeur de Dossier sans prestation 
        /// </summary>
        /// <param name="nomPatient"> nom du patient</param>
        /// <param name="prenomPatient"> prenom du patient</param>
        /// <param name="dateNaissancePatient"> date de naissance du patient</param>
        public Dossier(string nomPatient, string prenomPatient, DateTime dateNaissancePatient)
        {
            this.nomPatient = nomPatient;
            this.prenomPatient = prenomPatient;
            this.dateNaissancePatient = dateNaissancePatient;
            this.mesPrestations = new List<Prestation>();
        }


        /// <summary>
        /// Constructeur de Dossier avec une prestation 
        /// </summary>
        /// <param name="nomPatient"> nom du patient</param>
        /// <param name="prenomPatient"> prenom du patient</param>
        /// <param name="dateNaissancePatient"> date de naissance du patient</param>
        /// <param name="unePrestation"> une prestation à insérer dans le dossier</param>
        public Dossier(string nomPatient, string prenomPatient, DateTime dateNaissancePatient, Prestation unePrestation)
        {
            this.nomPatient = nomPatient;
            this.prenomPatient = prenomPatient;
            this.dateNaissancePatient = dateNaissancePatient;
            this.mesPrestations = new List<Prestation>();
            this.mesPrestations.Add(unePrestation);
        }


        /// <summary>
        /// Constructeur de Dossier avec une liste de prestations 
        /// </summary>
        /// <param name="nomPatient"> nom du patient</param>
        /// <param name="prenomPatient"> prenom du patient</param>
        /// <param name="dateNaissancePatient"> date de naissance du patient</param>
        /// <param name="lesPrestations"> une liste de prestation à insérer dans le client</param>
        public Dossier(string nomPatient, string prenomPatient, DateTime dateNaissancePatient, List<Prestation> lesPrestations)
        {
            this.nomPatient = nomPatient;
            this.prenomPatient = prenomPatient;
            this.dateNaissancePatient = dateNaissancePatient;
            this.mesPrestations = new List<Prestation>();
            foreach (Prestation unePresta in lesPrestations)
            {
                this.mesPrestations.Add(unePresta);
            }

        }

        /// <summary>
        /// Procédure permettant d'ajouter une prestation dans la liste des prestations du dossier du patient
        /// </summary>
        /// <param name="libelle"> libelle de la prestation</param>
        /// <param name="dateSoin"> date de soin de la prestation</param>
        /// <param name="unIntervenant"> l'intervenant sur la prestation</param>
        public void ajoutePrestation(string libelle, DateTime dateSoin, Intervenant unIntervenant)
        {
            try
            {
                this.mesPrestations.Add(new Prestation(libelle, dateSoin, unIntervenant));
            }
            catch (Exception e) { throw new Exception(e.Message); }

        }

        /// <summary>
        /// Fonction permettant de retourner le nombre de prestations effectuées par un intervenant externe
        /// </summary>
        /// <returns> cpt </returns>
        public int getNbPrestationsExternes()
        {
            try
            {
                int cpt = 0;
                foreach (Prestation unePresta in mesPrestations)
                {
                    if (unePresta.getL_Intervenant.GetType().ToString() == "Soins2020.classesMetier.IntervenantExterne")
                    {
                        cpt += 1;
                    }
                }
                return cpt;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        /// <summary>
        /// Fonction permettant de retourner le nombre de prestations effectuées
        /// </summary>
        /// <returns></returns>
        public int getNbPrestations()
        {
            try
            {
                return this.mesPrestations.Count;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }


        /// <summary>
        /// Fonction permettetant de récupérer le nombre de jours de soins déjà effectués
        /// </summary>
        /// <returns></returns>
        public int getNbJoursSoins()
        {
            try
            {
                if (this.mesPrestations.Count == 0)
                {
                    return 0;
                }

                int cpt = 1;
                this.mesPrestations.Sort((x, y) => DateTime.Compare(x.getDateSoin.Date, y.getDateSoin.Date));
                Prestation unePrestation = this.mesPrestations[0];
                foreach (Prestation maPresta in this.mesPrestations)
                {
                    cpt += maPresta.compareTo(unePrestation);
                    unePrestation = maPresta;
                }
                return cpt;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }


        /// <summary>
        /// Fonction permettetant de récupérer le nombre de jours de soins déjà effectués sans tri
        /// </summary>
        /// <returns></returns>
        public int getNbJoursSoinsV2()
        {
            try
            {
                if (this.mesPrestations.Count == 0)
                {
                    return 0;
                }
                List<DateTime> dates = new List<DateTime>();
                foreach (Prestation unePresta in mesPrestations)
                {
                    if (!dates.Contains(unePresta.getDateSoin.Date))
                    {
                        dates.Add(unePresta.getDateSoin.Date);
                    }
                }
                return dates.Count;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public override string ToString()
        {
            string dossier = "------- Début Dossier ------\n Nom : " + getNomPatient + " Prénom : " + getPrenomPatient + " Date de nassance : " + getDateNaissancePatient.Date;

            if (this.mesPrestations.Count != 0)
            {
                foreach (Prestation unePresta in this.mesPrestations)
                {
                    dossier += "\n\t" + unePresta.ToString();
                }
            }

            dossier += "\n------- Fin du dossier ----------";

            return dossier;
        }
    }
}
