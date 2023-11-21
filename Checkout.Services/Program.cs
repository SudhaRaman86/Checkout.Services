using Checkout.Repositoriess;
using Checkout.Services;
using Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddScoped<IRepository, Repository>();
//builder.Services.AddDbContext<DbContext>(options =>
//    options.UseSqlServer(connectionStringCore)
//    .EnableDetailedErrors()
//#if DEBUG
//     .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
//            .EnableSensitiveDataLogging()
//#endif
//);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
