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

namespace Aplicacion_PC_Intermodular.CRUD.Views
{
    /// <summary>
    /// Lógica de interacción para UpdateUserView.xaml
    /// </summary>
    public partial class UpdateUserView : Window
    {
        private UserResponse user;
        public UpdateUserView(UserResponse user)
        {
            InitializeComponent();
            this.user = user;
            pfp.Source = convertToImage(user.pfp_path);
        }

        public static BitmapImage convertToImage(String pfp)
        {
            byte[] binaryData = Convert.FromBase64String(pfp);

            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = new MemoryStream(binaryData);
            bi.EndInit();

            return bi;
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
            Image img = new Image();
            user.pfp_path = img.FindResource("/Resources/defaultUser.jpg").ToString();
        }

        private void modify_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                user.pfp_path =openFileDialog.FileName;
                user.pfp = Convert.ToBase64String(openFileDialog.OpenFile());
            }
                 
        }
    }
}
