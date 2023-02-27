using Aplicacion_PC_Intermodular.API.Models;
using Aplicacion_PC_Intermodular.Login.Models;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Aplicacion_PC_Intermodular.ErrorManager;
using System.Text.RegularExpressions;
using Aplicacion_PC_Intermodular.API.Controllers;

namespace Aplicacion_PC_Intermodular.CRUD.Views
{
    /// <summary>
    /// Lógica de interacción para UpdateUserPage.xaml
    /// </summary>
    public partial class UpdateUserPage : Page
    {
        public UserResponse updatedUser;
        public UserResponse dbUser { get; set; }
        public Image userPFP;

        public UpdateUserPage()
        {
            updatedUser = new UserResponse();
            userPFP = new Image();
            InitializeComponent();
        }

        private async void remove_btn_Click(object sender, RoutedEventArgs e)
        {
            string path = "~/../../../../Resources/default.jpeg";
            Uri uri = new Uri(path, UriKind.Relative);
            userPFP.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath(path), UriKind.Absolute));
            updatedUser.pfp_path = "default.jpeg";
            DefaultResponse response = await UserController.updateUserPFP(userPFP, updatedUser._id, updatedUser.pfp_path);
            if(response.status < 300)
            {
                new CustomErrorManager(response.data, MessageType.Info, MessageButtons.Ok).ShowDialog();
                pfp.Source = new BitmapImage(uri);
                
            }
            else
            {
                new CustomErrorManager(response.data, MessageType.Error, MessageButtons.Ok).ShowDialog();
            }
            
        }

        private async void modify_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                Uri uri = new Uri(openFileDialog.FileName, UriKind.Absolute);
                userPFP.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                updatedUser.pfp_path = openFileDialog.SafeFileName;
                DefaultResponse response = await UserController.updateUserPFP(userPFP, updatedUser._id, updatedUser.pfp_path);
                
                if (response.status < 300)
                {
                    new CustomErrorManager(response.data, MessageType.Info, MessageButtons.Ok).ShowDialog();
                    pfp.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                }
                else
                {
                    new CustomErrorManager(response.data, MessageType.Error, MessageButtons.Ok).ShowDialog();
                }
            }
        }

        private async void updateUserbtn_Click(object sender, RoutedEventArgs e)
        {
            if(assingData())
            {
                if (!dbUser.EqualsObjectValues(updatedUser))
                {
                    updateServerResponse(await UserController.updateUser(updatedUser, userPFP));
                }
                else
                {
                    new CustomErrorManager("The user didn't change, please change it before click the button", MessageType.Warning, MessageButtons.Ok).ShowDialog();

                }
            }
            else
            {
                new CustomErrorManager("Some fields are wrong, please fix it", MessageType.Warning, MessageButtons.Ok).ShowDialog();
            }
        }

        private void updateServerResponse(DefaultResponse defaultResponse)
        {
            if (defaultResponse.status < 300)
            {
                new CustomErrorManager("User updated correctly!", MessageType.Success, MessageButtons.Ok).ShowDialog();
                NavigationService.GoBack();
            }
            else if (defaultResponse.status < 500)
            {
                new CustomErrorManager(defaultResponse.data, MessageType.Warning, MessageButtons.Ok).ShowDialog();
            }
            else
            {
                new CustomErrorManager(defaultResponse.data, MessageType.Error, MessageButtons.Ok).ShowDialog();
            }
        }

        public bool assingData()
        {
            bool isValid = true;
            if (!String.IsNullOrEmpty(tb_email.Text))
            {
                if (new Regex("^\\S+@\\S+\\.\\S+$").IsMatch(tb_email.Text))
                {
                    updatedUser.email = tb_email.Text;
                    tb_email.BorderBrush = new SolidColorBrush(Colors.Black);
                    tb_email.BorderThickness = new Thickness(0, 0, 0, 1);
                }
                else
                {
                    tb_email.BorderBrush = new SolidColorBrush(Colors.Red);
                    tb_email.BorderThickness = new Thickness(1, 1, 1, 1);
                    isValid = false;
                }
            }else
            {
                tb_email.BorderBrush = new SolidColorBrush(Colors.Black);
                tb_email.BorderThickness = new Thickness(0, 0, 0, 1);
            }

            if (!String.IsNullOrEmpty(tb_name.Text))
            {
                updatedUser.name = tb_name.Text;
            }
            if (!String.IsNullOrEmpty(tb_lastname.Text))
            {
                updatedUser.lastname = tb_lastname.Text;
            }
            if (!String.IsNullOrEmpty(tb_nick.Text))
            {
                updatedUser.nick = tb_nick.Text;
            }
            if (!String.IsNullOrEmpty(tb_web.Text))
            {
                updatedUser.web = tb_web.Text;
            }
            if (!String.IsNullOrEmpty(tb_phone.Text))
            {
                if(new Regex("^\\+?[1-9][0-9]{6,8}$").IsMatch(tb_phone.Text))
                {
                    updatedUser.phone_number = int.Parse(tb_phone.Text);
                   tb_phone.BorderBrush = new SolidColorBrush(Colors.Black);
                    tb_phone.BorderThickness = new Thickness(0, 0, 0, 1);
                }
                else
                {
                    isValid = false;
                    tb_phone.BorderBrush = new SolidColorBrush(Colors.Red);
                    tb_phone.BorderThickness = new Thickness(1, 1, 1, 1);
                }
            }
            else
            {
                tb_phone.BorderBrush = new SolidColorBrush(Colors.Black);
                tb_phone.BorderThickness = new Thickness(0, 0, 0, 1);
            }

            if (updatedUser.pfp_path.Length > 200)
            {
                updatedUser.pfp_path = " ";
            }
            return isValid;
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            updatedUser = (UserResponse)Application.Current.Properties["USER"];
            dbUser = new UserResponse(updatedUser);
            string path =  @"http://127.0.0.1:8080/api/v1/imgs/users/" + dbUser.pfp_path;
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(path, UriKind.Absolute);
            image.EndInit();
            pfp.Source = image;
            assignPlaceholder();
        }


        private void assignPlaceholder()
        {
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, "Actual name: " + dbUser.name);
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_lastname, "Actual lastname: " + dbUser.lastname);
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_email, "Actual email: " + dbUser.email);
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_web, "Actual web: " + dbUser.web);
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_nick, "Actual nick: " + dbUser.nick);
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_phone, "Actual phone: " + dbUser.phone_number);
        }
    }
}
