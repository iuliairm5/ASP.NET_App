using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectIRIMIA.Data;

namespace ProjectIRIMIA.Data
{
    public class SeedDataIdentity
    {
       

        public static async  Task EnsurePopulatedAsync(IApplicationBuilder app)
        {

            var serviceProvider = app.ApplicationServices.CreateScope().ServiceProvider;

            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }

            //the roles
            if (!roleManager.RoleExistsAsync
        ("CreateUser").Result)
            {
                IdentityRole role0 = new IdentityRole();
                role0.Name = "CreateUser";

                await roleManager.CreateAsync(role0);
            }

            
            if (!roleManager.RoleExistsAsync
        ("Administrator").Result)
            {
                IdentityRole role2 = new IdentityRole();
                role2.Name = "Administrator";

                //IdentityResult roleResult2 = roleManager.
                //CreateAsync(role2).Result;
               await roleManager.CreateAsync(role2);
            }

            if (!roleManager.RoleExistsAsync
       ("OnlyDetails").Result)
            {
                IdentityRole role3 = new IdentityRole();
                role3.Name = "OnlyDetails";

                await roleManager.CreateAsync(role3);
            }


            //the users with the roles

            IdentityUser user0 = await userManager.FindByEmailAsync("user12@localhost.com");

            if (user0 == null) 
            { 
                    user0 = new IdentityUser();

                    user0.UserName = "user12@localhost.com";
                   
                    user0.Email = "user12@localhost.com";


                    await userManager.CreateAsync (user0, "User12pass&");

                    await userManager.AddToRoleAsync(user0,
                                            "CreateUser");

                }


            IdentityUser user2 = await userManager.FindByEmailAsync("user2@localhost.com");

            if (user2 == null)
            {
                user2 = new IdentityUser();

                user2.UserName = "user2@localhost.com";

                user2.Email = "user2@localhost.com";


                await userManager.CreateAsync(user2, "User2pass&");

                await userManager.AddToRoleAsync(user2,
                                        "Administrator");

            }

            IdentityUser user3 = await userManager.FindByEmailAsync("user3@localhost.com");

            if (user3 == null)
            {
                user3 = new IdentityUser();

                user3.UserName = "user3@localhost.com";

                user3.Email = "user3@localhost.com";


                await userManager.CreateAsync(user3, "User3pass&");

                await userManager.AddToRoleAsync(user3,
                                        "OnlyDetails");

            }


        }
    }
}
