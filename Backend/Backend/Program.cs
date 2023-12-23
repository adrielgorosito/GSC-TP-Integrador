using Backend.Controllers;
using Backend.DataAccess;
using Backend.DataAccess.Repositories;
using Backend.DataAccess.UnitOfWork;
using Backend.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LoanDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("LoanDb")));
builder.Services.AddControllers();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();
app.MapControllers();
app.Run();

//using var context = new LoanDbContext();

//LoansRepository loanRep = new LoansRepository(context);
//Loan? l = await loanRep.GetOne(1);

//// First database call test
//Console.WriteLine("Id: " + l.Id + " - FechaPrest: " + l.Date + " - FechaEntr: " + l.ReturnDate);
//Console.WriteLine("Persona: " + l.Person.Dni);
//Console.WriteLine("Cosa: " + l.Thing.Description);

//ThingsRepository thingRep = new ThingsRepository(context);
//Thing? th = await thingRep.GetOne(2);
//Console.WriteLine("Desc: " + th.Description + " - Categoría: " + th.Category.Description);

// app.Run();