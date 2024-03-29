﻿using Aplicacion_PC_Intermodular.API.Controllers;
using Aplicacion_PC_Intermodular.API.Models;
using Aplicacion_PC_Intermodular.CRUD.Models;
using Aplicacion_PC_Intermodular.ErrorManager;
using Aplicacion_PC_Intermodular.Login.Models;
using Syncfusion.UI.Xaml.ProgressBar;
using Syncfusion.Windows.Controls.RichTextBoxAdv;
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
using System.Windows.Media.Animation;
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
            
        }

        private async void putDataOnDataGrid()
        {
            progressBar.Visibility = Visibility.Visible;
            comments = (await CommentController.getAllComments()).data;
            List<CommentsDG>  commentsdg = new List<CommentsDG>();

            if (comments != null)
            {
                dataGridComments.Opacity = 0;
                

                for (int i = 0; i < comments.Length; i++)
                {
                    UserResponse user = await UserController.getUserById(comments[i].user);
                    Route route = await RoutesController.getRouteById(comments[i].post);
                    commentsdg.Add(new CommentsDG(i, user.nick, route.name, comments[i].message));
                }
                progressBar.Visibility= Visibility.Hidden;
                dataGridComments.ItemsSource = commentsdg;
                DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromSeconds(0.5));
                dataGridComments.BeginAnimation(DataGrid.OpacityProperty, animation);

            }
            else
            {
                new CustomErrorManager("An error has ocurred, please contact with your administrator", MessageType.Error, MessageButtons.Ok).ShowDialog();
            }
        }

        private async void remove_btn_Click(object sender, RoutedEventArgs e)
        {
            int index = dataGridComments.SelectedIndex;
            CommentResponse comment = comments[index];
            DefaultResponse response = await CommentController.removeComment(comment._id);
            if(response.status< 300)
            {
                new CustomErrorManager(response.data, MessageType.Success, MessageButtons.Ok).ShowDialog();
                putDataOnDataGrid();

            }
            else
            {
                new CustomErrorManager(response.data,MessageType.Error, MessageButtons.Ok).ShowDialog();
            }
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            putDataOnDataGrid();
        }

        private void dataGridComments_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headername = e.Column.Header.ToString();

            if (headername.Equals("Index"))
            {
                e.Column.Width = 80;
            }
        }

        private async void viewComment_btn_Click(object sender, RoutedEventArgs e)
        {
            int index = dataGridComments.SelectedIndex;
            Application.Current.Properties["COMMENT"] = comments[index];
            Application.Current.Properties["USERCOMMENT"] = await UserController.getUserById(comments[index].user);
            ViewCommentWindow commentView = new ViewCommentWindow();
            commentView.ShowDialog();
        }
    }
}
