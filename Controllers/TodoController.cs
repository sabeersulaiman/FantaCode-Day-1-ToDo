using System.Collections.Generic;
using FantaCode.Todoapi;
using FantaCode.Todoapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FantaCode.Todoapi
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {

        private readonly TodoRepository todoRepository;

        public TodoController()
        {
            todoRepository = new TodoRepository();
        }


        //Display all
        [HttpGet]
        public IEnumerable<Todo> Get() => todoRepository.GetAll();


        [HttpGet("{id}")]
        public Todo ViewbyID(int id)
        {
            if (ModelState.IsValid)
            {
                return todoRepository.View(id);
            }
            else return null;
        }

        // POST api/todo
        //Insert
        [HttpPost]
        public void Post([FromBody]Todo todo)
        {
            if (ModelState.IsValid)
                todoRepository.Add(todo);
        }

        // PUT api/todo/5
        //Update tasks and descrip
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Todo todo)
        {
            todo.TodoId = id;
            if (ModelState.IsValid)
                todoRepository.Update(todo);
        }

        [HttpPut("done/{id}")]
        public void DoneOnly(int id, [FromBody]Todo todo)
        {
            todo.TodoId = id;
            if (ModelState.IsValid)
                todoRepository.Done(todo);
        }

        //Delete
        [HttpDelete("{id}")]
        public void Delete(int id, [FromBody]Todo todo)
        {
            todo.TodoId = id;
            if (ModelState.IsValid)
                todoRepository.Delete(todo);
        }

        [HttpGet("done/{id}")]
        public void Done(int id)
        {
            todoRepository.Done(id);
        }
    }
}