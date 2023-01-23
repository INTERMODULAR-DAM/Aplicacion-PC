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
        private String _id;

        public String id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
               
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
