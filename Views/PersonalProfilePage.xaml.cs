using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Media;
using System;
//using Windows.Networking.NetworkOperators;

namespace GreenGuard.Views
{
    public partial class PersonalProfilePage : ContentPage
    {
        private string profileImagePath = "default_profile.png";

        public PersonalProfilePage()
        {
            InitializeComponent();
            LoadProfileData();
        }

        private void LoadProfileData()
        {
            NameEntry.Text = "John Doe";
            EmailEntry.Text = "john@example.com";
            PhoneEntry.Text = "01700000000";
            LocationEntry.Text = "Dhaka Zone A";
            ThemePicker.SelectedIndex = 2;
            NotificationSwitch.IsToggled = true; 
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            string name = NameEntry.Text?.Trim();
            string email = EmailEntry.Text?.Trim();
            string phone = PhoneEntry.Text?.Trim();
            string location = LocationEntry.Text?.Trim();
            string theme = ThemePicker.SelectedItem?.ToString() ?? "System Default";
            bool notifications = NotificationSwitch.IsToggled;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
            {
                await DisplayAlert("Error", "Please fill required fields (Name & Email).", "OK");
                return;
            }

            await DisplayAlert("✅ Profile Saved",
                $"Profile Updated:\n\nName: {name}\nEmail: {email}\nPhone: {phone}\nLocation: {location}\nTheme: {theme}\nNotifications: {(notifications ? "On" : "Off")}",
                "OK");
        }

        private async void OnResetClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Reset", "Reset all profile data?", "Yes", "No");
            if (confirm)
                LoadProfileData();
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
