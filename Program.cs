using Microsoft.EntityFrameworkCore;
using DIO_ProjetoMVC.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AgendaContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));
// builder.Services.AddDbContext<AgendaContext>(
//     options => options.UseMySql(
//         "Server=localhost; Initial Catalog=AgendaMVC; uid=root; pwd=Zwi$ch3n",
//         Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"))); 

builder.Services.AddControllersWithViews();

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
