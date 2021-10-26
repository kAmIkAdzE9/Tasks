using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace endpoints
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapPost("/headers", async context => 
                {
                    
                });

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapGet("/headers", async context =>
                {
                    string res = "";
                    IHeaderDictionary headers = context.Request.Headers;
                    foreach(KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues> keyValue in headers) {
                        res += keyValue.Key + " " + keyValue.Value.ToString() + "\n";
                    }
                    
                    await context.Response.WriteAsync(res);
                });

                endpoints.MapGet("/plural", async context =>
                {
                    await context.Response.WriteAsync("plural");
                });

                endpoints.MapGet("/frequency", async context =>
                {
                    await context.Response.WriteAsync("frequency");
                });
            });
        }
    }
}
