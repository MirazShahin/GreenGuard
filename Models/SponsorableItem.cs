namespace GreenGuard.Models
{
    public class SponsorableItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Zone { get; set; }
        public string TreeType { get; set; }           // ✅ Needed by DonationService
        public int TargetTrees { get; set; }
        public int SponsoredTrees { get; set; }
        public int SuggestedAmount { get; set; }       // ✅ Needed by DonationService
        public string CoverEmoji { get; set; }         // ✅ Needed by DonationService
        public string Image { get; set; }

        public double Progress => TargetTrees == 0 ? 0 : (double)SponsoredTrees / TargetTrees;
    }
}
