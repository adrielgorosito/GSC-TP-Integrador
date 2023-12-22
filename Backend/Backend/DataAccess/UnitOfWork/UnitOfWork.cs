using Backend.DataAccess.Generic;
using Backend.DataAccess.Repositories;

namespace Backend.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private LoanDbContext context;

        public CategoriesRepository CategoryRepository { get; set; }
        public LoansRepository LoanRepository { get; set; }
        public PeopleRepository PersonRepository { get; set; }
        public ThingsRepository ThingRepository { get; set; }

        public UnitOfWork(LoanDbContext context)
        {
            this.context = context;

            this.CategoryRepository = new CategoriesRepository(context);
            this.LoanRepository = new LoansRepository(context);
            this.PersonRepository = new PeopleRepository(context);
            this.ThingRepository = new ThingsRepository(context);
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
