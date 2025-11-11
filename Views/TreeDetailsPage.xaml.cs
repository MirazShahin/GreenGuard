namespace GreenGuard.Views
{
    public partial class TreeDetailsPage : ContentPage
    {
        private bool _isGuest;

        // Constructor-এ Guest parameter নিচ্ছে
        public TreeDetailsPage(bool isGuest = false)
        {
            InitializeComponent();
            _isGuest = isGuest;

            // যদি guest হয় → update button লুকিয়ে দাও
            if (_isGuest)
            {
                UpdateTreeButton.IsVisible = false;
            }
        }

        private async void OnUpdateTreeClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Tree Update", "Tree information updated successfully.", "OK");
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
