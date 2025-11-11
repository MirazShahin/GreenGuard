namespace GreenGuard.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            string name = NameEntry.Text?.Trim();
            string username = UsernameEntry.Text?.Trim();
            string email = EmailEntry.Text?.Trim();
            string password = PasswordEntry.Text?.Trim();
            string confirmPassword = ConfirmPasswordEntry.Text?.Trim();
            string userType = UserTypePicker.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(userType))
            {
                await DisplayAlert("Error", "Please fill in all required fields.", "OK");
                return;
            }

            if (password != confirmPassword)
            {
                await DisplayAlert("Error", "Passwords do not match.", "OK");
                return;
            }

            // ✅ You can add DB saving here in the future
            await DisplayAlert("Success", $"Account created successfully for {userType}!", "OK");

            // Navigate to their respective dashboard
            switch (userType)
            {
                case "Admin":
                    await Navigation.PushAsync(new AdminDashboard());
                    break;
                case "Leader":
                    await Navigation.PushAsync(new LeaderDashboard());
                    break;
                case "Volunteer":
                    await Navigation.PushAsync(new VolunteerDashboard());
                    break; 
                default:
                    await DisplayAlert("Error", "Invalid role selected.", "OK");
                    break;
            }
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
