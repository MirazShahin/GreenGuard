namespace GreenGuard.Views
{
    public partial class AddTreePage : ContentPage
    {
        public AddTreePage()
        {
            InitializeComponent();
        }

        private async void OnSaveTreeClicked(object sender, EventArgs e)
        {
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

            // ✅ Future: Save to database
            await DisplayAlert("Success", $"Tree '{name}' added successfully!\nPrice: {price} BDT\nStock: {stock}", "OK");

            // Back to Admin Dashboard
            await Navigation.PopAsync();
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
