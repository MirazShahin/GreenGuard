namespace GreenGuard.Views
{
    public partial class GuestDashboard : ContentPage
    {
        public class Tree
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }
            public int Quantity { get; set; } = 1; 
        }

        public GuestDashboard()
        {
            InitializeComponent();
            TreeCollectionView.ItemsSource = new List<Tree>
            {
                new Tree { Name = "Mango Tree", Description = "Sweet mango fruits", Price = 200 },
                new Tree { Name = "Jackfruit Tree", Description = "Large jackfruit", Price = 250 },
                new Tree { Name = "Guava Tree", Description = "Delicious guava fruits", Price = 150 },
                new Tree { Name = "Litchi Tree", Description = "Seasonal litchi fruits", Price = 300 },
                new Tree { Name = "Banana Plant", Description = "Fast growing bananas", Price = 120 },
                new Tree { Name = "Papaya Tree", Description = "Healthy papayas", Price = 130 },
                new Tree { Name = "Coconut Tree", Description = "Tall coconut palms", Price = 400 },
                new Tree { Name = "Orange Tree", Description = "Citrus orange fruits", Price = 220 },
                new Tree { Name = "Apple Tree", Description = "Sweet apples", Price = 350 },
                new Tree { Name = "Pomegranate Tree", Description = "Red juicy pomegranates", Price = 280 },
                new Tree { Name = "Neem Tree", Description = "Medicinal neem tree", Price = 100 },
                new Tree { Name = "Tulsi Plant", Description = "Holy basil medicinal plant", Price = 50 },
                new Tree { Name = "Peepal Tree", Description = "Sacred peepal tree", Price = 180 },
                new Tree { Name = "Ashoka Tree", Description = "Sacred Ashoka", Price = 200 },
                new Tree { Name = "Rose Plant", Description = "Beautiful red roses", Price = 100 },
                new Tree { Name = "Hibiscus Plant", Description = "Bright hibiscus flowers", Price = 120 },
                new Tree { Name = "Marigold Plant", Description = "Golden marigold flowers", Price = 90 },
                new Tree { Name = "Jasmine Plant", Description = "Fragrant jasmine flowers", Price = 150 },
                new Tree { Name = "Sunflower Plant", Description = "Tall sunflower", Price = 110 },
                new Tree { Name = "Orchid Plant", Description = "Exotic orchid flowers", Price = 350 },
                new Tree { Name = "Lotus Plant", Description = "Sacred lotus flower", Price = 250 },
                new Tree { Name = "Bamboo Plant", Description = "Lucky bamboo", Price = 130 }
            };
        }
        private async void OnBuyTreeClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Tree selectedTree)
            {
                await Navigation.PushAsync(new BuyTreePage(new BuyTreePage.Tree
                {
                    Name = selectedTree.Name,
                    Description = selectedTree.Description,
                    Price = selectedTree.Price,
                    Quantity = selectedTree.Quantity
                }));
            }
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Logout", "Do you really want to logout?", "Yes", "No");
            if (confirm)
            {
                await Navigation.PopToRootAsync(); 
            }
        }
    }
}
