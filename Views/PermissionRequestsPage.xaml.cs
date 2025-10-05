namespace GreenGuard.Views
{
    public partial class PermissionRequestsPage : ContentPage
    {
        private List<ZoneManagementPage.PermissionRequest> requests;
        private static List<PermissionHistory> history = new();

        public PermissionRequestsPage()
        {
            InitializeComponent();
            requests = ZoneManagementPage.GetRequests();
            RefreshUI();
        }

        private async void OnApproveClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is ZoneManagementPage.PermissionRequest request)
            {
                requests.Remove(request);
                history.Add(new PermissionHistory
                {
                    ZoneName = request.ZoneName,
                    Action = request.Action,
                    PermissionFrom = request.PermissionFrom,
                    Status = "Approved",
                    DecisionTime = DateTime.Now.ToString("g")
                });
                RefreshUI();
                await DisplayAlert("Approved", $"Request for {request.ZoneName} approved.", "OK");
            }
        }

        private async void OnRejectClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is ZoneManagementPage.PermissionRequest request)
            {
                requests.Remove(request);
                history.Add(new PermissionHistory
                {
                    ZoneName = request.ZoneName,
                    Action = request.Action,
                    PermissionFrom = request.PermissionFrom,
                    Status = "Rejected",
                    DecisionTime = DateTime.Now.ToString("g")
                });
                RefreshUI();
                await DisplayAlert("Rejected", $"Request for {request.ZoneName} rejected.", "OK");
            }
        }

        private void RefreshUI()
        {
            RequestsCollectionView.ItemsSource = null;
            RequestsCollectionView.ItemsSource = requests;

            HistoryCollectionView.ItemsSource = null;
            HistoryCollectionView.ItemsSource = history;
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        // Model for History
        public class PermissionHistory
        {
            public string ZoneName { get; set; }
            public string Action { get; set; }
            public string PermissionFrom { get; set; }
            public string Status { get; set; }
            public string DecisionTime { get; set; }

            public string StatusDisplay => $"Status: {Status}";
        }
    }
}
