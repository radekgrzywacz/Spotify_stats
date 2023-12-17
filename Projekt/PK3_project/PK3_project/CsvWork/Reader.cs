using System.Globalization;
using Microsoft.VisualBasic.FileIO;


namespace PK3_project.CsvWork;

public class Reader 
{
    private long ParseLong(string input)
    {
        string newLong = input.Replace(",", "");

        return long.Parse(newLong);
    }
    
    private int ParseInt(string input)
    {
        string newInt = input.Replace(",", "");

        return int.Parse(newInt);
    }
    
    
    public IEnumerable<Artist> Read(string filepath)
    {
        var logger = new Logger();
        
        using (TextFieldParser parser = new TextFieldParser(filepath))
        {
            parser.Delimiters = new string[] { "," };
            parser.HasFieldsEnclosedInQuotes = true;

            // Skip header line
            parser.ReadLine();

            int lineCounter = 1;
            while (!parser.EndOfData)
            {
                
                string[] fields = parser.ReadFields();
                Artist artist = null;
                try
                {
                    artist = new Artist
                    {
                        id = int.Parse(fields[0]),
                        artistName = fields[1],
                        leadStreams = ParseLong(fields[2]),
                        feats = ParseLong(fields[3]),
                        tracks = ParseInt(fields[4]),
                        oneBillion = int.Parse(fields[5]),
                        houndredMillions = int.Parse(fields[6]),
                        lastUpdated = DateTime.ParseExact(fields[7], "dd.MM.yy", CultureInfo.InvariantCulture)
                    };
                }
                catch (Exception ex)
                {
                    var message = $"Error in deserializing line {lineCounter}: {ex.Message}";
                    logger.Log(message);
                }

                if (artist != null)
                {
                    yield return artist;
                }

                lineCounter++;
            }

        }
    }
    
}
