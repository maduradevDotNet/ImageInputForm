using ImageInputForm.Data;
using ImageInputForm.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace ImageInputForm.Controllers
{
    public class StudentFormController : Controller
    {
        private readonly ApplicationDbContext _Db;

        public StudentFormController(ApplicationDbContext Db)
        {
            _Db = Db;
        }

        public IActionResult Index()
        {
            List<StudentForm> studentForms = _Db.StudentForms.ToList();
            return View(studentForms);
        }

        public IActionResult Create()
        {
            return View(new StudentForm());
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentForm model)
        {
            if (ModelState.IsValid)
            {
                if (model.Image != null && model.Image.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await model.Image.CopyToAsync(memoryStream);
                        model.ImageData = memoryStream.ToArray();
                    }
                }

                _Db.StudentForms.Add(model);
                await _Db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var studentForm = _Db.StudentForms.Find(id);
            if (studentForm == null)
            {
                return NotFound();
            }
            return View(studentForm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentForm model)
        {
            if (ModelState.IsValid)
            {
                var studentForm = _Db.StudentForms.Find(model.Id);
                if (studentForm == null)
                {
                    return NotFound();
                }

                studentForm.Name = model.Name;
                studentForm.Description = model.Description;

                if (model.Image != null && model.Image.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await model.Image.CopyToAsync(memoryStream);
                        studentForm.ImageData = memoryStream.ToArray();
                    }
                }

                _Db.StudentForms.Update(studentForm);
                await _Db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var studentForm = _Db.StudentForms.Find(id);
            if (studentForm == null)
            {
                return NotFound();
            }

            _Db.StudentForms.Remove(studentForm);
            await _Db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
