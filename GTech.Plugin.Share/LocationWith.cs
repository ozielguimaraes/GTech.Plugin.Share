using System;
using Xamarin.Forms;

namespace GTech.Plugin.Share
{
    public class LocationWith
    {
        private readonly string ClientId;

        public LocationWith() { }
        public LocationWith(string clientId)
        {
            ClientId = clientId;
        }

        public void Uber(Position to)
        {
            try
            {
                Device.OpenUri(new Uri($"uber://?action=setPickup&pickup=my_location&dropoff[latitude]={to.Latitude}&dropoff[longitude]={to.Longitude}&dropoff[formatted_address]={to.Address}"));
            }
            catch
            {
                var appId = Device.RuntimePlatform == Device.Android ? "com.ubercab" : "id368677368";
                OpenStore(appId);
            }
        }

        public void Uber(Position from, Position to)
        {
            try
            {
                Device.OpenUri(new Uri($"uber://?action=setPickup&pickup[latitude]={from.Latitude}&pickup[longitude]={from.Longitude}&dropoff[latitude]={to.Latitude}&dropoff[longitude]={to.Longitude}&dropoff[formatted_address]={to.Address}"));
                //Device.OpenUri(new Uri($"uber://?client_id={ClientId}&action=setPickup&pickup[latitude]={from.Latitude}&pickup[longitude]={from.Longitude}&pickup[formatted_address]={from.Address}&dropoff[latitude]={to.Latitude}&dropoff[longitude]={to.Longitude}&dropoff[formatted_address]={to.Address}&product_id=a1111c8c-c720-46c3-8534-2fcdd730040d&link_text=View%20team%20roster&partner_deeplink=partner%3A%2F%2Fteam%2F9383"));
            }
            catch
            {
                var appId = Device.RuntimePlatform == Device.Android ? "com.ubercab" : "id368677368";
                OpenStore(appId);
            }
        }

        public void Waze(string searchAddres, bool startNavigation = true)
        {
            try
            {
                Device.OpenUri(new Uri($"waze://?q={searchAddres}{GetWazeNavigationOption(startNavigation)}"));
            }
            catch
            {
                var appId = Device.RuntimePlatform == Device.Android ? "com.waze" : "id323229106";
                OpenStore(appId);
            }
        }

        public void Waze(Position to, bool startNavigation = true)
        {
            try
            {
                var latitude = to.Latitude.ToString().Replace(",", ".");
                var longitude = to.Longitude.ToString().Replace(",", ".");
                Device.OpenUri(new Uri($"waze://?ll={latitude}f,{longitude}f{GetWazeNavigationOption(startNavigation)}"));
            }
            catch
            {
                var appId = Device.RuntimePlatform == Device.Android ? "com.waze" : "id323229106";
                OpenStore(appId);
            }
        }

        public void OpenStore(string appId)
        {
            var url = Device.RuntimePlatform == Device.Android ? "market://details?id=" : "http://itunes.apple.com/br/app/";
            Device.OpenUri(new Uri($"{url}{appId}"));
        }

        private string GetWazeNavigationOption(bool startNavigation)
        {
            return startNavigation ? "&navigate=yes" : string.Empty;
        }
    }
}