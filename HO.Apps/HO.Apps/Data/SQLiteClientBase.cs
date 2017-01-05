using HO.Apps.Contracts;
using SQLite.Net;
using Xamarin.Forms;

namespace HO.Apps.Data
{
    public class SQLiteClientBase<T> where T : class, new()
    {
        static object locker = new object();
        SQLiteConnection database;

        public SQLiteClientBase()
        {
            database = DependencyService.Get<ISQLiteStorage>().GetConnection();

            // Create Tables
            database.CreateTable<T>();
        }

        public TableQuery<T> All()
        {
            lock (locker)
            {
                return database.Table<T>();
            }
        }

        public T Get(object id)
        {
            lock (locker)
            {
                return database.Get<T>(id);
            }
        }

        public int Save(T item)
        {
            lock (locker)
            {
                return database.Insert(item);
            }
        }

        public int Update(T item)
        {
            lock (locker)
            {
                return database.Update(item);
            }
        }

        public int Delete(T item)
        {
            lock (locker)
            {
                return database.Delete(item);
            }
        }
    }
}
