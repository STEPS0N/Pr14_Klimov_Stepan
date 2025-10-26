using Regex_Klimov.Classes;
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

namespace Regex_Klimov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Classes.Passport> Passports = new List<Classes.Passport>();
        public static MainWindow init;
        
        public MainWindow()
        {
            InitializeComponent();
            init = this;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            new Windows.Add(null).ShowDialog();
        }

        private void Update(object sender, RoutedEventArgs e)
        {

        }

        private void Delete(object sender, RoutedEventArgs e)
        {

        }
    }
}