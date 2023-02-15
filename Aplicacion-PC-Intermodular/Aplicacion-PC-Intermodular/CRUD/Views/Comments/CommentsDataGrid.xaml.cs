using Aplicacion_PC_Intermodular.API.Controllers;
using Aplicacion_PC_Intermodular.API.Models;
using Aplicacion_PC_Intermodular.CRUD.Models;
using Aplicacion_PC_Intermodular.ErrorManager;
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
    /// Interaction logic for CommentsDataGrid.xaml
    /// </summary>
    public partial class CommentsDataGrid : Page
    {
        private CommentResponse[] comments;

        public CommentsDataGrid()
        {
            InitializeComponent();
            putDataOnDataGrid();
        }

        private async void putDataOnDataGrid()
        {
            comments = (await CommentController.getAllComments()).data;
            List<CommentsDG> commentsdg = new List<CommentsDG>();
            if (comments != null)
            {
                for (int i = 0; i < comments.Length; i++)
                {
                    UserResponse user = await UserController.getUserById(comments[i].user);
                    Route route = await RoutesController.getRouteById(comments[i].post);
                    commentsdg.Add(new CommentsDG(i, user.nick, route.name, comments[i].message));
                }
                dataGridComments.ItemsSource = commentsdg;
            }
            else
            {
                new CustomErrorManager("An error has ocurred, please contact with your administrator", MessageType.Error, MessageButtons.Ok).ShowDialog();
            }
        }

        private void remove_btn_Click(object sender, RoutedEventArgs e)
        {
            int index = dataGridComments.SelectedIndex;
            
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void dataGridComments_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headername = e.Column.Header.ToString();

            if (headername.Equals("Index"))
            {
                e.Column.Width = 80;
            }
        }
    }
}
