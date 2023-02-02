using Aplicacion_PC_Intermodular.API;
using Aplicacion_PC_Intermodular.API.Models;
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
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Page

    {
        private UserController userController;
        private UserResponse user;

        public AddUser()
        {
            InitializeComponent();
            user = new UserResponse();
            userController = new UserController();
        }

        private void createUserbtn_Click(object sender, RoutedEventArgs e)
        {
            if (checkFields())
            {
                assignFields();
                userController.createUser(user);

            }
            else
            {
                MessageBox.Show("dsfsdfsdf");
            }
        }

        private Boolean checkFields()
        {
            if (String.IsNullOrEmpty(tb_name.SearchTermTextBox.Text) ||
                String.IsNullOrEmpty(tb_lastname.SearchTermTextBox.Text) ||
                String.IsNullOrEmpty(tb_email.SearchTermTextBox.Text) ||
                String.IsNullOrEmpty(tb_nick.SearchTermTextBox.Text) ||
                String.IsNullOrEmpty(tb_phone.SearchTermTextBox.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private void assignFields()
        {

            try
            {
                user.name = tb_name.SearchTermTextBox.Text;
                user.lastname = tb_lastname.SearchTermTextBox.Text;
                user.email = tb_email.SearchTermTextBox.Text;
                user.phone_number = int.Parse(tb_phone.SearchTermTextBox.Text);
                user.admin = (bool)isAdmin.IsChecked;
                user.nick = tb_nick.SearchTermTextBox.Text;
                if (string.IsNullOrEmpty(tb_web.SearchTermTextBox.Text))
                {
                    user.web = string.Empty;
                }
                else
                {
                    user.web = tb_web.SearchTermTextBox.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }

        }

        private void modify_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void remove_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
