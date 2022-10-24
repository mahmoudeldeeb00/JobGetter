using JobGetter.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobGetter.DAL
{
    public class DataBase:IdentityDbContext<AppUser>
    {
        public DataBase(DbContextOptions<DataBase> option):base(option)
        {

        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobOpportunityRequest> JobOpportunityRequests { get; set; }
        public DbSet<Jobpportunity> Jobpportunitys { get; set; }
        public DbSet<MilitaryStatus> MilitaryStatuses { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }



    }
}
