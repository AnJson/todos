namespace Todos.Model.DTO.Todo

{
    public class TodoCreate
    {
        public string Title { get; }
        public string Description { get; }
        public bool Done { get; }

        public TodoCreate(string title, string description, bool done)
        {
            Title = title;
            Description = description;
            Done = done;
        }
    }
}