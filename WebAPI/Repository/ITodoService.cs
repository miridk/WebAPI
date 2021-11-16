using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.ViewModels;

namespace WebAPI.Repository
{
    public interface ITodoService
    {
         
        /// <summary>
        /// get list of all Todos
        /// </summary>
        /// <returns></returns>
        List<Todo> GetTodoList();

        /// <summary>
        /// get todo details by todo id
        /// </summary>
        /// <param //name="todoId"></param>
        /// <returns></returns>
        Todo GetTodoDetailsById(int todoId);

        /// <summary>
        ///  add edit todo
        /// </summary>
        /// <param //name="todoModel"></param>
        /// <returns></returns>
        ResponseModel SaveTodo(Todo todoModel);


        /// <summary>
        /// delete todo
        /// </summary>
        /// <param //name="todoId"></param>
        /// <returns></returns>
        ResponseModel DeleteTodo(int todoId);
    }
}

