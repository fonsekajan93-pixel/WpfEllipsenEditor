
using System.IO.IsolatedStorage;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
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

        // Ausgewählte Ellipse wird gemerkt
        Ellipse selectedEllipse;


        public MainWindow()
        {
            InitializeComponent();
            

        }

        private void btnCreateEllipse_Click(object sender, RoutedEventArgs e)
        {
            // 1. Ellipse erstellen
            Ellipse ellipse = new Ellipse();

            // 2. Zufällige Größe 
            ellipse.Width = r.Next(20, 180);
            ellipse.Height = r.Next(20, 180);

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


            // 5. Event zuweisen
            ellipse.MouseLeftButtonDown += Ellipse_MouseLeftButtonDown;


            // 6. Ellipse wird hinzugefügt
            cnvsMain.Children.Add(ellipse);

        }


        private void Ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            // falls vorher eine Ellipose ausgewählt war, wird deren Markierung entfernt
            if (selectedEllipse != null )
            {
                selectedEllipse.Stroke = null;
                selectedEllipse.StrokeThickness = 0;

            }

            // Die neu angeklickte Ellipse wird gespeichert
            selectedEllipse = sender as Ellipse;

            // Die neue Auswahl wird sichtbar gemacht
            if (selectedEllipse != null )
            {
                selectedEllipse.Stroke = Brushes.GreenYellow;
                selectedEllipse.StrokeThickness = 6;
            }
            
            e.Handled = true;
        }
    }
}