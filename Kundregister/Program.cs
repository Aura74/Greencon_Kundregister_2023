using Kund_DataAccess.Data;
using Kundregister.Data;
using Microsoft.EntityFrameworkCore;
using Kund_Business.Repository;
using Kund_Business.Repository.IRepository;
using Kundregister.Service.IService;
using Kundregister.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// Denna ska vara med
builder.Services.AddDbContext<ApplicationDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// L�gg till referenser med,  l�gg till using Kund_Business.Repository; och using Kund_Business.Repository.IRepository; l�gger nu till detta i dependecy injection
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

// F�r bilderna
builder.Services.AddScoped<IFileUpload, FileUpload>();

// F�r automapper, kom ih�g AutoMapper.Extensions.Microsoft.DependencyInjection
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
