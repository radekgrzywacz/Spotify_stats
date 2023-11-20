using System.Globalization;
using CsvHelper;
using System.IO;
using System.Linq;

namespace PK3_project.CsvWork;

public class Reader 
{
    public void read(string filepath)
    {
        using var reader = new StreamReader(filepath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        var records = csv.GetRecords<Artist>().ToList();
    }
}