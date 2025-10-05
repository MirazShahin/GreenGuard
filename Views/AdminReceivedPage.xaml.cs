using GreenGuard.Models;

namespace GreenGuard.Views
{
    public partial class AdminReceivedPage : ContentPage
    {
        public AdminReceivedPage()
        {
            InitializeComponent();

            var messages = new List<NotificationMessage>
            {
                new NotificationMessage { From="Leader Rahim", Subject="Permission Request", Body="Approval needed for Zone A plantation.", Time=DateTime.Now.AddMinutes(-15).ToString("g") },
                new NotificationMessage { From="Leader Karim", Subject="Weekly Report", Body="Zone B progress submitted.", Time=DateTime.Now.AddHours(-2).ToString("g") },
                new NotificationMessage { From="Volunteer Sadia", Subject="Task Completion", Body="Watered 20 Neem Trees in Zone C.", Time=DateTime.Now.AddHours(-5).ToString("g") }
            };

            MessagesCollectionView.ItemsSource = messages;
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
