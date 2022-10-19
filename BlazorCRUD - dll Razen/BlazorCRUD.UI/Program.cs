
using BlazorCRUD.UI.Data;
using BlazorCRUD.UI.Interfaces;
using BlazorCRUD.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IFilmsService, FilmService>();       //Añadido aquí(program.cs) pero tendria que estar en el starup.cs
                                                                // Con esto se asocia la interface de servio con el obj de servicio
//1º intento --> var sqlConnectionConfiguration = new SqlConfiguration(Configuration.GetConnectionString("SqlConnection"));

var sqlConnectionConfiguration = new SqlConfiguration("Data Source=PC-ROL;Initial Catalog=BlazorCRUD;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

builder.Services.AddSingleton(sqlConnectionConfiguration);      //Así el objeto solo se crea una vez

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
