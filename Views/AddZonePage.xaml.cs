namespace GreenGuard.Views
{
    public partial class AddZonePage : ContentPage
    {
        public AddZonePage()
        {
            InitializeComponent();
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            string zoneName = ZoneNameEntry.Text?.Trim();
            string location = LocationEntry.Text?.Trim();
            string treeCount = TreeCountEntry.Text?.Trim();
            string description = DescriptionEditor.Text?.Trim();

            if (string.IsNullOrEmpty(zoneName) || string.IsNullOrEmpty(location) || string.IsNullOrEmpty(treeCount))
            {
                await DisplayAlert("Error", "Please fill in all required fields.", "OK");
                return;
            }

            await DisplayAlert("Request Sent",
                $"✅ Zone Name: {zoneName}\n📍 Location: {location}\n🌳 Trees Capacity: {treeCount}\n\nYour zone request has been submitted to Admin for approval.",
                "OK");

            // Future integration:
            // Save data to DB or send API call here

            await Navigation.PopAsync();
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
