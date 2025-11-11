using System.Collections.ObjectModel;

namespace GreenGuard.Views
{
    public partial class VolunteerManagementPage : ContentPage
    {
        private List<Volunteer> volunteers;

        public VolunteerManagementPage()
        {
            InitializeComponent();

            // Dummy data (later DB থেকে আসবে)
            volunteers = new List<Volunteer>
            {
                new Volunteer { Name="Alamin", VolunteerId="V001", Zone="Zone A" },
                new Volunteer { Name="Sadia", VolunteerId="V002", Zone="Zone B" },
                new Volunteer { Name="Rakib", VolunteerId="V003", Zone="Zone C" },
                new Volunteer { Name="Mitu", VolunteerId="V004", Zone="Zone A" }
            };

            ApplyFilters();
        }

        // 🔹 Grouped refresh
        private void ApplyFilters()
        {
            string searchText = VolunteerSearchBar.Text?.ToLower() ?? "";

            var filtered = volunteers
                .Where(v => string.IsNullOrEmpty(searchText) ||
                            v.Name.ToLower().Contains(searchText) ||
                            v.VolunteerId.ToLower().Contains(searchText))
                .GroupBy(v => v.Zone)
                .Select(g => new VolunteerGroup(g.Key, g.ToList()))
                .ToList();

            GroupedVolunteerCollectionView.ItemsSource = filtered;
        }

        // 🔹 Add Volunteer
        private async void OnAddVolunteerClicked(object sender, EventArgs e)
        {
            string name = await DisplayPromptAsync("Add Volunteer", "Enter volunteer name:");
            if (string.IsNullOrEmpty(name)) return;

            string id = $"V{volunteers.Count + 1:000}";

            var zones = ZoneManagementPage.GetZones();
            if (!zones.Any())
            {
                await DisplayAlert("Error", "No zones available. Please add zones first in Zone Management.", "OK");
                return;
            }

            string zone = await DisplayActionSheet("Select Zone", "Cancel", null, zones.ToArray());
            if (zone == "Cancel" || string.IsNullOrEmpty(zone)) return;

            volunteers.Add(new Volunteer { Name = name, VolunteerId = id, Zone = zone });
            ApplyFilters();
        }

        // 🔹 Edit Volunteer
        private async void OnEditClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Volunteer volunteer)
            {
                string newName = await DisplayPromptAsync("Edit Volunteer", "Update volunteer name:", initialValue: volunteer.Name);
                if (!string.IsNullOrEmpty(newName))
                {
                    volunteer.Name = newName;
                }

                var zones = ZoneManagementPage.GetZones();
                if (!zones.Any())
                {
                    await DisplayAlert("Error", "No zones available to select.", "OK");
                    return;
                }

                string newZone = await DisplayActionSheet("Update Zone", "Cancel", null, zones.ToArray());
                if (newZone != "Cancel" && !string.IsNullOrEmpty(newZone))
                {
                    volunteer.Zone = newZone;
                }

                ApplyFilters();
            }
        }

        // 🔹 Remove Volunteer
        private async void OnRemoveClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Volunteer volunteer)
            {
                bool confirm = await DisplayAlert("Confirm", $"Remove volunteer {volunteer.Name}?", "Yes", "No");
                if (confirm)
                {
                    volunteers.Remove(volunteer);
                    ApplyFilters();
                }
            }
        }

        // 🔹 Search bar
        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        // 🔹 Back
        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }

    // --- Models ---
    public class Volunteer
    {
        public string Name { get; set; }
        public string VolunteerId { get; set; }
        public string Zone { get; set; }
    }

    public class VolunteerGroup : ObservableCollection<Volunteer>
    {
        public string Key { get; }

        public VolunteerGroup(string key, IEnumerable<Volunteer> volunteers) : base(volunteers)
        {
            Key = key;
        }
    }
}
