using HotelBooking.Model;
using HotelBooking.Repository.IRepo;
using HotelBooking.Repository.Repo;
using HotelBooking.Services.Implementation;
using HotelBooking.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<HotelManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBDefault")));

//builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
//{
//    options.SignIn.RequireConfirmedAccount = false;
//    // Configure other Identity options here
//})
//.add;


builder.Services.AddScoped<IRoomInfo, RoomInfoRepo>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
builder.Services.AddScoped<IBookingRoomRepo, BookingRoomRepo>();
builder.Services.AddScoped<IBookingReservationRepo, BookingReservationRepo>();
builder.Services.AddScoped<IBookingDetailRepo, BookingDetailRepo>();

builder.Services.AddScoped<IRoomInfoService, RoomInfoServices>();
builder.Services.AddScoped<ICustomerServices, CustomerService>();
builder.Services.AddScoped<IBookingServices, BookingServices>();




//builder.Services.AddAuthentication(options =>
//{
//	options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//	options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//	options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//}).AddCookie();

builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true; // make the session cookie essential
});

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
app.UseSession();
app.MapRazorPages();

app.Run();
