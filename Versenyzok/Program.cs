namespace Versenyzok;

class Program
{
    static void Main(string[] args)
    {
        //2. feladat
        PilotaStat pilotaStat = new PilotaStat("pilotak.csv");
        
        //3. feladat
        Console.WriteLine("3. feladat\nPilotak darabszama: " + pilotaStat.Pilotak.Count);
        Console.WriteLine();
        
        //4. feladat
        Console.WriteLine("4. feladat\nUtolso pilota: " + pilotaStat.Pilotak[^1].Name);
        Console.WriteLine();
        
        //5. feladat
        Console.WriteLine("5. feladat\nXIX. szazadi pilotak: ");
        pilotaStat.Pilot21();
        Console.WriteLine();
        
        //6. feladat
        Console.WriteLine($"6. feladat\nXIX. szazadi pilotak: {pilotaStat.SmallestRaceNumber().Nationality}");
        
        //7. feladat
        Console.Write($"\n7. feladat\nTobbszor elofordulo rajtszamok: ");
        int?[] result = pilotaStat.MultiRaceNumbers();
        foreach (var num in result)
            Console.Write(num + ", ");
    }
}