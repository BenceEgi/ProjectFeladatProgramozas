using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerites
{
    internal class TelekSzamolas
    {
        public TelekSzamolas(string fajlBe)
        {
            FajlBe = fajlBe;
            Telkek = Beolvas();
        }

        public string FajlBe { get; set; }
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
                telek.Hazszam = int.Parse(telekReszei[1]);
                telek.Kerites = telekReszei[2];
                
                telkek.Add(telek);
            }
            srBe.Close();
            return telkek;
        }

        //2. feladat
        public int TelkekSzama()
        {
            return Telkek.Count;
        }

        //3. feladat
        public Telek UtolsoTelek()
        {
           return Telkek[Telkek.Count - 1];
        }

        //4.feladat
        public int HazszamMellett()
        {
            for(int i = 0; i < Telkek.Count; i++)
            {
                if (Telkek[i].Oldal == 1 && Telkek[i].Kerites == Telkek[i + 1].Kerites)
                {   
                     return i+1;
                }
                
            }
            return -1;
        }
    }
}