using Microsoft.Win32;
using System.Collections.ObjectModel;
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
        //private List<string> images = new();
        private ObservableCollection<string> imageCollection;
        public MainWindow()
        {
            InitializeComponent();
            openFolderDialog = new OpenFolderDialog();
            openFolderDialog.DefaultDirectory = "C:\\VisualStudioProjects\\PG_cursus\\data";
            openFolderDialog.InitialDirectory = "C:\\VisualStudioProjects\\PG_cursus\\data";
            TextBoxPath.Text = openFolderDialog.InitialDirectory;
            imageCollection=new ObservableCollection<string>(Directory.GetFiles(openFolderDialog.InitialDirectory, "*.jpg").ToList());
            ListBoxPictures.ItemsSource = imageCollection;
        }

        private void ButtonFolder_Click(object sender, RoutedEventArgs e)
        {
            openFolderDialog.ShowDialog();
            TextBoxPath.Text = openFolderDialog.FolderName;
            imageCollection= new ObservableCollection<string>(Directory.GetFiles(openFolderDialog.FolderName,"*.jpg").ToList());
        }

        private void ListBoxPictures_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            WindowImage w = new WindowImage(imageCollection,(int)ListBoxPictures.SelectedIndex);
            w.ShowDialog();
        }
    }
}