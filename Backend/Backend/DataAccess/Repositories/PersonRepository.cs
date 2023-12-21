using Backend.DataAccess.Generic;
using Backend.Domain;

namespace Backend.DataAccess.Repositories
{
    public class PersonRepository : GenericRepository<Person>
    {
        public PersonRepository(LoanDbContext context) : base(context) { }
    }
}
