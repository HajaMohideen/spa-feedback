using Feedback.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedback.Data.Configurations
{
    public class UsersConfiguration : EntityBaseConfiguration<Users>
    {
        public UsersConfiguration()
        {
            Property(u => u.Name).IsRequired().HasMaxLength(100);
            Property(u => u.Subject).IsRequired().HasMaxLength(200);
            Property(u => u.Email).IsRequired().HasMaxLength(200);
            Property(u => u.Feedback).IsRequired().HasMaxLength(200);

        }
    }
}
