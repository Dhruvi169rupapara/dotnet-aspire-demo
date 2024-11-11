using System.ComponentModel.DataAnnotations;

namespace StudentAspireCrud.Web.Models
{
    public class AddStudentModel
    {
        [Required(ErrorMessage = "First Name is required.")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        public String Age { get; set; }
    }
}
