using backend.IServices;
using backend.Models;
using core.DBContext;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class DemoService : IDemoService
    {
        private SqlDBContext _context;
        public DemoService(SqlDBContext context)
        {
            _context = context;
        }
        public async Task<ToItem> AddTodoItem(ToItem todoItem)
        {
            var DbSet = _context.GetDbSet<ToItem>();
            await DbSet.AddAsync(todoItem);
            await _context.SaveChangesAsync();
            return todoItem;
        }

        public async Task<ToItem> DeleteToItem(long id)
        {
            var DbSet = _context.GetDbSet<ToItem>();
            var entity = await DbSet.FirstOrDefaultAsync(t => t.Id.Equals(id));
            if (entity != null)
            {
                DbSet.Remove(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            else
            {
                return new ToItem();
            }
        }

        public async Task<List<ToItem>> getTodoItems()
        {
            var todoItem = _context.GetDbSet<ToItem>();
            var query = from t in todoItem.AsNoTracking()
                        select new ToItem
                        {
                            Id = t.Id,
                            Name = t.Name,
                            Sex = t.Sex
                        };
            var list = await query.ToListAsync();
            return list;
        }
    }
}
