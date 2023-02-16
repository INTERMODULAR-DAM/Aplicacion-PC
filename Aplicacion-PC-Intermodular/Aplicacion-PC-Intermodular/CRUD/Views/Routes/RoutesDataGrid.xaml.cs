using Aplicacion_PC_Intermodular.API.Controllers;
using Aplicacion_PC_Intermodular.API.Models;
using Aplicacion_PC_Intermodular.CRUD.Models;
using Aplicacion_PC_Intermodular.CRUD.Views.Comments;
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

namespace Aplicacion_PC_Intermodular.CRUD.Views.Routes
{
    /// <summary>
    /// Interaction logic for RoutesDataGrid.xaml
    /// </summary>
    public partial class RoutesDataGrid : Page
    {

        public Route[] allPosts;

        public RoutesDataGrid()
        {
            InitializeComponent();
            assignToDataGridView();
        }

        private async void remove_btn_Click(object sender, RoutedEventArgs e)
        {
            int index = dataGridRoutes.SelectedIndex;
            DefaultResponse response = await RoutesController.deleteRoute(allPosts[index]);

            if (response.status >= 400)
            {
                new CustomErrorManager(response.data, MessageType.Warning, MessageButtons.Ok).ShowDialog();
            }
            else
            {
                new CustomErrorManager("Post successfully deleted", MessageType.Success, MessageButtons.Ok).ShowDialog();
                assignToDataGridView();
            }
        }

        private void modify_btn_Click(object sender, RoutedEventArgs e)
        {
            int index = ((RouteDataGrid)dataGridRoutes.SelectedItem).Index;
            UpdateRoutePage updateUser = new UpdateRoutePage();
            Route routeUpdate = allPosts[index];
            Application.Current.Properties["ROUTE"] = routeUpdate;
            NavigationService.Navigate(updateUser);
        }

        private void addRouteBtn_Click(object sender, RoutedEventArgs e)
        {
            new CustomErrorManager("This feature will be available in the future, stay tuned!", MessageType.Info, MessageButtons.Ok).ShowDialog();
        }

        private async void assignToDataGridView()
        {
            allPosts = (await RoutesController.getAllRoutes()).allPosts;

            if(allPosts != null)
            {
                putDataOnDataGrid(allPosts);
            }
            else
            {
               new CustomErrorManager("An internal error has ocurred, please contact with your system administrator", MessageType.Error, MessageButtons.Ok).ShowDialog();
            }
        }


        public void putDataOnDataGrid(Route[] allPosts)
        {
            List<Models.RouteDataGrid> routes = new List<Models.RouteDataGrid>();
            for (int i = 0; i < allPosts.Length; i++)
            {
                routes.Add(new RouteDataGrid(i, allPosts[i].name, allPosts[i].category, allPosts[i].distance, allPosts[i].difficulty, allPosts[i].duration));
            }
            dataGridRoutes.ItemsSource = routes;
        }

        private void addComment_button_Click(object sender, RoutedEventArgs e)
        {
            int index = ((RouteDataGrid)dataGridRoutes.SelectedItem).Index;
            Route addCommentRoute = allPosts[index];
            Application.Current.Properties["ROUTE"] = addCommentRoute;
            NavigationService.Navigate(new AddCommentPage());
        }

        private void dataGridRoutes_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headername = e.Column.Header.ToString();

            if (headername.Equals("Index"))
            {
                e.Column.Width = 80;
            }

        }

        private void viewRoute_btn_Click(object sender, RoutedEventArgs e)
        {
            int index = ((RouteDataGrid)dataGridRoutes.SelectedItem).Index;
            Route viewRoute = allPosts[index];
            Application.Current.Properties["ROUTE"] = viewRoute;
            new ViewRouteWindow().ShowDialog();
        }
    }
}
