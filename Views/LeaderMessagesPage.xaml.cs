using GreenGuard.Models;

namespace GreenGuard.Views
{
    public partial class LeaderMessagesPage : ContentPage
    {
        private List<NotificationMessage> inboxMessages = new();
        private List<NotificationMessage> sentMessages = new();

        public LeaderMessagesPage()
        {
            InitializeComponent();

            LoadDummyMessages();

            // Default = Inbox
            MessagesCollectionView.ItemsSource = inboxMessages;
            MessageTypeControl.SelectedIndex = 0;
        }

        private void LoadDummyMessages()
        {
            // From Admin
            inboxMessages.Add(new NotificationMessage
            {
                Subject = "Weekly Instruction",
                From = "Admin",
                Body = "Please submit your report by tomorrow.",
                Time = DateTime.Now.AddHours(-5).ToString("g")
            });

            // From Volunteer
            inboxMessages.Add(new NotificationMessage
            {
                Subject = "Task Completed",
                From = "Volunteer Rakib",
                Body = "Planted 12 trees in Zone B.",
                Time = DateTime.Now.AddHours(-2).ToString("g")
            });

            // Sent (dummy)
            sentMessages.Add(new NotificationMessage
            {
                Subject = "Need Permission",
                From = "Me (Leader)",
                Body = "Request approval for Zone C plantation.",
                Time = DateTime.Now.AddHours(-1).ToString("g")
            });
        }

        private void OnSegmentChanged(object sender, EventArgs e)
        {
            if (MessageTypeControl.SelectedIndex == 0)
                MessagesCollectionView.ItemsSource = inboxMessages;
            else
                MessagesCollectionView.ItemsSource = sentMessages;
        }

        private async void OnNewMessageClicked(object sender, EventArgs e)
        {
            // Leader can message → Admin OR Volunteers
            await Navigation.PushAsync(new NewMessagePage("Leader"));
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
