using MELDv2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatinToCyrilicConverterRUS.FileWorkers
{
    internal class TagWriter
    {
        public TagWriter(string path, string connectionName, string db) 
        {
            Path = path;
            ConnectionName = connectionName;
            DB = db;
        }
        private string Path { get; set; }
        private string ConnectionName { get; set; }
        private string DB { get; set; }
        private void ParseS5Repository() 
        {
            foreach (S5Message message in S5MessagesRepository.S5Messages)
            {
                TagsRepository.Add(new Tag
                    (
                        MakeName(message.BigAdress),
                        ConnectionName,
                        ConnectionName + "_Alarms",

                    ));
            }
        }
        private void WriteFile() 
        {
            foreach (var item in S5MessagesRepository.S5Messages)
            {
                Console.Write(item.Adress);
                Console.Write("\t -> \t");
                Console.WriteLine(AdressConverter.JoinAdress("DB170", AdressConverter.ConvertAdressS5toS7(item.Adress)));
            }
        }
        private string MakeName(string adress) =>
            ConnectionName + "_" + adress.Replace('.', '_');
    }
}
