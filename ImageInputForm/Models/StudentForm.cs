using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageInputForm.Models
{
    public class StudentForm
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }

        // Property to store the image data or path
        public byte[]? ImageData { get; set; }
        public string? ImagePath { get; set; }
    }
}
