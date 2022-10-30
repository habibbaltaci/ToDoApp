using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Localization;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ToDoApp;

/* Inherit your application services from this class.
 */
 public  class ToDoAppAppService : ApplicationService,ITodoAppService
{
    private readonly IRepository<ToDoItem, Guid> _todoItemRepository;
    public ToDoAppAppService(IRepository<ToDoItem,Guid> todoItemRepository)
    {
        LocalizationResource = typeof(ToDoAppResource);
        _todoItemRepository = todoItemRepository;
    }

    public async Task<List<TodoItemDto>> GetListAsync()
    {
        var items = await _todoItemRepository.GetListAsync();
        return items
            .Select(item => new TodoItemDto
            {
                Id = item.Id,
                Text = item.Text
            }).ToList();
    }
    public async Task<TodoItemDto> CreateAsync(string text)
    {
        var todoItem = await _todoItemRepository.InsertAsync(
            new ToDoItem { Text = text }
        );

        return new TodoItemDto
        {
            Id = todoItem.Id,
            Text = todoItem.Text
        };
    }
    public async Task DeleteAsync(Guid id)
    {
        await _todoItemRepository.DeleteAsync(id);
    }

}
