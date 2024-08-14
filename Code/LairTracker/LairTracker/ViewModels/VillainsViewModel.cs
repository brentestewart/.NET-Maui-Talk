using CommunityToolkit.Mvvm.Input;
using LairTracker.Models;
using LairTracker.Services;
using LairTracker.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace LairTracker.ViewModels;

public partial class VillainsViewModel : BaseViewModel
{
    public VillainService VillainService { get; }
    public IConnectivity Connectivity { get; }
    public ObservableCollection<Villain> Villains { get; } = new();

    public VillainsViewModel(VillainService villainService, IConnectivity connectivity)
    {
        VillainService = villainService;
        Connectivity = connectivity;
        Title = "Villains List";
    }

    [RelayCommand]
    async Task LoadVillains()
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("No Connection", "Please check your internet connection", "OK");
                return;
            }

            IsBusy = true;
            var villains = await VillainService.GetVillains();
            Villains.Clear();
            foreach (var villain in villains)
            {
                Villains.Add(villain);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error", "Unable to load villains", "OK");
        }    
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task GoToDetails(Villain villain)
    {
        if(villain == null)
        {
            return;
        }

        await Shell.Current.GoToAsync($"{nameof(VillainDetailsPage)}", true,
            new Dictionary<string,object>
            {
                { "Villain", villain }
            });
    }
}
