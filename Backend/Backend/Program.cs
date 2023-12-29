using Backend.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddCors();
builder.AddAuthentication();
builder.AddConfig();
builder.Services.AddEndpointsApiExplorer().AddSwaggerGen();
builder.AddGrpc();

var app = builder.Build();

app.UseCors("AllowOrigin");
app.AddSwagger();
app.AddGrpc();
app.MapControllers();
app.Run();