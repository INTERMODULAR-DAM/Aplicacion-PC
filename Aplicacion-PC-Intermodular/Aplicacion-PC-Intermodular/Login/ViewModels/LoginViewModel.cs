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
        private User _user;

        public LoginViewModel()
        {
            _user = new User();
        }

        public User user
        {
            get
            {
                if (_user == null)
                {
                    _user = new User();
                }
                return _user;
            }

            set { _user = value;}
        }

        public String email
        {
            get { return user.email; }
            set { user.email = value;
                OnPropertyChanged(nameof(user.email));
                }
        }

        public String password
        {
            get { return user.password; }
            set { user.password = value;
                OnPropertyChanged(nameof(user.password));
                }
        }


        protected virtual void OnPropertyChanged([CallerMemberName] String propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }        
    }
}
