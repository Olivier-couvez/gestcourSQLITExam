using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace GestionCoursesXamarin.Models
{
    class EnregListeCourses
    {
        private string nomFichier;
        private List<Course> lesCourses;

        public EnregListeCourses()
        {
            nomFichier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "listecourses.json");
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
        public List<Course> recuperationListe()
        {
            string maListe = File.ReadAllText(nomFichier);
            lesCourses = JsonConvert.DeserializeObject<List<Course>>(maListe);
            return lesCourses;
        }

        public bool sauveListe(List<Course> listcou)
        {
            bool testCreation = false;
            try
            {
                string maListe = JsonConvert.SerializeObject(listcou);
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
        internal List<Course> LesCoureurs { get => lesCourses; set => lesCourses = value; }
    }
}
