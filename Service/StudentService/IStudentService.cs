using Client.Model;

public interface IStudentService
{
    Task<IEnumerable<Student>> GetAll();
    Task<Student?> GetById(int id);
    Task<bool> CreateAsync(Student student);
    Task<bool> UpdateAsync(Student student);
    Task<bool> DeleteAsync(int id);
}