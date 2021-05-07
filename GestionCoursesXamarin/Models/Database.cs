using System.Collections.Generic;
using GestionCoursesXamarin.ViewModels;
using System.Threading.Tasks;
using SQLite;
using System.Linq;
using GestionCoursesXamarin.Extension;

namespace GestionCoursesXamarin.Models
{
    public class Database
    {
        //readonly SQLiteAsyncConnection _database;
        readonly SQLiteConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<enrCourse>();
            _database.CreateTable<enrCoureur>();
            _database.CreateTable<enrInsciption>();
        }

        public List<Course> GetCourse()
        {
            List<Course> courses = new List<Course>();
            foreach (enrCourse enr in _database.Table<enrCourse>().ToList())
            {
                courses.Add(enr.ToCourse());
            }
            return courses;
        }

        public int SaveCourse(enrCourse course)
        {
            return _database.Insert(course);
        }

        public int DeleteCourse(enrCourse course)
        {
            return _database.Delete(course);
        }

        public List<Coureur> GetCoureur()
        {
            List<Coureur> coureur = new List<Coureur>();
            foreach (enrCoureur enr in _database.Table<enrCoureur>().ToList())
            {
                coureur.Add(enr.ToCoureur());
            }
            return coureur;
        }

        public int SaveCoureur(enrCoureur coureur)
        {
            return _database.Insert(coureur);
        }

        public int DeleteCoureur(enrCoureur coureur)
        {
            return _database.Delete(coureur);
        }

        public List<Inscription> GetInscription()
        {
            List<Inscription> Inscription = new List<Inscription>();
            foreach (enrInsciption enr in _database.Table<enrInsciption>().ToList())
            {
                Inscription.Add(enr.ToInscription());
            }
            return Inscription;
        }

        public int SaveInscription(enrInsciption Inscrpt)
        {
            return _database.Insert(Inscrpt);
        }
        public int DeleteInscriptionAsync(enrInsciption Inscrpt)
        {
            return _database.Delete(Inscrpt);
        }

    }
}
