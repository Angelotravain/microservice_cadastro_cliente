using Autofac.Extensions.DependencyInjection;
using Autofac;
using ClienteService.Data;
using Microsoft.EntityFrameworkCore;
using ClienteService.Ioc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new AutoFacModule());
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ClienteContexto>(options =>
    options.UseSqlServer(connectionString, sqlOptions =>
    {
        sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
        sqlOptions.MigrationsAssembly("ClienteService");
    }));

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowPort5000", builder =>
    {
        builder.WithOrigins("http://localhost:5000, https://localhost:5001")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MapConfigProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cliente Service", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cliente Service v1"));
}

app.UseCors("AllowPort5000");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
