namespace ToDoListMVC.Models
{
    public class ToDoItem
    {
        
        public string? ToDoTask { get; set; }
        public bool IsCompleted { get; set; } = false;

        public ToDoItem()
        {

        }
        public ToDoItem(string toDoTask)
        {
            ToDoTask = toDoTask;
        }
    }
}
