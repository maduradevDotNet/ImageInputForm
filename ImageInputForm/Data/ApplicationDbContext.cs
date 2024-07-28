using ImageInputForm.Models;
using Microsoft.EntityFrameworkCore;

namespace ImageInputForm.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<StudentForm> StudentForms { get; set; }
    }
}
