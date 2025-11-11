using System;

namespace GreenGuard.Models
{
    public class Donation
    {
        public string DonorName { get; set; }         
        public SponsorableItem SponsoredItem { get; set; }   
        public int Amount { get; set; }              
        public string PaymentMethod { get; set; }       
        public string Note { get; set; }                 
        public DateTime Date { get; set; } = DateTime.Now;
 
        public string DisplaySummary => $"{SponsoredItem?.Title} - {Amount} BDT via {PaymentMethod}";
    }
}
