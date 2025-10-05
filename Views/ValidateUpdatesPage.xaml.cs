namespace GreenGuard.Views
{
    public partial class ValidateUpdatesPage : ContentPage
    {
        private List<VolunteerUpdate> updates;

        public ValidateUpdatesPage()
        {
            InitializeComponent();

            // Dummy Data (later DB থেকে আসবে)
            updates = new List<VolunteerUpdate>
            {
                new VolunteerUpdate { VolunteerName="Alamin", Zone="Zone A", UpdateText="Planted 5 Mango Trees" },
                new VolunteerUpdate { VolunteerName="Sadia", Zone="Zone B", UpdateText="Watered 10 Neem Trees" },
                new VolunteerUpdate { VolunteerName="Rakib", Zone="Zone C", UpdateText="Fertilized 3 Coconut Trees" },
                new VolunteerUpdate { VolunteerName="Mitu", Zone="Zone A", UpdateText="Planted 7 Rose Plants" }
            };

            UpdatesCollectionView.ItemsSource = updates;
        }

        private async void OnApproveClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is VolunteerUpdate update)
            {
                updates.Remove(update);
                UpdatesCollectionView.ItemsSource = null;
                UpdatesCollectionView.ItemsSource = updates;

                await DisplayAlert("Approved", $"{update.VolunteerName}'s update approved ✅", "OK");
            }
        }

        private async void OnRejectClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is VolunteerUpdate update)
            {
                updates.Remove(update);
                UpdatesCollectionView.ItemsSource = null;
                UpdatesCollectionView.ItemsSource = updates;

                await DisplayAlert("Rejected", $"{update.VolunteerName}'s update rejected ❌", "OK");
            }
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }

    // Model
    public class VolunteerUpdate
    {
        public string VolunteerName { get; set; }
        public string Zone { get; set; }
        public string UpdateText { get; set; }
    }
}
