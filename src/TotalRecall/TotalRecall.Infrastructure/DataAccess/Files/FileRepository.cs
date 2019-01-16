using System;
using System.Diagnostics;
using System.IO;
using TotalRecall.Core.Interfaces;

namespace TotalRecall.Infrastructure.DataAccess.Files
{
    public class FileRepository : IFileRepository
    {
        private readonly string _path;
        private string CurrentDate => DateTime.Now.ToShortDateString();

        public FileRepository(string path)
        {
            _path = path;
        }

        public FileRepository()
        {
            _path = @"C:\Users\andrej.matijevic\Google Drive\Documents\2019\";
        }

        public string CreateDirectory(string name)
        {
            var resultPath = $@"{_path}{CurrentDate}_{name}";
            Directory.CreateDirectory(resultPath);
            return resultPath;
        }

        public string CreateFile(string path)
        {
            var resultPath = $@"{path}\{CurrentDate}_summery.txt";
            File.CreateText(resultPath);
            File.Create($@"{path}\{CurrentDate}_summery.md");
            File.Create($@"{path}\{CurrentDate}_code.linq");
            Process.Start("C:\\Program Files\\Notepad++\\notepad++.exe", $"\"{resultPath}\"");
            return resultPath;
        }
    }
}