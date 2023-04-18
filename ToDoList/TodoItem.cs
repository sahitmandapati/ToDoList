namespace ToDoList
{
    // define the TodoItem class, which represents a to-do list item
    public class TodoItem
    {
        // define an automatically generated unique identifier for the to-do list item
        public Guid Id { get; set; } = Guid.NewGuid();

        // define the title of the to-do list item
        public string Title { get; set; } = null!;

        // define the description of the to-do list item
        public string Description { get; set; } = null!;

        // define the category of the to-do list item using an enumeration
        public Category Category { get; set; }

        // define a boolean flag indicating whether the to-do list item has been completed
        public bool IsDone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    // define an enumeration to represent the possible categories of a to-do list item
    public enum Category
    {
        Urgent,
        Important,
        Normal
    }
}
