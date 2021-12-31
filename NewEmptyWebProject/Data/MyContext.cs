using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewEmptyWebProject.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewEmptyWebProject.Data
{
    public class MyContext :IdentityDbContext<ApplicationUser,ApplicationRole,string> //Appsettingteki ConnectionStings ekldikten sonra yaptık
    {
        public MyContext(DbContextOptions<MyContext> options):base(options)
        {

        }
    }
}
