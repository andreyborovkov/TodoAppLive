using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAppLive.Models;

namespace TodoAppLive
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetAll();
        Todo GetById(int id);
        void Create(Todo userTodoData);
        void Delete(Todo toDelete);
    }
}
