using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using System.IO;

namespace hextract.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {

        private ObservableCollection<string> _custColors;
        public ObservableCollection<string> custColors
        {
            get { return _custColors; }
            set
            {
                _custColors = value;
                OnPropertyChanged("custColors");
            }
        }


        public MainWindowViewModel()
        {
            _custColors = new ObservableCollection<string>();
        }


        public void propertyChange(String property)
        {
            OnPropertyChanged(property);
        }


        public void populate(string filepath)
        {
            _custColors.Clear();
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(filepath);
            List<int> decColors = new List<int>();
            while ((line = file.ReadLine()) != null)
            {
                foreach (Match m in Regex.Matches(line, @"#[A-Fa-f0-9]{3,8}"))
                {
                    string hexcolor = m.ToString().Substring(1,m.ToString().Length-1);
                    int deccolor = int.Parse(hexcolor, System.Globalization.NumberStyles.HexNumber);
                    decColors.Add(deccolor);
                }
                
            }

            decColors.Sort();

            foreach(int i in decColors)
            {
                string hexColor = i.ToString("X6");
                hexColor = "#" + hexColor;
                if(!(custColors.Contains(hexColor)))
                {
                    custColors.Add(hexColor);
                }
            }
            OnPropertyChanged("custColors");
            file.Close();
        }


        public void export(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(">> Colour count: " + custColors.Count + " <<");
                sw.WriteLine(">> Exported with Colour Extractor || jlangford.uk/github <<");
            }
            File.AppendAllLines(path, custColors);

        }
    }
}
