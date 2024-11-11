using Microsoft.AspNetCore.Mvc;
using StudentAspireApp.ApiService.Model;
using StudentAspireCrud.ApiService.Interface;
using StudentAspireCrud.ApiService.Services;

namespace StudentAspireCrud.ApiService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)

        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            return await _studentService.GetAllStudentsAsync();
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddStudents(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Ensure student is properly constructed from input
            var studentDetails = new Student()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Age = student.Age,
            };

            // Use the AddStudentAsync method, which is Task, no return expected.
            await _studentService.AddStudentAsync(studentDetails);

            // Return the created student object as confirmation
            return Ok(studentDetails);
        }

        [HttpDelete("Delete/{studentId}")]
        public async Task<IActionResult> DeleteStudent(long studentId)
        {
            var result = await _studentService.DeleteStudentAsync(studentId);

            if (result)
            {
                return Ok(new { Message = "Student deleted successfully." });
            }
            else
            {
                return NotFound(new { Message = "Student not found." });
            }
        }
    }
}
