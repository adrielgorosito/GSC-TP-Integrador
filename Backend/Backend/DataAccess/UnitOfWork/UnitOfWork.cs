using Backend.DataAccess.Generic;
using Backend.DataAccess.Repositories;

namespace Backend.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private LoanDbContext context;

        public CategoryRepository CategoryRepository { get; set; }
        public LoanRepository LoanRepository { get; set; }
        public PersonRepository PersonRepository { get; set; }
        public ThingRepository ThingRepository { get; set; }

        public UnitOfWork(LoanDbContext context)
        {
            this.context = context;

            this.CategoryRepository = new CategoryRepository(context);
            this.LoanRepository = new LoanRepository(context);
            this.PersonRepository = new PersonRepository(context);
            this.ThingRepository = new ThingRepository(context);
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

    }
}
