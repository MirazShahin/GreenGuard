using GreenGuard.Models;
using GreenGuard.Services;

namespace GreenGuard.Views
{
    public partial class NGOVolunteerPage : ContentPage
    {
        public NGOVolunteerPage()
        {
            InitializeComponent();
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            try
            {
                string ngoName = NGONameEntry.Text?.Trim();
                string project = ProjectEntry.Text?.Trim();
                string zone = ZoneEntry.Text?.Trim();
                string volunteers = VolunteersEntry.Text?.Trim();
                string message = MessageEditor.Text?.Trim();

                if (string.IsNullOrEmpty(ngoName) ||
                    string.IsNullOrEmpty(project) ||
                    string.IsNullOrEmpty(zone) ||
                    string.IsNullOrEmpty(volunteers))
                {
                    await DisplayAlert("⚠️ Missing Info", "Please fill all required fields.", "OK");
                    return;
                }

                if (!int.TryParse(volunteers, out int volunteerCount))
                {
                    await DisplayAlert("⚠️ Invalid Input", "Please enter a valid number for volunteers.", "OK");
                    return;
                }

                // Create message for Admin
                var requestMessage = new NotificationMessage
                {
                    From = ngoName,
                    To = "Admin",
                    Subject = $"Volunteer Request: {project}",
                    Body = $"NGO: {ngoName}\nProject: {project}\nZone: {zone}\nRequested Volunteers: {volunteerCount}\n\nAdditional Info:\n{message}",
                    Time = DateTime.Now.ToString("g"),
                    VolunteerCount = volunteerCount,
                    Zone = zone
                };

                // Add message to global message service
                MessageService.Current.AddMessage(requestMessage);

                await DisplayAlert("✅ Request Sent", "Your volunteer request has been submitted to Admin.", "OK");

                // ✅ Return to previous page safely
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("❌ Error", $"Unexpected issue:\n{ex.Message}", "OK");
            }
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
