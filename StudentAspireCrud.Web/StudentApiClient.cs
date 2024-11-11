using StudentAspireCrud.Web.Models;
using System.Net.Http;
using System.Threading;

namespace StudentAspireCrud.Web
{
    public class StudentApiClient
    {
        private readonly HttpClient _httpClient;

        public StudentApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Student>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<Student>>("/api/student");
        }

        public async Task<Student> AddStudent(AddStudentModel student)
        {
            // Send POST request
            var response = await _httpClient.PostAsJsonAsync("/api/student/add", student);

            // Ensure the response is successful
            response.EnsureSuccessStatusCode();

            // Read and deserialize the response body
            var result = await response.Content.ReadFromJsonAsync<Student>();

            return result;
        }

        public async Task<bool> DeleteStudent(long studentId)
        {
            var response = await _httpClient.DeleteAsync($"/api/student/delete/{studentId}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public class Student
        {
            public int StudentId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }
    }

    
}
