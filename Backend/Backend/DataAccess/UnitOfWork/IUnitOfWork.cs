using Backend.DataAccess.Generic;

namespace Backend.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
        void Dispose();
    }
}
