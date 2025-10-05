using GreenGuard.Models;
using GreenGuard.PageModels;

namespace GreenGuard.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}