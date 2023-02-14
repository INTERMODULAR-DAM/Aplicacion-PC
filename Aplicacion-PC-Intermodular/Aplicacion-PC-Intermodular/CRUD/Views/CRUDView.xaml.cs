﻿using Aplicacion_PC_Intermodular.ErrorManager;
using System;
using System.Windows;
using System.Windows.Input;

namespace Aplicacion_PC_Intermodular.CRUD
{
    /// <summary>
    /// Interaction logic for MainPageCRUD.xaml
    /// </summary>
    public partial class CRUDView : Window
    {
        bool response;

        public CRUDView()
        {
            InitializeComponent();            
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void minimize_button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        public bool ShowDialogRespuesta()
        {
            this.ShowDialog();
            return response;
        }

        private void close_button_Click(object sender, RoutedEventArgs e)
        {
            
            bool? result = new CustomErrorManager("Are you sure to exit?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (result.Value)
            {
                response = true;
                Close();
            }
        }

        private void logOutButton_Click(object sender, RoutedEventArgs e)
        {
            response = false;
            Close();
        }

        private void routesBtn_Click(object sender, RoutedEventArgs e)
        {
            mainContent.Source = new Uri("/CRUD/Views/Routes/RoutesDataGrid.xaml", UriKind.Relative);
        }

        private void commentsBtn_Click(object sender, RoutedEventArgs e)
        {
            mainContent.Source = new Uri("/CRUD/Views/Comments/CommentsDataGrid.xaml", UriKind.Relative);
        }

        private void usersBtn_Click(object sender, RoutedEventArgs e)
        {
            mainContent.Source = new Uri("/CRUD/Views/Users/UsersDataGrid.xaml", UriKind.Relative);
        }
    }
}
