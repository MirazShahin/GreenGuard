namespace GreenGuard.Views
{
    public partial class TreeAnalysisPage : ContentPage
    {
        public TreeAnalysisPage()
        {
            InitializeComponent();  

            var analysis = new List<TreeTypeReport>
            {
                new TreeTypeReport { Type="Fruit Trees", Sold=120 },
                new TreeTypeReport { Type="Flower Trees", Sold=80 },
                new TreeTypeReport { Type="Medicinal Trees", Sold=45 }
            };

            AnalysisCollectionView.ItemsSource = analysis;
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();  
        }
         
        public class TreeTypeReport
        {
            public string Type { get; set; }
            public int Sold { get; set; }
            public string SoldDisplay => $"Total Sold: {Sold}";
        }
    }
}
