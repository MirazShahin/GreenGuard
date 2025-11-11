using System.Collections.ObjectModel;
using GreenGuard.Models;

namespace GreenGuard.Services
{
    public class DonationService
    {
        public static DonationService Current { get; } = new DonationService();

        public ObservableCollection<SponsorableItem> Catalog { get; } = new();
        public ObservableCollection<Donation> Donations { get; } = new();

        private DonationService()
        {
            Catalog.Add(new SponsorableItem
            {
                Title = "Zone A – Mango Plantation",
                Description = "Plant 100 Mango saplings near school area.",
                Zone = "Zone A",
                TreeType = "Mango",
                TargetTrees = 100,
                SuggestedAmount = 1500,
                CoverEmoji = "🥭"
            });
            Catalog.Add(new SponsorableItem
            {
                Title = "Zone B – Neem Belt",
                Description = "Green belt with Neem along roadside.",
                Zone = "Zone B",
                TreeType = "Neem",
                TargetTrees = 200,
                SuggestedAmount = 2000,
                CoverEmoji = "🌿"
            });
            Catalog.Add(new SponsorableItem
            {
                Title = "Zone C – Mixed Species",
                Description = "Community park plantation (mixed).",
                Zone = "Zone C",
                TreeType = "Mixed",
                TargetTrees = 150,
                SuggestedAmount = 1800,
                CoverEmoji = "🌱"
            });
        }

        public void AddDonation(Donation d) => Donations.Add(d);
    }
}
