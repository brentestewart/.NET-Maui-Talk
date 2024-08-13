namespace LairTracker.Models;
public class Villain
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string Affiliation { get; set; } = "Unknown";
    public string Details { get; set; } = "Unknown";
    public string SecretIdentity { get; set; } = "Unknown";
    public double LairLongitude { get; set; }
    public double LairLatitude { get; set; }
    public string LairLocation { get; set; } = "Unknown";
    public string ImageUrl { get; set; } = "./images/dotnet_bot.png";
}
