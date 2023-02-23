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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aplicacion_PC_Intermodular.CRUD.Views.Routes
{
    /// <summary>
    /// Interaction logic for UpdateRoutePage.xaml
    /// </summary>
    public partial class UpdateRoutePage : Page
    {
        Route updatedRoute;
        Route dbRoute;
        int index;

        public UpdateRoutePage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            loadTime();
            loadDistance();
            updatedRoute = (Route)Application.Current.Properties["ROUTE"];
            dbRoute = new Route(updatedRoute);
            assingPlaceholder();
            if (dbRoute.photos.Length == 0)
            {
                nextPhotobtn.Visibility = Visibility.Collapsed;
                nextPhotobtn.IsEnabled = false;
                imgPost.Source = getPhoto("noPhotos.png");
            }
            else
            {
                imgPost.Source = getPhoto(dbRoute._id + "/" + dbRoute.photos[0]);
            }
        }

        private void assingPlaceholder()
        {
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, "Actual name: " + dbRoute.name);
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cbCategory, "Actual category: " + dbRoute.category);
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cbDifficulty, "Actual difficulty: " + dbRoute.difficulty);
        }

        private void loadTime()
        {
            for (int i = 1; i <= 60; i++)
            {
                cbTime.Items.Add(i.ToString());
                cbTimeMinutes.Items.Add(i.ToString());
            }
        }

        private void loadDistance()
        {
            for (int i = 1; i <= 100; i++)
            {
                cbDistance.Items.Add(i.ToString());
            }

            for (int x = 1; x <= 1000; x++)
            {
                cbDistanceMeters.Items.Add(x.ToString());
            }
        }

        private async void updateRoutebtn_Click(object sender, RoutedEventArgs e)
        {
            assignData();
            if (!updatedRoute.equalRoute(dbRoute))
            {
                updateServerResponse(await RoutesController.updateRoute(updatedRoute));
            }
            else
            {
                new CustomErrorManager("The route didn't change, please change it before click the button", MessageType.Warning, MessageButtons.Ok).ShowDialog();
            }
        }

        private void updateServerResponse(DefaultResponse response)
        {
            if (response.status < 300)
            {
                new CustomErrorManager("Post updated correctly!", MessageType.Success, MessageButtons.Ok).ShowDialog();
                NavigationService.GoBack();
            }
            else
            {
                new CustomErrorManager("An internal error has occurred, please contact with your administrator", MessageType.Error, MessageButtons.Ok).ShowDialog();
            }
        }

        private void assignData()
        {
            if (!String.IsNullOrEmpty(tb_name.Text))
            {
                updatedRoute.name = tb_name.Text;
            }

            if (!String.IsNullOrEmpty(cbCategory.Text))
            {
                updatedRoute.category = cbCategory.Text;
            }

            if (!String.IsNullOrEmpty(cbTime.Text))
            {
                if (cbTimeMinutes.Visibility != Visibility.Hidden && !cbMinutes.Text.Equals(""))
                {
                    updatedRoute.duration = cbTime.Text + "h " + cbTimeMinutes.Text + " m";
                }
                else
                {
                    updatedRoute.duration = cbTime.Text + "h";
                }
            }

            if (!String.IsNullOrEmpty(tb_description.Text))
            {
                updatedRoute.description = tb_description.Text;
            }

            if (!String.IsNullOrEmpty(cbDifficulty.Text))
            {
                updatedRoute.difficulty = cbDifficulty.Text;
            }

            if (!String.IsNullOrEmpty(cbDistance.Text))
            {
                if (cbDistanceMeters.Visibility != Visibility.Hidden && !cbDistanceMeters.Text.Equals(""))
                {
                    updatedRoute.distance = cbDistance.Text + "'" + cbDistanceMeters.Text + "km";
                }
                else
                {
                    updatedRoute.distance = cbDistance.Text + " " + cbDistanceMeasure.Text;
                }
            }
            updatedRoute.privacity = (bool)cbPrivacity.IsChecked;
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            cbTimeMinutes.Visibility = Visibility.Visible;
            cbMinutes.Visibility = Visibility.Visible;
        }

        private void cbiMinutes_Selected(object sender, RoutedEventArgs e)
        {
            cbTimeMinutes.Visibility = Visibility.Hidden;
            cbMinutes.Visibility = Visibility.Hidden;
        }

        private void cbiMeters_Selected(object sender, RoutedEventArgs e)
        {
            cbMeters.Visibility = Visibility.Hidden;
            cbDistanceMeters.Visibility = Visibility.Hidden;
        }

        private void cbieKm_Selected(object sender, RoutedEventArgs e)
        {
            cbMeters.Visibility = Visibility.Visible;
            cbDistanceMeters.Visibility = Visibility.Visible;
        }

        private void nextPhotobtn_Click(object sender, RoutedEventArgs e)
        {
            Image img = imgPost;

            if (index == dbRoute.photos.Length - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
            var ObjAnimation = new DoubleAnimation(0, TimeSpan.FromSeconds(0.33));
            ObjAnimation.Completed += new EventHandler(imgFadeOut_Completed);
            img.BeginAnimation(Image.OpacityProperty, ObjAnimation);

        }

        private void imgFadeOut_Completed(object? sender, EventArgs e)
        {
            imgPost.Source = getPhoto(dbRoute._id + "/" + dbRoute.photos[index]);
            Image img = imgPost;
            var ObjAnimation = new DoubleAnimation(1, TimeSpan.FromSeconds(0.33));
            img.BeginAnimation(Image.OpacityProperty, ObjAnimation);
        }

        private BitmapImage getPhoto(string namePhoto)
        {

            string path = @"http://127.0.0.1:8080/api/v1/imgs/posts/" + namePhoto;
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(path, UriKind.Absolute);
            image.EndInit();
            return image;

        }
    }
}
