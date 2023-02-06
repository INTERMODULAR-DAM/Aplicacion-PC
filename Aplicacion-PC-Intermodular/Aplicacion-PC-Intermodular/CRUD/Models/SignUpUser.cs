using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_PC_Intermodular.CRUD.Models
{
    public class SignUpUser
    {
        public string email { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string nick { get; set; }
        public string phone_number { get; set; }
        public bool admin { get; set; }
        public string web { get; set; }
        public string pfp { get; set; }
        public string pfp_path { get; set; }
        public string password { get; set; }
    }
}
