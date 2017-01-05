using SQLite;
using SQLite.Net;

namespace HO.Apps.Contracts
{
    public interface ISQLiteStorage
    {
        SQLiteConnection GetConnection();
    }
}
