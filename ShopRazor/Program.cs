using ShopRazor.Models.Database;
using ShopRazor.Repositories.ImageRepository;
using Microsoft.EntityFrameworkCore;
using ShopRazor.Repositories.ArticleCleanUp;
using ShopRazor.Repositories.ArticleRepository;
using ShopRazor.Repositories.CartRepository;
using ShopRazor.Repositories.CategoryRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IImageRepository, ImageRepository>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContextPool<ShopDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IArticleCleanUp, ArticleCleanUp>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();

System.Globalization.CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo("en-EN");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
