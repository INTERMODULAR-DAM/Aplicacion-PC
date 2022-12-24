using Aplicacion_PC_Intermodular.ForgotPassword;
using Aplicacion_PC_Intermodular.ForgotPassword.logicMail;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Aplicacion_PC_Intermodular
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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
           

        }

        private void forgetPassword_Click(object sender, RoutedEventArgs e)
        {
           ForgotPasswordWindow forgotPasswordWindow = new ForgotPasswordWindow();
            forgotPasswordWindow.ShowDialog();
        }
    }
}
