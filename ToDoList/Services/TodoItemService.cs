namespace ToDoList.Services
{
    public class TodoItemService
    {
        private List<TodoItem> _todoItems = new();

        public TodoItem? FindById(Guid guid)
        {
            return _todoItems.SingleOrDefault(x => x.Id == guid);

        }

        public List<TodoItem> GetAll()
        {
            return _todoItems;
        }

        public TodoItem Add(TodoItem item)
        {

            TodoItem item2 = new TodoItem();
            item2.Title = item.Title;
            item2.Description = item.Description;
            item2.Category = item.Category;
            item2.CreatedAt = DateTime.Now;
            item2.UpdatedAt = DateTime.Now;
            _todoItems.Add(item2);

            return item2;
        }

        public TodoItem? Remove(Guid id)
        {
            var item = _todoItems.SingleOrDefault(x=>x.Id==id);
            if (item is null)
            {
                return null;
            }
            _todoItems.Remove(item);
            return item;
        }

        public TodoItem? Update(Guid id, TodoItem updatedItem)
        {
            var item = _todoItems.SingleOrDefault(x => x.Id == id);
            if (item == null)
            {
                return null;
            }

            item.Title = updatedItem.Title;
            item.Description = updatedItem.Description;
            item.Category = updatedItem.Category;
            item.UpdatedAt = DateTime.Now;

            return item;
        }

    }
}
