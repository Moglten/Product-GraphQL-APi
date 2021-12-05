using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Product_GraphQL_APi.Data;
using Product_GraphQL_APi.Data.ModelDB;
using Product_GraphQL_APi.GraphQL;
using Product_GraphQL_APi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Product_GraphQL_APi
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NORTHWNDContext>(options =>
                                                            options.UseSqlServer(_config.GetConnectionString("ConnString")));

       

            services.AddScoped<OrderRepository>();

            services.AddScoped<EmployeeRepository>();

            services.AddScoped<DetailsRepository>();

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            services.AddScoped<AppSchema>();

            services.AddGraphQL(o =>{o.ExposeExceptions = true;
                                    }).AddGraphTypes(ServiceLifetime.Scoped)
                                      .AddDataLoader();

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

        }


        public void Configure(IApplicationBuilder app)
        {
            app.UseGraphQL<AppSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
        }
    }
}
