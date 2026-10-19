using EventEase;
using EventEase.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// The event catalogue and its registrations must outlive navigation, so they live for the app.
builder.Services.AddSingleton<EventService>();

// The signed-in attendee is per user session.
builder.Services.AddScoped<SessionService>();

await builder.Build().RunAsync();
