using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GTech.Plugin.Share.Sample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShareLocationPage : ContentPage
    {
        public ShareLocationPage()
        {
            InitializeComponent();
        }

        private void ShareWithUber_Clicked(object sender, EventArgs e)
        {
            var share = new LocationWith();
            share.Uber(new Position(-18.9141075f, -48.2670119f, "Amil Saúde"));
        }

        private void ShareWithWaze_Clicked(object sender, EventArgs e)
        {
            var share = new LocationWith();
            var position = new Position(-18.9141075f, -48.2670119f);
            share.Waze(position);
        }
    }
}