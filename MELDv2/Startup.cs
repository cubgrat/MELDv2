using MELDv2.Repositories;
using MELDv2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MELDv2.FileWorkers;

namespace MELDv2
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


            Console.Write("\nEnter endpoint DB number with alarms in S5:  ");
            CWarning();
            Console.Write("DB");
            EndpointDB = "DB" + Console.ReadLine();
            CNormal();

            Console.Write("\nEnter Simatic connection name (same in WinCC):  ");
            CWarning();
            ConnectionName = Console.ReadLine();
            CNormal();


        }
        private string FolderPath { get; set; }
        private string S5SeqPath { get; set; }
        private string MessageFilePath { get; set; }
        private string TagFilePath { get; set; }
        private string EndpointDB { get; set; }
        private string ConnectionName { get; set; }
        public void Run() 
        {
            new S5MessageReader(S5SeqPath);
            new TagWriter(TagFilePath,ConnectionName, EndpointDB);

        }
        private string ConfigureFilePath() 
        {
            FolderScaner scanner = new FolderScaner(FolderPath);
            int i = 0;
            foreach (var item in scanner.GetFileNames())
            {
                i++;
                CWarning();
                Console.Write($"[{i}] ");
                CNormal();
                Console.WriteLine(item);
                
            }

            Console.Write("\nEnter file number: ");
            return scanner.GetPathAtIndexOf(Int32.Parse(Console.ReadLine()) - 1);
        }
        private void CError() =>
            Console.ForegroundColor = ConsoleColor.Red;
        private void CWarning() =>
            Console.ForegroundColor = ConsoleColor.Green;
        private void CNormal() =>
            Console.ForegroundColor = ConsoleColor.White;




    }
}
