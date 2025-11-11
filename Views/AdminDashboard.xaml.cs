namespace GreenGuard.Views
{
    public partial class AdminDashboard : ContentPage
    {
        private int totalSold = 0;
        private string topTree = "None";

        public AdminDashboard()
        {
            InitializeComponent();
            totalSold = 120;
            topTree = "Mango Tree";
            TotalSoldLabel.Text = $"Total Trees Sold: {totalSold}";
            TopTreeLabel.Text = $"Top Selling Tree: {topTree}";
        }
        private async void OnAddTreeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTreePage());
        }
        private async void OnUpdateTreeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UpdateTreePage());
        }

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

        private async void OnProjectRequestsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminProjectApprovalPage());
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
        private async void OnNGORequestsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminNGORequestsPage());
        }
        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Logout", "Are you sure you want to logout?", "Yes", "No");
            if (confirm)
                await Navigation.PopToRootAsync();
        }
    }
}
