using Client.Model;

namespace Client.Service.StudentGroupService;

public interface IStudentGroupService
{
    Task<IEnumerable<StudentGroup>> GetAll();
    Task<StudentGroup?> GetById(int id);
    Task<bool> CreateAsync(StudentGroup studentGroup);
    Task<bool> UpdateAsync(StudentGroup studentGroup);
    Task<bool> DeleteAsync(int id);
}