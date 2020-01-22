using System;
using System.Collections.Generic;
using System.Text;

namespace Todo._Ms
{
    // 待办列表的列表项的数据模型,有一个描述字段和一个bool字段
    public class TodoItem
    {
        public string Description { get; set; }
        public bool IsChecked { get; set; }
    }
}
