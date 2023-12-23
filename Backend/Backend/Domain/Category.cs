namespace Backend.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public DateOnly CreationDate { get; set; }
        public string Description { get; set; }
    }
}
