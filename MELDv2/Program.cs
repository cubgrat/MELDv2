using LatinToCyrilicConverterRUS;
using MELDv2.Repositories;
using System.Text.RegularExpressions;

namespace MELDv2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Startup("C:\\Users\\vs\\Desktop\\MELD V2").Run();

            foreach (var item in TagsRepository.Tags)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}