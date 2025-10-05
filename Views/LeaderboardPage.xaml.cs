namespace GreenGuard.Views
{
    public partial class LeaderboardPage : ContentPage
    {
        public LeaderboardPage()
        {
            InitializeComponent();

            // Dummy Data (Later DB থেকে আসবে)
            var volunteers = new List<VolunteerPerformance>
            {
                new VolunteerPerformance { VolunteerName="Alamin", Zone="Zone A", Points=120 },
                new VolunteerPerformance { VolunteerName="Sadia", Zone="Zone B", Points=95 },
                new VolunteerPerformance { VolunteerName="Rakib", Zone="Zone C", Points=80 },
                new VolunteerPerformance { VolunteerName="Mitu", Zone="Zone A", Points=60 },
                new VolunteerPerformance { VolunteerName="Jannat", Zone="Zone D", Points=50 }
            };

            // Ranking logic
            var ranked = volunteers
                .OrderByDescending(v => v.Points)
                .Select((v, index) =>
                {
                    v.Rank = index + 1;
                    v.RankColor = v.Rank == 1 ? "Gold" : "Yellow"; // Top performer highlight
                    return v;
                })
                .ToList();

            LeaderboardCollectionView.ItemsSource = ranked;
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }

    // Model
    public class VolunteerPerformance
    {
        public int Rank { get; set; }
        public string VolunteerName { get; set; }
        public string Zone { get; set; }
        public int Points { get; set; }

        public string PointsText => $"Points: {Points}";
        public string RankColor { get; set; } // For UI binding
    }
}
