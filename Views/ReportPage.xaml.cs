namespace GreenGuard.Views
{
    public partial class ReportPage : ContentPage
    {
        public ReportPage()
        {
            InitializeComponent();

            // Dummy data (later DB থেকে আসবে)
            ZoneNameLabel.Text = "Zone: A";
            TotalTreesLabel.Text = "Total Trees: 150";
            HealthyTreesLabel.Text = "Healthy Trees: 130";
            UnhealthyTreesLabel.Text = "Unhealthy Trees: 20";

            var categoryData = new List<TreeCategory>
            {
                new TreeCategory { Category = "Fruit Trees", Count = 80 },
                new TreeCategory { Category = "Flower Trees", Count = 40 },
                new TreeCategory { Category = "Medicinal Trees", Count = 30 }
            };

            CategoryCollectionView.ItemsSource = categoryData;
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }

    // Model
    public class TreeCategory
    {
        public string Category { get; set; }
        public int Count { get; set; }
    }
}
