using GreenGuard.Services;
using Msg = GreenGuard.Models.NotificationMessage;   // 👈 add this

namespace GreenGuard.Views
{
    public partial class AdminVolunteerRequestsPage : ContentPage
    {
        private List<Msg> _ngoRequests = new();

        public AdminVolunteerRequestsPage()
        {
            InitializeComponent();
            LoadRequests();
        }

        private void LoadRequests()
        {
            _ngoRequests = MessageService.Current
                .GetMessagesForRole("Admin")
                .Where(m => (m.Subject?.Contains("Volunteer Request") ?? false) && m.From != "Admin")
                .ToList();

            RequestCollectionView.ItemsSource = _ngoRequests;
        }

        private async void OnApproveClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Msg request)
            {
                await DisplayAlert("✅ Approved", $"Volunteer request from {request.From} approved!", "OK");

                var response = new Msg
                {
                    From = "Admin",
                    To = request.From,
                    Subject = $"Approval: {request.Subject}",
                    Body = $"Your volunteer request for {request.Zone} ({request.VolunteerCount} volunteers) has been approved.",
                    Time = DateTime.Now.ToString("g")
                };

                MessageService.Current.AddMessage(response);

                _ngoRequests.Remove(request);
                RequestCollectionView.ItemsSource = null;
                RequestCollectionView.ItemsSource = _ngoRequests;
            }
        }

        private async void OnRejectClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Msg request)
            {
                await DisplayAlert("❌ Rejected", $"Volunteer request from {request.From} rejected.", "OK");

                var response = new Msg
                {
                    From = "Admin",
                    To = request.From,
                    Subject = $"Rejection: {request.Subject}",
                    Body = $"Your volunteer request for {request.Zone} ({request.VolunteerCount} volunteers) was not approved.",
                    Time = DateTime.Now.ToString("g")
                };

                MessageService.Current.AddMessage(response);

                _ngoRequests.Remove(request);
                RequestCollectionView.ItemsSource = null;
                RequestCollectionView.ItemsSource = _ngoRequests;
            }
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
