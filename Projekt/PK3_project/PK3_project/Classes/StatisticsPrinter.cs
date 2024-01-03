using System.Collections;
using System.Globalization;
using CsvHelper;

namespace PK3_project.Classes;

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
        
        string originalPropName;
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
            csv.WriteRecords(sortedListy.Select(artist => new
            {
                artist.id,
                artist.artistName,
                artist.leadStreams,
                artist.feats,
                artist.tracks,
                artist.oneBillion,
                artist.houndredMillions,
                artist.lastUpdated,
                Songs = string.Join(",", artist.songs)
            }));
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

    public List<double> RankSpearman(List<Artist> artists, string propName)
    {
        string originalPropName;
        if (propName == "")
        {
            originalPropName = "id";
        }
        else
        {
            originalPropName = char.ToLower(propName[0]) + propName.Substring(1).Replace(" ", ""); 
        }

        int N = artists.Count();


        var element = typeof(Artist).GetProperty(originalPropName).GetValue(artists.First());
        Type elementType = element.GetType();

        var propertyInArray = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(elementType));
        
        foreach (var artist in artists)
        {
            var propertyValue = artist?.GetType().GetProperty(originalPropName)?.GetValue(artist);
            propertyInArray.Add(propertyValue);
        }
        
        

        List<double> Rank_X = new List<double>();

        for (int i = 0; i < N; i++)
        {
            Rank_X.Add(0);
            int r = 1, s = 1;

            //Count no of smaller elements
            // in 0 to i-1
            if (elementType == typeof(DateTime))
            {
                DateTime dateTimeI = (DateTime)propertyInArray[i];
                DateTime dateTimeJ;
                for (int j = 0; j < i; j++)
                {
                    dateTimeJ = (DateTime)propertyInArray[j];
                    if (dateTimeJ < dateTimeI)
                        r++;
                    if (dateTimeJ == dateTimeI)
                        s++;
                }


                // Count no of smaller elements
                // in i+1 to N-1
                for (int j = i + 1; j < N; j++)
                {
                    dateTimeJ = (DateTime)propertyInArray[j];
                    if (dateTimeJ < dateTimeI)
                        r++;
                    if (dateTimeJ == dateTimeI)
                        s++;
                }

                // Use Fractional Rank formula
                // fractional_rank = r + (n-1)/2
                Rank_X[i] = (r + (s - 1) * 0.5);
            }
            else if(elementType == typeof(long))
            {
                for (int j = 0; j < i; j++)
                {
                    if ((long) propertyInArray[j] < (long) propertyInArray[i])
                        r++;
                    if (propertyInArray[j] == propertyInArray[i])
                        s++;
                }

                // Count no of smaller elements
                // in i+1 to N-1
                for (int j = i + 1; j < N; j++) {
                    if ((long) propertyInArray[j] < (long) propertyInArray[i])
                        r++;
                    if (propertyInArray[j] == propertyInArray[i])
                        s++;
                }
 
                // Use Fractional Rank formula
                // fractional_rank = r + (n-1)/2
                Rank_X[i] = (r + (s - 1) * 0.5);
            }
            else
            {
                for (int j = 0; j < i; j++)
                {
                    if ((int) propertyInArray[j] < (int) propertyInArray[i])
                        r++;
                    if (propertyInArray[j] == propertyInArray[i])
                        s++;
                }

                // Count no of smaller elements
                // in i+1 to N-1
                for (int j = i + 1; j < N; j++) {
                    if ((int) propertyInArray[j] < (int) propertyInArray[i])
                        r++;
                    if (propertyInArray[j] == propertyInArray[i])
                        s++;
                }
 
                // Use Fractional Rank formula
                // fractional_rank = r + (n-1)/2
                Rank_X[i] = (r + (s - 1) * 0.5);
            }
        }

        // Return Rank Vector
        return Rank_X;
    }

    public double SpearmansCoefficient(List<double> X, List<double> Y)
    {
        int n = X.Count;
        double sum_X = 0, sum_Y = 0, sum_XY = 0;
        double squareSum_X = 0, squareSum_Y = 0;
 
        for (int i = 0; i < n; i++) {
            // sum of elements of array X.
            sum_X = sum_X + X[i];
 
            // sum of elements of array Y.
            sum_Y = sum_Y + Y[i];
 
            // sum of X[i] * Y[i].
            sum_XY = sum_XY + X[i] * Y[i];
 
            // sum of square of array elements.
            squareSum_X = squareSum_X + X[i] * X[i];
            squareSum_Y = squareSum_Y + Y[i] * Y[i];
        }
 
        // use formula for calculating
        // correlation coefficient.
        double corr
            = (n * sum_XY - sum_X * sum_Y)
              / Math.Sqrt(
                  (n * squareSum_X - sum_X * sum_X)
                  * (n * squareSum_Y - sum_Y * sum_Y));
 
        return corr;
    }

    public void CalculateSpearman(List<Artist> artists, string firstProperty, string secondProperty)
    {
        var X = RankSpearman(artists, firstProperty);
        var Y = RankSpearman(artists, secondProperty);

        var spearman = SpearmansCoefficient(X, Y);
        
        Console.WriteLine($"Spearman's correlation coefficient between chosen properties is: {spearman}.");
    }
    
    public void AddSongs(List<Artist> artists, string filepath)
    {
        Console.WriteLine("Insert name of an artist you want to edit: ");
        var name = Console.ReadLine();

        bool isValid = false;
        do
        {
            foreach (var artist in artists)
            {
                if (name == artist.artistName)
                {
                    isValid = true;
                    string song = null;
                    do
                    {
                        Console.WriteLine("Insert a name of a song you want to add: ");
                        song = Console.ReadLine();
                    } while (string.IsNullOrEmpty(song));

                    if (artist.songs.Contains(song))
                    {
                        break;
                    }
                    artist.songs.Add(song);
                    break;
                }
            }
        } while (isValid = false);
        
        using (var writer = new StreamWriter(filepath))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(artists.Select(artist => new
            {
                artist.id,
                artist.artistName,
                artist.leadStreams,
                artist.feats,
                artist.tracks,
                artist.oneBillion,
                artist.houndredMillions,
                artist.lastUpdated,
                Songs = string.Join(",", artist.songs)
            }));
        }
    }
    
    public void RemoveSongs(List<Artist> artists, string filepath)
    {
        Console.WriteLine("Insert name of an artist you want to edit: ");
        var name = Console.ReadLine();

        bool isValid = false;
        do
        {
            foreach (var artist in artists)
            {
                if (name == artist.artistName)
                {
                    isValid = true;
                    string song = null;
                    do
                    {
                        Console.WriteLine("Insert a name of a song you want to remove: ");
                        song = Console.ReadLine();
                    } while (!artist.songs.Contains(song));

                    artist.songs.Remove(song);
                    break;
                }
            }
        } while (isValid = false);
        
        using (var writer = new StreamWriter(filepath))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(artists.Select(artist => new
            {
                artist.id,
                artist.artistName,
                artist.leadStreams,
                artist.feats,
                artist.tracks,
                artist.oneBillion,
                artist.houndredMillions,
                artist.lastUpdated,
                Songs = string.Join(",", artist.songs)
            }));
        }
    }
}
