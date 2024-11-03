using student_manager.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace student_manager.Web.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Student> Students { get; set; }
}