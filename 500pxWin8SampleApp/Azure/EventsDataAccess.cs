﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using Microsoft.WindowsAzure.MobileServices;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace _500pxWin8SampleApp
{
    public class Events
    {
        public int Id { get; set; }

        [DataMember(Name = "eventName")]
        public string EventName { get; set; }

        [DataMember(Name = "eventHashTag")]
        public string EventHashTag { get; set; }

        public DateTime EventDate { get; set; }
    }

    public class EventsDataAccess
    {
        // MobileServiceCollectionView implements ICollectionView (useful for databinding to lists) and 
        // is integrated with your Mobile Service to make it easy to bind your data to the ListView
        private ObservableCollection<Events> items;

        private IMobileServiceTable<Events> mobileServiceTable = App.MobileService.GetTable<Events>();

        public async Task<int> Insert(Events item)
        {
            // This code inserts a new Events into the database. When the operation completes
            // and Mobile Services has assigned an Id, the item is added to the CollectionView
            await mobileServiceTable.InsertAsync(item);

            return item.Id;
           // items.Add(events);
        }

        public async void Update(Events item)
        {
            // This code takes a freshly completed Events and updates the database. When the MobileService 
            // responds, the item is removed from the list 
            await mobileServiceTable.UpdateAsync(item);
        }

        public async void Delete(Events item)
        {
            // This code takes a freshly completed Events and updates the database. When the MobileService 
            // responds, the item is removed from the list 
            await mobileServiceTable.DeleteAsync(item);
            //items.Remove(item);
        }

        public async Task<ObservableCollection<Events>> Get()
        {
            var results = await mobileServiceTable.ToListAsync();
            items = new ObservableCollection<Events>(results.ToList());
            return items;
        }

     

    }
}
