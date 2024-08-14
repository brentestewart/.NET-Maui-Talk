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
        builder.Services.AddSingleton<VillainDetailsPage>();
        
        builder.Services.AddSingleton<VillainsViewModel>();
        builder.Services.AddSingleton<VillainDetailsViewModel>();
        
        builder.Services.AddSingleton<VillainService>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
