using Aplicacion_PC_Intermodular.API.Models;
using Aplicacion_PC_Intermodular.ErrorManager;
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
    public static class RoutesController
    {
        private static HttpClient client = new HttpClient();

        public static async Task<AllRoutes> getAllRoutes()
        {
            AllRoutes json = null;
            try
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("GET"), "http://localhost:8080/api/v1/posts/all");
                requestMessage.Headers.Add("Authorization", "Bearer " + Application.Current.Properties["TOKEN"].ToString());
                HttpResponseMessage response = await client.SendAsync(requestMessage);
                string apiResponse = await response.Content.ReadAsStringAsync();
                json = JsonSerializer.Deserialize<AllRoutes>(apiResponse);
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                json = new AllRoutes();
            }

            return json;
        }

        public static async Task<DefaultResponse> deleteRoute(Route route)
        {
            DefaultResponse json;
            try
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("DELETE"), "http://localhost:8080/api/v1/posts/");
                requestMessage.Headers.Add("Authorization", "Bearer " + Application.Current.Properties["TOKEN"].ToString());
                requestMessage.Content = new StringContent(JsonSerializer.Serialize(route), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.SendAsync(requestMessage);
                string apiResponse = await response.Content.ReadAsStringAsync();
                json = JsonSerializer.Deserialize<DefaultResponse>(apiResponse);
            }
            catch (Exception)
            {
                json = new DefaultResponse();
                json.status = 400;
                json.data = "An error has ocurred removing the post, please try again or contact with your administrator";
            }

            return json;
        }


        public static async Task<DefaultResponse> updateRoute(Route route)
        {
            DefaultResponse json;
            try
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("PATCH"), "http://localhost:8080/api/v1/posts");
                requestMessage.Headers.Add("Authorization", "Bearer " + Application.Current.Properties["TOKEN"].ToString());
                requestMessage.Content = new StringContent(JsonSerializer.Serialize(route), Encoding.UTF8, "application/json");
                MessageBox.Show(route.name);
                HttpResponseMessage response = await client.SendAsync(requestMessage);
                string responseAPI = await response.Content.ReadAsStringAsync();
                json = JsonSerializer.Deserialize<DefaultResponse>(responseAPI);
                

            }
            catch(Exception ex) 
            { 
                json = new DefaultResponse();
                json.status = 500;
                MessageBox.Show(ex.Message);
                json.data = "An internal error has ocurred, please contact with your administrator.";
            }
            return json;
        }

        public static async Task<Route> getRouteById(string id)
        {
            Route route;
            try
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("GET"), "http://localhost:8080/api/v1/posts/");
                requestMessage.Headers.Add("Authorization", "Bearer " + Application.Current.Properties["TOKEN"].ToString());
                requestMessage.Content = new StringContent("{\"_id\":\"" + id + "\"}", Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.SendAsync(requestMessage);
                string apiResponse = await response.Content.ReadAsStringAsync();

                route = JsonSerializer.Deserialize<RouteById>(apiResponse).data;

            }
            catch (Exception ex)
            {
                route = new Route();
            }

            return route;
        }
    }
}
