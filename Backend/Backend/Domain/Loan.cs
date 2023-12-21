namespace Backend.Domain
{
    public class Loan
    {
        public DateOnly Date { get; set; }
        public DateOnly ReturnDate { get; set; }

        // status???

        public Person Person { get; set; }
        public Thing Thing { get; set; }
    }
}
