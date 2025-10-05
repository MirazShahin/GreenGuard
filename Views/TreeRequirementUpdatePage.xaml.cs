namespace GreenGuard.Views
{
    public partial class TreeRequirementUpdatePage : ContentPage
    {
        public TreeRequirementUpdatePage()
        {
            InitializeComponent();

            // 👉 আজকের তারিখ ডিফল্ট সেট করবো এখানে
            RequirementDatePicker.Date = DateTime.Now;
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            string zone = ZoneEntry.Text;
            string project = ProjectEntry.Text;
            string treeType = TreeTypeEntry.Text;
            string count = TreeCountEntry.Text;
            string date = RequirementDatePicker.Date.ToString("dd MMM yyyy");

            await DisplayAlert("Requirement Submitted",
                $"Zone: {zone}\nProject: {project}\nTree Type: {treeType}\nCount: {count}\nDate: {date}",
                "OK");

            await Navigation.PopAsync();
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
