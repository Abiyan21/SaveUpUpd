using Newtonsoft.Json;
using SaveUpUpd.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using SaveUpUpd.View;
using System.Reflection;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using System.Windows.Input;

namespace SaveUpUpd.ViewModel
{
    public class ListPageVM : ViewModelBase
    {
        /// <summary>
        /// Variable
        /// </summary>
        private ObservableCollection<MainModel> data;
        public ObservableCollection<MainModel> Data
        {
            get { return data; }
            set { data = value; OnPropertyChanged(); }
        }
        private double gesamt;
        public double Gesamt
        {
            get { return gesamt; }
            set { gesamt = value; OnPropertyChanged(); }
        }
        /// <summary>
        /// Delete Command (Ruft die Delete Methode auf und gibt die Variable id weiter)
        /// </summary>
        public Command Delete
        {
            get
            {
                return new Command<int>(id =>
                {
                    delete(id);
                });
            }
        }
        
        /// <summary>
        /// Constructor (Liest die Daten von der Datei aus)
        /// </summary>
        public ListPageVM()
        {
            var file = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "eintraege.json");
            var json = File.ReadAllText(file);

            List<MainModel> dataList = JsonConvert.DeserializeObject<List<MainModel>>(json);
            data = new ObservableCollection<MainModel>(dataList);

            foreach(var item in data)
            {
                gesamt += item.Geld;
            }
        }

    

    async void delete(int id)
        {
            var choice = await App.Current.MainPage.DisplayAlert("Achtung!", "Sind Sie sicher, dass Sie diesen Eintrag löschen wollen?", "Ja", "Nein");
            if (choice)
            {
                var file = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "eintraege.json");
                for (int i = data.Count - 1; i >= 0; i--)
                {
                    if(id == data[i].ID)
                    {
                        data.Remove(data[i]);
                    }
                }
                await Application.Current.MainPage.Navigation.PopAsync();
                string input = JsonConvert.SerializeObject(data);
                File.WriteAllText(file, input);
            }

        }

    }
}
