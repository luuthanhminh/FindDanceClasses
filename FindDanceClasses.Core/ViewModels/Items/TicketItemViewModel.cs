using System;
namespace FindDanceClasses.Core.ViewModels.Items
{
    public class TicketItemViewModel : BaseItemViewModel
    {
        public string QrCode { get; set; }


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


    }
}
