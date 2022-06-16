using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mmo.Application.Interfaces.Context;
using mmo.Domain.Entities;

namespace mmo.Persistence.Context
{

    public class ApplicationDbContext : IdentityDbContext<Player> , IApplicationContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        
    }

}