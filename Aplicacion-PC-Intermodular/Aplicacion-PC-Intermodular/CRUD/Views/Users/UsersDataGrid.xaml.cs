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
using Aplicacion_PC_Intermodular.CRUD.Views.Users;
using Syncfusion.UI.Xaml.ProgressBar;
using System.Windows.Media.Animation;

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
            if(allUsers.data != null)
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
            dataGridUsers.Opacity = 0;
            progressBar.Visibility = Visibility.Visible;

            for (int i = 0; i < allUsers.data.Length; i++)
            {
                users.Add(new UserDataGrid(i, allUsers.data[i].email, allUsers.data[i].name, allUsers.data[i].lastname, allUsers.data[i].nick, allUsers.data[i].phone_number.ToString()));
                progressBar.Progress = (i / allUsers.data.Length) * 100;
            }
            progressBar.Visibility = Visibility.Collapsed;
            DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromSeconds(0.5));
            dataGridUsers.BeginAnimation(DataGrid.OpacityProperty, animation);
            dataGridUsers.ItemsSource = users;   
        }

        private void modify_btn_Click(object sender, RoutedEventArgs e)
        {
            int index = ((UserDataGrid)dataGridUsers.SelectedItem).Index;
            UpdateUserPage updateUser = new UpdateUserPage();
            UserResponse userUpdate = allUsers.data[index];
            Application.Current.Properties["USER"] = userUpdate;
            NavigationService.Navigate(updateUser);
        }

        private async void remove_btn_Click(object sender, RoutedEventArgs e)
        {
            int index = dataGridUsers.SelectedIndex;
            DefaultResponse response = await UserController.deleteUser(allUsers.data[index]);

            if (response.status >= 400)
            {
                new CustomErrorManager(response.data, MessageType.Warning, MessageButtons.Ok).ShowDialog(); ;
            }
            else
            {
                new CustomErrorManager("User successfully deleted", MessageType.Success, MessageButtons.Ok).ShowDialog();
                assignToDataGridView();
            }
        }

        private void addUserbtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/CRUD/Views/Users/AddUserPage.xaml", UriKind.Relative));
        }

        private void dataGridUsers_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headername = e.Column.Header.ToString();

            if (headername.Equals("Index"))
            {
                e.Column.Width = 80;
            }
        }

        private void viewUser_btn_Click(object sender, RoutedEventArgs e)
        {
            int index = ((UserDataGrid)dataGridUsers.SelectedItem).Index;
            ViewUserWindow viewUser = new ViewUserWindow();
            UserResponse userUpdate = allUsers.data[index];
            Application.Current.Properties["USER"] = userUpdate;
            viewUser.ShowDialog();
             
        }
    }
}
