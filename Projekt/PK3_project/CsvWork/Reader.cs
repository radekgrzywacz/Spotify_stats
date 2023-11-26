using System.Globalization;
using CsvHelper;

namespace PK3_project.CsvWork;

public class Reader 
{
    public List<Artist> read(string filepath)
    {
        using var reader = new StreamReader(filepath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);


        csv.Context.RegisterClassMap<ArtistMap>();

       // csv.Read();

       List<Artist> result = csv.GetRecords<Artist>().ToList();


       return result;

       
    }
}