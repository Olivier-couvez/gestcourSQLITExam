using System.Collections.Generic;
using GestionCoursesXamarin.ViewModels;
using System.Threading.Tasks;
using SQLite;

namespace GestionCoursesXamarin.Models
{ 
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<enrCourse>().Wait();
            _database.CreateTableAsync<enrCoureur>().Wait();
            _database.CreateTableAsync<enrInsciption>().Wait();
        }

        public Task<List<enrCourse>> GetcourseAsync()
        {
            return _database.Table<enrCourse>().ToListAsync();
        }

        public Task<int> SaveCourseAsync(enrCourse course)
        {     
                return _database.InsertAsync(course);
        }

        public Task<int> DeleteCourseAsync(enrCourse course)
        {
            return _database.DeleteAsync(course);
        }

        public Task<List<enrCoureur>> GetCoureurAsync()
        {
            return _database.Table<enrCoureur>().ToListAsync();
        }

        public Task<int> SaveCoureurAsync(enrCoureur coureur)
        {
                return _database.InsertAsync(coureur);
        }
        public Task<int> DeleteCoureurAsync(enrCoureur coureur)
        {
            return _database.DeleteAsync(coureur);
        }

        public Task<List<enrInsciption>> GetInscriptionAsync()
        {
            return _database.Table<enrInsciption>().ToListAsync();
        }

        public Task<int> SaveInscriptionAsync(enrInsciption Inscrpt)
        {
                return _database.InsertAsync(Inscrpt);
        }
        public Task<int> DeleteInscriptionAsync(enrInsciption Inscrpt)
        {
            return _database.DeleteAsync(Inscrpt);
        }

     }
}
