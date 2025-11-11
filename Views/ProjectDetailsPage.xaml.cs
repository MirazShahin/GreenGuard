namespace GreenGuard.Views
{
    public partial class ProjectDetailsPage : ContentPage
    {
        private readonly Project _selectedProject;

        public ProjectDetailsPage(Project project)
        {
            InitializeComponent();
            _selectedProject = project;
            LoadProjectDetails();
        }

        private void LoadProjectDetails()
        {
            TitleLabel.Text = _selectedProject.Title;
            DescriptionLabel.Text = _selectedProject.Description;
            LocationLabel.Text = $"📍 Location: {_selectedProject.Location}";
        }

        private async void OnRequestClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Confirm Request",
                $"Do you want to request tree plantation for '{_selectedProject.Title}'?",
                "Yes", "No");

            if (confirm)
                await DisplayAlert("Success", "Your plantation request has been sent to Admin!", "OK");
        }

        private async void OnSupportClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Confirm Support",
                $"Do you want to financially support '{_selectedProject.Title}'?",
                "Yes", "No");

            if (confirm)
                await DisplayAlert("Thank You 💚", "Your contribution will help this plantation succeed!", "OK");
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
