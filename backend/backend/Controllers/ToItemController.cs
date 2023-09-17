using backend.IServices;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/toItem")]
    public class ToItemController : ControllerBase
    {
        private readonly ILogger<ToItemController> _logger;

        public ToItemController(ILogger<ToItemController> logger, IDemoService DemoService)
        {
            _logger = logger;
            this.DemoService = DemoService;
        }

        private IDemoService DemoService;

        [HttpPost]
        public async Task<ToItem> PostTodoItem(ToItem todoItem)
        {
            var result = await DemoService.AddTodoItem(todoItem);
            return result;
        }

        [HttpGet]
        public async Task<List<ToItem>> GetTodoItem()
        {
           var todoItems = await DemoService.getTodoItems();
           return todoItems;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ToItem> DeleteTodoItem(long id)
        {
            var toItem = await DemoService.DeleteToItem(id);
            return toItem;
        }
    }
}