namespace Feedback.Data.Migrations
{
    using Feedback.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FeedbackContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FeedbackContext context)
        {
            // create roles
            context.RoleSet.AddOrUpdate(r => r.Name, GenerateRoles());

            // // create user-admin for haja
            context.UserRoleSet.AddOrUpdate(new UserRole[] {
                new UserRole() {
                    RoleId = 1, // admin
                    UserId = 1  // haja
                }
            });

            // username: haja, password: haja
            context.UserSet.AddOrUpdate(u => u.Email, new User[]{
                new User()
                {
                    Email="s.hajamohideen@gmail.com",
                    Username="haja",
                    HashedPassword ="QSRfMBH7ZiTafVhHMxcKKkPw8XFGxi0qvqdXUiBzb/E=",
                    Salt = "uL/1Qn3mQDyHKfkp+IhWmw==",
                    IsLocked = false,
                    DateCreated = DateTime.Now
                }
            });
        }

        private Role[] GenerateRoles()
        {
            Role[] _roles = new Role[]{
                new Role()
                {
                    Name="Admin"
                }
            };

            return _roles;
        }
    }
}
