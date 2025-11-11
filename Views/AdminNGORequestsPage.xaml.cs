using GreenGuard.Services;
using System.Collections.Generic;
using System.Linq;
using GreenGuard.Models;
using GreenGuard.Services;

namespace GreenGuard.Views
{
    public partial class AdminNGORequestsPage : ContentPage
    {
        private List<GreenGuard.Models.NotificationMessage> _requests;  // ✅ Explicit model path

        public AdminNGORequestsPage()
        {
            InitializeComponent();
            LoadRequests();
        }

        private void LoadRequests()
        {
            // ✅ Explicit type from Models namespace
            _requests = MessageService.Current.GetMessagesForRole("Admin")
                .Where(m => m.From.Contains("NGO"))
                .ToList();

            RequestsCollectionView.ItemsSource = _requests;
        }

        private async void OnApproveClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is GreenGuard.Models.NotificationMessage msg)
            {
                await DisplayAlert("✅ Approved", $"NGO request '{msg.Subject}' approved successfully.", "OK");
                _requests.Remove(msg);
                RequestsCollectionView.ItemsSource = null;
                RequestsCollectionView.ItemsSource = _requests;
            }
        }

        private async void OnRejectClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is GreenGuard.Models.NotificationMessage msg)
            {
                await DisplayAlert("❌ Rejected", $"NGO request '{msg.Subject}' has been rejected.", "OK");
                _requests.Remove(msg);
                RequestsCollectionView.ItemsSource = null;
                RequestsCollectionView.ItemsSource = _requests;
            }
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
