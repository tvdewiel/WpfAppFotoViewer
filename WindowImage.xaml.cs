using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace WpfAppFotoViewer
{
    /// <summary>
    /// Interaction logic for WindowImage.xaml
    /// </summary>
    public partial class WindowImage : Window
    {
        private int index;
        private ObservableCollection<string> fileNames;
        private int settingsIndex = 3;
        private Stretch[] stretchOptions = { Stretch.None, Stretch.Fill, Stretch.Uniform, Stretch.UniformToFill };
        private List<string> settings = new() { "None","Fill","Uniform", "UniformToFill" };
        public WindowImage(ObservableCollection<string> fileNames,int index)
        {
            InitializeComponent();
            this.index = index;
            this.fileNames = fileNames;
            LoadImage();
        }
        private void LoadImage()
        {
            BitmapImage bitmap = new BitmapImage(new Uri(fileNames[index]));
            myImage.Source = bitmap;
        }
        private void ButtonPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (index > 0) index--;
            LoadImage();
            SetTitle();
        }
        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            if (index < fileNames.Count - 1) index++;
            LoadImage();
            SetTitle();
        }
        private void SetTitle()
        {
            this.Title = fileNames[index];
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            fileNames.RemoveAt(index);
            if (index == fileNames.Count) index--;
            LoadImage();
            SetTitle();
        }
        private void myImage_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            ContextMenu contextMenu = new ContextMenu();
            for(int i=0;i<settings.Count;i++)
            {
                MenuItem item = new MenuItem { Header = settings[i], Tag = i };
                if (i == settingsIndex) item.IsChecked = true;
                item.Click += MenuItem_Click;
                contextMenu.Items.Add(item);
            }
           
            // Show context menu at the mouse position
            contextMenu.IsOpen = true;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("You clicked " + ((MenuItem)sender).Header);
            settingsIndex = (int)((MenuItem)sender).Tag;
            myImage.Stretch = stretchOptions[settingsIndex];
        }
    }    
}
