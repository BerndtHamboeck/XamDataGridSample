using System;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamDataGridSample
{
    public partial class MainXamlPage : ContentPage
    {
        public MainXamlPage()
        {
            InitializeComponent();

            ReadFeedList();
        }

        private async Task ReadFeedList()
        {
            var rssEntries = await RssParser.GetFeedInfo(
                new Uri("http://feeds.feedburner.com/Codefest?fmt=xml"));

            BindingContext = rssEntries;
            activityIndicator.IsVisible = false;
        }
    }
}


