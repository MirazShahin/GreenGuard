namespace GreenGuard.Views
{
    public partial class AdminNGORequestApprovalPage : ContentPage
    {
        public class NGORequest
        {
            public string NGOName { get; set; }
            public string Zone { get; set; }
            public string Location { get; set; }
            public string TreeType { get; set; }
            public int TreeCount { get; set; }
            public string Purpose { get; set; }
            public string Status { get; set; }
            public Color StatusColor { get; set; }
        }

        private List<NGORequest> requests;

        public AdminNGORequestApprovalPage()
        {
            InitializeComponent();

            // Dummy data (Later replace with database)
            requests = new List<NGORequest>
            {
                new NGORequest { NGOName = "Green Earth Foundation", Zone = "Dhaka Zone A", Location = "Mirpur", TreeType = "Mango", TreeCount = 100, Purpose = "Urban Greening", Status = "Pending", StatusColor = Colors.Orange },
                new NGORequest { NGOName = "Eco Bangladesh", Zone = "Chattogram Zone B", Location = "Patenga", TreeType = "Neem", TreeCount = 200, Purpose = "Coastal Plantation", Status = "Pending", StatusColor = Colors.Orange },
                new NGORequest { NGOName = "Nature Alliance", Zone = "Rajshahi Zone C", Location = "Boalia", TreeType = "Guava", TreeCount = 150, Purpose = "School Campus Greening", Status = "Pending", StatusColor = Colors.Orange }
            };

            RequestCollectionView.ItemsSource = requests;
        }

        private async void OnApproveClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is NGORequest request)
            {
                request.Status = "Approved";
                request.StatusColor = Colors.LightGreen;
                RefreshList();
                await DisplayAlert("✅ Approved", $"{request.NGOName}'s request has been approved.", "OK");
            }
        }

        private async void OnRejectClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is NGORequest request)
            {
                request.Status = "Rejected";
                request.StatusColor = Colors.Red;
                RefreshList();
                await DisplayAlert("❌ Rejected", $"{request.NGOName}'s request has been rejected.", "OK");
            }
        }

        private void RefreshList()
        {
            RequestCollectionView.ItemsSource = null;
            RequestCollectionView.ItemsSource = requests;
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
