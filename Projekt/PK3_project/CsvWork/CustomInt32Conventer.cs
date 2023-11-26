using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace PK3_project.CsvWork;

public class CustomInt32Converter : Int32Converter
{
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        text = text.Replace(",", string.Empty);
        return base.ConvertFromString(text, row, memberMapData);
    }
}