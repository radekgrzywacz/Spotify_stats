using CsvHelper;
using CsvHelper.Configuration;

namespace PK3_project.CsvWork;

public class CustomEmptyFieldConventer : CsvHelper.TypeConversion.StringConverter
{
    public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        if (string.IsNullOrEmpty(text))
            return null;
        else
            return base.ConvertFromString(text, row, memberMapData);
    }
}