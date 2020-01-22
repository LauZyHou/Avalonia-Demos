using System;
using System.Collections.Generic;
using System.Text;
using Todo.Services;

namespace Todo._VMs
{
    // 因为TodoList放在主窗体里,所以在主窗体的VM中要集成TodoList的VM
    public class MainWindow_VM : ViewModelBase
    {
        // 在构造时从DataBase里取TodoList的VM
        public MainWindow_VM(Database db)
        {
            TodoListVM = new TodoList_VM(db.GetItems());
        }

        //public string Greeting => "Welcome to Avalonia!";
        public TodoList_VM TodoListVM { get; set; }
    }
}
