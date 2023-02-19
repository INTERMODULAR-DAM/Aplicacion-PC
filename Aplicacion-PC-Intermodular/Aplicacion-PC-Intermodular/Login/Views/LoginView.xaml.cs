using Aplicacion_PC_Intermodular.CRUD;
using Aplicacion_PC_Intermodular.ForgotPassword;
using Aplicacion_PC_Intermodular.Login.Models;
using System.Windows;
using System.Windows.Input;
using Aplicacion_PC_Intermodular.ErrorManager;
using Aplicacion_PC_Intermodular.API.Controllers;
using System.Windows.Media.Animation;
using System;
using Aplicacion_PC_Intermodular.API.Models;

namespace Aplicacion_PC_Intermodular
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public static User user;
        public static DefaultResponse loginResponse;

        public LoginView()
        {
            user = new User();
            loginResponse = new DefaultResponse();
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void close_button_Click(object sender, RoutedEventArgs e)
        {
           bool? result =  new CustomErrorManager("Are you sure to exit?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (result.Value) {
                DoubleAnimation animation = new DoubleAnimation(0, TimeSpan.FromSeconds(0.2));
                animation.Completed += new EventHandler(Close_Completed);
                this.BeginAnimation(Window.OpacityProperty, animation);
                
            }
        }

        private void Close_Completed(object? sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)

        {
           if(checkFields()){
                assignParameters();
                checkInDB();
            }

        }

        private void forgetPassword_Click(object sender, RoutedEventArgs e)
        {
           ForgotPasswordWindow forgotPasswordWindow = new ForgotPasswordWindow();
            forgotPasswordWindow.ShowDialog();
        }

        private bool checkFields()
        {
            if (string.IsNullOrEmpty(tbPass.Password.Trim()) || string.IsNullOrEmpty(tbUser.Text.Trim()))
            {
                new CustomErrorManager("The user and password field must be filled.", MessageType.Warning, MessageButtons.Ok).ShowDialog();
                return false;
            }
            return true;
        }

        private void assignParameters()
        {
            user.id = tbUser.Text;
            user.password = tbPass.Password;
        }

        private void cleanTextFields()
        {
            tbUser.Text = "";
            tbPass.Password = "";
        }


        public async void checkInDB()
        {
            loginResponse = await LoginController.signIn(user);
            if(loginResponse.status >=400 && loginResponse.status < 500)
            {
                new CustomErrorManager("Wrong user or password, try it again", MessageType.Error, MessageButtons.Ok).ShowDialog();
            }
            else
            {
                UserResponse user = await UserController.getUserByIdWithToken(Application.Current.Properties["TOKEN"].ToString());
                if (user.admin)
                {
                    cleanTextFields();
                    DoubleAnimation animation = new DoubleAnimation(0, TimeSpan.FromSeconds(0.3));
                    animation.Completed += new EventHandler(Animation_Completed);
                    this.BeginAnimation(Window.OpacityProperty, animation);
                }
                else
                {
                    new CustomErrorManager("You're not an administrator, access denied.", MessageType.Warning, MessageButtons.Ok).ShowDialog();
                }
                
                
    
            }
        }

        private void Animation_Completed(object? sender, EventArgs e)
        {
            CRUDView crud = new CRUDView();

            bool response = (bool)crud.ShowDialogRespuesta(this);

            if (response)
            {
                Application.Current.Shutdown();
            }
            else
            {
                this.Show();
                DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromSeconds(0.5));
                this.BeginAnimation(Window.OpacityProperty, animation);


            }
        }

        private void loginWindow_StateChanged(object sender, EventArgs e)
        {
            if(WindowState.Equals(WindowState.Normal)) 
            {
                DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromSeconds(0.1));
                this.BeginAnimation(Window.OpacityProperty, animation);
            }

        }

        private void minimize_button_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation(0, TimeSpan.FromSeconds(0.1));
            animation.Completed += new EventHandler(Minimaze_Completed);
            this.BeginAnimation(Window.OpacityProperty, animation);
        }

        private void Minimaze_Completed(object? sender, EventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
