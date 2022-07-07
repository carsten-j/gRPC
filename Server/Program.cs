using BlazorApp1.Server.Services;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

const int Port = 8080;

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
// builder.WebHost.ConfigureKestrel(options =>
// {
//    // Setup a HTTP/2 endpoint without TLS.
//    options.ListenLocalhost(Port, o => o.Protocols = HttpProtocols.Http2);
//    options.ListenLocalhost(5069);    
//    options.ListenLocalhost(7069, o => o.UseHttps());
// });

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
