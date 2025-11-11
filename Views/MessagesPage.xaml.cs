using GreenGuard.Models;
using GreenGuard.Services;  

namespace GreenGuard.Views
{
    public partial class MessagesPage : ContentPage
    {
        private readonly string userRole;
        private readonly string zone;
        private readonly string assignedLeader;

        public MessagesPage(string role, string zoneName = null, string leader = null)
        {
            InitializeComponent();
            userRole = role;
            zone = zoneName;
            assignedLeader = leader;

            LoadMessages();
        }

        private void LoadMessages()
        {
            // ✅ Pull shared messages based on role
            var messages = MessageService.Current.GetMessagesForRole(userRole);
            MessagesCollectionView.ItemsSource = messages;

            // Only Admin and Leader can send new messages in this page
            NewMessageButton.IsVisible = (userRole == "Admin" || userRole == "Leader" || userRole == "Volunteer");
        }

        private async void OnNewMessageClicked(object sender, EventArgs e)
        {
            // ✅ Navigate to proper message composer
            if (userRole == "Volunteer")
                await Navigation.PushAsync(new NewMessagePage("Volunteer", assignedLeader)); // Volunteer → Leader
            else if (userRole == "Leader")
                await Navigation.PushAsync(new NewMessagePage("Leader"));   // Leader → Admin or Volunteers
            else if (userRole == "Admin")
                await Navigation.PushAsync(new NewMessagePage("Admin"));    // Admin → Leaders or NGOs
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
