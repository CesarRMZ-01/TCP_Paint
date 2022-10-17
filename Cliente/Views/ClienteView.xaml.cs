using Cliente.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Windows.Shapes;

namespace Cliente.Views
{
    /// <summary>
    /// Lógica de interacción para ClienteView.xaml
    /// </summary>
    public partial class ClienteView : Window
    {
        public ClienteView()
        {
            InitializeComponent();

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

           ((ClienteViewModel)this.DataContext).PosY = (((ClienteViewModel)this.DataContext).Dibu.Y) * .25;
        }

        private void Slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((ClienteViewModel)this.DataContext).PosX = (((ClienteViewModel)this.DataContext).Dibu.X) * .25;
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ((ClienteViewModel)this.DataContext).PosY = Mouse.GetPosition(Prev).Y;
            ((ClienteViewModel)this.DataContext).PosX = Mouse.GetPosition(Prev).X;

            ((ClienteViewModel)this.DataContext).Dibu.Y = Mouse.GetPosition(Prev).Y * 4;
            ((ClienteViewModel)this.DataContext).Dibu.X = Mouse.GetPosition(Prev).X * 4;
        }
    }
}
