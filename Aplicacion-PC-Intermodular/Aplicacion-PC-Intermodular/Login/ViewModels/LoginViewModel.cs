using Aplicacion_PC_Intermodular.Login.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_PC_Intermodular.Login.ViewModels
{


    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] String propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public LoginViewModel() 
        {
            email= string.Empty;
            password= string.Empty;
        }

        private String _email;

        public String email { 
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

        public String password { get; set; }


    }
}
