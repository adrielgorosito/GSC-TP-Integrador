namespace Backend.Domain
{
    public class Thing
    {
        public DateOnly CreationDate { get; set; }
        public string? Description { get; set; }
        public Category Category { get; set; }
    }
}
