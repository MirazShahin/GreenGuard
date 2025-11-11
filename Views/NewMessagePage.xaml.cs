namespace GreenGuard.Views
{
    public partial class NewMessagePage : ContentPage
    {
        private readonly string senderRole;
        private readonly string assignedLeader;

        public NewMessagePage(string role, string leader = null)
        {
            InitializeComponent(); // <-- This now works
            senderRole = role;
            assignedLeader = leader;
            SetupReceiverOptions();
        }

        private void SetupReceiverOptions()
        {
            ReceiverPicker.Items.Clear();

            if (senderRole == "Volunteer")
            {
                ReceiverPicker.Items.Add(assignedLeader ?? "Leader");
                ReceiverPicker.SelectedIndex = 0;
                ReceiverPicker.IsEnabled = false;
            }
            else if (senderRole == "Leader")
            {
                ReceiverPicker.Items.Add("Admin");
                ReceiverPicker.Items.Add("All Volunteers");
                ReceiverPicker.Items.Add("Specific Volunteer");
            }
            else if (senderRole == "Admin")
            {
                ReceiverPicker.Items.Add("All Leaders");
                ReceiverPicker.Items.Add("Specific Leader");
            }
        }

        private async void OnSendClicked(object sender, EventArgs e)
        {
            var receiver = ReceiverPicker.SelectedItem?.ToString();
            var subject = SubjectEntry.Text?.Trim();
            var body = MessageEditor.Text?.Trim();

            if (string.IsNullOrEmpty(receiver) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(body))
            {
                await DisplayAlert("Error", "All fields are required!", "OK");
                return;
            }

            await DisplayAlert("Message Sent", $"To: {receiver}\nSubject: {subject}", "OK");
            await Navigation.PopAsync();
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
