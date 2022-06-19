using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using SaveUpUpd.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SaveUpUpd.View;

namespace SaveUpUpd
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Überprüft ob der Benutzer schon eine Sprache ausgwählt hat. Falls ja wird der Benutzer direkt zum MainPage weitergeleitet. Falls nicht wird er zur LanguagePage weitergeleitet, wo er die bevorzugte Sprache auswählen kann.
            var file = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "language.json");
            if (File.Exists(file))
            {
                if (new FileInfo(file).Length > 0)
                {
                    var json = File.ReadAllText(file);
                    string lng = JsonConvert.DeserializeObject<string>(json);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(lng);
                    MainPage = new NavigationPage(new MainPage());
                }
                else
                {
                    MainPage = new NavigationPage(new LanguagePage());
                }
            }
            else
            {
                MainPage = new NavigationPage(new LanguagePage());
            }
            

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
