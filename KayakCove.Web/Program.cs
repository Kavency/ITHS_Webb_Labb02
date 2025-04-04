using KayakCove.Web.Components;
using KayakCove.Web.ApiServices;
using Blazored.Toast;
using Blazored.LocalStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddBlazoredToast();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<LoginStateService>();
builder.Services.AddScoped<CategoryApiService>();
builder.Services.AddScoped<ProductApiService>();
builder.Services.AddScoped<RoleApiService>();
builder.Services.AddScoped<UserApiService>();
builder.Services.AddScoped<OrderApiService>();

builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7247/api/");
});

var app = builder.Build();

app.UsePathBase("/");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
