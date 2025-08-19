namespace A3_nickdamor
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
          
            var navPage = new NavigationPage(new AppShell());
            return new Window(navPage);
        }
    }
}
