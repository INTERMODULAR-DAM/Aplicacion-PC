using Aplicacion_PC_Intermodular.ForgotPassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Aplicacion_PC_Intermodular.Navigation
{
    public class Navigator
    {
        public LoginView mw = new LoginView();
        public ForgotPasswordWindow fpw = new ForgotPasswordWindow();
        
        public Navigator() { }

    }
}
