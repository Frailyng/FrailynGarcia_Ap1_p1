using FrailynGarcia_Ap1_p1.Components;
using FrailynGarcia_Ap1_p1.DAL;
using FrailynGarcia_Ap1_p1.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var ConStr = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContext<Contexto>( options => options.UseSqlite(ConStr));

builder.Services.AddScoped<PrestamoService>();
builder.Services.AddScoped<DeudorService>();
builder.Services.AddScoped<CobroService>();
builder.Services.AddScoped<CobroDetalleService>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<TiposTelefonoService>();
builder.Services.AddScoped<TelefonosService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
