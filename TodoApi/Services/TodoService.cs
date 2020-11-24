using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Interface;
using TodoApi.Models;

namespace TodoApi.Services
{
    public class TodoService : ITodoService
    {
        
        private TodoContext _context;
        
        public TodoService(TodoContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<TodoItem>> GetItemsListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> GetItemByIdAsync(long id)
        {
            throw new NotImplementedException();

        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();

        }
    }
}
