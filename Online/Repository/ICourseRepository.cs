using Online.Models;

namespace Online.Repository
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAllCourses();
        Course GetCourseById(int id);
        IEnumerable<Category> GetAllCategories();
    }
}
