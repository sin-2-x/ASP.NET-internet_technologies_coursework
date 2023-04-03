using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Web_MVC.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Web_MVCContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Web_MVCContext") ?? throw new InvalidOperationException("Connection string 'Web_MVCContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();/*
builder.Services.AddSwaggerGen();*/

var app = builder.Build();

// Configure the HTTP request pipeline.
 if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
/*    app.UseSwagger();
    app.UseSwaggerUI();*/
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=CalendarGrid}/{action=Index}/{id?}");

app.Run();
