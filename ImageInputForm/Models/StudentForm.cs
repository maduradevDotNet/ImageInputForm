using Microsoft.AspNetCore.Http;

namespace ImageInputForm.Models
{
    public class StudentForm
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public IFormFile? Image { get; set; } // Attribute for uploading image
    }
}
