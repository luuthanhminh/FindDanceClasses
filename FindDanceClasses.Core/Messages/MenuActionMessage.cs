using System;
using MvvmCross.Plugin.Messenger;

namespace FindDanceClasses.Core.Messages
{
    public class MenuActionMessage : MvxMessage
    {
        public MenuActionMessage(object sender, bool isOpen)
    : base(sender)
        {
            IsOpen = isOpen;
        }
        public bool IsOpen { get; set; }
    }
}
