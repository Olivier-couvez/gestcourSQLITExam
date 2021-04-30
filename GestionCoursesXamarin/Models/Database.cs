using System.Collections.Generic;
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
        }

        public Task<List<enrCourse>> GetcourseAsync()
        {
            return _database.Table<enrCourse>().ToListAsync();
        }

        public Task<int> SaveCourseAsync(enrCourse course)
        {
            return _database.InsertAsync(course);
        }
    }
}
