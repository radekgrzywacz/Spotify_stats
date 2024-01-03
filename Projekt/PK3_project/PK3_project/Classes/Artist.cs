using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration.Attributes;

namespace PK3_project;

public class Artist
{
    public int id { get; set; }

    public string artistName { get; set; }

    public long leadStreams { get; set; }

    public long feats { get; set; }

    public int tracks { get; set; }

    public int oneBillion { get; set; }

    public int houndredMillions { get; set; }

    public DateTime lastUpdated { get; set; }

    public List<string> songs { get; set; }

}