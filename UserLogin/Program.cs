using DNTCaptcha.Core;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using UserLogin.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();
var Provider=builder.Services.BuildServiceProvider();   
var Config= Provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<DemoDbcontext>(item => item.UseSqlServer(Config.GetConnectionString("DbConnectionString")));

  builder.Services.AddDNTCaptcha(options =>
{
 
    options.UseCookieStorageProvider(SameSiteMode.Strict )

 

    
    .AbsoluteExpiration(minutes: 7)
    .ShowThousandsSeparators(false)
    
    .WithEncryptionKey("This is my secure key!")
    .InputNames(
        new DNTCaptchaComponent
        {
            CaptchaHiddenInputName = "DNT_CaptchaText",
            CaptchaHiddenTokenName = "DNT_CaptchaToken",
            CaptchaInputName = "DNT_CaptchaInputText"
        })
    .Identifier("dnt_Captcha")
    ;
});
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
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
