namespace GreenGuard.Views
{
    public partial class VolunteerDashboard : ContentPage
    {
        private string assignedLeader = "Leader A"; // 👉 Future: DB থেকে আসবে

        public VolunteerDashboard()
        {
            InitializeComponent();
        }

        private async void OnPlantationUpdateClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlantationUpdatePage());
        }

        private async void OnTreeRequestClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TreeRequestPage());
        }

        private async void OnRequirementUpdateClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TreeRequirementUpdatePage());
        }

        private async void OnHistoryClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VolunteerHistoryPage());
        }

        private async void OnMessageClicked(object sender, EventArgs e)
        {
            // Volunteer শুধু তার leader কেই মেসেজ পাঠাতে পারবে
            await Navigation.PushAsync(new NewMessagePage("Volunteer", assignedLeader));
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
