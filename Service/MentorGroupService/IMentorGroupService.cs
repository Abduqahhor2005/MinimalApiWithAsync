using Client.Model;

namespace Client.Service.MentorGroupService;

public interface IMentorGroupService
{
    Task<IEnumerable<MentorGroup>> GetAll();
    Task<MentorGroup?> GetById(int id);
    Task<bool> CreateAsync(MentorGroup mentorGroup);
    Task<bool> UpdateAsync(MentorGroup mentorGroup);
    Task<bool> DeleteAsync(int id);
}