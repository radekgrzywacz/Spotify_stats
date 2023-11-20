using CsvHelper;
using PK3_project.CsvWork;

namespace PK3_project;

public class MainProject
{
    public static void Main(string[] args)
    {
        string filepath = "/Users/radek/Desktop/studia/Rok 2/PK/spotify_artist_data.csv";
        
        var reader = new Reader();
        reader.read(filepath);
        
    }
}