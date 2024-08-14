using CommunityToolkit.Mvvm.ComponentModel;
using LairTracker.Models;

namespace LairTracker.ViewModels;
[QueryProperty("Villain", "Villain")]
public partial class VillainDetailsViewModel : BaseViewModel
{
    [ObservableProperty]
    Villain villain;
}
