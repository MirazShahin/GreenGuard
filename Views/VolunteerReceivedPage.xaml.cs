namespace GreenGuard.Views
{
    public partial class VolunteerReceivedPage : ContentPage
    {
        public VolunteerReceivedPage()
        {
            InitializeComponent();

            // Dummy data (later will come from DB/API)
            var messages = new List<NotificationMessage>
            {
                new NotificationMessage { Subject = "Tree Plantation Drive", From = "Leader Rahim", Body = "Please join tomorrow’s plantation activity at Zone A.", Time = DateTime.Now.AddHours(-2).ToString("g") },
                new NotificationMessage { Subject = "Weekly Update", From = "Admin", Body = "Great progress this week! Keep up the good work.", Time = DateTime.Now.AddDays(-1).ToString("g") }
            };

            MessagesCollectionView.ItemsSource = messages;
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }

    // Message Model
    public class NotificationMessage
    {
        public string Subject { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
        public string Time { get; set; }
        public string To { get; internal set; }
    }
}
