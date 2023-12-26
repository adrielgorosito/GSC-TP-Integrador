using Backend.DataAccess;
using Backend.DataAccess.UnitOfWork;
using Backend.Services;
using Backend;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LoanDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("LoanDb")));
builder.Services.AddControllers();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddEndpointsApiExplorer().AddSwaggerGen();

builder.Services.AddGrpc(opt => opt.EnableDetailedErrors = true); // -----------------
builder.Services.AddGrpcReflection(); // ---------------------------------------------

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGrpcService<LoansService>();      // ---------------------------------------------
app.MapGrpcReflectionService(); // ---------------------------------------------
app.MapGet("/api/loan/change", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.MapControllers();
app.Run();