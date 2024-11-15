// Program.cs

using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using AudioAnalysisGUI.Views;
using AudioAnalysisGUI.Services;
using AudioAnalysisGUI.Utilities;

namespace AudioAnalysisGUI;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        // Set up DI container
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        using var serviceProvider = serviceCollection.BuildServiceProvider();
        var mainForm = serviceProvider.GetRequiredService<MainForm>();
        Application.Run(mainForm);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Register services
        services.AddSingleton<IAtrAnalysisService, AtrAnalysisService>();

        // Register MainForm with dependencies
        services.AddTransient<MainForm>();
    }
}
