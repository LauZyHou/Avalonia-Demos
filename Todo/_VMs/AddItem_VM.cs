using System;
using System.Collections.Generic;
using System.Text;

namespace Todo._VMs
{
    // 添加事项的VM,添加事项所涉及的数据只有一个描述(用户写在文本框里),所以这里也就这一个字段
    class AddItem_VM : ViewModelBase
    {
        // View里要将文本框绑定到这个属性上面来
        public string Description { get; set; }
    }
}
