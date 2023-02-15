using Aplicacion_PC_Intermodular.API.Controllers;
using Aplicacion_PC_Intermodular.API.Models;
using Aplicacion_PC_Intermodular.ErrorManager;
using Aplicacion_PC_Intermodular.Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aplicacion_PC_Intermodular.CRUD.Views.Comments
{
    /// <summary>
    /// Interaction logic for AddCommentPage.xaml
    /// </summary>
    public partial class AddCommentPage : Page
    {
        private CommentResponse comment;
        public AddCommentPage()
        {
            InitializeComponent();
            comment = new CommentResponse();
        }

        private async void addCommentBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tb_comment.Text))
            {
                comment.message = tb_comment.Text;
                DefaultResponse response = await CommentController.AddComment(comment);

                if(response.status < 300)
                {
                    new CustomErrorManager(response.data, MessageType.Success, MessageButtons.Ok).ShowDialog();
                }
                else
                {
                    new CustomErrorManager(response.data, MessageType.Error,MessageButtons.Ok).ShowDialog();
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            comment.post = ((Route)Application.Current.Properties["ROUTE"])._id;
            comment.user = "63ea283062e481c02b4bf3c7";
        }
    }
}
