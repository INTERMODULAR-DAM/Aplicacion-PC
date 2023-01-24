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
            Application.Current.Properties["TOKEN"] = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJtYXJ0aW5lem1vcmlsbG9hbGVqYW5kcm9AZ21haWwuY29tIiwicm9sIjp0cnVlLCJpYXQiOjE2NzQ1NTYzMDMsImV4cCI6MTY3NDU4NTEwM30.R1FFJixKXb6Sc8Rv9cz7VZBR9xY8hFd8orTvr7ZbyEI";
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
            Application.Current.Shutdown();
        }

        private void asignToDataGridView()
        {
            allUsers = userController.getAllUsers();
            putDataOnDataGrid(allUsers);

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

        public void putDataOnDataGrid(AllUsers allUsers)
        {
            List<UserDataGrid> users = new List<UserDataGrid>();
            for(int i = 0; i < allUsers.allUsers.Length; i++)
            {
                users.Add(new UserDataGrid(i, allUsers.allUsers[i]._id, allUsers.allUsers[i].name, allUsers.allUsers[i].lastname, allUsers.allUsers[i].nick, allUsers.allUsers[i].phone_number.ToString()));
            }
            dataGridUsers.ItemsSource = users;
        }

        private void modify_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(((UserDataGrid) dataGridUsers.SelectedItem).Email);
        }

        private void remove_btn_Click(object sender, RoutedEventArgs e)
        {
            int index = dataGridUsers.SelectedIndex;
            userController.deleteUser(allUsers.allUsers[index]);
        }
    }
}
