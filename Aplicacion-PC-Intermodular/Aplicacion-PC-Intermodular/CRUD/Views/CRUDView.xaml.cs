using Aplicacion_PC_Intermodular.API;
using Aplicacion_PC_Intermodular.API.Models;
using Aplicacion_PC_Intermodular.CRUD.Models;
using Aplicacion_PC_Intermodular.CRUD.Views;
using Aplicacion_PC_Intermodular.Login.Models;
using Aplicacion_PC_Intermodular.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aplicacion_PC_Intermodular.CRUD
{
    /// <summary>
    /// Interaction logic for MainPageCRUD.xaml
    /// </summary>
    public partial class MainPageCRUD : Window
    {
        

        public MainPageCRUD()
        {
            InitializeComponent();            
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
            Application.Current.Shutdown();
        }

        private void logOutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void routesBtn_Click(object sender, RoutedEventArgs e)
        {
            mainContent.Source = new Uri("/CRUD/Views/RoutesDataGrid.xaml", UriKind.Relative);
        }

        private void commentsBtn_Click(object sender, RoutedEventArgs e)
        {
            mainContent.Source = new Uri("/CRUD/Views/CommentsDataGrid.xaml", UriKind.Relative);
        }

        private void usersBtn_Click(object sender, RoutedEventArgs e)
        {
            mainContent.Source = new Uri("/CRUD/Views/UsersDataGrid.xaml", UriKind.Relative);
        }
    }
}
