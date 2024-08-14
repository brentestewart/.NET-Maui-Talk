using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LairTracker.Models;
using System.Diagnostics;

namespace LairTracker.ViewModels;
[QueryProperty("Villain", "Villain")]
public partial class VillainDetailsViewModel(IGeolocation geolocation, IMap map) : BaseViewModel
{
    [ObservableProperty]
    Villain villain;

    [ObservableProperty]
    string distanceInMiles;

    [RelayCommand]
    async Task GetDistanceInMiles()
    {
        if(Villain is null)
        {
            return;
        }   
        try
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            if (location is null)
            {
                location = await Geolocation.GetLocationAsync(
                    new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)
                    });

                if (location is null)
                {
                    return;
                }
            }

            var distance = location.CalculateDistance(Villain.LairLatitude, Villain.LairLongitude, DistanceUnits.Miles);
            DistanceInMiles = $"{distance:0.0} miles";
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error", "Unable to get distance", "OK");
        }
    }

    public IGeolocation Geolocation { get; } = geolocation;
    public IMap Map { get; } = map;

    [RelayCommand]
    async Task ShowLairOnMap()
    {
        try
        {
            await Map.OpenAsync(Villain.LairLatitude, Villain.LairLongitude, new MapLaunchOptions
            {
                Name = Villain.Name,
                NavigationMode = NavigationMode.None
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error", "Unable to show lair on map", "OK");  
        }
    }
}
