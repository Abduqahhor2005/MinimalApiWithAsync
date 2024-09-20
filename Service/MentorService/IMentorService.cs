using Client.Model;

namespace Client.Service.MentorService;

public interface IMentorService
{
    Task<IEnumerable<Mentor>> GetAll();
    Task<Mentor?> GetById(int id);
    Task<bool> CreateAsync(Mentor mentor);
    Task<bool> UpdateAsync(Mentor mentor);
    Task<bool> DeleteAsync(int id);
}