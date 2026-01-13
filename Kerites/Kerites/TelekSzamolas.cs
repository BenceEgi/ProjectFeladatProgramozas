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
            int counterParos = 0;
            int counterParatlan = 0;

            while (!srBe.EndOfStream)
            {
                string? sor = srBe.ReadLine();
                if (string.IsNullOrWhiteSpace(sor))
                    continue;

                string[] telekReszei = sor.Split(' ');

                Telek telek = new Telek();
                telek.Oldal = int.Parse(telekReszei[0]);
                telek.Hossz = int.Parse(telekReszei[1]);
                telek.Kerites = telekReszei[2][0];
                if (telek.Oldal == 1)
                {
                    telek.Hazszam = telek.Oldal + counterParatlan;
                    counterParatlan+=2;
                }
                else
                {
                    counterParos+=2;
                    telek.Hazszam = telek.Oldal + counterParos;
                }

                telkek.Add(telek);
            }
            srBe.Close();
            return telkek;
        }

        //3. feladat
        public Telek UtolsoTelek()
        {
           return Telkek[Telkek.Count - 1];
        }

        //4.feladat
        public Telek? HazszamMellett()
        {
            Telek[] paratlanTelkek = Telkek.Where(x => x.Oldal == 1).ToArray();
            for (int i = 0; i < paratlanTelkek.Length - 1; i++)
            {
                if (paratlanTelkek[i].Kerites is not (':' or '#') && paratlanTelkek[i].Kerites == paratlanTelkek[i + 1].Kerites)
                    return paratlanTelkek[i];
            }
            return null;
        }
        
        //5. feladat
        public Telek? TelekLeker()
        {
            int hazszam;
            Console.WriteLine("Adj meg egy házszámot: ");
            do
            {
                _ = Int32.TryParse(Console.ReadLine(), out hazszam);
                if (hazszam == 0 || hazszam < 0) Console.WriteLine("Hibás adat!");
            } while (hazszam == 0 || hazszam < 0);
            
            foreach (var telek in Telkek)
                if (telek.Hazszam == hazszam) return telek;
            
            return null;
        }

        public string Szinlehetoseg(Telek telekBe)
        {
            string paletta = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var sor = Telkek.Where(x => x.Oldal == telekBe.Oldal).ToArray();
            int index = 0;
            for (int i = 0; i < sor.Length; i++)
                if (sor[i] == telekBe) index = i;
            
            var palArr = paletta
                .Where(x =>
                {
                    if (index == 0) return x != sor[index+1].Kerites && x != telekBe.Kerites;
                    if (index == sor.Length - 1) return x != sor[index-1].Kerites && x != telekBe.Kerites;
                    return x != telekBe.Kerites && x != sor[index-1].Kerites && x != sor[index+1].Kerites;
                })
                .ToArray();

            return palArr[0].ToString();
        }

        public void Kiir()
        {
            var arr = Telkek.Where(x => x.Oldal == 1).ToArray();
            StreamWriter strKi = new StreamWriter("utcakep.txt");
            foreach (var telek in arr)
            {
                strKi.Write($"{new string(telek.Kerites, telek.Hossz)}");
            }
            strKi.Write("\n");
            foreach (var telek in arr)
            {
                string hazszam = telek.Hazszam.ToString();
                strKi.Write($"{hazszam}{new string(' ', telek.Hossz - hazszam.Length)}");
            }
            strKi.Close();
        }
    }
}