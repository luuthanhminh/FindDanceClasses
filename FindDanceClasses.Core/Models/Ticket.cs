using System;
namespace FindDanceClasses.Core.Models
{
    public class Ticket
    {
        public int SingleChargeItemID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsCheckedIn { get; set; }

        public string Name { get; set; }

        public string QrCode { get; set; }
    }
}
