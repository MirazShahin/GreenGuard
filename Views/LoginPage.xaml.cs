namespace GreenGuard.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnInternalLoginClicked(object sender, EventArgs e)
        {
            var role = InternalRolePicker.SelectedItem?.ToString();
            var email = InternalEmailEntry.Text?.Trim();
            var password = InternalPasswordEntry.Text?.Trim();

            if (string.IsNullOrEmpty(role) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "Please fill all internal login fields.", "OK");
                return;
            }

            await DisplayAlert("Login Success", $"Welcome {role}: {email}", "OK");

            switch (role)
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
            }
        }

        private async void OnExternalLoginClicked(object sender, EventArgs e)
        {
            var role = ExternalRolePicker.SelectedItem?.ToString();
            var email = ExternalEmailEntry.Text?.Trim();
            var password = ExternalPasswordEntry.Text?.Trim();

            if (string.IsNullOrEmpty(role) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "Please fill all external login fields.", "OK");
                return;
            }

            await DisplayAlert("Login Success", $"Welcome {role}: {email}", "OK");

            switch (role)
            {
                case "NGO":
                    await Navigation.PushAsync(new NGODashboard());
                    break;
                case "Personal User":
                    await Navigation.PushAsync(new PersonalDashboard());
                    break;
            }
        }
        private async void OnGuestClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GuestDashboard());
        }
        private async void OnSignupTapped(object sender, TappedEventArgs e)
        {
            bool isInternal = await DisplayAlert("Choose Type",
                "Register as?",
                "Internal", "External");

            if (isInternal)
                await Navigation.PushAsync(new InternalRegistrationPage());
            else
                await Navigation.PushAsync(new ExternalRegistrationPage());
        }
    }
}
