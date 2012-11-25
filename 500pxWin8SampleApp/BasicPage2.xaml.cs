using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using _500pxWin8SampleApp.Data;
using _500pxWin8SampleApp.DataModel;
// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace _500pxWin8SampleApp
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    /// 
    public sealed partial class BasicPage2 : _500pxWin8SampleApp.Common.LayoutAwarePage
    {
        EventsDataAccess eventsDataAccess = new EventsDataAccess();

        public BasicPage2()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string name = e.Parameter as string;
            this.EventLabel.Text = name;
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            getEvents();
        }

        async void getEvents()
        {
            var events = await eventsDataAccess.Get();
            Debug.WriteLine("events");
            foreach (var item in events)
            {
                Debug.WriteLine("Id={0}, EventName={1}, EventHashTag={2}", item.Id, item.EventName, item.EventHashTag);
            }
            App._events = events;
            var imageDataGroups = ImageDataSource.GetGroups("AllGroups");
            this.DefaultViewModel["Groups"] = imageDataGroups;
            this.Frame.Navigate(typeof(GroupedItemsPage), imageDataGroups);
        }
        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {

        }
    }
}
