using Backend.DataAccess;
using Backend.DataAccess.UnitOfWork;
using Backend.Services;
using Backend;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(
        "AllowOrigin",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );
});

builder.Services.AddDbContext<LoanDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("LoanDb")));
builder.Services.AddControllers();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddEndpointsApiExplorer().AddSwaggerGen();

builder.Services.AddGrpc(opt => opt.EnableDetailedErrors = true);
builder.Services.AddGrpcReflection();

var app = builder.Build();

app.UseCors("AllowOrigin");

app.UseSwagger();
app.UseSwaggerUI();

app.MapGrpcService<LoansService>();
app.MapGrpcReflectionService();

app.MapControllers();
app.Run();