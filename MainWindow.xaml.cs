using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppFotoViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OpenFolderDialog openFolderDialog;
        public MainWindow()
        {
            InitializeComponent();
            openFolderDialog = new OpenFolderDialog();
            openFolderDialog.DefaultDirectory = "C:\\data\\fotos";
            openFolderDialog.InitialDirectory = "C:\\data\\fotos";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            openFolderDialog.ShowDialog();
            TextBoxPath.Text = openFolderDialog.FolderName;
            ListBoxPictures.ItemsSource = Directory.GetFiles(openFolderDialog.FolderName);
        }

        private void ListBoxPictures_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}