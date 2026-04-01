using System.Security.Cryptography.X509Certificates;
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

namespace WpfEllipsenEditor
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

        private void btnCreateEllipse_Click(object sender, RoutedEventArgs e)
        {
            // Ellipse became create
            Ellipse ellipse = new Ellipse();

            // set height and width of ellipse
            ellipse.Width = 60;
            ellipse.Height = 50;

            // set colour of ellipse
            ellipse.Fill = Brushes.Red;

            Canvas.SetLeft(ellipse, 20);
            Canvas.SetTop(ellipse, 20);

            cnvsMain.Children.Add(ellipse);
        }
    }
}