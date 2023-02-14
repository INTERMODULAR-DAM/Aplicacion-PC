using Aplicacion_PC_Intermodular.API.Models;
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
using System.Reflection.PortableExecutable;
using Aplicacion_PC_Intermodular.ErrorManager;
using System.Net.Http.Headers;

namespace Aplicacion_PC_Intermodular.API.Controllers
{
    public static class UserController
    {
        private static HttpClient client = new HttpClient();

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
                MessageBox.Show(ex.Message);
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

        public async static Task<DefaultResponse> updateUser(UserResponse user, Image userPFP)
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

        public async static void updateUserPFP(Image userPFP, string id, string fileName)
        {
            try
            {
                client.DefaultRequestHeaders.Clear();
                var fileStreamContent = new StreamContent(File.OpenRead(new Uri(userPFP.Source.ToString()).AbsolutePath));
                string extension = MimeTypes.GetMimeType(fileName);
                
                MultipartFormDataContent file = new MultipartFormDataContent("NKdKd9Yk");
                file.Headers.ContentType.MediaType = "multipart/form-data";
                fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue(extension);
                file.Add(fileStreamContent, "file", fileName);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Application.Current.Properties["TOKEN"].ToString());
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));
                client.DefaultRequestHeaders.Add("id", id);
                await client.PostAsync("http://localhost:8080/api/v1/imgs/userProfile", file);

           }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

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


        public async static Task<UserResponse> getUserById(string token)
        {
            UserResponse user;
            try
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("GET"), "http://localhost:8080/api/v1/users/");
                requestMessage.Headers.Add("Authorization", "Bearer " + token);
                HttpResponseMessage response = await client.SendAsync(requestMessage);
                string apiResponse = await response.Content.ReadAsStringAsync();

                user = JsonSerializer.Deserialize<UserById>(apiResponse).data;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);    
                user = new UserResponse();
            }
            return user;
        }


    }
}
