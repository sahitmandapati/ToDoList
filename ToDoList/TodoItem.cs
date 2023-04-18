namespace ToDoList
{
    public class TodoItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Category Category { get; set; }
        public bool IsDone { get; set; }
    }

    public enum Category
    {
        Urgent,
        Important,
        Normal
    }

}
