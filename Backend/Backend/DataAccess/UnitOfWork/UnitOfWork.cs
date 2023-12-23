using Backend.DataAccess.Generic;
using Backend.DataAccess.Repositories;

namespace Backend.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private LoanDbContext context;

        public CategoriesRepository CategoriesRepository { get; set; }
        public LoansRepository LoansRepository { get; set; }
        public PeopleRepository PeopleRepository { get; set; }
        public ThingsRepository ThingsRepository { get; set; }

        public UnitOfWork(LoanDbContext context)
        {
            this.context = context;

            this.CategoriesRepository = new CategoriesRepository(context);
            this.LoansRepository = new LoansRepository(context);
            this.PeopleRepository = new PeopleRepository(context);
            this.ThingsRepository = new ThingsRepository(context);
        }

        public void SaveChangesAsync()
        {
            this.context.SaveChangesAsync();
        }
    }
}
