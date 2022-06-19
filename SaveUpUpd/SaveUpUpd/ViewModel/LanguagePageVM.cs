using Newtonsoft.Json;
using SaveUpUpd.Model;
using SaveUpUpd.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Xamarin.Forms;

namespace SaveUpUpd.ViewModel
{
    public class LanguagePageVM
    {
        /// <summary>
        /// Ruft die germanlang Methode auf
        /// </summary>
        public Command germanbutton
        {
            get
            {
                return new Command(() =>
                {
                    germanlang();
                });
            }
        }

        /// <summary>
        /// Ruft die englishlang Methode auf
        /// </summary>
        public Command englishbutton
        {
            get
            {
                return new Command(() =>
                {
                    englishlang();
                });
            }
        }

        /// <summary>
        /// Wechselt die Sprache zu Deutsch
        /// </summary>
        private async void germanlang()
        {
            var file = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "language.json");
            string lang = "de";
            string input = JsonConvert.SerializeObject(lang);
            File.WriteAllText(file, input);

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("de");
            await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
        }

        /// <summary>
        /// Wechselt die Sprache zu Englisch
        /// </summary>
        private async void englishlang()
        {
            var file = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "language.json");
            string lang = "en";
            string input = JsonConvert.SerializeObject(lang);
            File.WriteAllText(file, input);

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
        }

    }
}
