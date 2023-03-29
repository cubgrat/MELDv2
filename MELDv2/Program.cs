using MELDv2.Repositories;
using System.Text.RegularExpressions;

namespace MELDv2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter .SEQ file name: ");
            string fileName = Console.ReadLine();

            string folderPath = "C:\\Users\\vs\\Desktop\\MELD V2\\";
            string extention = ".SEQ";

            string path = folderPath + fileName + extention;


            using (StreamReader reader = new StreamReader(path))
            {
                int regCount = 0;
                int condCount = 0;
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    
                    Regex regex = new Regex(@"S \d+\.\d\tS\d\d\d\d\.\d .+ M-\d+");
                    if (regex.IsMatch(line))
                        regCount++;
                    
                    
                    if (regex.IsMatch(line))
                        Console.WriteLine(line);

                    bool isMessageLine = false;
                    var subStrings = line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (subStrings.Length > 2)
                    {
                        var subSubStrings = subStrings[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (subSubStrings.Length > 2  && subSubStrings[1].Contains("__"))
                        {
                            isMessageLine = true;
                            condCount++;
                        }
                    }
                    
                    string message = line;
                    if (isMessageLine)
                        S5MessagesRepository.Add(new S5Message(message));
                }

                foreach (var item in S5MessagesRepository.S5Messages)
                {
                    Console.Write(item.Adress);
                    Console.Write("\t -> \t");
                    Console.WriteLine(AdressConverter.JoinAdress("DB170", AdressConverter.ConvertAdressS5toS7(item.Adress)));
                }
                Console.WriteLine(regCount);
                Console.WriteLine(condCount);

            }
        }
    }
}