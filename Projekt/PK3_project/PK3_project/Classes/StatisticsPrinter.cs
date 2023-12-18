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
        
        propName = char.ToLower(propName[0]) + propName.Substring(1).Replace(" ", ""); 
        //if(propName == "")
        
        List<Artist> sortedListy =
            artists.OrderByDescending(x => typeof(Artist).GetProperty(propName).GetValue(x, null)).ToList();

        using (var writer =
               new StreamWriter(
                   "/Users/radek/RiderProjects/4c668c11-gr03-repo/Projekt/PK3_project/PK3_project/sorted_data.csv"))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(sortedListy);
        }

    }

    public void CalculateMinMax(List<Artist> artists, string propName)
    {
        List<Artist> sortedListy =
            artists.OrderByDescending(x => typeof(Artist).GetProperty(propName).GetValue(x, null)).ToList();

        var min = typeof(Artist).GetProperty(propName).GetValue(artists.Last());
        var max = typeof(Artist).GetProperty(propName).GetValue(artists.First());

        string formattedMin = string.Format("{0:N0}", min);
        string formattedMax = string.Format("{0:N0}", max);

        Console.WriteLine(
            $"Minimal value of {propName} is {formattedMin}, maximum value of {propName} is {formattedMax}");
    }

    public void CalculateAverage(List<Artist> artists, string propName)
    {
        long sum = 0;
        for (int i = 0; i < artists.Count(); i++)
        {
            if (typeof(Artist).GetProperty(propName).GetValue(artists[i]) != typeof(string) && 
                typeof(Artist).GetProperty(propName).GetValue(artists[i]) != typeof(DateTime))
            {
                sum += (long)typeof(Artist).GetProperty(propName).GetValue(artists[i]);
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