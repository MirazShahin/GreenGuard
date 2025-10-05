namespace GreenGuard.Views
{
    public partial class TreeStatusUpdatePage : ContentPage
    {
        public TreeStatusUpdatePage()
        {
            InitializeComponent();
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            string zone = ZoneEntry.Text?.Trim();
            int.TryParse(TotalTreesEntry.Text?.Trim(), out int total);
            int.TryParse(HealthyTreesEntry.Text?.Trim(), out int healthy);
            int.TryParse(UnhealthyTreesEntry.Text?.Trim(), out int unhealthy);
            string date = StatusDatePicker.Date.ToString("dd MMM yyyy");

            if (string.IsNullOrEmpty(zone) || total <= 0 || (healthy + unhealthy) > total)
            {
                await DisplayAlert("Error", "Please enter valid data.", "OK");
                return;
            }

            // Dummy save - Later DB & Leader notification হবে
            await DisplayAlert("Success",
                $"Status Submitted ✅\n\nZone: {zone}\nTotal Trees: {total}\nHealthy: {healthy}\nUnhealthy: {unhealthy}\nDate: {date}",
                "OK");

            await Navigation.PopAsync();
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
