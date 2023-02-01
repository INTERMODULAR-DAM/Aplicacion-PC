using Aplicacion_PC_Intermodular.API;
using Aplicacion_PC_Intermodular.API.Models;
using Aplicacion_PC_Intermodular.CRUD.Models;
using Aplicacion_PC_Intermodular.CRUD.Views;
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
            Application.Current.Properties["TOKEN"] = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiI2M2Q2Yjk2YjU0ODI0ZmI0ZWJlYzA1MjEiLCJyb2wiOnRydWUsImlhdCI6MTY3NTEwNjA2NywiZXhwIjoxNjc1MTM0ODY3fQ.iJt0wlHnJdxqxnQCT1nuT1L8Zgs2zkMqDDcEiE0Ijp4";
            assignToDataGridView();
            
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

        private void assignToDataGridView()
        {
            allUsers = userController.getAllUsers();
            putDataOnDataGrid(allUsers);

        }

        public void putDataOnDataGrid(AllUsers allUsers)
        {
            List<UserDataGrid> users = new List<UserDataGrid>();
            for(int i = 0; i < allUsers.allUsers.Length; i++)
            {
                users.Add(new UserDataGrid(i, allUsers.allUsers[i].email, allUsers.allUsers[i].name, allUsers.allUsers[i].lastname, allUsers.allUsers[i].nick, allUsers.allUsers[i].phone_number.ToString()));
            }
            dataGridUsers.ItemsSource = users;
        }

        private void modify_btn_Click(object sender, RoutedEventArgs e)
        {
            int index = ((UserDataGrid)dataGridUsers.SelectedItem).Index;
            UserResponse user = allUsers.allUsers[index];
            UpdateUserView updateView = new UpdateUserView(user);
            this.Hide();
            updateView.ShowDialog();
            assignToDataGridView();
            this.Show();
        }

        private void remove_btn_Click(object sender, RoutedEventArgs e)
        {
            int index = dataGridUsers.SelectedIndex;
            DefaultResponse response = userController.deleteUser(allUsers.allUsers[index]);

            if(response.status >= 400){
                MessageBox.Show(response.data, "WikiTrail le comunica...", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBox.Show("Usuario eliminado correctamente", "WikiTrail le comunica...", MessageBoxButton.OK, MessageBoxImage.Information);
                assignToDataGridView();
            }
        }

        private void addUserbtn_Click(object sender, RoutedEventArgs e)
        {
            AddUserPage addUser = new AddUserPage();
            this.Hide();
            addUser.ShowDialog();
            this.Show();
        }
    }
}
