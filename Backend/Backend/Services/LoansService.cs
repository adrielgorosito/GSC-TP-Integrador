using Backend.DataAccess.UnitOfWork;
using Backend.Domain;
using Grpc.Core;

namespace Backend.Services
{
    public class LoansService : LoanStatusService.LoanStatusServiceBase
    {
        private IUnitOfWork Uow;

        public LoansService(IUnitOfWork uow)
        {
            this.Uow = uow;
        }

        public override async Task<LoanStatusResponse> ChangeStatus(LoanStatusRequest request, ServerCallContext context)
        {
            var loan = await Uow.LoansRepository.GetOne(int.Parse(request.Id));

            if (loan == null)
                throw new Exception("Error: loan not found");

            if (loan.ReturnDate != null)
                return new LoanStatusResponse
                {
                    Message = "The loan already has a status: " + loan.Status
                };

            // ReturnDate will be assigned today's date
            DateOnly todaysDate = DateOnly.FromDateTime(DateTime.Now);
            loan.ReturnDate = todaysDate;

            int daysDifference = (todaysDate.DayNumber - loan.Date.DayNumber);

            if (daysDifference <= 10)
                loan.Status = LoanStatus.Returned;
            else
                loan.Status = LoanStatus.ReturnedLate;

            try
            {
                await Uow.LoansRepository.Update(loan);
                Uow.SaveChangesAsync();

                return new LoanStatusResponse
                {
                    Message = "The loan status has been successfully changed."
                };
            }
            catch (Exception e)
            {
                return new LoanStatusResponse
                {
                    Message = "Error: " + e.Message
                };
            }
        }
    }
}
