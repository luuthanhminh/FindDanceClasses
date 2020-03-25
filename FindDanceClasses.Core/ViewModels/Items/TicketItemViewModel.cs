using System;
using System.Threading.Tasks;
using MvvmCross.Commands;

namespace FindDanceClasses.Core.ViewModels.Items
{
    public class TicketItemViewModel : BaseItemViewModel
    {
        public string QrCode { get; set; }
        public int Index { get; set; }

        public bool IsInPopup { get; set; }

        private bool _isCheckedIn;
        public bool IsCheckedIn
        {
            get
            {
                return _isCheckedIn;
            }
            set
            {
                SetProperty(ref _isCheckedIn, value);
                IsNotCheckedIn = !value;
            }
        }

        private bool _isNotCheckedIn;
        public bool IsNotCheckedIn
        {
            get
            {
                return _isNotCheckedIn;
            }
            set
            {
                SetProperty(ref _isNotCheckedIn, value);
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        private string _fullName;
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                SetProperty(ref _fullName, value);
            }
        }

        private string _displayName;
        public string DisplayName
        {
            get
            {
                return _displayName;
            }
            set
            {
                SetProperty(ref _displayName, value);
            }
        }

        private int _singleChargeItemID;
        public int SingleChargeItemID
        {
            get
            {
                return _singleChargeItemID;
            }
            set
            {
                SetProperty(ref _singleChargeItemID, value);
            }
        }

        private int _orderId;
        public int OrderId
        {
            get
            {
                return _orderId;
            }
            set
            {
                SetProperty(ref _orderId, value);
            }
        }

        public IMvxAsyncCommand ToggleCommand => new MvxAsyncCommand(Toggle);
        async Task Toggle()
        {
            this.IsCheckedIn = !this.IsCheckedIn;
            if (ParentViewModel is CheckinViewModel vm)
            {
                var result = await vm.ToggleChanged(this);
                if (!result) this.IsCheckedIn = !this.IsCheckedIn;
            }
        }
    }
}
