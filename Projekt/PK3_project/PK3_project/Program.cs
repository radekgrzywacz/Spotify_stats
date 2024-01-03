using PK3_project.Classes;
using PK3_project.ConsoleInterface;
using PK3_project.CsvWork;

namespace PK3_project;

public class Program
{
    public static void Main(string[] args)
    {

        const string filepath =
            "/Users/radek/RiderProjects/4c668c11-gr03-repo/Projekt/PK3_project/PK3_project/spotify_artist_data.csv";

        var console = new ConsoleOutput();
        var stats = new StatisticsPrinter();
        string input = null;

        do
        {
            console.Display(filepath);
            Console.WriteLine("\nInsert q to quit the program, anything else to choose again.");
            input = Console.ReadLine();
        } while (input != "q");
        
        
        
    }
}