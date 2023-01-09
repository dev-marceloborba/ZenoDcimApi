using System.Linq;
using System.Text;
using ZenoDcimManager.Api.Hubs;
using ZenoDcimManager.Domain.ZenoContext.Handlers;
using ZenoDcimManager.Domain.ZenoContext.Repositories;
using ZenoDcimManager.Domain.AutomationContext.Handlers;
using ZenoDcimManager.Domain.AutomationContext.Repositories;
using ZenoDcimManager.Domain.UserContext.Handlers;
using ZenoDcimManager.Domain.UserContext.Repositories;
using ZenoDcimManager.Domain.UserContext.Services;
using ZenoDcimManager.Infra.Contexts;
using ZenoDcimManager.Infra.Repositories;
using ZenoDcimManager.Infra.Services;
using ZenoDcimManager.Shared;
using ZenoDcimManager.Shared.Services;
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
using System.Text.Json.Serialization;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Domain.ActiveContext.Handlers;
using ZenoDcimManager.Domain.ServiceOrderContext.Repositories;
using System.Text.Json;

namespace ZenoDcimManager.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // contexts for SQL Server
            services.AddDbContext<ZenoContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("connectionString")));

            // services
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ICryptoService, CryptoService>();
            services.AddTransient<ITokenService, TokenService>();

            // repositories
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IRackRepository, RackRepository>();
            services.AddTransient<IRackEquipmentRepository, RackEquipmentRepository>();
            services.AddTransient<IPlcRepository, PlcRepository>();
            services.AddTransient<IModbusTagRepository, ModbusTagRepository>();
            services.AddTransient<IAlarmRepository, AlarmRepository>();
            services.AddTransient<IAlarmRuleRepository, AlarmRuleRepository>();
            services.AddTransient<ISiteRepository, SiteRepository>();
            services.AddTransient<IBuildingRepository, BuildingRepository>();
            services.AddTransient<IFloorRepository, FloorRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IEquipmentRepository, EquipmentRepository>();
            services.AddTransient<IParameterRepository, ParameterRepository>();
            services.AddTransient<IVirtualParameterRepository, VirtualParameterRepository>();
            services.AddTransient<IEquipmentParameterRepository, EquipmentParameterRepository>();
            services.AddTransient<IEquipmentParameterGroupRepository, EquipmentParameterGroupRepository>();
            services.AddTransient<IMeasureRepository, MeasureRepository>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<IWorkOrderRepository, WorkOrderRepository>();

            // handlers
            services.AddTransient<UserHandler, UserHandler>();
            services.AddTransient<CompanyHandler, CompanyHandler>();
            services.AddTransient<LoginHandler, LoginHandler>();
            services.AddTransient<RackHandler, RackHandler>();
            services.AddTransient<RackEquipmentHandler, RackEquipmentHandler>();
            services.AddTransient<PlcHandler, PlcHandler>();
            services.AddTransient<ModbusTagHandler, ModbusTagHandler>();
            services.AddTransient<AlarmHandler, AlarmHandler>();
            services.AddTransient<AlarmRuleHandler, AlarmRuleHandler>();
            services.AddTransient<SiteHandler, SiteHandler>();
            services.AddTransient<BuildingHandler, BuildingHandler>();
            services.AddTransient<FloorHandler, FloorHandler>();
            services.AddTransient<RoomHandler, RoomHandler>();
            services.AddTransient<EquipmentHandler, EquipmentHandler>();
            services.AddTransient<EquipmentParameterHandler, EquipmentParameterHandler>();
            services.AddTransient<ParameterHandler, ParameterHandler>();
            services.AddTransient<ParameterGroupHandler, ParameterGroupHandler>();
            services.AddTransient<VirtualParameterHandler, VirtualParameterHandler>();
            services.AddTransient<AlarmEmailHandler, AlarmEmailHandler>();

            services.AddCors(p => p.AddPolicy("zenoCors", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" });
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers()
                .AddJsonOptions(
                    options =>
                    {
                        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                        // options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                    }

                 );

            // services.AddControllers().AddNewtonSoftJson();
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ZenoDcimManager.Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZenoDcimManager.Api v1"));
            }


            app.UseRouting();

            app.UseCors("zenoCors");

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<NotificationsHub>("/notifications");
            });
        }
    }
}
