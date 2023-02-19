using Aplicacion_PC_Intermodular.API.Controllers;
using Aplicacion_PC_Intermodular.ErrorManager;
using Aplicacion_PC_Intermodular.Login.Models;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Aplicacion_PC_Intermodular.ForgotPassword
{
    /// <summary>
    /// Interaction logic for ForgotPasswordWindow.xaml
    /// </summary>
    public partial class ForgotPasswordWindow : Window
    {
        public ForgotPasswordWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private async void btn_sendEmail_Click(object sender, RoutedEventArgs e)
        {
            string emailTo = tb_user.Text;
            if (emailTo == "")
                new CustomErrorManager("The email can't be null, please type one", MessageType.Warning, MessageButtons.Ok).ShowDialog();
            else if (!(new Regex(@"^[a-zA-Z0-9_\-\.]+@[a-zA-Z0-9_\-\.]+\.[a-zA-Z]{2,}$")).IsMatch(emailTo))
                new CustomErrorManager("It's not a valid email, please type a good one", MessageType.Warning, MessageButtons.Ok).ShowDialog();
            else
            {
                DefaultResponse response = await LoginController.sendEmail(emailTo);
                if(response.status < 300)
                {
                    new CustomErrorManager(response.data, MessageType.Info, MessageButtons.Ok).ShowDialog();
                    close_button_Click(sender, e);
                }
                else
                {
                    new CustomErrorManager(response.data, MessageType.Warning, MessageButtons.Ok).ShowDialog();
                }

            }
        }

        private void close_button_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation(0, TimeSpan.FromSeconds(0.5));
            animation.Completed += new EventHandler(Animation_Completed);
            this.BeginAnimation(Window.OpacityProperty, animation);

        }

        private void Animation_Completed(object? sender, EventArgs e)
        {
            this.Close();
        }
    }

    
}
