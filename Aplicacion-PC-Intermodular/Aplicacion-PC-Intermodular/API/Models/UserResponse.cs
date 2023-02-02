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
        public UserResponse[] allUsers { get; set; }
    }

    public class UserResponse
    {
        public UserResponse() 
        {
            web = string.Empty;
            admin = false;
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
        public string pfp { get; set; }
        public Boolean admin { get; set; }

    }
}
