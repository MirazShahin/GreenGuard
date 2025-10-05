using GreenGuard.Views;

namespace GreenGuard;

public partial class App : Application
{
    public App()
    {
        InitializeComponent(); 
        MainPage = new NavigationPage(new LoginPage());
    }
}
