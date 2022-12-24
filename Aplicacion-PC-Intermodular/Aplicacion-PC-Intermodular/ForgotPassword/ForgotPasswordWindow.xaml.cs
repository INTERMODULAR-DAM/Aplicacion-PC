using Aplicacion_PC_Intermodular.ForgotPassword.logicMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string emailTo = tb.Text;
            if (emailTo == "")
                MessageBox.Show("El email no puede ser nulo");
            else if (!(new Regex(@"^[a-zA-Z0-9_\-\.]+@[a-zA-Z0-9_\-\.]+\.[a-zA-Z]{2,}$")).IsMatch(emailTo))
                MessageBox.Show("El correo es incorrecto");
            else
            {
                LogicEmail email = new LogicEmail();
                MessageBox.Show(email.sendMail(emailTo));
                this.Close();
            }
        }
    }
}
