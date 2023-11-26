using CsvHelper;
using CsvHelper.Configuration;

public class CustomLongConverter : CsvHelper.TypeConversion.Int64Converter
{
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        // Remove commas from the string before converting to Int64.
        text = text.Replace(",", string.Empty);
        return base.ConvertFromString(text, row, memberMapData);
    }
}