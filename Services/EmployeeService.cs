using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using CRUD_OPERATION_UI.Models.Entities;
using Newtonsoft.Json;
using System.Text;
namespace CRUD_OPERATION_UI.Services
{
    public class EmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Employee>>("http://localhost:5220/api/Crudoperation/GetEmployees");
        }

        public async Task<bool> AddEmployeeAsync(string employeeName, string designation, string post, string place, string phone)
        {
            var parameters = new Dictionary<string, string>
    {
        { "employeeName", employeeName },
        { "designation", designation },
        { "post", post },
        { "place", place },
        { "phone", phone }
    };

            var content = new FormUrlEncodedContent(parameters);

            var response = await _httpClient.PostAsync("http://localhost:5220/api/Crudoperation/AddEmployee", content);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateEmployeeAsync(string employeeName, string designation, string post, string place, string phone, int id)
        {
            bool status;
            var requestUri = $"http://localhost:5220/api/Crudoperation/UpdateEmployee?id={id}" +
                             $"&employeeName={Uri.EscapeDataString(employeeName)}" +
                             $"&designation={Uri.EscapeDataString(designation)}" +
                             $"&post={Uri.EscapeDataString(post)}" +
                             $"&place={Uri.EscapeDataString(place)}" +
                             $"&phone={Uri.EscapeDataString(phone)}";

            var response = await _httpClient.PutAsync(requestUri, null);

            var responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                    
                return status = true;
            }
            else
            {
                return status = true;                 
            }         
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:5220/api/Crudoperation/DeleteEmployee?id={id}");

            if (response.IsSuccessStatusCode)
            {
                return true; 
            }
            else
            {
                return false; 
            }
        }

    }
}
