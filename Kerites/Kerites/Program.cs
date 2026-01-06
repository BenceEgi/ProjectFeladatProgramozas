
namespace Kerites
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelekSzamolas stat = new TelekSzamolas("kerites.txt");
            //2. feladat
            Console.WriteLine("2. feladat");
            Console.WriteLine($"Az eladott telkek száma: {stat.TelkekSzama()}");

            // 3. feladat
            Console.WriteLine("\n3. feladat");

            Telek utolso = stat.UtolsoTelek();

            if (utolso.Oldal == 0)
            {
                Console.WriteLine("A páros oldalon adták el az utolsó telket.");
            }
            else
            {
                Console.WriteLine("A páratlan oldalon adták el az utolsó telket.");
            }

            Console.WriteLine($"Az utolsó telek házszáma: {utolso.Hazszam}");

            //4. feladat
            Console.WriteLine("\n4. feladat");
            int hazszam = stat.HazszamMellett();
            Console.WriteLine($"A szomszédossal egyezik a kerítés színe: {hazszam}");
        }
    }
}
