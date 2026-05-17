//using DAL.EF;
using BLL;
using BLL.Services;
using DAL.EF;
using DAL.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<CategoryRepo>();
builder.Services.AddScoped<BookRepo>();
builder.Services.AddScoped<UserRepo>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<UserService>();

//mapper
builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddDbContext<BookManagementContext>(opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConn"));
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
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
