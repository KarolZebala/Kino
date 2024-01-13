using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Infrastructure
{
    public class KinoDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public KinoDbContext(DbContextOptions<KinoDbContext> options) : base(options)
        {

        }
    }
}
