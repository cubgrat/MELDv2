using MELDv2.Repositories;
using MELDv2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MELDv2.FileWorkers;
using LatinToCyrilicConverterRUS.FileWorkers;

namespace LatinToCyrilicConverterRUS
{
    internal class Startup
    {
        public Startup(string folderPath) 
        {
            FolderPath = folderPath;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nSelect .SEQ file!");
            S5SeqPath = ConfigureFilePath();

            Console.WriteLine("\nSelect .txt alarms file!");
            MessageFilePath = ConfigureFilePath();

            Console.WriteLine("\nSelect .csv messages file!");
            TagFilePath = ConfigureFilePath();
        }
        private string FolderPath { get; set; }
        private string S5SeqPath { get; set; }
        private string MessageFilePath { get; set; }
        private string TagFilePath { get; set; }
        public void Run() 
        {
            new S5MessageReader(S5SeqPath);

        }
        private string ConfigureFilePath() 
        {
            FolderScaner scanner = new FolderScaner(FolderPath);
            int i = 0;
            foreach (var item in scanner.GetFileNames())
            {
                i++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"[{i}] ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(item);
                
            }

            Console.Write("\nEnter file number: ");
            return scanner.GetPathAtIndexOf(Int32.Parse(Console.ReadLine()) - 1);
        }

    }
}
