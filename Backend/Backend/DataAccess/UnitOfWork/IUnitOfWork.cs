using Backend.DataAccess.Generic;
using Backend.DataAccess.Repositories;

namespace Backend.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        public CategoriesRepository CategoriesRepository { get; }
        public PeopleRepository PeopleRepository { get; }
        public ThingsRepository ThingsRepository { get; }
        public LoansRepository LoansRepository { get; }

        void Commit();
        void Dispose();
    }
}
