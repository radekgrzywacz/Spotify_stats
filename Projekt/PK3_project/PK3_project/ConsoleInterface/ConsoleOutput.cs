using System.Reflection;
using PK3_project.Classes;
using PK3_project.CsvWork;


namespace PK3_project.ConsoleInterface;

public class ConsoleOutput
{
    public void ViewStatistics(string filepath)
    {
        
        var reader = new Reader();
        var artists = reader.Read(filepath).ToList();

        var stats = new StatisticsPrinter();
        
        // On account of project requirements I assumed that every region will have equal amount of artist,
        // with no regarding to their real life origin

        var asia = new List<Artist>();
        var europe = new List<Artist>();
        var america = new List<Artist>();
        var africa = new List<Artist>();

        var quarter = artists.Count / 4;
        
        for (int i = 0; i < artists.Count; i++)
        {
            if (i < quarter)
            {
                asia.Add(artists[i]);
            } else if (i >= quarter && i < 2 * quarter)
            {
                europe.Add(artists[i]);
            }
            else if (i >= 2 * quarter && i < 3 * quarter)
            {
                america.Add(artists[i]);
            }
            else
            {
                africa.Add(artists[i]);
            }
        }
        
        

        int dataOrigin = 0;
        do
        {
            Console.WriteLine(
                "Where do you want the data from? \n 1. Asia, 2. Europe, 3. America, 4. Africa, 5. All data");
            try
            {
                dataOrigin = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("You have to enter some value");
            }
        } while (!(dataOrigin == 1 || dataOrigin == 2 || dataOrigin == 3 || dataOrigin == 4 || dataOrigin == 5));
        
        var origin = dataOrigin switch
        {
            1 => asia,
            2 => europe,
            3 => america,
            4 => africa,
            5 => artists
        };

        int statisticsOfChoice = 0;

        do
        {
            Console.WriteLine("Select what do you want to do:");
            Console.WriteLine("1. Check the most popular artist, 2. Sort the data by chosen property (ascending), " +
                              "3. Check minimum and maximum of chosen property, 4. Check average of chosen property, " +
                              "5. Check Spearman's correlation coefficient between two parameters");

            try
            {
                statisticsOfChoice = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("You have to enter some value");
            }
            
        } while (!(statisticsOfChoice == 1 || statisticsOfChoice == 2 || statisticsOfChoice == 3 || statisticsOfChoice == 4 
                   || statisticsOfChoice == 5 ));

        string property;
        bool validInput = false;
        do
        {
            switch (statisticsOfChoice)
            {
                case 1:
                    stats.PrintTheMostPopularArtist(origin);
                    validInput = true;
                    break;
                case 2:
                    property = ChoseProperty(filepath);
                    stats.SortByProperty(origin, property);
                    validInput = true;
                    break;
                case 3:
                    property = ChoseProperty(filepath);
                    stats.CalculateMinMax(origin, property);
                    validInput = true;
                    
                    break;
                case 4:
                    property = ChoseProperty(filepath);
                    stats.CalculateAverage(origin, property);
                    validInput = true;
                    break;
                case 5:
                    string property1 = null;
                    string property2 = null;
                    do
                    {
                        property1 = ChoseProperty(filepath);
                        property2 = ChoseProperty(filepath);
                    } while (property1 == "Artist Name" || property2 == "Artist Name");

                    stats.CalculateSpearman(origin, property1, property2);
                    validInput = true;
                    break;
                default:
                    Console.WriteLine("Wrong input, try again");
                    break;

            }
        } while (!validInput);


    }

    private string ChoseProperty(string filepath)
    { 
        var filepathAsArray = filepath.Split("/");
        var filename = filepathAsArray.Last();

        var reader = new Reader();
        var header = reader.GetHeader(filepath);
        int headerCounter = 1;
        
        Console.WriteLine($"Select data you want to use from {filename} file (enter a number of the chosen option):");
        foreach (string value in header)
        {
            if (value == string.Empty)
            {
                Console.Write($"{headerCounter}.Id, ");
                headerCounter++;
            }
            else if (value != header.Last())
            {
                Console.Write($"{headerCounter}.{value}, ");
                headerCounter++;
            }
            else
            {
                Console.Write($"{headerCounter}.{value} \n");
            }
        }

        int propertyOfChoiceIndex = 0;
        string propertyOfChoice;
        do
        {
            try
            {
                propertyOfChoiceIndex = Convert.ToInt32(Console.ReadLine());
                propertyOfChoice = header[propertyOfChoiceIndex - 1];
            }
            catch (FormatException)
            {
                propertyOfChoice = "Wrong format, insert again: ";
                Console.WriteLine(propertyOfChoice);
            }
            catch (NullReferenceException)
            {
                propertyOfChoice = "Value out of bounds, insert again: ";
                Console.WriteLine(propertyOfChoice);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw;
            }
        } while (propertyOfChoice == "Wrong value, insert again: ");



        return propertyOfChoice;
    }

    public void ListArtists(string filepath)
    {
        var reader = new Reader();
        var artists = reader.Read(filepath);

        var artistsNames = new List<string>();

        foreach (var artist in artists)
        {
            artistsNames.Add(artist.artistName);
        }

        foreach (var name in artistsNames)
        {
            Console.Write(name + ", ");
        }


    }

    public void Display(string filepath)
    {
        var console = new ConsoleOutput();
        var reader = new Reader();
        var artists = reader.Read(filepath).ToList();
        var stats = new StatisticsPrinter();
        var reporter = new Raporter(filepath, artists);
        
        Console.WriteLine("What do you want to do? Press proper key to move to the next section:\n1. View Spotify statistics," +
                          "2. Generate Report, 3. Edit songs list, 4. Check available artists.");
        var input = Console.ReadLine();
        bool validInput = false;
        do
        {
            switch (Convert.ToInt32(input))
            {
                case 1:
                    console.ViewStatistics(filepath);
                    validInput = true;
                    break;
                case 2:
                    reporter.GenerateRaport();
                    validInput = true;
                    break;
                case 3:
                    string songInput = null;
                    do
                    {
                        Console.WriteLine("Press 1 to add a song and 2 to remove one:");
                        songInput = Console.ReadLine();
                        if (songInput == "1")
                        {
                            stats.AddSongs(artists, filepath);
                        }
                        else if (songInput == "2")
                        {
                            stats.RemoveSongs(artists, filepath);
                        }
                    } while (!(songInput == "1" || songInput == "2"));
                    validInput = true;
                    break;
                case 4:
                    console.ListArtists(filepath);
                    validInput = true;
                    break;
                default:
                    Console.WriteLine("Wrong input, try again");
                    break;

            }
        } while (!validInput);
        
    }
}