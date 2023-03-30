using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MELDv2.Repositories
{
    static public class S5MessagesRepository
    {
        static public List<S5Message> S5Messages = new List<S5Message>();

        static public void Add(S5Message message) =>
            S5Messages.Add(message);
    }
    public class S5Message 
    {
        public S5Message(string message) 
        {
            Console.WriteLine(message);
            var messageSplit = message.Split('\t', StringSplitOptions.RemoveEmptyEntries);
            Adress = messageSplit[0];
            var tempSplit = messageSplit[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            BigAdress = tempSplit[0];
            MessageType = tempSplit[1];
            MessageNumberCode = tempSplit[2];
            if(messageSplit.Length > 2)
                MessageText = messageSplit[2];

        }
        public string Adress {get;set;}
        public string BigAdress { get; set; }
        public string MessageType { get; set; }
        public string MessageNumberCode { get; set; }
        public string MessageText { get; set; } = "No message";
    }
}
