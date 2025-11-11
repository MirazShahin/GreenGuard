namespace GreenGuard.Views
{
    public partial class BuyTreePage : ContentPage
    {
        private Tree _tree;

        public class Tree
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }
            public int Quantity { get; set; }
        }

        public BuyTreePage(Tree selectedTree)
        {
            InitializeComponent();
            _tree = selectedTree;

            // Populate UI
            TreeNameLabel.Text = selectedTree.Name;
            TreeDescriptionLabel.Text = selectedTree.Description;
            TreePriceLabel.Text = $"Price: {selectedTree.Price} BDT";
            TreeQuantityLabel.Text = $"Quantity: {selectedTree.Quantity}";
            TotalPriceLabel.Text = $"Total: {selectedTree.Price * selectedTree.Quantity} BDT";
        }

        private async void OnConfirmClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Order Confirmed",
                $"You purchased {_tree.Quantity} {_tree.Name}(s)\nTotal: {_tree.Price * _tree.Quantity} BDT",
                "OK");

            await Navigation.PopToRootAsync(); // back to LoginPage
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(); // back to GuestDashboard
        }
    }
}
