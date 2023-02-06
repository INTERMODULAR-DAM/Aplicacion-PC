using Aplicacion_PC_Intermodular.API.Models;
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
using Aplicacion_PC_Intermodular.ErrorManager;
using Aplicacion_PC_Intermodular.API.Controllers;

namespace Aplicacion_PC_Intermodular.CRUD.Views
{
    /// <summary>
    /// Interaction logic for UsersDataGrid.xaml
    /// </summary>
    public partial class RoutesDataGrid : Page
    {
        public AllUsers allUsers;

        public RoutesDataGrid()
        {
            InitializeComponent();
            assignToDataGridView();
        }

        private async void assignToDataGridView()
        {
            allUsers = await UserController.getAllUsers();
            if(allUsers.allUsers != null)
            {
                putDataOnDataGrid(allUsers);
            }
            else
            {
                new CustomErrorManager("An internal error has ocurred, please contact with your system administrator", MessageType.Error, MessageButtons.Ok).ShowDialog();
            }

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
            UpdateUserPage updateUser = new UpdateUserPage();
            UserResponse userUpdate = allUsers.allUsers[index];
            Application.Current.Properties["USER"] = userUpdate;
            NavigationService.Navigate(updateUser);
        }

        private async void remove_btn_Click(object sender, RoutedEventArgs e)
        {
            int index = dataGridUsers.SelectedIndex;
            DefaultResponse response = await UserController.deleteUser(allUsers.allUsers[index]);

            if (response.status >= 400)
            {
                new CustomErrorManager(response.data, MessageType.Warning, MessageButtons.Ok).ShowDialog(); ;
            }
            else
            {
                new CustomErrorManager("User successfully deleted", MessageType.Success, MessageButtons.Ok);
                assignToDataGridView();
            }
        }

        private void addUserbtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/CRUD/Views/Users/AddUserPage.xaml", UriKind.Relative));
        }
    }
}
