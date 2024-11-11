using StudentAspireApp.ApiService.Model;

namespace StudentAspireCrud.ApiService.Interface
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int studentId);
        Task AddStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(long studentId);

        Task<Student>UpdateStudentAsync(long studentId, Student student);
    }
}
