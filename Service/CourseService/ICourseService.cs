using Client.Model;

namespace Client.Service.CourseService;

public interface ICourseService
{
    Task<IEnumerable<Course>> GetAll();
    Task<Course?> GetById(int id);
    Task<bool> CreateAsync(Course course);
    Task<bool> UpdateAsync(Course course);
    Task<bool> DeleteAsync(int id);    
}