using GreenGuard.Models;

namespace GreenGuard.Views
{
    public partial class MessagesPage : ContentPage
    {
        private string userRole;
        private string zone;
        private string assignedLeader;

        private List<NotificationMessage> inboxMessages = new();

        public MessagesPage(string role, string zoneName = null, string leader = null)
        {
            InitializeComponent();
            userRole = role;
            zone = zoneName;
            assignedLeader = leader;

            LoadDummyMessages();

            MessagesCollectionView.ItemsSource = inboxMessages; 
            if (userRole == "Volunteer")
                NewMessageButton.IsVisible = true;
        }

        private void LoadDummyMessages()
        {
            if (userRole == "Admin")
            {
                inboxMessages.Add(new NotificationMessage
                {
                    Subject = "Weekly Report",
                    From = "Leader A",
                    Body = "Zone A completed plantation",
                    Time = DateTime.Now.AddHours(-5).ToString("g")
                });
            }
            else if (userRole == "Leader")
            {
                inboxMessages.Add(new NotificationMessage
                {
                    Subject = "Instruction",
                    From = "Admin",
                    Body = "Submit your report",
                    Time = DateTime.Now.AddHours(-8).ToString("g")
                });
                inboxMessages.Add(new NotificationMessage
                {
                    Subject = "Update",
                    From = "Volunteer1",
                    Body = "Planted 10 trees",
                    Time = DateTime.Now.AddHours(-2).ToString("g")
                });
            }
            else if (userRole == "Volunteer")
            {
                inboxMessages.Add(new NotificationMessage
                {
                    Subject = "Task",
                    From = "Leader A",
                    Body = "Plant 5 trees today",
                    Time = DateTime.Now.AddHours(-3).ToString("g")
                });
            }
        }

        private async void OnNewMessageClicked(object sender, EventArgs e)
        {
            if (userRole == "Volunteer")
                await Navigation.PushAsync(new NewMessagePage("Volunteer", assignedLeader)); // volunteer -> leader only
            else if (userRole == "Leader")
                await Navigation.PushAsync(new NewMessagePage("Leader"));   // leader picks Admin / Volunteers in page
            else
                await Navigation.PushAsync(new NewMessagePage("Admin"));    // admin picks Leaders in page
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
