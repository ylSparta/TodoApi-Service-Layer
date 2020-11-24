using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Interface;
using TodoApi.Models;

namespace TodoApi.Interface
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItem>> GetItemsListAsync();

        Task<TodoItem> GetItemByIdAsync(long id);

        Task SaveChangesAsync();
    }
}
