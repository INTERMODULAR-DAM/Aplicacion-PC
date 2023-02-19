using Aplicacion_PC_Intermodular.ErrorManager;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

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

        public bool ShowDialogRespuesta(LoginView loginView)
        {
            loginView.Hide();
            this.ShowDialog();
            return response;
        }

        private void close_button_Click(object sender, RoutedEventArgs e)
        {
            
            bool? result = new CustomErrorManager("Are you sure to exit?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (result.Value)
            {
                response = true;
                fadeOut();
            }
        }

        private void logOutButton_Click(object sender, RoutedEventArgs e)
        {
            response = false;
            fadeOut();
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

        private void fadeOut()
        {
            var ObjAnimation = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.2));
            ObjAnimation.Completed += new EventHandler(Animation_FadeOutCompleted);
            this.BeginAnimation(UIElement.OpacityProperty, ObjAnimation);
        }

        private void Animation_FadeOutCompleted(object? sender, EventArgs e)
        {
            Close();
        }

        private void CRUDWindow_StateChanged(object sender, EventArgs e)
        {
            if (WindowState.Equals(WindowState.Normal))
            {
                DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromSeconds(0.1));
                this.BeginAnimation(Window.OpacityProperty, animation);
            }

        }

        private void minimize_button_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation(0, TimeSpan.FromSeconds(0.1));
            animation.Completed += new EventHandler(Minimaze_Completed);
            this.BeginAnimation(Window.OpacityProperty, animation);
        }

        private void Minimaze_Completed(object? sender, EventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}

