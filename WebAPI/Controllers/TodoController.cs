using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        ITodoService _todoService;
        public TodoController(ITodoService service)
        {
            _todoService = service;
        }
        /// <summary>
        /// get all todo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllTodo()
        {
            try
            {
                var todo = _todoService.GetTodoList();
                if (todo == null) return NotFound();
                return Ok(todo);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// get todo details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetTodoById(int id)
        {
            try
            {
                var todo = _todoService.GetTodoDetailsById(id);
                if (todo == null) return NotFound();
                return Ok(todo);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// save todo
        /// </summary>
        /// <param name="todoModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveTodo(Todo todoModel)
        {
            try
            {
                var model = _todoService.SaveTodo(todoModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// delete todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteTodo(int id)
        {
            try
            {
                var model = _todoService.DeleteTodo(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }




}
