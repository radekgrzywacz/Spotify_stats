using CsvHelper;
using PK3_project.CsvWork;

namespace PK3_project;

public class MainProject
{
    public static void Main(string[] args)
    {
        string filepath = "/Users/radek/RiderProjects/4c668c11-gr03-repo/Projekt/PK3_project/spotify_artist_data.csv";
        
        var reader = new Reader();
        
        List<Artist> records = reader.read(filepath);

        foreach (var artist in records)
        {
            Console.WriteLine(artist.id + artist.artistName + artist.leadStreams + " " + artist.feats+ " " + artist.tracks + " " +
                              artist.houndredMillions + " " + artist.oneBillion + " " +artist.lastUpdated);
        }



    }
}