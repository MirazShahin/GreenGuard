namespace GreenGuard.Views
{
    public partial class SalesSummaryPage : ContentPage
    {
        public SalesSummaryPage()
        {
            InitializeComponent();

            // Dummy Data (later DB থেকে আসবে)
            int totalSold = 250;
            int totalIncome = 75000;
            string topTree = "Mango Tree";

            var categorySales = new List<CategorySale>
            {
                new CategorySale { Category="Fruit Trees", Sold=150 },
                new CategorySale { Category="Flower Trees", Sold=60 },
                new CategorySale { Category="Medicinal Trees", Sold=40 }
            };

            // Update UI
            TotalSoldLabel.Text = $"Total Trees Sold: {totalSold}";
            TotalIncomeLabel.Text = $"Total Income: {totalIncome} BDT";
            TopTreeLabel.Text = $"Top Selling Tree: {topTree}";

            CategorySalesCollection.ItemsSource = categorySales;
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        // Model
        public class CategorySale
        {
            public string Category { get; set; }
            public int Sold { get; set; }
            public string SoldText => $"Sold: {Sold}";
        }
    }
}
