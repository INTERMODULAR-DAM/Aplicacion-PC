using Aplicacion_PC_Intermodular.API.Models;
using Aplicacion_PC_Intermodular.API;
using Aplicacion_PC_Intermodular.CRUD.Models;
using Aplicacion_PC_Intermodular.Login.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aplicacion_PC_Intermodular.CRUD.Views
{
    /// <summary>
    /// Interaction logic for UsersDataGrid.xaml
    /// </summary>
    public partial class UsersDataGrid : Page
    {
        public UserController userController;
        public AllUsers allUsers;

        public UsersDataGrid()
        {
            InitializeComponent();
            userController = new UserController();
            assignToDataGridView();
        }

        private void assignToDataGridView()
        {
            allUsers = userController.getAllUsers();
            putDataOnDataGrid(allUsers);

        }

        public void putDataOnDataGrid(AllUsers allUsers)
        {
            List<UserDataGrid> users = new List<UserDataGrid>();
            for (int i = 0; i < allUsers.allUsers.Length; i++)
            {
                users.Add(new UserDataGrid(i, allUsers.allUsers[i].email, allUsers.allUsers[i].name, allUsers.allUsers[i].lastname, allUsers.allUsers[i].nick, allUsers.allUsers[i].phone_number.ToString()));
            }
            dataGridUsers.ItemsSource = users;
        }
        private void modify_btn_Click(object sender, RoutedEventArgs e)
        {
            int index = ((UserDataGrid)dataGridUsers.SelectedItem).Index;

            NavigationService.Navigate(new Uri("/CRUD/Views/UpdateUserPage.xaml", UriKind.Relative), allUsers.allUsers[index]);
        }

        private void remove_btn_Click(object sender, RoutedEventArgs e)
        {
            int index = dataGridUsers.SelectedIndex;
            DefaultResponse response = userController.deleteUser(allUsers.allUsers[index]);

            if (response.status >= 400)
            {
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
            NavigationService.Navigate(new Uri("/CRUD/Views/AddUserPage.xaml", UriKind.Relative));
        }
    }
}
