using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_PC_Intermodular.CRUD.Models
{
    public class CommentsDG
    {
        public int Index;
        public string UserName;
        public string PostName;
        public string Message;


        public CommentsDG(int index, string user, string post, string message)
        {
            Index = index;
            UserName = user;
            PostName = post;
            Message = message;
        }

        
    }
}
