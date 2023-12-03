using rssnow.Views;

namespace rssnow;

public partial class AppShell : Shell {
    public AppShell() {
        InitializeComponent();
        
        Routing.RegisterRoute(nameof(RssChannelsPage), typeof(RssChannelsPage));
        Routing.RegisterRoute(nameof(RssChannelContentPage), typeof(RssChannelContentPage));
    }
}