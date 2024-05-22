using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Plugin.Maui.Audio;
using TripExpenseManager.Data;
using TripExpenseManager.ViewModels;

namespace TripExpenseManager
{
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
                })
                .UseMauiCommunityToolkit();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton(AudioManager.Current);
            AddServices(builder.Services);
            return builder.Build();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddSingleton<AppViewModel>()
                .AddSingleton<MauiInterop>()
                .AddSingleton<AppState>();

            services.AddSingleton<DatabaseContext>()
                    .AddTransient<SeeDataService>();

            services.AddTransient<AuthService>().
                AddSingleton<TripsService>()
                .AddTransient<DropDownsService>();


        }
    }
}
