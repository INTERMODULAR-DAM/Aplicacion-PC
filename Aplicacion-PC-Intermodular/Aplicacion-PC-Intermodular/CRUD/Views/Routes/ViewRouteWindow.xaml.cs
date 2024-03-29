﻿using Aplicacion_PC_Intermodular.API.Controllers;
using Aplicacion_PC_Intermodular.API.Models;
using Aplicacion_PC_Intermodular.Login.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace Aplicacion_PC_Intermodular.CRUD.Views.Routes
{
    /// <summary>
    /// Interaction logic for ViewRouteWindow.xaml
    /// </summary>
    public partial class ViewRouteWindow : Window
    {
        public Route fileRoute;
        public UserResponse userProfile;
        public int indexPhoto;
        public ViewRouteWindow()
        {
            InitializeComponent();
            fileRoute= new Route();
            indexPhoto = 0;
            userProfile = new UserResponse();
        }
        
        private void nextPhotobtn_Click(object sender, RoutedEventArgs e)
        {
            Image img = imgPost;
            
            

            if (indexPhoto == fileRoute.photos.Length -1)
            {
                indexPhoto = 0;
            }
            else
            {
                indexPhoto++;
            }
            var ObjAnimation = new DoubleAnimation(0, TimeSpan.FromSeconds(0.33));
            ObjAnimation.Completed += new EventHandler(imgFadeOut_Completed);
            img.BeginAnimation(Image.OpacityProperty, ObjAnimation);

        }

        private void imgFadeOut_Completed(object? sender, EventArgs e)
        {
            imgPost.Source = getPhoto("posts/" +  fileRoute._id + "/" + fileRoute.photos[indexPhoto]);
            Image img = imgPost;
            var ObjAnimation = new DoubleAnimation(1, TimeSpan.FromSeconds(0.33));
            img.BeginAnimation(Image.OpacityProperty, ObjAnimation);

        }

        private void close_button_Click(object sender, RoutedEventArgs e)
        {
            var ObjAnimation = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.2));
            ObjAnimation.Completed += new EventHandler(Animation_FadeOutCompleted);
            this.BeginAnimation(UIElement.OpacityProperty, ObjAnimation);
        }

        private void Animation_FadeOutCompleted(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fileRoute = (Route) Application.Current.Properties["ROUTE"];
            userProfile = await UserController.getUserById(fileRoute.user);
            assingData();
        }

        private async void assingData()
        {
            tb_title.Text = fileRoute.name;
            tb_distance.Text = fileRoute.distance;
            tb_duration.Text = fileRoute.duration;
            tb_description.Text = fileRoute.description;
            tb_Category.Text = fileRoute.category;
            tb_difficulty.Text = fileRoute.difficulty;
            tb_userName.Text = userProfile.nick.ToUpper();
            tb_createdAt.Text = "Member since: " + userProfile.date.ToShortDateString().ToString();
            tb_followers.Text = "Followers: " + (await UserController.getFollowers(userProfile._id)).data.Length.ToString();

            imgUser.ImageSource = getPhoto("users/" + userProfile.pfp_path);
            if(fileRoute.photos.Length == 0 || fileRoute.photos.Length == 1)
            {
                nextPhotobtn.IsEnabled = false;
                nextPhotobtn.Visibility = Visibility.Collapsed;
                if(fileRoute.photos.Length == 0)
                {
                    imgPost.Source = getPhoto("posts/noPhotos.png");
                }
                
            }
            else
            {
                imgPost.Source = getPhoto("posts/" + fileRoute._id + "/" + fileRoute.photos[0]);
                
            }
        }

        private BitmapImage getPhoto(string namePhoto)
        {
            
            string path = @"http://127.0.0.1:8080/api/v1/imgs/" + namePhoto;
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(path, UriKind.Absolute);
            image.EndInit();
            return image;
        }
    }
}
