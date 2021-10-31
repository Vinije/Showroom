using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Showroom.Api.Models;
using Showroom.Client.Areas.Identity;
using Showroom.Client.Data;
using Showroom.Client.Services;
using Showroom.Presentation.Extensions;
using Showroom.Presentation.UserInterface;

namespace Showroom.Client
{
    public class Startup
    {
        private const string UriString = "https://localhost:44397";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddThemeManager();

            services.AddHttpClient<IProjectService, ProjectService>(client =>
                client.BaseAddress = new Uri(UriString));

            services.AddScoped<IProgressUpdater, JsProgressUpdater>();

            services.AddScoped<TokenProvider>();

            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddDatabaseDeveloperPageExceptionFilter();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            StaticFileOptions option = new StaticFileOptions();
            FileExtensionContentTypeProvider contentTypeProvider = (FileExtensionContentTypeProvider)option.ContentTypeProvider ??
                                                                   new FileExtensionContentTypeProvider();

            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings.Remove(".data");
            provider.Mappings[".data"] = "application/octet-stream";
            provider.Mappings.Remove(".wasm");
            provider.Mappings[".wasm"] = "application/wasm";
            provider.Mappings.Remove(".symbols.json");
            provider.Mappings[".symbols.json"] = "application/octet-stream";
            app.UseStaticFiles(new StaticFileOptions { ContentTypeProvider = provider });
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
