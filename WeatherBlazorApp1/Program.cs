using WeatherBlazorApp1.Components;
using WeatherBlazorApp1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddTelerikBlazor();

// Register the services
builder.Services.AddTransient<IWeatherService, OpenWeatherService>();

//builder.Services.AddHttpClient();

var openWeatherUrl = builder.Configuration["OpenWeatherUrl"];
if (string.IsNullOrEmpty(openWeatherUrl))
{
    throw new InvalidOperationException("The OpenWeatherUrl configuration value is empty or missing.");
}
builder.Services.AddHttpClient("OpenWeatherAPI", client => client.BaseAddress = new Uri(openWeatherUrl));

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
