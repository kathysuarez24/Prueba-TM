using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_tm.Data;
using Api_tm.Model;
using Api_tm.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Api_tm
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
            //Conexion String
            services.AddDbContext<UsuarioDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConexionBD")));

            //Permiso para trabajar datos
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                     builder.AllowAnyHeader()
                             .AllowAnyMethod()
                             .AllowAnyOrigin()
                );
            });

            //Registrar la dependencia de Servicios
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IRolService, RolService>();

            //Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                 .AddEntityFrameworkStores<UsuarioDbContext>()
                 .AddDefaultTokenProviders();

            //Autenticación
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();

            app.UseCors("AllowSpecificOrigin");

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
