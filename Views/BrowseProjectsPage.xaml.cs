using System.Collections.ObjectModel;

namespace GreenGuard.Views
{
    public partial class BrowseProjectsPage : ContentPage
    {
        public ObservableCollection<Project> ProjectsList { get; set; }

        public BrowseProjectsPage()
        {
            InitializeComponent();
            LoadProjects();
            ProjectsCollectionView.ItemsSource = ProjectsList;
        }

        private void LoadProjects()
        {
            ProjectsList = new ObservableCollection<Project>
            {
                new Project
                {
                    Title = "Mango Tree Plantation - Zone A",
                    Description = "A community drive to plant 150 mango saplings in school surroundings.",
                    Location = "Mirpur, Dhaka"
                },
                new Project
                {
                    Title = "Neem Green Belt - Zone B",
                    Description = "Creating a green roadside barrier using Neem trees for air purification.",
                    Location = "Uttara, Dhaka"
                },
                new Project
                {
                    Title = "Community Park - Zone C",
                    Description = "Developing an eco-park with multiple tree species and walking paths.",
                    Location = "Dhanmondi, Dhaka"
                }
            };
        }

        private async void OnProjectSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedProject = e.CurrentSelection.FirstOrDefault() as Project;
            if (selectedProject == null)
                return;

            await Navigation.PushAsync(new ProjectDetailsPage(selectedProject));
            ((CollectionView)sender).SelectedItem = null;
        }
    }

    // Model class for project
    public class Project
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }
}
