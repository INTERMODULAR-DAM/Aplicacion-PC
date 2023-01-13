using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_PC_Intermodular.Login.Models
{
     public class User
    {
        private String _email;

        public String email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
               
            }
        }

        private String _password;

        public String password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;            }
        }
    }
}
