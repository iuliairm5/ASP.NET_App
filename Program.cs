using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using ProjectIRIMIA.Data;

namespace ProjectIRIMIA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
          
            builder.Services.AddControllersWithViews();


            string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
            builder.Services.AddDbContext<ApplicationDbContext>(opts => {
                opts.UseSqlServer(
                 builder.Configuration["ConnectionStrings:DefaultConnection"]);
            });

            /* builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
     .AddEntityFrameworkStores<ApplicationDbContext>();*/

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
            .AddRoleManager<RoleManager<IdentityRole>>()
            .AddDefaultUI()
            .AddEntityFrameworkStores<ApplicationDbContext>();


           
            //-----------------------------------------------------------------


            builder.Services.Configure<IdentityOptions>(options =>
            {


                options.Password.RequiredLength = 8; //minimum length for the password

               

                // Lockout settings. 
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);

                options.Lockout.MaxFailedAccessAttempts = 5;

                options.Lockout.AllowedForNewUsers = true;

              
            });


            //------------------------------------------------------------------------
            var app = builder.Build();
            
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
               
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
           
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();


             Task.Run(async () =>
             {
                 await SeedDataIdentity.EnsurePopulatedAsync(app);

             }).Wait();


            app.Run();
        }
    }
}