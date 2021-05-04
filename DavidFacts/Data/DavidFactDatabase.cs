using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace DavidFacts
{
    public class DavidFactDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<DavidFactDatabase> Instance = new AsyncLazy<DavidFactDatabase>(async () =>
        {
            var instance = new DavidFactDatabase();
            CreateTableResult result = await Database.CreateTableAsync<DavidFact>();
            return instance;
        });

        public DavidFactDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<DavidFact>> GetItemsAsync()
        {
            return Database.Table<DavidFact>().ToListAsync();
        }

        public Task<List<DavidFact>> GetItemsNotDoneAsync()
        {
            // SQL queries are also possible
            return Database.QueryAsync<DavidFact>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<DavidFact> GetItemAsync(int id)
        {
            return Database.Table<DavidFact>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(DavidFact item)
        {
            if (item.Id != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(DavidFact item)
        {
            return Database.DeleteAsync(item);
        }
    }
}