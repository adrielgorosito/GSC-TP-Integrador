namespace Backend.Domain
{
    public class Thing
    {
        public int Id { get; set; }
        public DateOnly CreationDate { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
    }
}
