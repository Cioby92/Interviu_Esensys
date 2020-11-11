using Essensys.Application;
using Essensys.Infrastructure;
using Essensys.Infrastructure.Persistence;
using Essensys.Application.Common.Interfaces;
using Essensys.WebInterface.Filters;
using Essensys.WebInterface.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using NSwag;
using System.Linq;
using MediatR;
using System.Reflection;
using Microsoft.Extensions.Options;
using System;
using Microsoft.AspNetCore.Identity;
using Essensys.Application.Transfer.Commands.CreateBankTransfer;
using Essensys.Application.Users.Commands;
using Essensys.Application.Transfer.Commands.GetTransferCommand;

namespace WebInterface
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
            services.AddControllersWithViews();
            services.AddInfrastructure(Configuration);

            services.AddSingleton<ICurrentUserService, CurrentUserService>();

            services.AddHttpContextAccessor();

            services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>();

            services.AddControllersWithViews(options =>
                options.Filters.Add(new ApiExceptionFilterAttribute()))
                    .AddFluentValidation();

            services.AddRazorPages();
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

            services.AddTransient<CreateTransferCommand>();
            services.AddTransient<CreateBankTransferCommandHandler>();
            services.AddScoped<IRequestHandler<CreateTransferCommand, int>, CreateBankTransferCommandHandler>();

            services.AddTransient<VerifyCNPCommand>();
            services.AddTransient<VerifyCNPCommandHandler>();
            services.AddScoped<IRequestHandler<VerifyCNPCommand, bool>, VerifyCNPCommandHandler>();


            services.AddTransient<GetBankTransferCommand>();
            services.AddTransient<GetBankTransferCommandHandler>();
            services.AddScoped<IRequestHandler<GetBankTransferCommand, TransferModel>, GetBankTransferCommandHandler>();

            // Customise default API behaviour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseHealthChecks("/health");

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();
         

            app.UseSwaggerUi3(settings =>
            {
                settings.Path = "/api";
                settings.DocumentPath = "/api/specification.json";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
