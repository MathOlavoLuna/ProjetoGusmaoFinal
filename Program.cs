using Microsoft.EntityFrameworkCore;
using ProjetoGusmaoFinal.Components;
using ProjetoGusmaoFinal.Data;

var builder = WebApplication.CreateBuilder(args);
var ConnectionString = "server=localhost;user=root;password=luna;database=projectg";
var serverVersion = new MariaDbServerVersion(new Version(12, 0, 2));
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

builder.Services.AddDbContext<DataContext>(options => options.UseMySql(ConnectionString, serverVersion));

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
