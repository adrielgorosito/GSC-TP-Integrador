using Backend.DataAccess.Generic;
using Backend.Domain;

namespace Backend.DataAccess.Repositories
{
    public class PeopleRepository : GenericRepository<Person>
    {
        public PeopleRepository(LoanDbContext context) : base(context) { }
    }
}
