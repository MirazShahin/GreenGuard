namespace GreenGuard.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text?.Trim();
        string password = PasswordEntry.Text?.Trim();
        string role = RolePicker.SelectedItem?.ToString();

        if (string.IsNullOrEmpty(role))
        {
            await DisplayAlert("Error", "Please select a role (Admin, Leader, Volunteer).", "OK");
            return;
        }

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Error", "Enter email and password.", "OK");
            return;
        }

        // Dummy validation (later DB integration করা যাবে)
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

    private async void OnSignupTapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }

    private async void OnForgotPasswordTapped(object sender, TappedEventArgs e)
    {
        await DisplayAlert("Forgot Password", "Password reset option coming soon!", "OK");
    }

    private async void OnGuestClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GuestDashboard());
    }
}
