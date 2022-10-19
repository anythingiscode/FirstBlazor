using BlazorDesktopApp1.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ElectronNET.API;
using ElectronNET.API.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.WebHost.UseElectron(args);              //Modificaciones aportadas para configurar Electron.Net  * * Tambien se añaden las using


        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddSingleton<WeatherForecastService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        app.Run();
    }

    //Modificaciones aportadas para configurar Electron.Net
    async void CreateWindow()
    {
        var window = await Electron.WindowManager.CreateWindowAsync(
            new BrowserWindowOptions
            {
                Width = 1550,
                Height = 900,
                BackgroundColor = "black",
                Frame = false,
                MinWidth = 800,
                MinHeight = 500
            }
        );
        window.RemoveMenu();
        window.OnClosed += () =>
        {
            Electron.App.Quit();
        };
    }
}