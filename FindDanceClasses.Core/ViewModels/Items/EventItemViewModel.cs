using System;
using System.Threading.Tasks;
using MvvmCross.Commands;

namespace FindDanceClasses.Core.ViewModels.Items
{
    public class EventItemViewModel : BaseItemViewModel
    {
        public int ClassID { get; set; }


        private bool _isClassLive;
        public bool IsClassLive
        {
            get
            {
                return _isClassLive;
            }
            set
            {
                SetProperty(ref _isClassLive, value);
            }
        }

        private bool _isInPast;
        public bool IsInPast
        {
            get
            {
                return _isInPast;
            }
            set
            {
                SetProperty(ref _isInPast, value);
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

        private string _venueAddress;
        public string VenueAddress
        {
            get
            {
                return _venueAddress;
            }
            set
            {
                SetProperty(ref _venueAddress, value);
            }
        }

        private string _imageUrl;
        public string ImageUrl
        {
            get
            {
                return _imageUrl;
            }
            set
            {
                SetProperty(ref _imageUrl, value);
            }
        }

        //public IMvxAsyncCommand GoToCheckInCommand => new MvxAsyncCommand(GoToCheckIn);

        //private async Task GoToCheckIn()
        //{
        //    if (this.ParentViewModel is EventsViewModel eventsViewModel)
        //    {
        //        await eventsViewModel.GoToCheckIn(this);
        //    }
        //}
    }
}
