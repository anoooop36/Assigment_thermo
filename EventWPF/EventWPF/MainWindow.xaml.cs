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

namespace EventWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CommonClickHandler(object sender, RoutedEventArgs e)
        {
            FrameworkElement feSource = e.Source as FrameworkElement;
            switch (feSource.Name)
            {
                case "YesButton":
                    MessageBox.Show("Event is Handled in Stack Panel Bubble up!");
                    break;
                case "NoButton":
                    MessageBox.Show("Event is Handled in Stack Panel Bubble up!");
                    break;
                case "CancelButton":
                    MessageBox.Show("Event is Handled in Stack Panel Bubble up!");
                    break;
            }
            e.Handled = true;
        }
    }
}
