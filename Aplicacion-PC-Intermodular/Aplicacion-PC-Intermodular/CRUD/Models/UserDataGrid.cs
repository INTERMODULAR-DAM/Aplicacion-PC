using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Aplicacion_PC_Intermodular.CRUD.Models
{
    class UserDataGrid
    {
        private int _index;
        private String _email;
        private String _password;
        private String _name;
        private String _lastname;
        private String _nick;
        private String _phone;

        public UserDataGrid()
        {
        }

        public UserDataGrid(int index,string email, string name, string lastname, string nick, string pfp, string phone)
        {
            _index = index;
            _email = email;
            _name = name;
            _lastname = lastname;
            _nick = nick;
            _phone = phone;
        }
        public String Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public String Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public String Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public String Nick
        {
            get { return _nick; }
            set { _nick = value; }
        }

        public String Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }
    }
}

