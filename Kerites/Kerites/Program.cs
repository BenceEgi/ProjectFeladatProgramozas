
namespace Kerites
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelekSzamolas stat = new TelekSzamolas("kerites.txt");
            //2. feladat
            Console.WriteLine($"Az eladott telkek száma: {stat.TelkekSzama()}");
        }
    }
}
