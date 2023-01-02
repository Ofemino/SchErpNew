using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using SchoolERP.Persistent.DataContext;
using SchoolERP.Persistent.IRepositories;
using SchoolERP.Persistent.Repositories;
using SchoolERP.Services;
using SchoolERP.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

//register nlog
var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    //register dbContext
    builder.Services.AddDbContextPool<SchoolErpDbContext>(option =>
        option.UseSqlServer(builder.Configuration.GetConnectionString("")));
    
    //register automapper
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
   
    
    //register repositories to the container.
    builder.Services.AddSingleton<IStaffRepository, StaffRepository>();
    builder.Services.AddSingleton<IStaffRepository, StaffRepository>();
    builder.Services.AddSingleton<IParentRepository, ParentRepository>();

     
    //register services to the container.
    builder.Services.AddSingleton<IStaffServices, StaffServices>();
    builder.Services.AddSingleton<IStudentServices, StudentServices>();
    builder.Services.AddSingleton<IParentServices, ParentServices>();

    
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    //NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();

    var app = builder.Build();

    //Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    LogManager.Shutdown();
}