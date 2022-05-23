using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using SaveUpUpd.Model;
using System.Collections.ObjectModel;
using SaveUpUpd.View;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;
using SaveUpUpd;

namespace SaveUpUpd.ViewModel
{
    public class MainPageVM : ViewModelBase
    {
        /// <summary>
        /// Variablen
        /// </summary>
        private MainModel DModel;
        private ObservableCollection<MainModel> _mainModels = new ObservableCollection<MainModel>();
        public ObservableCollection<MainModel> MainModels
        {
            get { return _mainModels; }
            set { _mainModels = value; OnPropertyChanged(); }
        }
        public float Geld
        {
            get { return DModel.Geld; }
            set
            {
                DModel.Geld = value; OnPropertyChanged(); 
            }
        }
        public string Detail
        {
            get { return DModel.Detail; }
            set
            {
                DModel.Detail = value; OnPropertyChanged();
            }
        }
        public string Datum
        {
            get { return DModel.Datum; }
            set
            {
                DModel.Datum = value; OnPropertyChanged();
            }
        }

        public int ID
        {
            get { return DModel.ID; }
            set
            {
                DModel.ID = value; OnPropertyChanged();
            }
        }

        /// <summary>
        /// Constructor (Macht ein Object aus MainModel)
        /// </summary>
        public MainPageVM()
        {
            DModel = new MainModel();
        }

        /// <summary>
        /// Einfügen Command (Ruft die AddToList Methode)
        /// </summary>
        public Command Einfügen
        {
            get
            {
                return new Command(() =>
                {
                    AddToList();
                });
            }
        }
       
        /// <summary>
        /// Einträge Command (Ruft die OpenListPage Methode)
        /// </summary>
        public Command Einträge
        {
            get
            {
                return new Command( () =>
                {
                    OpenListPage();
                });
            }
        }

        /// <summary>
        /// Delete Command (Ruft die DeleteList Methode)
        /// </summary>
        public Command Delete
        {
            get
            {
                return new Command(() =>
                {
                    DeleteList();
                });
            }
        }
        
        /// <summary>
        /// OpenListPage Methode. Navigiert den Benutzer zum ListPage.
        /// </summary>
        private async void OpenListPage()
        {
            var file = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "eintraege.json");
            if (File.Exists(file))
            {
                if (new FileInfo(file).Length == 0)
                {
                    await App.Current.MainPage.DisplayAlert("Liste ist leer!", " Bitte fügen Sie zuerst einen Eintrag ein", "OK");
                }
                else
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new ListPage());
                }
            }
            else
            {
                File.Create(file).Dispose();
            }

        }

        /// <summary>
        /// AddToList Methode. Fügt die EintragDaten in die Datei ein.
        /// </summary>
        private void AddToList()
        {
            _mainModels.Clear();
            var file = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "eintraege.json");
            if (File.Exists(file))
            {
                if(new FileInfo(file).Length > 0)
                {
                    var json = File.ReadAllText(file);
                    List<MainModel> dataList = JsonConvert.DeserializeObject<List<MainModel>>(json);
                    var data = new ObservableCollection<MainModel>(dataList);
                    _mainModels = data;
                }
            }
            else
            {
                File.Create(file).Dispose();
            }

            Datum = DateTime.Now.ToString("dd.MM.yy");
            if (_mainModels.Count == 0)
            {
                ID = 0;
            }
            else
            {
                ID = _mainModels.Count + 1;
            }
            _mainModels.Add(DModel);

            string input = JsonConvert.SerializeObject(_mainModels);
            File.WriteAllText(file, input);
        }

        /// <summary>
        /// DeleteList Methode. Löscht die Liste und erstellt eine neue leere Datei.
        /// </summary>
        private async void DeleteList()
        {
            var choice = await App.Current.MainPage.DisplayAlert("Achtung!", "Sind Sie sicher, dass Sie die Liste löschen wollen?", "Ja", "Nein");
            if(choice)
            {
                var file = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "eintraege.json");
                File.Create(file).Dispose();
            }
        }

    }
}
