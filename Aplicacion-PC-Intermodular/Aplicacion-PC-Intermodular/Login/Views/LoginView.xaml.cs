using Aplicacion_PC_Intermodular.CRUD;
using Aplicacion_PC_Intermodular.ForgotPassword;
using Aplicacion_PC_Intermodular.Login.Models;
using System.Windows;
using System.Windows.Input;
using Aplicacion_PC_Intermodular.ErrorManager;
using Aplicacion_PC_Intermodular.API.Controllers;

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

        private void minimize_button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void close_button_Click(object sender, RoutedEventArgs e)
        {
           bool? result =  new CustomErrorManager("Are you sure to exit?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (result.Value) {
                Application.Current.Shutdown();
            }
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
                CRUDView crud = new CRUDView();
                this.Hide();
                cleanTextFields();
                bool response = (bool)crud.ShowDialogRespuesta();
                if (response)
                {
                    Application.Current.Shutdown();
                }
                else
                {
                    crud.Close();
                    this.Show();
                    }
    
            }
        }
    }
}
