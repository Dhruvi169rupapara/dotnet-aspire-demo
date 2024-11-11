using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAspireApp.ApiService.Model;
using StudentAspireApp.AppHost.Model;
using StudentAspireCrud.ApiService.Interface;

namespace StudentAspireCrud.ApiService.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentContext _dbContext;

        public StudentService(StudentContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            var studentObj = await _dbContext.Students.FindAsync(studentId);
            return studentObj;
        }

        public async Task AddStudentAsync(Student student)
        {
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteStudentAsync(long studentId)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(x => x.StudentId == studentId);

            if (student == null) {
                return false;
            }

            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync(); 

            return true;

        }

        public async Task<Student> UpdateStudentAsync(long studentId, Student student)
        {

            var studentObj = await _dbContext.Students.FirstOrDefaultAsync(x => x.StudentId == studentId);
            if (studentObj == null) 
            {
                return null;
            }

            studentObj.FirstName = student.FirstName;
            studentObj.LastName = student.LastName;
            studentObj.Age = student.Age;

            await _dbContext.SaveChangesAsync();

            return studentObj;
        }
    }
}
