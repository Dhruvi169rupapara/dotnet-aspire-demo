using StudentAspireApp.ApiService.Model;

namespace StudentAspireCrud.ApiService.Interface
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task AddStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(long studentId);
    }
}
