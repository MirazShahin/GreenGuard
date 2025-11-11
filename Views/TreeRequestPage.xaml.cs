using Microsoft.Maui.Storage;

namespace GreenGuard.Views
{
    public partial class TreeRequestPage : ContentPage
    {
        private FileResult proofFile;

        public TreeRequestPage()
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
            string zone = ZoneEntry.Text?.Trim();
            string treeType = TreeTypeEntry.Text?.Trim();
            string quantity = QuantityEntry.Text?.Trim();
            string purpose = PurposeEditor.Text?.Trim();
            DateTime requiredDate = RequestDatePicker.Date;

            if (string.IsNullOrEmpty(zone) || string.IsNullOrEmpty(treeType) || string.IsNullOrEmpty(quantity) || string.IsNullOrEmpty(purpose))
            {
                await DisplayAlert("Error", "Please fill all required fields.", "OK");
                return;
            }

            string proofMsg = proofFile != null ? $"Proof attached: {proofFile.FileName}" : "No proof attached";

            await DisplayAlert("Request Submitted",
                $"Zone: {zone}\nTree: {treeType}\nQuantity: {quantity}\nPurpose: {purpose}\nDate: {requiredDate:dd MMM yyyy}\n{proofMsg}",
                "OK");

            await Navigation.PopAsync();
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
