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
using System.Windows.Shapes;

namespace Aplicacion_PC_Intermodular.CRUD.Views.Routes
{
    /// <summary>
    /// Interaction logic for ViewRouteWindow.xaml
    /// </summary>
    public partial class ViewRouteWindow : Window
    {
        public ViewRouteWindow()
        {
            InitializeComponent();
        }
        
        private void nextPhotobtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void close_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
