// Program.cs
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using ProjetoGusmaoFinal.Components;
using ProjetoGusmaoFinal.Data;
using ProjetoGusmaoFinal.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSignalR(options =>
{
    options.MaximumReceiveMessageSize = 104857600; 
    options.StreamBufferCapacity = 20;
    options.EnableDetailedErrors = true;
    options.KeepAliveInterval = TimeSpan.FromSeconds(15);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 104857600;
    options.ValueLengthLimit = 104857600;
    options.MultipartHeadersLengthLimit = 104857600;
});


builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 104857600;
});


builder.Services.Configure<HubOptions>(options =>
{
    options.MaximumReceiveMessageSize = 104857600;
    options.MaximumParallelInvocationsPerClient = 2;
    options.StreamBufferCapacity = 20;
    options.EnableDetailedErrors = true; // Útil para debug
});

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 104857600;
    options.ValueLengthLimit = 104857600;
    options.MultipartHeadersLengthLimit = 104857600;
});

builder.Services.AddServerSideBlazor(options =>
{
    options.DetailedErrors = true;
    options.DisconnectedCircuitRetentionPeriod = TimeSpan.FromMinutes(2);
    options.JSInteropDefaultCallTimeout = TimeSpan.FromMinutes(1);
});

// Configuração do DbContext
builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(10, 4, 32)),
        mySqlOptions =>
        {
            mySqlOptions.CommandTimeout(300); // 5 minutos de timeout
        }
    )
);

builder.Services.AddAuthentication("CookieAuth")
.AddCookie("CookieAuth", options =>
{
    options.LoginPath = "/login";
    options.AccessDeniedPath = "/acesso-negado";
});


builder.Services.AddAuthorization();
builder.Services.AddScoped(typeof(CRUDService<>));
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<NewService>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<PublisherService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<HashService>();
builder.Services.AddScoped<RegistrationService>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

// Controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/logout", async (HttpContext context) =>
{
    await context.SignOutAsync("CookieAuth");
    context.Response.Redirect("/Login");
    return Results.Empty;
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapControllers();

app.Run();