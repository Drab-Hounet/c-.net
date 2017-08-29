using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections.Generic;
using Microsoft.Maps.MapControl.WPF;


namespace windowTransport.Views
{
    /// <summary>
    /// Logique d'interaction pour TransportView.xaml
    /// </summary>

    public partial class TransportView : UserControl
    {
        Dictionary<string, int> eventCount = new Dictionary<string, int>();
        Dictionary<string, TextBlock> eventBlocks = new Dictionary<string, TextBlock>();
        public String LatGpsMap;

        public TransportView()
        {
            InitializeComponent();
            //Set focus on map
            myMap.Focus();

            myMap.MouseLeftButtonDown +=
                new MouseButtonEventHandler(MapWithEvents_MouseLeftButtonDown);
            //myMap.MouseLeftButtonUp +=
            //    new MouseButtonEventHandler(MapWithEvents_MouseLeftButtonUp);
        }
        //void MapWithEvents_MouseLeftButtonUp(object sender, MouseEventArgs e)
        //{
        //    // Updates the count of single mouse clicks.
        //    ShowEvent("MapWithEvents_MouseLeftButtonUp");
        //}

        void MapWithEvents_MouseLeftButtonDown(object sender, MouseEventArgs e)
        {
            // Updates the count of mouse pans.
            ShowEvent("MapWithEvents_MouseLeftButtonDown");
        }

        void ShowEvent(string eventName)
        {
            // Updates the display box showing the number of times 
            // the wired events occured.
            if (!eventBlocks.ContainsKey(eventName))
            {
                TextBlock tb = new TextBlock();
                tb.Foreground = new SolidColorBrush(
                    Color.FromArgb(255, 128, 255, 128));
                tb.Margin = new Thickness(5);
                eventBlocks.Add(eventName, tb);
                eventCount.Add(eventName, 0);
                eventsPanel.Children.Add(tb);
            }

            eventCount[eventName]++;
            eventBlocks[eventName].Text = String.Format(
                "{0} - {1} - {2}",
                eventName, eventCount[eventName].ToString(), LatGpsMap);
        }
     
        

        private void MapWithPushpins_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Disables the default mouse double-click action.
            e.Handled = true;

            // Determin the location to place the pushpin at on the map.

            //Get the mouse click coordinates
            Point mousePosition = e.GetPosition(myMap);
            //Convert the mouse coordinates to a locatoin on the map
            Location pinLocation = myMap.ViewportPointToLocation(mousePosition);

            // The pushpin to add to the map.
            Pushpin pin = new Pushpin();
            pin.Location = pinLocation;

            //LatGpsMap = pin.Location.Latitude.ToString();
            LatGpsMap = pinLocation.Latitude.ToString();

            // Adds the pushpin to the map.
            //myMap.Children.Add(pin);
        }
    }
}
