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

        /// <summary>
        /// Constructor (Liest die Daten von der Datei aus)
        /// </summary>
        public ListPageVM()
        {
            var file = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "eintraege.json");
            var json = File.ReadAllText(file);

            List<MainModel> dataList = JsonConvert.DeserializeObject<List<MainModel>>(json);
            data = new ObservableCollection<MainModel>(dataList);
        }
    }
}
