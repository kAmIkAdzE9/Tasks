using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using System.Buffers;
using System.Text.Json;

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
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapGet("/headers", async context =>
                {
                    string res = "";
                    IHeaderDictionary headers = context.Request.Headers;
                    foreach (KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues> keyValue in headers)
                    {
                        res += keyValue.Key + " " + keyValue.Value.ToString() + "\n";
                    }

                    await context.Response.WriteAsync(res);
                });

                endpoints.MapGet("/plural", async context =>
                {
                    int number = Convert.ToInt32(context.Request.Query["number"]);
                    string[] forms = context.Request.Query["forms"].ToString().Split(",", StringSplitOptions.RemoveEmptyEntries);
                    if (forms.Length > 2)
                    {
                        string response = Pluralization.GetPluralization(number, forms[0], forms[1], forms[2]);
                        await context.Response.WriteAsync($"Pluralization of {number} (using forms: {forms[0]}, {forms[1]}, {forms[2]})  is {number} {response}");
                    }
                    else
                    {
                        await context.Response.WriteAsync($"The length is {forms.Length}");
                    }
                });

                endpoints.MapPost("/frequency", async context =>
                {
                    string bodyString = await new StreamReader(context.Request.Body).ReadToEndAsync();
                    Dictionary<string, int> dict = Frequency.GetCountOfWord(bodyString);
                    int maxVal = 0;
                    string mostPopularWord = "";
                    foreach(var el in dict) {
                        if(el.Value > maxVal) {
                            maxVal = el.Value;
                            mostPopularWord = el.Key;
                        }
                    }
                    context.Response.ContentType = "application/json";
                    context.Response.Headers.Add("Words-Count", dict.Count.ToString());
                    context.Response.Headers.Add("MostPopularWord", mostPopularWord);

                    await context.Response.WriteAsync(JsonSerializer.Serialize<Dictionary<string, int>>(dict));
                });
            });
        }
    }
}
