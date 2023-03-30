using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MELDv2
{
    static public class AdressConverter
    {
        //SWn to DWn like S 0.0 -> D0.8 -> DB0.D0.8
        static public string ConvertAdressS5toS7(string db, string s5adress)
        {
            var adr = s5adress?.Split(new char[] { ' ' })?[1] ?? "0.0";
            var adrByteBit = adr.Split(new char[] { '.' });
            int adrByte = int.Parse(adrByteBit[0]);
            int adrBit = int.Parse(adrByteBit[1]);

            int newAdrByte = (adrByte / 2) + 1;
            int newAdrBit;
            if (adrByte % 2 == 0)
                newAdrBit = adrBit + 8;
            else
                newAdrBit = adrBit;

            var adress = String.Format($"D{newAdrByte}.{newAdrBit}");
            return JoinAdress(db, adress);

        }
        static private string JoinAdress(string DB, string adress) =>
            String.Format($"{DB}.{adress}");
        
    }

}
