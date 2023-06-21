using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RazorPagesDemoYoutube.Data;
using RazorPagesDemoYoutube.Models;
using RazorPagesDemoYoutube.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add Service CourseDbContext
string strcon = builder.Configuration.GetConnectionString("CourseDb");
builder.Services.AddDbContext<CourseDbContext>(options => options.UseSqlServer(strcon));
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add service ToastNotify
builder.Services.AddRazorPages().AddNToastNotifyToastr(new ToastrOptions()
{
    ProgressBar = true,
    PositionClass = ToastPositions.TopCenter,
    PreventDuplicates = true,
    CloseButton = true
});

// Add Service Identity 
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password = new PasswordOptions
    {
        RequireDigit = true,
        RequireUppercase = false,
        RequireLowercase = true,
        RequireNonAlphanumeric = false
    };
}).AddEntityFrameworkStores<CourseDbContext>();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
