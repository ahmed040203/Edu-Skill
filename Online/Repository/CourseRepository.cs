using Online.Data;
using Online.Models;

namespace Online.Repository
{
    public class CourseRepository:ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses.ToList();
        }

        public Course GetCourseById(int id)
        {
            return _context.Courses.FirstOrDefault(c => c.CourseId == id);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categoryes.ToList();
        }
    }
}
