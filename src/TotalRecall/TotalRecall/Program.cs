using System;
using System.Diagnostics;
using TotalRecall.Core.Interfaces;
using TotalRecall.Infrastructure.DataAccess.Files;

namespace TotalRecall
{
    class Program
    {
        static void Main(string[] args)
        {
            //Process.Start("C:\\Program Files\\Notepad++\\notepad++.exe", "\"c:\\file name for test.txt\"");
            //Console.WriteLine("Hello World!");
            IFileRepository fileRepository = new FileRepository();
            //When memory is created I create folder for that memory
            var memoryPath = fileRepository.CreateDirectory("DDD");
            var cellSummeryPath = fileRepository.CreateFile(memoryPath, "EFCore (and a DDD win)");
            Process.Start("C:\\Program Files\\Notepad++\\notepad++.exe", $"\"{cellSummeryPath}\"");

        }
    }
}
