using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Todo._Ms;

namespace Todo._VMs
{
    // 待办列表的ViweModel,集成多个列表项,在构造时就将列表传入进来
    public class TodoList_VM : ViewModelBase
    {
        public TodoList_VM(IEnumerable<TodoItem> items)
        {
            Items = new ObservableCollection<TodoItem>(items);
        }

        public ObservableCollection<TodoItem> Items { get; set; }
    }
}
