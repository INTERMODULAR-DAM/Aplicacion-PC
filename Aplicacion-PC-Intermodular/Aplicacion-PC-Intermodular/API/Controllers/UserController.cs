﻿using Aplicacion_PC_Intermodular.API.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows;
using System.Text.Json;
using Aplicacion_PC_Intermodular.Login.Models;
using System.Windows.Markup;
using System.Net.Http;
using System.Net.Http.Json;
using Aplicacion_PC_Intermodular.CRUD.Models;

namespace Aplicacion_PC_Intermodular.API.Controllers
{
    public static class UserController
    {
        private static HttpClient client = new HttpClient();

        public async static Task<DefaultResponse> signIn(User user)
        {
            DefaultResponse json;

            try
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("POST"), "http://localhost:8080/api/v1/users/signIn/");
                requestMessage.Content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.SendAsync(requestMessage);
                string apiResponse = await response.Content.ReadAsStringAsync();
                json = JsonSerializer.Deserialize<DefaultResponse>(apiResponse);
                Application.Current.Properties["TOKEN"] = json.data;
            }
            catch (Exception ex)
            {
                json = new DefaultResponse();
                json.status = 400;
                json.data = "Error al iniciar sesión";
                MessageBox.Show(ex.Message);
            }
            return json;
        }

        public async static Task<AllUsers> getAllUsers()
        {
            AllUsers users;
            try
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("GET"), "http://localhost:8080/api/v1/users/all");
                requestMessage.Headers.Add("Authorization", "Bearer " + Application.Current.Properties["TOKEN"].ToString());
                HttpResponseMessage response = await client.SendAsync(requestMessage);
                string apiResponse = await response.Content.ReadAsStringAsync();
                users = JsonSerializer.Deserialize<AllUsers>(apiResponse);
            }
            catch (Exception ex)
            {
                users = new AllUsers();
            }
            return users;

        }

        public async static Task<DefaultResponse> deleteUser(UserResponse user)
        {
            DefaultResponse json;
            try
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("DELETE"), "http://localhost:8080/api/v1/users/");
                requestMessage.Headers.Add("Authorization", "Bearer " + Application.Current.Properties["TOKEN"].ToString());
                requestMessage.Content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.SendAsync(requestMessage);
                string apiResponse = await response.Content.ReadAsStringAsync();
                json = JsonSerializer.Deserialize<DefaultResponse>(apiResponse);
            }
            catch (Exception)
            {
                json = new DefaultResponse();
                json.status = 400;
                json.data = "Ha ocurrido un error borrando al usuario, inténtelo de nuevo";
            }

            return json;
        }

        public async static Task<DefaultResponse> updateUser(UserResponse user)
        {
            DefaultResponse json;
            try
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("PATCH"), "http://localhost:8080/api/v1/users/");
                requestMessage.Headers.Add("Authorization", "Bearer " + Application.Current.Properties["TOKEN"].ToString());
                requestMessage.Content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.SendAsync(requestMessage);
                string apiResponse = await response.Content.ReadAsStringAsync();
                json = JsonSerializer.Deserialize<DefaultResponse>(apiResponse);

            }
            catch (Exception ex)
            {
                json = new DefaultResponse();
                json.status = 500;
                json.data = "An internal error has ocurred updating the user, please try again";
            }

            return json;
        }

        public async static Task<DefaultResponse> createUser(SignUpUser newUser)
        {
            DefaultResponse json;
            json = new DefaultResponse();
            try
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("POST"), "http://localhost:8080/api/v1/users/signUp");
                requestMessage.Headers.Add("Authorization", "Bearer " + Application.Current.Properties["TOKEN"].ToString());
                requestMessage.Content = new StringContent(JsonSerializer.Serialize(newUser), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.SendAsync(requestMessage);
                string apiResponse = await response.Content.ReadAsStringAsync();
                json = JsonSerializer.Deserialize<DefaultResponse>(apiResponse);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                json = new DefaultResponse();
                json.status = 500;
                json.data = "An internal error has ocurred updating the user, please try again";
            }
            return json;
        }


    }
}