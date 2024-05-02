using FH_Kufstein_Blazor_WebAppProject.Clients;
using FH_Kufstein_Blazor_WebAppProject.Components;

var builder = WebApplication.CreateBuilder(args); // Create a new WebApplication instance & create builder to register for dependency injection

// Add services to the container.
builder.Services.AddRazorComponents(); // Add RazorComponents to the services container
builder.Services.AddSingleton<ContainerDataClient>(); // Add the ContainerDataClient to the services container
builder.Services.AddSingleton<ContainerTypeClient>(); // Add the ContainerTypeClient to the services container

var app = builder.Build(); // Build the WebApplication

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts(); //Enforce HTTPS
}

app.UseHttpsRedirection(); //Redirect HTTP to HTTPS

app.UseStaticFiles(); // Serve static files, e.g. HTML, CSS, JS
app.UseAntiforgery(); // Add antiforgery token support to prevent cross-site request forgery attacks (CSRF)

app.MapRazorComponents<App>(); // Map the RazorComponents to the App component

app.Run();
