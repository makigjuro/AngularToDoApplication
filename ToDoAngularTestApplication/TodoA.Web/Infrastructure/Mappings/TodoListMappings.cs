using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoA.Model.Entities;
using TodoA.Web.Models.Todo;

namespace TodoA.Web.Infrastructure.Mappings
{
    /// <summary>
    /// Contains DTO - Entitiy two way mappings for the To do List object
    /// </summary>
    public class TodoListMappings
    {
        public static TodoListDetailsDto GetDetailsDtoFromEntity(TodoList todoList)
        {
            return new TodoListDetailsDto()
                   {
                       Title = todoList.Title,
                       CompletedItems = todoList.Items.Count(p => p.Status),
                       RemainingItems = todoList.Items.Count(p => !p.Status),
                       DateCreated = todoList.CreatedOn,
                       Id = todoList.Id,
                       Items = todoList.Items.Select(TodoItemMappings.GetTodoItemDto).ToList()
                   };
        }
    }
}