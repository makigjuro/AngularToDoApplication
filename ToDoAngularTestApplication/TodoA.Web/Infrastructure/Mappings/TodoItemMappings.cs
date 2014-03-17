using TodoA.Model.Entities;
using TodoA.Web.Models.Todo;

namespace TodoA.Web.Infrastructure.Mappings
{
    /// <summary>
    /// Contains mappings for the To do Item entity, both to and from.
    /// </summary>
    public class TodoItemMappings
    {
        public static TodoItemDto GetTodoItemDto(TodoItem entityObject)
        {
            return new TodoItemDto()
                   {
                       CreatedOn = entityObject.CreatedOn,
                       FinishBefore = entityObject.FinishBefore,
                       Status = entityObject.Status,
                       Text = entityObject.Text
                   };
        }
    }
}