using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Aplicacion_PC_Intermodular.API.Models
{
    public class AllComments
    {
        public int status { get; set; }
        public CommentResponse[] data { get; set; }
    }

    public class CommentResponse
    {
        public string _id { get; set; }
        public string message { get; set; }
        public string user { get; set; }
        public string post { get; set; }
    }
}
