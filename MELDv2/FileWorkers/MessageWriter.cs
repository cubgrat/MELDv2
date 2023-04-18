using LatinToCyrilicConverterRUS;
using MELDv2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MELDv2.FileWorkers
{
    internal class MessageWriter
    {
        public MessageWriter(string path, int startIndex, int @class, int[] types, string connectionName)
        {
            Path = path;
            StartIndex = startIndex;
            Class = @class;
            Types = types;
            ConnectionName = connectionName;

            ParseS5Repository();
            WriteFile();
        }
        private string Path { get; set; }
        private int StartIndex { get; set; }
        private int Class { get; set; }
        private int[] Types { get; set; }
        private string ConnectionName { get; set; }

        private void ParseS5Repository()
        {
            //russian translitic to cyrilic transformer(optionaly)
            var ltc = new LatinToCyrilicConverter();
            foreach (S5Message message in S5MessagesRepository.S5Messages)
            {
                MessagesRepository.Add(new MessageWinCC
                    (
                        StartIndex,
                        Class,
                        GetWinCCType(message.MessageType),
                        ltc.Translate(message.MessageText),
                        message.MessageNumberCode ?? " ",
                        message.Adress,
                        MakeName(message.BigAdress)
                    ));
                StartIndex++;
            }
        }
        private void WriteFile()
        {
            var newFileName = Path.Replace(".txt", "_MELDv2.txt");
            if (File.Exists(newFileName))
                File.Delete(newFileName);
            File.Copy(Path, newFileName);

            using (StreamWriter mesWriter = new StreamWriter(newFileName, true))
            {
                foreach (var message in MessagesRepository.MessagesWinCC)
                {
                    mesWriter.WriteLine(message.ToString());
                }
            }
        }
        private string MakeName(string adress) =>
            ConnectionName + "_" + adress.Replace('.', '_');
        private int GetWinCCType(string type) 
        {
            var code = type[type.Length - 1];
            switch (code) 
            {
                case 'F':
                    return Types[0];
                case 'W':
                    return Types[1];
                case 'B':
                    return Types[2];
                default: 
                    return Types[0];
            }
        }
    }
}
