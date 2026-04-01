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
        // Random Klasse erstellt
        Random r = new Random();

        public MainWindow()
        {
            InitializeComponent();
            

        }

        private void btnCreateEllipse_Click(object sender, RoutedEventArgs e)
        {
            // 1. Ellipse erstellen
            Ellipse ellipse = new Ellipse();

            // 2. Zufällige Größe 
            ellipse.Width = r.NextInt64(20, 180);
            ellipse.Height = r.NextInt64(20, 180);

            // 3. Zufällige Farbe
            byte rValue = (byte)r.Next(0, 256);
            byte gValue = (byte)r.Next(0, 256);
            byte bValue = (byte)r.Next(0, 256);

            Color c = Color.FromRgb(rValue, gValue, bValue);
            ellipse.Fill = new SolidColorBrush(c);

            // 4. Zufällige Position (mit Randprüfung)
            int maxX = (int)(cnvsMain.ActualWidth - ellipse.Width);
            int maxY = (int)(cnvsMain.ActualHeight - ellipse.Height);

            int posX = r.Next(0, maxX);
            int posY = r.Next(0, maxY);

            Canvas.SetLeft(ellipse, posX);
            Canvas.SetTop(ellipse, posY);

            // 5. Ellipse wird hinzugefügt
            cnvsMain.Children.Add(ellipse);
        }
    }
}