using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SaveUpUpd.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void MenuItem_OnClicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new LanguagePage());

        }
    }
}
