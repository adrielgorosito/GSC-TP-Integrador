using Backend.DataAccess.UnitOfWork;
using Backend.Domain;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private IUnitOfWork Uow;

        public LoansController(IUnitOfWork uow)
        {
            this.Uow = uow;
        }

        // GET api/loans/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Loan>?> GetLoanById(int id)
        {
            var loan = await Uow.LoansRepository.GetOne(id);

            if (loan == null)
                return this.BadRequest();
            return loan;
        }

        // GET api/loans
        [HttpGet]
        public async Task<ActionResult<List<Loan>?>> GetAllLoans()
        {
            return await Uow.LoansRepository.GetAll();
        }

        // POST api/loans
        [HttpPost]
        public async Task<ActionResult<int>> AddLoan(Loan loanToAdd)
        {
            var (success, loan) = await CheckIfThingAndPersonExists(loanToAdd);

            if (!success)
                return this.BadRequest();

            loan.Status = setStatus(loan);

            try
            {
                int id = await Uow.LoansRepository.Add(loan);
                Uow.SaveChangesAsync();
                return id;
            }
            catch (Exception e)
            {
                return this.BadRequest("Error: " + e.Message);
            }
        }

        // PUT api/loans
        [HttpPut]
        public async Task<ActionResult> UpdateLoan(Loan loanToUpdate)
        {
            var (success, loan) = await CheckIfThingAndPersonExists(loanToUpdate);

            if (!success)
                return this.BadRequest();

            loan.Status = this.setStatus(loan);

            try
            {
                await Uow.LoansRepository.Update(loan);
                Uow.SaveChangesAsync();
                return this.NoContent();
            }
            catch (Exception e)
            {
                return this.BadRequest("Error: " + e.Message);
            }
        }

        // DELETE api/loans/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLoan(int id)
        {
            var loan = await Uow.LoansRepository.GetOne(id);

            if (loan == null)
                return this.BadRequest();

            await Uow.LoansRepository.Delete(loan);
            Uow.SaveChangesAsync();
            return this.NoContent();
        }

        public async Task<(bool Success, Loan Loan)> CheckIfThingAndPersonExists(Loan loan)
        {
            var thing = await Uow.ThingsRepository.GetOne(loan.Thing.Id);
            var person = await Uow.PeopleRepository.GetOne(loan.Person.Dni);

            if (thing == null || person == null)
                return (false, null);

            loan.Thing = thing;
            loan.Person = person;

            return (true, loan);
        }

        public LoanStatus setStatus(Loan loan)
        {
            if (loan.ReturnDate == null)
                return LoanStatus.Pending;
            DateOnly returnDate = (DateOnly)loan.ReturnDate;
            int daysDifference = (int)(returnDate.DayNumber - loan.Date.DayNumber);

            if (daysDifference <= 10)
                return LoanStatus.Returned;
            else
                return LoanStatus.ReturnedLate;
        }
    }
}