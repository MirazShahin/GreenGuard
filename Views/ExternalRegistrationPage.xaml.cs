namespace GreenGuard.Views
{
    public partial class ExternalRegistrationPage : ContentPage
    {
        public ExternalRegistrationPage()
        {
            InitializeComponent();
        }

        // 🔹 Enable NGO field only when role = NGO
        private void OnRoleChanged(object sender, EventArgs e)
        {
            var selectedRole = RolePicker.SelectedItem?.ToString();

            if (selectedRole == "NGO")
            {
                OrganizationEntry.IsEnabled = true;
                OrganizationEntry.Opacity = 1; // make text box fully visible
            }
            else
            {
                OrganizationEntry.IsEnabled = false;
                OrganizationEntry.Text = string.Empty; // clear previous text
                OrganizationEntry.Opacity = 0.5; // fade to indicate disabled
            }
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            var role = RolePicker.SelectedItem?.ToString();
            var name = NameEntry.Text?.Trim();
            var email = EmailEntry.Text?.Trim();
            var password = PasswordEntry.Text?.Trim();
            var orgName = OrganizationEntry.Text?.Trim();

            if (string.IsNullOrEmpty(role) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "Please fill all required fields.", "OK");
                return;
            }

            if (role == "NGO" && string.IsNullOrEmpty(orgName))
            {
                await DisplayAlert("Error", "Please enter organization name for NGO registration.", "OK");
                return;
            }

            await DisplayAlert("Success", $"Welcome {role}! Registration complete.", "OK");
            await Navigation.PopAsync();
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
