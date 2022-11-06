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


        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ((ClienteViewModel)this.DataContext).PosY = Mouse.GetPosition(Prev).Y - ((((ClienteViewModel)this.DataContext).Dibu.Alto / 2)*.25);
            ((ClienteViewModel)this.DataContext).PosX = Mouse.GetPosition(Prev).X - ((((ClienteViewModel)this.DataContext).Dibu.Ancho /2)*.25);

            ((ClienteViewModel)this.DataContext).Dibu.Y = (Mouse.GetPosition(Prev).Y - (((ClienteViewModel)this.DataContext).Dibu.Alto / 2)*.25) * 4;
            ((ClienteViewModel)this.DataContext).Dibu.X = (Mouse.GetPosition(Prev).X - (((ClienteViewModel)this.DataContext).Dibu.Ancho / 2)*.25) * 4;
        }

        private void RED_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            ((ClienteViewModel)this.DataContext).Dibu.Color = "#db2334";
            ((ClienteViewModel)this.DataContext).Color = "#db2334";

            RED.Margin = new Thickness(0, 0, 0, 15);
            ORANGE.Margin = new Thickness(0, 0, 0, 0);
            YELLOW.Margin = new Thickness(0, 0, 0, 0);
            GREEN.Margin = new Thickness(0, 0, 0, 0);
            BLUE.Margin = new Thickness(0, 0, 0, 0);

        }

        private void ORANGE_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ((ClienteViewModel)this.DataContext).Dibu.Color = "#ff9116";
            ((ClienteViewModel)this.DataContext).Color = "#ff9116";

            RED.Margin = new Thickness(0, 0, 0, 0);
            ORANGE.Margin = new Thickness(0, 0, 0, 15);
            YELLOW.Margin = new Thickness(0, 0, 0, 0);
            GREEN.Margin = new Thickness(0, 0, 0, 0);
            BLUE.Margin = new Thickness(0, 0, 0, 0);
        }

        private void YELLOW_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ((ClienteViewModel)this.DataContext).Dibu.Color = "#fbf236";
            ((ClienteViewModel)this.DataContext).Color = "#fbf236";

            RED.Margin = new Thickness(0, 0, 0, 0);
            ORANGE.Margin = new Thickness(0, 0, 0, 0);
            YELLOW.Margin = new Thickness(0, 0, 0, 15);
            GREEN.Margin = new Thickness(0, 0, 0, 0);
            BLUE.Margin = new Thickness(0, 0, 0, 0);
        }

        private void GREEN_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ((ClienteViewModel)this.DataContext).Dibu.Color = "#6abe30";
            ((ClienteViewModel)this.DataContext).Color = "#6abe30";

            RED.Margin = new Thickness(0, 0, 0, 0);
            ORANGE.Margin = new Thickness(0, 0, 0, 0);
            YELLOW.Margin = new Thickness(0, 0, 0, 0);
            GREEN.Margin = new Thickness(0, 0, 0, 15);
            BLUE.Margin = new Thickness(0, 0, 0, 0);

        }

        private void BLUE_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ((ClienteViewModel)this.DataContext).Dibu.Color = "#388aee";
            ((ClienteViewModel)this.DataContext).Color = "#388aee";

            RED.Margin = new Thickness(0, 0, 0, 0);
            ORANGE.Margin = new Thickness(0, 0, 0, 0);
            YELLOW.Margin = new Thickness(0, 0, 0, 0);
            GREEN.Margin = new Thickness(0, 0, 0, 0);
            BLUE.Margin = new Thickness(0, 0, 0, 15);
        }
    }
}
