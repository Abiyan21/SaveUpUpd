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

        /// <summary>
        /// Einziges Grund wieso ich dies so programmiert habe ist wegen eines Problems auf Xamarins Seite. Das Property "Command" funktioniert seit 8 Jahren nicht richtig beim MenuItem.
        /// Aus diesem Grund konnte ich nicht das MVVM Pattern richtig anwenden bei diesem Command.
        /// Es ist einfach ein sehr simples Command das zur Language Seite weiterleitet, damit der Benutzer eine andere Sprache auswählen kann.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MenuItem_OnClicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new LanguagePage());

        }
    }
}
