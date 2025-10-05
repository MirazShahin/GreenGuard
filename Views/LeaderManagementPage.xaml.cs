using System.Collections.ObjectModel;

namespace GreenGuard.Views
{
    public partial class LeaderManagementPage : ContentPage
    {
        private List<Leader> leaders;

        public LeaderManagementPage()
        {
            InitializeComponent();

            // Dummy data (later DB থেকে আসবে)
            leaders = new List<Leader>
            {
                new Leader { Name="Rahim Uddin", LeaderId="L001", Zone="Zone A" },
                new Leader { Name="Karim Ali", LeaderId="L002", Zone="Zone B" },
                new Leader { Name="Shila Akter", LeaderId="L003", Zone="Zone C" },
                new Leader { Name="Babul Mia", LeaderId="L004", Zone="Zone A" }
            };

            ApplyFilters();
        }

        // 🔹 Apply search + grouping filter
        private void ApplyFilters()
        {
            string searchText = LeaderSearchBar.Text?.ToLower() ?? "";

            var filtered = leaders
                .Where(l => string.IsNullOrEmpty(searchText) ||
                            l.Name.ToLower().Contains(searchText) ||
                            l.LeaderId.ToLower().Contains(searchText))
                .GroupBy(l => l.Zone)
                .Select(g => new LeaderGroup(g.Key, g.ToList()))
                .ToList();

            GroupedLeaderCollectionView.ItemsSource = filtered;
        }

        // 🔹 Add Leader
        private async void OnAddLeaderClicked(object sender, EventArgs e)
        {
            string name = await DisplayPromptAsync("Add Leader", "Enter leader name:");
            if (string.IsNullOrEmpty(name)) return;

            string id = $"L{leaders.Count + 1:000}";

            // Zones আসবে ZoneManagementPage থেকে
            var zones = ZoneManagementPage.GetZones();
            if (!zones.Any())
            {
                await DisplayAlert("Error", "No zones available. Please add zones first in Zone Management.", "OK");
                return;
            }

            string zone = await DisplayActionSheet("Select Zone", "Cancel", null, zones.ToArray());
            if (zone == "Cancel" || string.IsNullOrEmpty(zone)) return;

            leaders.Add(new Leader { Name = name, LeaderId = id, Zone = zone });
            ApplyFilters();
        }

        // 🔹 Edit Leader
        private async void OnEditClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Leader leader)
            {
                string newName = await DisplayPromptAsync("Edit Leader", "Update leader name:", initialValue: leader.Name);
                if (!string.IsNullOrEmpty(newName))
                {
                    leader.Name = newName;
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
                    leader.Zone = newZone;
                }

                ApplyFilters();
            }
        }

        // 🔹 Remove Leader
        private async void OnRemoveClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Leader leader)
            {
                bool confirm = await DisplayAlert("Confirm", $"Remove leader {leader.Name}?", "Yes", "No");
                if (confirm)
                {
                    leaders.Remove(leader);
                    ApplyFilters();
                }
            }
        }

        // 🔹 Search bar change
        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        // 🔹 Back button
        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }

    // --- Models ---
    public class Leader
    {
        public string Name { get; set; }
        public string LeaderId { get; set; }
        public string Zone { get; set; }
    }

    public class LeaderGroup : ObservableCollection<Leader>
    {
        public string Key { get; }

        public LeaderGroup(string key, IEnumerable<Leader> leaders) : base(leaders)
        {
            Key = key;
        }
    }
}
