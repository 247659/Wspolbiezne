using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new VievModelController();
        }
        
        private void GenerateBalls(int numberOfBalls)
        {
            canvas.Children.Clear();
            Random random = new Random();
            for (int i = 0; i < numberOfBalls; i++)
            {
                Ellipse ball = new Ellipse();
                ball.Width = 20;
                ball.Height = 20;
                ball.Fill = Brushes.Red;
                int randomX = random.Next(96, 670);
                int randomY = random.Next(90, 370);

                // Losujemy pozycję kulki na płótnie
                double left = randomX;
                double top = randomY;

                Canvas.SetLeft(ball, left);
                Canvas.SetTop(ball, top);

                canvas.Children.Add(ball);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VievModelController viewModel = (VievModelController)DataContext;
            String balls = viewModel.BallsNumber;
            GenerateBalls(Int32.Parse(balls));
        }
    }
}