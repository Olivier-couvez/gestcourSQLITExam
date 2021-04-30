using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace GestionCoursesXamarin.Models
{
    class EnregListeCoureurs
    {
        private string nomFichier;
        private List<Coureur> lesCoureurs;

        public EnregListeCoureurs()
        {
            nomFichier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "listecoureurs.json");
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
        public List<Coureur> recuperationListe()
        {
            string maListe = File.ReadAllText(nomFichier);
            lesCoureurs =  JsonConvert.DeserializeObject<List<Coureur>>(maListe);

           // Stream testFileStream = File.OpenRead(nomFichier); // on ouvre le fichier en lecture
           // BinaryFormatter deserialiseur = new BinaryFormatter();
           // lesCoureurs = (List<Coureur>)deserialiseur.Deserialize(testFileStream);
           // testFileStream.Close();
            return lesCoureurs;
        }

        public bool sauveListe(List<Coureur> listcou)
        {
            bool testCreation = false;
            try
            {
                string maListe =  JsonConvert.SerializeObject(listcou);
                File.WriteAllText(nomFichier, maListe);
                testCreation = true;

            }
            catch (Exception erreur)
            {

                testCreation = false;
            }

            return testCreation;

        }
        internal List<Coureur> LesCoureurs { get => lesCoureurs; set => lesCoureurs = value; }
    }
}
