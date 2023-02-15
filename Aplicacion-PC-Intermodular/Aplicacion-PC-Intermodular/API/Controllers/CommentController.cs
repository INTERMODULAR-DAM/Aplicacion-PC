using Aplicacion_PC_Intermodular.API.Models;
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
    public static class CommentController
    {
        public static HttpClient client = new HttpClient();


        public static async Task<AllComments> getAllComments()
        {
            AllComments json;
            try
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("GET"), "http://localhost:8080/api/v1/comments/");
                requestMessage.Headers.Add("Authorization", "Bearer " + Application.Current.Properties["TOKEN"].ToString());
                HttpResponseMessage response = await client.SendAsync(requestMessage);
                string apiResponse = await response.Content.ReadAsStringAsync();
                json = JsonSerializer.Deserialize<AllComments>(apiResponse);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                json = new AllComments();
            }

            return json;
        }

        public static async Task<DefaultResponse> AddComment(CommentResponse comment)
        {
            DefaultResponse response;
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("POST"), "http://localhost:8080/api/v1/comments/");
                request.Headers.Add("Authorization", "Bearer " + Application.Current.Properties["TOKEN"].ToString());
                request.Content = new StringContent(JsonSerializer.Serialize(comment), Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = await client.SendAsync(request);
                string responseApi = await responseMessage.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<DefaultResponse>(responseApi);
            }
            catch(Exception ex)
            {
                response = new DefaultResponse();
                response.data = "An internal error has ocurred";
                response.status = 500;
            }

            return response;
        }
    }
}
