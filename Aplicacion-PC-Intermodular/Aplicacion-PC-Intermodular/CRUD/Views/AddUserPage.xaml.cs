using Aplicacion_PC_Intermodular.API.Models;
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

namespace Aplicacion_PC_Intermodular.CRUD.Views
{
    /// <summary>
    /// Interaction logic for AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Window
    {
        UserResponse user;

        public AddUserPage()
        {
            InitializeComponent();
            user = new UserResponse();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void minimize_button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void close_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void logOutButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void updateUserbtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void modify_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void remove_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
