using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MELDv2.Repositories
{
    public static class MessagesRepository
    {
        public static List<MessageWinCC> MessagesWinCC = new List<MessageWinCC>();
        public static void Add(MessageWinCC message) =>
            MessagesWinCC.Add(message);
    }
    public class MessageWinCC 
    {
        public MessageWinCC(int index, int @class, int type, string message, int s5Index, string tagName)
        {
            Index = index;
            Class = @class;
            Type = type;
            Message = message;
            S5Index = s5Index;
            TagName1 = tagName;
            TagName2 = tagName;
        }

        private int Index { get; set; }
        private int numX1 = 12;
        private int Class { get; set; }
        private int Type { get; set; }
        private string Filler1 = "0,0,0,0,0,0,0,0,0,0";
        private string Message { get; set; }
        private string Filler2 = " ";
        private int S5Index { get; set; }
        private string Filler3 = " ";
        private string Filler4 = "MXXX_S0.0";
        private string Filler5 = " , , , , , , , , , , , , , , ";
        private string TagName1 { get; set; }
        private int Filler6 = 0;
        private string TagName2 { get; set; }
        private string Filler7 = "0, ,0,0,0, ,0, , ,S5PMCNRM.NLL,0, ,0,0";


        public override string ToString() 
        {
            return Index + "," + numX1 + "," + Class + "," + Type + "," + Filler1 + "," + Message + "," + Filler2 + "," + S5Index + "," + Filler3 + "," + Filler4 
                + "," + Filler5 + "," + TagName1 + "," + Filler6 + "," + TagName2 + "," + Filler7;
            //return String.Format($"{Index},{Class},{Type},{Filler1},{Message},{Filler2},{S5Index},{Filler3},{Filler4},{Filler5},{TagName1},{Filler6},{TagName2},{Filler7}");
        }
    }
}
