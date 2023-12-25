using rssnow.Views;

namespace rssnow;

public partial class AppShell : Shell {
    public AppShell() {
        InitializeComponent();
        
        Routing.RegisterRoute("channelspage", typeof(RssChannelsPage));
        Routing.RegisterRoute("contentpage", typeof(RssChannelContentPage));
    }
}