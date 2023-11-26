using System.Globalization;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using PK3_project.CsvWork;

namespace PK3_project;

public sealed class ArtistMap : ClassMap<Artist>
{
    public ArtistMap()
    {
        Map(m => m.id).Name(" ");
        Map(m => m.artistName).Name("Artist Name");
        Map(m => m.leadStreams).Name("Lead Streams").TypeConverter<CustomLongConverter>();
        Map(m => m.feats).Name("Feats").TypeConverter<CustomLongConverter>();
        Map(m => m.tracks).Name("Tracks");
        Map(m => m.oneBillion).Name("One Billion");
        Map(m => m.houndredMillions).Name("100 Million");
        Map(m => m.lastUpdated).Name("Last Updated").TypeConverterOption.Format("dd.MM.yy");
    }
}
