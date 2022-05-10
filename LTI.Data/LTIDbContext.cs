using LTI.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTI.Data
{
    public class LTIDbContext : DbContext
    {

        public LTIDbContext(DbContextOptions<LTIDbContext> options) : base(options)
        {
            
        }

        //Entity framework create and manage db using ino we provide in DBContext
        public DbSet<Employee> AT_Employees { get; set; }

        //creating Table of type employee with name AT_Employees
        //Dbset type allows us to do CRUD Operations. this is a feature called Migrations

        public DbSet<Project> AT_Projects { get; set; }

        //dotnet tool install --global dotnet-ef   ----->to install dotnet ef bndle
        //dotnet tool update --global dotnet-ef ------> update
        //dotnet ef ------->verify version and all
        //dotnet ef dbcontext list  ------>check if a dbcontext is prsent

        //migrations keep the database schema in sync with models in application  code

        //dotnet ef migrations add initialcreate -s ..\OdeToFood\OdeToFood.csproj    -----> create the migration folder and queries for creating tables.
        //dotnet ef database update -s ..\OdeToFood\OdeToFood.csproj  ---->to create the tables
    }
}
