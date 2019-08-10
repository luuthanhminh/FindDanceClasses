using System;
using MvvmCross.Plugin.Messenger;

namespace FindDanceClasses.Core.Messages
{
    public class TabMessage : MvxMessage
    {
        public int TabIndex { get; set; }

        public TabMessage(object sender, int tabIndex) : base(sender)
        {
            this.TabIndex = tabIndex;
        }
    }
}
