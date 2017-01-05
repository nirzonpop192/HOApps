using System;

namespace HO.Apps.Contracts
{
    public interface ILogService
    {
        void Log(string content, string fileName = "");
        void LogException(Exception ex);
    }
}
