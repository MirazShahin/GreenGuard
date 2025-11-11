using System;
using System.Collections.Generic;

namespace GreenGuard.Views
{
    public partial class PersonalTreePurchasePage : ContentPage
    {
        public class Tree
        {
            public string Emoji { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }
        }

        private Tree selectedTree;
        private int selectedQuantity = 0;

        public PersonalTreePurchasePage()
        {
            InitializeComponent();

            // Dummy data for available trees
            TreeCollectionView.ItemsSource = new List<Tree>
            {
                new Tree { Emoji = "🥭", Name = "Mango Tree", Description = "Sweet mango fruits", Price = 200 },
                new Tree { Emoji = "🌿", Name = "Neem Tree", Description = "Medicinal tree for health", Price = 150 },
                new Tree { Emoji = "🌳", Name = "Guava Tree", Description = "Juicy guava fruits", Price = 180 },
                new Tree { Emoji = "🍊", Name = "Orange Tree", Description = "Citrus fruit for vitamins", Price = 220 },
                new Tree { Emoji = "🌸", Name = "Rose Plant", Description = "Beautiful red roses", Price = 120 },
                new Tree { Emoji = "🎋", Name = "Bamboo", Description = "Strong, fast-growing bamboo", Price = 250 }
            };
        }

        // When a user clicks on "Select"
        private void OnSelectTreeClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Tree tree)
            {
                selectedTree = tree;
                PurchaseFrame.IsVisible = true;
                SelectedTreeLabel.Text = $"Selected: {tree.Emoji} {tree.Name} ({tree.Price} BDT each)";
                QuantityEntry.Text = "";
                TotalPriceLabel.Text = "Total: 0 BDT";
            }
        }

        // When quantity changes
        private void OnQuantityChanged(object sender, TextChangedEventArgs e)
        {
            if (selectedTree == null) return;

            if (int.TryParse(QuantityEntry.Text, out int qty) && qty > 0)
            {
                selectedQuantity = qty;
                int total = selectedTree.Price * qty;
                TotalPriceLabel.Text = $"Total: {total} BDT";
            }
            else
            {
                TotalPriceLabel.Text = "Total: 0 BDT";
                selectedQuantity = 0;
            }
        }

        // Confirm Purchase
        private async void OnConfirmClicked(object sender, EventArgs e)
        {
            if (selectedTree == null || selectedQuantity <= 0)
            {
                await DisplayAlert("Error", "Please select a valid tree and enter quantity.", "OK");
                return;
            }

            int total = selectedTree.Price * selectedQuantity;

            await DisplayAlert("✅ Purchase Confirmed",
                $"You purchased {selectedQuantity} {selectedTree.Name}(s)\nTotal: {total} BDT",
                "OK");

            // Reset UI
            PurchaseFrame.IsVisible = false;
            QuantityEntry.Text = "";
            selectedQuantity = 0;
        }

        // Back navigation
        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
