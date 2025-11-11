namespace GreenGuard.Views
{
    public partial class InternalRegistrationPage : ContentPage
    {
        public InternalRegistrationPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            string name = NameEntry.Text?.Trim();
            string email = EmailEntry.Text?.Trim();
            string password = PasswordEntry.Text?.Trim();
            string role = RolePicker.SelectedItem?.ToString();
            string zone = ZoneEntry.Text?.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                await DisplayAlert("Error", "Please fill all required fields.", "OK");
                return;
            }

            await DisplayAlert("Success", $"{role} registered successfully!", "OK");
            await Navigation.PopAsync(); // back to login
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
