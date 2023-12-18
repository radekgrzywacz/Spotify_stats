using System.Globalization;
using System.Reflection;
using CsvHelper;
using CsvHelper.Configuration;

namespace PK3_project;

public class StatisticsPrinter
{
    public void PrintTheMostPopularArtist(List<Artist> artists)
    {
        int bestArtistIndex = 0;
        long maxStreams = 0;
        foreach (var artist in artists)
        {
            if (artist.leadStreams > maxStreams)
            {
                maxStreams = artist.leadStreams;
                bestArtistIndex = artists.IndexOf(artist);
            }
        }

        Console.WriteLine($"Best artist: {artists[bestArtistIndex].artistName}, " +
                          $"lead streams: {artists[bestArtistIndex].leadStreams}");
    }


    public void SortByProperty(List<Artist> artists, string propName)
    {
        
        string originalPropName = propName;
        if (propName == "")
        {
            originalPropName = "id";
        }
        else
        {
            originalPropName = char.ToLower(propName[0]) + propName.Substring(1).Replace(" ", ""); 
        }
        
        List<Artist> sortedListy =
            artists.OrderBy(x => typeof(Artist).GetProperty(originalPropName).GetValue(x, null)).ToList();

        using (var writer =
               new StreamWriter(
                   "/Users/radek/RiderProjects/4c668c11-gr03-repo/Projekt/PK3_project/PK3_project/sorted_data.csv"))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(sortedListy);
        }
        
        Console.WriteLine("Your list was sorted and written into a sorted_data.csv file.");

    }

    public void CalculateMinMax(List<Artist> artists, string propName)
    {
        string originalPropName = propName;
        if (propName == "")
        {
            originalPropName = "id";
        }
        else
        {
        originalPropName = char.ToLower(propName[0]) + propName.Substring(1).Replace(" ", ""); 
        }
        
        List<Artist> sortedListy =
            artists.OrderByDescending(x => typeof(Artist).GetProperty(originalPropName).GetValue(x, null)).ToList();

        var value1 = typeof(Artist).GetProperty(originalPropName).GetValue(artists.Last());
        var value2 = typeof(Artist).GetProperty(originalPropName).GetValue(artists.First());


        long value1Long = Convert.ToInt64(value1);
        long value2Long = Convert.ToInt64(value2);
        string formattedMin;
        string formattedMax;
        if (value1Long > value2Long)
        { 
           formattedMin =string.Format("{0:N0}", value2);
           formattedMax = string.Format("{0:N0}", value1);
        }
        else
        {
            formattedMin =string.Format("{0:N0}", value1);
            formattedMax = string.Format("{0:N0}", value2);
        }

       

        Console.WriteLine(
            $"Minimal value of {propName} is {formattedMin}, maximum value of {propName} is {formattedMax}");
    }

    public void CalculateAverage(List<Artist> artists, string propName)
    {
        string originalPropName = propName;
        if (propName == "")
        {
            originalPropName = "id";
        }
        else
        {
            originalPropName = char.ToLower(propName[0]) + propName.Substring(1).Replace(" ", ""); 
        }
        
        long sum = 0;
        for (int i = 0; i < artists.Count(); i++)
        {
            if (typeof(Artist).GetProperty(originalPropName).GetValue(artists[i]) != typeof(string) && 
                typeof(Artist).GetProperty(originalPropName).GetValue(artists[i]) != typeof(DateTime))
            {
                sum += (long)typeof(Artist).GetProperty(originalPropName).GetValue(artists[i]);
            }
            else
            {
                Console.WriteLine("Chosen property is not a number");
                break;
            }
        }

        var average = sum / artists.Count;

        var formattedAvg = string.Format("{0:N0}", average);
        
        Console.WriteLine($"Average value of property named {propName} is: {formattedAvg}");
    }
}