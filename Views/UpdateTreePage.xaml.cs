namespace GreenGuard.Views
{
    public partial class UpdateTreePage : ContentPage
    {
        // Mock tree data (later DB থেকে আসবে)
        private List<Tree> trees = new List<Tree>
        {
            new Tree { Name = "Mango Tree", Description = "Sweet mango fruits", Price = 200, Stock = 50 },
            new Tree { Name = "Neem Tree", Description = "Medicinal tree", Price = 100, Stock = 30 },
            new Tree { Name = "Rose Plant", Description = "Red roses", Price = 120, Stock = 40 }
        };

        public UpdateTreePage()
        {
            InitializeComponent();
            TreePicker.ItemsSource = trees.Select(t => t.Name).ToList();
        }

        private void OnTreeSelected(object sender, EventArgs e)
        {
            if (TreePicker.SelectedIndex == -1) return;

            string selectedTreeName = TreePicker.SelectedItem.ToString();
            var tree = trees.FirstOrDefault(t => t.Name == selectedTreeName);

            if (tree != null)
            {
                TreeNameEntry.Text = tree.Name;
                TreeDescriptionEditor.Text = tree.Description;
                TreePriceEntry.Text = tree.Price.ToString();
                TreeStockEntry.Text = tree.Stock.ToString();
            }
        }

        private async void OnUpdateTreeClicked(object sender, EventArgs e)
        {
            if (TreePicker.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "Please select a tree to update.", "OK");
                return;
            }

            string name = TreeNameEntry.Text?.Trim();
            string description = TreeDescriptionEditor.Text?.Trim();
            string priceText = TreePriceEntry.Text?.Trim();
            string stockText = TreeStockEntry.Text?.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) ||
                string.IsNullOrEmpty(priceText) || string.IsNullOrEmpty(stockText))
            {
                await DisplayAlert("Error", "All fields are required!", "OK");
                return;
            }

            if (!int.TryParse(priceText, out int price) || !int.TryParse(stockText, out int stock))
            {
                await DisplayAlert("Error", "Price and Stock must be valid numbers!", "OK");
                return;
            }

            // Update selected tree
            string selectedTreeName = TreePicker.SelectedItem.ToString();
            var tree = trees.FirstOrDefault(t => t.Name == selectedTreeName);

            if (tree != null)
            {
                tree.Name = name;
                tree.Description = description;
                tree.Price = price;
                tree.Stock = stock;

                await DisplayAlert("Success", $"Tree '{name}' updated successfully!", "OK");
                await Navigation.PopAsync(); // Back to AdminDashboard
            }
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        // Tree model
        public class Tree
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }
            public int Stock { get; set; }
        }
    }
}
