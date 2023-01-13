﻿using System.Linq;
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
using System.IO.Compression;

var builder = WebApplication.CreateBuilder(args);
ConfigureAuthentication(builder);
ConfigureMvc(builder);
ConfigureServices(builder);
ConfigureRepositories(builder);
ConfigureHandlers(builder);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

var app = builder.Build();
LoadConfiguration(app);

app.UseCors(builder =>
{
    builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
});
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseStaticFiles();
app.UseResponseCompression();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHub<NotificationsHub>("notifications");

app.Run();

void LoadConfiguration(WebApplication app)
{

}

void ConfigureAuthentication(WebApplicationBuilder builder)
{
    var key = Encoding.ASCII.GetBytes(Settings.Secret);
    builder.Services.AddAuthentication(x =>
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
}

void ConfigureMvc(WebApplicationBuilder builder)
{
    builder.Services.AddResponseCompression(options =>
    {
        options.Providers.Add<GzipCompressionProvider>();
        options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" });
    });
    builder.Services.Configure<GzipCompressionProviderOptions>(options =>
    {
        options.Level = CompressionLevel.Optimal;
    });
    builder.Services
        .AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });
}

void ConfigureServices(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("connectionString");
    builder.Services.AddDbContext<ZenoContext>(options => options.UseSqlServer(connectionString));
    builder.Services.AddTransient<IEmailService, EmailService>();
    builder.Services.AddTransient<ICryptoService, CryptoService>();
    builder.Services.AddTransient<ITokenService, TokenService>();
}

void ConfigureRepositories(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<IUserRepository, UserRepository>();
    builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
    builder.Services.AddTransient<IRackRepository, RackRepository>();
    builder.Services.AddTransient<IRackEquipmentRepository, RackEquipmentRepository>();
    builder.Services.AddTransient<IPlcRepository, PlcRepository>();
    builder.Services.AddTransient<IModbusTagRepository, ModbusTagRepository>();
    builder.Services.AddTransient<IAlarmRepository, AlarmRepository>();
    builder.Services.AddTransient<IAlarmRuleRepository, AlarmRuleRepository>();
    builder.Services.AddTransient<ISiteRepository, SiteRepository>();
    builder.Services.AddTransient<IBuildingRepository, BuildingRepository>();
    builder.Services.AddTransient<IFloorRepository, FloorRepository>();
    builder.Services.AddTransient<IRoomRepository, RoomRepository>();
    builder.Services.AddTransient<IEquipmentRepository, EquipmentRepository>();
    builder.Services.AddTransient<IParameterRepository, ParameterRepository>();
    builder.Services.AddTransient<IVirtualParameterRepository, VirtualParameterRepository>();
    builder.Services.AddTransient<IEquipmentParameterRepository, EquipmentParameterRepository>();
    builder.Services.AddTransient<IEquipmentParameterGroupRepository, EquipmentParameterGroupRepository>();
    builder.Services.AddTransient<IMeasureRepository, MeasureRepository>();
    builder.Services.AddTransient<ISupplierRepository, SupplierRepository>();
    builder.Services.AddTransient<IGroupRepository, GroupRepository>();
    builder.Services.AddTransient<IWorkOrderRepository, WorkOrderRepository>();
}

void ConfigureHandlers(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<UserHandler, UserHandler>();
    builder.Services.AddTransient<CompanyHandler, CompanyHandler>();
    builder.Services.AddTransient<LoginHandler, LoginHandler>();
    builder.Services.AddTransient<RackHandler, RackHandler>();
    builder.Services.AddTransient<RackEquipmentHandler, RackEquipmentHandler>();
    builder.Services.AddTransient<PlcHandler, PlcHandler>();
    builder.Services.AddTransient<ModbusTagHandler, ModbusTagHandler>();
    builder.Services.AddTransient<AlarmHandler, AlarmHandler>();
    builder.Services.AddTransient<AlarmRuleHandler, AlarmRuleHandler>();
    builder.Services.AddTransient<SiteHandler, SiteHandler>();
    builder.Services.AddTransient<BuildingHandler, BuildingHandler>();
    builder.Services.AddTransient<FloorHandler, FloorHandler>();
    builder.Services.AddTransient<RoomHandler, RoomHandler>();
    builder.Services.AddTransient<EquipmentHandler, EquipmentHandler>();
    builder.Services.AddTransient<EquipmentParameterHandler, EquipmentParameterHandler>();
    builder.Services.AddTransient<ParameterHandler, ParameterHandler>();
    builder.Services.AddTransient<ParameterGroupHandler, ParameterGroupHandler>();
    builder.Services.AddTransient<VirtualParameterHandler, VirtualParameterHandler>();
    builder.Services.AddTransient<AlarmEmailHandler, AlarmEmailHandler>();
}