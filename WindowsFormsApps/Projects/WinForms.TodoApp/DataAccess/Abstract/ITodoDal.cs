using System.Collections.Generic;
using WinForms.TodoApp.Entities.Concrete;
using WinForms.TodoApp.Enums;

namespace WinForms.TodoApp.DataAccess.Abstract
{
    public interface ITodoDal
    {
        int Count();
        int Add(TodoEntity data);
        List<TodoEntity> GetAll();
        List<TodoEntity> GetAll(Status status);
    }
}