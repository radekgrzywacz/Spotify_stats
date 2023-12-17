using PK3_project.CsvWork;

namespace PK3_project;

public class Program
{
    public static void Main(string[] args)
    {

        const string filepath =
            "/Users/radek/RiderProjects/4c668c11-gr03-repo/Projekt/PK3_project/PK3_project/spotify_artist_data.csv";
        
        
        var reader = new Reader();
        var artists = reader.Read(filepath).ToList();

        var stats = new StatisticsPrinter();
        
        stats.PrintTheMostPopularArtist(artists);

        stats.SortByProperty(artists, "leadStreams");
        
        stats.CalculateMinMax(artists, "leadStreams" );
        
        stats.CalculateAverage(artists,"leadStreams" );

    }
}