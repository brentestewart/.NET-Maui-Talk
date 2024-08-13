using LairTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LairTracker.Services;
public class VillainService
{
    private List<Villain> Villains { get; set; } = new List<Villain>();

    public async Task<List<Villain>> GetVillains()
    {
        await Task.Delay(2000);

        if (Villains.Count != 0)
        {
            return Villains;
        }

        using var stream = await FileSystem.OpenAppPackageFileAsync("villains.json");
        using var reader = new StreamReader(stream);
        var villainFileContent = await reader.ReadToEndAsync();
        var villains = JsonSerializer.Deserialize<List<Villain>>(villainFileContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        if (villains == null)
        {
            throw new Exception("Failed to load villains");
        }

        Villains = villains.OrderBy(v => v.Name).ToList();

        return Villains;
    }
}
