using CrudNetCore6.Server.Modelos;
using CrudNetCore6.Server.Servicios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
//Añado mis servicios --> DbContext al que le paso mi objeto de "NetCore6EjemploContext"
builder.Services.AddDbContext<NetCore6EjemploContext>
    (options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQL")));

builder.Services.AddScoped<IUsuario, GestionUsuarios>(); // De esta manera decimos de que interface depende (IUsuario) y donde se encuentra la clase que tiene los datos (GestionUsuarios)

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
