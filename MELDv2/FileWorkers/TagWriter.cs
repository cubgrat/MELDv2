using MELDv2;
using MELDv2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MELDv2.FileWorkers
{
    internal class TagWriter
    {
        public TagWriter(string path, string connectionName, string db) 
        {
            Path = path;
            ConnectionName = connectionName;
            DB = db;
            ParseS5Repository();
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
                        AdressConverter.ConvertAdressS5toS7(DB, message.Adress)
                    ));
            }
        }
        private void WriteFile() 
        {
            
        }
        private string MakeName(string adress) =>
            ConnectionName + "_" + adress.Replace('.', '_');
    }
}
