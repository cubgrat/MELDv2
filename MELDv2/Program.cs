using MELDv2;
using MELDv2.Repositories;

var PATH = "C:\\Users\\vs\\Desktop\\MELD V2";


var MELDv2 = new Startup(PATH);
MELDv2.Run();


foreach (var item in MessagesRepository.MessagesWinCC) 
{
    Console.WriteLine(item.ToString());
}