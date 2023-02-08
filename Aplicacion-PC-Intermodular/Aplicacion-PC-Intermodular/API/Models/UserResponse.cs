using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace Aplicacion_PC_Intermodular.API.Models
{
    public class AllUsers
    {
        public UserResponse[] data { get; set; }
    }

    public class UserResponse
    {
        public UserResponse() 
        {
            web = string.Empty;
            admin = false;
        }

        public UserResponse(UserResponse user)
        {
            _id = user._id;
            email = user.email;
            name = user.name;
            lastname = user.lastname;
            date= user.date;
            nick = user.nick;
            pfp_path = user.pfp_path;
            phone_number = user.phone_number;
            web = user.web;
            admin = user.admin;
        }

        public string _id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public DateTime date { get; set; }
        public string nick { get; set; }
        public string pfp_path { get; set; }
        public int phone_number { get; set; }
        public string web { get; set; }
        public Boolean admin { get; set; }

        public bool EqualsObjectValues(UserResponse obj)
        {
            if (obj.name == name && obj.lastname == lastname && obj.nick == nick && obj.pfp_path == pfp_path && obj.phone_number == phone_number && web == obj.web && obj.email == email)
                return true;
            else
                return false;
        }
    }

}
