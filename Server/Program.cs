using BlazorApp1.Server.Services;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IForecastService, ForecastService>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection(); // used for gRPCurl

builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();
    app.MapGrpcReflectionService(); // used for gRPCurl
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

// If DefaultEnabled = true then gRPC-web is enabled for all endpoint by default 
// and you do not need to call .EnableGrpcWeb() on specific endpoints
// Must be added between UseRouting and UseEndpoints
app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true }); 

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<WeatherService>(); //.EnableGrpcWeb();
});

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
