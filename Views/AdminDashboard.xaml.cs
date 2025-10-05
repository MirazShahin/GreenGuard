namespace GreenGuard.Views
{
    public partial class AdminDashboard : ContentPage
    {
        private int totalSold = 0;
        private string topTree = "None";

        public AdminDashboard()
        {
            InitializeComponent();

            // Dummy data (later DB থেকে আসবে)
            totalSold = 120;
            topTree = "Mango Tree";

            // Update UI labels
            TotalSoldLabel.Text = $"Total Trees Sold: {totalSold}";
            TopTreeLabel.Text = $"Top Selling Tree: {topTree}";
        }

        // 👉 Navigate to AddTreePage
        private async void OnAddTreeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTreePage());
        }

        // 👉 Navigate to UpdateTreePage
        private async void OnUpdateTreeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UpdateTreePage());
        }

        // 👉 Navigate to InventoryPage
        private async void OnInventoryClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InventoryPage());
        }

        private async void OnViewLeadersClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LeaderManagementPage());
        }

        private async void OnViewVolunteersClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VolunteerManagementPage());
        }


        private async void OnZoneWiseClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ZoneManagementPage());
        }
        private async void OnPermissionRequestsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PermissionRequestsPage());
        }

        private async void OnGovtControlClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Govt Control", "Check if zone is under govt control (to be implemented).", "OK");
        }
        private async void OnSalesReportClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SalesSummaryPage());
        }

        private async void OnTreeAnalysisClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TreeAnalysisPage());
        }
        private async void OnMessagesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MessagesPage("Admin"));
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
