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

namespace Aplicacion_PC_Intermodular.API
{
    public class UserController
    {
        private static HttpClient client = new HttpClient();

        public LoginResponse signIn(User user)
        {
            LoginResponse json;

            try
            { 
                HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("POST"), "http://localhost:8080/api/v1/users/signIn/");
                requestMessage.Content = new StringContent(JsonSerializer.Serialize<User>(user), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.SendAsync(requestMessage).Result;
                string apiResponse = response.Content.ReadAsStringAsync().Result;
                json =  JsonSerializer.Deserialize<LoginResponse>(apiResponse);
                Application.Current.Properties["TOKEN"] = json.data;
            }
            catch(Exception ex)
            {
                json = new LoginResponse();
                json.status = 400;
                json.data = "Error al iniciar sesión";
                MessageBox.Show(ex.Message);
                /*response.ReasonPhrase.toString()*/
            }
            return json;
        }

        public AllUsers getAllUsers()
        {
            AllUsers users;
            try
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("GET"), "http://localhost:8080/api/v1/users/all");
                requestMessage.Headers.Add("Authorization", "Bearer " + Application.Current.Properties["TOKEN"].ToString());
                HttpResponseMessage response = client.SendAsync(requestMessage).Result;
                String apiResponse = response.Content.ReadAsStringAsync().Result;

                users = JsonSerializer.Deserialize<AllUsers>(apiResponse);

            }catch(Exception ex)
            {
                users = new AllUsers();
                MessageBox.Show(ex.Message);
            }
            return users;

        }





        

    }   
}
