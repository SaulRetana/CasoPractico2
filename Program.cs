using Microsoft.EntityFrameworkCore;
using CasoPractico2.Models;
using CasoPractico2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EventCorpContext>(op =>
op.UseSqlServer(builder.Configuration.GetConnectionString("EventCorp")));

//Tipos de Servicios
builder.Services.AddTransient<ITrasientServices, TransientServices>();
builder.Services.AddSingleton<ISingeltonServices, SingeltonServices>();
builder.Services.AddScoped<IScopedServices, ScopedServices>();

builder.Services.AddScoped<IEventoServices, EventoServices>();
builder.Services.AddScoped<ICantidadRegistros, CantidadRegistros>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
