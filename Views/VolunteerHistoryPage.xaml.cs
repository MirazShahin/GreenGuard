namespace GreenGuard.Views
{
    public partial class VolunteerHistoryPage : ContentPage
    {
        public VolunteerHistoryPage()
        {
            InitializeComponent();

            LoadDummyData();
        }

        private void LoadDummyData()
        {
            // Dummy Tree Updates
            var updates = new List<TreeUpdate>
            {
                new TreeUpdate { Zone="Zone A", TreeType="Mango", Status="Healthy", Date=DateTime.Now.AddDays(-2).ToString("g") },
                new TreeUpdate { Zone="Zone B", TreeType="Neem", Status="Unhealthy", Date=DateTime.Now.AddDays(-5).ToString("g") }
            };

            // Dummy Tree Requests
            var requests = new List<TreeRequest>
            {
                new TreeRequest { Zone="Zone A", TreeType="Banyan", Quantity=10, Purpose="School Project", Date=DateTime.Now.AddDays(-7).ToString("g") },
                new TreeRequest { Zone="Zone C", TreeType="Guava", Quantity=20, Purpose="Community Drive", Date=DateTime.Now.AddDays(-12).ToString("g") }
            };

            UpdatesCollectionView.ItemsSource = updates;
            RequestsCollectionView.ItemsSource = requests;
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }

    // Models
    public class TreeUpdate
    {
        public string Zone { get; set; }
        public string TreeType { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
    }

    public class TreeRequest
    {
        public string Zone { get; set; }
        public string TreeType { get; set; }
        public int Quantity { get; set; }
        public string Purpose { get; set; }
        public string Date { get; set; }

        public string QuantityDisplay => $"Quantity: {Quantity}";
    }
}
