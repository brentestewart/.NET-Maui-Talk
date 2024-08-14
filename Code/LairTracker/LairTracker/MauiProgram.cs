using LairTracker.Services;
using LairTracker.ViewModels;
using LairTracker.Views;
using Microsoft.Extensions.Logging;

namespace LairTracker;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<VillainsPage>();
        builder.Services.AddTransient<VillainDetailsPage>();
        
        builder.Services.AddSingleton<VillainsViewModel>();
        builder.Services.AddTransient<VillainDetailsViewModel>();
        
        builder.Services.AddSingleton<VillainService>();
        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
        builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
        builder.Services.AddSingleton<IMap>(Map.Default);

#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
