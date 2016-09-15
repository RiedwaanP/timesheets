using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Timesheets.Domain;

namespace Timesheets.Database
{
    public class MigrationConfiguration : DbMigrationsConfiguration<DatabaseContext>
    {
        public MigrationConfiguration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DatabaseContext context)
        {
            if (!context.Roles.Any())
            {
                var admin = new Role("Admin");
                var capturer = new Role("Capturer");

                if (!context.Users.Any())
                {
                    var user1 = new User("riedwaan.petersen@entelect.co.za", "Riedwaan", "Petersen")
                    {
                        UserName = "riedwaan.petersen@entelect.co.za",
                        EmailConfirmed = true,
                        PasswordHash = "ANkp8cPgJLJTIHQO5C72+6nxOkMi5eIkqbvxMoSeAM+gaGqC5cygkfAUq2/WEbGEyg==",
                        LockoutEnabled = true,
                        SecurityStamp = "c367d481-9c34-4f21-9f42-1bf86e03f7f8"
                    };

                    var user2 = new User("matthew.markgraaff@entelect.co.za", "Matthew", "Markgraaff")
                    {
                        UserName = "matthew.markgraaff@entelect.co.za",
                        EmailConfirmed = true,
                        PasswordHash = "ANkp8cPgJLJTIHQO5C72+6nxOkMi5eIkqbvxMoSeAM+gaGqC5cygkfAUq2/WEbGEyg==",
                        LockoutEnabled = true,
                        SecurityStamp = "c367d481-9c34-4f21-9f42-1bf86e03f7f8"
                    };

                    var user3 = new User("capturer@entelect.co.za", "Capturer", "User")
                    {
                        UserName = "capturer@entelect.co.za",
                        EmailConfirmed = true,
                        PasswordHash = "ANkp8cPgJLJTIHQO5C72+6nxOkMi5eIkqbvxMoSeAM+gaGqC5cygkfAUq2/WEbGEyg==",
                        LockoutEnabled = true,
                        SecurityStamp = "c367d481-9c34-4f21-9f42-1bf86e03f7f8"
                    };

                    var user4 = new User("admin@entelect.co.za", "Admin", "User")
                    {
                        UserName = "admin@entelect.co.za",
                        EmailConfirmed = true,
                        PasswordHash = "ANkp8cPgJLJTIHQO5C72+6nxOkMi5eIkqbvxMoSeAM+gaGqC5cygkfAUq2/WEbGEyg==",
                        LockoutEnabled = true,
                        SecurityStamp = "c367d481-9c34-4f21-9f42-1bf86e03f7f8"
                    };

                    user1.Roles.Add(admin);
                    user1.Roles.Add(capturer);

                    user2.Roles.Add(admin);
                    user2.Roles.Add(capturer);

                    user3.Roles.Add(capturer);
                    user4.Roles.Add(admin);

                    var users = new List<User>() { user1, user2, user3, user4 };

                    context.Users.AddRange(users);
                }
                context.SaveChanges();
            }
            base.Seed(context);
        }
    }
}