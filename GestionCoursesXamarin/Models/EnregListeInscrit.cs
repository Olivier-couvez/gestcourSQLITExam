using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace GestionCoursesXamarin.Models
{
    class EnregListeInscrit
    {
        private string nomFichier;
        private List<Inscription> lesInscriptions;

        public EnregListeInscrit()
        {
            nomFichier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "listeinscriptions.json");
        }

        /// <summary>
        /// Cette méthode vérifie si le fichier bin existe déjà 
        /// </summary>
        /// <returns></returns>
        /// 
        public bool TestExistenceFichier()
        {
            return File.Exists(nomFichier);

        }
        /// <summary>
        /// Cette méthode permet de récupérer la liste des roverq qui ont été enregistrées dans le fichier bin
        /// </summary>
        /// <returns> retourne la liste des rovers</returns>
        /// 
        public List<Inscription> recuperationListe()
        {
            string maListe = File.ReadAllText(nomFichier);
            lesInscriptions = JsonConvert.DeserializeObject<List<Inscription>>(maListe);
            return lesInscriptions;
        }

        public bool sauveListe(List<Inscription> listins)
        {
            bool testCreation = false;
            try
            {
                string maListe = JsonConvert.SerializeObject(listins);
                File.WriteAllText(nomFichier, maListe);
                testCreation = true;
            }
            catch (FileNotFoundException erreur)
            {

                testCreation = false;
            }
            catch (UnauthorizedAccessException erreur)
            {

                testCreation = false;
            }

            return testCreation;

        }
        internal List<Inscription> LesCoureurs { get => lesInscriptions; set => lesInscriptions = value; }
    }
}
