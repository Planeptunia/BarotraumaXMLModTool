namespace BXMT
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        // Custom override to make default windows created have minimum size
        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);
            window.MinimumHeight = 600; // set minimal window height
            window.MinimumWidth = 800; // set minimal window width
            return window;
        }
    }
}
