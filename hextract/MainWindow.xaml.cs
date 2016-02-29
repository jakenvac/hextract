using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace hextract
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel.MainWindowViewModel mwvm;

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this.DataContext as ViewModel.MainWindowViewModel;
            mwvm = this.DataContext as ViewModel.MainWindowViewModel;

        }

        void RowDefinition_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        void CloseWindow(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        void Window_Drop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            mwvm.populate(files[0]);
        }

        private void ClearList(object sender, MouseButtonEventArgs e)
        {
            mwvm.custColors.Clear();
            mwvm.propertyChange("custColors");
        }

        private void ExportList(object sender, MouseButtonEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog sd = new Microsoft.Win32.SaveFileDialog();
            sd.FileName = "Colours";
            sd.DefaultExt = ".txt";
            sd.Filter = "Text Documents (.txt) | *.txt";
            bool? result = sd.ShowDialog();

            if (result == true)
            {
                mwvm.export(sd.FileName);
            }
        }
    }
}
