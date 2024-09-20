using Client.Model;

namespace Client.Service.GroupService;

public interface IGroupService
{
    Task<IEnumerable<Group>> GetAll();
    Task<Group?> GetById(int id);
    Task<bool> CreateAsync(Group group);
    Task<bool> UpdateAsync(Group group);
    Task<bool> DeleteAsync(int id);
}