using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace berek11_19
{
    internal class Ber
    {
        //Név;Neme;Részleg;Belépés;Bér

        public string Nev { get; set; }
        public string Nem { get; set; }
        public string Reszlet { get; set; }
        public int Belepes { get; set; }
        public int Fizetes { get; set; }
        public Ber(string sor) 
        {
            var s = sor.Split(';');
            Nev = s[0];
            Nem = s[1];
            Reszlet = s[2];
            Belepes = int.Parse(s[3]);
            Fizetes = int.Parse(s[4]);
        }
    }
}
