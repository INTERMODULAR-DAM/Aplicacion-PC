﻿using Aplicacion_PC_Intermodular.API.Models;
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
using System.Diagnostics;
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
        public UserResponse dbUser;

        public UpdateUserPage()
        {
            updatedUser = new UserResponse();
            updatedUser.name = "PRUEBA";
            DataContext = this;
            InitializeComponent();
        }

        private void remove_btn_Click(object sender, RoutedEventArgs e)
        {
            string path = "~/../../../../Resources/default.jpeg";
            Uri uri = new Uri(path, UriKind.Relative);
            pfp.Source = new BitmapImage(uri);
            updatedUser.pfp = ImageUtils.convertToBase64(uri);
            updatedUser.pfp_path = "default.jpeg";
        }

        private void modify_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                updatedUser.pfp_path = openFileDialog.SafeFileName;
                Uri uri = new Uri(openFileDialog.FileName, UriKind.Absolute);
                updatedUser.pfp = ImageUtils.convertToBase64(uri);
                new CustomErrorManager("Photo successfully updated!", MessageType.Info, MessageButtons.Ok).ShowDialog();
                pfp.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private async void updateUserbtn_Click(object sender, RoutedEventArgs e)
        {
            if(assingData())
            {
                if (!dbUser.EqualsObjectValues(updatedUser))
                {
                    updateServerResponse(await UserController.updateUser(updatedUser));
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
            }
            else if (defaultResponse.status < 500)
            {
                new CustomErrorManager("Maybe some fields are in use, check out the email, nick or phone field.", MessageType.Warning, MessageButtons.Ok).ShowDialog();
            }
            else
            {
                new CustomErrorManager("An internal error has occurred, please contact with your administrator", MessageType.Error, MessageButtons.Ok).ShowDialog();
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
                if(new Regex("^\\+?[1-9][0-9]{7,14}$").IsMatch(tb_phone.Text))
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
            pfp.Source = ImageUtils.convertToImage(updatedUser.pfp_path);

        }
    }
}
