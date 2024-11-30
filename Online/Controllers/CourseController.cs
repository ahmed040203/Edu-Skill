using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Online.Data;
using Online.Models;
using Online.Repository;

namespace Online.Controllers
{

    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ApplicationDbContext _context;

        public CourseController( ApplicationDbContext context, ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
            _context = context;
        }

        public IActionResult Index()
        {
            var courses = _courseRepository.GetAllCourses();
            ViewData["categ"] = _courseRepository.GetAllCategories();
            return View(courses);
        }

        public IActionResult Detail(int id)
        {
            var course = _courseRepository.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View("Detail", course);
        }































































































































































        //public IActionResult New()
        //{
        //  ViewData["categ"] = _context.Categoryes.ToList();
        //   return View();
        //}

        //[HttpPost]
        //public IActionResult Save(Course course)
        //{

        //    if (course.Title !=null)
        //    {
        //        string fileName = string.Empty;
        //        if (course.clientFile != null)
        //        {
        //            string myUploud = Path.Combine(_host.WebRootPath, "images");
        //            fileName = course.clientFile.FileName;

        //            string fullPath = Path.Combine(myUploud, fileName);
        //            course.clientFile.CopyTo(new FileStream(fullPath,FileMode.Create));
        //            course.Image = fileName;
        //        }
        //            _context.Courses.Add(course);
        //            _context.SaveChanges();
        //            return RedirectToAction("Index");

        //    }
        //    return View("New", course);
        //}
    }
}
