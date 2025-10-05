namespace GreenGuard.Views
{
    public partial class InventoryPage : ContentPage
    {
        private List<TreeInventory> inventory;
        private List<TreeInventory> filteredInventory;

        public InventoryPage()
        {
            InitializeComponent();

            // Dummy Data (later DB থেকে আসবে)
            inventory = new List<TreeInventory>
            {
                new TreeInventory { Name="Mango Tree", Category="Fruit", Available=50, Sold=70 },
                new TreeInventory { Name="Neem Tree", Category="Medicinal", Available=30, Sold=40 },
                new TreeInventory { Name="Rose Plant", Category="Flower", Available=80, Sold=20 },
                new TreeInventory { Name="Coconut Tree", Category="Fruit", Available=25, Sold=60 },
                new TreeInventory { Name="Tulsi Plant", Category="Medicinal", Available=60, Sold=15 },
                new TreeInventory { Name="Jasmine Plant", Category="Flower", Available=40, Sold=25 }
            };

            filteredInventory = new List<TreeInventory>(inventory);
            RefreshUI();
        }

        private void RefreshUI()
        {
            InventoryCollection.ItemsSource = null;
            InventoryCollection.ItemsSource = filteredInventory;
        }

        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void OnCategoryChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string searchText = TreeSearchBar.Text?.ToLower() ?? "";
            string selectedCategory = CategoryPicker.SelectedItem?.ToString() ?? "All";

            filteredInventory = inventory
                .Where(t => (string.IsNullOrEmpty(searchText) || t.Name.ToLower().Contains(searchText))
                            && (selectedCategory == "All" || t.Category == selectedCategory))
                .ToList();

            RefreshUI();
        }

        private async void OnUpdateClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is TreeInventory tree)
            {
                string newStock = await DisplayPromptAsync("Update Stock",
                    $"Enter new stock value for {tree.Name}:",
                    "OK", "Cancel", initialValue: tree.Available.ToString());

                if (int.TryParse(newStock, out int stock))
                {
                    tree.Available = stock;
                    RefreshUI();
                    await DisplayAlert("Success", $"{tree.Name} stock updated to {stock}.", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "Invalid number entered.", "OK");
                }
            }
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        // Model
        public class TreeInventory
        {
            public string Name { get; set; }
            public string Category { get; set; }
            public int Available { get; set; }
            public int Sold { get; set; }

            public string StockDisplay => $"Available: {Available}";
            public string SoldDisplay => $"Sold: {Sold}";
        }
    }
}
