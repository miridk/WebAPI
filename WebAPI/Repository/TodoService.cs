using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.ViewModels;

namespace WebAPI.Repository
{
    
    public class TodoService: ITodoService
    {
        private TodoContext _context;
        public TodoService(TodoContext context)
        {
            _context = context;
        }

        /// <summary>
        /// get list of all todo
        /// </summary>
        /// <returns></returns>
        public List<Todo> GetTodoList()
        {
            List<Todo> todoList;
            try
            {
                todoList = _context.Set<Todo>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return todoList;
        }

        /// <summary>
        /// get todo details by todo id
        /// </summary>
        /// <param name="todoId"></param>
        /// <returns></returns>
        public Todo GetTodoDetailsById(int todoId)
        {
            Todo todo;
            try
            {
                todo = _context.Find<Todo>(todoId);
            }
            catch (Exception)
            {
                throw;
            }
            return todo;
        }

        /// <summary>
        ///  add edit todo
        /// </summary>
        /// <param name="todoModel"></param>
        /// <returns></returns>
        public ResponseModel SaveTodo(Todo todoModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Todo _temp = GetTodoDetailsById(todoModel.TodoId);
                if (_temp != null)
                {
                    _temp.TodoTask = todoModel.TodoTask;
                    _temp.Amount = todoModel.Amount;
                    _context.Update<Todo>(_temp);
                    model.Messsage = "Todo Update Successfully";
                }
                else
                {
                    _context.Add<Todo>(todoModel);
                    model.Messsage = "Todo Inserted Successfully";
                }
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        /// <summary>
        /// delete todo
        /// </summary>
        /// <param name="TodoId"></param>
        /// <returns></returns>
        public ResponseModel DeleteTodo(int todoId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Todo _temp = GetTodoDetailsById(todoId);
                if (_temp != null)
                {
                    _context.Remove<Todo>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Todo Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Todo Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
    }
}
