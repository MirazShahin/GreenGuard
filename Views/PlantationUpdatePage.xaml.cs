using Microsoft.Maui.Storage;

namespace GreenGuard.Views
{
    public partial class PlantationUpdatePage : ContentPage
    {
        private FileResult proofFile;

        public PlantationUpdatePage()
        {
            InitializeComponent();
        }

        private async void OnUploadProofClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Select Proof (Image or Video)",
                    FileTypes = FilePickerFileType.Images
                });

                if (result != null)
                {
                    proofFile = result;
                    ProofImage.Source = ImageSource.FromFile(result.FullPath);
                    ProofImage.IsVisible = true;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"File selection failed: {ex.Message}", "OK");
            }
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Submitted", "Plantation update submitted with proof!", "OK");
            await Navigation.PopAsync();
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
