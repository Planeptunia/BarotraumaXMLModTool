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


            // Setting default window size to 1280x720
            window.Height = 720;
            window.Width = 1280;

            DisplayInfo userDisplay = new DisplayInfo();

            window.Y = (userDisplay.Height + window.Height) / 2.0;
            window.X = (userDisplay.Width + window.Width) / 2.0;

            return window;
        }
    }
}
