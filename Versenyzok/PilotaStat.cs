namespace Versenyzok;

public class PilotaStat
{
    public List<Pilota> Pilotak { get; private set; }
    private string File;
    
    public PilotaStat(string file)
    {
        File = file;
        Pilotak = new();
        ReadIn();
    }

    private void ReadIn()
    {
        StreamReader stream = new StreamReader(File);
        _ = stream.ReadLine(); //Skip header
        while (!stream.EndOfStream)
        {
            string line = stream.ReadLine();
            if (string.IsNullOrEmpty(line)) continue;
            string[] data = line.Split(';');
            
            var date = data[1].Split('.').Select(Int32.Parse).ToArray();
            bool success = Int32.TryParse(data[3], out var result);
            Pilota newPilot = new Pilota
            {
                Name = data[0],
                BornDate = new DateTime(date[0], date[1], date[2]),
                Nationality = data[2],
                RaceNumber = success ? result : null
            };
            Pilotak.Add(newPilot);
        }
    }

    public void Pilot21()
    {
        foreach (var pilota in Pilotak)
        {
            if (pilota.BornDate >= new DateTime(1901, 1, 1)) continue;
            string message = $"{pilota.Name} ({pilota.BornDate.Year}. {pilota.BornDate.Month}. {pilota.BornDate.Day})";
            Console.WriteLine($"\t{message}");
        }
    }

    public Pilota SmallestRaceNumber()
    {
        return Pilotak
            .Where(p => p.RaceNumber is not null)
            .OrderBy(p => p.RaceNumber)
            .ToArray()[0];
    }

    public int?[] MultiRaceNumbers()
    {
        return Pilotak
            .GroupBy(p => p.RaceNumber)
            .Where(p => p.Key is not null && p.Count() > 1)
            .Select(p => p.Key)
            .ToArray();
    }
}