using Backend.DataAccess;
using Backend.DataAccess.Repositories;
using Backend.Domain;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

using var context = new LoanDbContext();

LoanRepository loanRep = new LoanRepository(context);
Loan? l = await loanRep.GetOne(1);

// First database call test
Console.WriteLine("Id: " + l.Id + " - FechaPrest: " + l.Date + " - FechaEntr: " + l.ReturnDate);
Console.WriteLine("Persona: " + l.Person.Dni);
Console.WriteLine("Cosa: " + l.Thing.Description);

ThingRepository thingRep = new ThingRepository(context);
Thing? th = await thingRep.GetOne(2);
Console.WriteLine("Desc: " + th.Description + " - Categoría: " + th.Category.Description);

// app.Run();