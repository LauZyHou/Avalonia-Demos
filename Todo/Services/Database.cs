using System.Collections.Generic;
using Todo._Ms;

namespace Todo.Services
{
    // 假的数据库,接口中模拟返回若干个列表项
    public class Database
    {
        public IEnumerable<TodoItem> GetItems() => new[]
        {
            new TodoItem { Description = "Walk the dog" },
            new TodoItem { Description = "Buy some milk" },
            new TodoItem { Description = "Learn Avalonia", IsChecked = true },
        };
    }
}