using Api.Data.Context;
using Api.Domain.Interfaces;
using Api.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Api.Data.Implementations;
using Api.Domain.Repository;
using System;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();

            if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "SQLSERVER".ToLower())
            {
                serviceCollection.AddDbContext<MyContext>(
                options => options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION"))
                );

            }
            else
            {
                serviceCollection.AddDbContext<MyContext>(
                options => options.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION"))
                );   
            }
            
            /*serviceCollection.AddDbContext<MyContext>(
                options => options.UseMySql("Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=root")
            );
            */

        }
    }
}
