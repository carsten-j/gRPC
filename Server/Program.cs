using BlazorApp1.Server.Services;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IForecastService, ForecastService>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddGrpc();

builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

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
app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true }); // Must be added between UseRouting and UseEndpoints

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<WeatherService>().EnableGrpcWeb();
});

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
