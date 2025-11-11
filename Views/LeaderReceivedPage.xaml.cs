using GreenGuard.Models;

namespace GreenGuard.Views
{
    public partial class LeaderReceivedPage : ContentPage
    {
        public LeaderReceivedPage()
        {
            InitializeComponent();

            var messages = new List<NotificationMessage>
            {
                new NotificationMessage { From="Admin", Subject="Approval Granted", Body="You’re approved to start Zone A plantation.", Time=DateTime.Now.AddMinutes(-30).ToString("g") },
                new NotificationMessage { From="Volunteer Rakib", Subject="Task Update", Body="Planted 10 Mango Trees in Zone A.", Time=DateTime.Now.AddHours(-1).ToString("g") },
                new NotificationMessage { From="Volunteer Jannat", Subject="Help Needed", Body="Water supply shortage in Zone B.", Time=DateTime.Now.AddHours(-3).ToString("g") }
            };

            MessagesCollectionView.ItemsSource = messages;
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
