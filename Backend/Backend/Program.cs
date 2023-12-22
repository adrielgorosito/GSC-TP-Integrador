using Backend.DataAccess;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

using var context = new LoanDbContext();



app.Run();