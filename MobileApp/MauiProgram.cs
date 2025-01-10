using BusinessLibrary.Interfaces;
using BusinessLibrary.Services;
using Microsoft.Extensions.Logging;
using MobileApp.Pages;
using MobileApp.ViewModels;

namespace MobileApp
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
                });


            builder.Services.AddTransient<ListViewModel>();
            builder.Services.AddTransient<ListPage>();

            builder.Services.AddTransient<AddViewModel>();
            builder.Services.AddTransient<AddPage>();

            builder.Services.AddTransient<EditViewModel>();
            builder.Services.AddTransient<EditPage>();


            builder.Services.AddSingleton<IContactService, ContactService>();
            builder.Services.AddSingleton<IFileService, FileService>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
