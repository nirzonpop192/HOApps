namespace HO.Apps.Contracts
{
    public interface ICrossFileService
    {
        string GetDefaultDirectory();
        string GetApplicationDataDirectory();
        bool IsDirectoryExists(string path);
        string CreateDirectory(string path);
        void DeleteDirectory(string path);
        bool IsFileExists(string path);
        void Save(string content, string path);
        string Load(string path);
        void DeleteFile(string path);
    }
}
