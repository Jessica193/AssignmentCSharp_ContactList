using BusinessLibrary.Interfaces;
using BusinessLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.Console_MainApp.Dialogs;
using Presentation.Console_MainApp.Interfaces;

IHost host = Host.CreateDefaultBuilder()
    .ConfigureServices (services =>
    {
        services.AddSingleton<IFileService, FileService>();  
        services.AddSingleton<IContactService, ContactService>();
        services.AddSingleton<IMenuDialog, MenuDialog>();
    })
    .Build ();


using var scope = host.Services.CreateScope();
var menuDialogs = scope.ServiceProvider.GetRequiredService<IMenuDialog>();

menuDialogs.RunProgram();







