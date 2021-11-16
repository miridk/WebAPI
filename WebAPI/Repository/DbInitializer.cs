using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class DbInitializer
    {
      
            public static void Initialize(TodoContext context)
            {
                context.Database.EnsureCreated();
                
                // Look for any students.
                if (context.Todo.Any())
                {
                    return;   // DB has been seeded
                }

                var todo = new Todo[]
                {
            new Todo{TodoId=1, TodoTask="Milk", Amount=2 }
                };
                foreach (Todo s in todo)
                {
                    context.Todo.Add(s);
                }
                context.SaveChanges();



            
        }
    }
}
