using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mobile.DataGrid;
using Xamarin.Forms;

namespace XamDataGridSample
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            var appTitle = "Grid Demo - CodeFest.at Feeds";
            var pageTitle = "datagrids everywhere";

            Label mainheader = new Label()
            {
                Text = appTitle,
                TextColor = Color.White,
                Font = Device.OnPlatform(
                    Font.SystemFontOfSize(NamedSize.Large),  //ios
                    Font.SystemFontOfSize(NamedSize.Large),  //Android
                    Font.SystemFontOfSize(50))                //WP8
            };

            Label subHeader = new Label()
            {
                Text = pageTitle,
                TextColor = Color.White,
                Font = Font.SystemFontOfSize(NamedSize.Default)
            };

            var infoFooter = new Label()
            {
                Text = "Loading data...",
                TextColor = Color.White,
                Font = Font.SystemFontOfSize(NamedSize.Default)
            };
            var activityIndicator = new ActivityIndicator()
            {
                IsVisible = true,
                IsRunning = true
            };

            this.Content = new StackLayout()
            {
                Children =
                {
                    mainheader,
                    subHeader,
                    activityIndicator,
                    infoFooter
                }
            };
            ReadFeedList();
        }

        private async Task ReadFeedList()
        {
            var rssEntries = await RssParser.GetFeedInfo(
                new Uri("http://feeds.feedburner.com/Codefest?fmt=xml"));

            GridControl grid = new GridControl();

            grid.Columns.Add(new DateColumn() { DisplayFormat = "d",
                Caption = "Date", FieldName = "PubDate", Width = 75 });
            grid.Columns.Add(new TextColumn() { Caption = "Author",
                FieldName = "Author", Width = 75 });
            grid.Columns.Add(new TextColumn() { Caption = "Title",
                FieldName = "Title" });

            grid.ItemsSource = rssEntries;

            var content = this.Content as StackLayout;
            content.Children.RemoveAt(3);
            content.Children.RemoveAt(2);
            content.Children.Add(grid);
        }
    }
}
