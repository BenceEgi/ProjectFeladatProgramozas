
namespace Kerites
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelekSzamolas stat = new TelekSzamolas("kerites.txt");
            stat.Telkek.ForEach(x => Console.WriteLine(x.Hazszam + " " + x.Oldal));
            
            //2. feladat
            Console.WriteLine("2. feladat");
            Console.WriteLine($"Az eladott telkek száma: {stat.Telkek.Count}");

            // 3. feladat
            Console.WriteLine("\n3. feladat");
            Telek utolso = stat.UtolsoTelek();
            Console.WriteLine($"{(utolso.Oldal == 0 ? "A páros oldalon adták el az utolsó telket." : "A páratlan oldalon adták el az utolsó telket.")}");
            Console.WriteLine($"Az utolsó telek házszáma: {utolso.Hazszam}");

            //4. feladat
            Console.WriteLine("\n4. feladat");
            Telek hazszam = stat.HazszamMellett();
            Console.WriteLine($"A szomszédossal egyezik a kerítés színe: {hazszam.Hazszam}");
            
            //5 feladat
            Telek? valTel = stat.TelekLeker();
            Console.WriteLine($"A kerítés színe / állapota: {valTel.Kerites}");
            Console.WriteLine(stat.Szinlehetoseg(valTel));
            
            //6 feladat
            stat.Kiir();
        }
    }
}
