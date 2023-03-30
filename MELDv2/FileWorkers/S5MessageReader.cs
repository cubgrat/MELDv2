using MELDv2.Repositories;
using MELDv2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LatinToCyrilicConverterRUS.FileWorkers
{
    internal class S5MessageReader
    {
        public S5MessageReader(string path) 
        {
            Path = path;
            ReadFile(path);
        }
        private string Path { get; set; }

        private void ReadFile(string path) 
        {
            using (StreamReader s5messagesReader = new StreamReader(Path))
            {
                string? line;
                while ((line = s5messagesReader.ReadLine()) != null)
                {

                    Regex regex = new Regex(@"S \d+\.\d\tS\d\d\d\d\.\d .+ M-\d+");
                    if (regex.IsMatch(line))
                        S5MessagesRepository.Add(new S5Message(line));

                    //bool isMessageLine = false;
                    //var subStrings = line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    //if (subStrings.Length > 2)
                    //{
                    //    var subSubStrings = subStrings[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    //    if (subSubStrings.Length > 2  && subSubStrings[1].Contains("__"))
                    //    {
                    //        isMessageLine = true;
                    //        condCount++;
                    //    }
                    //}

                }

                //foreach (var item in S5MessagesRepository.S5Messages)
                //{
                //    Console.Write(item.Adress);
                //    Console.Write("\t -> \t");
                //    Console.WriteLine(AdressConverter.JoinAdress("DB170", AdressConverter.ConvertAdressS5toS7(item.Adress)));
                //}

            }
        }
    }
}
