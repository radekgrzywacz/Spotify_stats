using CsvHelper;
using CsvHelper.Configuration;

public class CustomLongConverter : CsvHelper.TypeConversion.Int64Converter
{
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        text = text.Replace("\"", "");
        text = text.Replace(",", string.Empty);
        return base.ConvertFromString(text, row, memberMapData);
    }
}

/*Map(m => m.id).Index(0).TypeConverter<CustomInt32Conventer>();
        Map(m => m.artistName).Index(1);
        Map(m => m.leadStreams).Index(2).TypeConverter<CustomLongConverter>();
        Map(m => m.feats).Index(3).TypeConverter<CustomLongConverter>();
        Map(m => m.tracks).Index(4);
        Map(m => m.oneBillion).Index(5);
        Map(m => m.houndredMillions).Index(6);
        Map(m => m.lastUpdated).Index(7).TypeConverterOption.Format("dd.MM.yy");*/