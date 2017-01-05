using HO.Apps.Contracts;
using HO.Apps.Droid.Services;
using HO.Apps.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidFileService))]
namespace HO.Apps.Droid.Services
{
    public class AndroidFileService : ICrossFileService
    {
        public string GetDefaultDirectory()
        {
            string basePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string path = Directory.CreateDirectory(Path.Combine(basePath, ApplicationSettingsConstant.RootDirectory)).FullName;
            Debug.WriteLine(path);
            return path;
        }

        public void DeleteFile(string path)
        {
            Debug.WriteLine(path);
            File.Delete(path);
        }

        public bool IsDirectoryExists(string path)
        {
            Debug.WriteLine(path);
            return Directory.Exists(path);
        }

        public bool IsFileExists(string path)
        {
            Debug.WriteLine(path);
            return File.Exists(path);
        }

        public string Load(string path)
        {
            Debug.WriteLine(path);
            return File.ReadAllText(path);
        }

        public void Save(string content, string path)
        {
            Debug.WriteLine(path);
            File.AppendAllText(path, content);
        }

        public string CreateDirectory(string path)
        {
            if (!IsDirectoryExists(path))
                path = Directory.CreateDirectory(path).FullName;

            Debug.WriteLine(path);
            return path;
        }

        public void DeleteDirectory(string path)
        {
            IEnumerable<string> files = new List<string>();
            var directories = Directory.EnumerateDirectories(path);
            foreach (var directory in directories)
            {
                files = Directory.EnumerateFiles(Path.Combine(path, directory));
                foreach (var file in files)
                {
                    DeleteFile(file);
                }

                Directory.Delete(directory);
            }


            files = Directory.EnumerateFiles(path);
            foreach (var file in files)
            {
                DeleteFile(file);
            }

            Directory.Delete(path);
        }

        public string GetApplicationDataDirectory()
        {
            string basePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string path = Directory.CreateDirectory(Path.Combine(basePath, ApplicationSettingsConstant.RootDirectory)).FullName;
            Debug.WriteLine(path);
            return path;
        }
    }
}