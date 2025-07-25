﻿using MauiVerter.ViewModels;
using Microsoft.Extensions.Logging;

namespace MauiVerter
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
                    fonts.AddFont("fontello.ttf", "Icons");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            ConfigureServices(builder.Services);

            return builder.Build();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MenuPageViewModel>();
            services.AddSingleton<ConverterPageViewModel>();
        }
    }
}
