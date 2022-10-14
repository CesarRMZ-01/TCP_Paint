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

        private void Slider_ValueChanged_2(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            (((ClienteViewModel)this.DataContext).MaxY) = 1132 - (((ClienteViewModel)this.DataContext).Dibu.Alto);
        }

        private void Slider_ValueChanged_3(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            (((ClienteViewModel)this.DataContext).MaxY) = 1132 - (((ClienteViewModel)this.DataContext).Dibu.Alto);

        }
    }
}
