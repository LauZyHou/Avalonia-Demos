using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using System.Reactive;
using Todo._Ms;

namespace Todo._VMs
{
    // 添加事项的VM,添加事项所涉及的数据只有一个描述(用户写在文本框里),所以这里也就这一个字段
    class AddItem_VM : ViewModelBase
    {
        private string description;

        public AddItem_VM()
        {
            // Description已启用更改通知,使用WhenAnyValue将属性转换为IObservable形式的值流
            // 目的是对于Description的初始值和后续更改,当其不为空时才显示Ok按钮
            IObservable<bool> okEnabled = this.WhenAnyValue(
                x => x.Description,
                x => !string.IsNullOrWhiteSpace(x)
                );

            // Ok按下的命令
            Ok = ReactiveCommand.Create(
                () => new TodoItem { Description = Description }, // 无参,调用时创建一个TodoItem项
                okEnabled); // 命令的可用状态,这里意味当okEnable为真时Ok命令才可用 

            // Cancel按下的命令
            Cancel = ReactiveCommand.Create(
                () => { } // 无参,调用时什么都不做
                ); // 任何时候都允许按下
        }

        // View里要将文本框绑定到这个属性上面来
        // 这里在内容发生变化时向View发出通知
        public string Description
        { 
            get => description;
            set => this.RaiseAndSetIfChanged(ref description, value);
        }

        // 用于绑定给Ok和Cancel按钮的命令执行
        /*
         ReactiveCommand的第二个type参数指定执行命令时产生的结果类型
         Ok生成TodoItem，而Cancel生成Unit
         Unit是void的Reactive形式，这意味着该命令不产生任何值。
         */
        public ReactiveCommand<Unit, TodoItem> Ok { get; }
        public ReactiveCommand<Unit, Unit> Cancel { get; }
    }
}
