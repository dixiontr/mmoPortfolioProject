using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using mmo.Application.Interfaces.Context;
using mmo.Domain.Entities;

namespace mmo.Application
{

    public static class ServiceRegistration
    {
        
        public static void AddApplicationServices(this IServiceCollection serviceCollection)
        {
            

            #region Localization

                serviceCollection.Configure<RequestLocalizationOptions>(options =>
                {
                    options.DefaultRequestCulture = new("en-US");
                    CultureInfo[] cultures = new CultureInfo[]
                    {
                        new("tr-TR"),
                        new("en-US"),
                    };
            
                    List<IRequestCultureProvider> cultureProviders = new List<IRequestCultureProvider>()
                    {
                        new QueryStringRequestCultureProvider()
                    };
        
                    options.SupportedCultures = cultures;
                    options.SupportedUICultures = cultures;
                    options.ApplyCurrentCultureToResponseHeaders = true;
            
                    options.RequestCultureProviders = cultureProviders;
        
                });

            #endregion

        }
        
    }

}