using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mmo.Application.Interfaces.Context;
using mmo.Application.Interfaces.UnitOfWork;
using mmo.Domain.Entities;
using mmo.Persistence.Context;
using mmo.Persistence.UnitOfWorks;

namespace mmo.Persistence
{

    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection, string connectionString)
        {         
            #region DbContext
            
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("mmo.API")));
            serviceCollection.AddIdentityCore<Player>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            serviceCollection.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });
            
            #endregion
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
        }
        
    }

}