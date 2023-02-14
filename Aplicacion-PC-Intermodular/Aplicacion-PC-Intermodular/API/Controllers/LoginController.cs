using Aplicacion_PC_Intermodular.Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Aplicacion_PC_Intermodular.API.Controllers
{
    public static class LoginController
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
                json.data = "An internal error has ocurred";
            }
            return json;
        }

        public async static Task<DefaultResponse> sendEmail(string email)
        {
            DefaultResponse json;
            try
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("POST"), "http://localhost:8080/api/v1/users/forgotPassword");
                requestMessage.Content = new StringContent("{\"email\":\"" + email + "\"}", Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.SendAsync(requestMessage);
                string apiResponse = await response.Content.ReadAsStringAsync();
                json = JsonSerializer.Deserialize<DefaultResponse>(apiResponse);
            }
            catch (Exception ex)
            {
                json = new DefaultResponse();
                json.status = 400;
                json.data = "An internal error has ocurred";
            }
            return json;
        }
    }
}
