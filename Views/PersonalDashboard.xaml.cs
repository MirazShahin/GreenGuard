namespace GreenGuard.Views
{
    public partial class PersonalDashboard : ContentPage
    {
        public PersonalDashboard()
        {
            InitializeComponent();
        }

        private async void OnAddZoneClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddZonePage());
        }

        private async void OnBrowseClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BrowseProjectsPage());
        }

        // 💰 View contribution / sponsorship history
        private async void OnHistoryClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PersonalContributionHistoryPage());
        }

        // 👤 Profile and settings
        private async void OnProfileClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PersonalProfilePage());
        }

        private async void OnPurchaseClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PersonalTreePurchasePage());
        }

        // 🚪 Logout
        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Logout", "Are you sure you want to logout?", "Yes", "No");
            if (confirm)
            {
                await Navigation.PopToRootAsync();
            }
        }
    }
}
