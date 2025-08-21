using Microsoft.Extensions.Logging;
using Quiz_Point_Counter.ViewModel;

namespace Quiz_Point_Counter
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("SANTELLO.ttf", "Santelo");
                });

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<PlayerList>();

            builder.Services.AddTransient<PointCountPage>();
            builder.Services.AddTransient<PointCount>();

            builder.Services.AddTransient<LeaderboardsPage>();
            builder.Services.AddTransient<Leaderboards>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
