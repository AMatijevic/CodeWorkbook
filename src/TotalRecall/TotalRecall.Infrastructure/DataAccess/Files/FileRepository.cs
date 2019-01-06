using System;
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

        public string CreateDirectory(string name, string path = "")
        {
            var resultPath = string.IsNullOrEmpty(path)
                ? $@"{_path}{CurrentDate}_{name}"
                : $@"{_path}{path}\{CurrentDate}_{name}";

            Directory.CreateDirectory(resultPath);

            return resultPath;
        }

        public string CreateFile(string path, string name)
        {
            var resultPath = $@"{path}\{CurrentDate}_{name}.txt";

            File.CreateText(resultPath);

            return resultPath;
        }
    }
}