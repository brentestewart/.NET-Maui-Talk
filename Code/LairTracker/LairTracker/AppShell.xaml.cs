using LairTracker.Views;

namespace LairTracker;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(VillainDetailsPage), typeof(VillainDetailsPage));
    }
}
