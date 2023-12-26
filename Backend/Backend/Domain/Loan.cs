namespace Backend.Domain
{
    public class Loan
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public DateOnly? ReturnDate { get; set; }
        public LoanStatus Status { get; set; }
        public Person Person { get; set; }
        public Thing Thing { get; set; }
    }

    public enum LoanStatus
    {
        Pending = 1,
        Returned = 2,
        ReturnedLate = 3 // Only if the difference between ReturnDate and Date is greater than 10 days
    }
}
