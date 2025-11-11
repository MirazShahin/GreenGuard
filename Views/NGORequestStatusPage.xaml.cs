namespace GreenGuard.Views
{
    public partial class NGORequestStatusPage : ContentPage
    {
        public class NGORequest
        {
            public string Zone { get; set; }
            public string Location { get; set; }
            public string TreeType { get; set; }
            public int TreeCount { get; set; }
            public string Status { get; set; }
            public Color StatusColor { get; set; }
        }

        public NGORequestStatusPage()
        {
            InitializeComponent();

            // Dummy data (later integrate with DB)
            var requests = new List<NGORequest>
            {
                new NGORequest { Zone = "Dhaka Zone A", Location = "Mirpur", TreeType = "Mango", TreeCount = 100, Status = "Pending", StatusColor = Colors.Orange },
                new NGORequest { Zone = "Chattogram Zone B", Location = "Patenga", TreeType = "Neem", TreeCount = 200, Status = "Approved", StatusColor = Colors.LightGreen },
                new NGORequest { Zone = "Rajshahi Zone C", Location = "Boalia", TreeType = "Guava", TreeCount = 150, Status = "Rejected", StatusColor = Colors.Red }
            };

            RequestCollectionView.ItemsSource = requests;
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
