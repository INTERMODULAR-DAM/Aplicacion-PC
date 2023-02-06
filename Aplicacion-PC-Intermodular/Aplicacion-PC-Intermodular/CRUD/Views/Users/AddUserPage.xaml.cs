using Aplicacion_PC_Intermodular.API.Controllers;
using Aplicacion_PC_Intermodular.API.Models;
using Aplicacion_PC_Intermodular.CRUD.Models;
using Aplicacion_PC_Intermodular.ErrorManager;
using Aplicacion_PC_Intermodular.Login.Models;
using Aplicacion_PC_Intermodular.Utils;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private SignUpUser newUser;

        public AddUser()
        {
            InitializeComponent();
            newUser = new SignUpUser();
        }

        private async void createUserbtn_Click(object sender, RoutedEventArgs e)
        {
            if (checkFields())
            {
                assignFields();
                DefaultResponse response = await UserController.createUser(newUser);
                if(response.status < 300)
                {
                    new CustomErrorManager("User created correctly!", MessageType.Success, MessageButtons.Ok).ShowDialog();
                    cleanAllFields();
                }
                else if(response.status < 500)
                {
                    MessageBox.Show(response.data);
                    new CustomErrorManager(response.data, MessageType.Warning, MessageButtons.Ok).ShowDialog();
                }
                else
                {
                    MessageBox.Show(response.data);

                    new CustomErrorManager("An internal error has ocurred, please contact with your admin.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                }
            }
            else
            {
                markWrongFields();
                new CustomErrorManager("Some required fields are empty, please check it.", MessageType.Warning, MessageButtons.Ok).ShowDialog();
            }
        }

        private void cleanAllFields()
        {
            
            tb_name.BorderBrush = new SolidColorBrush(Colors.Black);
            tb_name.BorderThickness = new Thickness(0, 0, 0, 1);
            tb_name.Text = string.Empty;
           
            tb_lastname.BorderBrush = new SolidColorBrush(Colors.Black);
            tb_lastname.BorderThickness = new Thickness(0, 0, 0, 1);
            tb_lastname.Text = string.Empty;

            tb_email.BorderBrush = new SolidColorBrush(Colors.Black);
            tb_email.BorderThickness = new Thickness(0, 0, 0, 1);
            tb_email.Text = string.Empty;

            tb_nick.BorderBrush = new SolidColorBrush(Colors.Black);
            tb_nick.BorderThickness = new Thickness(0, 0, 0, 1);
            tb_nick.Text = string.Empty;

            tb_phone.BorderBrush = new SolidColorBrush(Colors.Black);
            tb_phone.BorderThickness = new Thickness(0, 0, 0, 1);
            tb_phone.Text = string.Empty;

            tb_password.BorderBrush = new SolidColorBrush(Colors.Black);
            tb_password.BorderThickness = new Thickness(0, 0, 0, 1);
            tb_password.Text = string.Empty;

            tb_repeatPassword.BorderBrush = new SolidColorBrush(Colors.Black);
            tb_repeatPassword.BorderThickness = new Thickness(0, 0, 0, 1);
            tb_repeatPassword.Text = string.Empty;

            remove_btn_Click(new object(), new RoutedEventArgs());

        }

        private Boolean checkFields()
        {
            if (String.IsNullOrEmpty(tb_name.Text) ||
                String.IsNullOrEmpty(tb_lastname.Text) ||
                String.IsNullOrEmpty(tb_email.Text) ||
                String.IsNullOrEmpty(tb_nick.Text) ||
                String.IsNullOrEmpty(tb_phone.Text) ||
                String.IsNullOrEmpty(tb_password.Text) ||
                String.IsNullOrEmpty(tb_repeatPassword.Text) ||
                !tb_repeatPassword.Text.Equals(tb_password.Text) ||
                !new Regex("^\\S+@\\S+\\.\\S+$").IsMatch(tb_email.Text)
                || !new Regex("^\\+?[1-9][0-9]{7,14}$").IsMatch(tb_phone.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void markWrongFields()
        {
            if (String.IsNullOrEmpty(tb_name.Text)){
                tb_name.BorderBrush = new SolidColorBrush(Colors.Red);
                tb_name.BorderThickness = new Thickness(1, 1, 1, 1);
            }
            else
            {
                tb_name.BorderBrush = new SolidColorBrush(Colors.Black);
                tb_name.BorderThickness = new Thickness(0, 0, 0, 1);
            }
            if (String.IsNullOrEmpty(tb_lastname.Text))
            {
                tb_lastname.BorderBrush = new SolidColorBrush(Colors.Red);
                tb_lastname.BorderThickness = new Thickness(1, 1, 1, 1);
            }
            else
            {
                tb_lastname.BorderBrush = new SolidColorBrush(Colors.Black);
                tb_lastname.BorderThickness = new Thickness(0, 0, 0, 1);
            }
            if (String.IsNullOrEmpty(tb_email.Text) ||! new Regex("^\\S+@\\S+\\.\\S+$").IsMatch(tb_email.Text))
            {
                tb_email.BorderBrush = new SolidColorBrush(Colors.Red);
                tb_email.BorderThickness = new Thickness(1, 1, 1, 1);
            }
            else
            {
                tb_email.BorderBrush = new SolidColorBrush(Colors.Black);
                tb_email.BorderThickness = new Thickness(0, 0, 0, 1);
            }
            if (String.IsNullOrEmpty(tb_nick.Text))
            {
                tb_nick.BorderBrush = new SolidColorBrush(Colors.Red);
                tb_nick.BorderThickness = new Thickness(1, 1, 1, 1);
            }
            else
            {
                tb_nick.BorderBrush = new SolidColorBrush(Colors.Black);
                tb_nick.BorderThickness = new Thickness(0, 0, 0, 1);
            }
            if (String.IsNullOrEmpty(tb_phone.Text) || !new Regex("^\\+?[1-9][0-9]{7,14}$").IsMatch(tb_phone.Text))
            {
                tb_phone.BorderBrush = new SolidColorBrush(Colors.Red);
                tb_phone.BorderThickness = new Thickness(1, 1, 1, 1);
            }
            else
            {
                tb_phone.BorderBrush = new SolidColorBrush(Colors.Black);
                tb_phone.BorderThickness = new Thickness(0, 0, 0, 1);
            }
            if (String.IsNullOrEmpty(tb_repeatPassword.Text) || String.IsNullOrEmpty(tb_password.Text) || !tb_repeatPassword.Text.Equals(tb_password.Text))
            {
                tb_password.BorderBrush = new SolidColorBrush(Colors.Red);
                tb_password.BorderThickness = new Thickness(1, 1, 1, 1);

                tb_repeatPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                tb_repeatPassword.BorderThickness = new Thickness(1, 1, 1, 1);
            }
            else
            {
                tb_password.BorderBrush = new SolidColorBrush(Colors.Black);
                tb_password.BorderThickness = new Thickness(0, 0, 0, 1);

                tb_repeatPassword.BorderBrush = new SolidColorBrush(Colors.Black);
                tb_repeatPassword.BorderThickness = new Thickness(0, 0, 0, 1);
            }

        }


        private void assignFields()
        {

            try
            {
                newUser.name = tb_name.Text;
                newUser.lastname = tb_lastname.Text;
                newUser.email = tb_email.Text;
                newUser.phone_number = tb_phone.Text;
                newUser.admin = (bool)isAdmin.IsChecked;
                newUser.nick = tb_nick.Text;
                newUser.password = tb_password.Text;

                if (string.IsNullOrEmpty(tb_web.Text))
                {
                    newUser.web = string.Empty;
                }
                else
                {
                    newUser.web = tb_web.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }

        }

        private void modify_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                newUser.pfp_path = openFileDialog.SafeFileName;
                Uri uri = new Uri(openFileDialog.FileName, UriKind.Absolute);
                newUser.pfp = ImageUtils.convertToBase64(uri);
                new CustomErrorManager("Photo successfully updated!", MessageType.Info, MessageButtons.Ok).ShowDialog();
                pfp.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void remove_btn_Click(object sender, RoutedEventArgs e)
        {
            string path = "~/../../../../Resources/default.jpeg";
            Uri uri = new Uri(path, UriKind.Relative);
            pfp.Source = new BitmapImage(uri);
            newUser.pfp = ImageUtils.convertToBase64(uri);
            newUser.pfp_path = "default.jpeg";
        }
    }
}
