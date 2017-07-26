using AddressBook.ViewModel;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using AddressBook;

namespace AddressBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new AddressBookViewModel();
        }

        

        

        private void imageFoo_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //Do something
            OpenFileDialog open = new OpenFileDialog();
            // image filters
            open.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                            "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                            "Portable Network Graphic (*.png)|*.png";
            if (open.ShowDialog() == true)
            {

                // image file path
               // img.Source = new BitmapImage(new System.Uri(open.FileName));

                ((AddressBookViewModel)(this.DataContext)).SelectedEmployee.ImagePath = open.FileName;


               


            }
        }
    }
}
