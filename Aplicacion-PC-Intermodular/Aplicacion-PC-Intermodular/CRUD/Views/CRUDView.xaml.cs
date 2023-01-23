using Aplicacion_PC_Intermodular.API;
using Aplicacion_PC_Intermodular.API.Models;
using Aplicacion_PC_Intermodular.CRUD.Models;
using Aplicacion_PC_Intermodular.Login.Models;
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
using System.Windows.Shapes;

namespace Aplicacion_PC_Intermodular.CRUD
{
    /// <summary>
    /// Interaction logic for MainPageCRUD.xaml
    /// </summary>
    public partial class MainPageCRUD : Window
    {
        public UserController userController;
        public AllUsers allUsers;

        public MainPageCRUD()
        {
            userController= new UserController();
            InitializeComponent();
            asignToDataGridView();

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

        private void asignToDataGridView()
        {
            ObservableCollection<UserResponse> users = new ObservableCollection<UserResponse>();
            allUsers = userController.getAllUsers();
            users.Add(allUsers.allUsers[0]);
            MessageBox.Show(allUsers.allUsers[0]._id);
            dataGridUsers.ItemsSource= users;

        }

        public static Image convertToImage(String pfp)
        {
            byte[] binaryData = Convert.FromBase64String(pfp);

            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = new MemoryStream(binaryData);
            bi.EndInit();

            Image img = new Image();
            img.Source = bi;
            return img;
        }

    }
}
