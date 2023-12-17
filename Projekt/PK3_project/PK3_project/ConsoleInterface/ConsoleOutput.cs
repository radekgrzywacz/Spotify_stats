using PK3_project.CsvWork;

namespace PK3_project.ConsoleInterface;

public class ConsoleOutput
{
    public void StartConsole(string filepath)
    {
        var reader = new Reader();
        var artists = reader.Read(filepath).ToList();
        
        // On account of project requirements I assumed that every region will have equal amount of artist,
        // with no regarding to their real life origin

        var asia = new List<Artist>();
        var europe = new List<Artist>();
        var america = new List<Artist>();
        var africa = new List<Artist>();

        var quarter = artists.Count / 4;

        for (int i = 0; i < artists.Count; i++)
        {
            if (i < quarter)
            {
                asia.Add(artists[i]);
            } else if (i >= quarter && i < 2 * quarter)
            {
                europe.Add(artists[i]);
            }
            else if (i >= 2 * quarter && i < 3 * quarter)
            {
                america.Add(artists[i]);
            }
            else
            {
                africa.Add(artists[i]);
            }
        }
        
        var filepathAsArray = filepath.Split("/");
        var filename = filepathAsArray.Last();

        var header = reader.GetHeader(filepath);
        int headerCounter = 1;
        
        Console.WriteLine($"Select data you want to know from {filename} file (enter a number of the chosen option):");
        foreach (string value in header)
        {
            if (value == string.Empty)
            {
                Console.Write($"{headerCounter}.Id, ");
                headerCounter++;
            }
            else if (value != header.Last())
            {
                Console.Write($"{headerCounter}.{value}, ");
                headerCounter++;
            }
            else
            {
                Console.Write($"{headerCounter}.{value} \n");
            }
        }

        int statOfChoice = Convert.ToInt32(Console.ReadLine());
        

    }
}