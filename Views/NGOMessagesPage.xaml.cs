using GreenGuard.Services; 
using NotificationMessageModel = GreenGuard.Models.NotificationMessage;
using GreenGuard.Models;
using GreenGuard.Services;

namespace GreenGuard.Views
{
    public partial class NGOMessagesPage : ContentPage
    {
        public NGOMessagesPage()
        {
            InitializeComponent();
            LoadInbox();
        }

        private void LoadInbox()
        {
            var inbox = MessageService.Current.GetMessagesForRole("NGO");
            InboxCollectionView.ItemsSource = inbox;
        }

        private async void OnSendClicked(object sender, EventArgs e)
        {
            string subject = SubjectEntry.Text?.Trim();
            string body = BodyEditor.Text?.Trim();

            if (string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(body))
            {
                await DisplayAlert("Error", "Please fill in both subject and message.", "OK");
                return;
            }

            var message = new NotificationMessageModel
            {
                From = "NGO",
                To = "Admin",
                Subject = subject,
                Body = body,
                Time = DateTime.Now.ToString("g")
            };

            MessageService.Current.AddMessage(message);

            await DisplayAlert("✅ Message Sent", "Your message was sent to Admin.", "OK");

            SubjectEntry.Text = string.Empty;
            BodyEditor.Text = string.Empty; 
            LoadInbox();
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
