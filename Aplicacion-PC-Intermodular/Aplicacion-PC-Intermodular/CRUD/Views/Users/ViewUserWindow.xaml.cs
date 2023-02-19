using Aplicacion_PC_Intermodular.API.Models;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Aplicacion_PC_Intermodular.CRUD.Views.Users
{
    /// <summary>
    /// Interaction logic for ViewUserWindow.xaml
    /// </summary>
    public partial class ViewUserWindow : Window
    {
        private UserResponse userFile;
            
        public ViewUserWindow()
        {
            InitializeComponent();
            userFile = new UserResponse();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            userFile = (UserResponse)Application.Current.Properties["USER"];
            assingData();
        }

        private void assingData()
        {
            tb_lastname.Text = userFile.lastname;
            tb_name.Text = userFile.name;
            tb_createdAt.Text = userFile.date.ToShortDateString().ToString();

            tb_nick.Text = userFile.nick;
            tb_phone.Text = userFile.phone_number.ToString();
            tb_web.Text = userFile.web;

            tb_email.Text = userFile.email;
            tb_id.Text = userFile._id;

            string path = @"http://127.0.0.1:8080/api/v1/imgs/users/" + userFile.pfp_path;
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(path, UriKind.Absolute);
            image.EndInit();

            userPFP.Source = image;

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) 
            {
                DragMove();
            }
        }

        private void close_button_Click(object sender, RoutedEventArgs e)
        {
            var ObjAnimation = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.2));
            ObjAnimation.Completed += new EventHandler(Animation_FadeOutCompleted);
            this.BeginAnimation(UIElement.OpacityProperty, ObjAnimation);
        }

        private void Animation_FadeOutCompleted(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
