using Aplicacion_PC_Intermodular.API.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Xps.Serialization;
using Aplicacion_PC_Intermodular.Utils;

namespace Aplicacion_PC_Intermodular.CRUD.Views
{
    /// <summary>
    /// Lógica de interacción para UpdateUserView.xaml
    /// </summary>
    public partial class UpdateUserView : Window
    {
        public UserResponse user;
        public UpdateUserView(UserResponse user)
        {
            InitializeComponent();
            this.user = user;
            DataContext = this.user;
            pfp.Source = ImageAndBase64.convertToImage(user.pfp_path);
        }

        

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void logOutButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void usersMenubtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void remove_btn_Click(object sender, RoutedEventArgs e)
        {
            string path = "/Resources/defaultUser.jpg";
            pfp.Source = new BitmapImage(new Uri(path));
            user.pfp = ImageAndBase64.convertToBase64(path);
        }

        private void modify_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                user.pfp_path = openFileDialog.SafeFileName;
                user.pfp = ImageAndBase64.convertToBase64(openFileDialog.FileName);
                MessageBox.Show("Photo successfully updated!", "WikiTrail communicates...", MessageBoxButton.OK, MessageBoxImage.Information);
                pfp.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
                 
        }
    }





}
