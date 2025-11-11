using System.Collections.ObjectModel;

namespace GreenGuard.Views
{
    public partial class AdminProjectApprovalPage : ContentPage
    {
        public ObservableCollection<PlantationRequest> PendingRequests { get; set; }

        public AdminProjectApprovalPage()
        {
            InitializeComponent();
            LoadDummyRequests();
            RequestsCollectionView.ItemsSource = PendingRequests;
        }

        private void LoadDummyRequests()
        {
            PendingRequests = new ObservableCollection<PlantationRequest>
            {
                new PlantationRequest
                {
                    ProjectTitle = "Community Park – Zone C",
                    RequestedBy = "NGO: GreenEarth Foundation",
                    Zone = "Dhanmondi",
                    TreeType = "Mixed Species",
                    Quantity = 150
                },
                new PlantationRequest
                {
                    ProjectTitle = "Mango Plantation – Zone A",
                    RequestedBy = "Personal: Miraz Hossain",
                    Zone = "Mirpur",
                    TreeType = "Mango",
                    Quantity = 50
                }
            };
        }

        private async void OnApproveClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var request = (button.BindingContext as PlantationRequest);
            if (request == null) return;

            PendingRequests.Remove(request);
            await DisplayAlert("Approved ✅", $"{request.ProjectTitle} approved for plantation!", "OK");
        }

        private async void OnRejectClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var request = (button.BindingContext as PlantationRequest);
            if (request == null) return;

            PendingRequests.Remove(request);
            await DisplayAlert("Rejected ❌", $"{request.ProjectTitle} request has been rejected.", "OK");
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }

    public class PlantationRequest
    {
        public string ProjectTitle { get; set; }
        public string RequestedBy { get; set; }
        public string Zone { get; set; }
        public string TreeType { get; set; }
        public int Quantity { get; set; }

        public string QuantityDisplay => $"Requested Trees: {Quantity}";
    }
}
