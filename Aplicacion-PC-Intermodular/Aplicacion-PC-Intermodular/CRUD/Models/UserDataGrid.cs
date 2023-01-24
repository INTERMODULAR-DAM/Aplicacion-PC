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
        public UserDataGrid(int index, string email, string name, string lastname, string nick, string phone)
        {
            Index = index;
            Email = email;
            Name = name;
            Lastname = lastname;
            Nick = nick;
            Phone = phone;
        }

        public int Index { get; set; }

        public String Email { get; set;}

        public String Name { get; set;}

        public String Lastname { get; set;}

        public String Nick { get; set;}

        public String Phone { get; set;}

    }
}

