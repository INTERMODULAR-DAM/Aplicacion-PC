using Aplicacion_PC_Intermodular.API.Models;
using Aplicacion_PC_Intermodular.API;
using Aplicacion_PC_Intermodular.Login.Models;
using Aplicacion_PC_Intermodular.Utils;
using Microsoft.Win32;
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
    /// Lógica de interacción para UpdateUserPage.xaml
    /// </summary>
    public partial class UpdateUserPage : Page
    {
        public UserResponse user;
        private UserController userController;

        public UpdateUserPage()
        {
            userController = new UserController();
            InitializeComponent();
            this.user = NavigationService.Source.
            
        }

        private void remove_btn_Click(object sender, RoutedEventArgs e)
        {
            string path = "~/../../../../Resources/default.jpeg";
            Uri uri = new Uri(path, UriKind.Relative);
            pfp.Source = new BitmapImage(uri);
            user.pfp = ImageUtils.convertToBase64(uri);
            user.pfp_path = "default.jpeg";
        }

        private void modify_btn_Click(object sender, RoutedEventArgs e)
        {
            pfp.Source = ImageUtils.convertToImage(user.pfp_path);

            /*OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                user.pfp_path = openFileDialog.SafeFileName;
                Uri uri = new Uri(openFileDialog.FileName, UriKind.Absolute);
                user.pfp = ImageUtils.convertToBase64(uri);
                MessageBox.Show("Photo successfully updated!", "WikiTrail communicates you...", MessageBoxButton.OK, MessageBoxImage.Information);
                pfp.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }*/
        }

        private void updateUserbtn_Click(object sender, RoutedEventArgs e)
        {
            assingData();
            DefaultResponse response = userController.updateUser(user);
            if (response.status < 300)
            {
                MessageBox.Show("User updated correctly!", "WikiTrail communicates you...", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (response.status < 500)
            {
                MessageBox.Show("Maybe some fields are in use, check out the email, nick or phone field.", "WikiTrail communicates you...", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show("An internal error has occurred, please contact with your administrator", "WikiTrail communicates you...", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public void assingData()
        {
            if (!String.IsNullOrEmpty(tb_email.SearchTermTextBox.Text.ToString()))
            {
                user.email = tb_email.SearchTermTextBox.Text.ToString();
            }
            if (!String.IsNullOrEmpty(tb_name.SearchTermTextBox.Text.ToString()))
            {
                user.name = tb_name.SearchTermTextBox.Text.ToString();
            }
            if (!String.IsNullOrEmpty(tb_lastname.SearchTermTextBox.Text.ToString()))
            {
                user.lastname = tb_lastname.SearchTermTextBox.Text.ToString();
            }
            if (!String.IsNullOrEmpty(tb_nick.SearchTermTextBox.Text.ToString()))
            {
                user.nick = tb_nick.SearchTermTextBox.Text.ToString();
            }
            if (!String.IsNullOrEmpty(tb_web.SearchTermTextBox.Text.ToString()))
            {
                user.web = tb_web.SearchTermTextBox.Text.ToString();
            }
            if (!String.IsNullOrEmpty(tb_phone.SearchTermTextBox.Text.ToString()))
            {
                try
                {
                    user.phone_number = int.Parse(tb_phone.SearchTermTextBox.Text.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The number format isn't good, so we keep the old one.");
                }
            }
        }

        void NavigationService_LoadCompleted(object sender, NavigationEventArgs e)
        {
            UserResponse user = (UserResponse)e.ExtraData;
            MessageBox.Show(user.name);
            this.user = user;
            
        }
    }
}
