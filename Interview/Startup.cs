using DbEntities.DBContext;
using InterviewContracts;
using InterviewImplementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models;
using Models.EmailModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview
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
            services.AddDbContext<InterviewQuestionsDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;                
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 3;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(20);
                options.Lockout.MaxFailedAccessAttempts = 3;
            })
            .AddEntityFrameworkStores<InterviewQuestionsDbContext>()
            .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider);
            services.AddMvc();
            services.AddSession();
            services.AddControllersWithViews();
            services.AddAntiforgery();
            services.AddControllers();
            services.AddAntiforgery();
            services.AddAutoMapper(typeof(Mapping.AutoMapping));

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.Configure<SMTPConfigModel>(Configuration.GetSection("SMTPConfig"));
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=LogIn}/{action=LogIn}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
