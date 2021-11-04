using System.Linq;
using System.Text;
using EvoDcimManager.Api.Hubs;
using EvoDcimManager.Domain.ActiveContext.Handlers;
using EvoDcimManager.Domain.ActiveContext.Repositories;
using EvoDcimManager.Domain.AutomationContext.Handlers;
using EvoDcimManager.Domain.AutomationContext.Repositories;
using EvoDcimManager.Domain.UserContext.Handlers;
using EvoDcimManager.Domain.UserContext.Repositories;
using EvoDcimManager.Domain.UserContext.Services;
using EvoDcimManager.Infra.Contexts;
using EvoDcimManager.Infra.Repositories;
using EvoDcimManager.Infra.Services;
using EvoDcimManager.Shared;
using EvoDcimManager.Shared.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace EvoDcimManager.Api
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // contexts
            // services.AddDbContext<UserContext>(opt => opt.UseInMemoryDatabase("Database"));
            // services.AddDbContext<ActiveContext>(opt => opt.UseInMemoryDatabase("Database"));
            // services.AddDbContext<AutomationContext>(opt => opt.UseInMemoryDatabase("Database"));
            services.AddDbContext<UserContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("connectionString")));
            services.AddDbContext<ActiveContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("connectionString")));
            services.AddDbContext<AutomationContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("connectionString")));

            // services
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ICryptoService, CryptoService>();
            services.AddTransient<ITokenService, TokenService>();

            // repositories
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRackRepository, RackRepository>();
            services.AddTransient<IRackEquipmentRepository, RackEquipmentRepository>();
            services.AddTransient<IPlcRepository, PlcRepository>();
            services.AddTransient<IModbusTagRepository, ModbusTagRepository>();
            services.AddTransient<IAlarmRepository, AlarmRepository>();

            // handlers
            services.AddTransient<UserHandler, UserHandler>();
            services.AddTransient<LoginHandler, LoginHandler>();
            services.AddTransient<RackHandler, RackHandler>();
            services.AddTransient<RackEquipmentHandler, RackEquipmentHandler>();
            services.AddTransient<PlcHandler, PlcHandler>();
            services.AddTransient<ModbusTagHandler, ModbusTagHandler>();
            services.AddTransient<AlarmHandler, AlarmHandler>();

            services.AddCors();

            // services.AddCors();
            // services.AddCors(options =>
            // {
            //     options.AddPolicy("Default", builder =>
            //     {
            //         builder.WithOrigins("http://localhost:4200")
            //             .AllowAnyMethod()
            //             .AllowAnyHeader()
            //             .AllowAnyOrigin()
            //             .AllowCredentials();
            //     });
            // });
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" });
            });

            services.AddControllers();
            services.AddSignalR();

            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EvoDcimManager.Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EvoDcimManager.Api v1"));
            }

            // app.UseCors(MyAllowSpecificOrigins);
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
         );

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<AlarmHub>("/alarmHub");
            });
        }
    }
}
