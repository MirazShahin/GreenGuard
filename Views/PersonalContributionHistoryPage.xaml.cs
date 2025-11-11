using System;
using System.Collections.Generic;

namespace GreenGuard.Views
{
    public partial class PersonalContributionHistoryPage : ContentPage
    {
        public class PurchaseHistory
        {
            public string Emoji { get; set; }
            public string TreeName { get; set; }
            public int Quantity { get; set; }
            public int TotalPrice { get; set; }
            public DateTime PurchaseDate { get; set; }
        }

        public PersonalContributionHistoryPage()
        {
            InitializeComponent();
            LoadHistory();
        }

        private void LoadHistory()
        {
            // Sample dummy data (later replace with DB or API)
            var history = new List<PurchaseHistory>
            {
                new PurchaseHistory { Emoji = "🥭", TreeName = "Mango Tree", Quantity = 5, TotalPrice = 1000, PurchaseDate = DateTime.Now.AddDays(-7) },
                new PurchaseHistory { Emoji = "🌿", TreeName = "Neem Tree", Quantity = 3, TotalPrice = 450, PurchaseDate = DateTime.Now.AddDays(-12) },
                new PurchaseHistory { Emoji = "🍊", TreeName = "Orange Tree", Quantity = 2, TotalPrice = 440, PurchaseDate = DateTime.Now.AddDays(-20) }
            };

            if (history.Count == 0)
            {
                EmptyLabel.IsVisible = true;
                HistoryCollectionView.IsVisible = false;
            }
            else
            {
                EmptyLabel.IsVisible = false;
                HistoryCollectionView.ItemsSource = history;
            }
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
