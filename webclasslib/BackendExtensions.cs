using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Additional Namespaces
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DAL;
using BLL;

namespace webclasslib;
public static class BackEndExtensions
{
    public static void AddBackendDependencies(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
    {
        services.AddDbContext<Context>(options);

        services.AddTransient<OtherServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetRequiredService<Context>();
                return new OtherServices(context);
            });

        services.AddTransient<CategoryServices>((serviceProvider) =>
			{
				var context = serviceProvider.GetRequiredService<Context>();
				return new CategoryServices(context);
			});

        services.AddTransient<ProductServices>((serviceProvider) =>
			{
				var context = serviceProvider.GetRequiredService<Context>();
				return new ProductServices(context);
			});
    }
}
