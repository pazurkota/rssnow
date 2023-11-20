namespace rssnow;

public partial class App : Application {
    public static RssLinkRepository Repository { get; private set; }
    
    public App(RssLinkRepository repo) {
        InitializeComponent();

        MainPage = new AppShell();

        Repository = repo;
    }
}