using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_PC_Intermodular.CRUD.Models
{
    public class CommentsDG
    {
        public int Index { get; set; }
        public String User { get; set; }
        public String Post { get; set; }
        public String Message { get; set; }


        public CommentsDG(int index, string user, string post, string message)
        {
            Index = index;
            User = user;
            Post = post;
            Message = message;
        }

        
    }
}
