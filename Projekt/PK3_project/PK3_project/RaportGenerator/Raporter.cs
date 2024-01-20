namespace PK3_project;

public class Raporter : RaportBase
{
    public string inputFileName { get; set; }
    
    private string CurrentDirectory { get; set; }
   
    private string FileName { get; set; }
   
    private string FilePath { get; set; }

    public IEnumerable<Artist> artists;

    public Raporter (string inputFileName, IEnumerable<Artist> artists)
    {
        this.inputFileName = inputFileName;
        this.artists = artists;
        this.CurrentDirectory = Directory.GetCurrentDirectory();
        
    }

    public override void GenerateRaport()
    {
        string artistName = null;
        do
        {
            Console.WriteLine("Insert the name of an artist you want to generate report about: ");
            artistName = Console.ReadLine();
        } while (string.IsNullOrEmpty(artistName));

        var fileName = artistName;
        if (fileName.Contains(' '))
        {
            fileName = fileName.Replace(' ', '_');
        }
        this.FileName = $"Raport_{fileName}.txt";
        this.FilePath = this.CurrentDirectory + "/" + this.FileName;
        var artist = artists.FirstOrDefault(x => x.artistName == artistName);
        var f = new FileInfo(FilePath);
        if (artist == null)
        {
            Console.WriteLine($"Artist with name '{artistName}' not found.");
            return;
        }

        try
        {
            using (System.IO.StreamWriter w = System.IO.File.CreateText(this.FilePath))
            {
                w.Write($"Raport about {artistName}:");
                w.Write($"\rArtist: {artist.artistName}");
                w.Write($"\rBiggest number of streams: {artist.leadStreams.ToString("N0")}");
                w.Write($"\rFeats: {artist.feats.ToString("N0")}");
                w.Write($"\rTracks: {artist.tracks.ToString("N0")}");
                w.Write($"\rAmount of songs that gained streams over one billion: {artist.oneBillion.ToString("N0")}");
                w.Write($"\rAmount of songs that gained streams over one houndred millions: {artist.houndredMillions.ToString("N0")}");
                w.Write($"\rLast updated: {artist.lastUpdated}");
                if (artist.songs.Count > 0 && artist.songs[0] != "")
                {
                    w.Write("\rSongs:");
                    foreach (var song in artist.songs)
                    {
                        w.WriteLine($"\r    -{song}");
                    }
                }
                else
                {
                    w.Write("\rThis artist does not have any songs in data base.");
                }

                Console.WriteLine($"Your report was generated into the {CurrentDirectory} folder");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}