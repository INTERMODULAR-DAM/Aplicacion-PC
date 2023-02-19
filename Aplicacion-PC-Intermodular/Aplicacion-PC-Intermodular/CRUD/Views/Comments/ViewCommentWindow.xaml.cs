using Aplicacion_PC_Intermodular.API.Models;
using Microsoft.VisualBasic;
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

namespace Aplicacion_PC_Intermodular.CRUD.Views.Comments
{
    /// <summary>
    /// Interaction logic for ViewCommentWindow.xaml
    /// </summary>
    public partial class ViewCommentWindow : Window
    {
        private UserResponse user;
        private CommentResponse comment;

        public ViewCommentWindow()
        {
            InitializeComponent();
            user = new UserResponse();
            comment = new CommentResponse();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            user = (UserResponse)Application.Current.Properties["USERCOMMENT"];
            comment = (CommentResponse)Application.Current.Properties["COMMENT"];
            assingData();
        }

        private void assingData()
        {
            tb_userName.Text = user.nick;
            tb_comment.Text = comment.message;
            tb_createdAt.Text = "Created at: " + comment.date.ToShortDateString().ToString();

            string path = @"http://127.0.0.1:8080/api/v1/imgs/users/" + user.pfp_path;
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(path, UriKind.Absolute);
            image.EndInit();
            imgUser.ImageSource = image;
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
