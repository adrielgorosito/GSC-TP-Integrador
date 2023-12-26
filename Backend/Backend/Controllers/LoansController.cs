﻿using Backend.DataAccess.UnitOfWork;
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
        public async Task<ActionResult<int>> AddLoan(Loan loan)
        {
            var thing = await Uow.ThingsRepository.GetOne(loan.Thing.Id);
            var person = await Uow.PeopleRepository.GetOne(loan.Person.Dni);

            if (thing == null || person == null)
                return this.BadRequest();
            loan.Thing = thing;
            loan.Person = person;

            if (loan.ReturnDate != null)
            {
                DateOnly returnDate = (DateOnly) loan.ReturnDate;
                int daysDifference = (int)(returnDate.DayNumber - loan.Date.DayNumber);

                Console.WriteLine("Días diff:" + daysDifference);

                if (daysDifference <= 10)
                    loan.Status = LoanStatus.Returned;
                else
                    loan.Status = LoanStatus.ReturnedLate;
            } else
                loan.Status = LoanStatus.Pending;

            // This function is very long, consider moving part of it to a "LoansService" Layer

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
        public async Task<ActionResult> UpdateLoan(Loan loan)
        {
            var thing = await Uow.ThingsRepository.GetOne(loan.Thing.Id);
            var person = await Uow.PeopleRepository.GetOne(loan.Person.Dni);

            if (thing == null || person == null)
                return this.BadRequest();
            loan.Thing = thing;
            loan.Person = person;

            if (loan.ReturnDate != null)
            {
                DateOnly returnDate = (DateOnly)loan.ReturnDate;
                int daysDifference = (int)(returnDate.DayNumber - loan.Date.DayNumber);

                Console.WriteLine("Días diff:" + daysDifference);

                if (daysDifference <= 10)
                    loan.Status = LoanStatus.Returned;
                else
                    loan.Status = LoanStatus.ReturnedLate;
            }
            else
                loan.Status = LoanStatus.Pending;

            // This function is very long, consider moving part of it to a "LoansService" Layer

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
    }
}
