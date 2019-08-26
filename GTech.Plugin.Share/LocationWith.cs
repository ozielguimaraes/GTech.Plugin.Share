using System;
using Xamarin.Forms;

namespace GTech.Plugin.Share
{
    public class LocationWith
    {
        private readonly string ClientId;

        public LocationWith(string clientId)
        {
            ClientId = clientId;
        }

        public void Uber(Position from, Position to)
        {
                                     //uber://?action=setPickup&pickup=my_location&dropoff%5Bformatted_address%5D=Uber%20HQ%2C%20Market%20Street%2C%20San%20Francisco%2C%20CA%2C%20USA&dropoff%5Blatitude%5D=37.775231&dropoff%5Blongitude%5D=-122.417528
            Device.OpenUri(new Uri($"uber://?action=setPickup&pickup=my_location={from.Address}&dropoff[latitude]={to.Latitude}&dropoff[longitude]={to.Longitude}&dropoff[formatted_address]={to.Address}"));
            //Device.OpenUri(new Uri($"uber://?client_id={ClientId}&action=setPickup&pickup[latitude]={from.Latitude}&pickup[longitude]={from.Longitude}&pickup[formatted_address]={from.Address}&dropoff[latitude]={to.Latitude}&dropoff[longitude]={to.Longitude}&dropoff[formatted_address]={to.Address}&product_id=a1111c8c-c720-46c3-8534-2fcdd730040d&link_text=View%20team%20roster&partner_deeplink=partner%3A%2F%2Fteam%2F9383"));
        }
    }
}