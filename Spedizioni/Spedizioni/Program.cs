using Microsoft.AspNetCore.Authentication.Cookies;
using Spedizioni.Models;
using Spedizioni.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//CONFIGURAZIONE DELL'AUTORIZZAZIONE
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
{
    opt.LoginPath = "/Account/Login";
});



//CONFIGURAZIONE DEL SERVIZIO DI GESTIONE DELLE AUTENTIFICAZIONI
builder.Services.AddScoped<IAuthService, AuthService>();






var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();