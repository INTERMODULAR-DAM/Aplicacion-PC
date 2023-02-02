using Aplicacion_PC_Intermodular.API;
using Aplicacion_PC_Intermodular.CRUD;
using Aplicacion_PC_Intermodular.ForgotPassword;
using Aplicacion_PC_Intermodular.Login.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Aplicacion_PC_Intermodular.Utils;

namespace Aplicacion_PC_Intermodular
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public static User user;
        public static DefaultResponse loginResponse;
        public static UserController userController;

        public LoginView()
        {
            user = new User();
            loginResponse = new DefaultResponse();
            userController= new UserController();
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
                MessageBox.Show("Los dos campos deben estar rellenos para iniciar sesión", "WikiTrail le comunica...", MessageBoxButton.OK, MessageBoxImage.Warning);
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


        public void checkInDB()
        {
            loginResponse = userController.signIn(user);
            if(loginResponse.status >=400 && loginResponse.status < 500)
            {
                MessageBox.Show(loginResponse.data, "WikiTrail le comunica...", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                this.Hide();
                cleanTextFields();
                new MainPageCRUD().ShowDialog();
                this.Show();
                
            }
        }
    }
}
