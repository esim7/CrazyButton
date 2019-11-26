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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CrazyButton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        DoubleAnimation AnimationX = new DoubleAnimation();
        DoubleAnimation AnimationY = new DoubleAnimation();
        TransformGroup transformGroup = new TransformGroup();

        public MainWindow()
        {
            InitializeComponent();
            AnimationX.Duration = TimeSpan.FromSeconds(0.5);
            AnimationY.Duration = TimeSpan.FromSeconds(0.15);
            transformGroup.Children.Add(new TranslateTransform(0, 0));
        }

        private void mainWindow(object sender, RoutedEventArgs e)
        {
            //canvas.Width = Width - 6.4;
            //canvas.Height = Height - 45;
        }

        private void PushMe_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Молодец ты поймал меня :)");
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Run(PushButton);
        }

        private void Run(Control control)
        {
            control.RenderTransform = transformGroup;
            AnimationX.To = random.Next(0, (int)(canvas.Width - PushButton.Width));
            AnimationY.To = random.Next(0, (int)(canvas.Height - PushButton.Height));
            TranslateTransform translateTransform = (control.RenderTransform as TransformGroup).Children[0] as TranslateTransform;
            translateTransform.BeginAnimation(TranslateTransform.XProperty, AnimationX);
            translateTransform.BeginAnimation(TranslateTransform.YProperty, AnimationY);
        }
    }
}
