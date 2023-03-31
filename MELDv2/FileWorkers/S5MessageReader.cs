using MELDv2.Repositories;
using MELDv2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MELDv2.FileWorkers
{
    internal class S5MessageReader
    {
        public S5MessageReader(string path) 
        {
            Path = path;
            ReadFile();
        }
        private string Path { get; set; }

        private void ReadFile() 
        {
            using (StreamReader s5messagesReader = new StreamReader(Path))
            {
                string? line;
                while ((line = s5messagesReader.ReadLine()) != null)
                {
                    Regex regex = new Regex(@"S \d+\.\d\tS\d\d\d\d\.\d [1_][2_][3_][4_][5_][6_][7_][FWB]");
                    if (regex.IsMatch(line))
                        S5MessagesRepository.Add(new S5Message(line));
                }
            }
        }
        
    }
}
