namespace GreenGuard.Views
{
    public partial class NotificationsPage : ContentPage
    {
        private List<string> leaders;
        private List<string> volunteers;

        public NotificationsPage()
        {
            InitializeComponent();

            // Dummy data (later DB থেকে আসবে)
            leaders = new List<string> { "Rahim Uddin (L001)", "Karim Ali (L002)", "Shila Akter (L003)" };
            volunteers = new List<string> { "Alamin (V001)", "Sadia (V002)", "Rakib (V003)" };
        }

        // 👉 Receiver type change
        private void OnReceiverChanged(object sender, EventArgs e)
        {
            string selected = ReceiverPicker.SelectedItem?.ToString() ?? "";

            if (selected == "Specific Leader")
            {
                PersonPicker.IsVisible = true;
                PersonPicker.ItemsSource = leaders;
            }
            else if (selected == "Specific Volunteer")
            {
                PersonPicker.IsVisible = true;
                PersonPicker.ItemsSource = volunteers;
            }
            else
            {
                PersonPicker.IsVisible = false;
            }
        }

        // 👉 Send button
        private async void OnSendClicked(object sender, EventArgs e)
        {
            string receiver = ReceiverPicker.SelectedItem?.ToString();
            string person = PersonPicker.SelectedItem?.ToString();
            string subject = SubjectEntry.Text?.Trim();
            string message = MessageEditor.Text?.Trim();

            if (string.IsNullOrEmpty(receiver) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(message))
            {
                await DisplayAlert("Error", "Please fill all required fields.", "OK");
                return;
            }

            string finalReceiver = receiver.Contains("Specific") ? person : receiver;

            await DisplayAlert("Notification Sent",
                $"To: {finalReceiver}\nSubject: {subject}\nMessage: {message}",
                "OK");

            // 👉 Future: এখানে DB/Email/SMS Integration করা যাবে
            SubjectEntry.Text = "";
            MessageEditor.Text = "";
            ReceiverPicker.SelectedItem = null;
            PersonPicker.IsVisible = false;
        }

        // 👉 Cancel button
        private async void OnCancelClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Cancel", "Do you want to discard the message?", "Yes", "No");
            if (confirm)
            {
                await Navigation.PopAsync();
            }
        }
    }
}
