using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TodoA.Web.Models.Todo;

namespace TodoA.Web.Controllers.api
{
    public class TodoListDataController : ApiController
    {
        #region Properties

        /*
         * Seeing as this example is more focused on  front end and Angular we will be using a 
         */

        #endregion

        #region Actions

        /// <summary>
        /// Get all to do lists
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TodoListDisplayDto> Get()
        {
            return GetTestTodoListData();
        }

        /// <summary>
        /// GET Details for a single to do List
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TodoListDetailsDto Get(int id)
        {
            return GetDetailsDto(id);
        }

        /// <summary>
        /// POST Details for creating a new to do list
        /// </summary>
        /// <param name="listName"></param>
        /// <returns></returns>
        public TodoListDisplayDto Post(string listName)
        {
            return new TodoListDisplayDto();
        }

        #endregion

        #region Mock Data

        #region Lists

        private IEnumerable<TodoListDisplayDto> GetTestTodoListData()
        {
            return new List<TodoListDisplayDto>()
            {
                GetSingleTodoListViewModel (1, "Groceries",  DateTime.Now.AddDays(-2), 2,  4 ),
                GetSingleTodoListViewModel (2, "Shopping",  DateTime.Now.AddDays(-4), 6,  2 ),
                GetSingleTodoListViewModel (3, "Work",  DateTime.Now.AddDays(-6), 1,  12 ),
                GetSingleTodoListViewModel (4, "Party",  DateTime.Now.AddDays(-1),  10,  20)
            };
        }

        private TodoListDisplayDto GetSingleTodoListViewModel(int id, string title, DateTime dateCreated, int completedItems, int remainingItems)
        {
            return new TodoListDisplayDto()
            {
                Id = id,
                Title = title,
                DateCreated = dateCreated,
                RemainingItems = remainingItems,
                CompletedItems = completedItems
            };
        }

        #endregion

        #region List Details and Items

        private TodoListDetailsDto GetDetailsDto(int id)
        {
            var list = GetTestTodoListData().FirstOrDefault(t => t.Id == id);
            
            if (list == null)
            {
                return null;
            }
            else
            {
                return new TodoListDetailsDto()
                {
                    Title = list.Title,
                    CompletedItems = list.CompletedItems,
                    RemainingItems = list.RemainingItems,
                    DateCreated = list.DateCreated,
                    Id = id,
                    Items = GenerateTodoItems()
                };
            }
        }

        private List<TodoItemDto> GenerateTodoItems()
        {
            return new List<TodoItemDto>()
            {
                GetTodoItemDto("Run", false, DateTime.Now.AddDays(-10),null),
                GetTodoItemDto("Ride Bikes", false, DateTime.Now.AddDays(-2),DateTime.Now.AddDays(6)),
                GetTodoItemDto("Learn Angular", true, DateTime.Now.AddDays(-3),null),
                GetTodoItemDto("Solution", true, DateTime.Now.AddDays(-4),null),
                GetTodoItemDto("Watch Kevin Heart", true, DateTime.Now.AddDays(-5),DateTime.Now.AddDays(5)),
                GetTodoItemDto("Drink Coffeee", false, DateTime.Now.AddDays(-11), DateTime.Now.AddDays(2)),
            };
        }

        private TodoItemDto GetTodoItemDto(string text, bool status, DateTime createTime, DateTime? finishBefore)
        {
            return new TodoItemDto()
            {
                Text = text,
                Status = status,
                CreatedOn = createTime,
                FinishBefore = finishBefore
            };
        }

        #endregion

        #endregion
    }
}