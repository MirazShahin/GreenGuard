using System;
using System.Text.RegularExpressions;
using Microsoft.Maui.Controls;

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
            string email = EmailEntry.Text?.Trim();
            string password = PasswordEntry.Text?.Trim();
            string confirmPassword = ConfirmPasswordEntry.Text?.Trim();
            string userType = UserTypePicker.SelectedItem?.ToString();

            // Basic validation
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword) ||
                string.IsNullOrEmpty(userType))
            {
                await DisplayAlert("Error", "All fields are required!", "OK");
                return;
            }

            // Email validation
            if (!IsValidEmail(email))
            {
                await DisplayAlert("Error", "Invalid email format.", "OK");
                return;
            }

            // Password match validation
            if (password != confirmPassword)
            {
                await DisplayAlert("Error", "Passwords do not match!", "OK");
                return;
            }

            // ✅ NOTE: Database save logic will go here later
            await DisplayAlert("Success", $"Welcome {name}! Registered as {userType}", "OK");

            // Navigate to respective Dashboard
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
                    await DisplayAlert("Error", "Invalid user type.", "OK");
                    break;
            }
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(); // PopAsync ভালো, কারণ আগের LoginPage stack-এ আছে
        }

        // Utility function for email validation
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // simple regex for email validation
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
