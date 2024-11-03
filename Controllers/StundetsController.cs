using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using student_manager.Web.Data;
using student_manager.Web.Models;
using student_manager.Web.Models.Entities;


namespace student_manager.Web.Controllers
{

    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {

            var student = new Student
            {
                Name = viewModel.Name,
                Age = viewModel.Age,
                Email = viewModel.Email,
                Course = viewModel.Course,
            };
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List", "Students");

        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await dbContext.Students.ToListAsync();

            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
        {
            var student = await dbContext.Students.FindAsync(viewModel.Id);

            if (student is not null)
            {
                student.Name = viewModel.Name;
                student.Age = viewModel.Age;
                student.Email = viewModel.Email;
                student.Course = viewModel.Course;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        // public async Task<IActionResult> Delete(Student viewModel)
        {
            var student = await dbContext.Students.FindAsync(id);
            // var student = await dbContext.Students.FirstOrDefaultAsync(viewModel.Id, );

            if (student is not null)
            {
                dbContext.Students.Remove(student);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
        }
    }
}

