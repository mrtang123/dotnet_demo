using backend.Models;

namespace backend.IServices
{
    public interface IDemoService
    {
        Task<ToItem> AddTodoItem(ToItem todoItem);
        Task<ToItem> DeleteToItem(long id);
        Task<List<ToItem>> getTodoItems();
    }
}
