using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerites
{
    internal class TelekSzamolas
    {
        public TelekSzamolas(string fajlBe, string fajlKi)
        {
            FajlBe = fajlBe;
            FajlKi = fajlKi;
            Telkek = Beolvas();
        }

        public string FajlBe { get; set; }
        public string FajlKi { get; set; }
        public List<Telek> Telkek { get; private set; }

        //1. Feladat
        public List<Telek> Beolvas()
        {
            List<Telek> telkek = new List<Telek>();
            StreamReader srBe = new StreamReader(FajlBe);


            while (!srBe.EndOfStream)
            {
                string sor = srBe.ReadLine();
                if (string.IsNullOrWhiteSpace(sor))
                    continue;

                string[] telekReszei = sor.Split(' ');

                Telek telek = new Telek();
                telek.Oldal = int.Parse(telekReszei[0]);
                telek.Szelesseg = int.Parse(telekReszei[1]);
                telek.Kerites = telekReszei[2];
                
                telkek.Add(telek);
            }
            srBe.Close();
            return telkek;
        }

        public int TelkekSzama()
        {
            return Telkek.Count;
        }
    }
}