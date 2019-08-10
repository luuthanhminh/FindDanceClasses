using System;
using MvvmCross.ViewModels;

namespace FindDanceClasses.Core.ViewModels.Items
{
    public class BaseItemViewModel : MvxViewModel
    {
        public MvxViewModel ParentViewModel { get; set; }
    }
}
