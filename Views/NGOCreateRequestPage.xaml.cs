namespace GreenGuard.Views
{
    public partial class NGOCreateRequestPage : ContentPage
    {
        public NGOCreateRequestPage()
        {
            InitializeComponent();
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            string zone = ZoneNameEntry.Text?.Trim();
            string location = LocationEntry.Text?.Trim();
            string treeType = TreeTypePicker.SelectedItem?.ToString();
            string count = TreeCountEntry.Text?.Trim();
            string purpose = PurposeEditor.Text?.Trim();

            if (string.IsNullOrEmpty(zone) || string.IsNullOrEmpty(location) ||
                string.IsNullOrEmpty(treeType) || string.IsNullOrEmpty(count))
            {
                await DisplayAlert("Error", "Please fill all required fields.", "OK");
                return;
            }

            await DisplayAlert("✅ Submitted",
                $"Your request has been sent to Admin.\n\nZone: {zone}\nLocation: {location}\nTree Type: {treeType}\nTree Count: {count}\nPurpose: {purpose}",
                "OK");

            await Navigation.PopAsync();
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
