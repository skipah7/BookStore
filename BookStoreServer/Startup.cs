using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.IO;

namespace BookStoreServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var bookFileInfo = new FileInfo(
                Path.Combine(
                    AppContext.BaseDirectory, 
                    Configuration.GetSection(nameof(Book))["FilePath"]));

            var orderFileInfo = new FileInfo(
                Path.Combine(
                    AppContext.BaseDirectory, 
                    Configuration.GetSection(nameof(Order))["FilePath"]));
            
            services
                .AddTransient<IBookRepository>(provider => new JsonBookRepository(bookFileInfo))
                .AddTransient<IBookService, BookService>()
                .AddTransient<IOrderRepository>(provider => new JsonOrderRepository(orderFileInfo))
                .AddTransient<IOrderService, OrderService>()
                .AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
