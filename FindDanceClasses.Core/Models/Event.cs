using System;
namespace FindDanceClasses.Core.Models
{
    public class Event
    {
        public int ClassID { get; set; }

        public string Name { get; set; }

        public string ProviderType { get; set; }

        public string PleaseSelectHidden { get; set; }

        public string Description { get; set; }

        public int LocationID { get; set; }

        public int CompanyID { get; set; }

        public int EmailID { get; set; }

        public int WebsiteID { get; set; }

        public int PhoneID { get; set; }

        public int ProviderTypeID { get; set; }

        public int ProviderPriceScheme { get; set; }

        public bool IsClassLive { get; set; }

        public string CompanyName { get; set; }

        public string VenueAddress { get; set; }
    }
}
