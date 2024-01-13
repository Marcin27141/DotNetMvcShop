using ArticleShop.Models.Database;
using ArticleShop.Repositories.ArticleCleanUp;
using ArticleShop.Repositories.ArticleRepository;
using ArticleShop.Repositories.CartRepository;
using ArticleShop.Repositories.CategoryRepository;
using ArticleShop.Repositories.ImageRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using ArticleShop.Repositories.PaymentRepository;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IImageRepository, ImageRepository>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContextPool<ShopDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ShopDbContext>();

builder.Services.AddScoped<IArticleCleanUp, ArticleCleanUp>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("IsNotAdmin", policy =>
        policy.RequireAssertion(sth => !sth.User.IsInRole("Admin")));





System.Globalization.CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo("en-EN");

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

app.UseAuthentication();

app.UseAuthorization();



using (var scope = app.Services.CreateScope())
{
    //var someService = app.Services.GetService<UserManager<IdentityUser>>();
    //var otherService = app.Services.GetService<RoleManager<IdentityRole>>();

    IdentityInitializer.SeedData(
        scope.ServiceProvider.GetService<UserManager<IdentityUser>>(),
        scope.ServiceProvider.GetService<RoleManager<IdentityRole>>()
    );
}


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
